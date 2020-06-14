using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ETB.Core.Entities
{
    public class UserService
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public int UserDetailId { get; set; }
        public DateTime ServiceStDate { get; set; }
        public DateTime ServiceEnDate { get; set; }
        public decimal OriginalAmt { get; set; }
        public decimal AmtReceived { get; set; }
        public decimal AmtReceivedDate { get; set; }
        public IsActive IsServiceInForce { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        [MaxLength(50)]
        public string CreatedBy { get; set; }
        [MaxLength(50)]
        public string ModifiedBy { get; set; }

    }
}
