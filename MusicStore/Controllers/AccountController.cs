using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using MusicStore.Data;
using MusicStore.Models;
using MusicStore.Services;
using MusicStore.Services.Interfaces;
using MusicStore.ViewModels;
using MusicStore.ViewModels.Account;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace MusicStore.Controllers
{
    public class AccountController : BaseController
    {
        private SignInManager<MusicStoreUser> signIn;

        protected IUserService UserService { get; }

        public AccountController(SignInManager<MusicStoreUser> signIn, IUserService userService, MusicStoreDbContext dbContext) 
            : base(dbContext)
        {
            this.signIn = signIn;
            UserService = userService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            var result = this.UserService.UserLogin(model);
            if (result != SignInResult.Success)
            {
                return this.View();
            }
            
            
            return RedirectToAction("Home", "User");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }
            var result = this.UserService.RegisterUser(model).Result;
            
            if (result.Succeeded)
            {
                return this.RedirectToAction("Home", "User");
            }
            return this.View();
        }

        
        public IActionResult Logout()
        {
            this.UserService.Logout();
            return RedirectToAction("Index", "Home");
        }
    }
}
