//  
// Type: CodeLock.Models.MasterCustomerGroup
//  
//  
//  

using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CodeLock.Models
{
  public class MasterCustomerGroup : BaseModel
  {
    public MasterCustomerGroup()
    {
      this.GroupCode = string.Empty;
    }

    [Display(Name = "Group Code")]
    public string GroupCode { get; set; }

    [Required(ErrorMessage = "Please enter Group Name")]
    [StringLength(50, ErrorMessage = "Group Name must be minimum 2 and maximum 50 character long", MinimumLength = 2)]
    [Remote("IsGroupNameAvailable", "CustomerGroup", AdditionalFields = "GroupCode,_GroupCodeToken", ErrorMessage = "Group Name already exists", HttpMethod = "POST")]
    [Display(Name = "Group Name")]
    public string GroupName { get; set; }
  }
}
