using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PcPartsSite.Models;
using PcPartsSite.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PcPartsSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly PcPartsDataContext _db;

        public HomeController(PcPartsDataContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult ListProducts(string value, string filter, FilterProductsViewModel fp)
        {
            List<FilterSectionViewModel> filterSecs = fp.filterSections;
            ViewBag.value = value;
            ViewBag.filter = filter;
            int id = 0;
            Int32.TryParse(value, out id); //if value is an integer converts to int otherwise leave 0
            IEnumerable<Product> products;

            switch (filter) //loads products based on specific request 
            {
                case "Cat":
                    products = _db.Products.Where(p => p.SubCategory.CategoryId == id);
                    break;

                case "SubCat":
                   products = _db.Products.Where(p => p.SubCategoryId == id);
                   break;

                case "Search":
                    products = _db.Products.Where(p => p.Name.Contains(value));
                    break;

                default:
                    products = _db.Products;
                    break;
            }
            FilterProductsViewModel vm = new FilterProductsViewModel();
            vm.filterSections = filterSecs;

            if(filterSecs.Count > 0) 
            {
                products = FilterProducts(products, filterSecs); //if there are selected filters then filter by selected filters                
            }
            else
            {
                filterSecs = new List<FilterSectionViewModel>();
                foreach (Filter f in _db.Filters)
                {
                    FilterSectionViewModel filterSection = new FilterSectionViewModel();
                    filterSection.SectionFilter = f;
                    filterSection.selectableFilters = new List<SelectableFilterViewModel>();
                    List<FilterItem> filterItems = _db.FilterItems.Where(i => i.FilterId == f.Id).ToList();
                    foreach (FilterItem filterItem in filterItems)
                    {
                        SelectableFilterViewModel selectableFilter = new SelectableFilterViewModel();
                        selectableFilter.filter = filterItem;
                        selectableFilter.isSelected = false;
                        filterSection.selectableFilters.Add(selectableFilter);
                    }
                    filterSecs.Add(filterSection);
                }
            }
            vm.Products = products; //for viewmodel approach <---------------------------
            vm.filterSections = filterSecs;
            return View("ListProducts", vm);                                
        }

        //filters a list of products with the give list of filters sectioned into sub lists
        public List<Product> FilterProducts(IEnumerable<Product> products, List<FilterSectionViewModel> filterSecs)
        {
            List<Product> filteredProducts = new List<Product>();
            List<FilterSectionViewModel> activeSections = new List<FilterSectionViewModel>();

            //loads activeSections with the filters that were selected including their sections
            foreach (FilterSectionViewModel filterSection in filterSecs)
            {
                bool hasActiveFilters = false;
                List<SelectableFilterViewModel> activeFilters = new List<SelectableFilterViewModel>();
                foreach (SelectableFilterViewModel selectableFilter in filterSection.selectableFilters)
                {
                    if (selectableFilter.isSelected)
                    {
                        activeFilters.Add(selectableFilter);
                        hasActiveFilters = true;
                    }
                }
                if (hasActiveFilters)
                {
                    FilterSectionViewModel section = new FilterSectionViewModel();
                    section.selectableFilters = activeFilters;
                    section.SectionFilter = filterSection.SectionFilter;
                    activeSections.Add(section);
                }
            }

            if (activeSections.Count == 0)
            {
                filteredProducts = products.ToList();
            }
            else
            {
                foreach (Product product in products)
                {
                    int sectionPassCounter = 0; //counter for all filter sections the product has passed
                    foreach (FilterSectionViewModel section in activeSections)
                    {
                        Type t = product.GetType();
                        PropertyInfo p = t.GetProperty(section.SectionFilter.Name);
                        var x = p.GetValue(product);
                        bool passed = false;

                        foreach (SelectableFilterViewModel filter in section.selectableFilters)
                        {
                            if ((filter.isSelected && (decimal)p.GetValue(product) >= (decimal)filter.filter.MinValue && (decimal)p.GetValue(product) <= (decimal)filter.filter.MaxValue))
                            {
                                passed = true;
                            }
                        }
                        if (passed)
                        {
                            sectionPassCounter++;
                        }
                    }
                    if (sectionPassCounter == activeSections.Count)
                    {
                        filteredProducts.Add(product);
                    }
                }
            }
            return filteredProducts;
        }

        public ActionResult ViewProduct(int id)
        {
            Product product = _db.Products.Find(id);
            CartItem item = new CartItem();
            item.Product = product;
            item.ProductId = product.Id;
            return View(item);
        }

        public ActionResult Categories()
        {
            List<CategorySectionViewModel> model = new List<CategorySectionViewModel>();
            var categories = _db.Categories;

            foreach (Category category in categories)
            {
                CategorySectionViewModel section = new CategorySectionViewModel();
                section.Category = category;
                section.SubCategories = _db.SubCategories.Where(sc => sc.CategoryId == category.Id).ToList();
                model.Add(section);
            }           
            return View(model);
        }

        public ActionResult AddToCart(CartItem item)
        {
            if (ModelState.IsValid)
            {
                item.UserName = User.Identity.Name;
                _db.CartItems.Add(item);
                _db.SaveChanges();
                return View("Index");
            }
            return View(item);
        }

        [Authorize]
        public ActionResult Cart()
        {
            string username = User.Identity.Name;
            var model = _db.CartItems.Include(c=> c.Product).Where(c => c.UserName == username);
            return View(model);
        }

        public ActionResult DeleteCartItem(int id)
        {
            CartItem item = _db.CartItems.Find(id);
            _db.Remove(item);
            _db.SaveChanges();
            return RedirectToAction("Cart");
        }

        public ActionResult Search(string value)
        {
            var products = _db.Products.Where(p => p.Name.Contains(value));
            ViewData["Filters"] = _db.Filters.ToArray();
            ViewData["FilterItems"] = _db.FilterItems.ToArray();
            return View("ListProducts", products);
        }
    }
}