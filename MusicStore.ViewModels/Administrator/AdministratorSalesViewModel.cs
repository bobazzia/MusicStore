using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MusicStore.Models;

namespace MusicStore.ViewModels.Administrator
{
    public class AdministratorSalesViewModel
    {
        public AdministratorSalesViewModel()
        {
            this.Sales = new List<Sale>();
        }

        public ICollection<Sale> Sales { get; set; }
    }
}
