//  
// Type: CodeLock.Models.VendorContractDocketBased
//  
//  
//  

using System;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
	public class VendorContractDocketBased : BaseModel
	{
		public short ContractId { get; set; }

		public byte VendorTypeId { get; set; }

		[Display(Name = "From City")]
		[Required(ErrorMessage = "Please select From City")]
		public short FromLocationId { get; set; }

		[Display(Name = "To Location")]
		[Required(ErrorMessage = "Please select To Location")]
		public short ToLocationId { get; set; }

		[Required(ErrorMessage = "Please select Pay Basis")]
		[Display(Name = "Pay Basis")]
		public byte PaybasId { get; set; }

		[Required(ErrorMessage = "Please select Mode")]
		[Display(Name = "Transport Mode")]
		public byte TransportModeId { get; set; }

		[Display(Name = "Booking / Delivery")]
		[Required(ErrorMessage = "Please select Is Booking/Delivery")]
		public bool IsBooking { get; set; }

		[Display(Name = "BA Contract Type")]
		public short BaContractTypeId { get; set; }

		[Display(Name = "Service Type")]
		public byte ServiceType { get; set; }

		[Display(Name = "Rate of Labour Type")]
		public byte RateofLabourType { get; set; }

		[Display(Name = "Rate of Labour")]
		[Range(0.0, 9999999999.0, ErrorMessage = "Please enter rate of labour between 0 to 9999999999")]
		public Decimal RateofLabour { get; set; }

		[Display(Name = "Slab From")]
		[Range(0, 999999999, ErrorMessage = "Please enter Slab From greater than zero")]
		[Required(ErrorMessage = "Please enter Slab From")]
		public Decimal SlabFrom { get; set; }

		[Display(Name = "Slab To")]
		[Required(ErrorMessage = "Please enter Slab To")]
		[Range(0, 999999999, ErrorMessage = "Please enter Slab To greater than zero")]
		public Decimal SlabTo { get; set; }

		[Display(Name = "Weight Type")]
		public byte WeightType { get; set; }


		[Display(Name = "Is Door Pickup")]
		public bool IsBaDoorPickup { get; set; }

		[Display(Name = "Is Door Delivery")]
		public bool IsBaDoorDelivery { get; set; }

		[Display(Name = "Product Type")]
		[Required(ErrorMessage = "Please select Product Type")]
		public short ProductTypeId { get; set; }

		[Required(ErrorMessage = "Please select Packaging Type")]
		[Display(Name = "Packaging Type")]
		public byte PackagingTypeId { get; set; }

		[Required(ErrorMessage = "Please select Minimum Charge / C Note")]
		[Range(0.0, 9999999999.0, ErrorMessage = "Please enter Minimum Charge / C Note between 0 to 9999999999")]
		[Display(Name = "Minimum Charge / C Note")]
		public Decimal MinimumCharge { get; set; }

		[Range(0.0, 9999999999.0, ErrorMessage = "Please enter Maximum Charge / C Note between 0 to 9999999999")]
		[Display(Name = "Maximum Charge / C Note")]
		[Required(ErrorMessage = "Please select Maximum Charge / C Note")]
		public Decimal MaximumCharge { get; set; }

		[Display(Name = "Rate Type")]
		[Required(ErrorMessage = "Please select Rate Type")]
		public byte RateTypeId { get; set; }

		[Required(ErrorMessage = "Please enter Rate")]
		[Range(0.0, 9999999999.0, ErrorMessage = "Please enter Rate between 0 to 9999999999")]
		[Display(Name = "Rate")]
		public Decimal Rate { get; set; }

		[Required(ErrorMessage = "Please enter From Location")]
		public string FromLocationCode { get; set; }

		[Required(ErrorMessage = "Please enter To Location")]
		public string ToLocationCode { get; set; }
	}
}
