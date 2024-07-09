//  
// Type: CodeLock.Models.PurchaseOrderAdvancePayment
//  
//  
//  

using System;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class PurchaseOrderAdvancePayment
  {
    public long PoId { get; set; }

    public short LocationId { get; set; }

    [Display(Name = "PO No")]
    public string PoNo { get; set; }

    [Display(Name = "Vendor")]
    public short VendorId { get; set; }

    public string VendorCode { get; set; }

    [Display(Name = "Vendor Name")]
    public string VendorName { get; set; }

    [Display(Name = "Manual PO No")]
    public string ManualPoNo { get; set; }

    [Display(Name = "Voucher No")]
    public string VoucherNo { get; set; }

    [Required(ErrorMessage = "Please enter Voucher Date")]
    [Display(Name = "Voucher Date")]
    public DateTime VoucherDate { get; set; }

    [Display(Name = "PO Amount")]
    public Decimal PoAmount { get; set; }

    [Display(Name = "Advance Amount")]
    public Decimal AdvanceAmount { get; set; }

    [Display(Name = "Balance Amount")]
    public Decimal BalanceAmount { get; set; }

    public short EntryBy { get; set; }

    public string FinYear { get; set; }

    public short CompanyId { get; set; }

    public Payment PaymentDetails { get; set; }
  }
}
