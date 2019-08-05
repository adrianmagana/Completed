using Microsoft.AspNetCore.Mvc;
using System.Linq;
using PcPartsSite.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace PcPartsSite.ViewComponents
{
    public class ProductCarouselViewComponent : ViewComponent
    {
        private readonly PcPartsDataContext _db;
        public ProductCarouselViewComponent(PcPartsDataContext db)
        {
            _db = db;
        }

        public IViewComponentResult Invoke()
        {
            var products = _db.Products.Where(p => p.Discount > 0).Take(6);
            return View(products);
        }
    }
}