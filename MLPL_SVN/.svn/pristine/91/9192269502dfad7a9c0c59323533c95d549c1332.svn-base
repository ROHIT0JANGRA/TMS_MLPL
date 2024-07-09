//  
// Type: CodeLock.Models.MasterBudgetCriteria
//  
//  
//  

using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class MasterBudgetCriteria
  {
    public bool IsLocationWise { get; set; }

    [Display(Name = "Select Location")]
    public short LocationWiseBranchId { get; set; }

    [Display(Name = "Select Branch Location")]
    public short AccountWiseBranchId { get; set; }

    [Display(Name = "Select Year Type")]
    public bool IsFinancialYear { get; set; }

    [Display(Name = "Select Entry Type")]
    public bool IsYearly { get; set; }

    [Display(Name = "Select Budget Year")]
    public string BudgetYear { get; set; }

    [Display(Name = "Select Account Category")]
    [Required(ErrorMessage = "Please select Account Category")]
    public string MainAccountId { get; set; }

    [Required(ErrorMessage = "Please select Region")]
    [Display(Name = "Select Region")]
    public string LocationRegionId { get; set; }

    [Display(Name = "Select Account Code")]
    [Required(ErrorMessage = "Please select Account Code")]
    public byte LocationWiseAccountId { get; set; }

    [Display(Name = "Select Account Code")]
    [Required(ErrorMessage = "Please select Account Code")]
    public byte AccountWiseAccountId { get; set; }
  }
}
