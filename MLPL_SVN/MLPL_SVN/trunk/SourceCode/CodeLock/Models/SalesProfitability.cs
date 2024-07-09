//  
// Type: CodeLock.Models.SalesProfitability
//  
//  
//  

using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class SalesProfitability
  {
    [Display(Name = "Location")]
    public short LocationId { get; set; }

    [Display(Name = "Paybas")]
    public byte PaybasId { get; set; }

    [Display(Name = "Tranport Mode")]
    public byte TransportModeId { get; set; }

    [Display(Name = "Service Type")]
    public byte ServiceTypeId { get; set; }

    [Display(Name = "Business Type")]
    public byte BusinessTypeId { get; set; }

    [Display(Name = "Customer")]
    public short CustomerId { get; set; }

    public string CustomerCode { get; set; }

    public string CustomerName { get; set; }

    [Display(Name = "Document No")]
    public string DocumentNo { get; set; }

    public bool FormatType { get; set; }
  }
}
