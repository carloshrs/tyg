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
using ar.com.TiempoyGestion.BackEnd.Gravamenes.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Extranet.Inhibicion
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
			lblFec.Text = DateTime.Today.ToShortDateString();
			lblSolicitante.Text = cliente.RazonSocial;
			//lblRef.Text = usuario.Apellido + ", " + usuario.Nombre;
            if (oEncabezado.idReferencia != 0)
                lblRef.Text = oEncabezado.NombreReferencia.ToUpper();
            else if (oEncabezado.UsuarioCliente != "")
                lblRef.Text = oEncabezado.UsuarioCliente.ToUpper();
            else
                lblRef.Text = usuario.Apellido.ToUpper() + ", " + usuario.Nombre.ToUpper();

			
			InhibicionesDal oInhibicion = new InhibicionesDal();
			oInhibicion.Cargar(Id);
			CargarForm(oInhibicion);
		}


		private void CargarForm(InhibicionesDal oVerif)
		{
			lblNombre.Text= oVerif.Nombre;
			lblApellido.Text = oVerif.Apellido;
			lblTipoDocumento.Text = LoadTipoDNI(oVerif.TipoDocumento);
			lblDocumento.Text = oVerif.Documento;

			//EMPRESA
			lblRazonSocial.Text= oVerif.RazonSocial;
			lblCUIT.Text= oVerif.Cuit;

			if (oVerif.IdTipoPersona == 1) 
			{
				pnlJuridica.Visible = false;
				pnlFisica.Visible = true;
			} 
			else 
			{
				pnlFisica.Visible = false;
				pnlJuridica.Visible = true;
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


	}
}
