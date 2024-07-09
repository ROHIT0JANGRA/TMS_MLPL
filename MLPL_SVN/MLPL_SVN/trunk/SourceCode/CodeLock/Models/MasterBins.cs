//  
// Type: CodeLock.Models.MasterBins
//  
//  
//  

using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CodeLock.Models
{
  public class MasterBins : BaseModel
  {
    public MasterBins()
    {
      this.BindId = (short) 0;
    }

    public int BindId { get; set; }

    [Display(Name = "Bin Code")]
    [Required(ErrorMessage = "Please enter Bin Code")]
    [StringLength(10, ErrorMessage = "Bin Code must be minimum 2 and maximum 10 character long", MinimumLength = 2)]
    [Remote("IsBinCodeAvailable", "Bins", AdditionalFields = "BindId,_BindIdToken", ErrorMessage = "Bin Code already exists.", HttpMethod = "POST")]
    public string BinCode { get; set; }

    [Display(Name = "Bin Name")]
    [Remote("IsBinNameAvailable", "Bins", AdditionalFields = "BindId,_BindIdToken", ErrorMessage = "Bin Name already exists.", HttpMethod = "POST")]
    [Required(ErrorMessage = "Please enter Bin Name")]
    [StringLength(50, ErrorMessage = "Bin Name must be minimum 2 and maximum 50 character long", MinimumLength = 2)]
    public string BinName { get; set; }

    [Display(Name = "Bin Hierarchy")]
    [Required(ErrorMessage = "Please select Bin Hierarchy")]
    public byte BinHierarchyId { get; set; }

    public byte HierarchyId { get; set; }

    [Display(Name = "Parent Hierarchy")]
    public string ParentHierarchy { get; set; }

    [Display(Name = "Bin Hierarchy Name")]
    public string BinHierarchyName { get; set; }

    [Required(ErrorMessage = "Please select Parent Hierarchy")]
    [Display(Name = "Parent Hierarchy")]
    public short? ParentBindId { get; set; }
    public Decimal AvailableQuantity { get; set; }


    }
}
