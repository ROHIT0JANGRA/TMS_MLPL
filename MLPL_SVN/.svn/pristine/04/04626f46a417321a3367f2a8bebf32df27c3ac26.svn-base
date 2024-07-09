//  
// Type: CodeLock.Models.MasterRoleBasedAccessRight
//  
//  
//  

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class MasterRoleBasedAccessRight : BaseModel
  {
    [Display(Name = "User")]
    public short UserId { get; set; }

    [Required(ErrorMessage = "Please enter User")]
    public string UserName { get; set; }

    [Display(Name = "Role")]
    [Required(ErrorMessage = "Please select Role")]
    public byte RoleId { get; set; }

    public List<MasterMenu> MasterMenuList { get; set; }
  }
}
