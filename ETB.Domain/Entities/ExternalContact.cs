using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ETB.Core.Entities
{
    public class ExternalContact
    {
        public int Id { get; set; }
        public string Salutation { get; set; } = Enum.GetName(typeof(Salutations), Salutations.Mr);
        public string FullName { get; set; }
        [MaxLength(75)]
        public string City { get; set; }
        public string District { get; set; }
        [MaxLength(100)]
        public string Organisation { get; set; }
        [MaxLength(50)]
        public string Title { get; set; }
        [MaxLength(100)]
        public string Email1 { get; set; }
        [MaxLength(20)]
        public string ContactNo1 { get; set; }
        [MaxLength(150)]
        public string Address { get; set; }
        [MaxLength(10)]
        public string Class { get; set; }
        [MaxLength(15)]
        public string PanNo { get; set; }
        [MaxLength(50)]
        public string CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        

    }
}
