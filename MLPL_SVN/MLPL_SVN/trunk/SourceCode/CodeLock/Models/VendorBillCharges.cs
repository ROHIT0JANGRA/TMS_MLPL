//  
// Type: CodeLock.Models.VendorBillCharges
//  
//  
//  

using System.Collections.Generic;

namespace CodeLock.Models
{
  public class VendorBillCharges : Response
  {
    public List<MasterCharge> OtherChargeList { get; set; }
  }
}
