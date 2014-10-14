using System;
using System.Data;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.App;
using ar.com.TiempoyGestion.BackEnd.Busquedas.Dal;


namespace ar.com.TiempoyGestion.FrontEnd.Intranet.BusquedaAutomotor
{
	/// <summary>
	/// Summary description for altaInforme.
	/// </summary>
	public partial class Informe : Page
	{
		protected TextBox Provincia;
		protected Image Image1;
		protected Image Image2;
		protected Image Image3;
		protected Image Image4;
		protected Button Cerrar;
		protected Label Label2;
		protected Label Label5;
		protected Label Label8;
		protected TextBox txtMovParticular;
	
		protected void Page_Load(object sender, EventArgs e)
		{
			idInforme.Value = Request.QueryString["id"];

			if (!Page.IsPostBack)
			{
				if(Request.QueryString["id"] != null)
				{	
					LoadVerifBusqueda(int.Parse(idInforme.Value));
					ListarDominios(int.Parse(Request.QueryString["id"]));
					
				}
			}
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			// Put user code to initialize the page here
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.dgDominios.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgDominios_ItemCommand);

		}
		#endregion

		private void LoadVerifBusqueda(int Id)
		{
			BusquedaAutomotorApp oBusquedaAutomotor = new BusquedaAutomotorApp();
			bool cargar = oBusquedaAutomotor.Cargar(Id);
			if (cargar)
			{
				idReferencia.Value = (1).ToString();
				CargarForm(oBusquedaAutomotor);
			}
			else
			{
				idReferencia.Value = (0).ToString();
				EncabezadoApp oEncabezado = new EncabezadoApp();
				oEncabezado.cargarEncabezado(Id);
				CargarEncabezado(oEncabezado);
			}
		}


		
		private void CargarEncabezado(EncabezadoApp oEncabezado)
		{
			idTipoPersona.Value = oEncabezado.IdTipoPersona.ToString();

			txtNombre.Text = oEncabezado.Nombre;
			txtApellido.Text = oEncabezado.Apellido;
			txtDocumento.Text = oEncabezado.Documento;
			CargarTipoDocumento(oEncabezado.TipoDocumento);
			CargarEstadoCivil(oEncabezado.EstadoCivil);
			//EMPRESA
			RazonSocial.Text = oEncabezado.RazonSocial;
			NombreFantasia.Text = oEncabezado.NombreFantasia;
			Telefono.Text = oEncabezado.TelefonoEmpresa;
			Rubro.Text = oEncabezado.Rubro;
			Cuit.Text = oEncabezado.Cuit;
			CalleEmpresa.Text = oEncabezado.CalleEmpresa;
			NroEmpresa.Text = oEncabezado.NroEmpresa;
			DptoEmpresa.Text = oEncabezado.DptoEmpresa;
			PisoEmpresa.Text = oEncabezado.PisoEmpresa;
			BarrioEmpresa.Text = oEncabezado.BarrioEmpresa;
			CPEmpresa.Text = oEncabezado.CPEmpresa;
			// Empresas
			CargarComboProvincias(cmbProvinciaEmpresas, oEncabezado.ProvinciaEmpresa);
			CargarComboLocalidades(cmbProvinciaEmpresas, cmbLocalidadEmpresas, oEncabezado.LocalidadEmpresa.ToString());

			if (oEncabezado.IdTipoPersona == 1) 
			{
				pnlDomComercial.Visible = false;
				pnlFisica.Visible = true;
			} else {
				pnlDomComercial.Visible = true;
				pnlFisica.Visible = false;
			}
		}


