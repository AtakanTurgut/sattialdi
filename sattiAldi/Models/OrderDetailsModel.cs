using sattiAldi.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sattiAldi.Models
{
    public class OrderDetailsModel
    {
        public int OrderId { get; set; }
        public string OrderNumber { get; set; }
        public double Total { get; set; }
        public DateTime OrderDate { get; set; }
        public EnumOrderState OrderState { get; set; }
        public string UserName { get; set; }

        public string AddressTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Neighbourhood { get; set; }
        public string PostCode { get; set; }

        public virtual List<OrderlineModel> Orderlines { get; set; }
    }

    public class OrderlineModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
    }
}