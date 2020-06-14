using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ETB.WebApp.Models
{
    public class DivisionViewModel
    {
        public int Id { get; set; }
        public IList<SelectListItem> Departments { get; set; }
        public IList<SelectListItem> Districts { get; set; }
        [Required(ErrorMessage = "Department is required.")]
        [MaxLength(100)]
        [Display(Name = "Department")]
        public string DV_Department { get; set; }

        [Required(ErrorMessage = "District is required.")]
        [MaxLength(50)]
        [Display(Name = "District")]
        public string DV_District { get; set; }

        [Required(ErrorMessage =  "Division is required.")]
        [Display(Name = "Division")]
        [MaxLength(50)]
        public string DV_Division { get; set; }

        public IList<SelectListItem> NoOfRows { get; set; }
    }
}
