//  
// Type: CodeLock.Models.MasterAccountOpening
//  
//  
//  

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class MasterAccountOpening : BaseModel
  {
    public bool IsLocationWise { get; set; }

    [Display(Name = "Location Code")]
    public short CodeId { get; set; }

    [Required(ErrorMessage = "Please enter Location")]
    public string Code { get; set; }

    [Display(Name = "Account Category")]
    [Required(ErrorMessage = "Please select Account Category")]
    public byte AccountCategoryId { get; set; }

    [Display(Name = "Account")]
    public short AccountId { get; set; }

    [Display(Name = "Location")]
    public short LocationId { get; set; }

    public List<AccountOpeningDetail> Details { get; set; }
  }
}
