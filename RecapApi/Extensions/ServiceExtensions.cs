using System.Text;
using System.Threading.RateLimiting;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RecapApi.Contracts;
using RecapApi.Entities;
using RecapApi.Options;
using RecapApi.Repositories;
using RecapApi.Services;
using RecapApi.Validators;
using StackExchange.Redis;

namespace RecapApi.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureOptions(this WebApplicationBuilder builder)
    {
        builder
            .Services
            .Configure<ConnectionStringOptions>(builder.Configuration.GetSection(ConnectionStringOptions.Name));
        builder
            .Services
            .AddSingleton<IValidateOptions<ConnectionStringOptions>, ConnectionStringOptionsValidator>();
        builder.Services.Configure<JwtConfigurations>(builder.Configuration.GetSection(JwtConfigurations.Name));
    }

    public static void ConfigurePostgresDb(this WebApplicationBuilder builder)
    {
        builder
            .Services
            .AddDbContext<RepositoryContext>(opt =>
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

    public static void ConfigureRedisDb(this WebApplicationBuilder builder)
    {
        var redisUrl = builder.Configuration.GetConnectionString(RecapApiResources.RedisUrl)!;
        builder.Services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(redisUrl));
    }

    public static void ConfigureIdentity(this WebApplicationBuilder builder)
    {
        builder.Services.AddAuthentication();
        builder
            .Services
            .AddIdentity<User, IdentityRole>(opt =>
                {
                    opt.Password.RequireDigit = true;
                    opt.Password.RequireLowercase = true;
                    opt.Password.RequireUppercase = true;
                    opt.Password.RequireNonAlphanumeric = true;
                    opt.Password.RequiredUniqueChars = 2;
                    opt.Password.RequiredLength = 10;
                    opt.User.RequireUniqueEmail = true;
                }
            )
            .AddEntityFrameworkStores<RepositoryContext>()
            .AddDefaultTokenProviders();
    }

    public static void ConfigureJwtToken(this WebApplicationBuilder builder)
    {
        var jwtConfigurations = builder.Configuration.GetSection("JwtConfigurations");
        builder
            .Services
            .AddAuthentication(opt =>
                {
                    opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }
            )
            .AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtConfigurations["ValidIssuer"],
                    ValidAudience = jwtConfigurations["ValidAudience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfigurations["SecretKey"]!))
                };
            });
    }
}