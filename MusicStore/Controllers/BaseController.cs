using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicStore.Data;

namespace MusicStore.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
            this.Db = new MusicStoreDbContext(new DbContextOptions<MusicStoreDbContext>());
        }

        public MusicStoreDbContext Db { get; set; }
    }
}