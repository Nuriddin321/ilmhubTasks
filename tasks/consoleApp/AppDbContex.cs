
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Jadval>? Jadvals {get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data source=karajadval.db");
    }
}