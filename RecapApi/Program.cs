using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.OpenApi.Models;
using RecapApi;
using RecapApi.Extensions;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();
try
{
    Log.Information("Starting web application");
    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog();

    // Add services to the container.
    builder.Services.AddAutoMapper(typeof(Program));
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(s =>
    {
        s.SwaggerDoc("v1", new OpenApiInfo { Title = "Recap AspNet Api", Version = "v1" });
        s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Place to add JWT with Bearer",
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer"
        });
        s.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    },
                    Name = "Bearer",
                },
                new List<string>()
            }
        });
    });

    builder.ConfigureApiVersioning();
    builder.ConfigureOptions();
    builder.ConfigurePostgresDb();
    builder.ConfigureRedisDb();
    builder.ConfigureRateLimiting();
    builder.ConfigureIdentity();
    builder.ConfigureJwtToken();

    builder.Services.ConfigureCors();
    builder.Services.ConfigureRepositoryManager();
    builder.Services.ConfigureServiceManager();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    app.UseRateLimiter();
    app.ConfigureExceptionHandler();
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    else
    {
        app.UseHsts();
    }

    app.UseHttpsRedirection();

    app.UseForwardedHeaders(new ForwardedHeadersOptions
    {
        ForwardedHeaders = ForwardedHeaders.All
    });

    app.UseCors(RecapApiResources.CorsPolicy);

    app.UseAuthentication();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex) when (ex is not HostAbortedException)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}