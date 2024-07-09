//  
// Type: CodeLock.Models.PickRegister
//  
//  
//  

using System;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class PickRegister
  {
    [Display(Name = "Pick No")]
    public string PickNo { get; set; }

    public DateTime? PickDateTime { get; set; }

    public string LabourName { get; set; }

    public string OrderNo { get; set; }

    public string ProductCode { get; set; }

    public Decimal Quantity { get; set; }

    public string BinName { get; set; }

    public Decimal LocationQuantity { get; set; }
  }
}
