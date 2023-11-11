using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using RecapApi.Attributes;

namespace RecapApi.Entities;

public sealed class Employee
{
    [Key]
    [Identity("emp")]
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("name")]
    [Required(ErrorMessage = "Employee name is a required field.")]
    [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
    public string? Name { get; set; }

    [JsonPropertyName("age")]
    [Required(ErrorMessage = "Age is a required field.")]
    public int Age { get; set; }

    [JsonPropertyName("position")]
    [Required(ErrorMessage = "Position is a required field.")]
    [MaxLength(20, ErrorMessage = "Maximum length for the Position is 20characters.")]
    public string? Position { get; set; }
}