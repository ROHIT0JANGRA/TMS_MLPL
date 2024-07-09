//  
// Type: CodeLock.Models.VendorAdvancePayment
//  
//  
//  

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
    public class VendorAdvancePayment : BaseModel
    {
        public short VendorId { get; set; }

        [Display(Name = "Vendor")]
        [Required(ErrorMessage = "Please enter Vendor")]
        public string VendorCode { get; set; }

        public string VendorCodeName { get; set; }

        public string VendorName { get; set; }

        [Display(Name = "System Document No")]
        public string DocumentNo { get; set; }

        [Display(Name = "Manual Document No")]
        public string ManualDocumentNo { get; set; }

        [Required(ErrorMessage = "Please select At-least one Transport Mode")]
        [Display(Name = "Transport Mode")]
        public string TransportModeIdList { get; set; }

        [Display(Name = "Document Type")]
        public MasterGeneral[] DocumentTypes { get; set; }

        public string SelectedDocumentType { get; set; }

        [Display(Name = "From Date")]
        public DateTime FromDate { get; set; }

        [Display(Name = "To Date")]
        public DateTime ToDate { get; set; }

        [Required(ErrorMessage = "Please select Voucher Date")]
        [Display(Name = "Voucher Date")]
        public DateTime VoucherDate { get; set; }

        [Display(Name = "Manual VoucherNo")]
        public string ManualVoucherNo { get; set; }

        public string SelectedDocumentDetailType { get; set; }

        [Display(Name = "Payment Mode")]
        [Required(ErrorMessage = "Please select Payment Mode")]
        public string PaymentMode { get; set; }

        [Display(Name = "Amount Applicable")]
        [Range(0, 999999999, ErrorMessage = "Amount Applicable must be greater than zero")]
        public Decimal AmountApplicable { get; set; }

        [Display(Name = "Cash Amount")]
        public Decimal? CashAmount { get; set; }

        [Required(ErrorMessage = "Please select Cash Account")]
        [Display(Name = "Cash Account")]
        public string CashAccount { get; set; }

        [Display(Name = "Cheque Amount")]
        public Decimal? ChequeAmount { get; set; }

        [Display(Name = "Bank Account")]
        [Required(ErrorMessage = "Please select Bank Account")]
        public string BankAccount { get; set; }

        [Display(Name = "Cheque No")]
        [Required(ErrorMessage = "Please enter Cheque No.")]
        public string ChequeNo { get; set; }

        [Required(ErrorMessage = "Please enter Cheque Date")]
        [Display(Name = "Cheque Date")]
        public DateTime? ChequeDate { get; set; }

        public short LocationId { get; set; }

        public string LocationCode { get; set; }

        public byte DocumentType { get; set; }

        public string FinYear { get; set; }

        public List<VendorDocument> AdvanceDetails { get; set; }

        public Payment PaymentDetails { get; set; }


        [Display(Name = "Location")]
        public string BAMappedLocationid { get; set; }


        [Required(ErrorMessage = "Please Enter Location")]
        public string BAMappedLocation { get; set; }

        [Display(Name = "IS TDS Applicable")]
        public bool IsTDSApplicable { get; set; }
    }
}
