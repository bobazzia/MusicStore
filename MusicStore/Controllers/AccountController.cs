using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MusicStore.Models;
using MusicStore.ViewModels;

namespace MusicStore.Controllers
{
    public class AccountController : BaseController
    {
        private SignInManager<MusicStoreUser> signIn;
        

        public AccountController(SignInManager<MusicStoreUser> signIn)
        {
            this.signIn = signIn;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            var user = this.signIn.UserManager.Users.FirstOrDefault(u => u.UserName == model.Username);
            if (user == null)
            {
                return this.View();
            }
            var passwordCheck = this.signIn.CheckPasswordSignInAsync(user, model.Password, false).Result;
            if (!passwordCheck.Succeeded)
            {
                return this.View();
            }
            this.signIn.SignInAsync(user, model.RememberMe).Wait();

            return RedirectToAction("Index", "Home");
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            var user = new MusicStoreUser()
            {
                Email = model.Email,
                UserName = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber
            };
            var result = this.signIn.UserManager.CreateAsync(user, model.Password).Result;

            if (this.signIn.UserManager.Users.Count() == 1)
            {
                var roleResult = this.signIn.UserManager.AddToRoleAsync(user, "Administrator").Result;
                if (roleResult.Errors.Any())
                {
                    return this.View();
                }
            }

            if (result.Succeeded)
            {
                this.signIn.SignInAsync(user, false).Wait();
                return this.RedirectToAction("Index", "Home");
            }
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signIn.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
