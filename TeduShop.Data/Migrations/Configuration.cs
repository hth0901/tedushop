namespace TeduShop.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Model.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TeduShop.Data.TeduShopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TeduShop.Data.TeduShopDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            //var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new TeduShopDbContext()));
            //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new TeduShopDbContext()));

            //var user = new ApplicationUser()
            //{
            //    UserName = "kdc",
            //    Email = "kdc@gmail.com",
            //    EmailConfirmed = true,
            //    BirthDay = DateTime.Now,
            //    FullName = "hihihaha kdc"
            //};

            //manager.Create(user, "246357$");
            //if (!roleManager.Roles.Any())
            //{
            //    roleManager.Create(new IdentityRole { Name = "Admin" });
            //    roleManager.Create(new IdentityRole { Name = "User" });
            //}

            //var adminUser = manager.FindByEmail("kdc@gmail.com");

            //manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });
            CreateProductCategorySample(context);
        }

        private void CreateProductCategorySample(TeduShop.Data.TeduShopDbContext context)
        {
            if (context.ProductCategories.Count() == 0)
            {
                List<ProductCategory> lstProductCategory = new List<ProductCategory>()
                {
                    new ProductCategory()
                    {
                        Name="Dien lanh",
                        Alias="dien-lanh",
                        Status=true
                    },
                    new ProductCategory()
                    {
                        Name="vien thong",
                        Alias="vien-thong",
                        Status=true
                    },
                    new ProductCategory()
                    {
                        Name="do gia dung",
                        Alias="gia-dung",
                        Status=true
                    },
                    new ProductCategory()
                    {
                        Name="my pham",
                        Alias="my-pham",
                        Status=true
                    }
                };
                context.ProductCategories.AddRange(lstProductCategory);
                context.SaveChanges();
            }
            
        }
    }
}
