//  
// Type: CodeLock.Models.MasterGeneral
//  
//  
//  

using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CodeLock.Models
{
  public class MasterGeneral : BaseModel
  {
    [Required(ErrorMessage = "Please select Code Type")]
    [Display(Name = "Code Type")]
    public short CodeTypeId { get; set; }

    public short CodeId { get; set; }

    [Remote("IsGeneralNameAvailable", "General", AdditionalFields = "CodeTypeId,CodeId,_CodeIdToken", ErrorMessage = "Already exists.", HttpMethod = "POST")]
    [Display(Name = "Code Description")]
    [StringLength(50, ErrorMessage = "Code Description must be minimum 2 and maximum 50 character long", MinimumLength = 2)]
    [Required(ErrorMessage = "Please enter Code Description")]
    public string CodeDescription { get; set; }

    [Display(Name = "Code Type")]
    public string CodeType { get; set; }

    [Display(Name = "Used In")]
    public string UsedIn { get; set; }
  }
    public class CodeTypeByName
    {
        public short CodeTypeId { get; set; }
        public byte CodeId { get; set; }
        public string CodeDescription { get; set; }
    }
}
