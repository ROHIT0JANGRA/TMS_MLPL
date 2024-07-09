//  
// Type: CodeLock.Models.Pick
//  
//  
//  

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class Pick : BaseModel
  {
    public Pick()
    {
      this.PickDetails = new List<PickDetail>();
    }

    public long PickId { get; set; }

    public long OrderId { get; set; }

    [Display(Name = "Order No")]
    public string OrderNo { get; set; }

    [Display(Name = "Order Date")]
    public DateTime OrderDate { get; set; }

    [Display(Name = "Invoice No")]
    public string InvoiceNo { get; set; }

    [Display(Name = "Invoice Date")]
    public DateTime InvoiceDate { get; set; }

    [Display(Name = "Pick No")]
    public string PickNo { get; set; }

    public DateTime PickDate { get; set; }

    public TimeSpan PickTime { get; set; }

    [Display(Name = "Pick Date Time")]
    public DateTime? PickDateTime { get; set; }

    public short? LaborId { get; set; }

    [Display(Name = "Labor Name")]
    public string LaborName { get; set; }

    public bool IsCancel { get; set; }

    public DateTime? CancelDate { get; set; }

    public string CancelReason { get; set; }

    public List<PickDetail> PickDetails { get; set; }

    public List<PickLocationDetail> PickLocationDetails { get; set; }
  }
}
