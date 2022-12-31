using Microsoft.EntityFrameworkCore;
using paginationSample.Entities;

namespace paginationSample.Data;

public class AppDbContext : DbContext
{
    public DbSet<Company>? Companies {get; set;}
    // public DbSet<Employee>? Employees {get; set;}
    public AppDbContext(DbContextOptions options) : base(options) { }
}
