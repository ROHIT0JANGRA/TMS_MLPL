using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CodeLock.Startup))]
[assembly: OwinStartup(typeof(CodeLock.Startup))]


namespace CodeLock
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
