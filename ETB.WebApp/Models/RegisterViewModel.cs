using ETB.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ETB.WebApp.Models
{
    public class RegisterViewModel
    {
        [Required (ErrorMessage ="Salutation is required")]
        [MaxLength(10)]
        public string Salutation { get; set; } = Enum.GetName(typeof(Salutations), Salutations.Mr);
        
        [Required(ErrorMessage = "Full Name is required")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        
        [Required(ErrorMessage = "DOB is required")]
        [Display(Name = "DOB")]
        [DataType(DataType.Date)]
        public DateTime? DOB { get; set; }

        [Display(Name = "Code")]
        public string CountryAreaCode { get; set; }

        [Required(ErrorMessage = "Contact No is required")]
        [MaxLength(10, ErrorMessage = "Phone no. should be only 10 chars")]
        [Display(Name = "Contact No.")]
        public string ContactNo1 { get; set; }

        [Required(ErrorMessage = "Email Address is required")]
        [MaxLength(100)]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email1 { get; set; }

        [Required(ErrorMessage = "User Id is required")]
        [MaxLength(100)]
        [EmailAddress]
        [Display(Name = "User Id")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [Encrypted]
        [MaxLength(25, ErrorMessage ="You are not allowed to enter more than 25 chars")]
        [MinLength(8, ErrorMessage ="Minimum 8 to be entered.")]
        [Display(Name = "Password")]
        public string Pass { get; set; }

        [Required(ErrorMessage = "Role is required")]
        [Display(Name = "Role")]
        public UserRole UserRole { get; set; } = UserRole.Subscriber;
    }
}
