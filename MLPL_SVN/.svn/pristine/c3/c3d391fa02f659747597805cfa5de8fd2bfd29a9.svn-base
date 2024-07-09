//  
// Type: CodeLock.Areas.Master.MasterAreaRegistration
//  
//  
//  

using System.Web.Mvc;

namespace CodeLock.Areas.Master
{
  public class MasterAreaRegistration : AreaRegistration
  {
    public override string AreaName
    {
      get
      {
        return "Master";
      }
    }

    public override void RegisterArea(AreaRegistrationContext context)
    {
      context.MapRoute("Master_default", "Master/{controller}/{action}/{id}", (object) new
      {
        action = "Index",
        id = UrlParameter.Optional
      });
    }
  }
}
