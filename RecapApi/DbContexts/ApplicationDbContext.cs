using System.Reflection;
using Microsoft.EntityFrameworkCore;
using RecapApi.Attributes;
using RecapApi.Configurations;
using RecapApi.Entities;
using RecapApi.Utils;
using RecapApi.ValueGenerators;

namespace RecapApi.DbContexts;

public class ApplicationDbContext : DbContext
{
    private readonly IWebHostEnvironment _environment;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IWebHostEnvironment environment) :
        base(options)
    {
        _environment = environment;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        if (_environment.IsDevelopment())
        {
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        }

        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            foreach (var property in entityType.GetProperties())
            {
                var identityAttribute = property.PropertyInfo?.GetCustomAttribute<IdentityAttribute>();
                if (identityAttribute is null) continue;
                var valueGenerator = new IdentityValueGenerator(identityAttribute.Prefix, identityAttribute.Size);
                modelBuilder.Entity(entityType.ClrType).Property(property.Name)
                    .HasValueGenerator((_, _) => valueGenerator);
            }
        }
    }

    public DbSet<Employee>? Employees { get; set; }
}