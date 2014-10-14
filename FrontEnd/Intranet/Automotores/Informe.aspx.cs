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
using ar.com.TiempoyGestion.BackEnd.Automotores.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.Automotores
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
		protected Label lblObservaciones;
		protected Button Cerrar;
		protected Label Label8;
		protected TextBox txtTelefono;
		protected TextBox txtFecha;
		protected TextBox txtMovParticular;
		protected TextBox txtInformo;
		protected TextBox txtNombreVecino;
		protected TextBox txtDomicilioVecino;
		protected TextBox txtConoceVecino;
		protected TextBox txtPlanoA;
		protected TextBox txtPlanoB;
		protected TextBox txtPlanoC;
		protected TextBox txtPlanoD;
		protected TextBox txtHabita;
		protected TextBox txtRelacion;
		protected TextBox txtAntiguedad;
		protected TextBox txtTelAlternativo;
		protected RadioButtonList raTipoVivienda;
		protected RadioButtonList raEstadoCons;
		protected RadioButtonList raTipoConstruccion;
		protected RadioButtonList raTipoZona;
		protected RadioButtonList raTipoCalle;
		protected RadioButtonList raInteresado;
		protected TextBox txtAccesoDomicilio;
		protected TextBox txtMontoAlquiler;
		protected TextBox txtVencimiento;
		protected TextBox txtEnviar;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator1;
		protected System.Web.UI.WebControls.TextBox Textbox7;
	
		protected void Page_Load(object sender, EventArgs e)
		{
            this.GetPostBackEventReference(this);
			if (!Page.IsPostBack)
			{
				if(Request.QueryString["id"] != null)
				{
                    idInforme.Value = Request.QueryString["id"];
					LoadAutomotores(int.Parse(idInforme.Value));
					ListarTitulares(int.Parse(Request.QueryString["id"]));
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
			this.dgTitulares.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgTitulares_ItemCommand);

		}
		#endregion

		private void LoadAutomotores(int Id)
		{
			AutomotoresApp oAuto = new AutomotoresApp();
			bool cargar = oAuto.Cargar(Id);
			if (cargar)
			{
				idReferencia.Value = (1).ToString();
				CargarForm(oAuto);
			}
			else
			{
				idReferencia.Value = (0).ToString();
				EncabezadoApp oEncabezado = new EncabezadoApp();
				oEncabezado.cargarEncabezado(Id);
				CargarEncabezado(oEncabezado);
                oEncabezado.Leido = 1;
                oEncabezado.CambiarLeido(Id);
			}
		}
		
		private void CargarEncabezado(EncabezadoApp oEncabezado)
		{
			// Automotores
			txtDominio.Text = oEncabezado.Dominio;
			txtRegistro.Text = oEncabezado.Registro;
			txtCalleRegistro.Text = oEncabezado.CalleRegistro;
			txtNroRegistro.Text = oEncabezado.NroRegistro;
			txtDptoRegistro.Text = oEncabezado.DptoRegistro;
			txtPisoRegistro.Text = oEncabezado.PisoRegistro;
			txtBarrioRegistro.Text = oEncabezado.BarrioRegistro;
			txtCPRegistro.Text = oEncabezado.CPRegistro;
			// Registro - Automotor
			CargarComboProvincias(cmbProvinciaRegistro, oEncabezado.ProvinciaRegistro);
			CargarComboLocalidades(cmbProvinciaRegistro, cmbLocalidadRegistro, oEncabezado.LocalidadRegistro.ToString());

			

			txtObservaciones.Text = oEncabezado.Observaciones;
		}

		private void CargarForm(AutomotoresApp oAuto)
		{
			CultureInfo myInfo = new CultureInfo("es-AR");

			idInforme.Value= oAuto.IdInforme.ToString();



			// Automotores
			txtDominio.Text = oAuto.Dominio;
			txtRegistro.Text = oAuto.Registro;
			txtCalleRegistro.Text = oAuto.CalleRegistro;
			txtNroRegistro.Text = oAuto.NroRegistro;
			txtDptoRegistro.Text = oAuto.DptoRegistro;
			txtPisoRegistro.Text = oAuto.PisoRegistro;
			txtBarrioRegistro.Text = oAuto.BarrioRegistro;
			txtCPRegistro.Text = oAuto.CPRegistro;
			// Registro - Automotor
			CargarComboProvincias(cmbProvinciaRegistro, oAuto.ProvinciaRegistro);
			CargarComboLocalidades(cmbProvinciaRegistro, cmbLocalidadRegistro, oAuto.LocalidadRegistro.ToString());

			// Datos Vehículo
			txtMarca.Text = oAuto.Marca;
			txtModelo.Text = oAuto.Modelo;
			txtAno.Text = oAuto.Ano;
			txtNroChasis.Text = oAuto.NroChasis;
			txtNroMotor.Text = oAuto.NroMotor;

			txtObservaciones.Text = oAuto.Observaciones;
			txtGravamenes.Text = oAuto.Gravamenes;
			txtDatosNegativos.Text = oAuto.DatosNegativos;
			txtResultados.Text = oAuto.Resultado;

		}

		private void ListarTitulares(int idInforme)
		{
			AutomotoresApp objAutomotores = new AutomotoresApp();
			dgTitulares.DataSource = objAutomotores.TraerTitulares(idInforme);
			dgTitulares.DataBind();
		}

		protected void Aceptar_Click(object sender, EventArgs e)
		{
			ActualizarInforme();
			
			Response.Redirect("/BandejaEntrada/Principal.aspx?idTipo=2");

		}

		protected void Cancelar_Click(object sender, EventArgs e)
		{
			Response.Redirect("/BandejaEntrada/Principal.aspx?idTipo=2");
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



		protected void AceptarFinalizar_Click(object sender, System.EventArgs e)
		{
			string strScript;
			strScript = "<script languaje=\"Javascript\">";
            strScript += "window.showModalDialog('/BandejaEntrada/PopUpCambioEstado.aspx?idTipo=2&idInforme=" + idInforme.Value + "&Finalizar=1','','dialogWidth:400px;dialogHeight:250px');";
			strScript += "document.location.href = '/BandejaEntrada/Principal.aspx?idTipo=2'";
			strScript += "</script>";

			ActualizarInforme();
			Page.RegisterStartupScript("CambiarEstado", strScript);
		}

		private void ActualizarInforme()
		{
			AutomotoresApp oAuto = new AutomotoresApp();
			bool cargar = oAuto.Cargar(int.Parse(idInforme.Value));
			// Usuario Logueado
			UsuarioAutenticado Usuario = (UsuarioAutenticado)Session["UsuarioAutenticado"];
			oAuto.IdCliente = Usuario.IdCliente;
			oAuto.IdUsuario = Usuario.IdUsuario;
			
			oAuto.IdInforme = int.Parse(idInforme.Value);

		

			// Automotores
            oAuto.Dominio = txtDominio.Text.ToUpper();
            oAuto.Registro = txtRegistro.Text.ToUpper();
			oAuto.CalleRegistro = txtCalleRegistro.Text.ToUpper();
			oAuto.NroRegistro = txtNroRegistro.Text;
			oAuto.DptoRegistro = txtDptoRegistro.Text;
			oAuto.PisoRegistro = txtPisoRegistro.Text;
            oAuto.BarrioRegistro = txtBarrioRegistro.Text.ToUpper();
			oAuto.CPRegistro = txtCPRegistro.Text;
			// Registro - Automotor
			oAuto.ProvinciaRegistro = int.Parse(cmbProvinciaRegistro.SelectedItem.Value);
			oAuto.LocalidadRegistro = int.Parse(cmbLocalidadRegistro.SelectedItem.Value);
			
			// Datos Vehículo
            oAuto.Modelo = txtModelo.Text.ToUpper();
            oAuto.Marca = txtMarca.Text.ToUpper();
			oAuto.Ano = txtAno.Text;
            oAuto.NroChasis = txtNroChasis.Text.ToUpper();
            oAuto.NroMotor = txtNroMotor.Text.ToUpper();

            oAuto.Observaciones = txtObservaciones.Text.ToUpper();
            oAuto.Gravamenes = txtGravamenes.Text.ToUpper();
            oAuto.DatosNegativos = txtDatosNegativos.Text.ToUpper();
            oAuto.Resultado = txtResultados.Text.ToUpper();

			if(int.Parse(idReferencia.Value) == 0)
				oAuto.Crear();
			else
				oAuto.Modificar(int.Parse(idInforme.Value));
		
		}


		protected void cmbProvinciaRegistro_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			CargarComboLocalidades(cmbProvinciaRegistro, cmbLocalidadRegistro, "");
            cmbProvinciaRegistro.Focus();
		}




		protected void dgTitulares_PreRender(object sender, System.EventArgs e)
		{
			float porcentaje = 0;
			totalPorcentaje.Value = (0).ToString();
			foreach(DataGridItem myItem in dgTitulares.Items)
			{
                /*
				if (int.Parse(myItem.Cells[1].Text) == 2)
				{
					myItem.Cells[2].Text = "J";
					myItem.Cells[3].Text = myItem.Cells[8].Text + " de " + myItem.Cells[9].Text;
					myItem.Cells[4].Text = myItem.Cells[11].Text;
					myItem.Cells[5].Text = myItem.Cells[10].Text;
				}
				else
				{
					myItem.Cells[2].Text = "F";
				}
                 */
                if (int.Parse(myItem.Cells[1].Text) == 2)
                {
                    myItem.Cells[2].Text = myItem.Cells[8].Text;
                    myItem.Cells[3].Text = myItem.Cells[10].Text;
                }

                ((ImageButton)myItem.FindControl("Editar")).Attributes.Add("onclick", "javascript: EditarTitular('" + myItem.Cells[0].Text + "');");
				((ImageButton) myItem.FindControl("Borrar")).Attributes.Add("onclick", @"javascript: return confirm('¿Está seguro que desea eliminar el Titular?');");
			}
		}

		private void dgTitulares_ItemCommand(object source, DataGridCommandEventArgs e)
		{
			if (e.Item.Cells[0].Text != "")
			{
				switch(((ImageButton)e.CommandSource).CommandName)
				{
					case "Borrar":
						AutomotoresApp objAutomotores = new AutomotoresApp();
						bool borrar = objAutomotores.BorrarTitular(Convert.ToInt32(e.Item.Cells[0].Text));
						break;
				}
				ListarTitulares(int.Parse(idInforme.Value));
			}

		}

        protected void hAccion_ValueChanged(object sender, EventArgs e)
        {
            ListarTitulares(int.Parse(idInforme.Value));
            hAccion.Value = "0";
            btnNuevo.Focus();
        }
}
}
