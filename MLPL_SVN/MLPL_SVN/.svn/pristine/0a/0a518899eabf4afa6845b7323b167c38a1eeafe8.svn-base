//  
// Type: CodeLock.Models.ServiceTypeToSacMapping
//  
//  
//  

using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class ServiceTypeToSacMapping : BaseModel
  {
    public byte ServiceTypeId { get; set; }

    public string ServiceType { get; set; }

    [Required(ErrorMessage = "Please select SAC")]
    public byte SacId { get; set; }
  }
}
