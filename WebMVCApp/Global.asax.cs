using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.IO;

namespace WebMVCApp
{

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            ViewEngines.Engines.Insert(0, new SingleProjectAreasViewEngine());
            /*
            // Otra forma
            RazorViewEngine re = ViewEngines.Engines.OfType<RazorViewEngine>().FirstOrDefault();
            if (re != null)
            {
                var newsPaths = new[] {
                    "~/Areas/{2}/Views/Pages/{1}/{0}.cshtml"//,"~/Areas/{2}/Views/Shared/Partials/{0}.cshtml"
                };
                //re.PartialViewLocationFormats = re.PartialViewLocationFormats.Union(newsPaths).ToArray();
                re.AreaViewLocationFormats = re.AreaViewLocationFormats.Union(newsPaths).ToArray();
            }*/

            if (!CheckDatabaseExists("DbDomain")) RunScript();
        }

        private void RunScript()
        {
            string sqlConnectionString = Extra.GetSetting<string>("DbConect");
            /*FileInfo file = new FileInfo("C:\\myscript.sql");*/
            string mapPath = HttpContext.Current.Server.MapPath("~/_Resource/DbDomain.sql");
            FileStream f = new FileStream(mapPath, FileMode.Open, FileAccess.Read, FileShare.Read);

            using (StreamReader r = new StreamReader(f))
            {
                string sqlScript = r.ReadToEnd();
                SqlConnection conn = new SqlConnection(sqlConnectionString);
                Server server = new Server(new ServerConnection(conn));
                server.ConnectionContext.ExecuteNonQuery(sqlScript);
            }
        }

        private bool CheckDatabaseExists(string databaseName)
        {
            string sqlConnectionString = Extra.GetSetting<string>("DbConect");
            using (var cnn = new SqlConnection(sqlConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "SELECT db_id(@databaseName)";
                cmd.Parameters.Add("@databaseName", SqlDbType.VarChar).Value = databaseName;
                cmd.Connection = cnn;

                cnn.Open();
                bool bExistDb = (cmd.ExecuteScalar() != DBNull.Value);
                return bExistDb;
            }
        }
    }


    public class SingleProjectAreasViewEngine : RazorViewEngine
    {
        public SingleProjectAreasViewEngine() : this(
            new[] { "~/Areas/{2}/Views/Pages/{1}/{0}.cshtml" },
            null,
            null //new[] { "~/Areas/{2}/Views/{1}/{0}.master", "~/Areas/{2}/Views/Shared/{0}.master" }
        )
        { }

        public SingleProjectAreasViewEngine(
            IEnumerable<string> areaViewPath,
            IEnumerable<string> areaPartialViewPath,
            IEnumerable<string> areaMasterPath
        ) : base()
        {
            this.AreaViewLocationFormats = areaViewPath.ToArray();
            this.AreaPartialViewLocationFormats = (areaPartialViewPath ?? areaViewPath).ToArray();
            this.AreaMasterLocationFormats = (areaMasterPath ?? areaViewPath).ToArray();
        }
    }
}
