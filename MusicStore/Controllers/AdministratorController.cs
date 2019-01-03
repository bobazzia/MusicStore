using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using MusicStore.Data;
using MusicStore.Models;
using MusicStore.ViewModels;
using MusicStore.ViewModels.Administrator;

namespace MusicStore.Controllers
{
    
    [Authorize(Roles = "Administrator")]
    public class AdministratorController : BaseController
    {
        public IActionResult Index(AdministratorProductViewModel model)
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
                Image = Encoding.ASCII.GetBytes(model.Image),
                Price = model.Price,
                Description = model.Description, 
                Category = model.Category
            };
            this.Db.Products.Add(product);
            this.Db.SaveChanges();
            return RedirectToAction("Index", "Administrator");
        }

        
        public IActionResult Edit(int id, AddProductViewModel Product)
        {
            var product = this.Db.Products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                Product.Name = product.Name;
                Product.Description = product.Description;
                var bytesToString = Encoding.UTF8.GetString(product.Image);
                Product.Image = bytesToString;
                Product.Price = product.Price;
                Product.Category = product.Category;
            }
            return View(Product);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var product = this.Db.Products.FirstOrDefault(p => p.Id == id);
            this.Db.Products.Remove(product);
            this.Db.SaveChanges();

            return RedirectToAction("Index", "Administrator");
        }
    }
}
