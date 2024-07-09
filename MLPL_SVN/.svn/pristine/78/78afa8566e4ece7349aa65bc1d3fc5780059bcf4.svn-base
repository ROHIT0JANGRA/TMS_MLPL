//  
// Type: CodeLock.Models.WorkDone
//  
//  
//  

using ExpressiveAnnotations.Attributes;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class WorkDone
  {
    [Display(Name = "Date Type")]
    public bool DateType { get; set; }

    [Display(Name = "Report Type")]
    public bool ReportType { get; set; }

    public short UserId { get; set; }

    [RequiredIf("ReportType == true", ErrorMessage = "Please enter User Code")]
    [Display(Name = "User Code")]
    public string UserCode { get; set; }
  }
}
