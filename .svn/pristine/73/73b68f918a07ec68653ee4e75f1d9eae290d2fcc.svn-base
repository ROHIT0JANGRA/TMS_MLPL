//  
// Type: CodeLock.Models.MasterConsignorConsigneeMapping
//  
//  
//  

using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class MasterConsignorConsigneeMapping : BaseModel
  {
    public short MappingId { get; set; }

    [Display(Name = "Consignor")]
    public short ConsignorId { get; set; }

    [Display(Name = "Consignee")]
    public short ConsigneeId { get; set; }

    [Display(Name = "Billing Party")]
    public short BillingPartyId { get; set; }

    [Display(Name = "Consignor")]
    public string ConsignorName { get; set; }

    [Display(Name = "Consignee")]
    public string ConsigneeName { get; set; }

    [Display(Name = "Billing Party")]
    public string BillingPartyName { get; set; }

    [Required(ErrorMessage = "Please enter Consignor")]
    [Display(Name = "Consignor Code")]
    public string ConsignorCode { get; set; }

    [Display(Name = "Consignee Code")]
    [Required(ErrorMessage = "Please enter Consignee")]
    public string ConsigneeCode { get; set; }

    [Required(ErrorMessage = "Please enter Billing Party")]
    [Display(Name = "BillingParty Code")]
    public string BillingPartyCode { get; set; }
  }
}
