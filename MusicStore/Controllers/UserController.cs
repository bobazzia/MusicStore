using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicStore.Data;
using MusicStore.Models;
using MusicStore.ViewModels.User;

namespace MusicStore.Controllers
{
    public class UserController : BaseController
    {
        public UserController(MusicStoreDbContext dbContext) : base(dbContext)
        {
            
        }

        public MusicStoreUser MusicStoreUser { get; set; }

        public IActionResult Home(string usermane, MusicStoreUserViewModel model)
        {
            return View(model);
        }

        public IActionResult Strings(UserProductsViewModel model)
        {
            model.Products = this.Db.Products.Where(p => p.Category == Category.Strings).ToList();
            return this.View(model);
        }

        public IActionResult Guitars(UserProductsViewModel model)
        {
            model.Products = this.Db.Products.Where(p => p.Category == Category.Guitars).ToList();
            return this.View(model);
        }

        public IActionResult Keyboards(UserProductsViewModel model)
        {
            model.Products = this.Db.Products.Where(p => p.Category == Category.Keyboards).ToList();
            return this.View(model);
        }

        public IActionResult Woodwinds(UserProductsViewModel model)
        {
            model.Products = this.Db.Products.Where(p => p.Category == Category.Woodwinds).ToList();
            return this.View(model);
        }

        public IActionResult Brass(UserProductsViewModel model)
        {
            model.Products = this.Db.Products.Where(p => p.Category == Category.Brass).ToList();
            return this.View(model);
        }

        public IActionResult Accessories(UserProductsViewModel model)
        {
            model.Products = this.Db.Products.Where(p => p.Category == Category.Accessories).ToList();
            return this.View(model);
        }
    }
}
