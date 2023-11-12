namespace RecapApi.DTOs;

public sealed class EmployeeDto : BaseDto
{
    public string? Name { get; set; }
    public int Age { get; set; }
    public string? Position { get; set; }
    public string? CompanyId { get; set; }
    public string? CompanyName { get; set; }
}