//  
// Type: CodeLock.Models.DocumentControlSeries
//  
//  
//  

using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class DocumentControlSeries
  {
    public DocumentControlSeries()
    {
      this.BookCode = string.Empty;
      this.DocumentNo = string.Empty;
    }

    [Display(Name = "Document Type")]
    [Required(ErrorMessage = "Please select Document Type")]
    public byte DocumentTypeId { get; set; }

    public short LocationId { get; set; }

    [Display(Name = "Status")]
    public byte DcrStatus { get; set; }

    [Display(Name = "Book Code")]
    public string BookCode { get; set; }

    [Display(Name = "Document No")]
    public string DocumentNo { get; set; }

    public byte CompanyId { get; set; }
  }
}
