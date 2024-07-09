using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
    public class CustomerContractFleetCharge : Base
    {
        public short ContractId { get; set; }
        public short CustomerId { get; set; }

        public short vendorTypeId { get; set; }
        public long vendorId { get; set; }

        public byte BaseOn1 { get; set; }

        public byte BaseCode1 { get; set; }

        public byte BaseOn2 { get; set; }

        public short BaseCode2 { get; set; }

        public byte ChargeCode { get; set; }

        public byte TransportModeId { get; set; }

        public bool IsBooking { get; set; }

        public short ConsignorId { get; set; }

        public short ConsigneeId { get; set; }

        [Display(Name = "FTL Type")]
        public byte FtlTypeId { get; set; }

        public byte MatrixType { get; set; }

        public short ToLocation { get; set; }
        public string To { get; set; }

        [Display(Name = "Rate Type")]
        public byte RateType { get; set; }

        [Required(ErrorMessage = "Please enter To")]
        [Display(Name = "To")]
        public string ToLocationCode { get; set; }

        [Required(ErrorMessage = "Please select Vehicle")]
        [Display(Name = "Vehicle")]
        public short VehicleId { get; set; }

        [Required(ErrorMessage = "Please enter Fixed Amount")]
        [Range(1.0, 9999999999.0, ErrorMessage = "Please enter Fixed Amount")]
        [Display(Name = "Fixed Amount")]
        public Decimal FixedAmount { get; set; }

        [Display(Name = "Fixed KM")]
        [Required(ErrorMessage = "Please enter Fixed KM")]
        [Range(1.0, 9999999999.0, ErrorMessage = "Please enter Fixed KM")]
        public Decimal FixedKm { get; set; }

        [Display(Name = "Fixed Days")]
        [Required(ErrorMessage = "Please enter Fixed Days")]
        [Range(1.0, 9999999999.0, ErrorMessage = "Please enter Fixed Days")]
        public Decimal FixedDays { get; set; }

        [Range(1.0, 9999999999.0, ErrorMessage = "Please enter Variable Rate")]
        [Display(Name = "Variable Rate/KM")]
        [Required(ErrorMessage = "Please enter Variable Rate")]
        public Decimal VariableRate { get; set; }

        [Range(1, 9999999999, ErrorMessage = "Please enter Extra Days Rate")]
        [Display(Name = "Extra Days Rate/Day")]
        [Required(ErrorMessage = "Please enter Extra Days Rate")]
        public Decimal ExtraDaysRate { get; set; }

        [Range(1, 9999999999, ErrorMessage = "Please enter Extra Hours Rate")]
        [Display(Name = "Extra Hours Rate/Hour")]
        [Required(ErrorMessage = "Please enter Extra Hours Rate")]
        public Decimal ExtraHoursRate { get; set; }
        
        [Range(1, 9999999999, ErrorMessage = "Please enter Working Hrs")]
        [Display(Name = "Working Hrs")]
        [Required(ErrorMessage = "Please enter Working Hrs")]
        public Decimal WorkingHours { get; set; }

        [Range(1.0, 9999999999.0, ErrorMessage = "Please enter Other Fixed Amount")]
        [Display(Name = "Other Fixed Amount")]
        [Required(ErrorMessage = "Please enter Other Fixed Amount")]
        public Decimal OtherFixedAmount { get; set; }

        [Required(ErrorMessage = "Please select Product")]
        [Display(Name = "Product")]
        public byte ProductId { get; set; }

        public bool IsMilkrunHrsPerDayEnabled { get; set; }

        public bool IsLaneEnabled { get; set; }

        [Display(Name = "Contract Type")]
        [Required(ErrorMessage = "Please select Contract Type")]
        public string ContractType { get; set; }



        #region Lane Details

        public long ID { get; set; }

        [Display(Name = "Lane Id")]
        public string LaneId { get; set; }

        [Display(Name = "Mother Lane Id")]
        public string MasterLaneId { get; set; }

        [Display(Name = "Route")]
        public string RouteName { get; set; }

        [Display(Name = "Vehicle Size")]
        public string FTLTypeDesc { get; set; }

        [Display(Name = "Fuel Type")]
        public string FuelTypeDesc { get; set; }

        [Display(Name = "Contracted KM")]
        public long ContractedKM { get; set; }

        [Display(Name = "Asset Count")]
        public long AssetCount { get; set; }

        [Display(Name = "Driver Count")]
        public long DriverCount { get; set; }

        [Range(1.0, 9999999999.0, ErrorMessage = "Please enter Total Fixed Charge/Trip")]
        [Display(Name = "Total Fixed Charge/Trip")]
        [Required(ErrorMessage = "Total Fixed Charge/Trip is Required")]
        public decimal FixedChargePerTrip { get; set; }

        [Range(1.0, 9999999999.0, ErrorMessage = "Please enter Variable Base Amt./Trip")]
        [Display(Name = "Variable Base Amt./Trip")]
        [Required(ErrorMessage = "Variable Base Amt is Required")]
        public Decimal VariableBaseAmtPerTrip { get; set; }

        [Range(1.0, 9999999999.0, ErrorMessage = "Please enter Fuel Price")]
        [Display(Name = "Fuel Price")]
        [Required(ErrorMessage = "Fuel Price is Required")]
        public Decimal FuelPrice { get; set; }

        [Range(1.0, 9999999999.0, ErrorMessage = "Please enter Toll Amount")]
        [Display(Name = "Toll Amount")]
        [Required(ErrorMessage = "Toll Amount is Required")]
        public Decimal TollAmount { get; set; }


        #endregion

        public List<CustomerContractFleetCharge> Details { get; set; }
    }
}
