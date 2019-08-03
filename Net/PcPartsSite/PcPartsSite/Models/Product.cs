using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PcPartsSite.Models
{
    public class Product
    {
        public static readonly decimal TAX = .1m;      

        [Key, Required]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Name must be between 3-100 characters")]
        public string Name { get; set; }

        [StringLength(280, MinimumLength = 3, ErrorMessage = "Description must be between 3-280 characters")]
        public string Description { get; set; }

        
        public byte[] Image { get; set; }

        [Required]
        [Range(.01,9999999.99, ErrorMessage ="Price is out of Range")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Price { get; set; }

        [Range(0, .99, ErrorMessage = "Price must be between 0-.99")]
        [DisplayFormat(DataFormatString = "{0:P0}")]
        public decimal? Discount { get; set; }

        [Required]
        [Display(Name = "SubCategory")]
        public int? SubCategoryId { get; set; }

        [ForeignKey("SubCategoryId")]
        public virtual SubCategory SubCategory { get; set; }
    }
}