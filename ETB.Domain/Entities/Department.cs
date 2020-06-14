using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ETB.Core.Entities
{
    public class Department
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Deptartment { get; set; }
        [MaxLength(50)]
        public string DeptBelongsTo { get; set; } //Should contain state name
        public string CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
