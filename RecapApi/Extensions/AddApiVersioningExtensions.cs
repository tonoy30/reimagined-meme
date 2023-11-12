using Asp.Versioning;

namespace RecapApi.Extensions;

public static class AddApiVersioningExtensions
{
    public static void ConfigureApiVersioning(this WebApplicationBuilder builder)
    {
        builder.Services.AddApiVersioning(opt =>
        {
            opt.AssumeDefaultVersionWhenUnspecified = true;
            opt.DefaultApiVersion = new ApiVersion(1, 0);
            opt.ReportApiVersions = true;
            opt.ApiVersionReader = ApiVersionReader.Combine(
                new QueryStringApiVersionReader("api-version"),
                new HeaderApiVersionReader("X-Version"),
                new MediaTypeApiVersionReader("ver")
            );
        });
    }
}