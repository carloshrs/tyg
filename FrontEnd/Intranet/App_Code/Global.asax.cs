using System;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Security.Principal;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.App;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet
{
	/// <summary>
	/// Summary description for Global.
	/// </summary>
	public class Global : HttpApplication
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private IContainer components = null;

		public Global()
		{
			InitializeComponent();
		}

		protected void Application_Start(Object sender, EventArgs e)
		{}

		protected void Session_Start(Object sender, EventArgs e)
		{
			HttpContext.Current.Session.Add("UsuarioAutenticado", null);
		}

		protected void Application_BeginRequest(Object sender, EventArgs e)
		{}

		protected void Application_EndRequest(Object sender, EventArgs e)
		{}

		protected void Application_AuthenticateRequest(Object sender, EventArgs e)
		{
			string strUrlKey = Path.GetFileName(Request.Path);
           if (strUrlKey.ToLower() != "login.aspx" && strUrlKey.ToLower().EndsWith(".aspx"))
			{
				HttpCookie authCookie = Context.Request.Cookies[FormsAuthentication.FormsCookieName];
				if (authCookie != null)
				{
					FormsAuthenticationTicket authTicket = null;
					bool bolFlag = true;
					try
					{
						authTicket = FormsAuthentication.Decrypt(authCookie.Value);
						FormsAuthentication.RenewTicketIfOld(authTicket);
					}
					catch
					{
						bolFlag = false;
					}

					if (bolFlag && authTicket != null)
					{
						UsuarioAutenticado authUser;
//						if (Context.Session["UsuarioAutenticado"] != null)
//							authUser = (UsuarioAutenticado) Context.Session["UsuarioAutenticado"];
//						else
//						{
							authUser = CrearUsuarioAutenticado(authTicket);
//							HttpContext.Current.Session.Add("UsuarioAutenticado",authUser);
                            //Context.Session["UserPermisos"] = authUser;
//						}
//
                        if (authUser.IsInRole("Administrador") || authUser.CheckAccess(strUrlKey))
						{
							Context.User = authUser;
//							Context.Session["UsuarioAutenticado"] = authUser;
						}
						else
							Response.Redirect("/Login.aspx?accessdenied=1&message=" + Server.UrlEncode("El usuario actual no tiene privilegios para realizar la accion solicitada."));
					}
					else
						Response.Redirect("/Login.aspx?accessdenied=1&message=" + Server.UrlEncode("Sus credenciales expiraron."));
				}
				else
					Response.Redirect("/Login.aspx");
			}
		}

		protected void Application_Error(Object sender, EventArgs e)
		{}

		protected void Session_End(Object sender, EventArgs e)
		{}

		protected void Application_End(Object sender, EventArgs e)
		{}

		#region Web Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new Container();
		}

		#endregion

		private UsuarioAutenticado CrearUsuarioAutenticado(FormsAuthenticationTicket lAuthTicket)
		{
			Usuario user = new Usuario();
			user.Cargar(lAuthTicket.Name);
			int intTicketTimeOut = 0;
			try
			{
				intTicketTimeOut = int.Parse(ConfigurationSettings.AppSettings["ExpiracionTicket"]);
			}
			catch
			{
				intTicketTimeOut = 10;
			}
			
			UsuarioAutenticado authUserOut = new UsuarioAutenticado(new FormsIdentity(lAuthTicket),
																user,
																intTicketTimeOut);

			return authUserOut;
		
		}
	}
}