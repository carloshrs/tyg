using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.Admin.Clientes
{
	/// <summary>
	/// Summary description for UsuarioAddRol.
	/// </summary>
	public partial class UsuarioAddRol : System.Web.UI.Page
	{
		private Usuario user;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				try
				{
					int intIdUsuario = int.Parse(Request.QueryString["IdUsuario"]);
					user = new Usuario();
					user.Cargar(intIdUsuario);
					lblNombreUsuario.Text = user.Apellido + ", " + user.Nombre;
					Session["Usuario"] = user;
					CargarUsuario();
					ViewState["From"] = Request.QueryString["From"];
					ViewState["IdCliente"] = Request.QueryString["IdCliente"];
				}
				catch
				{
					Response.Redirect("ListaUsuarios.aspx");
				}
				CargarRoles();
			}
			else
				user = (Usuario) Session["Usuario"];

		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
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

		private void CargarUsuario()
		{
			SortedList slRolesUsuario = new SortedList();
			if (user.Roles.Count > 0)
			{
				foreach(Rol itemRol in user.Roles.Values)
				{
					slRolesUsuario.Add(itemRol.Nombre, itemRol);
				}
			}
			else
			{
				DataTable dtRoles;
				Rol auxRol;
				if (user.UsuarioIntranet)
					dtRoles = new Rol().Listar("", true, false);
				else
					dtRoles = new Rol().Listar("", true, true);
				foreach(DataRow drRol in dtRoles.Rows)
				{
					auxRol = new Rol(Convert.ToInt32(drRol["IdRol"]), Convert.ToString(drRol["Nombre"]), Convert.ToString(drRol["Descripcion"]), Convert.ToBoolean(drRol["Automatico"]), Convert.ToBoolean(drRol["Extranet"]));
					user.Roles.Add(auxRol.Id, auxRol);
					slRolesUsuario.Add(auxRol.Nombre, auxRol);
				}
				Session["Usuario"] = user;
			}

			lstRolesUsuario.DataSource = slRolesUsuario.Values;
			lstRolesUsuario.DataTextField = "Nombre";
			lstRolesUsuario.DataValueField = "Id";
			lstRolesUsuario.DataBind();

		}

		private void CargarRoles()
		{
			string strNotIn = ArmarLista();
			DataTable dtRoles;
			if (user.UsuarioIntranet)
				dtRoles = new Rol().Listar(strNotIn, false, false);
			else
				dtRoles = new Rol().Listar(strNotIn, false, true);

			lstRoles.DataSource = dtRoles.DefaultView;
			lstRoles.DataTextField = "Nombre";
			lstRoles.DataValueField = "IdRol";
			lstRoles.DataBind();

		}

		private string ArmarLista()
		{
			StringBuilder sbRes = new StringBuilder(128);
			if (lstRolesUsuario.Items.Count > 0)
			{
				sbRes.Append("(");
				foreach(ListItem item in lstRolesUsuario.Items)
				{
					sbRes.Append(item.Value + ", ");
				}
				sbRes.Remove(sbRes.Length - 2, 2);
				sbRes.Append(")");

			}

			return sbRes.ToString();

		}

		protected void btnCancelar_Click(object sender, EventArgs e)
		{
			if (ViewState["From"].ToString() == "abm")
			{
				if (ViewState["IdCliente"] != null && ViewState["IdCliente"].ToString() != "")
					Response.Redirect("AbmUsuario.aspx?IdUsuario=" + user.Id.ToString() + "&IdCliente=" + ViewState["IdCliente"].ToString());
				else
					Response.Redirect("AbmUsuario.aspx?IdUsuario=" + user.Id.ToString());
			}
			else
			{
				if (ViewState["IdCliente"] != null && ViewState["IdCliente"].ToString() != "")
					Response.Redirect("ListaUsuarios.aspx?IdCliente=" + ViewState["IdCliente"].ToString());
				else
					Response.Redirect("ListaUsuarios.aspx");
			}

		}

		protected void btnAddRol_Click(object sender, EventArgs e)
		{
			if (lstRoles.SelectedItem != null && user.Roles[Convert.ToInt32(lstRoles.SelectedValue)] == null)
			{
				Rol rol = new Rol();
				rol.Cargar(Convert.ToInt32(lstRoles.SelectedValue));
				user.Roles.Add(rol.Id, rol);
				Session["Usuario"] = user;
				CargarUsuario();
				CargarRoles();

			}

		}

		protected void btnRemoveRol_Click(object sender, EventArgs e)
		{
			if (lstRolesUsuario.SelectedItem != null)
			{
				user.Roles.Remove(Convert.ToInt32(lstRolesUsuario.SelectedValue));
				Session["Usuario"] = user;
				CargarUsuario();
				CargarRoles();

			}
		}

		protected void btnAceptar_Click(object sender, EventArgs e)
		{
			user.Modificar();
			Session.Remove("Usuario");
			btnCancelar_Click(null, null);

		}

	}
}
