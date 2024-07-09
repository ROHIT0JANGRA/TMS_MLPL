//  
// Type: CodeLock.Models.MultipleVoucher
//  
//  
//  

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class MultipleVoucher
  {
    public MultipleVoucher()
    {
      this.Details = new List<MultipleVoucherDetail>();
    }

    [Display(Name = "Voucher No")]
    public string VoucherNo { get; set; }

    [Display(Name = "Voucher Date")]
    public DateTime VoucherDate { get; set; }

    [Display(Name = "Manual No")]
    [Required(ErrorMessage = "Please enter Manual No")]
    public string ManualNo { get; set; }

    [Display(Name = "Reference No")]
    public string ReferenceNo { get; set; }

    [Display(Name = "Prepared at Location")]
    public short PreparedLocationId { get; set; }

    public string PreparedLocationCode { get; set; }

    [Display(Name = "Prepared For")]
    [Required(ErrorMessage = "Please enter Prepared For")]
    public string PreparedFor { get; set; }

    [Display(Name = "Paid To")]
    public byte CodeType { get; set; }

    public string Narration { get; set; }

    [Display(Name = "Cost Center Selection")]
    public bool CostCenterSelection { get; set; }

    [Display(Name = "Cost Center Type")]
    public byte CostCenterType { get; set; }

    [Display(Name = "Cost Center Value")]
    public short CostCenterId { get; set; }

    public string CostCenter { get; set; }

    public List<MultipleVoucherDetail> Details { get; set; }
  }
}
