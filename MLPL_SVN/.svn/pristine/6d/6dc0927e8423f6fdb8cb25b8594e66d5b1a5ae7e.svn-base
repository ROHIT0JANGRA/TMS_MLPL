//  
// Type: CodeLock.Models.ScanDetail
//  
//  
//  

using System.ComponentModel.DataAnnotations;
using System.Web;

namespace CodeLock.Models
{
  public class ScanDetail
  {
    public ScanDetail()
    {
      this.DocumentTypeId = (byte) 0;
      this.ManualNo = string.Empty;
      this.DocumentNo = string.Empty;
      this.ScanStatus = false;
      this.DocumentName = "";
      this.IsSuccessfull = false;
    }

    [Required(ErrorMessage = "Please select Document Type")]
    [Display(Name = "Document Type")]
    public byte DocumentTypeId { get; set; }

    public string DocumentType { get; set; }

    public string DocumentPath { get; set; }

    [Required(ErrorMessage = "Please enter Document No")]
    [Display(Name = "Document No")]
    public string DocumentNo { get; set; }

    public long DocumentId { get; set; }

    public long PodId { get; set; }

    [Display(Name = "Manual No")]
    public string ManualNo { get; set; }

    [Display(Name = "Scan Status")]
    public bool ScanStatus { get; set; }

    [Required(ErrorMessage = "Please select Attachment")]
    [Display(Name = "Attached Document")]
    public HttpPostedFileBase Attachment { get; set; }

    public string DocumentName { get; set; }

    public short LocationId { get; set; }

    public byte CompanyId { get; set; }

    public short EntryBy { get; set; }

    public int Id { get; set; }

    public bool IsSuccessfull { get; set; }

    public string ErrorMessage { get; set; }
  }
}
