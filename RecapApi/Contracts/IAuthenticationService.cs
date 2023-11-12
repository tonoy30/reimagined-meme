using Microsoft.AspNetCore.Identity;
using RecapApi.DTOs;

namespace RecapApi.Contracts;

public interface IAuthenticationService
{
    Task<IdentityResult> RegisterUserAsync(UserForRegistrationDto userForRegistrationDto);
    Task<bool> ValidateUserAsync(UserForAuthenticationDto userForAuth);
    Task<TokenDto> CreateTokenAsync(bool populateExp);
    Task<TokenDto> RefreshTokenAsync(TokenDto tokenDto);
}