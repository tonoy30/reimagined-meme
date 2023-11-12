namespace RecapApi.DTOs;

public class BaseDto
{
    public required string Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
    public bool IsDeleted { get; set; }
}