//  
// Type: CodeLock.Models.MasterVehicleDetail
//  
//  
//  

using System;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class MasterVehicleDetail : BaseModel
  {
    public MasterVehicleDetail()
    {
      this.VehicleId = (short) 0;
    }

    public short VehicleId { get; set; }

    [Display(Name = "No of Drivers")]
    [Required(ErrorMessage = "Please enter No of Drivers")]
    public Decimal NoOfDrivers { get; set; }

    [Display(Name = "Is GPS Enabled")]
    public bool IsGpsEnabled { get; set; }

    [StringLength(25, ErrorMessage = "GPS Device must be minimum 2 and maximum 25 character long", MinimumLength = 2)]
    [Display(Name = "GPS Device")]
    public string GpsDeviceId { get; set; }

    [StringLength(50, ErrorMessage = "Vehicle Broker must be minimum 2 and maximum 50 character long", MinimumLength = 2)]
    [Display(Name = "Vehicle Broker")]
    public string VehicleBroker { get; set; }

    [Required(ErrorMessage = "Please enter No Of Tyres")]
    [Display(Name = "No Of Tyres")]
    public Decimal NoOfTyres { get; set; }

    [Required(ErrorMessage = "Please enter RC Book No")]
    [StringLength(25, ErrorMessage = "RC Book No must be minimum 2 and maximum 25 character long", MinimumLength = 2)]
    [Display(Name = "RcBook No")]
    public string RcBookNo { get; set; }

    [Required(ErrorMessage = "Please enter Registration No")]
    [Display(Name = "Registration No")]
    [StringLength(25, ErrorMessage = "Registration No must be minimum 2 and maximum 25 character long", MinimumLength = 2)]
    public string RegistrationNo { get; set; }

    [Required(ErrorMessage = "Please select Registration Date")]
    [Display(Name = "Registration Date")]
    public DateTime RegistrationDate { get; set; }

    [Required(ErrorMessage = "Please enter Insurance No")]
    [StringLength(25, ErrorMessage = "Insurance No must be minimum 2 and maximum 25 character long", MinimumLength = 2)]
    [Display(Name = "Insurance No")]
    public string InsuranceNo { get; set; }

    [Required(ErrorMessage = "Please select Insurance Issue Date")]
    [Display(Name = "Insurance Issue Date")]
    public DateTime InsuranceIssueDate { get; set; }

    [Required(ErrorMessage = "Please select Insurance Expiry Date")]
    [Display(Name = "Insurance Expiry Date")]
    public DateTime InsuranceExpiryDate { get; set; }

    [Required(ErrorMessage = "Please enter Fitness Certificate No")]
    [StringLength(25, ErrorMessage = "Fitness Certificate No must be minimum 2 and maximum 25 character long", MinimumLength = 2)]
    [Display(Name = "Fitness Certificate No")]
    public string FitnessCertificateNo { get; set; }

    [Required(ErrorMessage = "Please select Fitness Certificate Issue Date")]
    [Display(Name = "Fitness Certificate Issue Date")]
    public DateTime FitnessCertificateIssueDate { get; set; }

    [Required(ErrorMessage = "Please enter National Permit Certificate No.")]
    [Display(Name = "National Permit Certificate No")]
    public string NationalPermitNo { get; set; }

    [Display(Name = "National Permit Certificate Issue Date ")]
    [Required(ErrorMessage = "Please select National Permit Issue Date")]
    public DateTime NationalPermitIssueDate { get; set; }

    [Required(ErrorMessage = "Please select National Permit Expiry Date")]
    [Display(Name = "National Permit Certificate Expiry Date ")]
    public DateTime NationalPermitExpiryDate { get; set; }

    [Required(ErrorMessage = "Please select Attaching Date")]
    [Display(Name = "Attaching Date")]
    public DateTime AttachingDate { get; set; }

    [StringLength(25, ErrorMessage = "Chasis No must be minimum 2 and maximum 25 character long", MinimumLength = 2)]
    [Display(Name = "Chasis No")]
    [Required(ErrorMessage = "Please enter Chasis No")]
    public string ChasisNo { get; set; }

    [StringLength(25, ErrorMessage = "Engine No must be minimum 2 and maximum 25 character long", MinimumLength = 2)]
    [Required(ErrorMessage = "Please enter Engine No")]
    [Display(Name = "Engine No")]
    public string EngineNo { get; set; }

    [Required(ErrorMessage = "Please enter RTO Name")]
    [Display(Name = "RTO Name")]
    [StringLength(50, ErrorMessage = "RTO Name must be minimum 2 and maximum 50 character long", MinimumLength = 2)]
    public string RtoName { get; set; }

    [Display(Name = "Pollution Certificate No")]
    [Required(ErrorMessage = "Please enter Pollution Certificate No")]
    public string PollutionCertificateNo { get; set; }

    [Required(ErrorMessage = "Please enter Pollution Certificate Issue Date")]
    [Display(Name = "Pollution Certificate Issue Date")]
    public DateTime PollutionCertificateIssueDate { get; set; }

    [Required(ErrorMessage = "Please enter Pollution Certificate Expiry Date")]
    [Display(Name = "Pollution Certificate Expiry Date")]
    public DateTime PollutionCertificateExpiryDate { get; set; }

    [Required(ErrorMessage = "Please enter Road Tax Certificate No.")]
    [Display(Name = "Road Tax Certificate No")]
    public string RoadTaxNo { get; set; }

    [Display(Name = "Road Tax Certificate Issue Date")]
    [Required(ErrorMessage = "Please enter Road Tax Issue Date")]
    public DateTime RoadTaxIssueDate { get; set; }

    [Display(Name = "Road Tax Certificate Expiry Date")]
    [Required(ErrorMessage = "Please enter Road Tax Expiry Date")]
    public DateTime RoadTaxExpiryDate { get; set; }

    [Display(Name = "Authorisation Certificate No")]
    [Required(ErrorMessage = "Please enter Authorisation Certificate No.")]
    public string AuthorisationNo { get; set; }

    [Display(Name = "Authorisation Certificate Issue Date")]
    [Required(ErrorMessage = "Please enter Authorisation Issue Date")]
    public DateTime AuthorisationIssueDate { get; set; }

    [Display(Name = "Authorisation Certificate Expiry Date")]
    [Required(ErrorMessage = "Please enter Authorisation Expiry Date")]
    public DateTime AuthorisationExpiryDate { get; set; }

    [Required(ErrorMessage = "Please enter Local Permit No.")]
    [Display(Name = "Local Permit No")]
    public string LocalPermitNo { get; set; }

    [Display(Name = "Local Permit Issue Date")]
    public DateTime LocalPermitIssueDate { get; set; }

    [Display(Name = "Local Permit Expiry Date")]
    public DateTime LocalPermitExpiryDate { get; set; }

    [Display(Name = "Fitness Certificate Expiry Date")]
    [Required(ErrorMessage = "Please select Fitness Certificate Expiry Date")]
    public DateTime FitnessCertificateExpiryDate { get; set; }

    [Display(Name = "Vehicle Mileage")]
    public Decimal VehicleMileage { get; set; }
  }
}
