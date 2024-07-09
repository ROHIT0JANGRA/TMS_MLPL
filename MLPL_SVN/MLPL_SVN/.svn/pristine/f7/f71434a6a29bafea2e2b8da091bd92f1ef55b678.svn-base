//  
// Type: CodeLock.Models.DocketUploadInSystem
//  
//  
//  

using System.Collections.Generic;
using System.Web;

namespace CodeLock.Models
{
  public class DocketUploadInSystem : Response
  {
    public string FileName { get; set; }

    public HttpPostedFileBase File { get; set; }

    public short EntryBy { get; set; }

    public DocketUploadInSystem()
    {
      this.Details = new List<Docket>();
    }

    public List<Docket> Details { get; set; }
  }
}
