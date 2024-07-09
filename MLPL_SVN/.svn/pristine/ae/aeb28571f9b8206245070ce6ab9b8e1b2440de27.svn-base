//  
// Type: CodeLock.Models.ExpectedDriverAdvanceDetails
//  
//  
//  

using System;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class ExpectedDriverAdvanceDetails : BaseModel
  {
    public short LocationId { get; set; }

    [Display(Name = "Location")]
    [Required(ErrorMessage = "Please Location")]
    public string LocationCode { get; set; }

    [Required(ErrorMessage = "Please enter Advance Amount")]
    [Range(0.001, 10000000.0, ErrorMessage = "Please enter Advance Amount")]
    [Display(Name = "Advance Amount")]
    public Decimal AdvanceAmount { get; set; }

    public Decimal PaidAmount { get; set; }
  }
}
