using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormApp.pages
{
    public partial class contacto : System.Web.UI.Page
    {

        public string nombre = "";
        public string telefono = "";
        public string varget = "";

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString.AllKeys.Contains("varget"))
            {
                varget = Request.QueryString["varget"];
            }
           
            if (Request.Form.AllKeys.Length > 0) { 
                nombre = Request.Form["nombre"];
                telefono = Request.Form["telefono"];
            }

        }
    }
}