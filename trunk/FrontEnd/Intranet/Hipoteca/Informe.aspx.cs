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
using ar.com.TiempoyGestion.BackEnd.Gravamenes.Dal;


namespace ar.com.TiempoyGestion.FrontEnd.Intranet.Hipoteca
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
			GravamenesDal Hipoteca = new GravamenesDal();
			bool cargar = Hipoteca.Cargar(Id, "Hipotecas");
			if (cargar)
			{
				idReferencia.Value = (1).ToString();
				CargarForm(Hipoteca);
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
			txtFolio.Text = oEncabezado.Folio;
			txtTomo.Text = oEncabezado.Tomo;
			txtAno.Text = oEncabezado.Ano;
			txtObservaciones.Text = oEncabezado.Comentarios;

            oEncabezado.Leido = 1;
            oEncabezado.CambiarLeido(oEncabezado.IdEncabezado);

		}


		private void CargarForm(GravamenesDal oGrav)
		{
			CultureInfo myInfo = new CultureInfo("es-AR");

			idInforme.Value= oGrav.IdInforme.ToString();
			txtFolio.Text= oGrav.Folio;
			txtTomo.Text = oGrav.Tomo;
			txtAno.Text = oGrav.Ano;
			txtObservaciones.Text = oGrav.Observaciones;
		}


		protected void Cancelar_Click(object sender, EventArgs e)
		{
			Response.Redirect("/BandejaEntrada/Principal.aspx?idTipo=3");
		}

		protected void AceptarFinalizar_Click(object sender, System.EventArgs e)
		{
			string strScript;
			strScript = "<script languaje=\"Javascript\">";
            strScript += "window.showModalDialog('/BandejaEntrada/PopUpCambioEstado.aspx?idTipo=3&idInforme=" + idInforme.Value + "&Finalizar=1','','dialogWidth:400px;dialogHeight:250px');";
			strScript += "document.location.href = '/BandejaEntrada/Principal.aspx?idTipo=3'";
			strScript += "</script>";
			ActualizarInforme();

			Page.RegisterStartupScript("CambiarEstado", strScript);
		}

		protected void Aceptar_Click(object sender, System.EventArgs e)
		{
			ActualizarInforme();
			
			Response.Redirect("/BandejaEntrada/Principal.aspx?idTipo=3");
		}

		private void ActualizarInforme()
		{
			GravamenesDal oHipoteca = new GravamenesDal();
			bool cargar = oHipoteca.Cargar(int.Parse(idInforme.Value), "Hipotecas");
			// Usuario Logueado
			UsuarioAutenticado Usuario = (UsuarioAutenticado)Session["UsuarioAutenticado"];
			oHipoteca.IdCliente = Usuario.IdCliente;
			oHipoteca.IdUsuario = Usuario.IdUsuario;

			oHipoteca.IdInforme = int.Parse(idInforme.Value);
			oHipoteca.Folio = txtFolio.Text;
			oHipoteca.Tomo = txtTomo.Text;
			oHipoteca.Ano = txtAno.Text;
            oHipoteca.Observaciones = txtObservaciones.Text.ToUpper();

			if(int.Parse(idReferencia.Value) == 0)
				oHipoteca.Crear("Hipotecas");
			else
				oHipoteca.Modificar(int.Parse(idInforme.Value), "Hipotecas");
		
		}


	}
}
