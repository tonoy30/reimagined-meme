using Microsoft.Extensions.Options;
using RecapApi.Configs;

namespace RecapApi.Validations;

public sealed class ConnectionStringOptionsValidation : IValidateOptions<ConnectionStringOptions>
{
    public ValidateOptionsResult Validate(string? name, ConnectionStringOptions options)
    {
        return string.IsNullOrEmpty(options.DefaultConnection)
            ? ValidateOptionsResult.Fail("Database connection string is required.")
            : ValidateOptionsResult.Success;
    }
}