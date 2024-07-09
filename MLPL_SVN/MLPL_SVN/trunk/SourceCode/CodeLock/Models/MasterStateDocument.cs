//  
// Type: CodeLock.Models.MasterStateDocument
//  
//  
//  

using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class MasterStateDocument
  {
    public MasterStateDocument()
    {
      this.StateDocumentId = (short) 0;
      this.StateId = (short) 0;
      this.DocumentName = string.Empty;
      this.IsInbound = false;
      this.IsRemoved = false;
    }

    public short StateDocumentId { get; set; }

    public short StateId { get; set; }

    [Required(ErrorMessage = "Please enter Document Name")]
    [Display(Name = "Document Name")]
    public string DocumentName { get; set; }

    [Display(Name = "Inbound/Outbound")]
    public bool IsInbound { get; set; }

    public bool IsRemoved { get; set; }
  }
}
