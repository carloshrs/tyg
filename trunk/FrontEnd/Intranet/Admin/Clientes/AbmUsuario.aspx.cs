using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.Admin.Clientes
{
	/// <summary>
	/// Summary description for AbmUsuario.
	/// </summary>
	public partial class AbmUsuario : Page
	{

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				bool bolFlagAlta = false;
				if (Request.QueryString["IdCliente"] != null && Request.QueryString["IdCliente"] != "")
					ViewState["IdCliente"] = Request.QueryString["IdCliente"];
				if (Request.QueryString["IdUsuario"] != null && Request.QueryString["IdUsuario"] != "")
				{
					int intIdUsuario;
					try
					{
						intIdUsuario = Convert.ToInt32(Request.QueryString["IdUsuario"]);
						ViewState["IdUsuario"] = Request.QueryString["IdUsuario"];
						CargarUsuario(intIdUsuario);
					}
					catch
					{
						bolFlagAlta = true;
					}
				}
				else
					bolFlagAlta = true;

				if (bolFlagAlta)
				{
					CargarComboProvincias(ddlProvincia, 2);
					CargarComboLocalidades(ddlProvincia, ddlLocalidad, "1");
				}

				ViewState["FlagAlta"] = bolFlagAlta.ToString();

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

		private void CargarUsuario(int lIdUsuario)
		{
			Usuario dalUsuario = new Usuario();
			dalUsuario.Cargar(lIdUsuario);

			txtLoginName.Text = dalUsuario.LogginName;
			txtNombre.Text = dalUsuario.Nombre;
			txtApellido.Text = dalUsuario.Apellido;
			txtEmail.Text = dalUsuario.Email;
			txtTelefono.Text = dalUsuario.Telefono;
			txtCelular.Text = dalUsuario.Celular;
			txtCalle.Text = dalUsuario.Calle;
			txtNro.Text = dalUsuario.Numero;
			txtPiso.Text = dalUsuario.Piso;
			txtDpto.Text = dalUsuario.Departamento;
			txtBarrio.Text = dalUsuario.Barrio;
			txtCodPos.Text = dalUsuario.CodigoPostal;
			CargarComboProvincias(ddlProvincia, dalUsuario.IdProvincia);
			CargarComboLocalidades(ddlProvincia, ddlLocalidad, dalUsuario.IdLocalidad.ToString());
            if (dalUsuario.Activo) chkActivo.Checked = true;

			lblPassword.Visible = false;
			txtPassword.Visible = false;
			lblRePassword.Visible = false;
			txtRePassword.Visible = false;
			reqPassword.Visible = false;
			reqPassword.Enabled = false;
			reqRePassword.Visible = false;
			reqRePassword.Enabled = false;
			compPassword.Visible = false;
			compPassword.Enabled = false;
			panPassword.Visible = false;

			Session["UsuarioUpdate"] = dalUsuario;

		}

		protected void btnCancelar_Click(object sender, EventArgs e)
		{
			Salir();

		}

		private void Salir()
		{
			Session.Remove("UsuarioUpdate");
			if (Convert.ToString(ViewState["IdCliente"]) != "")
				Response.Redirect("/Admin/Clientes/ListaUsuarios.aspx?IdCliente=" + Convert.ToString(ViewState["IdCliente"]));
			else
				Response.Redirect("/Admin/Clientes/ListaUsuarios.aspx");

		}

		protected void btnAceptar_Click(object sender, EventArgs e)
		{
			Usuario dalUsuario;
			if (Convert.ToBoolean(ViewState["FlagAlta"]))
			{
				dalUsuario = new Usuario();
				dalUsuario.Nombre = txtNombre.Text;
				dalUsuario.Apellido = txtApellido.Text;
				dalUsuario.Telefono = txtTelefono.Text;
				dalUsuario.Celular = txtCelular.Text;
				dalUsuario.Email = txtEmail.Text;
				dalUsuario.Calle = txtCalle.Text;
				dalUsuario.Numero = txtNro.Text;
				dalUsuario.Piso = txtPiso.Text;
				dalUsuario.Departamento = txtDpto.Text;
				dalUsuario.Barrio = txtBarrio.Text;
				dalUsuario.CodigoPostal = txtCodPos.Text;
				dalUsuario.IdLocalidad = Convert.ToInt32(ddlLocalidad.SelectedValue);
				dalUsuario.IdProvincia = Convert.ToInt32(ddlProvincia.SelectedValue);
				if (Convert.ToString(ViewState["IdCliente"]) != "")
					dalUsuario.Crear(txtLoginName.Text, txtPassword.Value, Convert.ToInt32(ViewState["IdCliente"]));
				else
					dalUsuario.Crear(txtLoginName.Text, txtPassword.Value);

			}
			else
			{
				dalUsuario = (Usuario) Session["UsuarioUpdate"];
				dalUsuario.Nombre = txtNombre.Text;
				dalUsuario.Apellido = txtApellido.Text;
				dalUsuario.Telefono = txtTelefono.Text;
				dalUsuario.Celular = txtCelular.Text;
				dalUsuario.Email = txtEmail.Text;
				dalUsuario.Calle = txtCalle.Text;
				dalUsuario.Numero = txtNro.Text;
				dalUsuario.Piso = txtPiso.Text;
				dalUsuario.Departamento = txtDpto.Text;
				dalUsuario.Barrio = txtBarrio.Text;
				dalUsuario.CodigoPostal = txtCodPos.Text;
				dalUsuario.IdLocalidad = Convert.ToInt32(ddlLocalidad.SelectedValue);
				dalUsuario.IdProvincia = Convert.ToInt32(ddlProvincia.SelectedValue);
                dalUsuario.Activo = chkActivo.Checked;
				dalUsuario.Modificar();

			}
			if (((Button)sender).Text != "Aceptar")
			{
				Session.Remove("UsuarioUpdate");
				if (ViewState["IdCliente"].ToString() != "")
					Response.Redirect("UsuarioAddRol.aspx?IdUsuario=" + dalUsuario.Id.ToString() + "&From=abm&IdCliente=" + ViewState["IdCliente"].ToString());
				else
					Response.Redirect("UsuarioAddRol.aspx?IdUsuario=" + dalUsuario.Id.ToString() + "&From=abm");
			}
			else
				Salir();
		}

		private void CargarComboProvincias(DropDownList comboProvincia, int IdProvincia)
		{
			UtilesApp Tipos = new UtilesApp();
			comboProvincia.Items.Clear();
			DataTable myTb;
			myTb = Tipos.TraerProvincias();
			ListItem myItem;
			foreach (DataRow myRow in myTb.Rows)
			{
				myItem = new ListItem(myRow[1].ToString(), myRow[0].ToString());
				if (IdProvincia == int.Parse(myRow[0].ToString()))
				{
					comboProvincia.SelectedIndex = -1;
					myItem.Selected = true;
				}
				comboProvincia.Items.Add(myItem);
			}
		}

		private void CargarComboLocalidades(DropDownList comboProvincias, DropDownList comboLocalidades, string IdLocalidad)
		{
			UtilesApp Tipos = new UtilesApp();
			comboLocalidades.Items.Clear();
			DataTable myTb;
			myTb = Tipos.TraerLocalidades(int.Parse(comboProvincias.SelectedItem.Value));
			ListItem myItem;
			foreach (DataRow myRow in myTb.Rows)
			{
				myItem = new ListItem(myRow[1].ToString(), myRow[0].ToString());
				if (IdLocalidad == myRow[0].ToString())
				{
					comboLocalidades.SelectedIndex = -1;
					myItem.Selected = true;
				}
				comboLocalidades.Items.Add(myItem);
			}
		}

		protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
		{
			CargarComboLocalidades(ddlProvincia, ddlLocalidad, "");
		}

	}
}