using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using MusicStore.Data;
using MusicStore.Models;
using MusicStore.ViewModels;
using MusicStore.ViewModels.Administrator;

namespace MusicStore.Controllers
{
    
    [Authorize(Roles = "Administrator")]
    public class AdministratorController : BaseController
    {
        public AdministratorController(MusicStoreDbContext dbContext) : base(dbContext)
        {
        }

        public IActionResult Index()
        {
            return this.View();
        }

        
    }
}
