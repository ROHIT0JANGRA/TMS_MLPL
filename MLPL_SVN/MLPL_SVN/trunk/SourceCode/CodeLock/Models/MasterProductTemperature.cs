//  
// Type: CodeLock.Models.MasterProductTemperature
//  
//  
//  

using System;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class MasterProductTemperature : BaseModel
  {
    [Display(Name = "Product Name")]
    [Required(ErrorMessage = "Please Select Product")]
    public short ProductId { get; set; }

    public string ProductCode { get; set; }

    public string ProductName { get; set; }

    [Display(Name = "Pre-Loaded Temperature")]
    [Required(ErrorMessage = "Please Enter Pre-Loaded Temperature")]
    public Decimal PreLoadedTemperature { get; set; }

    [Display(Name = "Minimum Temperature")]
    [Required(ErrorMessage = "Please Enter Minimum Temperature")]
    public Decimal MinimumTemperature { get; set; }

    [Display(Name = "Maximum Temperature")]
    [Required(ErrorMessage = "Please Enter Maximum Temperature")]
    public Decimal MaximumTemperature { get; set; }

    [Display(Name = "Standard Temperature")]
    [Required(ErrorMessage = "Please Enter Standard Temperature")]
    public Decimal StandardTemperature { get; set; }

    [Display(Name = "Minimum Humidity")]
    [Required(ErrorMessage = "Please Enter Minimum Humidity")]
    public Decimal MinimumHumidity { get; set; }

    [Required(ErrorMessage = "Please Enter Maximum Humidity")]
    [Display(Name = "Maximum Humidity")]
    public Decimal MaximumHumidity { get; set; }

    [Required(ErrorMessage = "Please Enter Standard Humidity")]
    [Display(Name = "Standard Humidity")]
    public Decimal StandardHumidity { get; set; }
  }
}
