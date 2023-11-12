using Microsoft.AspNetCore.Identity;

namespace RecapApi.Entities;

public class User : IdentityUser
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string RefreshToken { get; set; }
    public DateTime RefreshTokenExpiryTime { get; set; }
}