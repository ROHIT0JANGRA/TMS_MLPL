//  
// Type: CodeLock.Models.Pfm
//  
//  
//  

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class Pfm : BaseModel
  {
    public Pfm()
    {
      this.Details = new List<PfmDetails>();
      this.ManualPfmNo = "NA";
    }

    public List<PfmDetails> Details { get; set; }

    public long PfmId { get; set; }

    [Display(Name = "PFM No")]
    public string PfmNo { get; set; }

    [Display(Name = "PFM Date Time")]
    public DateTime PfmDateTime { get; set; }

    public DateTime PfmDate { get; set; }

        [Display(Name = "Manual No")]
    [Required(ErrorMessage = "Please enter Manual No")]
    public string ManualPfmNo { get; set; }

    public short LocationId { get; set; }

    public string LocationCode { get; set; }

    [Display(Name = "Forward To")]
    public bool ForwardType { get; set; }

    public string ForwardTypeName { get; set; }

    [Display(Name = "Location/Customer")]
    [Required(ErrorMessage = "Please enter Location/Customer")]
    public string ForwardTo { get; set; }

    public short ForwardToId { get; set; }

    public string ForwardFrom { get; set; }

    [Required(ErrorMessage = "Please enter Courier Name")]
    [Display(Name = "Courier Name")]
    public string CourierName { get; set; }

    [Display(Name = "Way Bill No")]
    [Required(ErrorMessage = "Please enter Way Bill No")]
    public string WayBillNo { get; set; }

    [Display(Name = "Way Bill Date")]
    public DateTime WayBillDate { get; set; }

    [Display(Name = "Is Acknowledged")]
    public bool IsAcknowledge { get; set; }

    [Display(Name = "Acknowledge Date")]
    public DateTime? AcknowledgeDate { get; set; }

    public bool IsCancel { get; set; }

    public DateTime? CancelDate { get; set; }

    public string CancelReason { get; set; }

    [Required(ErrorMessage = "Please enter Received By")]
    [Display(Name = "Received By")]
    public string ReceivedBy { get; set; }
  }
}
