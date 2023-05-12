﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StoreBook.Data;

#nullable disable

namespace StoreBook.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230511074546_addProductsToDataBase")]
    partial class addProductsToDataBase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StoreBook.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DisplayOrder = 1,
                            Name = "Kefir"
                        },
                        new
                        {
                            Id = 2,
                            DisplayOrder = 2,
                            Name = "WiFi"
                        },
                        new
                        {
                            Id = 3,
                            DisplayOrder = 3,
                            Name = "Action"
                        });
                });

            modelBuilder.Entity("StoreBook.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ListPrice")
                        .HasColumnType("float");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<double>("Price100")
                        .HasColumnType("float");

                    b.Property<double>("Price50")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Chopek Andriy",
                            Description = "Fantasy book for children and adult",
                            ISBN = "WWW999011YY",
                            ListPrice = 34.600000000000001,
                            Price = 3.0,
                            Price100 = 180.0,
                            Price50 = 110.59999999999999,
                            Title = "Lords of the rings"
                        },
                        new
                        {
                            Id = 2,
                            Author = "Chopek Andriy",
                            Description = "Fantasy book for children and adult",
                            ISBN = "WWW999011YY",
                            ListPrice = 34.600000000000001,
                            Price = 3.0,
                            Price100 = 180.0,
                            Price50 = 110.59999999999999,
                            Title = "Lords of the rings"
                        },
                        new
                        {
                            Id = 3,
                            Author = "Chopek Andriy",
                            Description = "Fantasy book for children and adult",
                            ISBN = "WWW999011YY",
                            ListPrice = 34.600000000000001,
                            Price = 3.0,
                            Price100 = 180.0,
                            Price50 = 110.59999999999999,
                            Title = "Lords of the rings"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
