using System.Collections.Generic;

namespace MusicStore.Models
{
    public class Order
    {
        public Order()
        {
            this.Products = new HashSet<Product>();
        }

        public int Id { get; set; }

        public string Address { get; set; }

        public ICollection<Product> Products { get; set; }

        public int UserId { get; set; }

        public MusicStoreUser User { get; set; }
    }
}