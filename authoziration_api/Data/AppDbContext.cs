using authoziration_api.Models;
using Microsoft.EntityFrameworkCore;

namespace authoziration_api.Data;

public class AppDbContext : DbContext
{
    public DbSet<User> Users {get; set;}
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}