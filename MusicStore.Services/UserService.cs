using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MusicStore.Models;
using MusicStore.Data;
using MusicStore.Services.Interfaces;
using MusicStore.ViewModels;

namespace MusicStore.Services
{
    public class UserService : BaseService, IUserService
    {
        public UserService(MusicStoreDbContext dbContext, SignInManager<MusicStoreUser> signIn) 
            : base(dbContext, signIn)
        {
        }

        public SignInResult UserLogin(LoginViewModel model)
        {
            var user = this.SignIn.UserManager.Users.FirstOrDefault(u => u.UserName == model.Username);
            if (user == null)
            {
                return SignInResult.Failed;
            }
            
            var result = this.SignIn.PasswordSignInAsync(user, model.Password, true, false).Result;
            return result;
        }

        public async Task<SignInResult> RegisterUser(RegisterViewModel model)
        {
            bool uniqueEmail = this.SignIn.UserManager.Users.Any(x => x.Email != model.Email);

            if (!uniqueEmail)
            {
                return SignInResult.Failed;
            }

            var user = new MusicStoreUser()
            {
                Email = model.Email,
                UserName = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber
            };
            await this.SignIn.UserManager.CreateAsync(user, model.Password);
            if (this.SignIn.UserManager.Users.Count() == 1)
            {
                var roleResult = this.SignIn.UserManager.AddToRoleAsync(user, "Administrator").Result;
                if (roleResult.Errors.Any())
                {
                    return SignInResult.Failed;
                }
            }
            var result = await SignIn.PasswordSignInAsync(user, model.Password, true, false);

            return result;
        }

        public async void Logout()
        {
            await this.SignIn.SignOutAsync();
        }
    }
}
