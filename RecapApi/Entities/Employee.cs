using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using RecapApi.Attributes;

namespace RecapApi.Entities;

public sealed class Employee : BaseEntity
{
    [Key] [Identity("emp")] public required string Id { get; set; }

    [Required(ErrorMessage = "Employee name is a required field.")]
    [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Age is a required field.")]
    public int Age { get; set; }

    [Required(ErrorMessage = "Position is a required field.")]
    [MaxLength(20, ErrorMessage = "Maximum length for the Position is 20characters.")]
    public string? Position { get; set; }

    [ForeignKey(nameof(Company))] public string? CompanyId { get; set; }
    public Company? Company { get; set; }
}