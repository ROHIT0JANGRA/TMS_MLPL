//  
// Type: CodeLock.Models.MasterHolidayDayWise
//  
//  
//  

using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class MasterHolidayDayWise : BaseModel
  {
    [Display(Name = "Holiday Day")]
    public MasterGeneral[] DayOfHoliday { get; set; }
  }
}
