using ETB.Core.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ETB.WebApp.Models
{
    public class UserSubscriptionViewModel
    {
        public int Id { get; set; }
        [Display(Name ="User Detail Id")]
        public int UserDetailId { get; set; }
        [Display(Name = "User Name")]
        public string FullName { get; set; }
        [Display(Name = "Service Id")]
        [Required(ErrorMessage = "Choose a Service")]
        public int ServiceId { get; set; }
        [Display(Name = "Service Name")]
        public string ServiceName { get; set; }
        public string UserId { get; set; }
        [Display(Name = "Start Date")]
        [Required(ErrorMessage = "Start Date is required.")]
        public DateTime StartDate { get; set; }
        [Display(Name = "End Date")]
        [Required(ErrorMessage = "End Date is required.")]
        public DateTime EndDate { get; set; }
        [Display(Name = "Extended End Date")]
        public DateTime? ExtendedEndDate { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }
        public bool IsPaid { get; set; }
        [Display(Name = "Paying Method")]
        public PayingMethod PayingMethod { get; set; }
        [Required(ErrorMessage = "Amount is required.")]
        public decimal Amount { get; set; }
        [Display(Name = "Is Active")]
        public IsActive IsActive { get; set; } = IsActive.Y;
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        [MaxLength(50)]
        public string CreatedBy { get; set; }
        [MaxLength(50)]
        public string ModifiedBy { get; set; }
        public IList<SelectListItem> Services { get; set;}
    }
}
