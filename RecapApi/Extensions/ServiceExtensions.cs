using Microsoft.Extensions.Options;
using RecapApi.Configs;
using RecapApi.Validations;

namespace RecapApi.Extensions;

public static class ServiceExtensions
{
    public static void AddConfigOptions(this WebApplicationBuilder builder)
    {
        builder
            .Services
            .Configure<DbConfig>(builder.Configuration.GetSection(nameof(DbConfig)));
        builder.Services.AddSingleton<IValidateOptions<DbConfig>, DbConfigValidation>();
    }
}