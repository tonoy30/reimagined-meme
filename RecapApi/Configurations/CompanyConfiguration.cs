using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecapApi.Entities;
using RecapApi.Utils;

namespace RecapApi.Configurations;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        var companies = new List<Company>
        {
            new()
            {
                Id = "cmp_TMtrWseo08Z2Mk",
                Name = "ContentCraft",
                Address = "1009, Oscar Neer, East Shwerepara, Mirpur, Dhaka-1216",
                Country = "Bangladesh",
                CreatedAt = DateTime.UtcNow,
                ModifiedAt = DateTime.UtcNow,
            }
        };

        builder.HasData(companies);
    }
}