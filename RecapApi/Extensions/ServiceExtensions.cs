using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RecapApi.Contracts;
using RecapApi.DbContexts;
using RecapApi.Options;
using RecapApi.Validations;

namespace RecapApi.Extensions;

public static class ServiceExtensions
{
    public static void AddConfigOptions(this WebApplicationBuilder builder)
    {
        builder
            .Services
            .Configure<ConnectionStringOptions>(builder.Configuration.GetSection(ConnectionStringOptions.Name));
        builder
            .Services
            .AddSingleton<IValidateOptions<ConnectionStringOptions>, ConnectionStringOptionsValidation>();
    }

    public static void AddPostgres(this WebApplicationBuilder builder)
    {
        builder
            .Services
            .AddDbContext<ApplicationDbContext>(opt =>
                opt.UseNpgsql(builder.Configuration.GetConnectionString(RecapApiResources.PostgresDefaultConnection)));
    }

    public static void ConfigureCors(this IServiceCollection services)
    {
        services.AddCors(opt =>
            opt.AddPolicy(RecapApiResources.CorsPolicy, builder =>
                builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
            ));
    }

    public static void ConfigureRepositoryManager(this IServiceCollection services)
    {
        services.AddScoped<IRepositoryManager, RepositoryManager>();
    }

    public static void ConfigureServiceManager(this IServiceCollection services)
    {
        services.AddScoped<IServiceManager, ServiceManager>();
    }
}