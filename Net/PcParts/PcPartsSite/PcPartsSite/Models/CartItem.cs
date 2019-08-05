using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PcPartsSite.Models
{
    public class CartItem
    {
        [Required]
        public int Id { get; set; }

        public string UserName { get; set; }

        [Required]
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        [Required]
        [Display(Name = "Amount")]
        public int Quantity { get; set; }


    }
}