		private void CargarForm(BusquedaAutomotorApp oBusquedaAuto)
		{
			CultureInfo myInfo = new CultureInfo("es-AR");

			idInforme.Value= oBusquedaAuto.IdInforme.ToString();
			txtNombre.Text= oBusquedaAuto.Nombre;
			txtApellido.Text = oBusquedaAuto.Apellido;
			CargarTipoDocumento(oBusquedaAuto.IdTipoDoc);
			CargarEstadoCivil(oBusquedaAuto.EstadoCivil);
			txtDocumento.Text = oBusquedaAuto.NroDoc.ToString();

			idTipoPersona.Value = oBusquedaAuto.IdTipoPersona.ToString();
			//EMPRESA
			RazonSocial.Text = oBusquedaAuto.RazonSocial;
			NombreFantasia.Text = oBusquedaAuto.NombreFantasia;
			Telefono.Text = oBusquedaAuto.TelefonoEmpresa;
			Rubro.Text = oBusquedaAuto.Rubro;
			Cuit.Text = oBusquedaAuto.Cuit;
			CalleEmpresa.Text = oBusquedaAuto.CalleEmpresa;
			NroEmpresa.Text = oBusquedaAuto.NroEmpresa;
			DptoEmpresa.Text = oBusquedaAuto.DptoEmpresa;
			PisoEmpresa.Text = oBusquedaAuto.PisoEmpresa;
			BarrioEmpresa.Text = oBusquedaAuto.BarrioEmpresa;
			CPEmpresa.Text = oBusquedaAuto.CPEmpresa;
			// Empresas
			CargarComboProvincias(cmbProvinciaEmpresas, oBusquedaAuto.ProvinciaEmpresa);
			CargarComboLocalidades(cmbProvinciaEmpresas, cmbLocalidadEmpresas, oBusquedaAuto.LocalidadEmpresa.ToString());

			if (oBusquedaAuto.IdTipoPersona == 1) 
			{
				pnlDomComercial.Visible = false;
				pnlFisica.Visible = true;
			} 
			else 
			{
				pnlDomComercial.Visible = true;
				pnlFisica.Visible = false;
			}
			
			txtObservaciones.Text = oBusquedaAuto.Observaciones;
			cmbResultado.SelectedValue = oBusquedaAuto.Resultado;


            EncabezadoApp oEncabezado = new EncabezadoApp();
            oEncabezado.Leido = 1;
            oEncabezado.CambiarLeido(oBusquedaAuto.IdInforme);

		}


		protected void Cancelar_Click(object sender, EventArgs e)
		{
			Response.Redirect("/BandejaEntrada/Principal.aspx?idTipo=10");
		}


		private void CargarTipoDocumento(int idTipo)
		{
			cmbTipoDocumento.Items.Clear();
			TipoDocumentoApp objTipoDocumento = new TipoDocumentoApp();
			DataTable dtTipoDoc = objTipoDocumento.TraerDatos();
			ListItem myItem;

			foreach(DataRow myRow in dtTipoDoc.Rows)
			{
				myItem = new ListItem(myRow[1].ToString(), myRow[0].ToString());
				if(idTipo == int.Parse(myRow[0].ToString()))
				{
					cmbTipoDocumento.SelectedIndex = -1;
					myItem.Selected = true;
				}
				cmbTipoDocumento.Items.Add(myItem);
			}
		}

		private void CargarEstadoCivil(int idEstado)
		{
			EstadoCivilApp objEstadoCivil = new EstadoCivilApp();
			DataTable dtEstadoCivil = objEstadoCivil.TraerDatos();
			ListItem myItem;

			foreach(DataRow myRow in dtEstadoCivil.Rows)
			{
				myItem = new ListItem(myRow[1].ToString(), myRow[0].ToString());
				if(idEstado == int.Parse(myRow[0].ToString()))
				{
					cmbEstadoCivil.SelectedIndex = -1;
					myItem.Selected = true;
				}
				cmbEstadoCivil.Items.Add(myItem);
			}
		}



		private void ListarDominios(int idInforme)
		{
			BusquedaAutomotorApp objBusquedaAutomotor = new BusquedaAutomotorApp();
			dgDominios.DataSource = objBusquedaAutomotor.TraerDominios(idInforme);
			dgDominios.DataBind();
		}


		protected void AceptarFinalizar_Click(object sender, EventArgs e)
		{
			string strScript;
			strScript = "<script languaje=\"Javascript\">";
            strScript += "window.showModalDialog('/BandejaEntrada/PopUpCambioEstado.aspx?idTipo=10&idInforme=" + idInforme.Value + "&Finalizar=1','','dialogWidth:400px;dialogHeight:250px');";
			strScript += "document.location.href = '/BandejaEntrada/Principal.aspx?idTipo=10'";
			strScript += "</script>";
			ActualizarInforme();
			Page.RegisterStartupScript("CambiarEstado", strScript);
		}

