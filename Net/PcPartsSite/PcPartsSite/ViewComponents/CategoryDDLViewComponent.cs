using Microsoft.AspNetCore.Mvc;
using System.Linq;
using PcPartsSite.Models;

namespace PcPartsSite.ViewComponents
{
    public class CategoryDDLViewComponent :ViewComponent 
    {
        private readonly PcPartsDataContext _db;
        public CategoryDDLViewComponent(PcPartsDataContext db)
        {
            _db = db;
        }
        public IViewComponentResult Invoke(int selectedId)
        {
            ViewBag.id = selectedId;
            var categories = _db.Categories.OrderBy(x => x.CatName).ToArray();
            return View(categories);
        }
    }
}
