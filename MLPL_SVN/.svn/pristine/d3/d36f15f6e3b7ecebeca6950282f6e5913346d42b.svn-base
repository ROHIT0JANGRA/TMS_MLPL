//  
// Type: CodeLock.Models.DocketBookingChallan
//  
//  
//  

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class DocketBookingChallan : BaseModel
  {
    public long ChallanId { get; set; }

    public short LocationId { get; set; }

    [Display(Name = "Manual Challan No")]
    [Required(ErrorMessage = "Please enter Manual Challan No")]
    public string ManualChallanNo { get; set; }

    [Display(Name = "Vendor Code")]
    public short? VendorId { get; set; }

    [Required(ErrorMessage = "Please enter Vendor Code")]
    public string VendorCode { get; set; }

    public string VendorName { get; set; }

    [Display(Name = "Challan Date")]
    public DateTime ChallanDate { get; set; }

    public List<DocketBookingChallanDetail> Details { get; set; }
  }
}
