using Microsoft.Extensions.Options;
using RecapApi.Options;

namespace RecapApi.Validations;

public sealed class ConnectionStringOptionsValidation : IValidateOptions<ConnectionStringOptions>
{
    public ValidateOptionsResult Validate(string? name, ConnectionStringOptions options)
    {
        return string.IsNullOrEmpty(options.DefaultConnection) || string.IsNullOrEmpty(options.RedisUrl)
            ? ValidateOptionsResult.Fail($"{name} is required.")
            : ValidateOptionsResult.Success;
    }
}