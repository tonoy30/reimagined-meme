using Microsoft.Extensions.Options;
using RecapApi.Options;

namespace RecapApi.Validators;

public sealed class ConnectionStringOptionsValidator : IValidateOptions<ConnectionStringOptions>
{
    public ValidateOptionsResult Validate(string? name, ConnectionStringOptions options)
    {
        return string.IsNullOrEmpty(options.DefaultConnection) || string.IsNullOrEmpty(options.RedisUrl)
            ? ValidateOptionsResult.Fail($"{name} is required.")
            : ValidateOptionsResult.Success;
    }
}