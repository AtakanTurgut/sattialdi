using sattiAldi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sattiAldi.Controllers
{
    public class PartialController : Controller
    {
        // GET: Partial
        public PartialViewResult NotificationMenu()
        {
            return PartialView(new Notification().OrderWaitingList());
        }
    }
}