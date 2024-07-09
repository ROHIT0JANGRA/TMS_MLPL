//  
// Type: CodeLock.Models.VendorBillUpload
//  
//  
//  

using System.Collections.Generic;
using System.Web;

namespace CodeLock.Models
{
  public class VendorBillUpload : Response
  {
    public string FileName { get; set; }

    public HttpPostedFileBase File { get; set; }

    public VendorBillUpload()
    {
      this.Details = new List<VendorBillUploadDetail>();
    }

    public List<VendorBillUploadDetail> Details { get; set; }
  }
}
