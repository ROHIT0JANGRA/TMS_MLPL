//  
// Type: CodeLock.Models.StandardChargeMatrixUpload
//  
//  
//  

using System.Collections.Generic;
using System.Web;

namespace CodeLock.Models
{
  public class StandardChargeMatrixUpload : Response
  {
    public string FileName { get; set; }

    public HttpPostedFileBase File { get; set; }

    public short EntryBy { get; set; }

    public StandardChargeMatrixUpload()
    {
      this.Details = new List<CustomerContractChargeMatrixSTD>();
    }

    public List<CustomerContractChargeMatrixSTD> Details { get; set; }
  }
}
