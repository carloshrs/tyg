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
    public partial class LoginExtra : Page
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
			if (Usuario.AutenticarUsuario(txtUserName.Text, txtPassword.Value))
			{
				Usuario user = new Usuario();
				user.Cargar(txtUserName.Text);
				string strRoles = user.RolesString;
				int intTicketTimeOut = 0;
				try
				{
					intTicketTimeOut = int.Parse(ConfigurationSettings.AppSettings["ExpiracionTicket"]);

				}
				catch
				{
					intTicketTimeOut = 10;
				}

				FormsAuthenticationTicket authTicket = 
					new FormsAuthenticationTicket(txtUserName.Text, false, intTicketTimeOut);
				string strEncryptedTicket = FormsAuthentication.Encrypt(authTicket);
				HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, strEncryptedTicket);
				Response.Cookies.Add(authCookie);
//				if (FormsAuthentication.GetRedirectUrl(txtUserName.Text,false) != "Login.aspx")
//					FormsAuthentication.RedirectFromLoginPage(txtUserName.Text,false);
//				else
					Response.Redirect("/Extranet.aspx");

			}
			else
			{
				lblLogueo.Text = "Usuario o contraseña invalidos.";
			}
		
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