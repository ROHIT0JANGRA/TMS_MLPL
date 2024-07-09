//  
// Type: CodeLock.Models.DocketTalk
//  
//  
//  

using System.ComponentModel.DataAnnotations;
using System.Web;

namespace CodeLock.Models
{
  public class DocketTalk : Base
  {
    public long DocketId { get; set; }

    public long TalkId { get; set; }

    [Required(ErrorMessage = "Please enter Docket No")]
    //[DisplayFormat(ConvertEmptyStringToNull = false)]
    [Display(Name = "Docket No")]
    public string DocketNo { get; set; }

    [Display(Name = "Remarks")]
    [Required(ErrorMessage = "Please enter Remarks")]
    public string Remarks { get; set; }

    [Display(Name = "Upload Support Document")]
    public string DocumentName { get; set; }

    [Display(Name = "Upload Image")]
    public HttpPostedFileBase DocumentAttachment { get; set; }
  }
}
