using ETB.Core.Entities;
using ETB.WebApp.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ETB.WebApp.Models
{
    public class TenderViewModel
    {
        public int Id { get; set; }
        public int RefId { get; set; }
        [Display(Name ="Status")]
        [Required(ErrorMessage = "Status is required.")]
        public PublishOrLive PublishOrLive { get; set; } = PublishOrLive.Published;
        [MaxLength(100)]
        [Required(ErrorMessage = "NIT is required.")]
        public string NIT { get; set; }
        [MaxLength(100)]
        [Display(Name ="Tender Ref")]
        public string TenderRef { get; set; }
        [MaxLength(50)]
        [Display(Name = "Work No")]
        public string WorkNo { get; set; }
        [Display(Name = "Type")]
        [Required(ErrorMessage = "Tender type is required.")]
        public string TenderType { get; set; }
        [MaxLength(150)]
        [Display(Name = "Title")]
        [Required(ErrorMessage = "Title is required.")]
        public string TenderTitle { get; set; }
        [Display(Name = "Description Of Work")]
        [Required(ErrorMessage = "Description of Work is required.")]
        public string DescOfWork { get; set; }
        [MaxLength(250)]
        [Display(Name = "Tender Document")]
        public string TenderDocument { get; set; }
        public string TenderDocumentPath { get; set; }
        public string TenderRelDocumentFilePath { get; set; }
        public List<TenderDocViewModel> TenderDocs { get; set; }
        [MaxLength(250)]
        [Display(Name = "Ref web address")]
        public string TenderRefSiteAddress { get; set; }
        [MaxLength(150)]
        public string Organisation { get; set; }
        [MaxLength(150)]
        public string Department { get; set; }
        [MaxLength(50)]
        [Required(ErrorMessage = "District is required.")]
        public string District { get; set; }
        [MaxLength(100)]
        public string Region { get; set; }
        [MaxLength(100)]
        public string Division { get; set; }
        [Display(Name = "ePublish Date")]
        [DataType(DataType.DateTime)]
        public DateTime? ePublishDate { get; set; }
        [DataType(DataType.DateTime)]
        [Display(Name = "Doc Download Start Date")]
        public DateTime? DocumentDownloadStDate { get; set; }
        [DataType(DataType.DateTime)]
        [Display(Name = "Doc Download End Date")]
        public DateTime? DocumentDownloadEdDate { get; set; }
        [DataType(DataType.DateTime)]
        [Display(Name = "Bid Opening Date")]
        [Required(ErrorMessage = "Bid Opening Date is required.")]
        public DateTime? BidOpeningDate { get; set; }
        [DataType(DataType.DateTime)]
        [Display(Name = "Bid Sumission Start Date")]
        public DateTime? BidSubmissionStDate { get; set; }
        [DataType(DataType.DateTime)]
        [Display(Name = "Bid Submission End Date")]
        [Required(ErrorMessage ="Bid Submission End Date is required.")]
        public DateTime? BidSubmissionEnDate { get; set; }

        [Display(Name = "Estimated Cost")]
        [Required(ErrorMessage = "Estimated Cost is required.")]
        //[DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(14, 2)")]
        [Range(.01, 999999999999.99 , ErrorMessage = "Estimated cost cannot be 0")]
        public decimal EstimatedCost { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(14, 2)")]
        [Range(.01, 999999999999.99, ErrorMessage = "Cost of BOQ cannot be 0")]
        //[DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = true)]
        [Display(Name = "Cost Of BOQ")]
        public decimal CostOfBOQ { get; set; }

        [Display(Name = "EMD")]
        [DataType(DataType.Currency)]
        [Range(.01, 999999999999.99, ErrorMessage = "EMD cannot be 0")]
        [Column(TypeName = "decimal(14, 2)")]
        //[DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = true)]
        public decimal EMD { get; set; }

        [Display(Name = "COT")]
        public string COT { get; set; }

        public Currency Currency { get; set; } = Currency.INR;
        public int ParentTenderId { get; set; }
        public IsActive IsActive { get; set; } = IsActive.Y;
        [Display(Name = "Payment Options")]
        public PaymentOption PaymentOption { get; set; }
        [Display(Name = "Payble At")]
        public string PayableAt { get; set; }
        [MaxLength(50)]
        [Display(Name = "EMD Pay. Options")]
        public string EMDPaymentOption { get; set; } //comma separated data.
        [Display(Name = "EMD Pay. Options")]
        public List<string> EMDPaymentOptions { get; set; } //comma separated data.
        [MaxLength(70)]
        [Display(Name = "EMD Payble At")]
        public string EMDPayableAt { get; set; }
        [Display(Name = "Bank Certificate")]
        public BankCertificate BankCertificate { get; set; }
        [Display(Name = "Unemployed Engineer")]
        public IsYesNo UnEmployedEng { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        [MaxLength(50)]
        public string CreatedBy { get; set; }
        [MaxLength(50)]
        public string ModifiedBy { get; set; }
        public string ValueFactor { get; set; }
        public IList<string> SelDivisions { get; set; }
        public IList<SelectListItem> States { get; set; }
        public string DefaultSelSTate { get; set; }
        public IList<SelectListItem> Districts { get; set; }
        public IList<SelectListItem> Divisions { get; set; }
        public IList<SelectListItem> TenderTypes { get; set; }
    }

}
