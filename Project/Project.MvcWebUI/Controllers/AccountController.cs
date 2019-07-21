using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Project.MvcWebUI.Entity;
using Project.MvcWebUI.Identity;
using Project.MvcWebUI.Models;

namespace Project.MvcWebUI.Controllers
{
    public class AccountController : Controller
    {
        private DataContext db = new DataContext();

        private UserManager<ApplicationUser> userManager;
        private RoleManager<ApplicationRole> roleManager;

        public AccountController()
        {
            var userStore = new UserStore<ApplicationUser>(new IdentityDataContext());
            userManager = new UserManager<ApplicationUser>(userStore);

            var roleStore = new RoleStore<ApplicationRole>(new IdentityDataContext());
            roleManager = new RoleManager<ApplicationRole>(roleStore);
        }

        [Authorize]
        public ActionResult Index()
        {
            var username = User.Identity.Name;
            var orders = db.Orders.Where(i => i.Username == username)
                .Select(i => new UserOrderModel()
                {
                    Id = i.Id,
                    OrderNumber = i.OrderNumber,
                    Total = i.Total,
                    OrderDate = i.OrderDate,
                    OrderState = i.OrderState
                }).OrderByDescending(i => i.OrderDate).ToList();

            return View(orders);
        }

        [Authorize]
        public ActionResult Details(int id)
        {
            var entity = db.Orders.Where(i => i.Id == id)
                .Select(i => new OrderDetailsModel()
            {
                OrderId = i.Id,
                OrderNumber = i.OrderNumber,
                Total = i.Total,
                OrderDate = i.OrderDate,
                OrderState = i.OrderState,
                AddressTitle = i.AddressTitle,
                Address = i.Address,
                City = i.City,
                District = i.District,
                Neighborhood = i.Neighborhood,
                PostCode = i.PostCode,
                OrderLines = i.OrderLines.Select(a=> new OrderLineModel()
                {
                    ProductId = a.ProductId,
                    ProductName = a.Product.Name.Length>50?a.Product.Name.Substring(0,47)+"...":a.Product.Name,
                    Image = a.Product.Image,
                    Quantity = a.Quantity,
                    Price = a.Price

                }).ToList()
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
        public ActionResult Register(RegisterModel model)
        {

            if (ModelState.IsValid)
            {
                //kayıt işlemleri
                var user = new ApplicationUser();

                user.Name = model.Name;
                user.Surname = model.Surname;
                user.Email = model.Email;
                user.UserName = model.Username;

                IdentityResult result = userManager.Create(user, model.Password);

                if (result.Succeeded)
                {
                    if (roleManager.RoleExists("User"))
                    {
                        userManager.AddToRole(user.Id, "User");
                    }

                    return RedirectToAction("Login", "Account");

                }
                else
                {
                    ModelState.AddModelError("RegisterUserError", "Error creating user. Please try again later");
                }

            }

            return View(model);
        }

        // GET: Acoount
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string ReturnUrl)
        {

            if (ModelState.IsValid)
            {
                //login işlemleri
                var user = userManager.Find(model.Username, model.Password);

                if (user != null)
                {
                    //varolan kullanıcıyı sisteme dahil et
                    //ApplicationCookie oluşturup sisteme bırak

                    var authManager = HttpContext.GetOwinContext().Authentication;
                    var identityclaims = userManager.CreateIdentity(user, "ApplicationCookie");
                    var authProperties = new AuthenticationProperties();
                    authProperties.IsPersistent = model.RememberMe;
                    authManager.SignIn(authProperties, identityclaims);

                    if (!String.IsNullOrEmpty(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("LoginUserError", "Wrong username or password.");
                }


            }

            return View(model);
        }

        public ActionResult Logout()
        {

            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();

            return RedirectToAction("Index", "Home");
        }



    }
}