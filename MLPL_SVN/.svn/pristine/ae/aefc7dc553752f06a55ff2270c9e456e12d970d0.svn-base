using System;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
    public class AdvanceTrialBalance
    {
        [Display(Name = "Company")]
        public byte CompanyId { get; set; }

        [Display(Name = "Report Type")]
        public byte ReportTypeId { get; set; }

        [Display(Name = "Account")]
        public short AccountId { get; set; }
        public string AccountCode { get; set; }

        [Display(Name = "Report Type")]
        public byte ReportType { get; set; }

        [Display(Name = "Report Sub Type")]
        public byte ReportSubType { get; set; }

        [Display(Name = "Customer")]
        public short CodeId { get; set; }

        public string PartyIds { get; set; }

        public string Code { get; set; }

        public bool IsIndividual { get; set; }

        [Display(Name = "Location")]
        [Required(ErrorMessage = "Please select Location")]
        public short LocationId { get; set; }

        [Display(Name = "Category")]
        public byte AccountCategoryId { get; set; }

        public bool IsNormal { get; set; }

        [Display(Name = "Document No")]
        public string DocumentNo { get; set; }

        [Display(Name = "Cheque No")]
        public string ChequeNo { get; set; }
        public string FinYear { get; set; }

    }
}