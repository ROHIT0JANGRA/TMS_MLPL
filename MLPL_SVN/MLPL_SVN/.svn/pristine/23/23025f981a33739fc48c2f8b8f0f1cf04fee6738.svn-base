using System;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class CustomerContractBillingInfo : BaseModel
  {
    [Display(Name = "Contract Id")]
    public short ContractId { get; set; }

    [Display(Name = "Bill Location Rule")]
    public byte BillLocationRule { get; set; }

    [Display(Name = "Bill Generation Location")]
    public short? BillGenerationLocationId { get; set; }

    [Display(Name = "Bill Submission Location")]
    [Required(ErrorMessage = "Please select Bill Submission Location")]
    public short BillSubmissionLocationId { get; set; }

    [Display(Name = "Bill Collection Location")]
    [Required(ErrorMessage = "Please select Bill Collection Location")]
    public short BillCollectionLocationId { get; set; }

    [Required(ErrorMessage = "Please enter Credit Days")]
    [Display(Name = "Credit Days")]
    public byte CreditDays { get; set; }

    [Required(ErrorMessage = "Please enter Credit Limit")]
    [Display(Name = "Credit Limit")]
    public Decimal CreditLimit { get; set; }

    [Display(Name = "Use Communication Address As Billing Address")]
    public bool UseCommunicationAddressAsBillingAddress { get; set; }

    [Required(ErrorMessage = "Please enter Address1")]
    [StringLength(300, ErrorMessage = "Address1 must be minimum 2 and maximum 300 character long", MinimumLength = 2)]
    [Display(Name = "Address1")]
    public string Address1 { get; set; }

    [Required(ErrorMessage = "Please enter Address2")]
    [StringLength(300, ErrorMessage = "Address2 must be minimum 2 and maximum 300 character long", MinimumLength = 2)]
    [Display(Name = "Address2")]
    public string Address2 { get; set; }

    [Required(ErrorMessage = "Please select City Name")]
    [Display(Name = "City")]
    public int CityId { get; set; }

    [Required(ErrorMessage = "Please enter Pincode")]
    [Display(Name = "Pincode")]
    public string Pincode { get; set; }

    [Required(ErrorMessage = "Please enter Mobile No")]
    [Display(Name = "Mobile No")]
    [MobileAnnotation]
    public string MobileNo { get; set; }

    [StringLength(50, ErrorMessage = "Bank Name must be minimum 2 and maximum 50 character long", MinimumLength = 2)]
    [Display(Name = "Bank Name")]
    public string BankName { get; set; }

    [Display(Name = "Branch Name")]
    [StringLength(50, ErrorMessage = "Branch Name must be minimum 2 and maximum 50 character long", MinimumLength = 2)]
    public string BranchName { get; set; }

    [Display(Name = "Bank Account No")]
    public string BankAccountNo { get; set; }

    [Display(Name = "TurnOver")]
    public Decimal TurnOver { get; set; }

    [Display(Name = "Country")]
    public byte CountryId { get; set; }

    [Display(Name = "State")]
    public short StateId { get; set; }
  }
}
