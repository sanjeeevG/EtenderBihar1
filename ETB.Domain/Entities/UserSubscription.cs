using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ETB.Core.Entities
{
    public enum PayingMethod
    {
        CASH, 
        CC,
        DC,
        Cheque,
        PayTM,
        NetBanking,
        OtherWallet,
        Others
    }
    public class UserSubscription
    {
        public int Id { get; set; }
        public virtual UserDetail UserDetail { get; set; }
        public virtual Service Service { get; set; }
        public DateTime StartDate {get; set;}
        public DateTime EndDate { get; set; }
        public DateTime ExtendedEndDate { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }
        public bool IsPaid { get; set; }
        public PayingMethod PayingMethod { get; set; }
        public decimal Amount { get; set; }
        public IsActive IsActive { get; set; } = IsActive.Y;
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        [MaxLength(50)]
        public string CreatedBy { get; set; }
        [MaxLength(50)]
        public string ModifiedBy { get; set; }
    }
}
