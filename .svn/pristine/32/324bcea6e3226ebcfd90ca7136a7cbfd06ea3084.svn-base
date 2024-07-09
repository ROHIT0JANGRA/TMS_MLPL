//  
// Type: CodeLock.Models.DocketDispatch
//  
//  
//  

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class DocketDispatch : Base
  {
    public short LocationId { get; set; }

    public string LocationCode { get; set; }

    public long DispatchId { get; set; }

    [Display(Name = "Dispatch No")]
    [Required(ErrorMessage = "Please enter Dispatch No")]
    public string DispatchNo { get; set; }

    [Display(Name = "Dispatch Date")]
    public DateTime DispatchDateTime { get; set; }

    public short VehicleId { get; set; }

    [Required(ErrorMessage = "Please enter Truck Number")]
    [Display(Name = "Truck Number")]
    public string VehicleNo { get; set; }

    public short FromLocationId { get; set; }

    [Required(ErrorMessage = "Please enter From")]
    [Display(Name = "From")]
    public string FromLocationCode { get; set; }

    public short ToLocationId { get; set; }

    [Display(Name = "To")]
    [Required(ErrorMessage = "Please enter To")]
    public string ToLocationCode { get; set; }

    public short DriverId { get; set; }

    [Display(Name = "Driver Name")]
    [Required(ErrorMessage = "Please enter To City")]
    public string DriverName { get; set; }

    [Display(Name = "Route")]
    [Required(ErrorMessage = "Please select Route")]
    public short RouteId { get; set; }

    [Display(Name = "Reference No")]
    [Required(ErrorMessage = "Please enter Reference No")]
    public string ReferenceNo { get; set; }

    [Display(Name = "Account")]
    [Required(ErrorMessage = "Please enter Account")]
    public short AccountId { get; set; }

    public short DestinationLocationId { get; set; }

    [Display(Name = "Destination")]
    [Required(ErrorMessage = "Please enter Destination")]
    public string DestinationLocationCode { get; set; }

    [Display(Name = "Remarks")]
    public string Remarks { get; set; }

    [Display(Name = "Remarks 1")]
    public string Remarks1 { get; set; }

    [Display(Name = "Remarks 2")]
    public string Remarks2 { get; set; }

    [Display(Name = "Net Packages")]
    public int NetPackages { get; set; }

    [Display(Name = "To Pay")]
    public Decimal ToPay { get; set; }

    [Display(Name = "Truck Freight")]
    public Decimal TruckFreight { get; set; }

    [Display(Name = "Disp. Packages")]
    public int DisplayPackages { get; set; }

    [Display(Name = "Delivery Commission")]
    public Decimal DeliveryCommission { get; set; }

    [Display(Name = "Advance Freight")]
    public Decimal AdvanceFreight { get; set; }

    [Display(Name = "Actual Weight")]
    public Decimal ActualWeight { get; set; }

    [Display(Name = "DO Charge")]
    public Decimal DoCharge { get; set; }

    [Display(Name = "Labour")]
    public Decimal LabourCharges { get; set; }

    [Display(Name = "Charged Weight")]
    public Decimal ChargedWeight { get; set; }

    [Display(Name = "KAT Amount")]
    public Decimal KatAmount { get; set; }

    [Display(Name = "Total Paid Amount")]
    public Decimal TotalPaidAmount { get; set; }

    [Display(Name = "Balance Freight")]
    public Decimal BalanceFreight { get; set; }

    [Display(Name = "Print Freight")]
    public Decimal PrintFreight { get; set; }

    [Display(Name = "PF")]
    public Decimal Pf { get; set; }

    [Display(Name = "Unloading Charge")]
    public Decimal UnloadingCharge { get; set; }

    [Display(Name = "Net Freight")]
    public Decimal NetFreight { get; set; }

    public List<DispatchDocketDetail> Details { get; set; }
  }
}
