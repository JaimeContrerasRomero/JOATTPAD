using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JOATTPAD1.dsDatosTableAdapters;

namespace JOATTPAD1
{
    public partial class Login : System.Web.UI.Page
    {
        LoginTableAdapter login = new LoginTableAdapter();
        dsDatos dsDatos = new dsDatos();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                String url = Request.QueryString["ReturnUrl"];
                //ejecutar la consula en la base de datos
                this.login.Fill(this.dsDatos.Login, this.txtCorreo.Text.Trim(), this.txtPassword.Text.Trim());
                if(this.dsDatos.Login.Rows.Count > 0) // se valida si hay registros
                {
                    if(url == null)
                    {
                        Response.Redirect("Default.aspx", false);
                        Context.ApplicationInstance.CompleteRequest();
                    }
                    else
                    {
                        System.Web.Security.FormsAuthentication.RedirectFromLoginPage(this.txtCorreo.Text, false);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.ToString());
            }
        }
    }
}