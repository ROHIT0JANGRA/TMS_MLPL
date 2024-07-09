using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CodeLock.Models
{
  public class MasterBinHierarchy : BaseModel
  {
    [Display(Name = "Warehouse Name")]
    [Required(ErrorMessage = "Please select Warehouse Name")]
    public new short WarehouseId { get; set; }

    [Display(Name = "Warehouse Name")]
    public string WarehouseName { get; set; }

    [Display(Name = "BinHierarchy Id")]
    public byte BinHierarchyId { get; set; }

    [Required(ErrorMessage = "Please enter Bin Hierarchy Name")]
    [StringLength(50, ErrorMessage = "Bin Hierarchy Name must be minimum 2 and maximum 50 character long", MinimumLength = 2)]
    [Remote("IsBinHierarchyNameAvailable", "BinHierarchy", AdditionalFields = "WarehouseId,BinHierarchyId,_BinHierarchyIdToken", ErrorMessage = "Bin Hierarchy Name already exists.", HttpMethod = "POST")]
    [Display(Name = "Bin Hierarchy Name")]
    public string BinHierarchyName { get; set; }
  }
}
