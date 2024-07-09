using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class CustomerGstRegistration : BaseModel
  {
    public CustomerGstRegistration()
    {
      this.Details = new List<CustomerGstRegistrationDetail>();
    }

    public short CustomerId { get; set; }

    [Required(ErrorMessage = "Please enter Customer")]
    [Display(Name = "Customer")]
    public string CustomerCode { get; set; }

    public string CustomerName { get; set; }

    [Display(Name = "Primary Billing Type")]
    public byte PrimaryBillingTypeId { get; set; }

    [Required(ErrorMessage = "Please select Primary Billing Preference Type")]
    [Display(Name = "Primary Billing Preference Type")]
    public byte PrimaryBillingPreferenceTypeId { get; set; }

    public List<CustomerGstRegistrationDetail> Details { get; set; }
  }
}
