//  
// Type: CodeLock.Models.Vr
//  
//  
//  

using System;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class Vr : BaseModel
  {
    public long VrId { get; set; }

    [Display(Name = "Vehicle Request No")]
    public string VrNo { get; set; }

    [Display(Name = "Billing Party")]
    public short CustomerId { get; set; }

    [Required(ErrorMessage = "Please enter Billing Party")]
    public string CustomerCode { get; set; }

    public string CustomerName { get; set; }

    [Display(Name = "Branch")]
    public short LocationId { get; set; }

    [Required(ErrorMessage = "Please enter Branch")]
    public string LocationCode { get; set; }

    public DateTime VrDate { get; set; }

    public TimeSpan VrTime { get; set; }

    [Display(Name = "Request Date Time")]
    public DateTime? VrDateTime { get; set; }

    [Required(ErrorMessage = "Please select Transport Mode")]
    [Display(Name = "Transport Mode")]
    public byte TransportModeId { get; set; }

    [Display(Name = "Placement Date")]
    public DateTime PlacementDate { get; set; }

    [Display(Name = "From City")]
    public int FromCityId { get; set; }

    [Display(Name = "To City")]
    public int ToCityId { get; set; }

    [Display(Name = "Consignor Code")]
    public short ConsignorId { get; set; }

    [Display(Name = "Consignor Code")]
    [Required(ErrorMessage = "Please enter Consignor Code")]
    public string ConsignorCode { get; set; }

    [Required(ErrorMessage = "Please enter Consignor Name")]
    [Display(Name = "Consignor Name")]
    public string ConsignorName { get; set; }

    [Required(ErrorMessage = "Please enter Consignor Address")]
    [Display(Name = "Consignor Address")]
    public string ConsignorAddress { get; set; }

    [Display(Name = "Consignor Pincode")]
    [Required(ErrorMessage = "Please enter Consignor Pincode")]
    public string ConsignorPincode { get; set; }

    [MobileAnnotation]
    [Required(ErrorMessage = "Please enter Consignor Mobile Number")]
    [Display(Name = "Consignor MobileNo")]
    public string ConsignorMobileNo { get; set; }

    [Required(ErrorMessage = "Please enter Consignor Email Id")]
    [EmailAnnotation]
    [Display(Name = "Consignor EmailId")]
    public string ConsignorEmailId { get; set; }

    [Display(Name = "Consignee Code")]
    public short ConsigneeId { get; set; }

    [Display(Name = "Consignee Code")]
    [Required(ErrorMessage = "Please enter Consignee Code")]
    public string ConsigneeCode { get; set; }

    [Display(Name = "Consignee Name")]
    [Required(ErrorMessage = "Please enter Consignee Name")]
    public string ConsigneeName { get; set; }

    [Required(ErrorMessage = "Please enter Consignee Address")]
    [Display(Name = "Consignee Address")]
    public string ConsigneeAddress { get; set; }

    [Display(Name = "Consignee Pincode")]
    [Required(ErrorMessage = "Please enter Consignee Pincode")]
    public string ConsigneePincode { get; set; }

    [Required(ErrorMessage = "Please enter Consignee Mobile Number")]
    [Display(Name = "Consignee MobileNo")]
    [MobileAnnotation]
    public string ConsigneeMobileNo { get; set; }

    [Required(ErrorMessage = "Please enter Consignee Email Id")]
    [Display(Name = "Consignee EmailId")]
    [EmailAnnotation]
    public string ConsigneeEmailId { get; set; }

    [Display(Name = "Remarks")]
    [Required(ErrorMessage = "Please enter Remark")]
    public string Remarks { get; set; }

    [Display(Name = "Content")]
    public byte ProductTypeId { get; set; }

    [Required(ErrorMessage = "Please select Business Type")]
    [Display(Name = "Business Type")]
    public byte BusinessTypeId { get; set; }

    [Display(Name = "Customer Reference No")]
    [Required(ErrorMessage = "Please enter Customer Reference No")]
    public string CustomerReferenceNo { get; set; }

    [Required(ErrorMessage = "Please enter Customer Reference Gatepass No")]
    [Display(Name = "Customer Reference Gatepass No")]
    public string CustomerReferenceGatePassNo { get; set; }

    [Required(ErrorMessage = "Please enter Customer Delivery No")]
    [Display(Name = "Customer Delivery No")]
    public string CustomerDeliveryNo { get; set; }

    [Display(Name = "Packages")]
    [Required(ErrorMessage = "Please enter Packages")]
    public int Packages { get; set; }

    [Required(ErrorMessage = "Please enter Actual Weight")]
    [Display(Name = "Actual Weight")]
    public Decimal ActualWeight { get; set; }

    [Display(Name = "Vendor")]
    public short? VendorId { get; set; }

    [Display(Name = "Vendor Name")]
    public string VendorName { get; set; }

    public short? VehicleId { get; set; }

    [Display(Name = "Vehicle No")]
    public string VehicleNo { get; set; }

    [Required(ErrorMessage = "Please enter From City")]
    public string FromCity { get; set; }

    [Required(ErrorMessage = "Please enter To City")]
    public string ToCity { get; set; }

    public long? DocketId { get; set; }

    [Display(Name = "Docket No")]
    public string DocketNo { get; set; }

    [Display(Name = "Vendor Type")]
    [Required(ErrorMessage = "Please select Vendor Type")]
    public byte VendorTypeId { get; set; }

    public bool IsClose { get; set; }

    public DateTime? CloseDate { get; set; }

    [Display(Name = "Manual No")]
    public string ManualNo { get; set; }
  }
}
