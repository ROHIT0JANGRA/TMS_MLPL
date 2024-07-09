//  
// Type: CodeLock.Models.VendorPaymentDone
//  
//  
//  

namespace CodeLock.Models
{
  public class VendorPaymentDone
  {
    public long VoucherId { get; set; }

    public string VoucherNo { get; set; }

    public long BillId { get; set; }

    public string BillNo { get; set; }
  }
}
