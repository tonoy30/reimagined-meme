using System.Text.Json.Serialization;
using RecapApi.Attributes;

namespace RecapApi.Entities;

public class BaseEntity
{
    [JsonPropertyName("created_at")]
    [GenerateOnAdd]
    public DateTime CreatedAt { get; set; }

    [JsonPropertyName("modified_at")]
    [GenerateOnAddOrUpdate]
    public DateTime ModifiedAt { get; set; }

    [JsonPropertyName("is_deleted")] public bool IsDeleted { get; set; }
}