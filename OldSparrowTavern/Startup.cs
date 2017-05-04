using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using OldSparrowTavern.HelperMethods;
using OldSparrowTavern.Models;
using Owin;
using System.Web.Routing;

[assembly: OwinStartupAttribute(typeof(OldSparrowTavern.Startup))]
namespace OldSparrowTavern
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
            ConfigureAuth(app);
        }
    }
}

