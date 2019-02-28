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
            model.ListOfProducts = this.Db.Products.ToList();
            var userId = HttpContext.User.Identity.Name;
            model.User = this.Db.Users.FirstOrDefault(u => u.Email == userId);
            model.User.Order = this.Db.Orders.FirstOrDefault(u => u.UserId == model.User.Id);

            if (model.User.Order == null)
            {
                var order = new Order()
                {
                    UserId = model.User.Id,
                    User = model.User,
                };
                this.Db.Orders.Add(order);
                this.Db.SaveChanges();
            }
            
            var testOrder = this.Db.Orders.FirstOrDefault(u => u.UserId == model.User.Id);
            return this.View(model);
        }

        [HttpPost]
        public IActionResult Strings(int id, UserProductsViewModel model)
        {
            model.ListOfProducts = this.Db.Products.ToList();
            var product = this.Db.Products.Find(id);
            var userId = HttpContext.User.Identity.Name;
            var user = this.Db.Users.FirstOrDefault(u => u.Email == userId);
            var order = this.Db.Orders.FirstOrDefault(o => o.UserId == user.Id);
            order.Products.Add(product);
            this.Db.Orders.Update(order);
            
            this.Db.SaveChanges();
            //this.UserProductService.AddProductToUserOrderAsync(product, user);


            model.User = user;
            model.User.Order = order;
            
            var testOrder = this.Db.Orders.FirstOrDefault(u => u.UserId == model.User.Id);
            return this.View(model);
        }


        public IActionResult Guitars(UserProductsViewModel model)
        {
            model.ListOfProducts = this.Db.Products.ToList();
            var userId = HttpContext.User.Identity.Name;
            model.User = this.Db.Users.FirstOrDefault(u => u.Email == userId);
            model.User.Order = this.Db.Orders.FirstOrDefault(u => u.UserId == model.User.Id);

            if (model.User.Order == null)
            {
                model.User.Order = new Order();
            }
            
            return this.View(model);
        }

        [HttpPost]
        public IActionResult Guitars(int id, UserProductsViewModel model)
        {
            model.ListOfProducts = this.Db.Products.ToList();
            var product = this.Db.Products.Find(id);
            var userId = HttpContext.User.Identity.Name;
            var user = this.Db.Users.FirstOrDefault(u => u.Email == userId);
            var order = this.Db.Orders.FirstOrDefault(o => o.UserId == user.Id);
            order.Products.Add(product);
            this.Db.Orders.Update(order);

            this.Db.SaveChanges();


            model.User = user;
            model.User.Order = order;
            
            return this.View(model);
        }

        public IActionResult Keyboards(UserProductsViewModel model)
        {
            model.ListOfProducts = this.Db.Products.ToList();
            var userId = HttpContext.User.Identity.Name;
            model.User = this.Db.Users.FirstOrDefault(u => u.Email == userId);
            model.User.Order = this.Db.Orders.FirstOrDefault(u => u.UserId == model.User.Id);
            if (model.User.Order == null)
            {
                model.User.Order = new Order();
            }
            
            return this.View(model);
        }

        [HttpPost]
        public IActionResult Keyboards(int id, UserProductsViewModel model)
        {
            model.ListOfProducts = this.Db.Products.ToList();
            var product = this.Db.Products.Find(id);
            var userId = HttpContext.User.Identity.Name;
            var user = this.Db.Users.FirstOrDefault(u => u.Email == userId);

            this.UserProductService.AddProductToUserOrderAsync(product, user);

            model.User = this.Db.Users.FirstOrDefault(u => u.Email == userId);
            model.User.Order = this.Db.Orders.FirstOrDefault(o => o.UserId == user.Id);
            
            return this.View(model);
        }

        public IActionResult Woodwinds(UserProductsViewModel model)
        {
            model.ListOfProducts = this.Db.Products.ToList();
            var userId = HttpContext.User.Identity.Name;
            model.User = this.Db.Users.FirstOrDefault(u => u.Email == userId);
            model.User.Order = this.Db.Orders.FirstOrDefault(u => u.UserId == model.User.Id);
            if (model.User.Order == null)
            {
                model.User.Order = new Order();
            }
            
            return this.View(model);
        }

        [HttpPost]
        public IActionResult Woodwinds(int id, UserProductsViewModel model)
        {
            model.ListOfProducts = this.Db.Products.ToList();
            var product = this.Db.Products.Find(id);
            var userId = HttpContext.User.Identity.Name;
            var user = this.Db.Users.FirstOrDefault(u => u.Email == userId);

            this.UserProductService.AddProductToUserOrderAsync(product, user);

            model.User = this.Db.Users.FirstOrDefault(u => u.Email == userId);
            model.User.Order = this.Db.Orders.FirstOrDefault(o => o.UserId == user.Id);
            
            return this.View(model);
        }

        public IActionResult Brass(UserProductsViewModel model)
        {
            model.ListOfProducts = this.Db.Products.ToList();
            var userId = HttpContext.User.Identity.Name;
            model.User = this.Db.Users.FirstOrDefault(u => u.Email == userId);
            model.User.Order = this.Db.Orders.FirstOrDefault(u => u.UserId == model.User.Id);
            if (model.User.Order == null)
            {
                model.User.Order = new Order();
            }
            
            return this.View(model);
        }

        [HttpPost]
        public IActionResult Brass(int id, UserProductsViewModel model)
        {
            model.ListOfProducts = this.Db.Products.ToList();
            var product = this.Db.Products.Find(id);
            var userId = HttpContext.User.Identity.Name;
            var user = this.Db.Users.FirstOrDefault(u => u.Email == userId);

            this.UserProductService.AddProductToUserOrderAsync(product, user);

            model.User = this.Db.Users.FirstOrDefault(u => u.Email == userId);
            model.User.Order = this.Db.Orders.FirstOrDefault(o => o.UserId == user.Id);
           
            return this.View(model);
        }

        public IActionResult Accessories(UserProductsViewModel model)
        {
            model.ListOfProducts = this.Db.Products.ToList();
            var userId = HttpContext.User.Identity.Name;
            model.User = this.Db.Users.FirstOrDefault(u => u.Email == userId);
            model.User.Order = this.Db.Orders.FirstOrDefault(u => u.UserId == model.User.Id);
            if (model.User.Order == null)
            {
                model.User.Order = new Order();
            }
            
            return this.View(model);
        }

        [HttpPost]
        public IActionResult Accessories(int id, UserProductsViewModel model)
        {
            model.ListOfProducts = this.Db.Products.ToList();
            var product = this.Db.Products.Find(id);
            var userId = HttpContext.User.Identity.Name;
            var user = this.Db.Users.FirstOrDefault(u => u.Email == userId);

            this.UserProductService.AddProductToUserOrderAsync(product, user);

            model.User = this.Db.Users.FirstOrDefault(u => u.Email == userId);
            model.User.Order = this.Db.Orders.FirstOrDefault(o => o.UserId == user.Id);
            
            return this.View(model);
        }
    }
}
