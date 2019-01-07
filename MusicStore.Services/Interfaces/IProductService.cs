using System.Threading.Tasks;
using MusicStore.Models;
using MusicStore.ViewModels.Administrator;

namespace MusicStore.Services.Interfaces
{
    public interface IProductService
    {
        void AddProduct(AddProductViewModel model);
        
        void DeleteProduct(int id);
    }
}