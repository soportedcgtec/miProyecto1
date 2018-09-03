using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace WebFormApp
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes(RouteTable.Routes);
        }

        void RegisterRoutes(RouteCollection routes)
        {
            // Portal Routes
            //routes.MapPageRoute("routeSale", "SalesReport/{locale}/{year}/{*queryvalues}", "~/sales.aspx");
            routes.MapPageRoute("routeIndex", "", "~/pages/portal/index.aspx");
            routes.MapPageRoute("routeContact", "contacto", "~/pages/portal/contacto.aspx");

            // Admin Routes
            routes.MapPageRoute("routeLogin", "admin", "~/pages/admin/login.aspx");
        }
    }
}