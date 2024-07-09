//  
// Type: CodeLock.Areas.FMS.FMSAreaRegistration
//  
//  
//  

using System.Web.Mvc;

namespace CodeLock.Areas.FMS
{
  public class FMSAreaRegistration : AreaRegistration
  {
    public override string AreaName
    {
      get
      {
        return "FMS";
      }
    }

    public override void RegisterArea(AreaRegistrationContext context)
    {
      context.MapRoute("FMS_default", "FMS/{controller}/{action}/{id}", (object) new
      {
        action = "Index",
        id = UrlParameter.Optional
      });
    }
  }
}
