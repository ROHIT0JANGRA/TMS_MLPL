//  
// Type: CodeLock.Models.FuelSurchargeRevision
//  
//  
//  

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class FuelSurchargeRevision : BaseModel
  {
    public FuelSurchargeRevision()
    {
      this.MasterFuelSurchargeRevisionRate = new List<CodeLock.Models.MasterFuelSurchargeRevisionRate>();
    }

    public short RevisionId { get; set; }

    [Required(ErrorMessage = "Please select ContractId")]
    public string ContractIdList { get; set; }

    public string ManualContractIdList { get; set; }

    [Display(Name = "From Date")]
    [DataType(DataType.DateTime)]
    [Required(ErrorMessage = "From Date is required")]
    public DateTime FromDate { get; set; }

    [Required(ErrorMessage = "To Date is required")]
    [Display(Name = "To Date")]
    [DataType(DataType.DateTime)]
    public DateTime ToDate { get; set; }

    public List<CodeLock.Models.MasterFuelSurchargeRevisionRate> MasterFuelSurchargeRevisionRate { get; set; }
  }
}
