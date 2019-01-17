using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MusicStore.Models;

namespace MusicStore.ViewModels.Administrator
{
    public class AddProductViewModel
    {
        [Required]
        public string Name { get; set; }

        public IFormFile Image { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        public Category Category { get; set; }
    }
}
