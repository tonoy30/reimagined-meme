using System.Text.Json;

namespace RecapApi.Entities;

public sealed class ErrorModel
{
    public int StatusCode { get; set; }
    public string? Message { get; set; }
    public override string ToString() => JsonSerializer.Serialize(this);
}