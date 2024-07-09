//  
// Type: CodeLock.Models.PurchaseOrderDetail
//  
//  
//  

using ExpressiveAnnotations.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class PurchaseOrderDetail
  {
    public long PoId { get; set; }

    public byte SkuId { get; set; }

    [Required(ErrorMessage = "Please enter Item")]
    public string SkuName { get; set; }

    [Display(Name = "Description")]
    [StringLength(200, ErrorMessage = "Description must be minimum 2 and maximum 200 character long", MinimumLength = 2)]
    [Required(ErrorMessage = "Please enter Description")]
    public string Description { get; set; }

    [Required(ErrorMessage = "Please enter Quantity")]
    [AssertThat("0 < Quantity", ErrorMessage = "Quantity must be greater than 0")]
    [Display(Name = "Quantity")]
    public int Quantity { get; set; }

    [AssertThat("0 < Rate", ErrorMessage = "Rate must be greater than 0")]
    [Required(ErrorMessage = "Please enter Rate")]
    [Display(Name = "Rate")]
    public Decimal Rate { get; set; }

    public Decimal DiscountPercentage { get; set; }

    public Decimal TaxPercentage { get; set; }

    public Decimal TotalAmount { get; set; }

    public int ReceivedQuantity { get; set; }

    public int PendingQuantity { get; set; }
  }
}
