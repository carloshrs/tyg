using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;
using ar.com.TiempoyGestion.BackEnd.Contratos.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.Contratos
{
	/// <summary>
	/// Summary description for ListaInformes.
	/// </summary>
	public partial class Historial : Page
	{
		private int idContrato;

		protected void Page_Load(object sender, EventArgs e)
		{
			// Put user code to initialize the page here
			// Usuario Logueado
			if(Request.QueryString["Id"] != null)
			{	
				idContrato = int.Parse(Request.QueryString["Id"]);
			}
			if (!Page.IsPostBack) 
			{

				ContratosDal contratos = new ContratosDal();
				dgridEncabezados.DataSource = contratos.ListaHistorico(idContrato);
				dgridEncabezados.DataBind();
				CargarContrato(idContrato);
			}
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();

			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.dgridEncabezados.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgridEncabezados_ItemCommand);

		}
		#endregion

		protected void btnInforme_Click(object sender, EventArgs e)
		{
			Page.RegisterClientScriptBlock("onClick", "<script>popup('abmHistorico.aspx?idContrato=" + idContrato + "','no', 'no','500','250');</script>"); 
		}


		protected void dgridEncabezados_PreRender(object sender, EventArgs e)
		{
			foreach (DataGridItem myItem in dgridEncabezados.Items)
			{
				((ImageButton)myItem.FindControl("Cancelar")).Attributes.Add("onclick",@"javascript: return confirm('�Est� seguro que desea Eliminar el Hist�rico del Contrato?');");

			}
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
			else 
			{
				Response.Redirect("ListaContratos.aspx");
			}
		}

		private void dgridEncabezados_ItemCommand(object source, DataGridCommandEventArgs e)
		{
			if (e.Item.Cells[0].Text != "")
			{
				int IdCodigo = int.Parse(e.Item.Cells[0].Text);
				switch(((ImageButton)e.CommandSource).CommandName)
				{
					case "Cancelar":
						EliminarHistorico(IdCodigo);
						Response.Redirect("Historial.aspx?id="+ idContrato);
						break;

					case "Editar":
						Page.RegisterClientScriptBlock("onClick", "<script>popup('abmHistorico.aspx?id=" + IdCodigo + "&idContrato=" + idContrato + "','no', 'no','500','250');</script>"); 
						break;
				}
			}
		}

		private void EliminarHistorico(int id)
		{
			ContratoAPP contrato = new ContratoAPP();
			contrato.EliminarHistorico(id);
		}

	}
}
