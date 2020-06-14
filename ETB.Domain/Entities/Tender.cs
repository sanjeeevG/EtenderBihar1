using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ETB.Core.Entities
{
    public enum IsActive
    {
        N,
        Y
    }

    public enum Currency
    {
        INR,
        USD
    }

    public enum PublishOrLive
    {
        Published,
        Live
    }

    public enum PaymentOption
    {
        Online,
        [Description("Demand Draft")]
        DD
    }

    public enum EMDPaymentOption
    {
        Online,
        [Description("Demand Draft")]
        DD,
        [Description("Fixed Deposite")]
        FD,
        [Description("Bank Guarantee")]
        BG,
        [Description("TD Pass")]
        TD_Pass,
        [Description("National Saving Certificate")]
        NSE,
        [Description("Kisan Vikas Patra")]
        KVP,
        Other
    }
    public enum IsYesNo
    {
        NO, 
        YES
    }

    public enum ValueIn
    {
        Crore,
        Lakh,
        Thousand,
        Actual,
    }

    public enum BankCertificate
    {
        [Description("10%")]
        Ten = 10,
        [Description("20%")]
        Twenty = 20,
        [Description("No")]
        NO = 0
    }

    public class Tender
    {
        public int Id { get; set; }
        public PublishOrLive PublishOrLive { get; set; } = PublishOrLive.Published;
        [MaxLength(100)]
        public string NIT { get; set; }
        [MaxLength(100)]
        public string TenderRef { get; set; }
        [MaxLength(50)]
        public string WorkNo { get; set; }
        public string TenderType { get; set; }
        [MaxLength(150)]
        public string TenderTitle { get; set; }
        public string DescOfWork { get; set; }
        [MaxLength(250)]
        public string TenderDocument { get; set; }
        public virtual IList<TenderDoc> TenderDocs { get; set; }
        [MaxLength(250)]
        public string TenderRefSiteAddress { get; set; }
        [MaxLength(150)]
        public string Organisation { get; set; }
        [MaxLength(150)]
        public string Department { get; set; }
        [MaxLength(100)]
        public string District { get; set; }
        [MaxLength(100)]
        public string Region { get; set; }
        [MaxLength(100)]
        public string Division { get; set; }
        public DateTime? ePublishDate { get; set; }
        public DateTime? DocumentDownloadStDate { get; set; }
        public DateTime? DocumentDownloadEdDate { get; set; }
        public DateTime BidOpeningDate { get; set; }
        public DateTime? BidSubmissionStDate { get; set; }
        public DateTime BidSubmissionEnDate { get; set; }
        public decimal EstimatedCost { get; set; }
        public decimal CostOfBOQ { get; set; }
        public decimal EMD { get; set; }
        public string COT { get; set; }
        public Currency Currency { get; set; } = Currency.INR;
        public int ParentTenderId { get; set; }
        public IsActive IsActive { get; set; } = IsActive.Y;
        public PaymentOption PaymentOption { get; set; }
        [MaxLength(70)]
        public string PayableAt { get; set; }
        [MaxLength(50)]
        public string EMDPaymentOption { get; set; }//comma separated data.
        [MaxLength(70)]
        public string EMDPayableAt { get; set; } 
        public BankCertificate BankCertificate { get; set; }
        public IsYesNo UnEmployedEng { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        [MaxLength(50)]
        public string CreatedBy { get; set; }
        [MaxLength(50)]
        public string ModifiedBy { get; set; }
        [MaxLength(25)]
        public string ValueFactor { get; set; }
    }
}
