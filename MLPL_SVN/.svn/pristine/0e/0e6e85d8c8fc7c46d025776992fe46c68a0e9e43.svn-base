//  
// Type: CodeLock.Models.MasterVehicleCapacityRate
//  
//  
//  

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class MasterVehicleCapacityRate : BaseModel
  {
    public MasterVehicleCapacityRate()
    {
      this.Details = new List<VehicleCapacityRateDetail>();
    }

    public short VendorId { get; set; }

    [Display(Name = "Vendor")]
    [Required(ErrorMessage = "Please enter Vendor")]
    public string VendorCode { get; set; }

    public string VendorName { get; set; }

    [Display(Name = "Start Date")]
    [DataType(DataType.DateTime)]
    [Required(ErrorMessage = "Please select Start Date")]
    public DateTime StartDate { get; set; }

    [Required(ErrorMessage = "Please select End Date")]
    [DataType(DataType.DateTime)]
    [Display(Name = "End Date")]
    public DateTime EndDate { get; set; }

    [Required(ErrorMessage = "Please enter Email Id")]
    [Display(Name = "Email Id")]
    public string EmailId { get; set; }

    [Required(ErrorMessage = "Please enter Content For Auto Email")]
    [Display(Name = "Content For Auto Mail")]
    public string ContentForAutoMail { get; set; }

    public List<VehicleCapacityRateDetail> Details { get; set; }
  }
}
