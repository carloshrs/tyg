using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;
using ar.com.TiempoyGestion.BackEnd.Clientes.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.Admin.Clientes
{
	/// <summary>
	/// Summary description for AbmCliente.
	/// </summary>
	public partial class AbmCliente : Page
	{
		#region Elementos Web
		
		private bool bolFlagAlta;

		#endregion

		#region Page_Load(object sender, EventArgs e)

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.QueryString["idCliente"] != null && Request.QueryString["idCliente"].ToString() != "")
				{
					//Cargar Cliente
					CargarCliente(Convert.ToInt32(Request.QueryString["idCliente"]));
					btnUsuarios.Enabled = true;
					bolFlagAlta = false;
				}
				else
				{
					bolFlagAlta = true;
					btnUsuarios.Enabled = false;
					CargarComboProvincias(ddlProvincia, 2);
					CargarComboLocalidades(ddlProvincia, ddlLocalidad, "1");

				}
				ViewState["Alta"] = bolFlagAlta.ToString();
			}
		}

		#endregion

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

		#region Métodos Privados

		#region CargarCliente(int lIdCliente)

		private void CargarCliente(int lIdCliente)
		{
			ClienteDal dalCliente = new ClienteDal();
			dalCliente.Cargar(lIdCliente);

			txtRazonSocial.Text = dalCliente.RazonSocial;
            lblRazonSocialFox.Text = dalCliente.RazonSocialFox;
            txtNombreFantasia.Text = dalCliente.NombreFantasia;
            txtSucursal.Text = dalCliente.Sucursal;
			txtCUIT.Text = dalCliente.CUIT;
			txtIngBrutos.Text = dalCliente.IngresosBrutos;
			txtTelefono.Text = dalCliente.Telefono;
			txtFax.Text = dalCliente.Fax;
			txtEmail.Text = dalCliente.Email;
			txtCalle.Text = dalCliente.Calle;
			txtNro.Text = dalCliente.Numero;
			txtPiso.Text = dalCliente.Piso;
			txtDpto.Text = dalCliente.Departamento;
			txtBarrio.Text = dalCliente.Barrio;
			txtCodPos.Text = dalCliente.CodigoPostal;
			CargarComboProvincias(ddlProvincia, dalCliente.IdProvincia);
			CargarComboLocalidades(ddlProvincia, ddlLocalidad, dalCliente.IdLocalidad.ToString());
            txtEncargado.Text = dalCliente.Encargado;
            txtCargo.Text = dalCliente.Cargo;
            txtObservaciones.Text = dalCliente.Observaciones;
            //bool tipoDocumento = false;
            raTipoDocumento1.Checked = (dalCliente.TipoDocumento == 1) ? true : false;
            raTipoDocumento2.Checked = (dalCliente.TipoDocumento == 2) ? true : false;
            raTipoPeriodo1.Checked = (dalCliente.TipoPeriodo == 1) ? true : false;
            raTipoPeriodo2.Checked = (dalCliente.TipoPeriodo == 2) ? true : false;

			Session.Add("Cliente",dalCliente);
		}

		#endregion

		#region CargarComboLocalidades(DropDownList comboProvincias, DropDownList comboLocalidades, string IdLocalidad)

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

		#endregion

		#region CargarComboProvincias(DropDownList comboProvincia, int IdProvincia)

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

		#endregion

		#region Salir(bool resultado)

		private void Salir(bool resultado)
		{
			Session.Remove("Cliente");
			if (resultado==false)
				Response.Redirect("/PaginaError.aspx");
			else
				Response.Redirect("/Admin/Clientes/ListaClientes.aspx");
		}

		#endregion
		
		#endregion

		#region Eventos
		
		#region btnAceptar_Click(object sender, EventArgs e)
		
		protected void btnAceptar_Click(object sender, EventArgs e)
		{
			bool resultado=false;
			ClienteDal dalCliente;
			if (Convert.ToBoolean(ViewState["Alta"]))
			{
				dalCliente = new ClienteDal();
				dalCliente.RazonSocial = txtRazonSocial.Text.ToUpper();
                dalCliente.NombreFantasia = txtNombreFantasia.Text.ToUpper();
                dalCliente.Sucursal = txtSucursal.Text.ToUpper();
				dalCliente.CUIT = txtCUIT.Text;
				dalCliente.IngresosBrutos = txtIngBrutos.Text;
				dalCliente.Telefono = txtTelefono.Text;
				dalCliente.Fax = txtFax.Text;
				dalCliente.Email = txtEmail.Text;
				dalCliente.Calle = txtCalle.Text;
				dalCliente.Numero = txtNro.Text;
				dalCliente.Piso = txtPiso.Text;
				dalCliente.Departamento = txtDpto.Text;
				dalCliente.Barrio = txtBarrio.Text;
				dalCliente.CodigoPostal = txtCodPos.Text;
				dalCliente.IdLocalidad = Convert.ToInt32(ddlLocalidad.SelectedValue);
				dalCliente.IdProvincia = Convert.ToInt32(ddlProvincia.SelectedValue);
                dalCliente.Encargado = txtEncargado.Text;
                dalCliente.Cargo = txtCargo.Text;
                dalCliente.Observaciones = txtObservaciones.Text;
				//resultado=dalCliente.Crear();				
			}
			else
			{
				dalCliente = (ClienteDal) Session["Cliente"];
				dalCliente.RazonSocial = txtRazonSocial.Text;
                dalCliente.NombreFantasia = txtNombreFantasia.Text.ToUpper();
                dalCliente.Sucursal = txtSucursal.Text.ToUpper();
				dalCliente.CUIT = txtCUIT.Text;
				dalCliente.IngresosBrutos = txtIngBrutos.Text;
				dalCliente.Telefono = txtTelefono.Text;
				dalCliente.Fax = txtFax.Text;
				dalCliente.Email = txtEmail.Text;
				dalCliente.Calle = txtCalle.Text;
				dalCliente.Numero = txtNro.Text;
				dalCliente.Piso = txtPiso.Text;
				dalCliente.Barrio = txtBarrio.Text;
				dalCliente.CodigoPostal = txtCodPos.Text;
				dalCliente.Departamento = txtDpto.Text;
				dalCliente.IdLocalidad = Convert.ToInt32(ddlLocalidad.SelectedValue);
				dalCliente.IdProvincia = Convert.ToInt32(ddlProvincia.SelectedValue);
                dalCliente.Encargado = txtEncargado.Text;
                dalCliente.Cargo = txtCargo.Text;
                dalCliente.Observaciones = txtObservaciones.Text;

                //Tipo de Documento
                // 1- REMITO : 2- PARTE DE ENTREGA
                //Tipo Periodo
                // 1- DIARIO : 2- MENSUAL

                int tipoDocumento = 0;
                if (raTipoDocumento1.Checked)
                    tipoDocumento = 1;
                if (raTipoDocumento2.Checked)
                    tipoDocumento = 2;
                dalCliente.TipoDocumento = tipoDocumento;

                int tipoPeriodo = 0;
                if (raTipoPeriodo1.Checked)
                    tipoPeriodo = 1;
                if (raTipoPeriodo2.Checked)
                    tipoPeriodo = 2;
                dalCliente.TipoPeriodo = tipoPeriodo;


				resultado=dalCliente.Modificar();
			}
			Salir(resultado);
		}

		#endregion

		#region btnCancelar_Click(object sender, EventArgs e)

		protected void btnCancelar_Click(object sender, EventArgs e)
		{
			Salir(true);

		}

		#endregion

		#region btnUsuarios_Click(object sender, EventArgs e)

		protected void btnUsuarios_Click(object sender, EventArgs e)
		{
			int idCliente = ((ClienteDal) Session["Cliente"]).Id;
			Response.Redirect("/Admin/Clientes/ListaUsuarios.aspx?IdCliente=" + idCliente.ToString());

		}

		#endregion

		#region ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)

		protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
		{
			CargarComboLocalidades(ddlProvincia, ddlLocalidad, "");
		}

		#endregion

		#endregion																
	}
}