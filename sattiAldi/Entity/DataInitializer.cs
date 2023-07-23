using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sattiAldi.Entity
{
    public class DataInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var categories = new List<Category>() 
            {
                new Category() {Name="KAMERA", Description="Kamera Ürünleri"},
                new Category() {Name="BİLGİSAYAR", Description="Bilgisayar Ürünleri"},
            };

            foreach (var category in categories) 
            { 
                context.Categories.Add(category);
            }

            context.SaveChanges();

            var products = new List<Product>() 
            {
                new Product() {CategoryId=1, Name="Canon", Description="Sıfır Kamera", Price=5000, Stock=20, IsHome=true, Image="canon.jpg", IsApproved=true, IsFeatured=false},
                new Product() {CategoryId=2, Name="Asus", Description="Asus Gaming", Price=35000, Stock=7, IsHome=false, Image="asus.jpg", IsApproved=true, IsFeatured=true},
                new Product() {CategoryId=2, Name="Casper", Description="Nirvana", Price=24000, Stock=12, IsHome=true, Image="casper.jpg", IsApproved=true, IsFeatured=true},
            };

            foreach (var product in products)
            {
                context.Products.Add(product);
            }

            context.SaveChanges();

            base.Seed(context);
        }
    }
}