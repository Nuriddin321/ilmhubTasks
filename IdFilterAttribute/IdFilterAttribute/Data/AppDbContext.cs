using Microsoft.EntityFrameworkCore;

namespace IdFilterAttribute.Data;

public class AppDbContext : DbContext
{
    public DbSet<Company>? Companies {get; set;}
    public AppDbContext(DbContextOptions options) : base(options) {}
}

public class Company
{
    public int Id { get; set; }
    public string? Name { get; set; }

}