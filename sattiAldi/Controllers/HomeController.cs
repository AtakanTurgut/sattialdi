using sattiAldi.Entity;
using sattiAldi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sattiAldi.Controllers
{
    public class HomeController : Controller
    {
        DataContext db = new DataContext();

        // GET: Home
        public ActionResult Index()
        {
            var product = db.Products.Where(i => i.IsHome && i.IsApproved).Select(i => new ProductModel()
            {
                Id = i.Id,
                Name = i.Name,
                Description = i.Description.Length > 25 ? i.Description.Substring(0,20) + "..." : i.Description,
                Price = i.Price,
                Stock = i.Stock,
                Image = i.Image,
                CategoryId = i.CategoryId,
            }).ToList();

            return View(product);
        }

        public ActionResult ProductList(int id)
        {
            return View(db.Products.Where(p => p.CategoryId == id).ToList());
        }

        public PartialViewResult FeaturedProductList()
        {
            return PartialView(db.Products.Where(p => p.IsFeatured && p.IsApproved).Take(5).ToList());
        }

        public ActionResult Search(string query)
        {
            var product  = db.Products.Where(p => p.IsApproved == true);
            if (!string.IsNullOrEmpty(query))
            {
                product = product.Where(p => p.Name.Contains(query) || p.Description.Contains(query));
            }
            return View(product.ToList());
        }

        public PartialViewResult _Slider()
        {
            return PartialView(db.Products.Where(p => p.Slider && p.IsApproved).Take(5).ToList());
        }

        public ActionResult ProductDetails(int id)
        {
            return View(db.Products.Where(i => i.Id == id).FirstOrDefault());
        }

        public ActionResult Product()
        {
            var product = db.Products.Where(i => i.IsApproved).Select(i => new ProductModel()
            {
                Id = i.Id,
                Name = i.Name,
                Description = i.Description.Length > 25 ? i.Description.Substring(0, 20) + "..." : i.Description,
                Price = i.Price,
                Stock = i.Stock,
                Image = i.Image,
                CategoryId = i.CategoryId,
            }).ToList();

            return View(product);
        }
    }
}