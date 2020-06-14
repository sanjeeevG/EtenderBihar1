using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ETB.WebApp.Models
{
    public class ForgotPassViewModel
    {
        [Display(Name = "User Id")]
        public string UserId { get; set; }
    }
}
