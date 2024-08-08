using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Http;
using CodeLock.Scheduler;

namespace CodeLock
{
    public class Global : HttpApplication
    {
        string connString = ConfigurationManager.ConnectionStrings["CodeLockDBConnection"].ConnectionString;
        void Application_Start(object sender, EventArgs e)
        {
            SqlDependency.Start(connString);

        }
        protected void Application_End()
        {
            //Stop SQL dependency
            SqlDependency.Stop(connString);

        }
    }
}
