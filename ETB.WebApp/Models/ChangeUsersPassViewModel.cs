using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ETB.WebApp.Models
{
    public class ChangeUsersPassViewModel
    {
        [Display(Name = "User Id")]
        public string UserId { get; set; }

        [Display(Name = "User Id")]
        public string UserIdEncr { get; set; }

        [Display(Name = "Name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "New Password is required")]
        [Encrypted]
        [MaxLength(255)]
        [Display(Name = "New Password")]
        public string Pass { get; set; }
    }
}
