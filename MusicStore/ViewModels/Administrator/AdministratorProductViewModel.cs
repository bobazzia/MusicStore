using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using MusicStore.Models;

namespace MusicStore.ViewModels
{
    public class AdministratorProductViewModel
    {
        public AdministratorProductViewModel()
        {
            this.Products = new List<Product>();
        }
        
        public int ProductId { get; set; }

        public List<Product> Products { get; set; }
        
    }
}
