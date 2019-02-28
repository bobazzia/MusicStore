using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MusicStore.Data;
using MusicStore.Models;
using MusicStore.Services.Interfaces;

namespace MusicStore.Services
{
    public class UserProductService : BaseService, IUserProductService
    {
        public UserProductService(MusicStoreDbContext dbContext, SignInManager<MusicStoreUser> signIn) : base(dbContext, signIn)
        {
        }

        public void AddProductToUserOrderAsync(Product product, MusicStoreUser user)
        {
            user.Order = this.DbContext.Orders.FirstOrDefault(o => o.UserId == user.Id);

            if (user.Order == null)
            {
                user.Order = new Order()
                {
                    UserId = user.Id

                };
                user.Order.Products.Add(product);
                this.DbContext.Orders.Add(user.Order);
                this.DbContext.SaveChanges();
            }
            else
            {
                var order = this.DbContext.Orders.FirstOrDefault(o => o.UserId == user.Id);
                order.Products.Add(product);
               
                this.DbContext.Orders.Attach(order);
                this.DbContext.SaveChanges();
            }
        }
    }
}