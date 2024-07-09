//  
// Type: CodeLock.Models.MasterVendor
//  
//  
//  

using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CodeLock.Models
{
  public class MasterVendor : Base
  {
    public MasterVendor()
    {
      this.MasterVendorDetail = new MasterVendorDetail();
    }

    [Required(ErrorMessage = "Please select Vendor Type")]
    [Display(Name = "Vendor Type")]
    public byte VendorTypeId { get; set; }

    public short VendorId { get; set; }

    [Display(Name = "Vendor Code")]
    public string VendorCode { get; set; }

    [Required(ErrorMessage = "Please enter Vendor Name")]
    [StringLength(100, ErrorMessage = "Vendor Name must be minimum 2 and maximum 100 character long", MinimumLength = 2)]
    [Display(Name = "Vendor Name")]
    [Remote("IsVendorNameAvailable", "Vendor", AdditionalFields = "VendorId,_VendorIdToken", ErrorMessage = "Vendor Name already exists.", HttpMethod = "POST")]
    public string VendorName { get; set; }

    [Display(Name = "Vender Type Name")]
    public string VendorTypeName { get; set; }

    [Display(Name = "Vendor Location")]
    [Required(ErrorMessage = "Please select Vendor Location")]
    public string VendorLocation { get; set; }

    public string VendorLocationName { get; set; }

    public string SavedVendorLocation { get; set; }
    [Display(Name = "Vendor Warehouse")]
     public string VendorWarehouse { get; set; }
        public short WarehouseId { get; set; }
        public string VendorWarehouseName { get; set; }

        public string SavedVendorWarehouse { get; set; }


        [Display(Name = "Vendor Service")]
    [Required(ErrorMessage = "Please select Vendor Service")]
    public string VendorService { get; set; }

    public string VendorServiceName { get; set; }

    public string SavedVendorService { get; set; }

    [Display(Name = "Contract Applicable")]
    public string ContractApplicable { get; set; }

    [Display(Name = "Contract Applicable")]
    [Required(ErrorMessage = "Please select Contract Applicable")]
    public string ContractApplicableId { get; set; }
    public MasterVendorDetail MasterVendorDetail { get; set; }


   [Display(Name = "PayBasId")]
   public string PayBasId { get; set; }
        [Display(Name = "PayBas")]
   public string PayBasName { get; set; }

   [Display(Name = "PayBas")]
   public MasterGeneral[] PayBas { get; set; }

   [Display(Name = "Manual Vendor Code")]
   public string ManualVendorCode { get; set; }
        
    }
}
