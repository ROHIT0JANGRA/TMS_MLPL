//  
// Type: CodeLock.Models.TransportModeToServiceMapping
//  
//  
//  

using System;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class TransportModeToServiceMapping : BaseModel
  {
    public byte TransportModeId { get; set; }

    public string TransportMode { get; set; }

    [Required(ErrorMessage = "Please select Service Type")]
    public byte ServiceTypeId { get; set; }

    public string ServiceType { get; set; }

    public string SacName { get; set; }

    public byte SacId { get; set; }

    public Decimal GstRate { get; set; }

    public bool IsRcm { get; set; }
  }
}
