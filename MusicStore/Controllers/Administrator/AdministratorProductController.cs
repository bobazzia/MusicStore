﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicStore.Data;
using MusicStore.Models;
using MusicStore.Services.Interfaces;
using MusicStore.ViewModels;
using MusicStore.ViewModels.Administrator;

namespace MusicStore.Controllers.Administrator
{
    public class AdministratorProductController : AdministratorController
    {
        public AdministratorProductController(MusicStoreDbContext dbContext, IProductService productService) 
            : base(dbContext)
        {
            this.ProductService = productService;
        }

        protected IProductService ProductService { get; }

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
            this.ProductService.AddProduct(model);
           
            return RedirectToAction("Products", "AdministratorProduct");
        }

        public IActionResult EditProduct(int id)
        {
            var product = this.Db.Products.Find(id);

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
            this.ProductService.DeleteProduct(id);
            return RedirectToAction("Products", "AdministratorProduct");
        }
    }
}
