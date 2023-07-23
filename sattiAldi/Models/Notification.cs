using sattiAldi.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sattiAldi.Models
{
    public class Notification
    {
        DataContext db = new DataContext();

        public List<Order> OrderWaitingList() 
        { 
            return db.Orders.Where(o => o.OrderState == EnumOrderState.Bekleniyor).ToList();
        }
    }
}