﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.Clientes.App;
using ar.com.TiempoyGestion.BackEnd.Clientes.Dal;


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
            int idCliente = 0;
            string[] arrDoc;
            string[] separators = {"_"};
            string vParam ="";
            string concepto = "";
            float montoDebe = 0;
            int tipoDoc = 0;
            int tipoPeriodo = 0;
            float NroDoc = 0;
  

            if ((txtMontoaPagar1.Text != "" && txtMontoaPagar1.Text != "0") || (txtMontoaPagar2.Text != "" && txtMontoaPagar2.Text != "0") || (txtMontoaPagar3.Text != "" && txtMontoaPagar3.Text != "0"))
            {
                
                idCliente = int.Parse(hIdCliente.Value);

                // Begin Transaction
                CuentaCorrienteApp ccCliente = new CuentaCorrienteApp();
                 ccCliente.ValClienteCC(idCliente);
                int idCuentaCliente = ccCliente.ObtenerNroClienteCC(idCliente);
                int idCajaDiaria = ccCliente.ObtenerNroCajaDiaria();
                float SaldoCliente = ccCliente.ObtenerSaldoClienteCC(idCuentaCliente);
                int entrada = 1;
                bool bAddMovCC = false;
                bool bAddMovCaja = false;
                int vIdCuentaClienteDetalle = 0;
                int vIdCajaDetalle = 0;
                float vMontoTotalPagar = 0;

                if (idCajaDiaria != 0)
                {

                    foreach (GridViewRow myItem in GVlistaCobrar.Rows)
                    {
                        if (((CheckBox)myItem.FindControl("chkItem")).Checked)
                        {
                            vParam = myItem.Cells[1].Text; // EJ: 1_1_74 //remito, diario, nro 74
                            arrDoc = vParam.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                            concepto = concepto + myItem.Cells[3].Text + ", ";
                            montoDebe = float.Parse(myItem.Cells[4].Text);

                            //Verificar y registrar en CC Cliente como salida, es decir, informes por cobrar
                            vIdCuentaClienteDetalle = AgregarMovimientoCC(idCuentaCliente, 0, myItem.Cells[3].Text, montoDebe, 0);
                        }
                    }

                    if (txtMontoaPagar1.Text != "" && int.Parse(txtMontoaPagar1.Text) != 0)
                        vMontoTotalPagar = float.Parse(txtMontoaPagar1.Text);

                    if (txtMontoaPagar2.Text != "" && int.Parse(txtMontoaPagar2.Text) != 0)
                        vMontoTotalPagar = vMontoTotalPagar + float.Parse(txtMontoaPagar2.Text);

                    if (txtMontoaPagar3.Text != "" && int.Parse(txtMontoaPagar3.Text) != 0)
                        vMontoTotalPagar = vMontoTotalPagar + float.Parse(txtMontoaPagar3.Text);

                    vIdCuentaClienteDetalle = AgregarMovimientoCC(idCuentaCliente, entrada, concepto, montoDebe, vMontoTotalPagar);

                    ClienteDal dalCliente = new ClienteDal();
                    dalCliente.Cargar(idCliente);
                    string NombreCliente = dalCliente.NombreFantasia;
                    if(dalCliente.Sucursal != "")
                        NombreCliente = NombreCliente +"( " + dalCliente.Sucursal + ")";
                    NombreCliente = NombreCliente + ": ";

                    vIdCajaDetalle = AgregarMovimientoCaja(idCajaDiaria, entrada, NombreCliente + concepto, montoDebe, vMontoTotalPagar);


                    // Se agrega Forma de Pago
                    if (txtMontoaPagar1.Text != "" && int.Parse(txtMontoaPagar1.Text) != 0)
                        AgregarFormaPago(vIdCajaDetalle, int.Parse(cmbFormaPago1.SelectedValue), float.Parse(txtMontoaPagar1.Text));

                    if (txtMontoaPagar2.Text != "" && int.Parse(txtMontoaPagar2.Text) != 0)
                        AgregarFormaPago(vIdCajaDetalle, int.Parse(cmbFormaPago2.SelectedValue), float.Parse(txtMontoaPagar2.Text));

                    if (txtMontoaPagar3.Text != "" && int.Parse(txtMontoaPagar3.Text) != 0)
                        AgregarFormaPago(vIdCajaDetalle, int.Parse(cmbFormaPago3.SelectedValue), float.Parse(txtMontoaPagar3.Text));

                    // Cheques en Cartera

                    foreach (GridViewRow myItem in GVlistaCobrar.Rows)
                    {
                        if (((CheckBox)myItem.FindControl("chkItem")).Checked)
                        {
                            vParam = myItem.Cells[1].Text; // EJ: 1_1_74 //remito, diario, nro 74
                            arrDoc = vParam.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                            tipoDoc = int.Parse(arrDoc[0]);
                            tipoPeriodo = int.Parse(arrDoc[1]);
                            NroDoc = int.Parse(arrDoc[2]);
                            //concepto = myItem.Cells[3].Text;
                            

                            // Agrega documentos de movimientos en CC
                            bAddMovCC = AgregarDocumentosMovimientoCC(idCuentaCliente, tipoDoc, tipoPeriodo, NroDoc, entrada, concepto, montoDebe, 0);
                            bAddMovCaja = AgregarDocumentosMovimientoCaja(idCajaDiaria, tipoDoc, tipoPeriodo, NroDoc, entrada, concepto, montoDebe, 0);

                            //if (Convert.Decimal(((Label)myItem.Cells[1].FindControl("Lbl_Peso")).Text) > 500)
                            //  Cantidades.Add(Convert.Decimal(((Label)fila.Cells[7].FindControl("Lbl_Peso")).Text));
                            //((Label)myItem.FindControl("ID")).Text = DateTime.Parse(myItem.Cells[1].Text).ToShortDateString() + " " + DateTime.Parse(myItem.Cells[1].Text).ToShortTimeString();
                            // 2. Agregar a detalles de factura
                        }
                    }
                }
                else
                {
                    lblMensaje.Text = "No hay apertura de caja en el dia " + DateTime.Now.Date.ToShortDateString();
                }

                Response.Redirect("/Admin/Cuentas/cobranzas.listado.aspx");
                // Agregar movimiento en Caja ultima.

                // 1. Crear Nº de Factura (NO va)
                
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

            CuentaCorrienteApp ccCliente = new CuentaCorrienteApp();
            ccCliente.ValClienteCC(vIdCliente);
            int idCuentaCliente = ccCliente.ObtenerNroClienteCC(vIdCliente);
            float SaldoCliente = ccCliente.ObtenerSaldoClienteCC(idCuentaCliente);
            //if (appCliente.ValClienteCC(vIdCliente))
            //{
                //Si tiene CC el cliente, puede realizar el pago y visualizar el saldo actual
                lblSaldoActual.Text = SaldoCliente.ToString();
                btnPagar.Enabled = true;
                btnActualizarSaldo.Visible = false;
            //}
            //else
            //{
                //Si no tiene CC el cliente se debe poner un saldo inicial de acuerdo a los informes pendientes de cobro.
            //    lblSaldoActual.Text = " ";
            //    btnPagar.Enabled = false;
            //    btnActualizarSaldo.Visible = true;
            //}
        }
        

        private int AgregarMovimientoCC(int idCuentaCliente, int entrada, string concepto, float montoDebe, float montoPagar)
        {
            CuentaCorrienteApp ccMovimiento = new CuentaCorrienteApp();
            return ccMovimiento.AgregarMovimientoCC(idCuentaCliente, entrada, concepto, montoDebe, montoPagar);
        }

        private int AgregarMovimientoCaja(int idCuentaCliente, int entrada, string concepto, float montoDebe, float montoPagar)
        {
            CuentaCorrienteApp ccMovimiento = new CuentaCorrienteApp();
            return ccMovimiento.AgregarMovimientoCaja(idCuentaCliente, entrada, concepto, montoDebe, montoPagar);
        }

        private bool AgregarDocumentosMovimientoCC(int idCuentaCliente, int tipoDoc, int tipoPeriodo, float NroDoc, int entrada, string concepto, float montoDebe, float montoPagar)
        {
            CuentaCorrienteApp ccMovimiento = new CuentaCorrienteApp();
            return ccMovimiento.AgregarDocumentosMovimientoCC(idCuentaCliente, tipoDoc, tipoPeriodo, NroDoc, entrada, concepto, montoDebe, montoPagar);
        }

        private bool AgregarDocumentosMovimientoCaja(int idCuentaCliente, int tipoDoc, int tipoPeriodo, float NroDoc, int entrada, string concepto, float montoDebe, float montoPagar)
        {
            CuentaCorrienteApp ccMovimiento = new CuentaCorrienteApp();
            return ccMovimiento.AgregarDocumentosMovimientoCaja(idCuentaCliente, tipoDoc, tipoPeriodo, NroDoc, entrada, concepto, montoDebe, montoPagar);
        }

        private void AgregarFormaPago(int idCajaDetalle, int idFormaPago, float MontoaPagar)
        {
            CuentaCorrienteApp ccMovimiento = new CuentaCorrienteApp();
            ccMovimiento.AgregarFormaPago(idCajaDetalle, idFormaPago, MontoaPagar);
        }
    }
}