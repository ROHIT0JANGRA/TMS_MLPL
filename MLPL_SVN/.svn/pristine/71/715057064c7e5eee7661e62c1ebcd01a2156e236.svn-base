//  
// Type: CodeLock.Models.GatePass
//  
//  
//  

using System;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class GatePass : BaseModel
  {
    public GatePass()
    {
      this.GatepassInNo = "";
    }

    public DateTime FromDate { get; set; }

    public DateTime ToDate { get; set; }

    public DateTime FinStartDate { get; set; }

    public DateTime FinEndDate { get; set; }

    [Required(ErrorMessage = "Please Select Gate Pass In Number")]
    [Display(Name = "Gate Pass In Number")]
    public long GatepassInId { get; set; }

    public string GatepassInNo { get; set; }

    public short LocationId { get; set; }

    public string SkuCode { get; set; }

    public string SkuName { get; set; }

    public long Quantity { get; set; }

    public string UOM { get; set; }

    public long BatchNumber { get; set; }

    public DateTime ManufacturingDate { get; set; }

    public DateTime ExpiryDate { get; set; }

    public long MRP { get; set; }

    public long Coupon { get; set; }

    [Display(Name = "Invoice Number")]
    public string InvoiceNo { get; set; }

    public DateTime InvoiceDate { get; set; }

    [Display(Name = "Supplier Type")]
    public byte SupplierType { get; set; }

    public string SupplierTypeName { get; set; }

    [Display(Name = "Purchse Order Number")]
    public string PurchaseOrderNo { get; set; }

    public DateTime PurchaseOrderDate { get; set; }

    [Display(Name = "Gate Pass From Date")]
    [DataType(DataType.DateTime)]
    public DateTime GatepassFromDateTime { get; set; }

    [Display(Name = "Wearhouse")]
    public short WearhouseId { get; set; }

    public string WearhouseName { get; set; }

    [Display(Name = "Client")]
    public string SupplierCode { get; set; }

    public long SupplierId { get; set; }

    public string SupplierName { get; set; }

    [Display(Name = "Client")]
    public short ClientId { get; set; }

    public string ClientName { get; set; }

    [Display(Name = "Entry From")]
    public byte EntryFrom { get; set; }

    [Required(ErrorMessage = "Please select Entry From")]
    [Display(Name = "Entry From Document No.")]
    public long EntryFromId { get; set; }

    [Display(Name = "ASN No")]
    public string AsnNo { get; set; }

    public long AsnId { get; set; }

    public DateTime AsnDate { get; set; }

    [Required(ErrorMessage = "Please Enter Vehicle Number")]
    [Display(Name = "Vehicle Number")]
    public string VehicleNumber { get; set; }

    public DateTime VehicleInDateTime { get; set; }

    [Display(Name = "Transporter")]
    public short TransporterId { get; set; }

    public string TransporterName { get; set; }

    [StringLength(50, ErrorMessage = "Driver Name must be minimum 3 and maximum 50 character long", MinimumLength = 3)]
    [Display(Name = "Driver Name")]
    [Required(ErrorMessage = "Please Enter Driver Name")]
    public string DriverName { get; set; }

    [Required(ErrorMessage = "Please enter Driver Contact Number")]
    [StringLength(50, ErrorMessage = "Driver Contact Number must be minimum 10 and maximum 10 digit long", MinimumLength = 10)]
    [RegularExpression("^\\(?([0-9]{3})\\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entered phone format is not valid.")]
    [Display(Name = "Driver Contact Number")]
    public string DriverMobileNo { get; set; }

    [Display(Name = "Docket Number")]
    [Required(ErrorMessage = "Please Enter Docket Number")]
    public string DockNo { get; set; }

    [Required(ErrorMessage = "Please Enter Vehicle seal Number")]
    [Display(Name = "Vehicle Seal Number ")]
    public string VehicleSealNo { get; set; }

    [Display(Name = "Login Id")]
    public short LoginUserId { get; set; }

    public string UserName { get; set; }
        //Entry From

    }
}
