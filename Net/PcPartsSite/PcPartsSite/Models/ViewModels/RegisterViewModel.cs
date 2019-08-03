using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PcPartsSite.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress, MaxLength(500)]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="Confirm Password")]
        [Compare("Password" , ErrorMessage = "Passwords do not match")]
        public string PasswordConfirm { get; set; }
    }
}
