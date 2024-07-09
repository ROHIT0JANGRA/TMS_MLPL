//  
// Type: CodeLock.Models.MasterVendorDetails
//  
//  
//  

using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class MasterVendorDetails : BaseModel
  {
        public int TotalVendors { get; set; }
        public int FilterVendors { get; set; }
        [Display(Name = "Vender Type Name")]
    public string VendorTypeName { get; set; }

    [Display(Name = "Vendor Type")]
    public byte VendorTypeId { get; set; }

    public short VendorId { get; set; }

    [Display(Name = "Vendor Code")]
    public string VendorCode { get; set; }

    [Display(Name = "Vendor Name")]
    public string VendorName { get; set; }

    [Display(Name = "Mobile No")]
    public string MobileNo { get; set; }

    [Display(Name = "Email Id")]
    public string EmailId { get; set; }

    [Display(Name = "Address")]
    public string Address { get; set; }

    [Display(Name = "Vendor Location")]
    public string VendorLocation { get; set; }

    public string VendorLocationName { get; set; }

    [Display(Name = "Is Black Listed")]
    public bool IsBlackListed { get; set; }

    [Display(Name = "Vendor Service")]
    public string VendorService { get; set; }

    public string VendorServiceName { get; set; }

    [Display(Name = "PAN No")]
    [Required(ErrorMessage = "Please Enter PAN No")]
    [PanNoAnnotation]
    public string PanNo { get; set; }

    [Display(Name = "GST TIN No")]
    public string GstTinNo { get; set; }

    [Display(Name = "Remarks")]
    public string Remarks { get; set; }
  }
    public class VendorExcelData
    {
        public string VendorName { get; set; }
        public string VendorTypeName { get; set; }
        public string MobileNo { get; set; }
        public string EmailId { get; set; }
        public string Address { get; set; }
        public string CityName { get; set; }
        public bool IsActive { get; set; }
        public string VendorLocationName { get; set; }
        public string PanNo { get; set; }
        public string GstTinNo { get; set; }
        public string VendorServiceName { get; set; }

    }

}
