using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETB.WebApp.Models
{
    public class FilterModel
    {
        public string PublishOrLive { get; set; }
        public string District { get; set; }
        public string NIT { get; set; }
        public string Division { get; set; }
        public string Organisation { get; set; }
        public string Department { get; set; }
        public string TendCor { get; set; }
        public string Archive { get; set; }
        public string ExpInSevenDays { get; set; }
    }
}
