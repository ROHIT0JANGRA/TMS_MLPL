//  
// Type: CodeLock.Models.MasterJobOrderTaskType
//  
//  
//  

using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CodeLock.Models
{
  public class MasterJobOrderTaskType : BaseModel
  {
    public byte TaskTypeId { get; set; }

    [Required(ErrorMessage = "Please enter Task Type")]
    [Remote("IsTaskTypeAvailable", "JobOrderTaskType", AdditionalFields = "TaskTypeId,_TaskTypeIdToken", ErrorMessage = "Task Type already exists.", HttpMethod = "POST")]
    [Display(Name = "Task Type")]
    [StringLength(100, ErrorMessage = "Task Type must be minimum 2 and maximum 100 character long", MinimumLength = 2)]
    public string TaskType { get; set; }

    public short AccountId { get; set; }

    [Display(Name = "Account Code")]
    [Required(ErrorMessage = "Please enter Account Code")]
    public string AccountCode { get; set; }
  }
}
