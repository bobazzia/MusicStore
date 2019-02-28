using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MusicStore.Data;
using MusicStore.ViewModels.Administrator;

namespace MusicStore.Controllers.Administrator
{
    public class AdministratorUsersController : AdministratorController
    {
        public AdministratorUsersController(MusicStoreDbContext dbContext) : base(dbContext)
        {
        }

        public IActionResult Users(AdministratorUsersViewModel model)
        {
            var userId = HttpContext.User.Identity.Name;
            var userAdmin = this.Db.Users.FirstOrDefault(u => u.Email == userId);
            model.Users = this.Db.Users.Where(u => u.Email != userAdmin.Email).ToList();
            

            return this.View(model);
        }

        [HttpPost]
        public IActionResult Users(string id, AdministratorUsersViewModel model)
        {
            var user = this.Db.Users.Find(id);
            user.Order = this.Db.Orders.FirstOrDefault(o => o.UserId == id);
            if (user.Order != null)
            {
                this.Db.Orders.Remove(user.Order);
            }
            user.Order = null;
            this.Db.Users.Remove(user);
            this.Db.SaveChanges();

            var userId = HttpContext.User.Identity.Name; var userAdmin = this.Db.Users.FirstOrDefault(u => u.Email == userId);
            model.Users = this.Db.Users.Where(u => u.Email != userAdmin.Email).ToList();
            
            return this.View(model);
        }
    }
}
