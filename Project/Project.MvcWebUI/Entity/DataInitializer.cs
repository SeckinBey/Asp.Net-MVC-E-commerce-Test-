using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Project.MvcWebUI.Entity
{
    public class DataInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {

            var categories = new List<Category>()
            {
                new Category(){Name = "Camera", Description = "Camera products"},
                new Category(){Name = "Computer", Description = "Computer products"},
                new Category(){Name = "Electronic", Description = "Electronic products"},
                new Category(){Name = "Phone", Description = "Phone products"},
                new Category(){Name = "Tablet", Description = "Tablet products"}
            };  //Test data

            foreach (var item in categories)
            {
                context.Categories.Add(item);
            }

            context.SaveChanges();

            var products = new List<Product>()
            {
                new Product() {Name = "Canon 400D 18-55 MM III Camera", Description = "Canon 400D 18-55 MM III description", Price = 1999.00 , Stock = 425, IsApproved =true, CategoryId =1, IsHome = true, Image = "1.jpg"},
                new Product() {Name = "Sony A6300 16-50 Mm Kit Camera", Description = "Sony A6300 16-50 Mm Kit description", Price = 6499.00, Stock = 263, IsApproved = false, CategoryId =1, IsHome = true, Image = "2.jpg" },
                new Product() {Name = "Fujifilm Instax Mini 9 Camera", Description = "Fujifilm Instax Mini 9 Camera description", Price = 369.00, Stock = 780, IsApproved = true, CategoryId =1, IsHome = true, Image = "3.jpg" },
                new Product() {Name = "Sony Fdr-Ax33 4K Video Camera", Description = "Sony Fdr-Ax33 4K Video Camera description", Price = 4199.00, Stock = 562, IsApproved = true, CategoryId =1, IsHome = true, Image = "4.jpg" },
                new Product() {Name = "Sony Mc2500 Professional Hd Video Camera", Description = "Sony Mc2500 Professional Hd Video Camera description", Price = 7189.00, Stock = 86, IsApproved = true, CategoryId =1, IsHome = true, Image = "5.jpg" },
                new Product() {Name = "Nikon D5300 18-55MM F3.5-5.6G VR II SLR Digital Camera", Description = "Nikon D5300 18-55MM F3.5-5.6G VR II SLR Digital Camera", Price = 3895.00, Stock = 143, IsApproved = true, CategoryId =1, IsHome = true, Image = "6.jpg" },

                new Product() {Name = "Hometech Alfa 11A Laptop-Notebook", Description = "Hometech Alfa 11A Laptop-Notebook description", Price = 699.00, Stock = 413, IsApproved = true, CategoryId =2, IsHome = true , Image = "1.jpg"},
                new Product() {Name = "Apple MacBook Air MQD32TU/A Intel core i5 8GB Ram 128 SSD 13.3 Inch Laptop-Notebook", Description = "Apple MacBook Air MQD32TU/A Intel core i5 8GB Ram 128 SSD 13.3 Inch Laptop-Notebook description", Price = 5199.99, Stock = 362, IsApproved = true, CategoryId =2, IsHome = true, Image = "2.jpg" },
                new Product() {Name = "Acer EX2519 N3060 Intel Core i5 4GB Ram 500 GB 15.6 Inch Laptop-Notebook", Description = "Acer EX2519 N3060 Intel Core i5 4GB Ram 500 GB 15.6 Inch Laptop-Notebook description", Price = 1229.99, Stock = 260, IsApproved = true, CategoryId =2, IsHome = true, Image = "3.jpg" },
                new Product() {Name = "Lenovo V110 80TG011JTX Intel Celeron 4 GB Ram 512 GB 15.6 Inch Laptop-Notebook", Description = "Lenovo V110 80TG011JTX Intel Celeron 4 GB Ram 512 GB 15.6 Inch Laptop-Notebook description", Price = 2569.99, Stock = 452, IsApproved = true, CategoryId =2, IsHome = true, Image = "4.jpg" },
                new Product() {Name = "HP 15-RA013NT 3QT54EA Intel Celeron N3060 4 GB Ram 500 GB 15.6 Inch Windows Laptop-Notebook", Description = "HP 15-RA013NT 3QT54EA Intel Celeron N3060 4 GB Ram 500 GB 15.6 Inch Windows Laptop-Notebook description", Price = 1479.00, Stock = 712, IsApproved = true, CategoryId =2, IsHome = true, Image = "5.jpg" },
                new Product() {Name = "Asus CicoBook X540BA-GO179 AMD A6 9225 4 GB Ram 1TB 15.6 Inch Laptop", Description = "Asus CicoBook X540BA-GO179 AMD A6 9225 4 GB Ram 1TB 15.6 Inch Laptop description", Price = 3249.99, Stock = 952, IsApproved = true, CategoryId =2, IsHome = true, Image = "6.jpg" },

                new Product() {Name = "Wireless USB Bluetooth Adapter V4.0 Bluetooth Dongle Music Sound Receiver", Description = "Wireless USB Bluetooth Adapter V4.0 Bluetooth Dongle Music Sound Receiver description", Price = 8.95, Stock = 250, IsApproved = true, CategoryId =3, IsHome = true, Image = "1.jpg" },
                new Product() {Name = "BOAMINGO brand men sports watches dual display analog digital LED", Description = "BOAMINGO brand men sports watches dual display analog digital LED description", Price = 20.81, Stock = 340, IsApproved = true, CategoryId =3, IsHome = true , Image = "2.jpg"},
                new Product() {Name = "3pcs/lots ATCO Professional Universal DLP LINK Shutter Active 3D Glasses", Description = "3pcs/lots ATCO Professional Universal DLP LINK Shutter Active 3D Glasses description", Price = 48.74, Stock = 650, IsApproved = true, CategoryId =3, IsHome = false, Image = "3.jpg" },
                new Product() {Name = "VR Shinecon Virtual Reality 3D Glasses google cardboard 2.0 Pro Version VR", Description = "VR Shinecon Virtual Reality 3D Glasses google cardboard 2.0 Pro Version VR description", Price = 56.75, Stock = 125, IsApproved = true, CategoryId =3, IsHome = true, Image = "4.jpg" },
                new Product() {Name = "KZ ATE S In Ear Earphones HIFI KZ ATE-S Stereo Sport", Description = "KZ ATE S In Ear Earphones HIFI KZ ATE-S Stereo Sport description", Price = 17.80, Stock = 390, IsApproved = true, CategoryId =3, IsHome = true, Image = "5.jpg" },
                new Product() {Name = "QCY Q26 mini car calls wireless Invisible headphone bluetooth 4.1", Description = "QCY Q26 mini car calls wireless Invisible headphone bluetooth 4.1 description", Price = 20.90, Stock = 60, IsApproved = true, CategoryId =3, IsHome = false , Image = "6.jpg"},

                new Product() {Name = "OnePlus 7", Description = "OnePlus 7 description", Price = 32999.00, Stock = 100, IsApproved = true, CategoryId =4, IsHome = false, Image = "1.jpg" },
                new Product() {Name = "Samsung Galaxy M30", Description = "Samsung Galaxy M30 description", Price = 13990.00, Stock = 420, IsApproved = true, CategoryId =4, IsHome = false , Image = "2.jpg"},
                new Product() {Name = "Redmi Y3", Description = "Redmi Y3 description", Price = 8999.00, Stock = 640, IsApproved = true, CategoryId =4, IsHome = false, Image = "3.jpg" },
                new Product() {Name = "Redmi 6", Description = "Redmi 6 description", Price = 6999.00, Stock = 60, IsApproved = true, CategoryId =4, IsHome = false, Image = "4.jpg" },
                new Product() {Name = "Xiaomi Mi A2", Description = "Xiaomi Mi A2 description", Price = 9999.00, Stock = 599, IsApproved = true, CategoryId =4, IsHome = false, Image = "5.jpg" },
                new Product() {Name = "Mi Redmi 6A", Description = "Mi Redmi 6A description ", Price = 6199.00, Stock = 423, IsApproved = true, CategoryId =4, IsHome = false, Image = "6.jpg" }

            };  //Test data

            foreach (var item in products)
            {
                context.Products.Add(item);
            }

            context.SaveChanges();

            base.Seed(context);
        }
    }
}