using ETB.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETB.WebApp.Models
{
    public class TenderDocViewModel
    {
        public int Id { get; set; }
        public string DocPath { get; set; }
        public string DocName { get; set; }
        public DocFor DocFor { get; set; }
        public string DocRelPathName { get; set; }
        public DateTime? TenderCreatedDate { get; set; }
    }
}
