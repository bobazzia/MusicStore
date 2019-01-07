using Microsoft.AspNetCore.Identity;
using MusicStore.Data;
using MusicStore.Models;

namespace MusicStore.Services
{
    public abstract class BaseService
    {
        protected BaseService(MusicStoreDbContext dbContext, 
            SignInManager<MusicStoreUser> signIn)
        {
            this.DbContext = dbContext;
            this.SignIn = signIn;
        }

        protected MusicStoreDbContext DbContext { get; }

        protected SignInManager<MusicStoreUser> SignIn { get; }
    }
}
