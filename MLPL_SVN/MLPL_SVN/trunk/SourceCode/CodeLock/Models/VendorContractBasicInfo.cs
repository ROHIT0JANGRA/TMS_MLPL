//  
// Type: CodeLock.Models.VendorContractBasicInfo
//  
//  
//  

using System;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class VendorContractBasicInfo : BaseModel
  {
    public VendorContractBasicInfo()
    {
      this.ContractId = (short) 0;
      this.ThcMatrixTypeId = (byte) 0;
      this.PrsMatrixTypeId = (byte) 0;
      this.DrsMatrixTypeId = (byte) 0;
    }

    public short ContractId { get; set; }

    [Display(Name = "Contract ID")]
    public string ManualContractId { get; set; }

    [DataType(DataType.DateTime)]
    [Required(ErrorMessage = "Please select Contract Date")]
    [Display(Name = "Contract Date")]
    public DateTime ContractDate { get; set; }

    [Required(ErrorMessage = "Please select Location")]
    [Display(Name = "Location")]
    public short LocationId { get; set; }

    [Display(Name = "Location")]
    public string LocationCode { get; set; }

    [Display(Name = "Vendor Category")]
    [Required(ErrorMessage = "Please select Vendor Category")]
    public byte VendorCategory { get; set; }

    [Display(Name = "Vendor Category")]
    public string VendorCategoryName { get; set; }

    [Required(ErrorMessage = "Please select Contract Category")]
    [Display(Name = "Contract Category")]
    public byte ContractCategory { get; set; }

    [Display(Name = "Contract Category")]
    public string ContractCategoryName { get; set; }

    [Display(Name = "Is TDS Applicable")]
    public bool IsTDSApplicable { get; set; }

    [Range(0, 999, ErrorMessage = "Please enter TDS Rate between 0 to 999")]
    [Display(Name = "TDS Rate")]
    public Decimal TDSRate { get; set; }

    [Required(ErrorMessage = "Please enter Security Deposit Cheque")]
    [Display(Name = "Security Deposit Cheque")]
    public string SecurityDepositCheque { get; set; }

    [DataType(DataType.DateTime)]
    [Display(Name = "Security Deposit Date")]
    public DateTime? SecurityDepositDate { get; set; }

    [Display(Name = "Security Deposit Amount")]
    [Required(ErrorMessage = "Please enter Security Deposit Amount")]
    [Range(0.0, 9999999999.0, ErrorMessage = "Please enter Security Deposit Amount between 0 to 9999999999")]
    public Decimal SecurityDepositAmount { get; set; }

    [Display(Name = "Payment Interval")]
    [Required(ErrorMessage = "Please enter Payment Interval")]
    public string PaymentInterval { get; set; }

    [Display(Name = "Payment Interval")]
    public string PaymentIntervalName { get; set; }

    [Display(Name = "Payment Basis")]
    [Required(ErrorMessage = "Please enter Payment Basis")]
    public string PaymentBasis { get; set; }

    [Required(ErrorMessage = "Please select Payment Location")]
    [Display(Name = "Payment Location")]
    public short? PaymentLocationId { get; set; }

    [Display(Name = "Payment Location")]
    public string PaymentLocationCode { get; set; }

    [Display(Name = "THC Matrix Type")]
    public byte ThcMatrixTypeId { get; set; }

    public string ThcMatrixType { get; set; }

    [Display(Name = "PRS Matrix Type")]
    public byte PrsMatrixTypeId { get; set; }

    public string DrsMatrixType { get; set; }

    [Display(Name = "DRS Matrix Type")]
    public byte DrsMatrixTypeId { get; set; }

    public string PrsMatrixType { get; set; }

    [Display(Name = "Credit Days")]
    [Required(ErrorMessage = "Please enter Credit Days")]
    public byte CreditDays { get; set; }

     [Display(Name = "Docket Matrix Type")]
    public byte DocketMatrixTypeId { get; set; }


    [Required(ErrorMessage = "Please select PayBas Id")]
        [Display(Name = "PayBas")]
        public byte PayBasId { get; set; }
    }
}
