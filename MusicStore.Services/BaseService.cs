using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using MusicStore.Data;
using MusicStore.Models;

namespace MusicStore.Services
{
    public abstract class BaseService
    {
        protected BaseService(MusicStoreDbContext dbContext, SignInManager<MusicStoreUser> signIn)
        {
            DbContext = dbContext;
            SignIn = signIn;
        }

        protected MusicStoreDbContext DbContext { get; set; }

        protected SignInManager<MusicStoreUser> SignIn { get; set; }
    }
}
