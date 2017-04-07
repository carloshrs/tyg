using System;
using System.Data;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;
using ar.com.TiempoyGestion.BackEnd.Busquedas.Dal;
using ar.com.TiempoyGestion.BackEnd.Clientes.Dal;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.Dal;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.App;
using ar.com.TiempoyGestion.BackEnd.Verificaciones.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Extranet.BusquedaPropiedad
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
		protected System.Web.UI.WebControls.Label lblOcupacion;
		protected System.Web.UI.WebControls.Label lblCargo;
		private int IdInforme;
	
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if(Request.QueryString["id"] != null)
				{	
					IdInforme = int.Parse(Request.QueryString["id"]);
					LoadVerifBusqueda(int.Parse(Request.QueryString["id"]));
                    ListarMatriculas(int.Parse(Request.QueryString["id"]));

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

		private void LoadVerifBusqueda(int Id)
		{
			BusquedaPropiedadApp oBusqueda = new BusquedaPropiedadApp();
			bool cargar = oBusqueda.Cargar(Id);

			EncabezadoApp oEncabezado = new EncabezadoApp();
			oEncabezado.cargarEncabezado(Id);
			ClienteDal cliente = new ClienteDal();
			cliente.Cargar(oEncabezado.IdCliente);
			Usuario usuario = new Usuario();
			usuario.Cargar(oEncabezado.IdUsuario);
            /*
			lblNum.Text = Id.ToString();
			lblFec.Text = DateTime.Today.ToShortDateString();
			lblSolicitante.Text = cliente.RazonSocial;
			lblRef.Text = usuario.Apellido + ", " + usuario.Nombre;
            */
			if (cargar)
			{
				idReferencia.Value = (1).ToString();
                lblNum.Text = Id.ToString();
                lblTipoDocumentoPeriodo.Text = TipoDocumentoPeriodo(cliente.TipoDocumento, cliente.TipoPeriodo);
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

				CargarForm(oBusqueda);
			}
			else
			{
				idReferencia.Value = (0).ToString();
				oEncabezado.cargarEncabezado(Id);
				CargarEncabezado(oEncabezado);
			}

		}


		private void CargarEncabezado(EncabezadoApp oVerif)
		{
			lblNombre.Text= oVerif.Nombre;
			lblApellido.Text = oVerif.Apellido;
			lblTipoDocumento.Text = LoadTipoDNI(oVerif.TipoDocumento);
			//lblEstadoCivil.Text = LoadEstadoCivil(oVerif.EstadoCivil);
			lblDocumento.Text = oVerif.Documento;
		}


		private void CargarForm(BusquedaPropiedadApp oBusquedaProp)
		{
			CultureInfo myInfo = new CultureInfo("es-AR");

			lblNombre.Text= oBusquedaProp.Nombre;
			lblApellido.Text = oBusquedaProp.Apellido;
			lblTipoDocumento.Text = LoadTipoDNI(oBusquedaProp.IdTipoDoc);
			//lblEstadoCivil.Text = LoadEstadoCivil(oBusquedaProp.EstadoCivil);
			lblDocumento.Text = oBusquedaProp.NroDoc.ToString();
			lblObservaciones.Text = oBusquedaProp.Observaciones;
			lblResultado.Text = oBusquedaProp.Resultado;
			//EMPRESA
			lblRazonSocial.Text= oBusquedaProp.RazonSocial;
			lblCUIT.Text= oBusquedaProp.Cuit;
            lblProvincia.Text = CargarProvincias(oBusquedaProp.ProvinciaEmpresa);

			if (oBusquedaProp.IdTipoPersona == 1) 
			{
				pnlJuridica.Visible = false;
				pnlFisica.Visible = true;
			} 
			else {
				pnlFisica.Visible = false;
				pnlJuridica.Visible = true;
			}
		}


		private void ListarMatriculas(int idInforme)
		{
			BusquedaPropiedadApp objBusquedaPropiedad = new BusquedaPropiedadApp();
            dgMatriculas.DataSource = objBusquedaPropiedad.TraerMatriculas(idInforme);
			dgMatriculas.DataBind();
		}

		private void Cancelar_Click(object sender, EventArgs e)
		{
			Response.Redirect("/BandejaEntrada/Principal.aspx?idTipo=" + Request.QueryString["idTipo"]);
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

		private String CargarProvincias(int idProvincia)
		{
			UtilesApp Tipos = new UtilesApp();
			DataTable myTb;
			string Provincia = "";
			myTb = Tipos.TraerProvincias();
			foreach(DataRow myRow in myTb.Rows)
			{
				if(idProvincia.ToString() == myRow[0].ToString())
				{
					Provincia = myRow[1].ToString();
				}
			}
			return Provincia;
		}

        private string TipoDocumentoPeriodo(int TipoDocumento, int TipoPeriodo)
        {
            string cadena = "";
            if (TipoDocumento != 0 && TipoPeriodo != 0)
            {
                if (TipoDocumento == 1)
                    cadena = "<br>R";
                else
                    cadena = "<br>PE";

                if (TipoPeriodo == 1)
                    cadena = cadena + "D";
                else
                    cadena = cadena + "M";

            }
            return cadena;

        }
	}
}
