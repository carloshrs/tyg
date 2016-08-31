using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;
using ar.com.TiempoyGestion.BackEnd.Clientes.Dal;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.Dal;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.App;
using ar.com.TiempoyGestion.BackEnd.Verificaciones.Dal;
using ar.com.TiempoyGestion.BackEnd.Contratos.Dal;
using ar.com.TiempoyGestion.BackEnd.Contratos.App;

namespace ar.com.TiempoyGestion.FrontEnd.Extranet.verifContrato
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
		private int IdInforme;
	
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if(Request.QueryString["id"] != null)
				{	
					IdInforme = int.Parse(Request.QueryString["id"]);
					LoadInforme(IdInforme);
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

			EncabezadoApp oEncabezado = new EncabezadoApp();
			oEncabezado.cargarEncabezado(Id);
			ClienteDal cliente = new ClienteDal();
			cliente.Cargar(oEncabezado.IdCliente);
			Usuario usuario = new Usuario();
			usuario.Cargar(oEncabezado.IdUsuario);
			lblNum.Text = Id.ToString();
            lblTipoDocumentoPeriodo.Text = TipoDocumentoPeriodo(cliente.TipoDocumento, cliente.TipoPeriodo);
			lblFec.Text = DateTime.Today.ToShortDateString();
			lblSolicitante.Text = cliente.RazonSocial;
			lblRef.Text = usuario.Apellido + ", " + usuario.Nombre;
			
			VerifContratoDal oVerifContrato = new VerifContratoDal();
			oVerifContrato.Cargar(Id);
			CargarForm(oVerifContrato);
		}


		private void CargarForm(VerifContratoDal oVerif)
		{
			lblNombre.Text= oVerif.Nombre;
			lblApellido.Text = oVerif.Apellido;
			lblTipoDocumento.Text = LoadTipoDNI(oVerif.TipoDocumento);
			lblEstadoCivil.Text = LoadEstadoCivil(oVerif.EstadoCivil);
			lblDocumento.Text = oVerif.Documento;
			//EMPRESA
			lblNombreFantasia.Text = oVerif.NombreFantasia;
			lblRazonSocial.Text= oVerif.RazonSocial;
			lblRubro.Text= oVerif.Rubro;
			lblCUIT.Text= oVerif.Cuit;
			lblCalle.Text= oVerif.CalleEmpresa;
			lblBarrio.Text= oVerif.BarrioEmpresa;
			lblNro.Text= oVerif.NroEmpresa;
			lblPiso.Text= oVerif.PisoEmpresa;
			lblDpto.Text= oVerif.DptoEmpresa;
			lblCP.Text= oVerif.CPEmpresa;
			lblTelefono.Text= oVerif.TelefonoEmpresa;
			lblLocalidad.Text = CargarLocalidades(23, oVerif.LocalidadEmpresa);

			ContratosApp contratos = new ContratosApp();
			if (oVerif.IdTipoPersona == 1) 
			{
				pnlJuridica.Visible = false;
				pnlFisica.Visible = true;
				txtGrilla.Text = contratos.ImprimirInforme(oVerif.Documento, oVerif.TipoDocumento).ToString();
			} 
			else 
			{
				pnlFisica.Visible = false;
				pnlJuridica.Visible = true;
				txtGrilla.Text = contratos.ImprimirInforme(oVerif.Cuit, -1).ToString();
			}

			lblObservaciones.Text = oVerif.Observaciones;

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
