using Microsoft.Extensions.Options;
using RecapApi.Configs;

namespace RecapApi.Validations;

public sealed class DbConfigValidation : IValidateOptions<DbConfig>
{
    public ValidateOptionsResult Validate(string? name, DbConfig options)
    {
        return string.IsNullOrEmpty(options.ConnectionString)
            ? ValidateOptionsResult.Fail("Database connection string is required.")
            : ValidateOptionsResult.Success;
    }
}