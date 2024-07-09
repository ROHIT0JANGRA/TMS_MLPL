//  
// Type: CodeLock.Models.PutAway
//  
//  
//  

using ExpressiveAnnotations.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class PutAway : BaseModel
  {
    public PutAway()
    {
      this.PutAwayNo = "";
      this.PutAwayGrnCriteriaDetails = new List<PutAwayGrnCriteriaDetail>();
      this.Details = new List<PutAwayDetail>();
      this.BinDetails = new List<PutAwayBinDetail>();
    }

    public long PutAwayId { get; set; }

    [Display(Name = "Put Away No")]
    public string PutAwayNo { get; set; }

    public DateTime PutAwayDate { get; set; }

    public TimeSpan PutAwayTime { get; set; }

    [Display(Name = "Put Away Date Time")]
    public DateTime? PutAwayDateTime { get; set; }

    [Display(Name = "Labour")]
    [Required(ErrorMessage = "Please enter Labour")]
    public string LabourName { get; set; }

    public short LabourId { get; set; }

    [AssertThat("GrnCriteriaCount > 0", ErrorMessage = "Please select any one GRN")]
    public short GrnCriteriaCount { get; set; }

    public bool IsCancel { get; set; }

    public DateTime? CancelDate { get; set; }

    public string CancelReason { get; set; }

    public List<PutAwayGrnCriteriaDetail> PutAwayGrnCriteriaDetails { get; set; }

    [Required(ErrorMessage = "Please select atleast one record")]
    public List<PutAwayDetail> Details { get; set; }

    public List<PutAwayBinDetail> BinDetails { get; set; }
  }
}
