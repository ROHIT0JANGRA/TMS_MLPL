//  
// Type: CodeLock.Models.MasterReceiver
//  
//  
//  

using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CodeLock.Models
{
  public class MasterReceiver : BaseModel
  {
    public short ReceiverId { get; set; }

    [Required(ErrorMessage = "Please select Location")]
    [Display(Name = "Location Code")]
    public short LocationId { get; set; }

    [StringLength(50, ErrorMessage = "Receiver Name must be minimum 2 and maximum 50 character long", MinimumLength = 2)]
    [NameAnnotation]
    [Required(ErrorMessage = "Please enter Receiver Name")]
    [Remote("IsReceiverNameAvailable", "Receiver", AdditionalFields = "ReceiverId,_ReceiverIdToken", ErrorMessage = "Receiver Name already exists. Please enter a different Receiver Name.", HttpMethod = "POST")]
    [Display(Name = "Receiver Name")]
    public string ReceiverName { get; set; }

    [Display(Name = "Location Code")]
    public string LocationCode { get; set; }
  }
}
