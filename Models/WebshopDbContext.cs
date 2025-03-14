using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace webshopsimpler.Models
{
    internal class WebshopDbContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ShippingMethod> ShippingMethods { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<User> Users { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=Webshop;Trusted_connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seeding Data for PaymentType
            modelBuilder.Entity<PaymentType>().HasData(
                new PaymentType { Id = 1, PaymentTypeName = "Credit Card" },
                new PaymentType { Id = 2, PaymentTypeName = "PayPal" }
            );

            // Seeding Data for ProductCategory
            modelBuilder.Entity<ProductCategory>().HasData(
                new ProductCategory { Id = 1, CategoryName = "Speed", Description = "Brrrrr" },
                new ProductCategory { Id = 2, CategoryName = "Balanced", Description = "As all things should be." },
                new ProductCategory { Id = 3, CategoryName = "Control", Description = "Boomers love theese" }
            );

            // Seeding Data for Country
            modelBuilder.Entity<Country>().HasData(
                new Country { Id = 1, CountryName = "Sweden" },
                new Country { Id = 2, CountryName = "England" },
                new Country { Id = 3, CountryName = "AMERIKA" }
            );

            // Seeding Data for Users
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "User", Password = "User", Email = "john@example.com", FirstLastName = "John Doe", Address = "123 John St", PostalCode = "10001", City = "New John", CountryId = 1, PhoneNumber = "+15551234567", IsAdmin = false },
                new User { Id = 2, Username = "Admin", Password = "Admin", Email = "admin@example.com", FirstLastName = "John Admin", Address = "456 Admin St", PostalCode = "20002", City = "Los Admines", CountryId = 1, PhoneNumber = "+15557654321", IsAdmin = true }
            );

            // Seeding Data for ShippingMethod
            modelBuilder.Entity<ShippingMethod>().HasData(
                new ShippingMethod { Id = 1, Name = "Standard Shipping", Price = 5.99m },
                new ShippingMethod { Id = 2, Name = "Express Shipping", Price = 12.99m }
            );

            // Seeding Data for Product
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, ProductCategoryId = 1, Name = "Raiden", Description = "The fastest fully cloth pad, Do you have the skill for this?", Size = "XXL", Dimensions = "500x500x3", Stock = 2, Price = 699.99m, SelectProduct = true },
                new Product { Id = 2, ProductCategoryId = 2, Name = "Hayate Otsu", Description = "The perfect stepping stone for controlpad users looking for someting faster, but not too fast.", Size = "XXL", Dimensions = "500x500x3", Stock = 18, Price = 19.99m, SelectProduct = true },
                new Product { Id = 3, ProductCategoryId = 3, Name = "Type-99", Description = "The pad for tacfps enthusiasts, made to enhance big flicks and minimize accidental microadjustments.", Size = "XXL", Dimensions = "500x500x3", Stock = 8, Price = 14.99m, SelectProduct = true },
                new Product { Id = 4, ProductCategoryId = 1, Name = "Sumuzu kuriminaru", Description = "Our first glass pad, it's nearly bulletproof! Very fast and smooth pad with finely tuned texture to proivde feedback.", Size = "XXL", Dimensions = "500x500x3", Stock = 2, Price = 899.99m, SelectProduct = false },
                new Product { Id = 5, ProductCategoryId = 2, Name = "Shidenkai", Description = "This pad is one step faster than raiden, with it's glass coating. You will get the benefits of cloth and the speed of glass!", Size = "XXL", Dimensions = "500x500x3", Stock = 0, Price = 29.99m, SelectProduct = false }
            );
        }
    }
}

