using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMVCApp.Areas.Admin.Models;
using WebMVCApp.Libraries.Db;

namespace WebMVCApp.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Portal/Login
        // Vista de inicio de session
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                string defUrl = FormsAuthentication.DefaultUrl;
                if (defUrl != null && defUrl != "") { return Redirect(defUrl); }
                return RedirectToAction("Index", "Panel");
            }
            return View();
        }

        // Iniciando session
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(FormCollection form)
        {
            string sql = "SELECT * FROM usuario WHERE nomuser='{0}' AND passuser='{1}'";
            sql = String.Format(sql, form["nomuser"], form["passuser"]);
            DASql DB = new DASql(Extra.GetSetting<string>("DbDomain"));
            DataSet oSDA = (DataSet)DB.objSqlResult(sql, "sql", "Reader");
            DataTable dtRes = oSDA.Tables["Table1"];

            // Is User Valid
            if (dtRes.Rows.Count > 0)
            {
                // Llenamos el Usuario Model
                Usuario usu = new Usuario();
                DataRow drRes = dtRes.Rows[0];

                usu.id = (int)drRes["id"];
                usu.nomape = (string)drRes["nomape"];

                usu.nomuser = form["nomuser"];
                usu.passuser = form["passuser"];

                usu.email = (string)drRes["email"];
                usu.ultLogin = (drRes["ultLogin"]==DBNull.Value)?DateTime.Now:(DateTime)drRes["ultLogin"];
                usu.idRol = (int)drRes["idRol"];
                usu.nomRol = (string)drRes["nomRol"];
                usu.fecreg = (DateTime)drRes["fecreg"];

                // Create a new ticket used for authentication
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                    1,                           // version: Ticket version
                    usu.nomuser,                 // name: Username to be associated with this ticket
                    DateTime.Now,                // issueDate: Date/time issued - fecha Inicio
                    DateTime.Now.AddMinutes(30), // expiration: Date/time to expire
                    true,                        // isPersistent: "true" for a persistent user cookie (could be a checkbox on form)
                    usu.nomRol,                  // User-data (the roles from this user record in our database)
                    FormsAuthentication.FormsCookiePath
                ); // Path cookie is valid for

                // Hash the cookie for transport over the wire
                string hash = FormsAuthentication.Encrypt(ticket);
                string defUrl = FormsAuthentication.DefaultUrl;
                // Hashed ticket
                // FormsCookieName: Name of auth cookie (it's the name specified in web.config)
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hash);

                // Add the cookie to the list for outbound response
                Response.Cookies.Add(cookie);

                // Redirect to requested URL, or homepage if no previous page requested
                string returnUrl = Request.QueryString["ReturnUrl"];
                if (returnUrl != null) { return Redirect(returnUrl); }

                if(defUrl!=null && defUrl != "") { return Redirect(defUrl); }

                return RedirectToAction("Index", "Panel");

                // Don't call the FormsAuthentication.RedirectFromLoginPage since it could
                // replace the authentication ticket we just added...
            }
            else
            {
                ViewBag.sqlRes = JsonConvert.SerializeObject(oSDA, Formatting.Indented);
                ViewBag.msg = "Usuario o Clave incorrectos!";
                return View();
            }

        }
    }
}