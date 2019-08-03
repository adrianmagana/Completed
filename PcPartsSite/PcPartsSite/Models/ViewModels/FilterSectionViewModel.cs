using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PcPartsSite.Models.ViewModels
{
    public class FilterSectionViewModel
    {
        public FilterSectionViewModel()
        {
            selectableFilters = new List<SelectableFilterViewModel>();
        }

        public Filter SectionFilter { get; set; }
        public List<SelectableFilterViewModel> selectableFilters{get;set;}
    }
}
