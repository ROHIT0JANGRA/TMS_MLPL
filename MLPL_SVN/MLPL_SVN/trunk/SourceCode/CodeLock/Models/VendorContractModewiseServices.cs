using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeLock.Models
{
    public class VendorContractModewiseServices
    {
        [Key]
        public short ContractId { get; set; }

        [Display(Name = "Transport Mode")]
        [Required(ErrorMessage = "Please select Transport Mode")]
        public byte TransportModeId { get; set; }

        [Display(Name = "Ratio")]
        public Decimal CftRatio { get; set; }

        [Display(Name = "Volumetric Measure")]
        [Required(ErrorMessage = "Please select Volumetric Measure")]
        public string CftMeasurementType { get; set; }

        [Display(Name = "Start Time")]
        public DateTime CutOffStartTime { get; set; }

        [Display(Name = "End Time")]
        public DateTime CutOffEndTime { get; set; }

        [Display(Name = "Additional Transit Days")]
        public byte CutOffTransitDays { get; set; }

        [Display(Name = "Charge Rate")]
        public Decimal FuelSurchargeRate { get; set; }

        [Display(Name = "Rate Type")]
        [Required(ErrorMessage = "Please select Rate Type")]
        public byte FuelSurchargeRateType { get; set; }

        [Display(Name = "Minimum Charge")]
        [Range(0.0, 9999999999.99, ErrorMessage = "Please enter a value between 0 to 9999999999")]
        public Decimal MinimumFuelSurchargeAmount { get; set; }

        [Display(Name = "Maximum Charge")]
        public Decimal MaximumFuelSurchargeAmount { get; set; }

        [Display(Name = "Minimum Freigh Rate")]
        [Range(0.0, 9999999999.99, ErrorMessage = "Please enter a value between 0 to 9999999999")]
        public Decimal MinimumFreightRate { get; set; }

        [Display(Name = "Freigh Rate Type")]
        public string MinimumFreightRateType { get; set; }

        [Display(Name = "Minimum Freight Amount")]
        [Range(0.0, 9999999999.99, ErrorMessage = "Please enter a value between 0 to 9999999999.99")]
        public Decimal MinimumFreightAmount { get; set; }

        [Range(0.0, 9999999999.99, ErrorMessage = "Please enter a value between 0 to 9999999999")]
        [Display(Name = "Minimum Freight Lower Limit")]
        public Decimal MinimumFreightLowerLimit { get; set; }

        [Display(Name = "Minimum Freight Upper Limit")]
        public Decimal MinimumFreightUpperLimit { get; set; }

        [Display(Name = "Minimum SubTotal Amount")]
        [Range(0.0, 9999999999.99, ErrorMessage = "Please enter a value between 0 to 9999999999")]
        public Decimal MinimumSubTotalAmount { get; set; }

        [Display(Name = "SubTotal Lower Limit")]
        [Range(0.0, 9999999999.99, ErrorMessage = "Please enter a value between 0 to 9999999999")]
        public Decimal SubTotalLowerLimit { get; set; }

        [Display(Name = "SubTotal Upper Limit")]
        public Decimal SubTotalUpperLimit { get; set; }

        [Display(Name = "Default GST Payer")]
        [Required(ErrorMessage = "Please select Default GST Payer")]
        public byte DefaultServiceTaxPayer { get; set; }

        [Display(Name = "Is GST Payer Enabled")]
        public bool IsServiceTaxPayerEnabled { get; set; }

        public string TransportMode { get; set; }

        public bool UseMinimumFreightTypeBaseWise { get; set; }

        public bool IsCreate { get; set; }

        [Display(Name = "GST Payer")]
        public MasterGeneral[] ServiceTaxPayer { get; set; }
    }
}