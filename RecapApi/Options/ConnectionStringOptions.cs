namespace RecapApi.Options;

public sealed class ConnectionStringOptions
{
    public const string Name = "ConnectionStrings";
    public string DefaultConnection { get; set; } = string.Empty;
}