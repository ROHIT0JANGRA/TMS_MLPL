//  
// Type: CodeLock.Models.SpecialCostVoucherDetail
//  
//  
//  

using System;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class SpecialCostVoucherDetail
  {
    [Display(Name = "GST Exempted")]
    public bool GstExempted { get; set; }

    [Display(Name = "TDS Exempted")]
    public bool TdsExempted { get; set; }

    [Display(Name = "Goods/Product\t")]
    public bool IsProduct { get; set; }

    public short AccountId { get; set; }

    [Display(Name = "Account Code")]
    [Required(ErrorMessage = "Please enter Account Code")]
    public string AccountCode { get; set; }

    [Display(Name = "Account Description")]
    public string AccountDescription { get; set; }

    [Required(ErrorMessage = "Please select Cost Center Type")]
    [Display(Name = "Cost Center Type")]
    public byte CostCenterType { get; set; }

    [Display(Name = "Cost Center")]
    public short CostCenterId { get; set; }

    [Required(ErrorMessage = "Please enter Cost Center")]
    public string CostCenter { get; set; }

    [Required(ErrorMessage = "Please select SAC")]
    [Display(Name = "SAC/HSN")]
    public byte SacId { get; set; }

    [Display(Name = "Units")]
    public int Units { get; set; }

    [StringLength(200, ErrorMessage = "Narration must be minimum 2 and maximum 200 character long", MinimumLength = 2)]
    [Display(Name = "Narration")]
    [Required(ErrorMessage = "Please enter Narration")]
    public string Narration { get; set; }

    [Required(ErrorMessage = "Please enter Amount")]
    [Range(0.001, 10000000.0, ErrorMessage = "Please enter Amount")]
    [Display(Name = "Amount")]
    public Decimal Amount { get; set; }

    [Display(Name = "RCM")]
    public string Rcm { get; set; }

    public bool IsRcm { get; set; }

    [Display(Name = "GST Rate")]
    public Decimal GstRate { get; set; }

    [Display(Name = "GST Amount")]
    public Decimal GstAmount { get; set; }

    [Display(Name = "GST Charged")]
    public Decimal GstCharged { get; set; }

    [Display(Name = "Total Amount")]
    public Decimal TotalAmount { get; set; }

    [Required(ErrorMessage = "Please enter Document No")]
    public string DocumentNo { get; set; }

    [Display(Name = "Document No")]
    public long DocumentId { get; set; }
  }
}
