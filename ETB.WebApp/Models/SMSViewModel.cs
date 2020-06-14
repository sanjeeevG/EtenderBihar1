using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ETB.WebApp.Models
{
    public class SMSViewModel
    {
        [Required(ErrorMessage = "Phone numbers are required")]
        [Display(Name = "Comma Spearated Phone Numbers")]
        public string CommaSepToNum { get; set; }
        [MaxLength(200)]
        [Required(ErrorMessage = "Message is required.")]
        public string Message { get; set; }
    }
}
