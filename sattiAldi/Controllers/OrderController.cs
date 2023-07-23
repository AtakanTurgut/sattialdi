using sattiAldi.Entity;
using sattiAldi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sattiAldi.Controllers
{
    public class OrderController : Controller
    {
        DataContext db = new DataContext();

        // GET: Order
        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            var orders = db.Orders.Select(o => new AdminOrderModel()
            {
                Id = o.Id,
                OrderNumber = o.OrderNumber,
                OrderDate = o.OrderDate,
                OrderState = o.OrderState,
                Total = o.Total,
                Count = o.Orderlines.Count,
            }).OrderByDescending(o => o.OrderDate).ToList();

            return View(orders);
        }

        public ActionResult Details(int id)
        {
            var entity = db.Orders.Where(o => o.Id == id).Select(o => new OrderDetailsModel()
            {
                OrderId = o.Id,
                OrderNumber = o.OrderNumber,
                Total = o.Total,
                UserName = o.UserName,
                OrderDate = o.OrderDate,
                OrderState = o.OrderState,

                AddressTitle = o.AddressTitle,
                Address = o.Address,
                City = o.City,
                District = o.District,
                Neighbourhood = o.Neighbourhood,
                PostCode = o.PostCode,

                Orderlines = o.Orderlines.Select(x => new OrderlineModel()
                {
                    ProductId = x.ProductId,
                    ProductName = x.Product.Name,
                    Price = x.Product.Price,
                    Quantity = x.Quantity,
                    Image = x.Product.Image,
                }).ToList(),
            }).FirstOrDefault();

            return View(entity);
        }

        public ActionResult UpdateOrderState(int orderId, EnumOrderState orderState)
        {
            var order = db.Orders.FirstOrDefault(i => i.Id == orderId);

            if (order != null)
            {
                order.OrderState = orderState;
                db.SaveChanges();

                TempData["mesaj"] = "Bilgiler Kaydedildi!";

                return RedirectToAction("Details", new { id = orderId });
            }

            return RedirectToAction("Index");
        }

        public ActionResult PendingOrders()
        {
            var orders = db.Orders.Where(o => o.OrderState == EnumOrderState.Bekleniyor).ToList();
            return View(orders);
        }

        public ActionResult PackedOrders()
        {
            var orders = db.Orders.Where(o => o.OrderState == EnumOrderState.Paketlendi).ToList();
            return View(orders);
        }

        public ActionResult ShippingOrders()
        {
            var orders = db.Orders.Where(o => o.OrderState == EnumOrderState.Kargolandı).ToList();
            return View(orders);
        }

        public ActionResult CompletedOrders()
        {
            var orders = db.Orders.Where(o => o.OrderState == EnumOrderState.Tamamlandı).ToList();
            return View(orders);
        }
    }
}