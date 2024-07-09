//  
// Type: CodeLock.Models.MasterLocationHierarchy
//  
//  
//  

using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CodeLock.Models
{
  public class MasterLocationHierarchy : BaseModel
  {
    public byte LocationHierarchyId { get; set; }

    [Remote("IsLocationHierarchyNameAvailable", "LocationHierarchy", AdditionalFields = "LocationHierarchyId,_LocationHierarchyIdToken", ErrorMessage = "Location Hierarchy Name already exists.", HttpMethod = "POST")]
    [Display(Name = "Location Hierarchy Name")]
    [Required(ErrorMessage = "Please enter Location Hierarchy Name")]
    [StringLength(50, ErrorMessage = "Location Hierarchy Name must be minimum 2 and maximum 50 character long", MinimumLength = 2)]
    public string LocationHierarchyName { get; set; }

    [Display(Name = "Location Rank")]
    public Decimal LocationRank { get; set; }
  }
}
