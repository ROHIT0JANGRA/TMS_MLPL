//  
// Type: CodeLock.Models.DrsDocket
//  
//  
//  

using System;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class DrsDocket
  {
    public long DrsId { get; set; }

    public long DocketId { get; set; }

    public string DocketNo { get; set; }

    [Display(Name = "Suffix")]
    public string DocketSuffix { get; set; }

    [Display(Name = "Consignor Name")]
    public string ConsignorName { get; set; }

    [Display(Name = "Consignee Name")]
    public string ConsigneeName { get; set; }

    [Display(Name = "Booking Date")]
    public DateTime DocketDate { get; set; }

    public DateTime Edd { get; set; }

    [Display(Name = "Committed Delay Date")]
    public DateTime? DeliveryDate { get; set; }

    public DateTime? DeliveryDateTime { get; set; }

    public DateTime? ArrivalDate { get; set; }

    [Display(Name = "Booked Packages")]
    public int BookedPackages { get; set; }

    [Display(Name = "Pending Packages")]
    public int Packages { get; set; }

    [Display(Name = "Arrived Packages")]
    public int ArrivedPackages { get; set; }

    [Display(Name = "Pending Packages")]
    public int PendingPackages { get; set; }

    [Display(Name = "Delivered Packages")]
    public int DeliveredPackages { get; set; }

    [Display(Name = "Actual Weight")]
    public Decimal? ActualWeight { get; set; }

    public Decimal BookedActualWeight { get; set; }

    [Display(Name = "Charge Weight")]
    public Decimal ChargeWeight { get; set; }

    public bool IsMultiDelivery { get; set; }

    [Display(Name = "Origin")]
    public string FromLocationCode { get; set; }

    [Display(Name = "Destination")]
    public string ToLocationCode { get; set; }

    [Display(Name = "Pay Basis")]
    public string Paybas { get; set; }

    public bool IsChecked { get; set; }

    [Required(ErrorMessage = "Please enter Remark")]
    public string Remark { get; set; }

    [Required(ErrorMessage = "Please enter Person Name")]
    [Display(Name = "Person Name")]
    public string PersonName { get; set; }

    [Display(Name = "Delivery Time")]
    [Required(ErrorMessage = "Please enter Delivery Time")]
    public TimeSpan DeliveryTime { get; set; }

    [Required(ErrorMessage = "Please select Late Delivery Reason")]
    [Display(Name = "Late Delivery Reason")]
    public byte? LateDeliveryReasonId { get; set; }

    [Required(ErrorMessage = "Please select Part Delivery Reason")]
    [Display(Name = "Part Delivery Reason")]
    public byte? PartDeliveryReasonId { get; set; }

    [Required(ErrorMessage = "Please select Un Delivery Reason")]
    [Display(Name = "Un Delivery Reason")]
    public byte? UndeliveredReasonId { get; set; }

    [Display(Name = "Kart Amount")]
    public Decimal KartAmount { get; set; }

    public bool UnderDrs { get; set; }

    public string ToCity { get; set; }

    [Display(Name = "Labour Amount")]
    public Decimal LabourAmount { get; set; }
        public string Status { get; set; }
        public string DeliveryPersonName { get; set; }

    }
}
