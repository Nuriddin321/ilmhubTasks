using Microsoft.EntityFrameworkCore;
using mvc.Models;

namespace mvc.Data;
public class AppDbContext : DbContext
{
    public DbSet<Number>? Numbers { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Number>().HasData(new List<Number>
        {
            new Number()
            {
                Id = 1,
                Raqam = 1000000,
                Name = "million"
            },
            new Number()
            {
                Id = 2,
                Raqam = 1000,
                Name = "ming"
            },
            new Number()
            {
                Id = 3,
                Raqam = 100,
                Name = "yuz"
            },
            new Number()
            {
                Id = 4,
                Raqam = 90,
                Name = "to'qson"
            },
            new Number()
            {
                Id = 5,
                Raqam = 80,
                Name = "sakson"
            },
            new Number()
            {
                Id = 6,
                Raqam = 70,
                Name = "yetmish"
            },
            new Number()
            {
                Id = 7,
                Raqam = 60,
                Name = "oltmish"
            },
            new Number()
            {
                Id = 8,
                Raqam = 50,
                Name = "ellik"
            },
            new Number()
            {
                Id = 9,
                Raqam = 40,
                Name = "qirq"
            },
            new Number()
            {
                Id = 10,
                Raqam = 30,
                Name = "o'ttiz"
            },
            new Number()
            {
                Id = 11,
                Raqam = 20,
                Name = "yigirma"
            },
            new Number()
            {
                Id = 12,
                Raqam = 10,
                Name = "o'n"
            },
            new Number()
            {
                Id = 13,
                Raqam = 9,
                Name = "to'qqiz"
            },
            new Number()
            {
                Id = 14,
                Raqam = 8,
                Name = "sakkiz"
            },
            new Number()
            {
                Id = 15,
                Raqam = 7,
                Name = "yetti"
            },
            new Number()
            {
                Id = 16,
                Raqam = 6,
                Name = "olti"
            },
            new Number()
            {
                Id = 17,
                Raqam = 5,
                Name = "besh"
            },
            new Number()
            {
                Id = 18,
                Raqam = 4,
                Name = "to'rt"
            },
            new Number()
            {
                Id = 19,
                Raqam = 3,
                Name = "uch"
            },
            new Number()
            {
                Id = 20,
                Raqam = 2,
                Name = "ikki"
            },
            new Number()
            {
                Id = 21,
                Raqam = 1,
                Name = "bir"
            },
        });
    }
}