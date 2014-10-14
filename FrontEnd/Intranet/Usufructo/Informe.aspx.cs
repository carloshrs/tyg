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


namespace ar.com.TiempoyGestion.FrontEnd.Intranet.Usufructo
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
			GravamenesDal Usufructo = new GravamenesDal();
			bool cargar = Usufructo.Cargar(Id, "Usufructos");
			if (cargar)
			{
				idReferencia.Value = (1).ToString();
				CargarForm(Usufructo);
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
			GravamenesDal oUsufructo = new GravamenesDal();
			bool cargar = oUsufructo.Cargar(int.Parse(idInforme.Value), "Usufructos");
			// Usuario Logueado
			UsuarioAutenticado Usuario = (UsuarioAutenticado)Session["UsuarioAutenticado"];
			oUsufructo.IdCliente = Usuario.IdCliente;
			oUsufructo.IdUsuario = Usuario.IdUsuario;
			
			oUsufructo.IdInforme = int.Parse(idInforme.Value);
			oUsufructo.Folio = txtFolio.Text;
			oUsufructo.Tomo = txtTomo.Text;
			oUsufructo.Ano = txtAno.Text;
			oUsufructo.Observaciones = txtObservaciones.Text.ToUpper();

			if(int.Parse(idReferencia.Value) == 0)
				oUsufructo.Crear("Usufructos");
			else
				oUsufructo.Modificar(int.Parse(idInforme.Value), "Usufructos");
		
		}


	}
}
