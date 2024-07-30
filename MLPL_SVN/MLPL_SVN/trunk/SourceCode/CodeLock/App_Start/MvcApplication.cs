using CodeLock.Models;
using ExpressiveAnnotations.Attributes;
using ExpressiveAnnotations.MvcUnobtrusive.Validators;
using System;
using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.SessionState;
using System.Web.Http;
using CodeLock.Areas.Ewaybill.Repository;
using Unity;

namespace CodeLock
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            MvcApplication.RegisterExpressiveAttributes();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            IocConfig.ConfigureIocUnityContainer();
            RegisterValidation.Init();
            DataAnnotationsModelValidatorProvider.AddImplicitRequiredAttributeForValueTypes = false;
            ModelValidatorProviders.Providers.Add((ModelValidatorProvider)new ExtendedDataAnnotationsModelValidatorProvider());
            
            var container = DependencyResolver.Current.GetService<IUnityContainer>();
            var ewaybillRepository = container.Resolve<EwaybillRepository>();
            if (ewaybillRepository.GetUpdateIsSchedulerActiveOrUpdate("DailyEwaybillTaskScheduler", "GetIsActive", false) == true)
            {
                ewaybillRepository.Start();
            }
        }

        protected void Application_PreRequestHandlerExecute(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB");

            if (!(this.Context.Handler is IRequiresSessionState) && !(this.Context.Handler is IReadOnlySessionState) || !this.Session.IsNewSession && this.Session.Count >= 1)
                return;

            char[] chArray = new char[2] { '/', ' ' };
            if (!this.Context.Request.Url.AbsoluteUri.ToLower().Contains("home/index") 
                && !this.Context.Request.Url.AbsoluteUri.ToLower().Contains("tracking/consignment") 
                && (!this.Context.Request.Url.AbsoluteUri.ToLower().Contains("tracking/getconsignment") 
                && !this.Context.Request.Url.AbsoluteUri.ToLower().Contains("tracking/dockettracking")) 
                && !this.Context.Request.Url.AbsoluteUri.ToLower().Contains("tracking/getdockettransitsummary") 
                && !this.Context.Request.Url.AbsoluteUri.ToLower().Contains("tracking/getapidocketstatus") 
                && !this.Context.Request.Url.AbsoluteUri.ToLower().Contains("tracking/getdockettransitsummary") 
                && !this.Context.Request.Url.AbsoluteUri.ToLower().Contains("api/docket/getlogicloudbookingorderupload") 
                && !this.Context.Request.Url.AbsoluteUri.ToLower().Contains("api/docket/getdocketstatus") 
                && !Context.Request.Url.AbsoluteUri.ToLower().Contains("webclientprintapi/processrequest") 
                && !Context.Request.Url.AbsoluteUri.ToLower().Contains("operation/api") 
                && !Context.Request.Url.AbsoluteUri.ToLower().Contains("fms/api") 
                && !Context.Request.Url.AbsoluteUri.ToLower().Contains("api/tripsheet")
                && !Context.Request.Url.AbsoluteUri.ToLower().Contains("api/docket")
                && this.Context.Request.Url.AbsoluteUri.ToLower().TrimEnd(chArray).Replace("http://", string.Empty) != (this.Context.Request.Url.Authority + this.Request.ApplicationPath).ToLower().TrimEnd(chArray))
            {
                if (Context.Request.Url.AbsoluteUri.ToLower().TrimEnd(chArray).Replace("http://", string.Empty) != (Context.Request.Url.Authority + Request.ApplicationPath).ToLower().TrimEnd(chArray))
                    this.Context.Response.Redirect("~/Home/Index");
            }
        }
        private static void RegisterExpressiveAttributes()
        {
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(RequiredIfAttribute), typeof(RequiredIfValidator));
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(AssertThatAttribute), typeof(AssertThatValidator));
        }
    }
}
