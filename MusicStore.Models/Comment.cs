namespace MusicStore.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string UserId { get; set; }

        public MusicStoreUser User { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}