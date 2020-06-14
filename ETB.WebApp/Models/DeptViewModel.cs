using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ETB.WebApp.Models
{
    public class DeptViewModel
    {
        public IList<SelectListItem> States { get; set; }
        [Required(ErrorMessage ="State is required.")]
        [MaxLength(50)]
        public string SelState {get; set;}
        [Required(ErrorMessage = "Dept. is required.")]
        [MaxLength(100)]
        public string Department1 { get; set; }

        public IList<SelectListItem> NoOfRows { get; set; }
    }
}
