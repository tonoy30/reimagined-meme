using Microsoft.EntityFrameworkCore;
using RecapApi.Entities;

namespace RecapApi.DbContexts;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Todo>? Todos { get; set; }
}