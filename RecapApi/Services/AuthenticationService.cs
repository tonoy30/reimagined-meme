using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RecapApi.Contracts;
using RecapApi.DTOs;
using RecapApi.Entities;
using RecapApi.Exceptions;
using RecapApi.Options;
using Serilog;

namespace RecapApi.Services;

public sealed class AuthenticationService : IAuthenticationService
{
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;
    private readonly JwtConfigurations _configuration;
    private User? _user;

    public AuthenticationService(UserManager<User> userManager, IMapper mapper,
        IOptions<JwtConfigurations> configuration)
    {
        _mapper = mapper;
        _userManager = userManager;
        _configuration = configuration.Value;
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

    public async Task<TokenDto> CreateTokenAsync(bool populateExp)
    {
        var signingCredentials = GetSigningCredentials();
        var claims = await GetClaimsAsync();
        var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
        var refreshToken = GenerateRefreshToken();
        _user.RefreshToken = refreshToken;
        if (populateExp)
        {
            _user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
        }

        await _userManager.UpdateAsync(_user);
        var accessToken = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        return new TokenDto(accessToken, refreshToken);
    }

    public async Task<TokenDto> RefreshTokenAsync(TokenDto tokenDto)
    {
        var principal = GetClaimsPrincipalFromExpiredToken(tokenDto.AccessToken);
        var user = await _userManager.FindByNameAsync(principal.Identity.Name);
        if (user is null || !string.Equals(user.RefreshToken, tokenDto.RefreshToken) ||
            user.RefreshTokenExpiryTime <= DateTime.UtcNow)
        {
            throw new RefreshTokenBadRequest();
        }

        _user = user;
        return await CreateTokenAsync(false);
    }

    private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
    {
        var tokenOptions = new JwtSecurityToken(
            issuer: _configuration.ValidIssuer,
            audience: _configuration.ValidAudience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration.Expires)),
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
        var key = Encoding.UTF8.GetBytes(_configuration.SecretKey);
        var secret = new SymmetricSecurityKey(key);
        return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
    }

    private string GenerateRefreshToken()
    {
        var randomNumber = new byte[32];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }

    private ClaimsPrincipal GetClaimsPrincipalFromExpiredToken(string expiredToken)
    {
        var tokenValidationParams = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = _configuration.ValidIssuer,
            ValidAudience = _configuration.ValidAudience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.SecretKey))
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        var principal = tokenHandler.ValidateToken(expiredToken, tokenValidationParams, out var securityToken);
        if (securityToken == null ||
            !(securityToken as JwtSecurityToken).Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                StringComparison.CurrentCultureIgnoreCase))
        {
            throw new SecurityTokenException("Invalid token");
        }

        return principal;
    }
}