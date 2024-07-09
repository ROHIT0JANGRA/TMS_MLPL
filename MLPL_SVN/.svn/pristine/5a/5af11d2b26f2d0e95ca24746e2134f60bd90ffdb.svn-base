//  
// Type: CodeLock.Models.ExpectedDriverAdvance
//  
//  
//  

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class ExpectedDriverAdvance
  {
    public ExpectedDriverAdvance()
    {
      this.Details = new List<ExpectedDriverAdvanceDetails>();
    }

    public byte CompanyId { get; set; }

    public long TripsheetId { get; set; }

    public byte searchBy { get; set; }

    [Display(Name = "Tripsheet No")]
    public string TripsheetNo { get; set; }

    [Display(Name = "Tripsheet Date")]
    public DateTime TripsheetDate { get; set; }

    [Display(Name = "Starting Location")]
    public string StartLocationCode { get; set; }

    [Display(Name = "End Location")]
    public string EndLocationCode { get; set; }

    [Display(Name = "From City")]
    public string FromCity { get; set; }

    [Display(Name = "To City")]
    public string ToCity { get; set; }

    [Display(Name = "Category")]
    public string Category { get; set; }

    [Display(Name = "Customer Code")]
    public string CustomerCode { get; set; }

    [Display(Name = "Vehicle No")]
    public string VehicleNo { get; set; }

    public List<ExpectedDriverAdvanceDetails> Details { get; set; }
  }
}
