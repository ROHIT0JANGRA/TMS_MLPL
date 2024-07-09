//  
// Type: CodeLock.Models.Tax
//  
//  
//  

using ExpressiveAnnotations.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class Tax
  {
    [Display(Name = "Please check here to enable GST")]
    public bool EnableGst { get; set; }

    [Display(Name = "Exempted Category")]
    public byte GstExemptedCategoryId { get; set; }

    [Display(Name = "Please check here to enable TDS")]
    public bool EnableTds { get; set; }

    [Display(Name = "Please check here to apply round off GST")]
    public bool RoundOffGst { get; set; }

    [Display(Name = "Please check here to apply round off TDS")]
    public bool RoundOffTds { get; set; }

    [Display(Name = "Please check here to apply TDS Without GST")]
    public bool TdsWithoutGst { get; set; }

    [Display(Name = "Amount applicable for GST")]
    public Decimal GstApplicableAmount { get; set; }

    [Display(Name = "Amount applicable for TDS")]
    public Decimal TdsApplicableAmount { get; set; }

    [Display(Name = "TDS Section")]
    [RequiredIf("EnableTds==true", ErrorMessage = "Please select TDS Section")]
    public string TdsAccountId { get; set; }

    [Display(Name = "TDS Rate(%)")]
    [Range(0, 100, ErrorMessage = "TDS Rate must be between 0 to 100")]
    public Decimal TdsRate { get; set; }

    [Display(Name = "TDS Amount")]
    public Decimal TdsAmount { get; set; }

    [Required(ErrorMessage = "Please enter PAN No.")]
    [PanNoAnnotation]
    [Display(Name = "PAN No.")]
    public string PanNo { get; set; }

    [Display(Name = "Sub Total")]
    public Decimal SubTotal { get; set; }

    [Display(Name = "GST Rate(%)")]
    public Decimal GstRate { get; set; }

    public byte GstTypeId { get; set; }

    public Decimal TaxTotal { get; set; }

    [Display(Name = "Grand Total")]
    [Range(1.0, 9999999999.0, ErrorMessage = "Grand Total must be greater than 0")]
    public Decimal GrandTotal { get; set; }
  }
}
