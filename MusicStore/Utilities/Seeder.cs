using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using MusicStore.Data;
using MusicStore.Models;

namespace MusicStore.Utilities
{
    public static class Seeder
    {
        public static async Task Seed(IServiceProvider provider)
        {
            var roleManager = provider.GetService<RoleManager<IdentityRole>>();
            var adminRoleExists = roleManager.RoleExistsAsync("Administrator").Result;
            if (!adminRoleExists)
            {
                
                await roleManager.CreateAsync(new IdentityRole("Administrator"));
            }
        }
    }
}
