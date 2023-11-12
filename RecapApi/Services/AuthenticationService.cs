using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using RecapApi.Contracts;
using RecapApi.DTOs;
using RecapApi.Entities;
using Serilog;

namespace RecapApi.Services;

public sealed class AuthenticationService : IAuthenticationService
{
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;
    private readonly IConfiguration _configuration;
    private User? _user;

    public AuthenticationService(UserManager<User> userManager, IMapper mapper, IConfiguration configuration)
    {
        _mapper = mapper;
        _userManager = userManager;
        _configuration = configuration;
    }

    public async Task<IdentityResult> RegisterUserAsync(UserForRegistrationDto userForRegistrationDto)
    {
        var user = _mapper.Map<User>(userForRegistrationDto);
        var result = await _userManager.CreateAsync(user, userForRegistrationDto.Password);

        if (result.Succeeded)
        {
            await _userManager.AddToRolesAsync(user, userForRegistrationDto.Roles);
        }

        return result;
    }

    public async Task<bool> ValidateUserAsync(UserForAuthenticationDto userForAuth)
    {
        if (!string.IsNullOrEmpty(userForAuth.UserName))
        {
            _user = await _userManager.FindByNameAsync(userForAuth.UserName);
        }
        else if (!string.IsNullOrEmpty(userForAuth.Email))
        {
            _user = await _userManager.FindByEmailAsync(userForAuth.Email);
        }
        else
        {
            return false;
        }

        var result = _user is not null && await _userManager.CheckPasswordAsync(_user, userForAuth.Password);
        if (!result)
        {
            Log.Warning($"{nameof(ValidateUserAsync)}: Authentication failed. Wrong email/username or password");
        }

        return result;
    }

    public async Task<string> CreateTokenAsync()
    {
        var signingCredentials = GetSigningCredentials();
        var claims = await GetClaimsAsync();
        var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
        return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
    }

    private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
    {
        var jwtConfigurations = _configuration.GetSection("JwtConfigurations");
        var tokenOptions = new JwtSecurityToken(
            issuer: jwtConfigurations["ValidIssuer"],
            audience: jwtConfigurations["ValidAudience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtConfigurations["Expires"])),
            signingCredentials: signingCredentials);
        return tokenOptions;
    }

    private async Task<List<Claim>> GetClaimsAsync()
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, _user.UserName)
        };
        var roles = await _userManager.GetRolesAsync(_user);
        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));
        return claims;
    }

    private SigningCredentials GetSigningCredentials()
    {
        var secretKey = _configuration.GetValue<string>("JwtConfigurations:SecretKey");
        var key = Encoding.UTF8.GetBytes(secretKey);
        var secret = new SymmetricSecurityKey(key);
        return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
    }
}