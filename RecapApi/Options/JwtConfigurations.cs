namespace RecapApi.Options;

public sealed class JwtConfigurations
{
    public const string Name = "JwtConfigurations";
    public required string ValidIssuer { get; set; }
    public required string ValidAudience { get; set; }
    public required string SecretKey { get; set; }
    public int Expires { get; init; }
}