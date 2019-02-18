using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicStore.Data;
using MusicStore.Models;
using MusicStore.Services;
using MusicStore.Services.Interfaces;
using MusicStore.ViewModels.User;

namespace MusicStore.Controllers
{
    public class UserController : BaseController
    {
        public UserController(MusicStoreDbContext dbContext, IUserProductService UserProductService) 
            : base(dbContext)
        {
            this.UserProductService = UserProductService;
        }

        public MusicStoreUser MusicStoreUser { get; set; }

        public IUserProductService UserProductService { get; }

        public IActionResult Home(string usermane, MusicStoreUserViewModel model)
        {
            return View(model);
        }

        public IActionResult Strings(UserProductsViewModel model)
        {
            var userId = HttpContext.User.Identity.Name;
            model.User = this.Db.Users.FirstOrDefault(u => u.Email == userId);
            model.User.Order = this.Db.Orders.FirstOrDefault(u => u.UserId == model.User.Id);
            if (model.User.Order == null)
            {
                model.User.Order = new Order();
            }
            model.Products = this.Db.Products.Where(p => p.Category == Category.Strings).ToList();
            return this.View(model);
        }

        [HttpPost]
        public IActionResult Strings(int id, UserProductsViewModel model)
        {
            var product = this.Db.Products.Find(id);
            var userId = HttpContext.User.Identity.Name;
            var user = this.Db.Users.FirstOrDefault(u => u.Email == userId);

            this.UserProductService.AddProductToUserOrder(product, user);
            
            
            model.User = this.Db.Users.FirstOrDefault(u => u.Email == userId);
            model.User.Order = this.Db.Orders.FirstOrDefault(o => o.UserId == user.Id);
            model.Products = this.Db.Products.Where(p => p.Category == Category.Strings).ToList();
            return this.View(model);
        }


        public IActionResult Guitars(UserProductsViewModel model)
        {
            var userId = HttpContext.User.Identity.Name;
            model.User = this.Db.Users.FirstOrDefault(u => u.Email == userId);
            model.User.Order = this.Db.Orders.FirstOrDefault(u => u.UserId == model.User.Id);
            if (model.User.Order == null)
            {
                model.User.Order = new Order();
            }
            model.Products = this.Db.Products.Where(p => p.Category == Category.Guitars).ToList();
            return this.View(model);
        }

        [HttpPost]
        public IActionResult Guitars(int id, UserProductsViewModel model)
        {
            var product = this.Db.Products.Find(id);
            var userId = HttpContext.User.Identity.Name;
            var user = this.Db.Users.FirstOrDefault(u => u.Email == userId);

            this.UserProductService.AddProductToUserOrder(product, user);


            model.User = this.Db.Users.FirstOrDefault(u => u.Email == userId);
            model.User.Order = this.Db.Orders.FirstOrDefault(o => o.UserId == user.Id);
            model.Products = this.Db.Products.Where(p => p.Category == Category.Guitars).ToList();
            return this.View(model);
        }

        public IActionResult Keyboards(UserProductsViewModel model)
        {
            var userId = HttpContext.User.Identity.Name;
            model.User = this.Db.Users.FirstOrDefault(u => u.Email == userId);
            model.User.Order = this.Db.Orders.FirstOrDefault(u => u.UserId == model.User.Id);
            if (model.User.Order == null)
            {
                model.User.Order = new Order();
            }
            model.Products = this.Db.Products.Where(p => p.Category == Category.Keyboards).ToList();
            return this.View(model);
        }

        [HttpPost]
        public IActionResult Keyboards(int id, UserProductsViewModel model)
        {
            var product = this.Db.Products.Find(id);
            var userId = HttpContext.User.Identity.Name;
            var user = this.Db.Users.FirstOrDefault(u => u.Email == userId);

            this.UserProductService.AddProductToUserOrder(product, user);

            model.User = this.Db.Users.FirstOrDefault(u => u.Email == userId);
            model.User.Order = this.Db.Orders.FirstOrDefault(o => o.UserId == user.Id);
            model.Products = this.Db.Products.Where(p => p.Category == Category.Keyboards).ToList();
            return this.View(model);
        }

        public IActionResult Woodwinds(UserProductsViewModel model)
        {
            var userId = HttpContext.User.Identity.Name;
            model.User = this.Db.Users.FirstOrDefault(u => u.Email == userId);
            model.User.Order = this.Db.Orders.FirstOrDefault(u => u.UserId == model.User.Id);
            if (model.User.Order == null)
            {
                model.User.Order = new Order();
            }
            model.Products = this.Db.Products.Where(p => p.Category == Category.Woodwinds).ToList();
            return this.View(model);
        }

        [HttpPost]
        public IActionResult Woodwinds(int id, UserProductsViewModel model)
        {
            var product = this.Db.Products.Find(id);
            var userId = HttpContext.User.Identity.Name;
            var user = this.Db.Users.FirstOrDefault(u => u.Email == userId);

            this.UserProductService.AddProductToUserOrder(product, user);

            model.User = this.Db.Users.FirstOrDefault(u => u.Email == userId);
            model.User.Order = this.Db.Orders.FirstOrDefault(o => o.UserId == user.Id);
            model.Products = this.Db.Products.Where(p => p.Category == Category.Woodwinds).ToList();
            return this.View(model);
        }

        public IActionResult Brass(UserProductsViewModel model)
        {
            var userId = HttpContext.User.Identity.Name;
            model.User = this.Db.Users.FirstOrDefault(u => u.Email == userId);
            model.User.Order = this.Db.Orders.FirstOrDefault(u => u.UserId == model.User.Id);
            if (model.User.Order == null)
            {
                model.User.Order = new Order();
            }
            model.Products = this.Db.Products.Where(p => p.Category == Category.Brass).ToList();
            return this.View(model);
        }

        [HttpPost]
        public IActionResult Brass(int id, UserProductsViewModel model)
        {
            var product = this.Db.Products.Find(id);
            var userId = HttpContext.User.Identity.Name;
            var user = this.Db.Users.FirstOrDefault(u => u.Email == userId);

            this.UserProductService.AddProductToUserOrder(product, user);

            model.User = this.Db.Users.FirstOrDefault(u => u.Email == userId);
            model.User.Order = this.Db.Orders.FirstOrDefault(o => o.UserId == user.Id);
            model.Products = this.Db.Products.Where(p => p.Category == Category.Brass).ToList();
            return this.View(model);
        }

        public IActionResult Accessories(UserProductsViewModel model)
        {
            var userId = HttpContext.User.Identity.Name;
            model.User = this.Db.Users.FirstOrDefault(u => u.Email == userId);
            model.User.Order = this.Db.Orders.FirstOrDefault(u => u.UserId == model.User.Id);
            if (model.User.Order == null)
            {
                model.User.Order = new Order();
            }
            model.Products = this.Db.Products.Where(p => p.Category == Category.Accessories).ToList();
            return this.View(model);
        }

        [HttpPost]
        public IActionResult Accessories(int id, UserProductsViewModel model)
        {
            var product = this.Db.Products.Find(id);
            var userId = HttpContext.User.Identity.Name;
            var user = this.Db.Users.FirstOrDefault(u => u.Email == userId);

            this.UserProductService.AddProductToUserOrder(product, user);

            model.User = this.Db.Users.FirstOrDefault(u => u.Email == userId);
            model.User.Order = this.Db.Orders.FirstOrDefault(o => o.UserId == user.Id);
            model.Products = this.Db.Products.Where(p => p.Category == Category.Accessories).ToList();
            return this.View(model);
        }
    }
}
