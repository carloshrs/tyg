using System;
using System.Collections;
using System.Data;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.Admin.Seguridad.Admin.Seguridad
{
	/// <summary>
	/// Summary description for FuncionAddRol.
	/// </summary>
	public partial class FuncionAddRol : Page
	{
		private Rol rol;
	
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				try
				{
					int intIdRol = int.Parse(Request.QueryString["IdRol"]);
					rol = new Rol();
					rol.Cargar(intIdRol);
					lblNombreRol.Text = rol.Nombre;
					Session["Rol"] = rol;
					CargarRol();
					ViewState["From"] = Request.QueryString["From"];
				}
				catch
				{
					Response.Redirect("ListaRoles.aspx");
				}
				CargarFunciones();
			}
			else
				rol = (Rol) Session["Rol"];

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
			this.btnAddFuncion.Click += new EventHandler(this.btnAddFuncion_Click);
			this.btnRemoveFuncion.Click += new EventHandler(this.btnRemoveFuncion_Click);
			this.btnAceptar.Click += new EventHandler(this.btnAceptar_Click);
			this.btnCancelar.Click += new EventHandler(this.btnCancelar_Click);
			this.Load += new EventHandler(this.Page_Load);

		}
		#endregion

		private void CargarRol()
		{
			SortedList slFuncionesRol = new SortedList();
			foreach(Funcion itemFuncion in rol.Funciones.Values)
			{
				slFuncionesRol.Add(itemFuncion.Nombre, itemFuncion);
			}

			lstFuncionesRol.DataSource = slFuncionesRol.Values;
			lstFuncionesRol.DataTextField = "Nombre";
			lstFuncionesRol.DataValueField = "Id";
			lstFuncionesRol.DataBind();

		}

		private void CargarFunciones()
		{
			string strNotIn = ArmarLista();
			DataTable dtFunciones = new Funcion().Listar(strNotIn);

			lstFunciones.DataSource = dtFunciones.DefaultView;
			lstFunciones.DataTextField = "Nombre";
			lstFunciones.DataValueField = "IdFuncion";
			lstFunciones.DataBind();

		}

		private string ArmarLista()
		{
			StringBuilder sbRes = new StringBuilder(128);
			if (lstFuncionesRol.Items.Count > 0)
			{
				sbRes.Append("(");
				foreach(ListItem item in lstFuncionesRol.Items)
				{
					sbRes.Append(item.Value + ", ");
				}
				sbRes.Remove(sbRes.Length - 2, 2);
				sbRes.Append(")");

			}

			return sbRes.ToString();

		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			if (ViewState["From"].ToString() == "abm")
				Response.Redirect("AbmRol.aspx?IdRol=" + rol.Id.ToString());
			else
				Response.Redirect("ListaRoles.aspx");
		}

		private void btnAddFuncion_Click(object sender, EventArgs e)
		{
			if (lstFunciones.SelectedItem != null && rol.Funciones[Convert.ToInt32(lstFunciones.SelectedValue)] == null)
			{
				Funcion funcion = new Funcion();
				funcion.Cargar(Convert.ToInt32(lstFunciones.SelectedValue));
				rol.Funciones.Add(funcion.Id, funcion);
				Session["Rol"] = rol;
				CargarRol();
				CargarFunciones();

			}

		}

		private void btnRemoveFuncion_Click(object sender, EventArgs e)
		{
			if (lstFuncionesRol.SelectedItem != null)
			{
				rol.Funciones.Remove(Convert.ToInt32(lstFuncionesRol.SelectedValue));
				Session["Rol"] = rol;
				CargarRol();
				CargarFunciones();

			}
		}

		private void btnAceptar_Click(object sender, EventArgs e)
		{
			rol.Modificar();
			Session.Remove("Rol");
			btnCancelar_Click(null, null);

		}

	}
}
