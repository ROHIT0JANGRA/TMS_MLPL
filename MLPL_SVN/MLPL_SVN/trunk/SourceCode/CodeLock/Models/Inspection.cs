//  
// Type: CodeLock.Models.Inspection
//  
//  
//  

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class Inspection : BaseModel
  {
    public long InspectionId { get; set; }

    [Display(Name = "Inspection No")]
    public string InspectionNo { get; set; }

    public DateTime InspectionDate { get; set; }

    public TimeSpan InspectionTime { get; set; }

    [Display(Name = "Inspection Date Time")]
    public DateTime? InspectionDateTime { get; set; }

    public List<InspectionDetail> Details { get; set; }
  }
}
