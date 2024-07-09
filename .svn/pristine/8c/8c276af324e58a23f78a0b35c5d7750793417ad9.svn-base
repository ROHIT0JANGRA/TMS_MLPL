using CodeLock.Models;
using System.Web.Http;

namespace CodeLock
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                 name: "ControllerAndActionOnly",
                 routeTemplate: "api/{controller}/{action}/{id}",
                 defaults: new { id = RouteParameter.Optional });

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{area}/api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
            name: "HomeApiOnly",
            routeTemplate: "api/{controller}/{action}/{id}",
            defaults: new { id = RouteParameter.Optional }
            );

            //config.Filters.Add(new BasicAuthenticationAttribute());
        }
    }
}
