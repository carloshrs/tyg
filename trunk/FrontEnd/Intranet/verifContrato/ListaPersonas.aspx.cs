using System;
using System.Data;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;
using ar.com.TiempoyGestion.BackEnd.Contratos.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.verifContrato
{
	/// <summary>
	/// Summary description for altaInforme.
	/// </summary>
	public partial class ListaPersonas : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button Aceptar;
		protected System.Web.UI.WebControls.TextBox Provincia;
		private int idContrato;
		private int tipo = 0;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(Request.QueryString["Id"] != null)
			{	
				idContrato = int.Parse(Request.QueryString["Id"]);
				if(Request.QueryString["tipo"] != null)
				{	
					tipo = int.Parse(Request.QueryString["tipo"]);
				}

			}
			if (!Page.IsPostBack) 
			{
				ContratosDal contratos = new ContratosDal();
				CargarContrato(idContrato);
				dgridContratos.DataSource = contratos.CargarPersonasContratos(idContrato);
				dgridContratos.DataBind();
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


		private void Aceptar_Click(object sender, System.EventArgs e)
		{
			//ContratoAPP contrato = new ContratoAPP();
			// Usuario Logueado
			//UsuarioAutenticado Usuario = (UsuarioAutenticado)Session["UsuarioAutenticado"];
			
			//contrato.Crear();
			Response.Redirect("ListaContratos.aspx");
		}

		private void Cancelar_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("ListaContratos.aspx");
		}

		private void CargarContrato(int idContrato)
		{
			ContratoAPP contrato = new ContratoAPP();
			if (contrato.Cargar(idContrato)) 
			{
				txtNumero.Text = contrato.Numero;
				txtFechaInicio.Text = contrato.FechaInicio;
				txtFechaFin.Text = contrato.FechaFin;
				txtDescripcion.Text = contrato.Descripcion;
				txtTipoContrato.Text = contrato.TipoContrato;
			
			} 
			else {
				Response.Redirect("ListaContratos.aspx");
			}
		}



		protected void dgridContratos_PreRender_1(object sender, System.EventArgs e)
		{
			foreach (DataGridItem myItem in dgridContratos.Items)
			{
				if (myItem.Cells[7].Text == "1")  // Persona Física
				{
					myItem.Cells[2].Text = "<B>Apellido y Nombre: </B>" + myItem.Cells[4].Text + ", " + myItem.Cells[3].Text;
				} 
				else 
				{ // Persona jurídica
					myItem.Cells[2].Text = "<B>Razón Social: </B>" + myItem.Cells[6].Text + " - <B>Cuit: </B> " + myItem.Cells[5].Text;
				}
				 
			}
		}

	}
}
