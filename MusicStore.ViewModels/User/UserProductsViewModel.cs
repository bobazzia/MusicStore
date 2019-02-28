using System.Collections.Generic;
using MusicStore.Models;

namespace MusicStore.ViewModels.User
{
    public class UserProductsViewModel
    {
        public UserProductsViewModel()
        {
            this.ListOfProducts = new List<Product>();
        }

        public MusicStoreUser User { get; set; }

        public List<Product> ListOfProducts { get; set; }
    }
}