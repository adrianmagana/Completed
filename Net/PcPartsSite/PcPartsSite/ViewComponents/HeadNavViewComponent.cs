using Microsoft.AspNetCore.Mvc;
using System.Linq;
using PcPartsSite.Models;
using Microsoft.EntityFrameworkCore;

namespace PcPartsSite.ViewComponents
{   
    public class HeadNavViewComponent : ViewComponent
    {
        private readonly PcPartsDataContext _db;
        public HeadNavViewComponent(PcPartsDataContext db)
        {
            _db = db;
        }
        public IViewComponentResult Invoke()
        {
            var categories = _db.Categories
                .Include(c => c.SubCategories)
                .OrderBy(c => c.CatName)
                .Take(3);
            return View(categories);
        }
    }
}