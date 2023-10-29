using Microsoft.EntityFrameworkCore;
using RecapApi.Configurations;
using RecapApi.Entities;

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
            modelBuilder.ApplyConfiguration(new TodoConfiguration());
        }
    }

    public DbSet<Todo>? Todos { get; set; }
}