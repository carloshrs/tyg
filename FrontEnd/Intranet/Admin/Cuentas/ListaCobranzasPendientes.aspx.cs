using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.Clientes.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.Admin.Seguridad.Admin.Cuentas
{
	/// <summary>
	/// Summary description for ListaFunciones.
	/// </summary>
    public partial class ListaCobranzasPendientes : Page
	{
	
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
                //string idCaja = "";
                //idCaja = Request.QueryString["id"];
                //hdIdCaja.Value = idCaja;
                //pnlEncabezado.Visible = true;
                if (txtFechaInicio.Text == "")
                {
                    txtFechaInicio.Text = DateTime.Today.AddMonths(-2).ToShortDateString();
                    //FechaDesde = txtFechaInicio.Text;
                }
                if (txtFechaFinal.Text == "")
                {
                    txtFechaFinal.Text = DateTime.Today.ToShortDateString();
                    //FechaHasta = txtFechaFinal.Text;
                }
				

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
            this.dgPendientesCobrosClientes.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgPendientesCobrosClientes_ItemCommand);

		}
		#endregion



        private void ListarCobrosPendientesClientes()
		{
            int tipoDocumento = 0;
            int tipoPeriodo = 0;
            string fechaDesde = "";
            string fechaHasta = "";

            if (raDiario.Checked) tipoPeriodo = 1;
            if (raMensual.Checked) tipoPeriodo = 2;

            if (raRemito.Checked) tipoDocumento = 1;
            if (raParte.Checked) tipoDocumento = 2;

            if (txtFechaInicio.Text != "")
                fechaDesde = txtFechaInicio.Text;

            if (txtFechaFinal.Text != "")
                fechaHasta = txtFechaFinal.Text;

			//GestorPrecios Adicionales = new GestorPrecios();
            if (tipoDocumento != 0 && tipoPeriodo != 0)
            {
                dgPendientesCobrosClientes.DataSource = GestorPrecios.ListaPendientesCobrosClientes(tipoDocumento, tipoPeriodo, fechaDesde, fechaHasta).DefaultView;
                dgPendientesCobrosClientes.DataBind();
            }

		}



        protected void dgPendientesCobrosClientes_ItemCommand(object source, DataGridCommandEventArgs e)
		{
			if (e.Item.Cells[0].Text != "")
			{
				switch(((ImageButton)e.CommandSource).CommandName)
				{

                    case "Detalle":
                        Response.Redirect("ListaCobranzasPendientesDetalle.aspx?idCliente=" + e.Item.Cells[0].Text + "&fechaDesde=" + txtFechaInicio.Text + "&fechaHasta=" + txtFechaFinal.Text);
                        break;

				}
			}
		}







        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            ListarCobrosPendientesClientes();

        }
}
}
