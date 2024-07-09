//  
// Type: CodeLock.Models.MasterAccountGroup
//  
//  
//  

using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CodeLock.Models
{
  public class MasterAccountGroup : BaseModel
  {
    [Display(Name = "Account GroupId")]
    public short AccountGroupId { get; set; }

    [Required(ErrorMessage = "Please select Account Category")]
    [Display(Name = "Account Category")]
    public byte AccountCategoryId { get; set; }

    [Required(ErrorMessage = "Please select Parent Group")]
    [Display(Name = "Parent Group")]
    public short? ParentGroupId { get; set; }

    [Display(Name = "Group Code")]
    public string GroupCode { get; set; }

    [Required(ErrorMessage = "Please select Group Level")]
    [Display(Name = "Group Level")]
    public byte GroupLevel { get; set; }

    [Required(ErrorMessage = "Please enter Manual GroupCode")]
    [StringLength(10, ErrorMessage = "Manual GroupCode must be minimum 6 and maximum 10 character long", MinimumLength = 6)]
    [Display(Name = "Manual Group Code")]
    [Remote("IsGroupCodeAvailable", "AccountGroup", AdditionalFields = "AccountGroupId,_AccountGroupIdToken", ErrorMessage = "Manual GroupCode already exists", HttpMethod = "POST")]
    public string ManualGroupCode { get; set; }

    [StringLength(50, ErrorMessage = "Group Name must be minimum 2 and maximum 50 character long", MinimumLength = 2)]
    [Display(Name = "Group Name")]
    [Remote("IsGroupNameAvailable", "AccountGroup", AdditionalFields = "AccountGroupId,_AccountGroupIdToken", ErrorMessage = "Group Name already exists", HttpMethod = "POST")]
    [Required(ErrorMessage = "Please enter Group Name")]
    public string GroupName { get; set; }

    [Display(Name = "Category Name")]
    public string CategoryName { get; set; }

    [Display(Name = "Parent Group Name")]
    public string ParentGroupName { get; set; }
  }
}
