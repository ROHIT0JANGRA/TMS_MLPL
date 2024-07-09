//  
// Type: CodeLock.Models.MasterWarehouse
//  
//  
//  

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class MasterWarehouse : BaseModel
  {
    [Display(Name = "Location Name")]
    [Required(ErrorMessage = "Please select Location Name")]
    public short LocationId { get; set; }

    [Display(Name = "Location Code")]
    public string LocationCode { get; set; }

    [StringLength(50, ErrorMessage = "Warehouse Name must be minimum 2 and maximum 50 character long", MinimumLength = 2)]
    [Required(ErrorMessage = "Please enter Warehouse Name")]
    [Display(Name = "Warehouse Name")]
    public string WarehouseName { get; set; }

    [StringLength(100, ErrorMessage = "Description must be minimum 2 and maximum 100 character long", MinimumLength = 2)]
    [Display(Name = "Description")]
    [Required(ErrorMessage = "Please enter Description")]
    public string Description { get; set; }

    public List<Warehouse> WarehouseList { get; set; }
  }
}
