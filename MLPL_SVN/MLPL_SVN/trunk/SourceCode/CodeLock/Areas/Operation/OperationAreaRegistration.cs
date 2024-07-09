//  
// Type: CodeLock.Areas.Operation.OperationAreaRegistration
//  
//  
//  

using System.Web.Http;
using System.Web.Mvc;

namespace CodeLock.Areas.Operation
{
  public class OperationAreaRegistration : AreaRegistration
  {
    public override string AreaName
    {
      get
      {
        return "Operation";
      }
    }

    public override void RegisterArea(AreaRegistrationContext context)
    {

            context.Routes.MapHttpRoute(
         name: "Operation_ActionApi",
         routeTemplate: "Operation/api/{controller}/{action}/{id}",
         defaults: new { id = RouteParameter.Optional });

            context.Routes.MapHttpRoute(
            name: "Operation_DefaultApi",
            routeTemplate: "Operation/api/{controller}/{id}",
            defaults: new { id = RouteParameter.Optional });


            context.MapRoute("Operation_default", "Operation/{controller}/{action}/{id}", (object) new
      {
        action = "Index",
        id = UrlParameter.Optional
      });
    }
  }
}
