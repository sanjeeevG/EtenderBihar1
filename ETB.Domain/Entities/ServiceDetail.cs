using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ETB.Core.Entities
{
    public class ServiceDetail
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Detail { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
