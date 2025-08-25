using ASP_NET_Web_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_NET_Web_app.Data
{
    public static class SeedData
    {
        public static void EnsureSeed(AppDbContext db)
        {
            if (!db.Categories.Any())
            {
                var c1 = db.Categories.Add(new Category { CategoryName = "Mobiles" });
                var c2 = db.Categories.Add(new Category { CategoryName = "Laptops" });
                db.SaveChanges();

                db.Products.Add(new Product { ProductName = "iPhone 14", CategoryId = c1.CategoryId });
                db.Products.Add(new Product { ProductName = "Galaxy S23", CategoryId = c1.CategoryId });
                db.Products.Add(new Product { ProductName = "ThinkPad X1", CategoryId = c2.CategoryId });
                db.SaveChanges();
            }
        }
    }
}