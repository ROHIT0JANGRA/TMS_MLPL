//  
// Type: CodeLock.Models.VendorOutstanding
//  
//  
//  

using System;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class VendorOutstanding
  {
    [Display(Name = "Company")]
    public string CompanyId { get; set; }

    [Display(Name = "Report Type")]
    public byte ReportType { get; set; }

    [Display(Name = "Vendor")]
    public string PartyCode { get; set; }

    public string PartyName { get; set; }

    public short PartyId { get; set; }

    [Display(Name = "Location")]
    public short LocationId { get; set; }
    public bool IsIndividual { get; set; }

        [Display(Name = "Bill Type")]
    public byte BillType { get; set; }

    [Display(Name = "As On Date")]
    public DateTime AsOnDate { get; set; }
  }
}
