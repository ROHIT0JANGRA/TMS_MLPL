//  
// Type: CodeLock.Models.DocketHold
//  
//  
//  

using System;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class DocketHold
  {
    public long DocketId { get; set; }

    public long HoldId { get; set; }

    [Required(ErrorMessage = "Please enter Docket No")]
    [DisplayFormat(ConvertEmptyStringToNull = false)]
    [DisplayName("Docket", "DocketNo")]
    public string DocketNo { get; set; }

    [Display(Name = "Date")]
    public DateTime EntryDate { get; set; }

    [Display(Name = "Current Status")]
    public string DocketStatus { get; set; }

    [Display(Name = "Origin")]
    public string FromLocation { get; set; }

    public short FromLocationId { get; set; }

    [Display(Name = "Destination")]
    public string ToLocation { get; set; }

    public short ToLocationId { get; set; }

    [Display(Name = "Consignor")]
    public string ConsignorName { get; set; }

    public short ConsignorId { get; set; }

    [Display(Name = "Consignee")]
    public string ConsigneeName { get; set; }

    public short ConsigneeId { get; set; }

    [Display(Name = "Date Of Booking")]
    public DateTime DocketDate { get; set; }

    [Display(Name = "Entered By")]
    public string EnteredBy { get; set; }

    [Display(Name = "Material Hold Reason")]
    public string HoldReason { get; set; }

    public short HoldBy { get; set; }

    [Display(Name = "Material Hold By")]
    public string HoldByName { get; set; }

    [Display(Name = "Material Hold Date")]
    public DateTime HoldDate { get; set; }

    public short UnholdBy { get; set; }

    [Display(Name = "Material Unhold Date")]
    public DateTime UnholdDate { get; set; }

    public short HoldLocationId { get; set; }

    public short UnholdLocationId { get; set; }

    [Display(Name = "Material Unhold Reason")]
    public string UnholdReason { get; set; }
  }
}
