using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.MvcWebUI.Entity;
using Project.MvcWebUI.Models;

namespace Project.MvcWebUI.Controllers
{
    public class HomeController : Controller
    {

        DataContext _context = new DataContext();

        // GET: Home
        public ActionResult Index()
        {
            var products = _context.Products
                .Where(i => i.IsApproved && i.IsHome == true)
                .Select(i=>new ProductModel()
                {
                    Id = i.Id,
                    Name = i.Name.Length > 50 ? i.Name.Substring(0, 47) + "..." : i.Name,
                    Description = i.Description.Length>50?i.Description.Substring(0,47)+"...":i.Description,
                    Price = i.Price,
                    Stock = i.Stock,
                    Image = i.Image,
                    CategoryId = i.CategoryId
                }).ToList();

            return View(products);
        }

        public ActionResult Details(int id)
        {
            return View(_context.Products.Where(i=>i.Id == id).FirstOrDefault());
        }

        public ActionResult List(int? id)
        {
            var products = _context.Products
                .Where(i => i.IsApproved == true)
                .Select(i => new ProductModel()
                {
                    Id = i.Id,
                    Name = i.Name.Length > 50 ? i.Name.Substring(0, 47) + "..." : i.Name,
                    Description = i.Description.Length > 50 ? i.Description.Substring(0, 47) + "..." : i.Description,
                    Price = i.Price,
                    Stock = i.Stock,
                    Image = i.Image ?? "1.jpg",
                    CategoryId = i.CategoryId
                }).AsQueryable();

            if (id!=null)
            {
                products = products.Where(i => i.CategoryId == id);
            }

            return View(products);
        }

        public PartialViewResult GetCategories()
        {
            return PartialView(_context.Categories.ToList());
        }
    }
}