using System;

namespace MusicStore.Models
{
    public class Event
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public DateTime Datetime { get; set; }

        public int UserId { get; set; }

        public MusicStoreUser User { get; set; }
    }
}