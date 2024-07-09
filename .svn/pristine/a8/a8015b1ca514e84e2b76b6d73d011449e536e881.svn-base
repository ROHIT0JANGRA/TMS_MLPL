
using System;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class AsnDetail
  {
    public DateTime AsnDate { get; set; }

    [Required(ErrorMessage = "Please select Sku")]
    [Display(Name = "Sku")]
    [DisplayFormat(ConvertEmptyStringToNull = false)]
    public string SkuCode { get; set; }

    public string SkuName { get; set; }

    public int SkuId { get; set; }

    public string SkuDescription { get; set; }

    public bool IsSerialNumber { get; set; }

    public bool? IsSingle { get; set; }

    public long Packages { get; set; }

    public string Uom { get; set; }

    public Decimal UomQuantity { get; set; }

    [Range(0.001, 999999999.0, ErrorMessage = "Please enter Packages greater than zero")]
    public int Box { get; set; }

    [Range(0.001, 999999999.0, ErrorMessage = "Please enter Packages greater than zero")]
    public Decimal Volume { get; set; }

    [Required(ErrorMessage = "Please enter Batch Number")]
    public string BatchNumber { get; set; }

    public DateTime? ManufacturingDate { get; set; }

    public DateTime? ExpiryDate { get; set; }

    public Decimal UnitPrice { get; set; }

    public byte Coupon { get; set; }

    public Decimal Quantity { get; set; }
  }
}
