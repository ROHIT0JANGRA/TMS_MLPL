//  
// Type: CodeLock.Models.DocketFinalization
//  
//  
//  

using ExpressiveAnnotations.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class DocketFinalization
  {
    [Display(Name = "Finalization Date")]
    public DateTime FinalizationDate { get; set; }

    [Display(Name = "Finalize By Docket Date")]
    public bool FinalizeByDocketDate { get; set; }

    [RequiredIf("DocketNo == null", ErrorMessage = "Please enter Billing Party")]
    [Display(Name = "Billing Party")]
    public string CustomerCode { get; set; }

    public string CustomerName { get; set; }

    public string DocketNo { get; set; }

    public List<DocketFinalizationDetail> DocketDetails { get; set; }
  }
}
