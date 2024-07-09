//  
// Type: CodeLock.Models.SparePartDetail
//  
//  
//  

using ExpressiveAnnotations.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class SparePartDetail
  {
    [Required(ErrorMessage = "Please select SKU")]
    public byte SkuId { get; set; }

    public string SkuName { get; set; }

    public byte TaskTypeId { get; set; }

    public string TaskType { get; set; }

    [AssertThat("0 < RequestedQuantity", ErrorMessage = "Requested Quantity must be greater than 0")]
    [Required(ErrorMessage = "Please enter Requested Quantity")]
    public int RequestedQuantity { get; set; }

    public Decimal CostPerUnit { get; set; }

    public Decimal Cost { get; set; }

    [Required(ErrorMessage = "Please enter Remarks")]
    public string Remarks { get; set; }

    [AssertThat("0 < ActualQuantity", ErrorMessage = "Actual Quantity must be greater than 0")]
    public int ActualQuantity { get; set; }

    public Decimal ActualCostPerUnit { get; set; }

    public Decimal ActualCost { get; set; }
  }
}
