using FluentValidation;
using Microsoft.IdentityModel.Tokens;
using RecapApi.DTOs;

namespace RecapApi.Validators;

public sealed class UserForAuthenticationDtoValidator : AbstractValidator<UserForAuthenticationDto>
{
    public UserForAuthenticationDtoValidator()
    {
        RuleFor(o => o.Email)
            .NotNull()
            .NotEmpty()
            .When(o => o.UserName.IsNullOrEmpty())
            .WithMessage("Email field is required");

        RuleFor(o => o.UserName)
            .NotNull()
            .NotEmpty()
            .When(o => o.Email.IsNullOrEmpty())
            .WithMessage("Username field is required");

        RuleFor(o => o.Password)
            .MinimumLength(10)
            .WithMessage("Password filed must be at least 10 char long");
    }
}