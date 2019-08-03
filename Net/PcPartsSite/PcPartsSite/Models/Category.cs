using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PcPartsSite.Models
{
    public class Category
    {
        [Key, Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Category")]
        [StringLength(25, MinimumLength = 1, ErrorMessage = "Name must be between 1-25 characters")]
        public string CatName { get; set; }

        public virtual ICollection<SubCategory> SubCategories { get; set; }
    }
}
