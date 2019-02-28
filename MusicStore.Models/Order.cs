using System.Collections.Generic;

namespace MusicStore.Models
{
    public class Order
    {
        public Order()
        {
            this.Products = new List<Product>();
        }

        public int Id { get; set; }

        public string Address { get; set; }
        
        public int ProductId { get; set; }

        public ICollection<Product> Products { get; set; }

        public string UserId { get; set; }

        public virtual MusicStoreUser User { get; set; }
    }
}