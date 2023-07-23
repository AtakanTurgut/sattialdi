using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using sattiAldi.Entity;
using sattiAldi.Identity;
using sattiAldi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sattiAldi.Controllers
{
    public class AccountController : Controller
    {
        DataContext db = new DataContext();

        private UserManager<ApplicationUser> UserManager;
        private RoleManager<ApplicationRole> RoleManager;

        public AccountController()
        {
            var userStore = new UserStore<ApplicationUser>(new IdentityDataContext());
            UserManager = new UserManager<ApplicationUser>(userStore);

            var roleStore = new RoleStore<ApplicationRole>(new IdentityDataContext());
            RoleManager = new RoleManager<ApplicationRole>(roleStore);
        }

        public ActionResult Index()
        {
            var userName = User.Identity.Name;
            var orders = db.Orders.Where(o => o.UserName == userName).Select(o => new UserOrderModel
            {
                Id = o.Id,
                OrderNumber = o.OrderNumber,
                OrderDate = o.OrderDate,
                OrderState = o.OrderState,
                Total = o.Total,
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

        // GET: Account
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser();
                user.Name = model.Name;
                user.Surname = model.Surname;
                user.Email = model.Email;
                user.UserName = model.Username;

                var result = UserManager.Create(user, model.Password);

                if (result.Succeeded)
                {
                    if (RoleManager.RoleExists("user"))
                    {
                        UserManager.AddToRole(user.Id, "user");
                    }

                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ModelState.AddModelError("RegisterUserError", "Kullanıcı Oluşturma Hatası!");
                }
            }

            return View(model);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login model, string ReturnURL)
        {
            if (ModelState.IsValid)
            {
                var user = UserManager.Find(model.Username, model.Password);
                
                if (user != null)
                {
                    var authManager = HttpContext.GetOwinContext().Authentication;
                    var identityClaims = UserManager.CreateIdentity(user, "ApplicationCookie");

                    var authProperties = new AuthenticationProperties();
                    authProperties.IsPersistent = model.RememberMe;
                    authManager.SignIn(authProperties, identityClaims);

                    if (!String.IsNullOrEmpty(ReturnURL))
                    {
                        return Redirect(ReturnURL);
                    }

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("LoginUserError", "Böyle Bir Kullanıcı Sistemde Bulunmuyor!");
                }
            }

            return View(model);
        }

        public ActionResult LogOut()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();

            return RedirectToAction("Index", "Home");
        }

        
    }
}