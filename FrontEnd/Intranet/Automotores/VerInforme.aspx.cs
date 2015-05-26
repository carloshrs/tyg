using System;
using System.Data;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;
using ar.com.TiempoyGestion.BackEnd.Clientes.Dal;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.Dal;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;
using ar.com.TiempoyGestion.BackEnd.Automotores.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.Automotores
{
	/// <summary>
	/// Summary description for altaInforme.
	/// </summary>
	public partial class verInforme : Page
	{
		protected RequiredFieldValidator reqNombre;
		protected RequiredFieldValidator reqApellido;
		protected DropDownList cmbEstadoCivil;
		protected DropDownList cmbTipoDocumento;
		protected RequiredFieldValidator RequiredFieldValidator2;
		protected RequiredFieldValidator RequiredFieldValidator3;
		protected RequiredFieldValidator RequiredFieldValidator6;
		protected RequiredFieldValidator RequiredFieldValidator7;
		protected DropDownList cmbProvincia;
		protected DropDownList cmbLocalidad;
		protected System.Web.UI.WebControls.Label lblFecha;
		protected System.Web.UI.WebControls.Label lblHabita;
		protected System.Web.UI.WebControls.Label lblAntiguedad;
		protected System.Web.UI.WebControls.Label lblTelefonoAlt;
		protected System.Web.UI.WebControls.Label lblMonto;
		protected System.Web.UI.WebControls.Label lblVencimiento;
		protected System.Web.UI.WebControls.Label lblEnviar;
		protected System.Web.UI.WebControls.Label lblTipoVivienda;
		protected System.Web.UI.WebControls.Label lblEstadoConservacion;
		protected System.Web.UI.WebControls.Label lblTipoConstruccion;
		protected System.Web.UI.WebControls.Label lblTipoZona;
		protected System.Web.UI.WebControls.Label lblTipoCalle;
		protected System.Web.UI.WebControls.Label lblInteresado;
		protected System.Web.UI.WebControls.Label lblAccesoDomicilio;
		protected System.Web.UI.WebControls.Label lblInformo;
		protected System.Web.UI.WebControls.Label lblRelacion;
		protected System.Web.UI.WebControls.Label lblNombreVecino;
		protected System.Web.UI.WebControls.Label lblDomicilioVecino;
		protected System.Web.UI.WebControls.Label lblConoceVecino;
		protected System.Web.UI.WebControls.Label lblPlanoA;
		protected System.Web.UI.WebControls.Label lblPlanoB;
		protected System.Web.UI.WebControls.Label lblPlanoC;
		protected System.Web.UI.WebControls.Label lblPlanoD;
		private int IdInforme;
	
		protected void Page_Load(object sender, EventArgs e)
		{
            dlTitulares.ItemDataBound +=
             new DataListItemEventHandler(this.Item_Bound);

			if (!Page.IsPostBack)
			{
				if(Request.QueryString["id"] != null)
				{	
					IdInforme = int.Parse(Request.QueryString["id"]);
					LoadInforme(IdInforme);
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

		}
		#endregion

		private void LoadInforme(int Id)
		{
			AutomotoresApp oAuto = new AutomotoresApp();

			EncabezadoApp oEncabezado = new EncabezadoApp();
			oEncabezado.cargarEncabezado(Id);
			ClienteDal cliente = new ClienteDal();
			cliente.Cargar(oEncabezado.IdCliente);
			Usuario usuario = new Usuario();
			usuario.Cargar(oEncabezado.IdUsuario);

			bool cargar = oAuto.Cargar(Id);

			if (cargar)
			{
				lblNum.Text = Id.ToString();
				//lblFec.Text = DateTime.Today.ToShortDateString();
                if (oEncabezado.FechaFin != "")
                    lblFec.Text = Convert.ToDateTime(oEncabezado.FechaFin).ToShortDateString();
                string solicitante = "";
                if (cliente.NombreFantasia != null && cliente.NombreFantasia != "")
                    solicitante = cliente.NombreFantasia;
                else
                    solicitante = cliente.RazonSocial;
                if (cliente.Sucursal != null && cliente.Sucursal != "")
                    solicitante = solicitante + " (" + cliente.Sucursal + ")";
                lblSolicitante.Text = solicitante;

                string direccion = "";
                direccion = cliente.Calle + " " + cliente.Numero;
                if (cliente.Piso != "")
                {
                    direccion = direccion + " Piso: " + cliente.Piso;
                    direccion = direccion + " Dpto/Of: " + cliente.Departamento;
                }
                direccion = direccion + ". " + cliente.Barrio;
                lblDireccionSolicitante.Text = direccion;

                if (oEncabezado.idReferencia != 0)
                    lblRef.Text = oEncabezado.NombreReferencia.ToUpper();
                else if (oEncabezado.UsuarioCliente != "")
                    lblRef.Text = oEncabezado.UsuarioCliente.ToUpper();
                else
                    lblRef.Text = usuario.Apellido.ToUpper() + ", " + usuario.Nombre.ToUpper();
				
                CargarForm(oAuto);
			}
		}



		private void CargarForm(AutomotoresApp oAuto)
		{
			// Automotores
			lblDominio.Text = oAuto.Dominio;
			lblRegistro.Text = oAuto.Registro;
			lblCalleRegistro.Text = oAuto.CalleRegistro;
			lblNroRegistro.Text = oAuto.NroRegistro;
			lblDptoRegistro.Text = oAuto.DptoRegistro;
			lblpisoRegistro.Text = oAuto.PisoRegistro;
			lblBarrioRegistro.Text = oAuto.BarrioRegistro;
			lblCPRegistro.Text = oAuto.CPRegistro;
			// Registro - Automotor
			lblProvinciaRegistro.Text = CargarProvincias(oAuto.ProvinciaRegistro);
			lblLocalidadRegistro.Text = CargarLocalidades(oAuto.ProvinciaRegistro, oAuto.LocalidadRegistro);

			// Datos Vehículo
			lblMarca.Text = oAuto.Marca;
			lblModelo.Text = oAuto.Modelo;
			lblAno.Text = oAuto.Ano;
			lblNroChasis.Text = oAuto.NroChasis;
			lblNroMotor.Text = oAuto.NroMotor;

			lblObservaciones.Text = oAuto.Observaciones;
			lblGravamenes.Text = oAuto.Gravamenes;
			lblDatosNegativos.Text = oAuto.DatosNegativos;
			lblResultados.Text = oAuto.Resultado;
		}

		private void Cancelar_Click(object sender, EventArgs e)
		{
			Response.Redirect("/BandejaEntrada/Principal.aspx?idTipo=2");
		}


		private string LoadEstadoCivil(int EstadoCivil)
		{
			UtilesApp Tipos = new UtilesApp();
			string Estado = "";
			DataTable myTb;
			myTb = Tipos.TraerEstadoCivil();
			foreach(DataRow myRow in myTb.Rows)
			{
				if(EstadoCivil.ToString() == myRow[0].ToString())
				{
					Estado= myRow[1].ToString();			
				}
			}
			return Estado;
		}

		private string LoadTipoDNI(int DNI)
		{
			UtilesApp Tipos = new UtilesApp();
			string TipoDNI="";
			DataTable myTb;
			myTb = Tipos.TraerTipoDocumento();
			foreach(DataRow myRow in myTb.Rows)
			{
				if(DNI.ToString() == myRow[0].ToString())
				{
					TipoDNI= myRow[1].ToString();			
				}
			}
			return TipoDNI;
		}


		private string CargarProvincias(int IdProvincia)
		{
			UtilesApp Tipos = new UtilesApp();
			string Provincia= "";
			DataTable myTb;
			myTb = Tipos.TraerProvincias();
			foreach(DataRow myRow in myTb.Rows)
			{
				if(IdProvincia == int.Parse(myRow[0].ToString()))
				{
					Provincia = myRow[1].ToString();
				}
			}
			return Provincia;
		}

		private String CargarLocalidades(int idProvincia, int IdLocalidad)
		{
			UtilesApp Tipos = new UtilesApp();
			DataTable myTb;
			string Localidad = "";
			myTb = Tipos.TraerLocalidades(idProvincia);
			foreach(DataRow myRow in myTb.Rows)
			{
				if(IdLocalidad.ToString() == myRow[0].ToString())
				{
					Localidad = myRow[1].ToString();
				}
			}
			return Localidad;
		}


		private void ListarTitulares(int idInforme)
		{
			AutomotoresApp objAutomotores = new AutomotoresApp();
			dlTitulares.DataSource = objAutomotores.TraerTitulares(idInforme);
			dlTitulares.DataBind();
		}



        protected void Item_Bound(Object sender, DataListItemEventArgs e)
        {

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (((DataRowView)e.Item.DataItem).Row.ItemArray[1].ToString() == "1")
                {
                    ((Panel)e.Item.FindControl("pnlFisica")).Visible = true;
                    ((Panel)e.Item.FindControl("pnlJuridica")).Visible = false;
                    ((Label)e.Item.FindControl("lblProvincia")).Text = CargarProvincias(int.Parse(((DataRowView)e.Item.DataItem).Row.ItemArray[17].ToString()));
                    ((Label)e.Item.FindControl("lblLocalidad")).Text = CargarLocalidades(int.Parse(((DataRowView)e.Item.DataItem).Row.ItemArray[17].ToString()), int.Parse(((DataRowView)e.Item.DataItem).Row.ItemArray[16].ToString()));
                }
                else
                {
                    ((Panel)e.Item.FindControl("pnlFisica")).Visible = false;
                    ((Panel)e.Item.FindControl("pnlJuridica")).Visible = true;
                    ((Label)e.Item.FindControl("lblProvinciaEmpresa")).Text = CargarProvincias(int.Parse(((DataRowView)e.Item.DataItem).Row.ItemArray[25].ToString()));
                }
            }
                //((Label)e.Item.FindControl("lblFecha")).Text = ((DataRowView)e.Item.DataItem).Row.ItemArray[7].ToString();
        }
	}
}
