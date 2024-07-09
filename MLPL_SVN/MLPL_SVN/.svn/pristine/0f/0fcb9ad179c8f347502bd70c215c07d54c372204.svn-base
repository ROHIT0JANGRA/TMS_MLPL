//  
// Type: CodeLock.Models.VendorContract
//  
//  
//  

using System;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class VendorContract : BaseModel
  {[Key]
    public short ContractId { get; set; }

    [Display(Name = "Contract ID")]
    public string ManualContractId { get; set; }

    [Required(ErrorMessage = "Please select Vendor Type")]
    [Display(Name = "Vendor Type")]
    public byte VendorTypeId { get; set; }

    [Required(ErrorMessage = "Please select Vendor Name")]
    [Display(Name = "Vendor Name")]
    public short VendorId { get; set; }

    [DataType(DataType.DateTime)]
    [Required(ErrorMessage = "Please select Start Date")]
    [Display(Name = "Start Date")]
    public DateTime StartDate { get; set; }

    [DataType(DataType.DateTime)]
    [Required(ErrorMessage = "Please select End Date")]
    [Display(Name = "End Date")]
    public DateTime EndDate { get; set; }

    [Display(Name = "Vendor Name")]
    public string VendorName { get; set; }

    [Display(Name = "Vendor Code")]
    public string VendorCode { get; set; }

    public string VendorType { get; set; }

    public bool IsUseRouteContractAmount { get; set; }
    public Decimal ContractAmount { get; set; }

   public VendorContractBasicInfo VendorContractBasicInfo { get; set; }
  }
}
