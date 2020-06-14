using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ETB.Core.Entities
{
    public enum NotificationRequired
    {
        NO,
        YES
    }

    public enum IsRecordUpdated
    {
        NO,
        YES
    }

    public enum Salutations
    {
        [Description("Mr.")]
        Mr,
        [Description("Mrs.")]
        Mrs,
        [Description("Dr.")]
        Dr
    }

    public enum Gender
    {
        Male,
        Female
    }


    public class UserDetail
    {
        public int Id { get; set; }
        public virtual UserInfo UserInfo { get; set; }
        [MaxLength(10)]
        public string Salutation { get; set; } = Enum.GetName(typeof(Salutations), Salutations.Mr);
        [MaxLength(50)]
        public string FName { get; set; }
        [MaxLength(50)]
        public string MName { get; set; }
        [MaxLength(50)]
        public string LName { get; set; }
        [NotMapped]
        public string FullName
        {
            get
            {
                if (!string.IsNullOrEmpty(MName ))
                    return $"{FName} {MName} {LName}";
                else
                    return $"{FName} {LName}";
            }
        }
        public Gender Gender { get; set; } = Gender.Male;
        [Range(16, 99)]
        public int Age { get; set; }
        public DateTime? DOB { get; set; }
        [MaxLength(150)]
        public string Address { get; set; }
        [MaxLength(75)]
        public string City { get; set; }
        public string Pin { get; set; }
        [MaxLength(50)]
        public string District { get; set; }
        [MaxLength(100)]
        public string Organisation { get; set; }
        [MaxLength(50)]
        public string Title { get; set; }
        [MaxLength(100)]
        public string Email1 { get; set; }
        [MaxLength(100)]
        public string Email2Optinal { get; set; } = string.Empty;
        public NotificationRequired WantEmailNotfi { get; set; } = NotificationRequired.NO;
        [MaxLength(20)]
        public string ContactNo1 { get; set; }
        [MaxLength(20)]
        public string ContactNo2Mobile { get; set; }
        [MaxLength(20)]
        public string ContactNo3Mobile { get; set; }
        [MaxLength(25)]
        public string Nationality { get; set; } = "Indian";
        public NotificationRequired WantSMSNotfi { get; set; } = NotificationRequired.NO;
        public NotificationRequired WantWhatsUpNotfi { get; set; } = NotificationRequired.NO;
        [MaxLength(255)]
        public string PhotoUrl {get; set;}
        [MaxLength(255)]
        public string WebUrl { get; set; }
        [MaxLength(15)]
        public string PanNo { get; set; }
        [MaxLength(50)]
        public string RegistrationNo { get; set; }
        public IsRecordUpdated IsDetailUpdated { get; set; } = IsRecordUpdated.NO;
        public IsActive IsActive { get; set; } = IsActive.Y;
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        [MaxLength(50)]
        public string CreatedBy { get; set; }
        [MaxLength(50)]
        public string ModifiedBy { get; set; }

    }
}
