//  
// Type: CodeLock.Models.MasterTripCheckList
//  
//  
//  

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class MasterTripCheckList : BaseModel
  {
    public MasterTripCheckList()
    {
      this.DocumentList = new List<MasterTripCheckListDocument>();
      this.SavedDocuments = "";
      this.Documents = "";
    }

    public byte CheckListId { get; set; }

    [StringLength(50, ErrorMessage = "Description must be minimum 2 and maximum 50 character long", MinimumLength = 2)]
    [Display(Name = "Description")]
    [Required(ErrorMessage = "Please enter Description")]
    public string Description { get; set; }

    [Display(Name = "Documents")]
    [Required(ErrorMessage = "Please select Documents")]
    public string Documents { get; set; }

    [Display(Name = "Documents")]
    public string SavedDocuments { get; set; }

    public string Category { get; set; }

    [Display(Name = "Category")]
    [Required(ErrorMessage = "Please select Category")]
    public byte CategoryId { get; set; }

    public List<MasterTripCheckListDocument> DocumentList { get; set; }
  }
}
