using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ETB.Core.Entities
{
    public enum DurationType
    {
        Weekly  = 7,
        Monthly = 30,
        Quaterly = 90,
        HalfAnnually = 180,
        Annually = 365
    }

    public enum ServiceType
    {
        Demo, 
        Actual,
    }

    public class Service
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }
        //for image
        [MaxLength(255)]
        public string ServiceRepUrl { get; set; }
        public DurationType Duration { get; set; }
        public ServiceType ServiceType { get; set; }
        public decimal Price { get; set; }
        public IsActive IsActive { get; set; } = IsActive.Y;
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        [MaxLength(50)]
        public string CreatedBy { get; set; }
        [MaxLength(50)]
        public string ModifiedBy { get; set; }
        public virtual IList<ServiceDetail> ServiceDetails { get; set; }
    }
}
