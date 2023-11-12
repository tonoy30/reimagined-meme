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
                ModifiedAt = DateTime.UtcNow,
                CompanyId = "cmp_TMtrWseo08Z2Mk"
            },
            new()
            {
                Id = RandomIdGenerator.Generate("emp"),
                Name = "Ali Ahmmed",
                Age = 26,
                Position = "Founder & CFO",
                CreatedAt = DateTime.UtcNow,
                ModifiedAt = DateTime.UtcNow,
                CompanyId = "cmp_TMtrWseo08Z2Mk"
            },
        };
        builder.HasData(employees);
    }
}