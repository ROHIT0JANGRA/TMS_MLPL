using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
    public class CustomerContractDefineChargeMatrix : BaseModel
    {
        [Display(Name = "Contract Id")]
        public string ManualContractId { get; set; }

        public short ContractId { get; set; }

        [Display(Name = "Booking")]
        public bool IsBooking { get; set; }

        [Display(Name = "Delivery")]
        public bool IsDelivery { get; set; }

        public byte BaseOn { get; set; }

        public byte BaseCode { get; set; }

        [Display(Name = "Charge Based On")]
        [Required(ErrorMessage = "Please select Charge Based On")]
        public byte ChargeBase { get; set; }

        public byte ChargeCode { get; set; }

        [Display(Name = "Charge Name")]
        public string ChargeName { get; set; }

        [Display(Name = "Use Transport Mode")]
        public bool UseTransportMode { get; set; }

        [Display(Name = "Use Rate Type")]
        public bool UseRateType { get; set; }

        [Display(Name = "Use From")]
        public bool UseFrom { get; set; }

        [Display(Name = "Use To")]
        public bool UseTo { get; set; }

        [Display(Name = "Slab Type")]
        [Required(ErrorMessage = "Please select Slab Type")]
        public string SlabType { get; set; }

        [Display(Name = "Use FTL Type")]
        public bool UseFtlType { get; set; }

        [Display(Name = "Use Consignor")]
        public bool UseConsignor { get; set; }

        [Display(Name = "Use Consignee")]
        public bool UseConsignee { get; set; }

        [Display(Name = "Use Part No")]
        public bool UsePartNo{ get; set; }

        [Display(Name = "Use Billing Code")]
        public bool UseBillingCode { get; set; }

        public CustomerContract CustomerContract { get; set; }
    }
}
