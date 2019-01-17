using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicStore.Data;
using MusicStore.ViewModels.User;

namespace MusicStore.Controllers
{
    public class UserController : BaseController
    {
        public UserController(MusicStoreDbContext dbContext) : base(dbContext)
        {
        }

        public IActionResult Home(string usermane, MusicStoreUserViewModel model)
        {
            
            model.User = this.Db.Users.FirstOrDefault(u => u.UserName == usermane);
            return View(model);
        }
    }
}
