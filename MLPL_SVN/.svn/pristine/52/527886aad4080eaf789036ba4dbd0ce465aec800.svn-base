//  
// Type: CodeLock.Models.StockReport
//  
//  
//  

using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class StockReport
  {
    [Display(Name = "Company")]
    public string CompanyId { get; set; }

    [Display(Name = "Location Type")]
    public short FromLocationTypeId { get; set; }

    [Display(Name = "From Location")]
    public short FromLocationId { get; set; }

    [Display(Name = "Destination Location")]
    public short ToLocationId { get; set; }

    [Display(Name = "Date Type")]
    public short DateTypeId { get; set; }

    [Display(Name = "Paybas")]
    [Required(ErrorMessage = "Please select Paybas")]
    public string PaybasId { get; set; }

    [Display(Name = "Stock Type")]
    [Required(ErrorMessage = "Please select Stock Type")]
    public string StockTypeId { get; set; }

    [Display(Name = "Tranport Mode")]
    public string TransportModeId { get; set; }

    [Display(Name = "Service Type")]
    public string ServiceTypeId { get; set; }

    [Display(Name = "Business Type")]
    public string BusinessTypeId { get; set; }

    [Display(Name = "Report Type")]
    public bool ReportType { get; set; }

    [Display(Name = "Format Type")]
    public bool FormatType { get; set; }

    [Display(Name = "Suffix")]
    public bool IsSuffix { get; set; }
  }
}
