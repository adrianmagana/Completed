using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PcPartsSite.Models;

namespace PcPartsSite.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly PcPartsDataContext _db;

        public CategoryController(PcPartsDataContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return RedirectToAction("ListCategories");
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                category.Id = 0;
                _db.Categories.Add(category);
                _db.SaveChanges();
                return RedirectToAction("ListCategories");
            }
            else
            {
                return View(category);
            }
        }


        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            Category category = _db.Categories.Find(id);
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(category).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("ListCategories");
            }
            else
            {
                return View(category);
            }
        }

        [HttpGet]
        public IActionResult DeleteCategory(int id)
        {
            Category category = _db.Categories.Find(id);
            ViewData["SubCategories"] = _db.SubCategories.Where(sc => sc.CategoryId == id).ToArray();
            ViewData["Products"] = _db.Products.Where(p => p.SubCategory.CategoryId == id).OrderBy(p => p.SubCategory.SubCatName).ToArray();
            return View(category);

        }
        [HttpPost]
        public IActionResult DeleteCategory(Category category)
        {

            _db.Remove(category);
            _db.SaveChanges();
            return RedirectToAction("ListCategories");
        }
        public IActionResult DeleteCategoryConfirmed(Category category)
        {
            _db.Remove(category);
            _db.SaveChanges();
            return RedirectToAction("ListCategories");
        }

        public IActionResult ListCategories(int id)
        {
            int categoryId = 0;
            if (id > 0)
            {
                categoryId = id;
            }
            else
            {
                if (_db.Categories.Count() > 0)
                {
                    categoryId = _db.Categories.First().Id;
                }
            }

            ViewData["SelectedId"] = categoryId;
            ViewData["SubCategories"] = _db.SubCategories.Where(sc => sc.CategoryId == categoryId).ToArray();
            var categories = _db.Categories.OrderBy(cat => cat.CatName);
            return View(categories);
        }

        //                              -------------------------------SUB-CATEGORY-------------------------------
        [HttpGet]
        public IActionResult AddSubCategory()
        {
            ViewData["Categories"] = new SelectList(_db.Categories, "Id", "CatName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddSubCategory(SubCategory subCategory)
        {
            if (ModelState.IsValid)
            {
                subCategory.Id = 0;
                _db.SubCategories.Add(subCategory);
                _db.SaveChanges();
                return RedirectToAction("ListCategories");
            }
            else
            {
                ViewData["Categories"] = new SelectList(_db.Categories, "Id", "CatName");
                return View(subCategory);
            }
        }

        [HttpGet]
        public IActionResult UpdateSubCategory(int id)
        {
            SubCategory subCategory = _db.SubCategories.Find(id);
            ViewData["Categories"] = new SelectList(_db.Categories, "Id", "CatName", subCategory.CategoryId);
            return View(subCategory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateSubCategory(SubCategory subCategory)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(subCategory).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("ListCategories");
            }
            else
            {
                ViewData["Categories"] = new SelectList(_db.Categories, "Id", "CatName", subCategory.CategoryId);
                return View(subCategory);
            }
        }

        [HttpGet]
        public IActionResult DeleteSubCategory(int id)
        {
            SubCategory subCategory = _db.SubCategories.Find(id);
            ViewData["Products"] = _db.Products.Where(p => p.SubCategoryId == id).ToArray();
            return View(subCategory);

        }
        [HttpPost]
        public IActionResult DeleteSubCategory(SubCategory subCategory)
        {

            _db.Remove(subCategory);
            _db.SaveChanges();
            return RedirectToAction("ListCategories");
        }
        public IActionResult DeleteSubCategoryConfirmed(SubCategory subCategory)
        {
            _db.Remove<SubCategory>(subCategory);
            _db.SaveChanges();
            return RedirectToAction("ListCategories");
        }
    }
}