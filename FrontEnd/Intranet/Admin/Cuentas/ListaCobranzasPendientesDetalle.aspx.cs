using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.Clientes.Dal;
using ar.com.TiempoyGestion.BackEnd.Clientes.App;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.Admin.Seguridad.Admin.Cuentas
{
	/// <summary>
	/// Summary description for ListaFunciones.
	/// </summary>
    public partial class ListaCobranzasPendientesDetalle : Page
	{
	
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
                //string idCaja = "";
                //idCaja = Request.QueryString["id"];
                //hdIdCaja.Value = idCaja;
                //pnlEncabezado.Visible = true;
                int idCliente = int.Parse(Request.QueryString["idCliente"]);
                string FechaDesde = Request.QueryString["fechaDesde"];
                string FechaHasta = Request.QueryString["fechaHasta"];

                int vEstado = 1;
                    //FechaDesde = txtFechaInicio.Text;
                
                ClienteDal vCargar = new ClienteDal();
                vCargar.Cargar(idCliente);
                lblCliente.Text = vCargar.NombreFantasia;
                lblFechaInicio.Text = FechaDesde;
                lblFechaFinal.Text = FechaHasta;

                GestorPreciosApp documentos = new GestorPreciosApp();
                dgPendientesCobrosClienteDetalle.DataSource = documentos.ListaDocumentosPendientesCobrar(idCliente, FechaDesde, FechaHasta, vEstado);
                //GVlistaCobrar.DataSource = NorthwindData.GetAllProduct();
                dgPendientesCobrosClienteDetalle.DataBind();

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
            //this.dgPendientesCobrosClientes.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgPendientesCobrosClientes_ItemCommand);

		}
		#endregion

}
}
