//  
// Type: CodeLock.Models.DocketBookingChallanDetail
//  
//  
//  

using System;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class DocketBookingChallanDetail
  {
    public long DocketId { get; set; }

    [DisplayName("Docket", "DocketNo")]
    [DisplayFormat(ConvertEmptyStringToNull = false)]
    public string DocketNo { get; set; }

    [DisplayName("Docket", "DocketDate")]
    public DateTime DocketDate { get; set; }

    [Required(ErrorMessage = "Please select Paybas")]
    [Display(Name = "Paybas")]
    public byte PaybasId { get; set; }

    [DisplayName("Docket", "FromCity")]
    public string FromCity { get; set; }

    public int FromCityId { get; set; }

    [DisplayName("Docket", "ToCity")]
    public string ToCity { get; set; }

    public int ToCityId { get; set; }

    [Required(ErrorMessage = "Please enter Consignor Name")]
    [Display(Name = "Consignor Name")]
    public string ConsignorName { get; set; }

    [Required(ErrorMessage = "Please enter Consignee Name")]
    [Display(Name = "Consignee Name")]
    public string ConsigneeName { get; set; }

    [Range(0.001, 99999.0, ErrorMessage = "Please enter Packages")]
    [Required(ErrorMessage = "Please enter Packages")]
    public int Packages { get; set; }

    [Range(0.001, 99999.0, ErrorMessage = "Please enter Actual Weight")]
    [Required(ErrorMessage = "Please enter Actual Weight")]
    public Decimal ActualWeight { get; set; }

    [Range(0.001, 99999.0, ErrorMessage = "Please enter Charge Weight")]
    [Required(ErrorMessage = "Please enter Charge Weight")]
    public Decimal ChargeWeight { get; set; }

    [Display(Name = "Docket Total")]
    public Decimal DocketTotal { get; set; }

    public Decimal ContractAmount { get; set; }

    [Display(Name = "Bulky")]
    public bool IsBulky { get; set; }

    public Decimal BulkyAmount { get; set; }

    [Display(Name = "Freight")]
    public Decimal Freight { get; set; }

    [Display(Name = "Other Charges")]
    public Decimal OtherCharges { get; set; }

    [Display(Name = "Grand Total")]
    public Decimal GrandTotal { get; set; }
  }
}
