using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicStore.Data;

namespace MusicStore.Controllers
{
    public class BaseController : Controller
    {
        public BaseController(MusicStoreDbContext dbContext)
        {
            this.Db = dbContext;
        }

        public MusicStoreDbContext Db { get; set; }
    }
}