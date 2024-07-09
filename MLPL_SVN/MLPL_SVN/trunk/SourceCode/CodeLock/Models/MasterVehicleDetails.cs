﻿//  
// Type: CodeLock.Models.MasterVehicleDetails
//  
//  
//  

using System;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class MasterVehicleDetails : BaseModel
  {
        public short SrNo { get; set; }
        public short Id { get; set; }
    public string FtlTypeName { get; set; }

    [Display(Name = " Vehicle Id")]
    public short VehicleId { get; set; }

    [Display(Name = "Vehicle No")]
    public string VehicleNo { get; set; }

    [Display(Name = "Vehicle Type")]
    public short VehicleTypeId { get; set; }

    [Display(Name = "Vendor")]
    public short VendorId { get; set; }

    [Display(Name = "Ftl Type")]
    public byte FtlTypeId { get; set; }

    [Display(Name = "Location")]
    public string LocationCode { get; set; }

    [Display(Name = "Vendor Type")]
    public byte VendorTypeId { get; set; }

    [Display(Name = "Start Km")]
    public int? StartKm { get; set; }

    public string VehicleTypeName { get; set; }

    public string VendorTypeName { get; set; }

    public Decimal? Capacity { get; set; }

    public string VendorName { get; set; }

    public string LocationName { get; set; }

    public virtual MasterVehicleDetail MasterVehicleDetail { get; set; }

    [Display(Name = "No of Drivers")]
    public Decimal NoOfDrivers { get; set; }

    [Display(Name = "Is GPS Enabled")]
    public bool IsGpsEnabled { get; set; }

    [Display(Name = "GPS Device")]
    public string GpsDeviceId { get; set; }

    [Display(Name = "Vehicle Broker")]
    public string VehicleBroker { get; set; }

    [Display(Name = "No Of Tyres")]
    public Decimal NoOfTyres { get; set; }

    [Display(Name = "RcBook No")]
    public string RcBookNo { get; set; }

    [Display(Name = "Registration No")]
    public string RegistrationNo { get; set; }

    [Display(Name = "Registration Date")]
    public DateTime RegistrationDate { get; set; }

    [Display(Name = "Insurance No")]
    public string InsuranceNo { get; set; }

    [Display(Name = "Insurance Issue Date")]
    public DateTime InsuranceIssueDate { get; set; }

    [Display(Name = "Insurance Expiry Date")]
    public DateTime InsuranceExpiryDate { get; set; }

    [Display(Name = "Fitness Certificate No")]
    public string FitnessCertificateNo { get; set; }

    [Display(Name = "Fitness Certificate Issue Date")]
    public DateTime FitnessCertificateIssueDate { get; set; }

    [Display(Name = "National Permit Certificate No")]
    public string NationalPermitNo { get; set; }

    [Display(Name = "National Permit Certificate Issue Date ")]
    public DateTime NationalPermitIssueDate { get; set; }

    [Display(Name = "National Permit Certificate Expiry Date ")]
    public DateTime NationalPermitExpiryDate { get; set; }

    [Display(Name = "Attaching Date")]
    public DateTime AttachingDate { get; set; }

    [Display(Name = "Chasis No")]
    public string ChasisNo { get; set; }

    [Display(Name = "Engine No")]
    public string EngineNo { get; set; }

    [Display(Name = "RTO Name")]
    public string RtoName { get; set; }

    [Display(Name = "Pollution Certificate No")]
    public string PollutionCertificateNo { get; set; }

    [Display(Name = "Pollution Certificate Issue Date")]
    public DateTime PollutionCertificateIssueDate { get; set; }

    [Display(Name = "Pollution Certificate Expiry Date")]
    public DateTime PollutionCertificateExpiryDate { get; set; }

    [Display(Name = "Road Tax Certificate No")]
    public string RoadTaxNo { get; set; }

    [Display(Name = "Road Tax Certificate Issue Date")]
    public DateTime RoadTaxIssueDate { get; set; }

    [Display(Name = "Road Tax Certificate Expiry Date")]
    public DateTime RoadTaxExpiryDate { get; set; }

    [Display(Name = "Authorisation Certificate No")]
    public string AuthorisationNo { get; set; }

    [Display(Name = "Authorisation Certificate Issue Date")]
    public DateTime AuthorisationIssueDate { get; set; }

    [Display(Name = "Authorisation Certificate Expiry Date")]
    public DateTime AuthorisationExpiryDate { get; set; }

    [Display(Name = "Local Permit No")]
    public string LocalPermitNo { get; set; }

    [Display(Name = "Local Permit Issue Date")]
    public DateTime LocalPermitIssueDate { get; set; }

    [Display(Name = "Local Permit Expiry Date")]
    public DateTime LocalPermitExpiryDate { get; set; }

    [Display(Name = "Fitness Certificate Expiry Date")]
    public DateTime FitnessCertificateExpiryDate { get; set; }

    [Display(Name = "Vehicle Mileage")]
    public Decimal VehicleMileage { get; set; }
        public string CodeDescription { get; set; }
        public int TotalVehicle { get; set; }
        public int FilterVehcile { get; set; }
    }
}