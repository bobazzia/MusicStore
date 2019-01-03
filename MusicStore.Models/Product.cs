using System.Collections.Generic;

namespace MusicStore.Models
{
    public class Product
    {
        public Product()
        {
            this.Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        public Category Category { get; set; }

        public ICollection<Comment> Comments { get; set; }

    }
}