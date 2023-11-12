using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecapApi.Entities;
using RecapApi.Utils;

namespace RecapApi.Configurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        var employees = new List<Employee>
        {
            new()
            {
                Id = RandomIdGenerator.Generate("emp"),
                Name = "Tonoy Akanda",
                Age = 26,
                Position = "Founder & CTO",
                CreatedAt = DateTime.UtcNow,
                ModifiedAt = DateTime.UtcNow
            },
        };
        builder.HasData(employees);
    }
}