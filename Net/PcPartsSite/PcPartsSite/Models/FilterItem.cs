using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PcPartsSite.Models.Validation;
namespace PcPartsSite.Models
{
    public class FilterItem
    {
        [Key, Required]
        public int Id { get; set; }

        [Required]
        public int FilterId { get; set; }

        [ForeignKey("FilterId")]
        public virtual Filter Filter { get; set; }

        [Required]
        [Display(Name ="Filter Item")]
        public string Display { get; set; }

        public string Value { get; set; }

        [RequiredIfFieldNull("Value")]
        public double? MinValue { get; set; }

        [RequiredIfFieldNull("Value")]
        public double? MaxValue { get; set; }
    }
}
