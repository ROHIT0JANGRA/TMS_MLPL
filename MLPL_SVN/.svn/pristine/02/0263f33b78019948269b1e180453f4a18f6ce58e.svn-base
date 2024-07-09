//  
// Type: CodeLock.Models.JobOrder
//  
//  
//  

using ExpressiveAnnotations.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class JobOrder : BaseModel
  {
    public long JobOrderId { get; set; }

    public short LocationId { get; set; }

    [Display(Name = "Vehicle No")]
    public short VehicleId { get; set; }

    [Required(ErrorMessage = "Please enter Vehicle No")]
    [Display(Name = "Vehicle No")]
    public string VehicleNo { get; set; }

    [Display(Name = "Job Order No")]
    public string JobOrderNo { get; set; }

    [Required(ErrorMessage = "Please select Job Order Date")]
    [Display(Name = "Job Order Date")]
    public DateTime JobOrderDate { get; set; }

    [Display(Name = "Job Card Type")]
    [Required(ErrorMessage = "Please select Job Card Type")]
    public byte JobCardType { get; set; }

    public string CardType { get; set; }

    [Display(Name = "Service Center Type")]
    [Required(ErrorMessage = "Please select Service Center Type")]
    public byte ServiceCenterType { get; set; }

    public string ServiceType { get; set; }

    public byte ServiceCenterId { get; set; }

    public byte JobServiceCenterId { get; set; }

    public string ServiceCenter { get; set; }

    [Display(Name = "Send date to WorkShop")]
    [Required(ErrorMessage = "Please enter Send Date")]
    public DateTime SendDate { get; set; }

    [Required(ErrorMessage = "Please enter Estimated Return Date")]
    [Display(Name = "Estimated Return Date")]
    public DateTime EstimatedReturnDate { get; set; }

    [AssertThat("0 < CurrentKmReading", ErrorMessage = "Current KM must be greater than 0")]
    [Display(Name = "Current KM Reading")]
    public int CurrentKmReading { get; set; }

    [Display(Name = "Close KM Reading")]
    [AssertThat("CurrentKmReading < CloseKmReading", ErrorMessage = "Close KM must be greater than Start KM")]
    public int CloseKmReading { get; set; }

    [Display(Name = "Actual Return date")]
    public DateTime? ActualReturnDate { get; set; }

    [Display(Name = "Labour Cost per Hour")]
    public Decimal LabourCostPerHour { get; set; }

    [Display(Name = "Total Estimated Labour Hours")]
    public byte TotalEstimatedLabourHours { get; set; }

    [Display(Name = "Total Estimated Labour Cost")]
    public Decimal TotalEstimatedLabourCost { get; set; }

    [Display(Name = "Total Actual Labour Cost")]
    public Decimal TotalActualLabourCost { get; set; }

    [Display(Name = "Total Estimated Cost")]
    public Decimal TotalEstimatedCost { get; set; }

    [Display(Name = "Total Estimated Spare Part Cost")]
    public Decimal TotalEstimatedSparePartCost { get; set; }

    [Display(Name = "Total Actual Spare Part Cost")]
    public Decimal TotalActualSparePartCost { get; set; }

    [Display(Name = "Total Actual Cost")]
    public Decimal TotalActualCost { get; set; }

    public DateTime? CloseDate { get; set; }

    public bool? IsApprove { get; set; }

    public short CloseBy { get; set; }

    public List<TaskDetail> TaskDetails { get; set; }

    public List<SparePartDetail> SparePartDetails { get; set; }
  }
}
