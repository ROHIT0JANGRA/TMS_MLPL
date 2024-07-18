//  
// Type: CodeLock.Models.StockUpdateDocket
//  
//  
//  

using System;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class StockUpdateDocket
  {
    [Display(Name = "Manifest No")]
    public string ManifestNo { get; set; }

    public long? ManifestId { get; set; }

    public string DocketNo { get; set; }

    public long DocketId { get; set; }

    public string DocketSuffix { get; set; }

    public DateTime DocketDate { get; set; }

    [Display(Name = "Origin")]
    public string FromLocationCode { get; set; }

    [Display(Name = "Destination")]
    public string ToLocationCode { get; set; }

    public short FromLocationId { get; set; }

    public short ToLocationId { get; set; }

    [Display(Name = "Delivery Date")]
    public DateTime DeliveryDate { get; set; }

    public DateTime? DeliveryDateTime { get; set; }

    public string PersonName { get; set; }
        public string UnloadingPersonName { get; set; }

        

    public byte? LateDeliveryReasonId { get; set; }

    [Display(Name = "Arrival Packages")]
    public int ArrivalPackages { get; set; }

    public int StockUpdatedPackages { get; set; }

    [Display(Name = "Arrival Actual Weight")]
    public Decimal ArrivalWeight { get; set; }

    public Decimal StockUpdatedActualWeight { get; set; }

    [Display(Name = "Arrival Condition")]
    [Required(ErrorMessage = "Please select Arrival Condition")]
    public byte ArrivalConditionId { get; set; }

        [Display(Name = "Labour Vendor")]
        public short LabourVendorId { get; set; }

        [Required(ErrorMessage = "Please select Warehouse")]
    [Display(Name = "Warehouse")]
    public byte WareHouseId { get; set; }

    [Required(ErrorMessage = "Please select Delivery Process")]
    [Display(Name = "Delivery Process")]
    public byte DeliveryProcessId { get; set; }

    [Display(Name = "Pickup Delivery Process")]
    public int PickupDeliveryTypeId { get; set; }

    public bool IsChecked { get; set; }

    public short ManifestDestinationId { get; set; }

    public short DocketDestinationId { get; set; }

    public string Remark { get; set; }

    public DepsDocket DepsDetails { get; set; }

    public string FromCity { get; set; }

    public string ToCity { get; set; }

    public bool IsDaccUpdated { get; set; }

    public string DocketNoBarcode { get; set; }
    public string DocketNoBarcodeScan { get; set; }
    public int DocketPackages { get; set; }

    }
}
