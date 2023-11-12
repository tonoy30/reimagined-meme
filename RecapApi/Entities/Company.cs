using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using RecapApi.Attributes;

namespace RecapApi.Entities;

public class Company : BaseEntity
{
    [Key]
    [Identity("com")]
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("name")]
    [Required(ErrorMessage = "Company name is a required field.")]
    [MaxLength(256, ErrorMessage = "Maximum length for the Name is 256 characters.")]
    public required string Name { get; set; }

    public string? Address { get; set; }
}