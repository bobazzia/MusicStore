using System;
using System.Threading.Tasks;
using MusicStore.Models;

namespace MusicStore.Services.Interfaces
{
    public interface IUserProductService
    {
          void AddProductToUserOrderAsync(Product product, MusicStoreUser user);
    }
}