using System;
using System.Data;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;
using ar.com.TiempoyGestion.BackEnd.Contratos.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Extranet.Contratos
{
	/// <summary>
	/// Summary description for altaInforme.
	/// </summary>
	public partial class altaContrato : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox Provincia;
		
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			// Put user code to initialize the page here
            Aceptar.Attributes.Add("onclick", "javascript: deshabilitarBotones(" + Aceptar.ClientID + ");");
			CargarTipoContrato();
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


		protected void Aceptar_Click(object sender, System.EventArgs e)
		{
			ContratoAPP contrato = new ContratoAPP();
			contrato.IdTipo = int.Parse(cmbTipoContrato.SelectedValue);
			// Usuario Logueado
			UsuarioAutenticado Usuario = (UsuarioAutenticado)Session["UsuarioAutenticado"];
			contrato.IdCliente = Usuario.IdCliente;
			contrato.IdUsuario = Usuario.IdUsuario;
			contrato.Descripcion = Observaciones.Text.ToString();

			contrato.Numero = txtNumero.Text.ToString();
			contrato.FechaInicio = txtFechaInicio.Text.ToString();
			contrato.FechaFin = txtFechaFin.Text.ToString();
			
			
			int idNewContrato = contrato.Crear();
			Response.Redirect("ListaPersonas.aspx?Id=" + idNewContrato);
		}

		private void CargarTipoContrato()
		{
			ContratosDal Tipos = new ContratosDal();
			cmbTipoContrato.DataSource = Tipos.TraerTipoContrato();
			cmbTipoContrato.DataTextField = "Descripcion";
			cmbTipoContrato.DataValueField = "idTipoContrato";
			cmbTipoContrato.DataBind();
		}

	}
}
