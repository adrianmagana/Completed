using System.ComponentModel.DataAnnotations;

namespace PcPartsSite.Models
{
    public class Filter
    {
        [Key, Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Filter")]
        [StringLength(25, MinimumLength = 1, ErrorMessage = "Filter must be between 1-25 characters")]
        public string Name { get; set; }
    }
}
