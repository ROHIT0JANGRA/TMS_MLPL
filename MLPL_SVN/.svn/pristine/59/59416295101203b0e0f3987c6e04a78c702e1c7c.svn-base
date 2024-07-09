//  
// Type: CodeLock.Models.Repacking
//  
//  
//  

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class Repacking : BaseModel
  {
    public Repacking()
    {
      this.Details = new List<RepackingDetail>();
    }

    public long RepackingId { get; set; }

    [Display(Name = "Repacking No")]
    public string RepackingNo { get; set; }

    public DateTime RepackingDate { get; set; }

    public TimeSpan RepackingTime { get; set; }

    [Display(Name = "Repacking Date Time")]
    public DateTime? RepackingDateTime { get; set; }

    public List<RepackingDetail> Details { get; set; }
  }
}
