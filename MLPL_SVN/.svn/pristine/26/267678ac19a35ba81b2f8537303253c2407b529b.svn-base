//  
// Type: CodeLock.Models.Advice
//  
//  
//  

using System;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class Advice : BaseModel
  {
    public string FinYear { get; set; }

    public long AdviceId { get; set; }

    [Display(Name = "Advice No")]
    public string AdviceNo { get; set; }

    [Display(Name = "Advice Type")]
    public byte AdviceType { get; set; }

    [Display(Name = "Advice Date")]
    public DateTime AdviceDate { get; set; }

    [Display(Name = "Raised By")]
    public short LocationId { get; set; }

    public string LocationCode { get; set; }

    [Display(Name = "Raised On Branch")]
    public short RaisedLocationId { get; set; }

    [Required(ErrorMessage = "Please enter Branch")]
    public string RaisedLocationCode { get; set; }

    [Required(ErrorMessage = "Please enter Reason")]
    [StringLength(200, ErrorMessage = "Reason must be minimum 2 and maximum 200 character long", MinimumLength = 2)]
    [Display(Name = "Reason")]
    public string Reason { get; set; }

    [StringLength(200, ErrorMessage = "Enclosed Documents must be minimum 2 and maximum 200 character long", MinimumLength = 2)]
    [Display(Name = "Enclosed Documents")]
    public string DocumentName { get; set; }

    [Display(Name = "Payment Amount")]
    [Range(0.001, 10000000.0, ErrorMessage = "Please enter Payment Amount")]
    public Decimal Amount { get; set; }

    public Payment PaymentDetails { get; set; }
  }
}
