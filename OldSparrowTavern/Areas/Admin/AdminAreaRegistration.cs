using System.Web.Mvc;
using System.Web.Routing;

namespace OldSparrowTavern.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ManageUsers",
                "Admin/{controller}/{action}",
                new { controller= "ManageUsers", action = "Users", id = UrlParameter.Optional },
                new string[] { "OldSparrowTavern.Areas.Admin.Controllers" }
            );
        }
    }
}