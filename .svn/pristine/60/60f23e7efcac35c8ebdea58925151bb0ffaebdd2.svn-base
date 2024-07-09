//  
// Type: CodeLock.Models.MasterHsn
//  
//  
//  

using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CodeLock.Models
{
  public class MasterHsn : BaseModel
  {
    public byte HsnId { get; set; }

    [Remote("IsHsnCodeAvailable", "Hsn", AdditionalFields = "HsnId,_HsnIdToken", ErrorMessage = "HSN Code already exists.", HttpMethod = "POST")]
    [Display(Name = "HSN Code")]
    [StringLength(25, ErrorMessage = "HSN Code must be minimum 2 and maximum 25 character long", MinimumLength = 2)]
    [Required(ErrorMessage = "Please enter HSN Code")]
    public string HsnCode { get; set; }

    [Required(ErrorMessage = "Please enter HSN Name")]
    [Display(Name = "HSN Name")]
    [StringLength(100, ErrorMessage = "HSN Name must be minimum 2 and maximum 100 character long", MinimumLength = 2)]
    [Remote("IsHsnNameAvailable", "Hsn", AdditionalFields = "HsnId,_HsnIdToken", ErrorMessage = "HSN Name already exists.", HttpMethod = "POST")]
    public string HsnName { get; set; }
  }
}
