
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<UsersContact>? UsersContacts {get; set;}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseNpgsql("host=localhost; port=5432; database=testdb; username=postgres; password=3321;");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<UsersContact>().ToView("users_contact");
    }

}

public class UsersContact
{
    [Column("id")]
    public int Id { get; set; }
    [Column("name")]
    public string? Name { get; set; }
    [Column("usercontact")]
    public string? Contact { get; set; }
}
