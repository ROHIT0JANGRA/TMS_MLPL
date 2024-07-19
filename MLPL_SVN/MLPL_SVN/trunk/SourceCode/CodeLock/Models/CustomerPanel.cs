using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeLock.Models
{
	public class CustomerPickup : Base
	{
		public CustomerPickup()
		{
			CustomerPickupDetails = new List<CustomerPickupDetail>();
			InvoiceDetails = new List<CustomerPickupInvoiceDetail>();
		}
		public long PurchaseOrderId { get; set; }
		[Display(Name = "Purchase Order No.")]
		public string PurchaseOrderNo { get; set; }
		[Display(Name = "Purchase Order Date")]
		public DateTime PurchaseOrderDate { get; set; }
		public short SupplierId { get; set; }
		[Display(Name = "Supplier Name")]
		public string SupplierName { get; set; }
		[Display(Name = "Supplier Place")]
		public int SupplierCityId { get; set; }
		public string SupplierCity { get; set; }
		[Display(Name = "Origin")]
		public short OriginId { get; set; }
		public string Origin { get; set; }
		[Display(Name = "Destination")]
		public short DestinationId { get; set; }
		public string Destination { get; set; }
		public string OrderBy { get; set; }
		[Display(Name = "Mobile No.")]
		public string MobileNo { get; set; }
		[Display(Name = "Total Order Quantity")]
		public decimal TotalOrderQuantity { get; set; }
		[Display(Name = "Warehouse")]
		public short WarehouseIds { get; set; }
		public string Warehouse { get; set; }
		[Display(Name = "Picked Quantity")]
		public decimal PickedQuantity { get; set; }
		[Display(Name = "Balance Quantity")]
		public decimal BalanceQuantity { get; set; }
		public string Remarks { get; set; }
		[Display(Name = "Add New")]
		public bool IsAddNew { get; set; }
		[Display(Name = "Print Sticker")]
		public bool IsPrintSticker { get; set; }

		public List<CustomerPickupDetail> CustomerPickupDetails { get; set; }
		public List<CustomerPickupInvoiceDetail> InvoiceDetails { get; set; }
	}

	public class CustomerPickupDetail
	{
		public long PickupId { get; set; }
		[Display(Name = "Pickup No.")]
		public string PickupNo { get; set; }
		[Display(Name = "CD No")]
		public string CDNo { get; set; }
		[Display(Name = "Consignor Referance No.")]
		public string ConsignorReferanceNo { get; set; }
		public byte TransportModeTypeId { get; set; }
		[Display(Name = "Transport Mode Type")]
		public string TransportModeType { get; set; }
		[Display(Name = "Invoice No.")]
		public string InvoiceNo { get; set; }
		[Display(Name = "Invoice Date")]
		public DateTime InvoiceDate { get; set; }
		[Display(Name = "Invoice Value")]
		public decimal InvoiceValue { get; set; }
		[Display(Name = "Eway Bill No")]
		public string EwayBillNo { get; set; }
		[Display(Name = "Eway Bill Expiry Date")]
		public DateTime EwayBillExpiryDate { get; set; }
		[Display(Name = "Pickup Date")]
		public DateTime PickupDate { get; set; }
		[Display(Name = "Pickup Time")]
		public TimeSpan PickupTime { get; set; }
		[Display(Name = "Pickup Quantity")]
		public int PickupQuantity { get; set; }
		[Display(Name = "No Of Boxes")]
		public int NoOfBoxes { get; set; }
		public byte StatusId { get; set; }
		[Display(Name = "Status")]
		public string Status { get; set; }

		public short OriginId { get; set; }
		public string Origin { get; set; }
		[Display(Name = "Origin")]
		public List<CustomerPickupInvoiceDetail> CustomerPickupInvoiceDetails { get; set; }
	}

	public class CustomerPickupInvoiceDetail
	{
		public byte BrandId { get; set; }
		public byte GenderId { get; set; }
		public string StyleId { get; set; }
		public byte ArticalId { get; set; }
		public int Quantity { get; set; }
		public string Remark { get; set; }
	}
}