using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class CompanyGstRegistration
  {
    public CompanyGstRegistration()
    {
      this.Details = new List<CompanyGstRegistrationDetail>();
    }

    public byte CompanyId { get; set; }

    [Required(ErrorMessage = "Please enter Company")]
    [Display(Name = "Company")]
    public string CompanyCode { get; set; }

    public List<CompanyGstRegistrationDetail> Details { get; set; }
  }
}
