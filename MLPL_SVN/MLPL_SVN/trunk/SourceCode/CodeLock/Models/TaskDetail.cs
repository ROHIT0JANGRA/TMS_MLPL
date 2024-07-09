//  
// Type: CodeLock.Models.TaskDetail
//  
//  
//  

using ExpressiveAnnotations.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class TaskDetail
  {
    [Required(ErrorMessage = "Please select Work Group")]
    public byte WorkGroupId { get; set; }

    public string WorkGroup { get; set; }

    [Required(ErrorMessage = "Please select Task Type")]
    public byte TaskTypeId { get; set; }

    public string TaskType { get; set; }

    [Required(ErrorMessage = "Please select Task Description")]
    public short TaskId { get; set; }

    public short Task { get; set; }

    public string TaskDes { get; set; }

    [AssertThat("0 < EstimatedLabourHours", ErrorMessage = "Labour Hours must be greater than 0")]
    [Required(ErrorMessage = "Please enter Labour Hours")]
    public byte EstimatedLabourHours { get; set; }

    public byte LabourHours { get; set; }

    [AssertThat("0 < EstimatedLabourCost", ErrorMessage = "Labour Cost must be greater than 0")]
    [Required(ErrorMessage = "Please enter Labour Cost")]
    public Decimal EstimatedLabourCost { get; set; }

    public Decimal LabourCost { get; set; }

    [Required(ErrorMessage = "Please enter Remarks")]
    public string Remarks { get; set; }

    public string Action { get; set; }

    [Required(ErrorMessage = "Please select AMC/Non-AMC")]
    public bool AmcType { get; set; }

    public Decimal ActualLabourCost { get; set; }
  }
}
