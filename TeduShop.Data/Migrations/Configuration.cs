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
            //CreateProductCategorySample(context);
            //CreateProductSample(context);
            CreateSlide(context);
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

        private void CreateProductSample(TeduShop.Data.TeduShopDbContext context)
        {
            if (context.Products.Count() == 0)
            {
                List<Product> lstProduct = new List<Product>()
                {
                    new Product()
                    {
                        Name="san pham 1",
                        Alias="san-pham-1",
                        Status=true
                    },
                    new Product()
                    {
                        Name="san pham 2",
                        Alias="san-pham-2",
                        Status=false
                    },
                    new Product()
                    {
                        Name="san pham 3",
                        Alias="san-pham-3",
                        Status=true
                    },
                    new Product()
                    {
                        Name="san pham 4",
                        Alias="san-pham-4",
                        Status=true
                    }
                };
                context.Products.AddRange(lstProduct);
                context.SaveChanges();
            }

        }
        private void CreateSlide(TeduShopDbContext dbContext)
        {
            if (dbContext.Slides.Count() == 0)
            {
                List<Slide> lstSlide = new List<Slide>()
                {
                    new Slide() {Name="Slide 1",DisplayOrder=1,Status=true,URL="#", Image="~/Assets/client/images/bag1.jpg", Description="this is slide 1 description"  },
                    new Slide() {Name="Slide 2",DisplayOrder=2,Status=true,URL="#", Image="~/Assets/client/images/bag.jpg", Description="this is slide 2 description"  },
                    new Slide() {Name="Slide 3",DisplayOrder=3,Status=true,URL="#", Image="~/Assets/client/images/bag1.jpg", Description="this is slide 3 description"  },
                };
                dbContext.Slides.AddRange(lstSlide);
                dbContext.SaveChanges();
            }
        }
    }
}
