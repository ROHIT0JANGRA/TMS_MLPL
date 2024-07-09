//  
// Type: CodeLock.Models.MasterFinancialYearRight
//  
//  
//  

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class MasterFinancialYearRight : BaseModel
  {
    public MasterFinancialYearRight()
    {
      this.UserId = (short) 0;
      this.UserName = string.Empty;
      this.FinanceYearList = new List<FinanceYear>();
    }

    [Required(ErrorMessage = "Please Enter User Name")]
    [Display(Name = "User")]
    public short UserId { get; set; }

    public string UserName { get; set; }

    [Display(Name = "Financial Year")]
    public List<FinanceYear> FinanceYearList { get; set; }
  }
}
