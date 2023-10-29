using System.ComponentModel.DataAnnotations;

namespace RecapApi.Entities;

public class Todo
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public bool Completed { get; set; }
}