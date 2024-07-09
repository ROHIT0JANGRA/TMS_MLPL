//  
// Type: CodeLock.Models.MasterIssueClose
//  
//  
//  

using System.ComponentModel.DataAnnotations;
using System.Web;

namespace CodeLock.Models
{
  public class MasterIssueClose
  {
    public long IssueId { get; set; }

    [Display(Name = "Resolved Document")]
    public string ResolvedDocument { get; set; }

    [Display(Name = "Resolved Document")]
    public HttpPostedFileBase ResolvedDocumentAttachment { get; set; }

    [Required(ErrorMessage = "Please enter Comment")]
    [Display(Name = "Comment")]
    public string Comment { get; set; }

    [Required(ErrorMessage = "Please select Resolved By")]
    [Display(Name = "Resolved By")]
    public byte ResolvedById { get; set; }

    public string ResolvedBy { get; set; }
  }
}
