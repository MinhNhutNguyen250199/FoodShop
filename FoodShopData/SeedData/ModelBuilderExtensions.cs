using FoodShopData.Entities;

using FoodShopData.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShopData.SeedData
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppConfig>().HasData(
               new AppConfig() { Key = "HomeTitle", Value = "This is home page of FoodShop" },
               new AppConfig() { Key = "HomeKeyword", Value = "This is keyword of FoodShop" },
               new AppConfig() { Key = "HomeDescription", Value = "This is description of FoodShop" }
               );
            modelBuilder.Entity<Language>().HasData(
                new Language() { Id = "vi-VN", Name = "Tiếng Việt", IsDefault = true },
                new Language() { Id = "en-US", Name = "English", IsDefault = false });

            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    Id = 1,
                    IsShowOnHome = true,
                    ParentId = null,
                    SortOrder = 1,
                    Status = Status.Active,
                },
                 new Category()
                 {
                     Id = 2,
                     IsShowOnHome = true,
                     ParentId = null,
                     SortOrder = 2,
                     Status = Status.Active
                 });

            modelBuilder.Entity<CategoryTranslation>().HasData(
                  new CategoryTranslation() { Id = 1, CategoryId = 1, Name = "Trái cây", LanguageId = "vi-VN", SeoAlias = "Trai-cay", SeoDescription = "Trái cây", SeoTitle = "Trái cây" },
                  new CategoryTranslation() { Id = 2, CategoryId = 1, Name = "Fruit", LanguageId = "en-US", SeoAlias = "fruit", SeoDescription = "Fruit", SeoTitle = "Fruit" },
                  new CategoryTranslation() { Id = 3, CategoryId = 2, Name = "Rau củ", LanguageId = "vi-VN", SeoAlias = "rau-cu", SeoDescription = "rau-cu", SeoTitle = "rau-cu" },
                  new CategoryTranslation() { Id = 4, CategoryId = 2, Name = "Vegetable", LanguageId = "en-US", SeoAlias = "vegetable", SeoDescription = "vegetable", SeoTitle = "Vegetables" }
                    );

            modelBuilder.Entity<Product>().HasData(
           new Product()
           {
               Id = 1,
               DateCreated = DateTime.Now,
               OriginalPrice = 100000,
               Price = 200000,
               Stock = 0,
               ViewCount = 0,
           });
            modelBuilder.Entity<ProductTranslation>().HasData(
                 new ProductTranslation()
                 {
                     Id = 1,
                     ProductId = 1,
                     Name = "Chuoi",
                     LanguageId = "vi-VN",
                     SeoAlias = "trai-cay-chuoi",
                     SeoDescription = "Chuoi",
                     SeoTitle = "Chuoi",
                     Details = "Chuoi",
                     Description = "Chuoi"
                 },
                    new ProductTranslation()
                    {
                        Id = 2,
                        ProductId = 1,
                        Name = "Banana",
                        LanguageId = "en-US",
                        SeoAlias = "Banana-Fruit",
                        SeoDescription = "Banana-Fruit",
                        SeoTitle = "Banana-Fruit",
                        Details = "Banana-Fruit",
                        Description = "Banana-Fruit"
                    });
            modelBuilder.Entity<ProductInCategory>().HasData(
                new ProductInCategory() { ProductId = 1, CategoryId = 1 }
                );

           
            modelBuilder.Entity<Role>().HasData(
                new Role
            {
                Id = 1,
                Name = "admin",
                NormalizedName = "admin",
                Description = "Administrator role"
            });

            var hasher = new PasswordHasher<User>();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "nmna7911@gmail.com",
                NormalizedEmail = "nmna7911@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "minhnhut123"),
                SecurityStamp = string.Empty,
                FirstName = "Nhut",
                LastName = "Nguyen",
                DayOfBirth = new DateTime(1999, 01, 25)
            });

            modelBuilder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int>
            {
                RoleId = 1,
                UserId = 2
            });
            modelBuilder.Entity<Slide>().HasData(
              new Slide() { Id = 1, Name = "Second Thumbnail label", Description = "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", SortOrder = 1, Url = "#", Image = "/themes/images/carousel/1.png", Status = Status.Active },
              new Slide() { Id = 2, Name = "Second Thumbnail label", Description = "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", SortOrder = 2, Url = "#", Image = "/themes/images/carousel/2.png", Status = Status.Active },
              new Slide() { Id = 3, Name = "Second Thumbnail label", Description = "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", SortOrder = 3, Url = "#", Image = "/themes/images/carousel/3.png", Status = Status.Active },
              new Slide() { Id = 4, Name = "Second Thumbnail label", Description = "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", SortOrder = 4, Url = "#", Image = "/themes/images/carousel/4.png", Status = Status.Active },
              new Slide() { Id = 5, Name = "Second Thumbnail label", Description = "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", SortOrder = 5, Url = "#", Image = "/themes/images/carousel/5.png", Status = Status.Active },
              new Slide() { Id = 6, Name = "Second Thumbnail label", Description = "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", SortOrder = 6, Url = "#", Image = "/themes/images/carousel/6.png", Status = Status.Active }
              );
        }

    }
}
