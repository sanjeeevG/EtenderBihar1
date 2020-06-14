using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETB.WebApp.Models
{
    public class Index2ViewModel
    {
        public IList<SelectListItem> Nits { get; set; }
        public IList<SelectListItem> Divisions { get; set; }
        public IList<SelectListItem> Oganisations { get; set; }
        public IList<SelectListItem> Departments { get; set; }
        public IList<SelectListItem> NoOfRows { get; set; }
    }
}
