using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace RecapApi.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        var roles = new List<IdentityRole>
        {
            new()
            {
                Name = "Manager",
                NormalizedName = "MANAGER",
            },
            new()
            {
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR",
            }
        };
        builder.HasData(roles);
    }
}