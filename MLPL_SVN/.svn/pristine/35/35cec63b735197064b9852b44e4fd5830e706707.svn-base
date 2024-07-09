//  
// Type: CodeLock.Models.MasterIssueApproval
//  
//  
//  

using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class MasterIssueApproval
  {
    public long IssueId { get; set; }

    [Display(Name = "Issue Document")]
    public string IssueDocument { get; set; }

    [Display(Name = "Resolved Document")]
    public string ResolvedDocument { get; set; }

    [Required(ErrorMessage = "Please enter Approval Comment")]
    [Display(Name = "Approval Comment")]
    public string ApprovalComment { get; set; }

    [Display(Name = "Approved By")]
    [Required(ErrorMessage = "Please select Approved By")]
    public byte ApprovedById { get; set; }

    public string ApprovedBy { get; set; }
  }
}
