//  
// Type: CodeLock.Models.VendorBillCharge
//  
//  
//  

namespace CodeLock.Models
{
  public class VendorBillCharge : MasterCharge
  {
    public long DocumentId { get; set; }

    public byte DocumentTypeId { get; set; }
  }
}
