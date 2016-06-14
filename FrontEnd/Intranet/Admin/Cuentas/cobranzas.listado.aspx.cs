using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.Clientes.App;


namespace ar.com.TiempoyGestion.FrontEnd.Intranet.Admin.Cuentas
{
    public partial class facturacion_listaClientes : System.Web.UI.Page
    {
        string FechaDesde = "";
        string FechaHasta = "";

        protected void Page_Load(object sender, EventArgs e)
        {
           if (!Page.IsPostBack)
            {
                if (txtFechaInicio.Text == "")
                    txtFechaInicio.Text = DateTime.Today.AddDays(-60).ToShortDateString();
                if (txtFechaFinal.Text == "")
                    txtFechaFinal.Text = DateTime.Today.ToShortDateString();
            }
        }
        
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            pnlListadoPendiente.Visible = true;
            ListadoDocumentosPendientesCobroClientes();
        }

        protected void btnPagar_Click(object sender, EventArgs e)
        {
            if ((txtMontoaPagar1.Text != "" || txtMontoaPagar1.Text != "0") && (txtMontoaPagar2.Text != "" || txtMontoaPagar2.Text != "0") && (txtMontoaPagar3.Text != "" || txtMontoaPagar3.Text != "0"))
            { 
                
            }
        }


        protected void WzPagosDocumentos_FinishButtonClick(object sender, WizardNavigationEventArgs e)
        {
            float vMontoaPagar=0;
            int idCliente = 0;
            string vDoc="";

            if ((txtMontoaPagar1.Text != "" && txtMontoaPagar1.Text != "0") || (txtMontoaPagar2.Text != "" && txtMontoaPagar2.Text != "0") || (txtMontoaPagar3.Text != "" && txtMontoaPagar3.Text != "0"))
            {
                vMontoaPagar = float.Parse(txtMontoaPagar1.Text);
                idCliente = int.Parse(hIdCliente.Value);

                // Begin Transaction

                foreach (GridViewRow myItem in GVlistaCobrar.Rows)
			    {
                    if (((CheckBox)myItem.FindControl("chkItem")).Checked)
                    {
                        vDoc = myItem.Cells[1].Text;
                        ((Label)myItem.FindControl("ID")).Text = DateTime.Parse(myItem.Cells[1].Text).ToShortDateString() + " " + DateTime.Parse(myItem.Cells[1].Text).ToShortTimeString();

                        // Verificar si existe
                        // 2. Agregar a detalles de factura
                    }
                }

                // 1. Crear Nº de Factura

                // 3. Agregar a CC detalle de cliente de tipo entrada
                // 4. Calculo y actualizacion de Saldo en CC
                // 5. Setear Estados "Cobrado" en R y PE

                //verificarDocumentosSalida();
                //setearEstadoDocumentos();
            }


        }
        protected void WzPagosDocumentos_NextButtonClick(object sender, WizardNavigationEventArgs e)
        {
            
            if (txtCobroSubTotal.Value != "" && txtCobroSubTotal.Value != "0")
            {
                lblCliente.Text = txtCliente.Text.Replace("/n", "<br>");
                lblMonto.Text = "$ " + txtCobroSubTotal.Value;
                txtMontoaPagar1.Text = txtCobroSubTotal.Value;

                ObtenerSaldoActual();
            }
            else
                e.Cancel = true;
            
        }


        
        protected void WzPagosDocumentos_SideBarButtonClick(object sender, WizardNavigationEventArgs e)
        {
            if (txtCobroSubTotal.Value != "" && txtCobroSubTotal.Value != "0")
            {
                lblCliente.Text = txtCliente.Text.Replace("/n", "<br>");
                lblMonto.Text = "$ " + txtCobroSubTotal.Value;
            }
            else
                e.Cancel = true;
        }


        private void ListadoDocumentosPendientesCobroClientes()
        {
            int idCliente = int.Parse(hIdCliente.Value);
            if (txtFechaInicio.Text == "")
                txtFechaInicio.Text = DateTime.Today.AddDays(-60).ToShortDateString();
            FechaDesde = txtFechaInicio.Text;

            if (txtFechaFinal.Text == "")
                txtFechaFinal.Text = DateTime.Today.ToShortDateString();
            FechaHasta = txtFechaFinal.Text;

            GestorPreciosApp documentos = new GestorPreciosApp();
            documentos.ActualizarMontosDocumentos(idCliente, FechaDesde, FechaHasta);
            GVlistaCobrar.DataSource = documentos.ListaDocumentosPendientesCobrar(idCliente, FechaDesde, FechaHasta, 1);
            //GVlistaCobrar.DataSource = NorthwindData.GetAllProduct();
            GVlistaCobrar.DataBind();
        }

        protected void GVlistaCobrar_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //GridView1.PageIndex = e.NewPageIndex;
            ListadoDocumentosPendientesCobroClientes();
        }

        private void ObtenerSaldoActual() 
        {
            int vIdCliente = int.Parse(hIdCliente.Value);

            CuentaCorrienteApp appCliente = new CuentaCorrienteApp();

            if (appCliente.ValClienteCC(vIdCliente))
            {
                //Si tiene CC el cliente, puede realizar el pago y visualizar el saldo actual
                lblSaldoActual.Text = appCliente.ObtenerSaldoClienteCC(vIdCliente).ToString();
                btnPagar.Enabled = true;
                btnActualizarSaldo.Visible = false;
            }
            else
            {
                //Si no tiene CC el cliente se debe poner un saldo inicial de acuerdo a los informes pendientes de cobro.
                lblSaldoActual.Text = " ";
                btnPagar.Enabled = false;
                btnActualizarSaldo.Visible = true;
            }
        }
        
    }
}