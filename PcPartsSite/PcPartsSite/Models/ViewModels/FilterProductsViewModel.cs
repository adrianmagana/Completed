using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PcPartsSite.Models.ViewModels
{
    public class FilterProductsViewModel
    {
        public FilterProductsViewModel()
        {
            filterSections = new List<FilterSectionViewModel>();
        }
        public IEnumerable<Product> Products { get; set; }
        public List<FilterSectionViewModel> filterSections { get; set; }

    }
}
