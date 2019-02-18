using MusicStore.Models;

namespace MusicStore.Services.Interfaces
{
    public interface IUserProductService
    {
        void AddProductToUserOrder(Product product, MusicStoreUser user);
    }
}