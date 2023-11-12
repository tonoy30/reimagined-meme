using System.ComponentModel.DataAnnotations;

namespace RecapApi.DTOs;

public sealed class UserForAuthenticationDto
{
    public string? Email { get; init; }
    public string? UserName { get; init; }

    [Required(ErrorMessage = "Password name is required")]
    public string? Password { get; init; }
}