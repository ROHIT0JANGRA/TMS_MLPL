//  
// Type: ManifestDocket
//  
//  
//  

using System;
using System.ComponentModel.DataAnnotations;

public class ManifestDocket
{
    public ManifestDocket()
    {
        this.IsChecked = false;
        this.IsSuffixDocket = false;
    }

    public long DocketId { get; set; }

    public string DocketNo { get; set; }

    [Display(Name = "Suffix")]
    public string DocketSuffix { get; set; }

    [Display(Name = "Booking Date")]
    public DateTime DocketDate { get; set; }

    [Display(Name = "EDD")]
    public DateTime Edd { get; set; }

    [Display(Name = "Packages")]
    public int DocketPackages { get; set; }

    [Display(Name = "Packages")]
    public int Packages { get; set; }

    public int LoadPackages { get; set; }

    [Display(Name = "Actual Weight")]
    public Decimal ActualWeight { get; set; }

    public Decimal LoadActualWeight { get; set; }

    [Display(Name = "Origin")]
    public string FromLocationCode { get; set; }

    [Display(Name = "Destination")]
    public string ToLocationCode { get; set; }

    [Display(Name = "From City")]
    public string FromCityName { get; set; }

    public short FromCityId { get; set; }

    [Display(Name = "to City")]
    public string ToCityName { get; set; }

    public short ToCityId { get; set; }

    [Display(Name = "Pay Basis")]
    public string Paybas { get; set; }

    [Display(Name = "Transport Mode")]
    public string TransportMode { get; set; }

    public bool IsChecked { get; set; }

    public bool IsSuffixDocket { get; set; }

    public string LastDocketSuffix { get; set; }
    // VendorId
    public long VendorId { get; set; }

    public Decimal KartRate { get; set; }

    public Decimal ChargedWeight { get; set; }

    public Decimal KartAmount { get; set; }

    public Decimal LoadKartAmount { get; set; }
    public Decimal LabourAmount { get; set; }
    public Decimal DeliveryKartAmount { get; set; }
    public Decimal DeliveryLabourAmount { get; set; }
    public Decimal DoorDeliveryBaAmount { get; set; }
    public string ConsignorName { get; set; }
    public string ConsigneeName { get; set; }
    public string DocketNoBarcode { get; set; }
    public string DocketNoBarcodeScan { get; set; }



}
