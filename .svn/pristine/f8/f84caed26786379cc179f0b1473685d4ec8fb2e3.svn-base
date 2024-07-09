//  
// Type: CodeLock.Models.MasterFlight
//  
//  
//  

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CodeLock.Models
{
  public class MasterFlight : BaseModel
  {
    public short FlightId { get; set; }

    [Required(ErrorMessage = "Please enter Flight No")]
    [StringLength(25, ErrorMessage = "Flight No must be minimum 2 and maximum 25 character long", MinimumLength = 2)]
    [Remote("IsFlightNoAvailable", "Flight", AdditionalFields = "FlightId,_FlightIdToken", ErrorMessage = "Flight No already exists.", HttpMethod = "POST")]
    [Display(Name = "Flight No")]
    public string FlightNo { get; set; }

    [Display(Name = "Airline")]
    [Required(ErrorMessage = "Please select Airline")]
    public byte AirlineId { get; set; }

    public string Airline { get; set; }

    [Display(Name = "Is N Route")]
    public bool IsNRoute { get; set; }

    [Display(Name = "From Airport")]
    public byte FromAirportId { get; set; }

    [Display(Name = "From Airport")]
    [Required(ErrorMessage = "Please enter From Airport")]
    public string FromAirport { get; set; }

    [Display(Name = "To Airport")]
    public byte ToAirportId { get; set; }

    [Display(Name = "To Airport")]
    [Required(ErrorMessage = "Please enter To Airport")]
    public string ToAirport { get; set; }

    public MasterGeneral[] Day { get; set; }

    public List<FlightDetail> Details { get; set; }
  }
}
