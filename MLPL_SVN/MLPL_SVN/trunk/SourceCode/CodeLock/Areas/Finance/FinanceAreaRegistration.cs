//  
// Type: CodeLock.Areas.Finance.FinanceAreaRegistration
//  
//  
//  

using System.Web.Mvc;

namespace CodeLock.Areas.Finance
{
  public class FinanceAreaRegistration : AreaRegistration
  {
    public override string AreaName
    {
      get
      {
        return "Finance";
      }
    }

    public override void RegisterArea(AreaRegistrationContext context)
    {
      context.MapRoute("Finance_default", "Finance/{controller}/{action}/{id}", (object) new
      {
        action = "Index",
        id = UrlParameter.Optional
      });
    }
  }
}
