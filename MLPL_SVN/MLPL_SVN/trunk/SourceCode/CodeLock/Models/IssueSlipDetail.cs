//  
// Type: CodeLock.Models.IssueSlipDetail
//  
//  
//  

using System;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class IssueSlipDetail
  {
    public byte SkuId { get; set; }

    public string SkuName { get; set; }

    [Display(Name = "Description")]
    [Required(ErrorMessage = "Please enter Description")]
    [StringLength(200, ErrorMessage = "Description must be minimum 2 and maximum 200 character long", MinimumLength = 2)]
    public string Description { get; set; }

    public int StockQuantity { get; set; }

    public int RequiredQuantity { get; set; }

    public int IssuedQuantity { get; set; }

    public Decimal UnitPrice { get; set; }

    public Decimal TotalAmount { get; set; }
  }
}
