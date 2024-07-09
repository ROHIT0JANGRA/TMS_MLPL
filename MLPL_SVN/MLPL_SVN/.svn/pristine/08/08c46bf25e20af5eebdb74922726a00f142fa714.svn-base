using ExpressiveAnnotations.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class ChangeAdvanceBalanceLocation : BaseModel
  {
        public ChangeAdvanceBalanceLocation()
        {
           
            this.AdvBalPmtDtl = new List<ThcAdvBalPaymnt_Details>();

        }
        public long DocumentId { get; set; }

    [Display(Name = "Vendor")]
    public string VendorId { get; set; }

    [Display(Name = "Vendor Name")]
    public string VendorName { get; set; }

    [Display(Name = "Document No")]
    [Required(ErrorMessage = "Please Enter Document No.")]
     public string DocumentNo { get; set; }

    [Display(Name = "Booking Location")]
    public string BookingLocation { get; set; }

    public long AdvanceLocationId { get; set; }

    [Display(Name = "Advance Location")]
    public string AdvanceLocationCode { get; set; }

    public long BalanceLocationId { get; set; }

    [Display(Name = "Balance Location")]
    public string BalanceLocationCode { get; set; }

    public bool IsValidForAdvanceLocChange { get; set; }

    public bool IsValidForBalanceLocChange { get; set; }

    public string DocumentType { get; set; }

    [Range(0.0, 9999999999.0, ErrorMessage = "Please enter Advance Amount between 0 to 9999999999")]
    [Display(Name = "Advance Amount")]
    [AssertThat("ContractAmount >= AdvanceAmount", ErrorMessage = "Advance Amount is must be less than or equal to Contract Amount")]
    public Decimal AdvanceAmount { get; set; }

    public Decimal OtherAmount { get; set; }

    [Range(1.0, 9999999999.0, ErrorMessage = "Please enter Contract Amount must be greater then 0")]
    [Display(Name = "Contract Amount")]
    [Required(ErrorMessage = "Please enter Contract Amount")]
    public Decimal ContractAmount { get; set; }

    public bool IsMultiAdvApply { get; set; }
        [Display(Name = "Actual Weight")]
        public decimal TotalActualWeight { get; set; }
        [Display(Name = "Kanta Weight")]
        public decimal KantaWeight { get; set; }
        [Display(Name = "Slip No.")]
        public string SlipNo { get; set; }
        [Display(Name = "Reason For Weight Loss")]
        public string ReasonForWeightLoss { get; set; }
        public bool IsMultiAdvApplyfix { get; set; }
     public List<ThcAdvBalPaymnt_Details> AdvBalPmtDtl { get; set; }

    public List<MasterCharge> ChargeList { get; set; }
  }
}
