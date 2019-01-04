using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicStore.Models;
using MusicStore.ViewModels;
using MusicStore.ViewModels.Administrator;

namespace MusicStore.Controllers.Administrator
{
    public class AdministratorProductController : AdministratorController
    {
        public IActionResult Products(AdministratorProductViewModel model)
        {
            model.Products = this.Db.Products.ToList();
            return this.View(model);
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(AddProductViewModel model)
        {
            var product = new Product()
            {
                Name = model.Name,
                Image = model.Image,
                Price = model.Price,
                Description = model.Description,
                Category = model.Category
            };
            this.Db.Products.Add(product);
            this.Db.SaveChanges();
            return RedirectToAction("Products", "AdministratorProduct");
        }

        public IActionResult EditProduct(int id)
        {
            var product = this.Db.Products.Find(id);// FirstOrDefault(p => p.Id == id);

            return View(product);
        }

        [HttpPost]
        public IActionResult EditProduct(int id, Product product)
        {
            if (ModelState.IsValid)
            {
                Db.Entry(product).State = EntityState.Modified;
                Db.SaveChanges();
                return RedirectToAction("Products");
            }
            return View(product);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var product = this.Db.Products.FirstOrDefault(p => p.Id == id);
            this.Db.Products.Remove(product);
            this.Db.SaveChanges();

            return RedirectToAction("Products", "AdministratorProduct");
        }
    }
}
