//  
// Type: CodeLock.Models.FinanceUpdate
//  
//  
//  

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class FinanceUpdate : BaseModel
  {
    [Display(Name = "Document Type")]
    public byte DocumentTypeId { get; set; }

    [Display(Name = "Document No")]
    public string DocumentNo { get; set; }

    [Display(Name = "Manual Document No")]
    public string ManualDocumentNo { get; set; }

    public List<FinanceUpdate> Details { get; set; }

    public short LocationId { get; set; }
  }
}
