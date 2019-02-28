using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MusicStore.Data;
using MusicStore.ViewModels.User;

namespace MusicStore.Controllers
{
    public class UserProfileController : BaseController

    {
        public UserProfileController(MusicStoreDbContext dbContext) : base(dbContext)
        {
        }

        public IActionResult Order(int id, UserOrder order)
        {
            var userId = HttpContext.User.Identity.Name;
            var user = this.Db.Users.FirstOrDefault(u => u.Email == userId);

            var products = this.Db.Products.ToList();
            if (id == 0)
            {
                user.Order = this.Db.Orders.FirstOrDefault(x => x.UserId == user.Id);
            }
            else
            {
                order.Order = this.Db.Orders.Find(id);
            }
            order.Order = user.Order;
            return this.View(order);
        }

        public IActionResult PreviousOrders()
        {
            
            return this.View();
        }

        public IActionResult ProfileInformation()
        {
            return this.View();
        }

        public IActionResult DeleteProduct(int id)
        {
            var products = this.Db.Products.ToList();
            var userId = HttpContext.User.Identity.Name;
            var user = this.Db.Users.FirstOrDefault(u => u.Email == userId);
            var order = this.Db.Orders.FirstOrDefault(x => x.UserId == user.Id);
            var product = this.Db.Products.Find(id);
            order.Products.Remove(product);
            this.Db.Orders.Update(order);
            this.Db.SaveChanges();

            return RedirectToAction("Order", "UserProfile");
        }
    }
}
