//  
// Type: CodeLock.Models.DocketDacc
//  
//  
//  

using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class DocketDacc : Base
  {
    public long DocketId { get; set; }

    //[DisplayFormat(ConvertEmptyStringToNull = false)]
    //[DisplayName("Docket", "DocketNo")]
    [Display(Name = "Docket No")]
    [Required(ErrorMessage = "Please enter Docket No")]
    public string DocketNo { get; set; }

    [Required(ErrorMessage = "Please enter Remarks")]
    [Display(Name = "Remarks")]
    public string Remarks { get; set; }
  }
}
