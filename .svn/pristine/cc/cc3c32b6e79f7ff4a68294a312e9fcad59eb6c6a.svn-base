//  
// Type: CodeLock.Areas.Contract.ContractAreaRegistration
//  
//  
//  

using System.Web.Mvc;

namespace CodeLock.Areas.Contract
{
  public class ContractAreaRegistration : AreaRegistration
  {
    public override string AreaName
    {
      get
      {
        return "Contract";
      }
    }

    public override void RegisterArea(AreaRegistrationContext context)
    {
      context.MapRoute("Contract_default", "Contract/{controller}/{action}/{id}", (object) new
      {
        action = "Index",
        id = UrlParameter.Optional
      });
    }
  }
}
