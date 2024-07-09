//  
// Type: CodeLock.Models.FlightDetail
//  
//  
//  

using ExpressiveAnnotations.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class FlightDetail
  {
    public FlightDetail()
    {
      this.FlightId = (short) 0;
      this.TransitId = (short) 0;
      this.DepartureTime = DateTime.Now;
      this.ArrivalTime = DateTime.Now;
      this.TransitDays = (short) 0;
      this.Days = "";
    }

    public short FlightId { get; set; }

    public short TransitId { get; set; }

    [Display(Name = "Departure Time")]
    [Required(ErrorMessage = "Please enter Departure Time")]
    public DateTime DepartureTime { get; set; }

    [Required(ErrorMessage = "Please enter Arrival Time")]
    [Display(Name = "Arrival Time")]
    public DateTime ArrivalTime { get; set; }

    [AssertThat("0 < TransitDays", ErrorMessage = "Please enter Transit Days greater than 0")]
    [Required(ErrorMessage = "Please enter Transit Days")]
    public short TransitDays { get; set; }

    public byte Day { get; set; }

    public string DayId { get; set; }

    [Required(ErrorMessage = "Please select Days")]
    public string Days { get; set; }

    public List<CodeLock.Models.FlightDay> FlightDayId { get; set; }

    public List<CodeLock.Models.FlightDay> FlightDay { get; set; }
  }
}
