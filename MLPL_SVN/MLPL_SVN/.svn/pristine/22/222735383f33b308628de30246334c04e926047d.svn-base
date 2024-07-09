//  
// Type: CodeLock.Models.MasterRouteCityWise
//  
//  
//  

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class MasterRouteCityWise : BaseModel
  {
    public MasterRouteCityWise()
    {
      this.RouteDetailList = new List<MasterRouteCityWiseDetail>();
    }

    public short RouteId { get; set; }

    [Required(ErrorMessage = "Route Name cannot be blank")]
    [Display(Name = "Route Name")]
    public string RouteName { get; set; }

    [Display(Name = "Route Mode")]
    [Required(ErrorMessage = "Please select Route Mode")]
    public byte TransportModeId { get; set; }

    [Display(Name = "Route Category")]
    [Required(ErrorMessage = "Please select Route Category")]
    public byte RouteCategoryIsLongHaul { get; set; }

    [Display(Name = "Departure Time")]
    public TimeSpan DepartureTime { get; set; }

    [Display(Name = "Controlling City")]
    [Required(ErrorMessage = "Please select Controlling City")]
    public string CityName { get; set; }

    public int ControlCityId { get; set; }

    [Display(Name = "Dist.(Km) / Transit (HRS)")]
    public short Dist { get; set; }

    public string Transit { get; set; }

    [Display(Name = "Enter No. Of Rows")]
    public short NumberOfRows { get; set; }

    public string TransportMode { get; set; }

    public string Category { get; set; }

    public int? FromCityId { get; set; }

    public int? ToCityId { get; set; }

    public byte TotalTransitTimeHour { get; set; }

    public byte TotalTransitTimeMin { get; set; }

    [Display(Name = "Driver Advance")]
    public Decimal DriverAdvanceAmount { get; set; }

    [Display(Name = "Fuel Quantity")]
    public Decimal FuelQuantity { get; set; }

    [Display(Name = "Is Reverse")]
    public bool IsReverse { get; set; }
    public List<MasterRouteCityWiseDetail> RouteDetailList { get; set; }
  }
}
