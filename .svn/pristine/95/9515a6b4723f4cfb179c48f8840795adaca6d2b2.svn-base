//  
// Type: CodeLock.Models.VendorContractCrossingBased
//  
//  
//  

using System;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class VendorContractCrossingBased : BaseModel
  {
    public short ContractId { get; set; }

    public byte VendorTypeId { get; set; }

    [Required(ErrorMessage = "Please enter Location")]
    [Display(Name = "Origin")]
    public short FromLocationId { get; set; }

    [Required(ErrorMessage = "Please enter City")]
    [Display(Name = "Destination City")]
    public int ToCityId { get; set; }

    [Display(Name = "Rate Type")]
    [Required(ErrorMessage = "Please select Rate Type")]
    public byte RateTypeId { get; set; }

    [Required(ErrorMessage = "Please enter Rate")]
    [Display(Name = "Rate")]
    [Range(0.0, 9999999999.0, ErrorMessage = "Please enter Rate between 0 to 9999999999")]
    public Decimal Rate { get; set; }

    [Range(0.0, 9999999999.0, ErrorMessage = "Please enter Door Delivery Charge between 0 to 9999999999")]
    [Required(ErrorMessage = "Please enter Door Delivery Charge")]
    [Display(Name = "Door Delivery Charge")]
    public Decimal DoorDeliveryRate { get; set; }

    [Required(ErrorMessage = "Please enter City")]
    public string ToCityName { get; set; }

    [Required(ErrorMessage = "Please enter Location")]
    public string FromLocationCode { get; set; }
  }
}
