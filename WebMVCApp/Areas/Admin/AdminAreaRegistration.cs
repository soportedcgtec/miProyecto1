using System.Web.Mvc;

namespace WebMVCApp.Areas.Admin
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
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "WebMVCApp.Areas.Admin.Controllers" }
            );

            context.MapRoute(
                "Admin_home",
                "Admin",
                new { controller = "Login", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "WebMVCApp.Areas.Admin.Controllers" }
            );
        }
    }
}