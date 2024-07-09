using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class CrossLocationVoucher
  {
    public CrossLocationVoucher()
    {
      this.Details = new List<CrossLocationVoucherDetail>();
    }

    public byte CompanyId { get; set; }

    [Display(Name = "Voucher No")]
    public string VoucherNo { get; set; }

    [Display(Name = "Voucher Date")]
    public DateTime VoucherDate { get; set; }

    [Display(Name = "Manual No")]
    [Required(ErrorMessage = "Please enter Manual No")]
    public string ManualNo { get; set; }

    [Display(Name = "Prepared at Location")]
    public short PreparedLocationId { get; set; }

    public string PreparedLocationCode { get; set; }

    [Display(Name = "Accounting Location")]
    public short AccountingLocationId { get; set; }

    public string AccountingLocationCode { get; set; }

    [Display(Name = "Business Devision")]
    [Required(ErrorMessage = "Please select Business Devision")]
    public byte BusinessTypeId { get; set; }

    [Display(Name = "Prepared For")]
    public string PreparedFor { get; set; }

    [Display(Name = "Reference No")]
    public string ReferenceNo { get; set; }

    public byte CodeType { get; set; }

    [Display(Name = "Paid To")]
    public short CodeId { get; set; }

    [Display(Name = "Paid To")]
    [Required(ErrorMessage = "Please enter Paid To")]
    public string Code { get; set; }

    public string PartyName { get; set; }

    [Display(Name = "Narration")]
    public string Narration { get; set; }

    [Display(Name = "Crossing Location")]
    public short CrossingLocationId { get; set; }

    [Required(ErrorMessage = "Please enter Cross Location")]
    public string CrossingLocationCode { get; set; }

    [Display(Name = "Transaction Mode")]
    [Required(ErrorMessage = "Please select Transaction Mode")]
    public byte TransactionModeId { get; set; }

    public List<CrossLocationVoucherDetail> Details { get; set; }

    public Payment PaymentDetails { get; set; }

    public Receipt ReceiptDetails { get; set; }
  }
}
