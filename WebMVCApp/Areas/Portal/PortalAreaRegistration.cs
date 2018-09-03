using System.Web.Mvc;

namespace WebMVCApp.Areas.Portal
{
    public class PortalAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Portal";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Portal_default",
                "Portal/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "WebMVCApp.Areas.Portal.Controllers" }
            );

            context.MapRoute(
                "Portal_home",
                "",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "WebMVCApp.Areas.Portal.Controllers" }
            );
        }
    }
}