//  
// Type: CodeLock.Models.VendorBillPayment
//  
//  
//  

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
    public class VendorBillPayment
    {
        public VendorBillPayment()
        {
            this.DocumentType = "1".ConvertToByte();
            this.PartyType = "1".ConvertToByte();
        }

        public short VendorId { get; set; }

        [Display(Name = "Vendor")]
        [Required(ErrorMessage = "Please enter Vendor")]
        public string VendorCode { get; set; }

        public string VendorCodeName { get; set; }

        public string VendorName { get; set; }

        [Display(Name = "Bill No")]
        public string BillNo { get; set; }

        [Display(Name = "Manual Bill No")]
        public string ManualBillNo { get; set; }

        [Display(Name = "From Date")]
        public DateTime FromDate { get; set; }

        [Display(Name = "To Date")]
        public DateTime ToDate { get; set; }

        [Required(ErrorMessage = "Please select Vendor Service")]
        [Display(Name = "Vendor Service")]
        public byte VendorServiceId { get; set; }

        [Required(ErrorMessage = "Please select Voucher Date")]
        [Display(Name = "Voucher Date")]
        public DateTime VoucherDate { get; set; }

        [Display(Name = "Manual Voucher No")]
        public string ManualVoucherNo { get; set; }
        [Display(Name = "Remarks")]
        public string BillPaymentRemarks { get; set; }

        public string PaymentMode { get; set; }

        public short LocationId { get; set; }

        public long ChequeId { get; set; }

        public string ChequeNo { get; set; }

        public DateTime ChequeDate { get; set; }

        public Decimal ChequeAmount { get; set; }

        public short BankAccount { get; set; }

        public Decimal AmountApplicable { get; set; }

        public bool IsByCash { get; set; }

        public string DocumentNo { get; set; }

        public string DocumentSuffix { get; set; }

        public byte DocumentType { get; set; }

        public string PartyCode { get; set; }

        public byte PartyType { get; set; }

        public string FinYear { get; set; }

        public short EntryBy { get; set; }

        public DateTime EntryDate { get; set; }

        public byte CompanyId { get; set; }

        public List<VendorBillDetail> VendorBillDetails { get; set; }

        public Payment PaymentDetails { get; set; }
    }
}
