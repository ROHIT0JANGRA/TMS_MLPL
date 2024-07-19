using System.Web.Mvc;

namespace CodeLock.Areas.Ewaybill
{
    public class EwaybillAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Ewaybill";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Ewaybill_default",
                "Ewaybill/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}