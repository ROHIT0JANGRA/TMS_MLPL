//  
// Type: CodeLock.Models.MasterSupplier
//  
//  
//  

using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CodeLock.Models
{
  public class MasterSupplier : BaseModel
  {
    public string CompanyName { get; set; }

    public short SupplierId { get; set; }

    [Display(Name = "Supplier Code")]
    public string SupplierCode { get; set; }

    [Required(ErrorMessage = "Please enter Supplier Name")]
    [Display(Name = "Supplier Name")]
    [StringLength(50, ErrorMessage = "Supplier Name must be minimum 2 and maximum 50 character long", MinimumLength = 2)]
    [Remote("IsSupplierNameAvailable", "Supplier", AdditionalFields = "SupplierId,_SupplierIdToken", ErrorMessage = "Supplier Name already exists.", HttpMethod = "POST")]
    public string SupplierName { get; set; }

    [Display(Name = "Mobile No")]
    [MobileAnnotation]
    [Required(ErrorMessage = "Please enter Mobile No")]
    public string MobileNo { get; set; }

    [Required(ErrorMessage = "Please enter Email Id")]
    [EmailAnnotation]
    [Display(Name = "Email Id")]
    public string EmailId { get; set; }

    [Display(Name = "Address")]
    public string Address { get; set; }
  }
}
