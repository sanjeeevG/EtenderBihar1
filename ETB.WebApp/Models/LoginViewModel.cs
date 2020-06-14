using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ETB.WebApp.Models
{
    public class LoginViewModel
    {
        
        [MaxLength(50)]
        [Display(Name = "User Id")]
        [Required(ErrorMessage = "User Id is required.")]
        [EmailAddress(ErrorMessage = "User Id is not in proper format.")]
        public string UserId { get; set; }


        [Required(ErrorMessage = "Password is required.")]
        [Display(Name = "Password")]
        [MaxLength(255)]
        public string Pass { get; set; }

        public bool RememberMe { get; set; } = true;
    }
}
