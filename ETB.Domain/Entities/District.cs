using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ETB.Core.Entities
{
    public class District
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string DistrictName { get; set; }
        [MaxLength(50)]
        public string DistrictHQ { get; set; }
        [MaxLength(50)]
        public string State { get; set; }
    }
}
