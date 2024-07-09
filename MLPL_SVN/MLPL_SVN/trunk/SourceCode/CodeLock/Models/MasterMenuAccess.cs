//  
// Type: CodeLock.Models.MasterMenuAccess
//  
//  
//  

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class MasterMenuAccess : BaseModel
  {
    [Required(ErrorMessage = "Please select Role")]
    [Display(Name = "Role")]
    public byte RoleId { get; set; }

    public string RoleName { get; set; }

    public List<MasterMenu> MasterMenuList { get; set; }
  }
}
