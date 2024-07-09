//  
// Type: CodeLock.Models.VendorGstRegistration
//  
//  
//  

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class VendorGstRegistration
  {
    public VendorGstRegistration()
    {
      this.Details = new List<VendorGstRegistrationDetail>();
    }

    public short VendorId { get; set; }

    [Display(Name = "Vendor")]
    [Required(ErrorMessage = "Please enter Vendor")]
    public string VendorCode { get; set; }

    public List<VendorGstRegistrationDetail> Details { get; set; }
  }
}
