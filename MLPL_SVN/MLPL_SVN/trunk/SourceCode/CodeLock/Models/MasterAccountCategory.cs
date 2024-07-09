//  
// Type: CodeLock.Models.MasterAccountCategory
//  
//  
//  

using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CodeLock.Models
{
  public class MasterAccountCategory : BaseModel
  {
    public byte AccountCategoryId { get; set; }

    [Required(ErrorMessage = "Please enter Category Name")]
    [Remote("IsAccountCategoryNameAvailable", "AccountCategory", AdditionalFields = "AccountCategoryId,_AccountCategoryIdToken", ErrorMessage = "Account Category Name already exists.", HttpMethod = "POST")]
    [NameAnnotation]
    [Display(Name = "Account Category Name")]
    [StringLength(25, ErrorMessage = "Account Category Name must be minimum 2 and maximum 25 character long", MinimumLength = 2)]
    public string CategoryName { get; set; }

    [Display(Name = "Is Main")]
    public bool IsMain { get; set; }
  }
}
