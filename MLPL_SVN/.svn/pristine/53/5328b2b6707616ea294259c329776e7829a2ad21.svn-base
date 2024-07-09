//  
// Type: CodeLock.Models.MasterSkuLocationMapping
//  
//  
//  

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class MasterSkuLocationMapping : BaseModel
  {
    [Display(Name = "Sku Name")]
    [Required(ErrorMessage = "Please Select Sku Name")]
    public byte SkuId { get; set; }

    public short LocationId { get; set; }

    [Display(Name = "Location")]
    public string LocationCode { get; set; }

    public List<MasterSkuLocationMapping> LocationList { get; set; }
  }
}
