using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.MvcWebUI.Entity;
using Project.MvcWebUI.Models;

namespace Project.MvcWebUI.Controllers
{
    public class CartController : Controller
    {

        private DataContext db = new DataContext();

        // GET: Cart
        public ActionResult Index()
        {
            return View(GetCart());
        }

        public Cart GetCart()
        {
            //session: her kullanıcıya özel oluşturulan bir depo
            var cart = (Cart)Session["Cart"];

            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }

            return cart;

        }

        public ActionResult AddToCart(int id)
        {
            var product = db.Products.FirstOrDefault(i => i.Id == id);

            if (product != null)
            {
                GetCart().AddProduct(product, 1);
            }

            return RedirectToAction("Index");
        }

        public ActionResult RemoveFromCart(int id)
        {
            var product = db.Products.FirstOrDefault(i => i.Id == id);

            if (product != null)
            {
                GetCart().DeleteProduct(product);
            }

            return RedirectToAction("Index");
        }

        public PartialViewResult Summary()
        {
            return PartialView(GetCart());
        }

        public ActionResult Checkout()
        {
            return View(new ShippingModel());
        }

        [HttpPost]
        public ActionResult Checkout(ShippingModel entity)
        {
            var cart = GetCart();

            if (cart.GetCartLines.Count() == 0)
            {
                ModelState.AddModelError("NoProductError", "There are no products in your cart.");
            }

            if (ModelState.IsValid)
            {
                //siparişi veritabanına kayıt et
                //cart ı sıfırla

                SaveOrder(cart, entity);
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(entity);
            }



            return View();
        }

        private void SaveOrder(Cart cart, ShippingModel entity)
        {
            var order = new Order();

            order.OrderNumber = "A" + (new Random()).Next(11111,99999).ToString();
            order.Total = cart.TotalPrice();
            order.OrderDate = DateTime.Now;
            order.OrderState = EnumOrderState.Waiting;
            order.Username = User.Identity.Name;

            order.AddressTitle = entity.AddressTitle;
            order.Address = entity.Address;
            order.City = entity.City;
            order.District = entity.District;
            order.Neighborhood = entity.Neighborhood;
            order.PostCode = entity.PostCode;

            order.OrderLines = new List<OrderLine>();

            foreach (var pr in cart.GetCartLines)
            {
                var orderline = new OrderLine();

                orderline.Quantity = pr.Quantity;
                orderline.Price = pr.Quantity * pr.Product.Price;
                orderline.ProductId = pr.Product.Id;

                order.OrderLines.Add(orderline);
            }

            db.Orders.Add(order);
            db.SaveChanges();
        }
    }
}