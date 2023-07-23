using sattiAldi.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sattiAldi.Models
{
    public class State
    {
        DataContext db = new DataContext();

        public StateModelStyle GetModelState()
        {
            StateModelStyle models = new StateModelStyle();
            models.WaitingOrderCount = db.Orders.Where(o => o.OrderState == EnumOrderState.Bekleniyor).ToList().Count();
            models.PackedOrderCount = db.Orders.Where(o => o.OrderState == EnumOrderState.Paketlendi).ToList().Count();
            models.ShippedOrderCount = db.Orders.Where(o => o.OrderState == EnumOrderState.Kargolandı).ToList().Count();
            models.CompletedOrderCount = db.Orders.Where(o => o.OrderState == EnumOrderState.Tamamlandı).ToList().Count();

            models.ProductCount = db.Products.Count();
            models.OrderCount = db.Orders.Count();

            return models;
        }
    }

    public class StateModelStyle
    {
        public int ProductCount { get; set; }
        public int OrderCount { get; set; }
        public int WaitingOrderCount { get; set; }
        public int PackedOrderCount { get; set; }
        public int ShippedOrderCount { get; set; }
        public int CompletedOrderCount { get; set; }
    }
}