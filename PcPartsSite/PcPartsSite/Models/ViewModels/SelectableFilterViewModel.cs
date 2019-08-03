using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PcPartsSite.Models.ViewModels
{
    public class SelectableFilterViewModel
    {
        public FilterItem filter { get; set; }
        public Boolean isSelected { get; set; }
    }
}
