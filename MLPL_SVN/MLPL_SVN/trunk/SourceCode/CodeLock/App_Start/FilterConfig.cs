using CodeLock.Models;
using System.Web;
using System.Web.Mvc;

namespace CodeLock
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
