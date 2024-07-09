//  
// Type: CodeLock.Models.MasterRoute
//  
//  
//  

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class MasterRoute : BaseModel
  {
    public MasterRoute()
    {
      this.RouteDetailList = new List<MasterRouteDetail>();
    }

    [Display(Name = "Route Code")]
    public short RouteId { get; set; }

    [Required(ErrorMessage = "Route Name cannot be blank")]
    [Display(Name = "Route Name")]
    public string RouteName { get; set; }

    [Required(ErrorMessage = "Please select Route Mode")]
    [Display(Name = "Route Mode")]
    public byte TransportModeId { get; set; }

    [Required(ErrorMessage = "Please select Route Category")]
    [Display(Name = "Route Category")]
    public byte RouteCategoryIsLongHaul { get; set; }

    [Display(Name = "Departure Time")]
    public DateTime DepartureTime { get; set; }

    [Required(ErrorMessage = "Please select Controlling Location")]
    [Display(Name = "Controlling Location")]
    public string LocationCode { get; set; }

    public short ControlLocationId { get; set; }

    [Display(Name = "Dist.(Km) / Transit (HRS)")]
    public short Dist { get; set; }

    public string Transit { get; set; }

    [Display(Name = "Enter No. Of Rows")]
    public short NumberOfRows { get; set; }

    public string TransportMode { get; set; }

    public string Category { get; set; }

    public short OriginLocationId { get; set; }

    public short DestinationLocationId { get; set; }

    public bool IsUseRouteContractAmount { get; set; }

    [Range(1.0, 9999999999.0, ErrorMessage = "Please enter From Amount must be greater then 0")]
    [Required(ErrorMessage = "Please enter From Amount")]
    [Display(Name = "From Amount")]
    public Decimal FromAmount { get; set; }

    [Range(1.0, 9999999999.0, ErrorMessage = "Please enter To Amount must be greater then 0")]
    [Required(ErrorMessage = "Please enter To Amount")]
    [Display(Name = "To Amount")]
    public Decimal ToAmount { get; set; }

    public List<MasterRouteDetail> RouteDetailList { get; set; }
  }
}
