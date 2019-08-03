using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PcPartsSite.Models
{
    public class SubCategory
    {
        [Key, Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Sub-Category")]
        [StringLength(25, MinimumLength = 1, ErrorMessage = "Sub-category must be between 1-25 characters")]
        public string SubCatName { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
    }
}
