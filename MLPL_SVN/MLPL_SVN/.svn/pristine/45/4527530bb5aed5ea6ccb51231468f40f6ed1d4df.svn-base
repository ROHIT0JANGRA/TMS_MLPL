using System;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class CopyCustomerContract : BaseModel
  {
    [Required(ErrorMessage = "Please select Paybas")]
    [Display(Name = "Paybas")]
    public byte PaybasId { get; set; }

    public string Paybas { get; set; }

    [Display(Name = "Customer Name")]
    [Required(ErrorMessage = "Please select Customer Name")]
    public short CustomerId { get; set; }

    [Display(Name = "Customer Name")]
    public string CustomerName { get; set; }

    [Display(Name = "Customer Code")]
    public string CustomerCode { get; set; }

    public short ContractId { get; set; }

    [Display(Name = "Contract Id")]
    public string ManualContractId { get; set; }

    [DataType(DataType.DateTime)]
    [Required(ErrorMessage = "Please select Start Date")]
    [Display(Name = "Start Date")]
    public DateTime StartDate { get; set; }

    [Required(ErrorMessage = "Please select End Date")]
    [Display(Name = "End Date")]
    [DataType(DataType.DateTime)]
    public DateTime EndDate { get; set; }

    [Display(Name = "Contract Date")]
    [Required(ErrorMessage = "Please select Contract Date")]
    [DataType(DataType.DateTime)]
    public DateTime ContractDate { get; set; }

    public bool IsCustomerContract { get; set; }

    [Display(Name = "Existing Contract Id")]
    [Required(ErrorMessage = "Please select Copy Contract Id")]
    public string ExistingManualContractId { get; set; }

    [Display(Name = "Existing Contract Id")]
    [Required(ErrorMessage = "Please select Copy Contract Id")]
    [Range(1, 99999999, ErrorMessage = "Please select Copy Contract Id")]
    public short ExistingContractId { get; set; }
  }
}
