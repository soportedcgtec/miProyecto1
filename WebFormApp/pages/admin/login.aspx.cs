using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormApp.pages.admin
{
    public partial class login : AdminBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

        }

        protected void ValidateUser(object sender, EventArgs e)
        {
            int userId = 0;
            string constr = ConfigurationManager.ConnectionStrings["DbLocal"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("pa_validarusuario"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nomuser", Login.UserName);
                    cmd.Parameters.AddWithValue("@passuser", Login.Password);
                    cmd.Connection = con;
                    con.Open();
                    userId = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }
                switch (userId)
                {
                    case -1:
                        Login.FailureText = "password incorrecto.";
                        break;
                    case 0:
                        Login.FailureText = "Usuario no existe";
                        break;
                    default:
                        FormsAuthentication.RedirectFromLoginPage(Login.UserName, Login.RememberMeSet);
                        break;
                }
            }
        }

        // Mostrar y ocultar formularios
        protected void rdbtnLoginA_CheckedChanged(object sender, EventArgs e)
        {
            panelLoginA.Visible = true;
            panelLoginB.Visible = false;
        }

        protected void rdbtnLoginB_CheckedChanged(object sender, EventArgs e)
        {
            panelLoginA.Visible = false;
            panelLoginB.Visible = true;
        }
    }
}