//  
// Type: CodeLock.Models.ProductDetail
//  
//  
//  

using System;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class ProductDetail
  {
    [Display(Name = "Product")]
    public string ProductCode { get; set; }

    public string ProductName { get; set; }

    public int ProductId { get; set; }

    [Display(Name = "UOM")]
    public string Uom { get; set; }

    [Range(1.0, 9999999999.0, ErrorMessage = "Please enter Quantity")]
    [Display(Name = "Quantity")]
    public Decimal Quantity { get; set; }

    [Display(Name = "Unit Price")]
    public Decimal UnitPrice { get; set; }
  }
}
