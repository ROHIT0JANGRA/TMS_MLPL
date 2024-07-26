//  
// Type: CodeLock.Models.MasterUserWarehouseMapping
//  
//  
//  

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class MasterUserWarehouseMapping : Base
  {
    [Display(Name = "User")]
    [Required(ErrorMessage = "Please select User")]
    public short UserId { get; set; }

    [Display(Name = "User Name")]
    public string UserName { get; set; }

    [Display(Name = "Warehouse Name")]
    public string WarehouseName { get; set; }

    [Display(Name = "")]
    public short DefaultWarehouseId { get; set; }

    [Display(Name = "Warehouse")]
    public List<MasterUserWarehouseMapping> WarehouseList { get; set; }

    public bool IsDefault { get; set; }
    }
}
