using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETB.WebApp.Models
{
    public class ExContactIndexViewModel
    {
        public string FullName { get; set; }
        public string ContactNo1 { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Class { get; set; }
        public IList<SelectListItem> Districts { get; set; }
        public IList<SelectListItem> NoOfRows { get; set; }
    }
}
