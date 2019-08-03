using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PcPartsSite.Models;
using System.IO;
using System.Linq;

namespace PcPartsSite.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private readonly PcPartsDataContext _db;

        public ProductController(PcPartsDataContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
           return RedirectToAction("ListProducts");
        }

        [HttpGet]
        public IActionResult AddProduct()
        {

            if (_db.Categories.Count() > 0)
            {
                int categoryId = _db.Categories.First<Category>().Id;
                ViewData["SubCategories"] = new SelectList(_db.SubCategories.Where(subCat => subCat.CategoryId == categoryId), "Id", "SubCatName");
                ViewData["Categories"] = new SelectList(_db.Categories, "Id", "CatName");
            }

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddProduct(Product product, IFormFile file)
        {

            if (product.Discount == null)
            {
                product.Discount = 0;
            }

            if (product.SubCategoryId > 0)
            {
                product.SubCategory = _db.SubCategories.Find(product.SubCategoryId);
            }

            if (ModelState.IsValid & (file?.ContentType == "image/jpeg" | file?.ContentType == "image/png"))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    byte[] fileBytes = ms.ToArray();
                    product.Image = fileBytes;
                }
                product.Id = 0;
                _db.Products.Add(product);
                _db.SaveChanges();
                return RedirectToAction("ListProducts");
            }
            else
            {
                int catId = 0;
                if (product.SubCategory == null)
                {
                    if (_db.Categories.Count() > 0)
                    {
                        catId = _db.Categories.First<Category>().Id;
                    }

                }
                else
                {
                    catId = product.SubCategory.CategoryId;
                }
                ViewData["SubCategories"] = new SelectList(_db.SubCategories.Where(subCat => subCat.CategoryId == catId), "Id", "SubCatName");
                ViewData["Categories"] = new SelectList(_db.Categories, "Id", "CatName", product.SubCategory?.CategoryId);
                return View(product);
            }
        }
        [ValidateAntiForgeryToken]
        public IActionResult AddProductRefresh(Product product, int catId)
        {
            ViewData["SubCategories"] = new SelectList(_db.SubCategories.Where(subCat => subCat.CategoryId == catId), "Id", "SubCatName");
            ViewData["Categories"] = new SelectList(_db.Categories, "Id", "CatName", catId);
            foreach (var modelValue in ModelState.Values)
            {
                modelValue.Errors.Clear();
            }
            return View("AddProduct");
        }

        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            Product product = _db.Products.Include(p => p.SubCategory).Where(p => p.Id == id).SingleOrDefault();
            ViewData["SubCategories"] = new SelectList(_db.SubCategories.Where(subCat => subCat.CategoryId == product.SubCategory.CategoryId), "Id", "SubCatName");
            ViewData["Categories"] = new SelectList(_db.Categories, "Id", "CatName", product.SubCategory.CategoryId);
            ViewData["ImageValidation"] = "hidden";
            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateProduct(Product product, IFormFile file, string changeImg)
        {
            ViewData["ImageValidation"] = "hidden";
            if (product.Discount == null)
            {
                product.Discount = 0;
            }
            if (ModelState.IsValid)
            {
                if (changeImg == "on")
                {
                    if (file?.ContentType == "image/jpeg" | file?.ContentType == "image/png")
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            file.CopyTo(ms);
                            byte[] fileBytes = ms.ToArray();
                            product.Image = fileBytes;
                        }
                        _db.Entry(product).State = EntityState.Modified;
                        _db.SaveChanges();
                        return RedirectToAction("ListProducts");
                    }
                    else
                    {
                        SubCategory subCategory = _db.SubCategories.Find(product.SubCategoryId);
                        ViewData["SubCategories"] = new SelectList(_db.SubCategories.Where(subCat => subCat.CategoryId == subCategory.CategoryId), "Id", "SubCatName");
                        ViewData["Categories"] = new SelectList(_db.Categories, "Id", "CatName", subCategory.CategoryId);
                        ViewData["ImageValidation"] = "field-validation-error";
                        return View();
                    }
                }
                else
                {
                    _db.Entry(product).State = EntityState.Modified;
                    _db.SaveChanges();
                    return RedirectToAction("ListProducts");
                }
            }
            else
            {
                if (changeImg == "on" & !(file?.ContentType == "image/jpeg" | file?.ContentType == "image/png"))
                {
                    ViewData["ImageValidation"] = "field-validation-error";
                }
                SubCategory subCategory = _db.SubCategories.Find(product.SubCategoryId);
                ViewData["SubCategories"] = new SelectList(_db.SubCategories.Where(subCat => subCat.CategoryId == subCategory.CategoryId), "Id", "SubCatName");
                ViewData["Categories"] = new SelectList(_db.Categories, "Id", "CatName", subCategory.CategoryId);
                return View(product);
            }
        }
        [ValidateAntiForgeryToken]
        public IActionResult UpdateProductRefresh(Product product, int catId)
        {
            SubCategory subCategory = _db.SubCategories.Find(product.SubCategoryId);
            ViewData["SubCategories"] = new SelectList(_db.SubCategories.Where(subCat => subCat.CategoryId == catId), "Id", "SubCatName");
            ViewData["Categories"] = new SelectList(_db.Categories, "Id", "CatName", catId);
            ViewData["ImageValidation"] = "hidden";
            foreach (var modelValue in ModelState.Values) //clears errors so user doesn't think they submitted
            {
                modelValue.Errors.Clear();
            }
            return View("UpdateProduct");
        }

        [HttpGet]
        public IActionResult DeleteProduct(int id)
        {
            Product product = _db.Products.Where(x => x.Id == id).ToArray()[0];
            return View(product);
        }

        public IActionResult DeleteProductConfirmed(int id)
        {
            Product product = _db.Products.Where(x => x.Id == id).ToArray()[0];
            _db.Remove(product);
            _db.SaveChanges();
            return RedirectToAction("ListProducts");
        }

        public IActionResult ListProducts()
        {
            var products = _db.Products.Include(p => p.SubCategory).Include(p => p.SubCategory.Category).OrderBy(p => p.SubCategory.Category.CatName).ThenByDescending(p => p.SubCategory.SubCatName).ThenBy(p => p.Name).ToArray();
            return View(products);
        }
    }
}