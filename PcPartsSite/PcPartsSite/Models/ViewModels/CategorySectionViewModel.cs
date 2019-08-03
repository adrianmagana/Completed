using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PcPartsSite.Models.ViewModels
{
    public class CategorySectionViewModel
    {
        public CategorySectionViewModel()
        {
            SubCategories = new List<SubCategory>();
        }
        public Category Category { get; set; }
        public List<SubCategory> SubCategories { get; set; } 
    }
}
