using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MusicStore.Data;
using MusicStore.Models;
using MusicStore.Services.Interfaces;
using MusicStore.ViewModels.Administrator;

namespace MusicStore.Services
{
    public class ProductService : BaseService, IProductService
    {
        public ProductService(MusicStoreDbContext dbContext, SignInManager<MusicStoreUser> signIn) 
            : base(dbContext, signIn)
        {
        }

        public void AddProduct(AddProductViewModel model)
        {
            var product = new Product()
            {
                Name = model.Name,
                Image = model.Image,
                Price = model.Price,
                Description = model.Description,
                Category = model.Category
            };

            this.DbContext.Products.Add(product);
            this.DbContext.SaveChanges();
        }


        public void DeleteProduct(int id)
        {
            var product = this.DbContext.Products.FirstOrDefault(p => p.Id == id);
            this.DbContext.Products.Remove(product);
            this.DbContext.SaveChanges();
        }
    }
}
