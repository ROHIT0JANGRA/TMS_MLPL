//  
// Type: CodeLock.Models.MasterJobOrderTask
//  
//  
//  

using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class MasterJobOrderTask : BaseModel
  {
    [Required(ErrorMessage = "Please select Work Group")]
    [Display(Name = "Work Group")]
    public byte WorkGroupId { get; set; }

    public string WorkGroup { get; set; }

    [Display(Name = "Task Type")]
    [Required(ErrorMessage = "Please select Task Type")]
    public byte TaskTypeId { get; set; }

    public string TaskType { get; set; }

    public short TaskId { get; set; }

    [StringLength(200, ErrorMessage = "Task Description must be minimum 2 and maximum 200 character long", MinimumLength = 2)]
    [Display(Name = "Task Description")]
    [Required(ErrorMessage = "Please enter Task Description")]
    public string Task { get; set; }

    [Display(Name = "Estimated Labour Hours")]
    [Required(ErrorMessage = "Please enter Estimated Labour Hours")]
    [Range(0.001, 255.0, ErrorMessage = "Please enter Estimated Labour Hours between 1 to 255")]
    public byte EstimatedLabourHours { get; set; }
  }
}
