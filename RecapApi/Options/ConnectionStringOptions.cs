namespace RecapApi.Options;

public sealed class ConnectionStringOptions
{
    public const string Name = "ConnectionStrings";
    public required string DefaultConnection { get; set; }
    public required string? RedisUrl { get; set; }
}