using AutoMapper;
using Microsoft.AspNetCore.Identity;
using RecapApi.Contracts;
using RecapApi.DTOs;
using RecapApi.Entities;

namespace RecapApi.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;

    public AuthenticationService(UserManager<User> userManager, IMapper mapper)
    {
        _mapper = mapper;
        _userManager = userManager;
    }

    public async Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistrationDto)
    {
        var user = _mapper.Map<User>(userForRegistrationDto);
        var result = await _userManager.CreateAsync(user, userForRegistrationDto.Password);

        if (result.Succeeded)
        {
            await _userManager.AddToRolesAsync(user, userForRegistrationDto.Roles);
        }

        return result;
    }
}