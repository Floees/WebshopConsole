﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using webshopsimpler.Models;

#nullable disable

namespace webshopsimpler.Migrations
{
    [DbContext(typeof(WebshopDbContext))]
    [Migration("20250312042554_bruhx2")]
    partial class bruhx2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("webshopsimpler.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CountryName = "Sweden"
                        },
                        new
                        {
                            Id = 2,
                            CountryName = "England"
                        },
                        new
                        {
                            Id = 3,
                            CountryName = "AMERIKA"
                        });
                });

            modelBuilder.Entity("webshopsimpler.Models.PaymentMethod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AccountNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExpiryDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PaymentTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Provider")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PaymentTypeId");

                    b.ToTable("PaymentMethods");
                });

            modelBuilder.Entity("webshopsimpler.Models.PaymentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("PaymentTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PaymentTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PaymentTypeName = "Credit Card"
                        },
                        new
                        {
                            Id = 2,
                            PaymentTypeName = "PayPal"
                        });
                });

            modelBuilder.Entity("webshopsimpler.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dimensions")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("ProductCategoryId")
                        .HasColumnType("int");

                    b.Property<bool>("SelectProduct")
                        .HasColumnType("bit");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductCategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "The fastest fully cloth pad, Do you have the skill for this?",
                            Dimensions = "500x500x3",
                            Name = "Raiden",
                            Price = 699.99m,
                            ProductCategoryId = 1,
                            SelectProduct = true,
                            Size = "XXL",
                            Stock = 2
                        },
                        new
                        {
                            Id = 2,
                            Description = "The perfect stepping stone for controlpad users looking for someting faster, but not too fast.",
                            Dimensions = "500x500x3",
                            Name = "Hayate Otsu",
                            Price = 19.99m,
                            ProductCategoryId = 2,
                            SelectProduct = true,
                            Size = "XXL",
                            Stock = 18
                        },
                        new
                        {
                            Id = 3,
                            Description = "The pad for tacfps enthusiasts, made to enhance big flicks and minimize accidental microadjustments.",
                            Dimensions = "500x500x3",
                            Name = "Type-99",
                            Price = 14.99m,
                            ProductCategoryId = 3,
                            SelectProduct = true,
                            Size = "XXL",
                            Stock = 8
                        },
                        new
                        {
                            Id = 4,
                            Description = "Our first glass pad, it's nearly bulletproof! Very fast and smooth pad with finely tuned texture to proivde feedback.",
                            Dimensions = "500x500x3",
                            Name = "Sumuzu kuriminaru",
                            Price = 899.99m,
                            ProductCategoryId = 1,
                            SelectProduct = false,
                            Size = "XXL",
                            Stock = 2
                        },
                        new
                        {
                            Id = 5,
                            Description = "This pad is one step faster than raiden, with it's glass coating. You will get the benefits of cloth and the speed of glass!",
                            Dimensions = "500x500x3",
                            Name = "Shidenkai",
                            Price = 29.99m,
                            ProductCategoryId = 2,
                            SelectProduct = false,
                            Size = "XXL",
                            Stock = 0
                        });
                });

            modelBuilder.Entity("webshopsimpler.Models.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductCategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryName = "Speed",
                            Description = "Brrrrr"
                        },
                        new
                        {
                            Id = 2,
                            CategoryName = "Balanced",
                            Description = "As all things should be."
                        },
                        new
                        {
                            Id = 3,
                            CategoryName = "Control",
                            Description = "Boomers love theese"
                        });
                });

            modelBuilder.Entity("webshopsimpler.Models.ShippingMethod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("ShippingMethods");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Standard Shipping",
                            Price = 5.99m
                        },
                        new
                        {
                            Id = 2,
                            Name = "Express Shipping",
                            Price = 12.99m
                        });
                });

            modelBuilder.Entity("webshopsimpler.Models.ShoppingCart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsPaid")
                        .HasColumnType("bit");

                    b.Property<int?>("PaymentMethodId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int?>("ShippingMethodId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PaymentMethodId");

                    b.HasIndex("ProductId");

                    b.HasIndex("ShippingMethodId");

                    b.HasIndex("UserId");

                    b.ToTable("ShoppingCarts");
                });

            modelBuilder.Entity("webshopsimpler.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstLastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "123 John St",
                            City = "New John",
                            CountryId = 1,
                            Email = "john@example.com",
                            FirstLastName = "John Doe",
                            IsAdmin = false,
                            Password = "User",
                            PhoneNumber = "+15551234567",
                            PostalCode = "10001",
                            Username = "User"
                        },
                        new
                        {
                            Id = 2,
                            Address = "456 Admin St",
                            City = "Los Admines",
                            CountryId = 1,
                            Email = "admin@example.com",
                            FirstLastName = "John Admin",
                            IsAdmin = true,
                            Password = "Admin",
                            PhoneNumber = "+15557654321",
                            PostalCode = "20002",
                            Username = "Admin"
                        });
                });

            modelBuilder.Entity("webshopsimpler.Models.PaymentMethod", b =>
                {
                    b.HasOne("webshopsimpler.Models.PaymentType", "PaymentType")
                        .WithMany("PaymentMethods")
                        .HasForeignKey("PaymentTypeId");

                    b.Navigation("PaymentType");
                });

            modelBuilder.Entity("webshopsimpler.Models.Product", b =>
                {
                    b.HasOne("webshopsimpler.Models.ProductCategory", "ProductCategory")
                        .WithMany("Products")
                        .HasForeignKey("ProductCategoryId");

                    b.Navigation("ProductCategory");
                });

            modelBuilder.Entity("webshopsimpler.Models.ShoppingCart", b =>
                {
                    b.HasOne("webshopsimpler.Models.PaymentMethod", "PaymentMethod")
                        .WithMany("ShoppingCarts")
                        .HasForeignKey("PaymentMethodId");

                    b.HasOne("webshopsimpler.Models.Product", "Product")
                        .WithMany("ShoppingCarts")
                        .HasForeignKey("ProductId");

                    b.HasOne("webshopsimpler.Models.ShippingMethod", "ShippingMethod")
                        .WithMany("ShoppingCarts")
                        .HasForeignKey("ShippingMethodId");

                    b.HasOne("webshopsimpler.Models.User", "User")
                        .WithMany("ShoppingCarts")
                        .HasForeignKey("UserId");

                    b.Navigation("PaymentMethod");

                    b.Navigation("Product");

                    b.Navigation("ShippingMethod");

                    b.Navigation("User");
                });

            modelBuilder.Entity("webshopsimpler.Models.User", b =>
                {
                    b.HasOne("webshopsimpler.Models.Country", "Country")
                        .WithMany("Users")
                        .HasForeignKey("CountryId");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("webshopsimpler.Models.Country", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("webshopsimpler.Models.PaymentMethod", b =>
                {
                    b.Navigation("ShoppingCarts");
                });

            modelBuilder.Entity("webshopsimpler.Models.PaymentType", b =>
                {
                    b.Navigation("PaymentMethods");
                });

            modelBuilder.Entity("webshopsimpler.Models.Product", b =>
                {
                    b.Navigation("ShoppingCarts");
                });

            modelBuilder.Entity("webshopsimpler.Models.ProductCategory", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("webshopsimpler.Models.ShippingMethod", b =>
                {
                    b.Navigation("ShoppingCarts");
                });

            modelBuilder.Entity("webshopsimpler.Models.User", b =>
                {
                    b.Navigation("ShoppingCarts");
                });
#pragma warning restore 612, 618
        }
    }
}
