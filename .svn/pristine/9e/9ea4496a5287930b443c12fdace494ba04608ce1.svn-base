using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
    public class VendorContractServices : BaseModel
    {
        [Key]
        public short ContractId { get; set; }

        [Display(Name = "Volumetric")]
        public bool UseVolumetric { get; set; }

        [Display(Name = "Volumetric Weight Type")]
        public string VolumetricWeightType { get; set; }

        [Display(Name = "Invoice No")]
        public bool UseInvoiceNo { get; set; }

        [Display(Name = "Invoice Date")]
        public bool UseInvoiceDate { get; set; }

        [Display(Name = "Deferemente Allowed")]
        public bool UseDeferement { get; set; }

        [Display(Name = "Deferment Days")]
        [Required(ErrorMessage = "Deferment Days can not be blank")]
        public byte DefermentDays { get; set; }

        [Display(Name = "Freight As % of Invoice")]
        public bool UseFreightAsInvoicePercentage { get; set; }

        [Display(Name = "Freight Invoice Percentage")]
        [Required(ErrorMessage = "Freight Invoice Percentage can not be blank")]
        public Decimal FreightInvoicePercentage { get; set; }

        [Display(Name = "Freight Discount")]
        public bool UseFreightDiscount { get; set; }

        [Display(Name = "Freight Discount Percentage")]
        [Required(ErrorMessage = "Freight Discount Percentage can not be blank")]
        public Decimal FreightDiscountPercentage { get; set; }

        [Display(Name = "Freight Contract")]
        public short? FreightContractId { get; set; }

        public string FreightManualContractId { get; set; }

        [Display(Name = "Delivery Reattempt")]
        public bool UseDeliveryReattempt { get; set; }

        [Display(Name = "Delivery Reattempt Count")]
        [Required(ErrorMessage = "Delivery Reattempt Count can not be blank")]
        public byte DeliveryReattemptCount { get; set; }

        [Display(Name = "Minimum Freight Type Base Wise")]
        public bool UseMinimumFreightTypeBaseWise { get; set; }

        [Display(Name = "Freight Rate Limit")]
        public bool UseFreightRateLimit { get; set; }

        [Display(Name = "SubTotal Limit")]
        public bool UseSubTotalLimit { get; set; }

        [Display(Name = "COD")]
        public bool UseCod { get; set; }

        [Display(Name = "COD Rate")]
        [Required(ErrorMessage = "COD Rate can not be blank")]
        public Decimal CodRate { get; set; }

        [Display(Name = "COD Rate Type")]
        public byte CodRateType { get; set; }

        [Range(0.0, 9999999999.99, ErrorMessage = "Please enter a value between 0 to 9999999999")]
        [Display(Name = "Minimum COD Amount")]
        [Required(ErrorMessage = "Minimum COD Amount can not be blank")]
        public Decimal MinimumCodAmount { get; set; }

        [Required(ErrorMessage = "Maximum COD Amount can not be blank")]
        [Display(Name = "Maximum COD Amount")]
        public Decimal MaximumCodAmount { get; set; }

        [Display(Name = "DACC")]
        public bool UseDacc { get; set; }

        [Display(Name = "DACC Rate")]
        [Required(ErrorMessage = "DACC Rate can not be blank")]
        public Decimal DaccRate { get; set; }

        [Display(Name = "DACC Rate Type")]
        public byte DaccRateType { get; set; }

        [Range(0.0, 9999999999.99, ErrorMessage = "Please enter a value between 0 to 9999999999")]
        [Required(ErrorMessage = "Minimum DACC Amount can not be blank")]
        [Display(Name = "Minimum DACC Amount")]
        public Decimal MinimumDaccAmount { get; set; }

        [Display(Name = "Maximum DACC Amount")]
        [Required(ErrorMessage = "Maximum DACC Amount can not be blank")]
        public Decimal MaximumDaccAmount { get; set; }

        [Display(Name = "Octroi")]
        public bool UseOctroi { get; set; }

        [Required(ErrorMessage = "Octroi Rate can not be blank")]
        [Display(Name = "Octroi Rate")]
        public Decimal OctroiRate { get; set; }

        [Display(Name = "Octroi Rate Type")]
        public byte OctroiRateType { get; set; }

        [Range(0.0, 9999999999.99, ErrorMessage = "Please enter a value between 0 to 9999999999")]
        [Required(ErrorMessage = "Minimum Octroi Amount can not be blank")]
        [Display(Name = "Minimum Octroi Amount")]
        public Decimal MinimumOctroiAmount { get; set; }

        [Required(ErrorMessage = "Maximum Octroi Amount can not be blank")]
        [Display(Name = "Maximum Octroi Amount")]
        public Decimal MaximumOctroiAmount { get; set; }

        [Display(Name = "Oda")]
        public bool UseOda { get; set; }

        [Display(Name = "Fuel Surcharge")]
        public bool UseFuelSurcharge { get; set; }

        [Display(Name = "Delivery Without Demurrage")]
        public bool UseDeliveryWithoutDemurrage { get; set; }

        [Required(ErrorMessage = "Demurrage Rate can not be blank")]
        [Display(Name = "Demurrage Rate")]
        public Decimal DemurrageRate { get; set; }

        [Required(ErrorMessage = "Please select Demurrage Rate Type ")]
        [Display(Name = "Demurrage Rate Type")]
        public byte DemurrageRateType { get; set; }

        [Range(0.0, 9999999999.99, ErrorMessage = "Please enter a value between 0 to 9999999999")]
        [Required(ErrorMessage = "Minimum Demurrage Amount can not be blank")]
        [Display(Name = "Minimum Demurrage Amount")]
        public Decimal MinimumDemurrageAmount { get; set; }

        [Required(ErrorMessage = "Maximum Demurrage Amount can not be blank")]
        [Display(Name = "Maximum Demurrage Amount")]
        public Decimal MaximumDemurrageAmount { get; set; }

        [Display(Name = "Demurrage Free Storage Days")]
        [Required(ErrorMessage = "Demurrage Free Storage Day can not be blank")]
        public byte DemurrageFreeStorageDays { get; set; }

        [Display(Name = "Demurrage BasInclusive Storage Days")]
        public bool UseDemurrageBasInclusiveStorageDays { get; set; }

        [Display(Name = "GST Applicable")]
        public bool IsGstApplicable { get; set; }

        [Display(Name = "Apply Multipoint Charges to")]
        public bool UseMultipointChargesForChild { get; set; }

        [Display(Name = "Risk Type")]
        public bool IsCarrierRisk { get; set; }

        public bool IsFovApplicable { get; set; }

        [Display(Name = "Transport Mode")]
        public MasterGeneral[] TransportMode { get; set; }

        [Display(Name = "Service Type")]
        public MasterGeneral[] ServiceType { get; set; }

        [Display(Name = "Rate Types")]
        public MasterGeneral[] RateTypes { get; set; }

        [Display(Name = "Matrices")]
        public MasterGeneral[] Matrices { get; set; }

        [Display(Name = "Pickup Delivery")]
        public MasterGeneral[] PickupDelivery { get; set; }

        public List<VendorContractRiskMatrix> CarrierDetails { get; set; }

        public List<VendorContractRiskMatrix> OwnerDetails { get; set; }
    }
}