		protected void dgDominios_PreRender(object sender, System.EventArgs e)
		{
			foreach(DataGridItem myItem in dgDominios.Items)
			{
				((ImageButton) myItem.FindControl("Editar")).Attributes.Add("onclick","window.showModalDialog('abmDominio.aspx?idInforme=" + idInforme.Value + "&IdDominio="+ myItem.Cells[0].Text + "' ,'','dialogWidth:510px;dialogHeight:250px');document.forms[0].submit();");
				((ImageButton) myItem.FindControl("Borrar")).Attributes.Add("onclick", @"javascript: return confirm('¿Está seguro que desea eliminar el Dominio?');");
			}
		}

		private void dgDominios_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.Item.Cells[0].Text != "")
			{
				switch(((ImageButton)e.CommandSource).CommandName)
				{
					case "Borrar":
						BusquedaAutomotorApp objBusquedaAutomotor = new BusquedaAutomotorApp();
						bool borrar = objBusquedaAutomotor.BorrarDominio(Convert.ToInt32(e.Item.Cells[0].Text));
						break;
				}
				ListarDominios(int.Parse(idInforme.Value));
			}
		}

		protected void Aceptar_Click(object sender, System.EventArgs e)
		{
			ActualizarInforme();
			
			Response.Redirect("/BandejaEntrada/Principal.aspx?idTipo=10");

		}

		private void ActualizarInforme()
		{
			BusquedaAutomotorApp objBusquedaAutomotor = new BusquedaAutomotorApp();
			bool cargar = objBusquedaAutomotor.Cargar(int.Parse(idInforme.Value));
			// Usuario Logueado
			UsuarioAutenticado Usuario = (UsuarioAutenticado)Session["UsuarioAutenticado"];
			objBusquedaAutomotor.IdCliente = Usuario.IdCliente;
			objBusquedaAutomotor.IdUsuario = Usuario.IdUsuario;
			
			objBusquedaAutomotor.IdInforme = int.Parse(idInforme.Value);
			objBusquedaAutomotor.IdTipoPersona = int.Parse(idTipoPersona.Value);

			objBusquedaAutomotor.Nombre = txtNombre.Text;
			objBusquedaAutomotor.Apellido = txtApellido.Text;
			objBusquedaAutomotor.IdTipoDoc = int.Parse(cmbTipoDocumento.SelectedValue);
			objBusquedaAutomotor.NroDoc = txtDocumento.Text;
			objBusquedaAutomotor.EstadoCivil = int.Parse(cmbEstadoCivil.SelectedValue);
			objBusquedaAutomotor.Resultado = cmbResultado.SelectedValue;
			objBusquedaAutomotor.Observaciones = txtObservaciones.Text;
			//EMPRESA
			objBusquedaAutomotor.RazonSocial = RazonSocial.Text;
			objBusquedaAutomotor.NombreFantasia = NombreFantasia.Text;
			objBusquedaAutomotor.TelefonoEmpresa = Telefono.Text;
			objBusquedaAutomotor.Rubro = Rubro.Text;
			objBusquedaAutomotor.Cuit = Cuit.Text;
			objBusquedaAutomotor.CalleEmpresa = CalleEmpresa.Text;
			objBusquedaAutomotor.NroEmpresa = NroEmpresa.Text;
			objBusquedaAutomotor.DptoEmpresa = DptoEmpresa.Text;
			objBusquedaAutomotor.PisoEmpresa = PisoEmpresa.Text;
			objBusquedaAutomotor.BarrioEmpresa = BarrioEmpresa.Text;
			objBusquedaAutomotor.CPEmpresa = CPEmpresa.Text;
			objBusquedaAutomotor.ProvinciaEmpresa = int.Parse(cmbProvinciaEmpresas.SelectedValue);
			objBusquedaAutomotor.LocalidadEmpresa = int.Parse(cmbLocalidadEmpresas.SelectedValue);

			if(int.Parse(idReferencia.Value) == 0)
				objBusquedaAutomotor.Crear();
			else
				objBusquedaAutomotor.Modificar(int.Parse(idInforme.Value));

		}

		protected void cmbProvinciaEmpresas_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			CargarComboLocalidades(cmbProvinciaEmpresas, cmbLocalidadEmpresas, "");
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
			
	}
}
