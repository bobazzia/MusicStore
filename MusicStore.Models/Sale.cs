using System;
using System.Collections.Generic;
using System.Text;

namespace MusicStore.Models
{
    public class Sale
    {
        public Sale()
        {
            this.Products = new HashSet<Product>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }

        public double PercentOffPrice { get; set; }
    }
}
