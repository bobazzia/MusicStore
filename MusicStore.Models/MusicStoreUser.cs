﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace MusicStore.Models
{
    public class MusicStoreUser : IdentityUser
    {
        public MusicStoreUser()
        {
            this.Orders = new HashSet<Order>();
            this.Comments = new HashSet<Comment>();
            this.Events = new HashSet<Event>();
        }
        
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }
        
        public int? OrderId { get; set; }

        [ForeignKey("OrderId")]
        public  virtual Order Order { get; set; }

        public ICollection<Order> Orders { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<Event> Events { get; set; }
    }
}
