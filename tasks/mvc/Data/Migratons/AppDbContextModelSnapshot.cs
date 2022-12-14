// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using mvc.Data;

#nullable disable

namespace mvc.Data.Migratons
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.10");

            modelBuilder.Entity("mvc.Models.Number", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("Raqam")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Numbers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "million",
                            Raqam = 1000000
                        },
                        new
                        {
                            Id = 2,
                            Name = "ming",
                            Raqam = 1000
                        },
                        new
                        {
                            Id = 3,
                            Name = "yuz",
                            Raqam = 100
                        },
                        new
                        {
                            Id = 4,
                            Name = "to'qson",
                            Raqam = 90
                        },
                        new
                        {
                            Id = 5,
                            Name = "sakson",
                            Raqam = 80
                        },
                        new
                        {
                            Id = 6,
                            Name = "yetmish",
                            Raqam = 70
                        },
                        new
                        {
                            Id = 7,
                            Name = "oltmish",
                            Raqam = 60
                        },
                        new
                        {
                            Id = 8,
                            Name = "ellik",
                            Raqam = 50
                        },
                        new
                        {
                            Id = 9,
                            Name = "qirq",
                            Raqam = 40
                        },
                        new
                        {
                            Id = 10,
                            Name = "o'ttiz",
                            Raqam = 30
                        },
                        new
                        {
                            Id = 11,
                            Name = "yigirma",
                            Raqam = 20
                        },
                        new
                        {
                            Id = 12,
                            Name = "o'n",
                            Raqam = 10
                        },
                        new
                        {
                            Id = 13,
                            Name = "to'qqiz",
                            Raqam = 9
                        },
                        new
                        {
                            Id = 14,
                            Name = "sakkiz",
                            Raqam = 8
                        },
                        new
                        {
                            Id = 15,
                            Name = "yetti",
                            Raqam = 7
                        },
                        new
                        {
                            Id = 16,
                            Name = "olti",
                            Raqam = 6
                        },
                        new
                        {
                            Id = 17,
                            Name = "besh",
                            Raqam = 5
                        },
                        new
                        {
                            Id = 18,
                            Name = "to'rt",
                            Raqam = 4
                        },
                        new
                        {
                            Id = 19,
                            Name = "uch",
                            Raqam = 3
                        },
                        new
                        {
                            Id = 20,
                            Name = "ikki",
                            Raqam = 2
                        },
                        new
                        {
                            Id = 21,
                            Name = "bir",
                            Raqam = 1
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
