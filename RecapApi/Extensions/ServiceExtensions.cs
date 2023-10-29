using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RecapApi.Configs;
using RecapApi.DbContexts;
using RecapApi.Validations;

namespace RecapApi.Extensions;

public static class ServiceExtensions
{
    public static void AddConfigOptions(this WebApplicationBuilder builder)
    {
        builder
            .Services
            .Configure<ConnectionStringOptions>(builder.Configuration.GetSection(ConnectionStringOptions.Name));
        builder.Services.AddSingleton<IValidateOptions<ConnectionStringOptions>, ConnectionStringOptionsValidation>();
    }

    public static void AddPostgres(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<ApplicationDbContext>(opt =>
            opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
    }
}