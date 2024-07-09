//  
// Type: CodeLock.Models.MasterUnitTemperature
//  
//  
//  

using System;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class MasterUnitTemperature : BaseModel
  {
    public short UnitId { get; set; }

    [Display(Name = "Product Name")]
    [Required(ErrorMessage = "Please Select Product")]
    public short ProductId { get; set; }

    public string ProductCode { get; set; }

    public string ProductName { get; set; }

    [Display(Name = "Model Number")]
    [Required(ErrorMessage = "Please Enter Model Number")]
    public string ModelNumber { get; set; }

    [Required(ErrorMessage = "Please Enter Model Serial Number")]
    [Display(Name = "Model Serial Number")]
    public string ModelSerialNumber { get; set; }

    [Display(Name = "Minimum Temperature")]
    [Required(ErrorMessage = "Please Enter Minimum Temperature")]
    public Decimal MinimumTemperature { get; set; }

    [Display(Name = "Maximum Temperature")]
    [Required(ErrorMessage = "Please Enter Maximum Temperature")]
    public Decimal MaximumTemperature { get; set; }

    [Display(Name = "Standard Temperature")]
    [Required(ErrorMessage = "Please Enter Standard Temperature")]
    public Decimal StandardTemperature { get; set; }

    [Required(ErrorMessage = "Please Enter Remarks")]
    [Display(Name = "Remarks")]
    public string Remarks { get; set; }
  }
}
