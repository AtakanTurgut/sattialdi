using sattiAldi.Entity;
using sattiAldi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sattiAldi.Controllers
{
    public class CartController : Controller
    {
        DataContext db = new DataContext();

        // GET: Cart
        public ActionResult Index()
        {
            return View(GetCart());
        }

        public ActionResult AddToCart(int Id)
        {
            var product = db.Products.FirstOrDefault(x => x.Id == Id);

            if (product != null)
            {
                GetCart().AddProduct(product, 1);
            }

            return RedirectToAction("Index");
        }

        public ActionResult RemoveFromCart(int Id)
        {
            var product = db.Products.FirstOrDefault(x => x.Id == Id);

            if (product != null)
            {
                GetCart().DeleteProduct(product);
            }

            return RedirectToAction("Index");
        }

        public Cart GetCart()
        {
            var cart = (Cart)Session["Cart"];

            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }

            return cart;
        }

        public PartialViewResult Summary()
        {
            return PartialView(GetCart());
        }

        public ActionResult Checkout()
        {
            return View(new ShippingDetails());
        }

        [HttpPost]
        public ActionResult Checkout(ShippingDetails entity)
        {
            var cart = GetCart();

            if (cart.Cartlines.Count == 0)
            {
                ModelState.AddModelError("NoProductInCartError", "Sepetinizde Ürün Bulunmamaktadır!");
            }
            if (ModelState.IsValid)
            {
                SaveOrder(cart, entity);

                cart.Clear();

                return View("Completed");
            }
            else
            {
                return View(entity);
            }
        }

        private void SaveOrder(Cart cart, ShippingDetails entity)
        {
            var order = new Order();
            order.OrderNumber = "A" + (new Random().Next(1000, 9999));
            order.Total = cart.Total();
            order.OrderDate = DateTime.Now;
            order.OrderState = EnumOrderState.Bekleniyor;
            order.UserName = User.Identity.Name;
            order.AddressTitle = entity.AddressTitle;
            order.Address = entity.Address;
            order.City = entity.City;
            order.District = entity.District;
            order.Neighbourhood = entity.Neighbourhood;
            order.PostCode = entity.PostCode;

            order.Orderlines = new List<Orderline>();

            foreach (var cartline in cart.Cartlines)
            {
                var orderline = new Orderline();
                orderline.Quantity = cartline.Quantity;
                orderline.Price = (cartline.Quantity * cartline.Product.Price);
                orderline.ProductId = cartline.Product.Id;

                order.Orderlines.Add(orderline);
            }
            db.Orders.Add(order);
            db.SaveChanges();
        }
    }
}