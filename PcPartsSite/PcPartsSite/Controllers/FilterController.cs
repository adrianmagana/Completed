using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PcPartsSite.Models;

namespace PcPartsSite.Controllers
{
    [Authorize(Roles = "Admin")]
    public class FilterController : Controller
    {
        private readonly PcPartsDataContext _db;

        public FilterController(PcPartsDataContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return RedirectToAction("ListFilters");
        }

        [HttpGet]
        public IActionResult AddFilter()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddFilter(Filter filter)
        {
            if (ModelState.IsValid)
            {
                filter.Id = 0;
                _db.Filters.Add(filter);
                _db.SaveChanges();
                return RedirectToAction("ListFilters");
            }
            else
            {
                return View(filter);
            }
        }

        [HttpGet]
        public IActionResult UpdateFilter(int id)
        {
            Filter filter = _db.Filters.Find(id);
            return View(filter);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateFilter(Filter filter)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(filter).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("ListFilters");
            }
            else
            {
                return View(filter);
            }
        }

        [HttpGet]
        public IActionResult DeleteFilter(int id)
        {
            Filter filter = _db.Filters.Find(id);
            ViewData["FilterItems"] = _db.FilterItems.Where(fi => fi.FilterId == id).ToArray();
            return View(filter);

        }

        public IActionResult DeleteFilterConfirmed(Filter filter)
        {
            _db.Remove(filter);
            _db.SaveChanges();
            return RedirectToAction("ListFilters");
        }

        public IActionResult ListFilters(int id)
        {
            int filterId = 0;
            if (id > 0)
            {
                filterId = id;
            }
            else
            {
                if (_db.Filters.Count() > 0)
                {
                    filterId = _db.Filters.First().Id;
                }
            }

            ViewData["SelectedId"] = filterId;
            ViewData["FilterItems"] = _db.FilterItems.Where(fi => fi.FilterId == filterId).ToArray();
            var filters = _db.Filters.OrderBy(f => f.Name);
            return View(filters);
        }

        //                              -------------------------------Filter-Item-------------------------------
        [HttpGet]
        public IActionResult AddFilterItem()
        {
            ViewData["Filters"] = new SelectList(_db.Filters, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddFilterItem(FilterItem filterItem)
        {
            if (ModelState.IsValid)
            {
                filterItem.Id = 0;
                _db.FilterItems.Add(filterItem);
                _db.SaveChanges();
                return RedirectToAction("ListFilters");
            }
            else
            {
                ViewData["Filters"] = new SelectList(_db.Filters, "Id", "Name");
                return View(filterItem);
            }
        }

        public IActionResult DeleteFilterItem(FilterItem filterItem)
        {
            _db.Remove<FilterItem>(filterItem);
            _db.SaveChanges();
            return RedirectToAction("ListFilters");
        }

        [HttpGet]
        public IActionResult UpdateFilterItem(int id)
        {
            FilterItem filterItem = _db.FilterItems.Find(id);
            return View(filterItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateFilterItem(FilterItem filterItem)
        {
            if (ModelState.IsValid)
            {
                Filter fil = _db.Filters.Find(filterItem.FilterId);
                filterItem.Filter = fil;
                _db.Entry(filterItem).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("ListFilters");
            }
            else
            {
                return View(filterItem);
            }
        }
    }
}