//  
// Type: CodeLock.Models.MasterUserCompanyMapping
//  
//  
//  

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class MasterUserCompanyMapping : Base
  {
    [Required(ErrorMessage = "Please select User")]
    [Display(Name = "User")]
    public short UserId { get; set; }

    [Display(Name = "User Name")]
    public string UserName { get; set; }

    [Display(Name = "Company Name")]
    public string CompanyName { get; set; }

    [Display(Name = "Default Company")]
    public byte DefaultCompanyId { get; set; }

    public bool IsDefault { get; set; }

    [Display(Name = "Company")]
    public List<MasterUserCompanyMapping> CompanyList { get; set; }
  }
}
