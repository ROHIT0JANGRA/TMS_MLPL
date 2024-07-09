//  
// Type: CodeLock.Models.LocationWarehouseMapping
//  
//  
//  

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class LocationWarehouseMapping
  {
    [Display(Name = "Location Name")]
    [Required(ErrorMessage = "Please select Location Name")]
    public short LocationId { get; set; }

    public List<Warehouse> WarehouseList { get; set; }

    [Required(ErrorMessage = "Please select Warehouse Details")]
    public virtual Warehouse Warehouse { get; set; }
  }
}
