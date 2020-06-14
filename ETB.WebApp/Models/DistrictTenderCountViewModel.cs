using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETB.WebApp.Models
{
    public class DistrictTenderCountViewModel
    {
        public int Id { get; set; }
        public string State { get; set; }
        public string District { get; set; }
        public int TenderCount { get; set; } = 0;
    }
}
