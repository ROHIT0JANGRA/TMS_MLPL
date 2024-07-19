using System;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
    public class CustomerBillSupplementryDetail
    {
        public long BillId { get; set; }

        public short AccountId { get; set; }

        [Required(ErrorMessage = "Please Select SAC")]
        [Display(Name = "SAC")]
        public byte GstSacId { get; set; }

        [Display(Name = "Gst Rate")]
        public Decimal GstRate { get; set; }

        [Display(Name = "RCM")]
        public bool IsRcm { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
        [Required(ErrorMessage = "Please enter amount")]
        [Display(Name = "Amount")]
        public Decimal Amount { get; set; }

        [Display(Name = "GST Amount")]
        public Decimal GstAmount { get; set; }

        [Display(Name = "GST Charged")]
        public Decimal GstCharge { get; set; }

        [Display(Name = "Total Amount")]
        public Decimal TotalAmount { get; set; }

        [Display(Name = "Narration")]
        [Required(ErrorMessage = "Please enter narration")]
        public string Narration { get; set; }

        public byte ServiceTypeId { get; set; }

        [Required(ErrorMessage = "Please enter account code")]
        [Display(Name = "Account Code")]
        public string AccountCode { get; set; }

        [Display(Name = "Area Size")]
        public string AreaSize { get; set; }

        [Display(Name = "Area Located")]
        public short WarehouseId { get; set; }

        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [Display(Name = "Packages")]
        public int Packages { get; set; }

        [Display(Name = "Item Description")]
        public string ItemDescription { get; set; }

        [Required(ErrorMessage = "Please Select HSN")]
        [Display(Name = "HSN")]
        public byte HsnId { get; set; }

        [Required(ErrorMessage = "Please Select Vehicle")]
        [Display(Name = "Vehicle")]
        public short VehicleId { get; set; }

        [Display(Name = "KM")]
        public int Km { get; set; }

        [Display(Name = "Purchase Value")]
        public decimal PurchaseValue { get; set; }

        [Display(Name = "Purchase Date")]
        public DateTime? PurchaseDate { get; set; }

        [Display(Name = "Depreciation Value")]
        public decimal DepreciationValue { get; set; }

        [Display(Name = "TCS Amount")]
        public decimal TcsAmount { get; set; }

        [Display(Name = "Cess")]
        public decimal Cess { get; set; }

        [Display(Name = "Is NOC Declare")]
        public bool IsNocDeclare { get; set; }
    }
}
