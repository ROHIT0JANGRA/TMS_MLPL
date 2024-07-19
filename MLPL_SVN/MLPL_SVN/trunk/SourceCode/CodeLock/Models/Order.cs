//  
// Type: CodeLock.Models.Order
//  
//  
//  

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class Order : Base
  {
    public Order()
    {
      this.OrderNo = "";
      this.OrderDate = DateTime.Now;
      this.IsBillToFromMaster = true;
      this.IsShipToFromMaster = true;
      this.OrderDetails = new List<OrderDetail>();
    }

    public DateTime FromDate { get; set; }

    public DateTime ToDate { get; set; }

    public long OrderId { get; set; }

    [Display(Name = "Order No")]
    public string OrderNo { get; set; }

    [Display(Name = "Order Type")]
    public string OrderType { get; set; }

    [Display(Name = "Order From")]
     public string OrderFrom { get; set; }

    public DateTime OrderDate { get; set; }

    public TimeSpan OrderTime { get; set; }

    [Display(Name = "Order Date Time")]
    public DateTime? OrderDateTime { get; set; }

    [Display(Name = "Customer")]
    [Required(ErrorMessage = "Please enter Customer")]
    public string CustomerCode { get; set; }

    public string CustomerName { get; set; }

    public short CustomerId { get; set; }

    [Required(ErrorMessage = "Please enter Invoice No")]
    [Display(Name = "Invoice No")]
    public string InvoiceNo { get; set; }

    [Display(Name = "Invoice Date")]
    [Required(ErrorMessage = "Please select Invoice Date")]
    public DateTime InvoiceDate { get; set; }

    [Display(Name = "Bill To Details")]
    public bool IsBillToFromMaster { get; set; }

        [Display(Name = "Bill Customer Name")]
        public string BillToFrom { get; set; }

    [DisplayFormat(ConvertEmptyStringToNull = false)]
    [Display(Name = "Address Code")]
    public string BillToAddressCode { get; set; }

    public short BillToAddressId { get; set; }

    [Display(Name = "Bill Customer Address 1")]
    public string BillToAddress1 { get; set; }

    [Display(Name = "Bill Customer Address 2")]
    public string BillToAddress2 { get; set; }

        [Display(Name = "Bill Customer Address 3")]
        public string BillToAddress3 { get; set; }

        [Display(Name = "City")]
    [Required(ErrorMessage = "Please enter City")]
    [DisplayFormat(ConvertEmptyStringToNull = false)]
    public string BillToCity { get; set; }

    public int BillToCityId { get; set; }

    [Display(Name = "Bill Customer Pin Code")]
    [DisplayFormat(ConvertEmptyStringToNull = false)]
    [Required(ErrorMessage = "Please enter Pincode")]
    [StringLength(6, ErrorMessage = "Pincode length between 2 To 6", MinimumLength = 2)]
    public string BillToPincode { get; set; }

    [DisplayFormat(ConvertEmptyStringToNull = false)]
    [MobileAnnotation]
    [Required(ErrorMessage = "Please enter Mobile No")]
    [Display(Name = "Bill Customer Mobile No")]
    public string BillToMobileNo { get; set; }

    [EmailAnnotation]
    [Display(Name = "Bill Customer Email Id")]
    [DisplayFormat(ConvertEmptyStringToNull = false)]
    public string BillToEmailId { get; set; }

    [StringLength(15, ErrorMessage = "TIN No. Length between 2 To 15", MinimumLength = 2)]
    [Display(Name = "TIN No")]
    [DisplayFormat(ConvertEmptyStringToNull = false)]
    public string BillToTinNo { get; set; }

    [StringLength(15, ErrorMessage = "CST No. Length between 2 To 15", MinimumLength = 2)]
    [DisplayFormat(ConvertEmptyStringToNull = false)]
    [Display(Name = "CST No")]
    public string BillToCstNo { get; set; }

    [Display(Name = "Ship To Details")]
    public bool IsShipToFromMaster { get; set; }

    [Display(Name = "Ship Customer Name")]
    public string ShipToFrom { get; set; }

    [DisplayFormat(ConvertEmptyStringToNull = false)]
    [Display(Name = "Address Code")]
    public string ShipToAddressCode { get; set; }

    public short ShipToAddressId { get; set; }

    [Display(Name = "Ship Customer Address 1")]
    public string ShipToAddress1 { get; set; }

    [Display(Name = "Ship Customer Address 2")]
    [Required(ErrorMessage = "Please enter Address 2")]
    public string ShipToAddress2 { get; set; }

        [Display(Name = "Ship Customer Address 3")]
        [Required(ErrorMessage = "Please enter Address 2")]
        public string ShipToAddress3 { get; set; }


        [DisplayFormat(ConvertEmptyStringToNull = false)]
    [Required(ErrorMessage = "Please enter City")]
    [Display(Name = "City")]
    public string ShipToCity { get; set; }

    public int ShipToCityId { get; set; }

    [Required(ErrorMessage = "Please enter Pincode")]
    [StringLength(6, ErrorMessage = "Pincode length between 2 To 6", MinimumLength = 2)]
    [Display(Name = "Pincode")]
    [DisplayFormat(ConvertEmptyStringToNull = false)]
    public string ShipToPincode { get; set; }

    [Display(Name = "Mobile No")]
    [DisplayFormat(ConvertEmptyStringToNull = false)]
    [MobileAnnotation]
    [Required(ErrorMessage = "Please enter Mobile No")]
    public string ShipToMobileNo { get; set; }

    [DisplayFormat(ConvertEmptyStringToNull = false)]
    [EmailAnnotation]
    [Display(Name = "Email Id")]
    public string ShipToEmailId { get; set; }

    [StringLength(15, ErrorMessage = "TIN No. Length between 2 To 15", MinimumLength = 2)]
    [Display(Name = "TIN No")]
    [DisplayFormat(ConvertEmptyStringToNull = false)]
    public string ShipToTinNo { get; set; }

    [StringLength(15, ErrorMessage = "CST No. Length between 2 To 15", MinimumLength = 2)]
    [Display(Name = "CST No")]
    [DisplayFormat(ConvertEmptyStringToNull = false)]
    public string ShipToCstNo { get; set; }

    public bool IsCancel { get; set; }

    public DateTime? CancelDate { get; set; }

    public string CancelReason { get; set; }

    public string EntryByName { get; set; }

    [Required(ErrorMessage = "Please select atleast one record")]
    public List<OrderDetail> OrderDetails { get; set; }
        public int column { get; internal set; }
        public string dir { get; internal set; }
    }
}
