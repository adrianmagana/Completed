using System;
using System.ComponentModel.DataAnnotations;


namespace MVCMovie.Models
{
    public class Movie
    {
        [Key, Required]
        public int Id { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage ="Title must be between 3 and 100 characters")]
        public string Title { get; set; }
        [DataType(DataType.Date), Required]
        [Display(Name ="Release Date")]
        public DateTime ReleaseDate { get; set; }
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Title must be between 3 and 50 characters")]
        public string Genre { get; set; }
        [DataType(DataType.Currency), Required]
        public decimal Price { get; set; }
    }
}