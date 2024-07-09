//  
// Type: CodeLock.Models.MasterRole
//  
//  
//  

using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CodeLock.Models
{
  public class MasterRole : BaseModel
  {
    public byte RoleId { get; set; }

    [Remote("IsRoleNameAvailable", "Role", AdditionalFields = "RoleId,_RoleIdToken", ErrorMessage = "Role Name already exists.", HttpMethod = "POST")]
    [Display(Name = "Role Name")]
    [StringLength(50, ErrorMessage = "Role Name must be minimum 2 and maximum 50 character long", MinimumLength = 2)]
    [Required(ErrorMessage = "Please enter Role Name")]
    public string RoleName { get; set; }
  }
}
