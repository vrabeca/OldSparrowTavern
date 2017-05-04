using AutoMapper;
using OldSparrowTavern.Areas.Admin.ViewModels;
using OldSparrowTavern.Models;
using OldSparrowTavern.ViewModels;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace OldSparrowTavern
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Mapper.Initialize(cfg => { cfg.CreateMap<User, UserToEditViewModel>();
            cfg.CreateMap<User, ProfileViewModel>();
            cfg.CreateMap<User, UserInfoViewModel>();
            });

            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
