using Microsoft.AspNetCore.Diagnostics;
using RecapApi.Entities;
using RecapApi.Exceptions;
using Serilog;

namespace RecapApi.Extensions;

public static class ExceptionMiddlewareExtensions
{
    public static void ConfigureExceptionHandler(this WebApplication app)
    {
        app.UseExceptionHandler(builder =>
        {
            builder.Run(async ctx =>
            {
                ctx.Response.ContentType = "application/json";
                var features = ctx.Features.Get<IExceptionHandlerFeature>();
                if (features is not null)
                {
                    ctx.Response.StatusCode = features.Error switch
                    {
                        BadRequestException => StatusCodes.Status400BadRequest,
                        NotFoundException => StatusCodes.Status404NotFound,
                        _ => StatusCodes.Status500InternalServerError
                    };
                    Log.Error("Something went wrong: {Error}", features.Error.ToString());
                    await ctx.Response.WriteAsync(new ErrorModel
                    {
                        StatusCode = ctx.Response.StatusCode,
                        Message = features.Error.Message
                    }.ToString());
                }
            });
        });
    }
}