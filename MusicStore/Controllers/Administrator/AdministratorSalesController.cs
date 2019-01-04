using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MusicStore.Models;
using MusicStore.ViewModels;
using MusicStore.ViewModels.Administrator;

namespace MusicStore.Controllers.Administrator
{
    public class AdministratorSalesController : AdministratorController
    {
        public IActionResult Sales(AdministratorSalesViewModel model)
        {
            model.Sales = this.Db.Sales.ToList();
            return this.View(model);
        }

        public IActionResult AddSale()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddSale(AddSaleViewModel model)
        {
            var sale = new Sale()
            {
                Name = model.Name,
                PercentOffPrice = model.PercentOff
            };
            this.Db.Sales.Add(sale);
            this.Db.SaveChanges();
            return RedirectToAction("Sales", "AdministratorSales");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var sale = this.Db.Sales.FirstOrDefault(p => p.Id == id);
            this.Db.Sales.Remove(sale);
            this.Db.SaveChanges();

            return RedirectToAction("Sales", "AdministratorSales");
        }
    }

   
}
