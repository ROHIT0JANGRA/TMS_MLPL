//  
// Type: CodeLock.Models.MasterJobOrderWorkGroup
//  
//  
//  

using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CodeLock.Models
{
  public class MasterJobOrderWorkGroup : BaseModel
  {
    public byte WorkGroupId { get; set; }

    [Remote("IsWorkGroupAvailable", "JobOrderWorkGroup", AdditionalFields = "WorkGroupId,_WorkGroupIdToken", ErrorMessage = "Work Group already exists.", HttpMethod = "POST")]
    [Display(Name = "Work Group")]
    [StringLength(100, ErrorMessage = "Work Group must be minimum 2 and maximum 100 character long", MinimumLength = 2)]
    [Required(ErrorMessage = "Please enter Work Group")]
    public string WorkGroup { get; set; }
  }
}
