using System.Net;
using RedisRateLimiting.AspNetCore;
using StackExchange.Redis;

namespace RecapApi.Extensions;

public static class RateLimitingExtensions
{
    public static void ConfigureRateLimiting(this WebApplicationBuilder builder)
    {
        var redisUrl = builder.Configuration.GetConnectionString(RecapApiResources.RedisUrl)!;
        builder
            .Services
            .AddRateLimiter(options =>
            {
                options.RejectionStatusCode = (int)HttpStatusCode.TooManyRequests;
                options.AddRedisTokenBucketLimiter(RecapApiResources.TokenBucketRateLimitingPolicy, opt =>
                {
                    opt.ConnectionMultiplexerFactory = () => ConnectionMultiplexer.Connect(redisUrl);
                    opt.TokenLimit = 30;
                    opt.TokensPerPeriod = 1;
                    opt.ReplenishmentPeriod = TimeSpan.FromSeconds(1);
                });
                options.OnRejected = (context, ct) =>
                    RateLimitMetadata.OnRejected(context.HttpContext, context.Lease, ct);
            });
    }
}