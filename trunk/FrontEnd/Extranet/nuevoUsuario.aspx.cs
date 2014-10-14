using System;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.App;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Extranet
{
	/// <summary>
	/// Summary description for Login.
	/// </summary>
    public partial class nuevoUsuario : Page
	{

		protected void Page_Load(object sender, EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
				lblLogueo.Text = "";
				if (Request.QueryString["accessdenied"] != null && Request.QueryString["accessdenied"] == "1")
				{
					lblErrorPermisos.Text = Server.UrlDecode(Request.QueryString["message"]) + "<br>Por favor ingrese un Usuario y Password con los privilegios necesarios...";
					lblErrorPermisos.Visible = true;

				}
			}

		}

		#region Web Form Designer generated code

		protected override void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{

		}

		#endregion

        protected void btnLogin_Click(object sender, EventArgs e)
		{
            string empresa = txtEmpresa.Text;
            string NombreyApellido = txtNombreApellido.Text;
            string Telefono = txtTelefono.Text;
            string email = txtEmail.Text;
            System.Net.Mail.MailMessage correo = new System.Net.Mail.MailMessage();
            correo.From = new System.Net.Mail.MailAddress("informes@tiempoygestion.com.ar");
            correo.To.Add("carlosrodriguez@tiempoygestion.com.ar");
            correo.Subject = "Tiempo & Gestión: solicitud de nuevo usuario";
            //texto = "\n\nFecha: " + DateTime.Now.ToUniversalTime().ToString("dd/MM/yyyy HH:mm:ss");

            string texto = NombreyApellido + " ("+empresa+") solicita nuevo usuario. Comunicarse al " + Telefono + " ó enviar a " + email + ".";
            correo.Body = texto;
            correo.IsBodyHtml = true;
            correo.Priority = System.Net.Mail.MailPriority.Normal;
            //
            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
            //
            //---------------------------------------------
            // Estos datos debes rellanarlos correctamente
            //---------------------------------------------
            smtp.Host = "smtp.tiempoygestion.com.ar";
            smtp.Credentials = new System.Net.NetworkCredential("informes@tiempoygestion.com.ar", "Info123456");
            //smtp.EnableSsl = false;

            try
            {
                smtp.Send(correo);
                //LabelError.Text = "Mensaje enviado satisfactoriamente";
            }
            catch (Exception ex)
            {
                //LabelError.Text = "ERROR: " + ex.Message;
            }

            Response.Redirect("/");
		
		}

		protected void btnCancelar_Click(object sender, System.EventArgs e)
		{
			if (lblErrorPermisos.Visible)
			{
				Response.Clear();
				Response.Write("<script languaje=\"Javascript\">history.back(-1);</script>");
			}
			else
			{
				Response.Redirect("http://www.tiempoygestion.com.ar");
			}
		}
	}
}