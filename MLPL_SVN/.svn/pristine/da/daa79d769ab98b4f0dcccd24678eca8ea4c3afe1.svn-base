//  
// Type: CodeLock.Models.MasterSupervisor
//  
//  
//  

using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CodeLock.Models
{
  public class MasterSupervisor : BaseModel
  {
    [Required(ErrorMessage = "Please Select Warehouse")]
    public new short WarehouseId { get; set; }

    [Display(Name = "Supervisor Id")]
    public short SupervisorId { get; set; }

    [Required(ErrorMessage = "Please enter Supervisor Name")]
    [Remote("IsSupervisorNameAvailable", "Supervisor", AdditionalFields = "WarehouseId,SupervisorId,_SupervisorIdToken", ErrorMessage = "Supervisor Name already exists.", HttpMethod = "POST")]
    [Display(Name = "Supervisor")]
    [StringLength(50, ErrorMessage = "Supervisor Name must be minimum 2 and maximum 50 character long", MinimumLength = 2)]
    public string SupervisorName { get; set; }

    [Display(Name = "Warehouse Name")]
    public string WarehouseName { get; set; }

    [Required(ErrorMessage = "Please select Document Type")]
    [Display(Name = "Document Type")]
    public byte DocumentTypeId { get; set; }

    public string DocumentTypeName { get; set; }
  }
}
