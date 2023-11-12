namespace RecapApi.DTOs;

public sealed class CompanyDto : BaseDto
{
    public required string Name { get; set; }
    public string? FullAddress { get; set; }
    public IEnumerable<EmployeeDto>? Employees { get; set; }
}