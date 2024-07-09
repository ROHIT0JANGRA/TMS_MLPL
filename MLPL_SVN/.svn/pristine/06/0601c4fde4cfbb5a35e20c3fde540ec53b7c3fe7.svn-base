//  
// Type: CodeLock.Models.VendorBill
//  
//  
//  

using ExpressiveAnnotations.Attributes;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class VendorBill
  {
    [Required(ErrorMessage = "Please select Transaction Type")]
    [Display(Name = "Transaction Type")]
    public byte TransactionTypeId { get; set; }

    [Display(Name = "Transaction Category")]
    [Required(ErrorMessage = "Please select Transaction Category")]
    public string GstSac { get; set; }

    public byte GstSacId { get; set; }

    public short VendorId { get; set; }

    [Display(Name = "Vendor")]
    [Required(ErrorMessage = "Please enter Vendor")]
    public string VendorCode { get; set; }

    [Display(Name = "Vendor Name")]
    [RequiredIf("VendorId == 1", ErrorMessage = "Please enter Vendor Name")]
    public string VendorName { get; set; }

    [Display(Name = "Vendor GST State")]
    [Required(ErrorMessage = "Please select Vendor GST State")]
    public long VendorGstId { get; set; }

    [Display(Name = "Registered")]
    public bool IsRegistered { get; set; }

    public string Registered { get; set; }

    [Display(Name = "Transporter GST State")]
    [Required(ErrorMessage = "Please select Transporter GST State")]
    public long CompanyGstId { get; set; }

    public byte PrimaryBillingTypeId { get; set; }

    [Display(Name = "Transport Mode")]
    [Required(ErrorMessage = "Please select Transport Mode")]
    public byte? TransportModeId { get; set; }

    [Display(Name = "Document Type")]
    public MasterGeneral[] DocumentType { get; set; }
  }
}
