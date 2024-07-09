
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class ContractKeys : Response
  {
    public ContractKeys()
    {
      this.IsBooking = true;
    }

    public bool IsOda { get; set; }

    public bool IsCod { get; set; }

    public bool IsDacc { get; set; }

    public bool IsCarrierRisk { get; set; }

    public bool IsFound { get; set; }

    public string ContractFrom { get; set; }

    public DateTime DocketDate { get; set; }

    public DateTime Edd { get; set; }

    public short ContractId { get; set; }

    public short FreightContractId { get; set; }

    public byte TransportModeId { get; set; }

    public bool IsBooking { get; set; }

    public byte BaseOn1 { get; set; }

    public byte BaseCode1 { get; set; }

    public byte BaseOn2 { get; set; }

    public byte BaseCode2 { get; set; }

    public byte[] MatrixTypes { get; set; }

    public short FromLocationId { get; set; }

    public short ToLocationId { get; set; }

    public int FromCityId { get; set; }

    public int ToCityId { get; set; }

    public short FromZoneId { get; set; }

    public short ToZoneId { get; set; }

    public byte FtlTypeId { get; set; }

    public byte ServiceTypeId { get; set; }

    public short PaybasId { get; set; }

    public string Behaviour { get; set; }

    public string Search { get; set; }

    public byte ChargeCode { get; set; }

    public int Packages { get; set; }

    public Decimal ChargedWeight { get; set; }

    public Decimal InvoiceAmount { get; set; }

    public Decimal Freight { get; set; }

    public Decimal FreightRate { get; set; }

    public Decimal ChargeRate { get; set; }

    public byte RateTypeId { get; set; }

    public byte TransitDays { get; set; }

    public short BillLocationId { get; set; }

    public string BillLocationCode { get; set; }

    public short ConsignorId { get; set; }

    public short ConsigneeId { get; set; }

    public byte DefaultServiceTaxPayer { get; set; }

    public bool IsServiceTaxPayerEnabled { get; set; }

    public bool IsFovChargeApplicable { get; set; }

    public bool IsRoundOff { get; set; }

    public bool IsBindAllGstState { get; set; }

    public char IsFreightEnaledDisabled { get; set; }
    public bool IsManualBillLocationEntry { get; set; }

    public Int32 MinimumCalculatedPackage { get; set; }

    public Decimal MinimumCalculatedChargeWeight { get; set; }

    public Decimal MinimumCalculatedFreightRate { get; set; }

    public Decimal MinimumCalculatedFreight { get; set; }

    public string MinimumCalculatedFreightRateType { get; set; }

    public string MinimumFreightMessage { get; set; }

        [Required(ErrorMessage = "Please select Apply Rate Type")]
        [Display(Name = "Apply Rate Type")]
        public string ApplyRateType { get; set; }

        [Display(Name = "FreightGM")]
        public Decimal FreightGM { get; set; }

        [Display(Name = "FreightKG")]
        public Decimal FreightKG { get; set; }

        [Display(Name = "Slab Type")]
        public string ContractSlabType { get; set; }
    }
}
