using Microsoft.AspNetCore.Identity;
using RecapApi.DTOs;

namespace RecapApi.Contracts;

public interface IAuthenticationService
{
    Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistrationDto);
}