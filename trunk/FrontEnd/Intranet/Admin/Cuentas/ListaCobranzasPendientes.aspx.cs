using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.Clientes.Dal;
using ar.com.TiempoyGestion.BackEnd.Cobranzas.Dal;

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
            int tipoPeriodo = 0;
            string fechaDesde = "";
            string fechaHasta = "";
            string clientes = "";
            int tipoMorosidad = 1;
            clientes = Request.QueryString["clientes"];

            if (raDiario.Checked) tipoPeriodo = 1;
            if (raMensual.Checked) tipoPeriodo = 2;

           
            if (txtFechaInicio.Text != "")
                fechaDesde = txtFechaInicio.Text;

            if (txtFechaFinal.Text != "")
                fechaHasta = txtFechaFinal.Text;

            if (raTipoMorosidad.SelectedValue != "")
                tipoMorosidad = int.Parse(raTipoMorosidad.SelectedValue);


			//GestorPrecios Adicionales = new GestorPrecios();
            if (tipoPeriodo != 0)
            {
                dgPendientesCobrosClientes.DataSource = GestorPrecios.ListaPendientesCobrosClientes(tipoPeriodo, fechaDesde, fechaHasta, clientes, tipoMorosidad).DefaultView;
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
            //idImprimirDeudaDetalle.s

        }


        protected void idImprimir_Click(object sender, EventArgs e)
        {
            int tipoPeriodo = 2;
            int mostrarSubtotal = 0;
            int tipoMorosidad = 1;
            string clientes = "";
            bool bandera = false;
            tipoPeriodo = (raMensual.Checked) ? 2 : 1;
            mostrarSubtotal = (chkMostrarSubTotal.Checked) ? 1 : 0;
            tipoMorosidad = int.Parse(raTipoMorosidad.SelectedValue);

            foreach (DataGridItem myItem in dgPendientesCobrosClientes.Items)
            {
                try
                {

                    if (((CheckBox)myItem.FindControl("chkCliente")).Checked)
                    {
                        if (!bandera)
                            clientes = myItem.Cells[1].Text;
                        else
                            clientes = clientes + ", " + myItem.Cells[1].Text;
                        
                        bandera = true;
                    }
                    
                }
                catch (Exception exc)
                { }
            }

            Response.Redirect("imprimirDeudaDetalle.aspx?tipoPeriodo=" + tipoPeriodo + "&tipoMorosidad=" + tipoMorosidad + "&subtotal=" + mostrarSubtotal + "&fechaDesde=" + txtFechaInicio.Text + "&fechaHasta=" + txtFechaFinal.Text + "&clientes=" + clientes);

        }
        
}
}
