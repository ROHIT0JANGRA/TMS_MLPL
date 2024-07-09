//  
// Type: CodeLock.Models.MasterSac
//  
//  
//  

using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CodeLock.Models
{
  public class MasterSac : BaseModel
  {
    public byte SacId { get; set; }

    [Display(Name = "SAC Name")]
    [StringLength(100, ErrorMessage = "SAC Name must be minimum 2 and maximum 100 character long", MinimumLength = 2)]
    [Required(ErrorMessage = "Please enter SAC Name")]
    [Remote("IsSacNameAvailable", "Sac", AdditionalFields = "SacId,_SacIdToken", ErrorMessage = "SAC Name already exists.", HttpMethod = "POST")]
    public string SacName { get; set; }

    [Remote("IsSacCodeAvailable", "Sac", AdditionalFields = "SacId,_SacIdToken", ErrorMessage = "SAC Code already exists.", HttpMethod = "POST")]
    [Display(Name = "SAC Code")]
    [StringLength(25, ErrorMessage = "SAC Code must be minimum 2 and maximum 25 character long", MinimumLength = 2)]
    [Required(ErrorMessage = "Please enter SAC Code")]
    public string SacCode { get; set; }

    [Range(0, 100, ErrorMessage = "Please enter a Rate between 0 to 100")]
    [Display(Name = "GST Rate")]
    public Decimal GstRate { get; set; }

    [Display(Name = "RCM Applicable")]
    public bool IsRcm { get; set; }

    public string ServiceType { get; set; }

    public string TransportMode { get; set; }
  }
}
