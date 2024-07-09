//  
// Type: CodeLock.Models.MasterIssue
//  
//  
//  

using System;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace CodeLock.Models
{
  public class MasterIssue : BaseModel
  {
    public long IssueId { get; set; }

    public long HistoryId { get; set; }

    [Required(ErrorMessage = "Please select Client")]
    [Display(Name = "Client")]
    public byte ClientId { get; set; }

    public string ClientName { get; set; }

    [Display(Name = "Issue Date & Time")]
    public DateTime IssueDateTime { get; set; }

    [Display(Name = "Main Menu")]
    [Required(ErrorMessage = "Please select Main Menu")]
    public short MainMenuId { get; set; }

    public string MainMenu { get; set; }

    [Display(Name = "Parent Menu")]
    [Required(ErrorMessage = "Please select Parent Menu")]
    public short ParentMenuId { get; set; }

    public string ParentMenu { get; set; }

    [Display(Name = "Child Menu")]
    [Required(ErrorMessage = "Please select Child Menu")]
    public short ChildMenuId { get; set; }

    public string ChildMenu { get; set; }

    [Display(Name = "Issue Description")]
    [Required(ErrorMessage = "Please enter Issue Description")]
    public string IssueDescription { get; set; }

    [Required(ErrorMessage = "Please select Issue Type")]
    [Display(Name = "Issue Type")]
    public byte IssueTypeId { get; set; }

    public string IssueType { get; set; }

    [Display(Name = "Image")]
    public string IssueImage { get; set; }

    [Display(Name = "Issue Priority")]
    [Required(ErrorMessage = "Please select Issue Priority")]
    public byte IssuePriorityId { get; set; }

    public string IssuePriority { get; set; }

    [Required(ErrorMessage = "Please select Issue Raised By")]
    [Display(Name = "Issue Raised By")]
    public byte IssueRaisedById { get; set; }

    public string IssueRaisedBy { get; set; }

    [Display(Name = "Image")]
    public HttpPostedFileBase IssueAttachment { get; set; }

    [Display(Name = "Resolved Document")]
    public string ResolvedDocument { get; set; }

    [Display(Name = "Comment")]
    public string Comment { get; set; }

    [Display(Name = "Resolved By")]
    public string ResolvedBy { get; set; }

    [Display(Name = "Resolved Date & Time")]
    public DateTime ResolvedDateTime { get; set; }

    [Display(Name = "Approval Comment")]
    public string ApprovalComment { get; set; }

    [Display(Name = "Approved By")]
    public string ApprovedBy { get; set; }

    [Display(Name = "Approved Date & Time")]
    public DateTime ApprovedDateTime { get; set; }
  }
}
