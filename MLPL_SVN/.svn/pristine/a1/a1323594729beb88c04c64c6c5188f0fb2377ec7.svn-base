//  
// Type: CodeLock.CompressAttribute
//  
//  
//  

using System.IO;
using System.IO.Compression;
using System.Web;
using System.Web.Mvc;

namespace CodeLock
{
  public class CompressAttribute : ActionFilterAttribute
  {
    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
      string header = filterContext.HttpContext.Request.Headers["Accept-Encoding"];
      if (string.IsNullOrEmpty(header))
        return;
      string lowerInvariant = header.ToLowerInvariant();
      HttpResponseBase response = filterContext.HttpContext.Response;
      if (lowerInvariant.Contains("deflate"))
      {
        response.AppendHeader("Content-encoding", "deflate");
        response.Filter = (Stream) new DeflateStream(response.Filter, CompressionMode.Compress);
      }
      else
      {
        if (!lowerInvariant.Contains("gzip"))
          return;
        response.AppendHeader("Content-encoding", "gzip");
        response.Filter = (Stream) new GZipStream(response.Filter, CompressionMode.Compress);
      }
    }
  }
}
