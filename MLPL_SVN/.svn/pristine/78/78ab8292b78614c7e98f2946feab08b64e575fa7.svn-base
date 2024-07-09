//  
// Type: CodeLock.Models.FuelSlip
//  
//  
//  

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class FuelSlip
  {
    public FuelSlip()
    {
      this.Details = new List<FuelSlipDetail>();
    }

    public byte CompanyId { get; set; }

    public long TripsheetId { get; set; }

    public byte searchBy { get; set; }

    [Display(Name = "Tripsheet No")]
    public string TripsheetNo { get; set; }

    [Display(Name = "Tripsheet Date")]
    public DateTime TripsheetDate { get; set; }

    [Display(Name = "Starting Location")]
    public string StartLocationCode { get; set; }

    [Display(Name = "End Location")]
    public string EndLocationCode { get; set; }

    [Display(Name = "Category")]
    public string Category { get; set; }

    [Display(Name = "Customer Code")]
    public string CustomerCode { get; set; }

    [Display(Name = "Vehicle No")]
    public string VehicleNo { get; set; }

    public short VehicleId { get; set; }

    [Display(Name = "Driver")]
    public string DriverName { get; set; }

    public short DriverId { get; set; }

    [Display(Name = "Driver License No")]
    public string DriverLicenseNo { get; set; }

    [Display(Name = "License Valid upto")]
    public DateTime DriverLicenseValidityDate { get; set; }

    public Decimal DriverBalance { get; set; }

    public short LocationId { get; set; }

    public string LocationCode { get; set; }

    public string FinYear { get; set; }

    public string AdvancePaidBy { get; set; }

    public short EntryBy { get; set; }

    public List<FuelSlipDetail> Details { get; set; }
  }
}
