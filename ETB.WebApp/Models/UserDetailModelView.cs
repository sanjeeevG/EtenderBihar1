using ETB.Core.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ETB.WebApp.Models
{
    public class UserDetailModelView
    {
        public int Id { get; set; }
        //public virtual UserInfo UserInfo { get; set; }
        public int UserInfoId { get; set;}
        public string UserId { get; set; }
        public UserRole UserRole { get; set; }
        [MaxLength(10)]
        [Required(ErrorMessage = "Salutation is required.")]
        public string Salutation { get; set; }
        [MaxLength(50)]
        [Display(Name ="First Name")]
        [Required(ErrorMessage = "First Name is required.")]
        public string FName { get; set; }

        [MaxLength(50)]
        [Display(Name = "Middle Name")]
        public string MName { get; set; }

        [MaxLength(50)]
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is required.")]
        public string LName { get; set; }
        
        public Gender Gender { get; set; } = Gender.Male;
        [Range(16, 99)]
        public int Age { get; set; }
        [Display(Name = "DOB")]
        [Required(ErrorMessage = "DOB is required.")]
        public DateTime? DOB { get; set; }
        [MaxLength(150)]
        public string Address { get; set; }
        [MaxLength(75)]
        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; }
        public string Pin { get; set; }
        [MaxLength(50)]
        [Required(ErrorMessage = "District is required.")]
        public string District { get; set; }
        [MaxLength(100)]
        public string Organisation { get; set; }
        [MaxLength(50)]
        public string Title { get; set; }
        [MaxLength(100)]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required.")]
        public string Email1 { get; set; }
        [MaxLength(100)]
        [Display(Name = "Email (2nd)")]
        public string Email2Optinal { get; set; } = string.Empty;
        [Display(Name = "Email Notif.?")]
        public NotificationRequired WantEmailNotfi { get; set; } = NotificationRequired.NO;
        [Display(Name = "Code")]
        public string CountryAreaCode { get; set; }
        [MaxLength(10, ErrorMessage = "Phone no. should be only 10 chars")]
        [Display(Name = "Contact No (Primary)")]
        [Required(ErrorMessage = "Contact No (Primary) is required.")]
        public string ContactNo1 { get; set; }
        [MaxLength(10, ErrorMessage = "Phone no. should be only 10 chars")]
        [Display(Name = "Contact No (2nd)")]
        public string ContactNo2Mobile { get; set; }
        [MaxLength(10, ErrorMessage = "Phone no. should be only 10 chars")]
        [Display(Name = "Contact No (3rd)")]
        public string ContactNo3Mobile { get; set; }
        [MaxLength(25)]
        public string Nationality { get; set; } = "Indian";
        [Display(Name = "SMS Notif.?")]
        public NotificationRequired WantSMSNotfi { get; set; } = NotificationRequired.NO;
        [Display(Name = "Whatsup Notif.?")]
        public NotificationRequired WantWhatsUpNotfi { get; set; } = NotificationRequired.NO;
        [MaxLength(255)]
        [Display(Name = "Photo")]
        public string PhotoUrl { get; set; }
        public string PhotoOriginalUrl { get; set; }
        public string PhotoRelUrl { get; set; }
        [MaxLength(255)]
        [Display(Name = "Web Url")]
        public string WebUrl { get; set; }
        [MaxLength(10)]
        [Display(Name = "PAN No.")]
        [RegularExpression(@"[A-Z]{5}\d{4}[A-Z]{1}") ]
        [Required(ErrorMessage = "PAN No is required.")]
        public string PanNo { get; set; }
        [MaxLength(50)]
        [Display(Name = "Registration No.")]
        [Required(ErrorMessage = "Reg. No. is required.")]
        public string RegistrationNo { get; set; }
        [Display(Name = "Detail Updated?")]
        public IsRecordUpdated IsDetailUpdated { get; set; } = IsRecordUpdated.NO;
        [Display(Name = "Active?")]
        public IsActive IsActive { get; set; } = IsActive.Y;
        [Display(Name = "Creation Date")]
        public DateTime CreationDate { get; set; }
        [Display(Name = "Modif. Date")]
        public DateTime? ModificationDate { get; set; }
        [MaxLength(50)]
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }
        [MaxLength(50)]
        [Display(Name = "Modified By")]
        public string ModifiedBy { get; set; }
        public IList<SelectListItem> Districts { get; set; }
    }
}
