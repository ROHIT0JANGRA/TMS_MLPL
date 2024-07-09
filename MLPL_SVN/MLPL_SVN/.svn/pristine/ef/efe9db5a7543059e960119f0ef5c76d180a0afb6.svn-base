//  
// Type: CodeLock.Models.DocketUpload
//  
//  
//  

using System.Collections.Generic;
using System.Web;

namespace CodeLock.Models
{
  public class DocketUpload : Response
  {
    public string FileName { get; set; }

    public HttpPostedFileBase File { get; set; }

    public short EntryBy { get; set; }

        public DocketUpload()
    {
      this.Details = new List<Docket>();
    }

    public List<Docket> Details { get; set; }
  }
}
