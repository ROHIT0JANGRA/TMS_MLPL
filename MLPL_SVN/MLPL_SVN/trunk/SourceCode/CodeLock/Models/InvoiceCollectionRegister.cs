//  
// Type: CodeLock.Models.InvoiceCollectionRegister
//  
//  
//  

using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class InvoiceCollectionRegister
  {
    [Display(Name = "Company")]
    public byte CompanyId { get; set; }

    [Display(Name = "Document")]
    public bool Document { get; set; }

    [Display(Name = "Locationt Type")]
    public short LocationTypeId { get; set; }

    [Display(Name = "Location")]
    public short LocationId { get; set; }

    [Display(Name = "Date Type")]
    public short DateTypeId { get; set; }

    [Display(Name = "Bill No")]
    public string BillNo { get; set; }

    [Display(Name = "MR No")]
    public string MRNo { get; set; }

    [Display(Name = "Manual Bill No")]
    public string ManualBillNo { get; set; }

    [Display(Name = "Docket No")]
    public string DocketNo { get; set; }
  }
}
