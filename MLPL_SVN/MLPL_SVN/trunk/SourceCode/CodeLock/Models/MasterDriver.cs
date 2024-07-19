//  
// Type: CodeLock.Models.MasterDriver
//  
//  
//  

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class MasterDriver : BaseModel
  {
    public MasterDriver()
    {
      this.ManualDriverCode = "NA";
      this.DocumentDetails = new List<DriverDocument>();
    }
        public int TotalDrivers { get; set; }
        public int FilterDriver {  get; set; }    
    public short DriverId { get; set; }

    public Decimal BalanceAmount { get; set; }

    public bool DriverStatus { get; set; }

    [Display(Name = "Driver Code")]
    public string DriverCode { get; set; }

    [Required(ErrorMessage = "Please enter Driver Name")]
    [Display(Name = "Driver Name")]
    public string DriverName { get; set; }

    [Required(ErrorMessage = "Please enter Manual Driver Code")]
    [Display(Name = "Manual Driver Code")]
    public string ManualDriverCode { get; set; }

    [Display(Name = "Driver's Father Name")]
    [Required(ErrorMessage = "Please enter Driver Father Name")]
    public string DriverFatherName { get; set; }

    [Display(Name = "Vehicle No")]
    public string VehicleNo { get; set; }

    public short? VehicleId { get; set; }

    [Required(ErrorMessage = "Please enter Control Location")]
    [Display(Name = "Control Location")]
    public string DriverLocationCode { get; set; }

    public short DriverLocationId { get; set; }

    [Required(ErrorMessage = "Please enter Mobile No")]
    [Display(Name = "Mobile No")]
    [MobileAnnotation]
    public string MobileNo { get; set; }

    [Display(Name = "Permanent Address")]
    [Required(ErrorMessage = "Please enter Permanent Address")]
    public string PermanentAddress { get; set; }

    [Display(Name = "Permanent City")]
    [Required(ErrorMessage = "Please enter Permanent City")]
    public string PermanentCityName { get; set; }

    public int PermanentCityId { get; set; }

    [Display(Name = "Permanent Pincode")]
    [Required(ErrorMessage = "Please enter Permanent Pincode")]
    public string PermanentPincode { get; set; }

    [Required(ErrorMessage = "Please enter Current Address")]
    [Display(Name = "Current Address")]
    public string CurrentAddress { get; set; }

    [Required(ErrorMessage = "Please enter Current City")]
    [Display(Name = "Current City")]
    public string CurrentCityName { get; set; }

    public int CurrentCityId { get; set; }

    [Required(ErrorMessage = "Please enter Current Pincode")]
    [Display(Name = "Current Pincode")]
    public string CurrentPincode { get; set; }

    [Display(Name = "Use Permanent Address As Current Address")]
    public bool UsePermanentAddressAsCurrentAddress { get; set; }

    [Required(ErrorMessage = "Please enter License No")]
    [Display(Name = "License No")]
    public string LicenseNo { get; set; }

    [Required(ErrorMessage = "Please select License Validity Date")]
    [Display(Name = "License Validity Date")]
    public DateTime LicenseValidityDate { get; set; }

    [Display(Name = "License Issued By")]
    [Required(ErrorMessage = "Please enter License Issued By")]
    public string LicenseIssueBy { get; set; }

    [Required(ErrorMessage = "Please enter Guarantor Name")]
    [Display(Name = "Guarantor Name")]
    public string GuarantorName { get; set; }

    [Display(Name = "Driver Category")]
    [Required(ErrorMessage = "Please select Category")]
    public byte CategoryId { get; set; }

    public string Category { get; set; }

    [Display(Name = "Date Of Birth")]
    [Required(ErrorMessage = "Please select Date Of Birth")]
    public DateTime DoB { get; set; }

    [Display(Name = "Ethnicity")]
    [Required(ErrorMessage = "Please select Ethnicity")]
    public byte? Ethnicity { get; set; }

    public string DriverEthnicity { get; set; }

    [Required(ErrorMessage = "Please select License Initial Issue Date")]
    [Display(Name = "License Initial Issue Date")]
    public DateTime LicenseInitialIssueDate { get; set; }

    [Display(Name = "License Current Issue Date")]
    [Required(ErrorMessage = "Please select License Current Issue Date")]
    public DateTime LicenseCurrentIssueDate { get; set; }

    [Display(Name = "License Verified")]
    public bool IsLicenseVerified { get; set; }

    [Display(Name = "Address Verified")]
    public bool IsAddressVerified { get; set; }

    [Display(Name = "License Verified Date")]
    public DateTime LicenseVerifiedDate { get; set; }

    public List<DriverDocument> DocumentDetails { get; set; }
  }
}
