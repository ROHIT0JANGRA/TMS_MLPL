using System;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class MasterHolidayDateWise : BaseModel
  {
    [Display(Name = "Holiday Location")]
    public string Holidaylocation { get; set; }

    public short HolidayId { get; set; }

    [Required(ErrorMessage = "Holiday Date is required")]
    [Display(Name = "Holiday Date")]
    public DateTime HolidayDate { get; set; }

    [Required(ErrorMessage = "Holiday Name is required")]
    [NameAnnotation]
    [Display(Name = "Holiday Name")]
    [StringLength(50, ErrorMessage = "Holiday Name must be minimum 2 and maximum 50 character long", MinimumLength = 2)]
    public string HolidayName { get; set; }

    public virtual MasterLocation MasterLocation { get; set; }
  }
}
