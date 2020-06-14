using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETB.WebApp.Models
{
    public class DivisionPostViewModel
    {
        public string Department { get; set; }
        public string District { get; set; }
        public string Division { get; set; }
    }
}
