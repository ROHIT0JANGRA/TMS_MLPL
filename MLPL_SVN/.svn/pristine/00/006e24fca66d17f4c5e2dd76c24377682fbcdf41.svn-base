using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace CodeLock.Hubs
{
    public class DashboardHub : Hub
    {
        [HubName("dHub")]
        public class DHub : Hub
        {
            public static void BroadcastData()
            {
                IHubContext context = GlobalHost.ConnectionManager.GetHubContext<DHub>();
                context.Clients.All.refreshDashbard();
            }
        }
    }
}