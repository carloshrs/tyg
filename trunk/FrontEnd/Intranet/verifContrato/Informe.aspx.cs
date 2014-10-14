using System;
using System.Data;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;
using ar.com.TiempoyGestion.BackEnd.Verificaciones.Dal;
using ar.com.TiempoyGestion.BackEnd.Contratos.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.verifContrato
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
		protected Label Label8;
		protected TextBox txtMovParticular;
	
		protected void Page_Load(object sender, EventArgs e)
		{
			idInforme.Value = Request.QueryString["id"];

			if (!Page.IsPostBack)
			{
				if(Request.QueryString["id"] != null)
				{	
					LoadVerifContrato(int.Parse(idInforme.Value));
					
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

		}
		#endregion

		private void LoadVerifContrato(int Id)
		{
			VerifContratoDal oVerifDom = new VerifContratoDal();
			bool cargar = oVerifDom.Cargar(Id);
			if (cargar)
			{
				idReferencia.Value = (1).ToString();
				CargarForm(oVerifDom);
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
			CargarTipoDocumento(oEncabezado.TipoDocumento);
			CargarEstadoCivil(oEncabezado.EstadoCivil);
			txtDocumento.Text = oEncabezado.Documento;
			txtObservaciones.Text = oEncabezado.Comentarios;
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

			ContratosDal contratos = new ContratosDal();
			if (oEncabezado.IdTipoPersona == 1) 
			{
				pnlDomComercial.Visible = false;
				pnlFisica.Visible = true;
				dgridEncabezados.DataSource = contratos.ListaContratosInforme(oEncabezado.Documento, oEncabezado.TipoDocumento);
			} 
			else 
			{
				pnlDomComercial.Visible = true;
				pnlFisica.Visible = false;
				dgridEncabezados.DataSource = contratos.ListaContratosInforme(oEncabezado.Cuit, -1);
			}
			dgridEncabezados.DataBind();

		}


		private void CargarForm(VerifContratoDal oVerifContrato)
		{
			CultureInfo myInfo = new CultureInfo("es-AR");

			idInforme.Value= oVerifContrato.IdInforme.ToString();
			txtNombre.Text= oVerifContrato.Nombre;
			txtApellido.Text = oVerifContrato.Apellido;
			CargarTipoDocumento(oVerifContrato.TipoDocumento);
			CargarEstadoCivil(oVerifContrato.EstadoCivil);
			txtDocumento.Text = oVerifContrato.Documento;
			txtObservaciones.Text = oVerifContrato.Observaciones;

			idTipoPersona.Value = oVerifContrato.IdTipoPersona.ToString();
			//EMPRESA
			RazonSocial.Text = oVerifContrato.RazonSocial;
			NombreFantasia.Text = oVerifContrato.NombreFantasia;
			Telefono.Text = oVerifContrato.TelefonoEmpresa;
			Rubro.Text = oVerifContrato.Rubro;
			Cuit.Text = oVerifContrato.Cuit;
			CalleEmpresa.Text = oVerifContrato.CalleEmpresa;
			NroEmpresa.Text = oVerifContrato.NroEmpresa;
			DptoEmpresa.Text = oVerifContrato.DptoEmpresa;
			PisoEmpresa.Text = oVerifContrato.PisoEmpresa;
			BarrioEmpresa.Text = oVerifContrato.BarrioEmpresa;
			CPEmpresa.Text = oVerifContrato.CPEmpresa;
			// Empresas
			CargarComboProvincias(cmbProvinciaEmpresas, oVerifContrato.ProvinciaEmpresa);
			CargarComboLocalidades(cmbProvinciaEmpresas, cmbLocalidadEmpresas, oVerifContrato.LocalidadEmpresa.ToString());

			ContratosDal contratos = new ContratosDal();
			if (oVerifContrato.IdTipoPersona == 1) 
			{
				pnlDomComercial.Visible = false;
				pnlFisica.Visible = true;
				dgridEncabezados.DataSource = contratos.ListaContratosInforme(oVerifContrato.Documento, oVerifContrato.TipoDocumento);
			} 
			else 
			{
				pnlDomComercial.Visible = true;
				pnlFisica.Visible = false;
				dgridEncabezados.DataSource = contratos.ListaContratosInforme(oVerifContrato.Cuit, -1);
			}
			dgridEncabezados.DataBind();
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


		protected void Cancelar_Click(object sender, EventArgs e)
		{
			Response.Redirect("/BandejaEntrada/Principal.aspx?idTipo=14");
		}

		private void CargarComboLocalidades(DropDownList comboLocalidades, int IdLocalidad)
		{
			UtilesApp Tipos = new UtilesApp();
			comboLocalidades.Items.Clear();
			DataTable myTb;
			myTb = Tipos.TraerLocalidades(2);
			ListItem myItem;
			foreach(DataRow myRow in myTb.Rows)
			{
				myItem = new ListItem(myRow[1].ToString(), myRow[0].ToString());
				if(IdLocalidad == int.Parse(myRow[0].ToString()))
				{
					comboLocalidades.SelectedIndex = -1;
					myItem.Selected = true;
				}
				comboLocalidades.Items.Add(myItem);
			}
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

		protected void AceptarFinalizar_Click(object sender, System.EventArgs e)
		{
			string strScript;
			strScript = "<script languaje=\"Javascript\">";
            strScript += "window.showModalDialog('/BandejaEntrada/PopUpCambioEstado.aspx?idTipo=14&idInforme=" + idInforme.Value + "&Finalizar=1','','dialogWidth:400px;dialogHeight:250px');";
			strScript += "document.location.href = '/BandejaEntrada/Principal.aspx?idTipo=14'";
			strScript += "</script>";
			ActualizarInforme();

			Page.RegisterStartupScript("CambiarEstado", strScript);
		}

		protected void dgridEncabezados_PreRender(object sender, System.EventArgs e)
		{
			foreach (DataGridItem myItem in dgridEncabezados.Items)
			{
				string[] fecha = myItem.Cells[6].Text.Remove(9,myItem.Cells[6].Text.Length -9).Split("/".ToCharArray());
				myItem.Cells[5].Text = fecha[1] + "/" + fecha[0] + "/" + fecha[2];

				fecha = myItem.Cells[8].Text.Remove(9,myItem.Cells[8].Text.Length -9).Split("/".ToCharArray());
				myItem.Cells[7].Text = fecha[1] + "/" + fecha[0] + "/" + fecha[2];

				string strRedir = "ListaPersonas.aspx?tipo=0&Id="+ myItem.Cells[0].Text;
				string strRedirHistorico = "Historial.aspx?Id="+ myItem.Cells[0].Text;
				((ImageButton) myItem.FindControl("Ver")).Attributes.Add("onclick", "javascript: window.open('" + strRedir + "','','tools=no,width=620,menus=no,scrollbars=yes'); return false;");
				((ImageButton) myItem.FindControl("Historico")).Attributes.Add("onclick", "javascript: window.open('" + strRedirHistorico + "','','tools=no,width=620,menus=no,scrollbars=yes'); return false;");
			}

		}

		protected void Aceptar_Click(object sender, System.EventArgs e)
		{
			ActualizarInforme();
			
			Response.Redirect("/BandejaEntrada/Principal.aspx?idTipo=14");
		}

		private void ActualizarInforme()
		{
			VerifContratoDal oVerifContrato = new VerifContratoDal();
			bool cargar = oVerifContrato.Cargar(int.Parse(idInforme.Value));
			// Usuario Logueado
			UsuarioAutenticado Usuario = (UsuarioAutenticado)Session["UsuarioAutenticado"];
			oVerifContrato.IdCliente = Usuario.IdCliente;
			oVerifContrato.IdUsuario = Usuario.IdUsuario;

			oVerifContrato.IdInforme = int.Parse(idInforme.Value);
			oVerifContrato.IdTipoPersona = int.Parse(idTipoPersona.Value);
			
			oVerifContrato.Nombre = txtNombre.Text;
			oVerifContrato.Apellido = txtApellido.Text;
			oVerifContrato.TipoDocumento = int.Parse(cmbTipoDocumento.SelectedItem.Value);
			oVerifContrato.Documento = txtDocumento.Text;
			oVerifContrato.EstadoCivil = int.Parse(cmbEstadoCivil.SelectedValue);
			oVerifContrato.Observaciones = txtObservaciones.Text;

			//EMPRESA
			oVerifContrato.RazonSocial = RazonSocial.Text;
			oVerifContrato.NombreFantasia = NombreFantasia.Text;
			oVerifContrato.TelefonoEmpresa = Telefono.Text;
			oVerifContrato.Rubro = Rubro.Text;
			oVerifContrato.Cuit = Cuit.Text;
			oVerifContrato.CalleEmpresa = CalleEmpresa.Text;
			oVerifContrato.NroEmpresa = NroEmpresa.Text;
			oVerifContrato.DptoEmpresa = DptoEmpresa.Text;
			oVerifContrato.PisoEmpresa = PisoEmpresa.Text;
			oVerifContrato.BarrioEmpresa = BarrioEmpresa.Text;
			oVerifContrato.CPEmpresa = CPEmpresa.Text;
			oVerifContrato.ProvinciaEmpresa = int.Parse(cmbProvinciaEmpresas.SelectedValue);
			oVerifContrato.LocalidadEmpresa = int.Parse(cmbLocalidadEmpresas.SelectedValue);

			if(int.Parse(idReferencia.Value) == 0)
				oVerifContrato.Crear();
			else
				oVerifContrato.Modificar(int.Parse(idInforme.Value));
		
		}

		protected void cmbProvinciaEmpresas_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			CargarComboLocalidades(cmbProvinciaEmpresas, cmbLocalidadEmpresas, "");
		}


	}
}
