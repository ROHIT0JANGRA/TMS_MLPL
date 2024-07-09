//  
// Type: CodeLock.Models.MasterState
//  
//  
//  

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CodeLock.Models
{
  public class MasterState : BaseModel
  {
    public MasterState()
    {
      this.MasterStateDocumentList = new List<MasterStateDocument>();
    }

    [Required(ErrorMessage = "Please select Country Name")]
    [Display(Name = "Country Name")]
    public byte CountryId { get; set; }

    public short StateId { get; set; }

    [Required(ErrorMessage = "Please enter State Name")]
    [StringLength(50, ErrorMessage = "State Name must be minimum 2 and maximum 50 character long", MinimumLength = 2)]
    [Remote("IsStateNameAvailable", "State", AdditionalFields = "StateId,_StateIdToken", ErrorMessage = "State Name already exists.", HttpMethod = "POST")]
    [Display(Name = "State Name")]
    public string StateName { get; set; }

    [Range(1, 50, ErrorMessage = "State Code must be between 1 and 50")]
    [Remote("IsStateCodeAvailable", "State", AdditionalFields = "StateId,_StateIdToken", ErrorMessage = "State Code already exists.", HttpMethod = "POST")]
    public byte StateCode { get; set; }

    [Display(Name = "Is Service Tax Exempted")]
    public bool IsServiceTaxExempted { get; set; }

    [Display(Name = "Is Union Territory")]
    public bool IsUnionTerritory { get; set; }

    [Display(Name = "Service Tax Exempted")]
    public string ServiceTaxExempted { get; set; }

    [Display(Name = "Country Name")]
    public string CountryName { get; set; }

    public List<MasterStateDocument> MasterStateDocumentList { get; set; }
  }
}
