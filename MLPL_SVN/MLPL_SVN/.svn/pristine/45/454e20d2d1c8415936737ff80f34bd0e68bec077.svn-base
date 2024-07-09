using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class ContraVoucher : BaseModel
  {
    public ContraVoucher()
    {
      this.Details = new List<ContraVoucherDetail>();
    }

    [Display(Name = "Voucher No")]
    public string VoucherNo { get; set; }

    [Display(Name = "Voucher Date")]
    public DateTime VoucherDate { get; set; }

    [Required(ErrorMessage = "Please enter Manual No")]
    [Display(Name = "Manual No")]
    public string ManualNo { get; set; }

    [Display(Name = "Reference No")]
    public string ReferenceNo { get; set; }

    [Display(Name = "Location")]
    public short LocationId { get; set; }

    public string LocationCode { get; set; }

    [Display(Name = "Prepared By")]
    public short PreparedById { get; set; }

    public string PreparedByCode { get; set; }

    public string PreparedByName { get; set; }

    [Display(Name = "Narration")]
    [Required(ErrorMessage = "Please enter Narration")]
    public string Narration { get; set; }

    public string FinYear { get; set; }

    public List<ContraVoucherDetail> Details { get; set; }
  }
}
