//  
// Type: CodeLock.Models.FinanceSummary
//  
//  
//  

using System;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class FinanceSummary : BaseModel
  {
    public long DocumentId { get; set; }

    [Display(Name = "Document No")]
    public string DocumentNo { get; set; }

    [Display(Name = "Manual Document No")]
    public string ManualDocumentNo { get; set; }

    [Display(Name = "Document Date")]
    public DateTime DocumentDate { get; set; }

    [Display(Name = "Origin")]
    public string FromLocationCode { get; set; }

    [Display(Name = "Vehicle No")]
    public string VehicleNo { get; set; }
    public string ValidationMassage { get; set; }
  }
}
