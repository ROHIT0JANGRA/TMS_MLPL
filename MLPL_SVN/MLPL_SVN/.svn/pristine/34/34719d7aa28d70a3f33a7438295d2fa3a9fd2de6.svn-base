//  
// Type: CodeLock.Models.Dispatch
//  
//  
//  

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class Dispatch : BaseModel
  {
    public Dispatch()
    {
      this.Details = new List<DispatchDetail>();
    }

    public long DispatchId { get; set; }

    public long OrderId { get; set; }

    [Display(Name = "Order No")]
    public string OrderNo { get; set; }

    [Display(Name = "Order Date")]
    public DateTime OrderDate { get; set; }

    [Display(Name = "Invoice No")]
    public string InvoiceNo { get; set; }

    [Display(Name = "Invoice Date")]
    public DateTime InvoiceDate { get; set; }

    [Display(Name = "Dispatch No")]
    public string DispatchNo { get; set; }

    public DateTime DispatchDate { get; set; }

    public TimeSpan DispatchTime { get; set; }

    [Display(Name = "Dispatch Date Time")]
    public DateTime? DispatchDateTime { get; set; }

    [Required(ErrorMessage = "Please select atleast one record")]
    public List<DispatchDetail> Details { get; set; }
  }
}
