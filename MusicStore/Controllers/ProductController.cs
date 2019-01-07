using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MusicStore.Data;

namespace MusicStore.Controllers
{
    public class ProductController : BaseController
    {
        public ProductController(MusicStoreDbContext dbContext) : base(dbContext)
        {
        }
    }
}
