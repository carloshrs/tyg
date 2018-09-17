using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.Cobranzas.App;
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
                    txtFechaInicio.Text = DateTime.Today.AddYears(-1).ToShortDateString();
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

            realizarCobranzas();

            Response.Redirect("/Admin/Cuentas/ListaCobranzas.aspx");
            // Agregar movimiento en Caja ultima.

            // 1. Crear Nº de Factura (NO va)
                
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


       private void realizarCobranzas()
        {
            int idCliente = 0;
            string[] arrDoc;
            string[] separators = {"_"};
            string vParam ="";
            int idConcepto = 0;
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

                    // Anulamos el ingreso de CC como ingreso ya que toma por el total. Se segmentará segun formas de pago
                    //vIdCuentaClienteDetalle = AgregarMovimientoCC(idCuentaCliente, entrada, concepto, montoDebe, vMontoTotalPagar);

                    ClienteDal dalCliente = new ClienteDal();
                    dalCliente.Cargar(idCliente);
                    string NombreCliente = dalCliente.NombreFantasia;
                    if (dalCliente.Sucursal != "")
                        NombreCliente = NombreCliente + "( " + dalCliente.Sucursal + ")";
                    NombreCliente = NombreCliente + ": ";

                    vIdCajaDetalle = AgregarMovimientoCaja(idCajaDiaria, entrada, idConcepto, NombreCliente.Replace("'", "''") + concepto, montoDebe, vMontoTotalPagar, "");
                    int idCajaDetalleFormaPago = 0;

                    // Se agrega Forma de Pago
                    if (txtMontoaPagar1.Text != "" && int.Parse(txtMontoaPagar1.Text) != 0)
                    {
                        vIdCuentaClienteDetalle = AgregarMovimientoCC(idCuentaCliente, entrada, concepto + ", (" + cmbFormaPago1.SelectedItem + ")", montoDebe, float.Parse(txtMontoaPagar1.Text));
                        idCajaDetalleFormaPago = AgregarFormaPago(vIdCajaDetalle, int.Parse(cmbFormaPago1.SelectedValue), float.Parse(txtMontoaPagar1.Text), entrada);
                    }

                    // Cheques en Cartera
                    if (cmbFormaPago1.SelectedValue == "2")
                        AgregarChequeCartera(idCajaDetalleFormaPago, float.Parse(txtMontoaPagar1.Text), txtBanco1.Text, txtNroCheque1.Text, txtFechaEmision1.Text, txtFechaCobro1.Text, idCliente);


                    if (txtMontoaPagar2.Text != "" && int.Parse(txtMontoaPagar2.Text) != 0)
                    {
                        vIdCuentaClienteDetalle = AgregarMovimientoCC(idCuentaCliente, entrada, concepto + ", (" + cmbFormaPago2.SelectedItem + ")", montoDebe, float.Parse(txtMontoaPagar2.Text));
                        idCajaDetalleFormaPago = AgregarFormaPago(vIdCajaDetalle, int.Parse(cmbFormaPago2.SelectedValue), float.Parse(txtMontoaPagar2.Text), entrada);
                    }

                    // Cheques en Cartera
                    if (cmbFormaPago2.SelectedValue == "2")
                        AgregarChequeCartera(idCajaDetalleFormaPago, float.Parse(txtMontoaPagar2.Text), txtBanco2.Text, txtNroCheque2.Text, txtFechaEmision2.Text, txtFechaCobro2.Text, idCliente);

                    if (txtMontoaPagar3.Text != "" && int.Parse(txtMontoaPagar3.Text) != 0)
                    {
                        vIdCuentaClienteDetalle = AgregarMovimientoCC(idCuentaCliente, entrada, concepto + ", (" + cmbFormaPago3.SelectedItem + ")", montoDebe, float.Parse(txtMontoaPagar3.Text));
                        idCajaDetalleFormaPago = AgregarFormaPago(vIdCajaDetalle, int.Parse(cmbFormaPago3.SelectedValue), float.Parse(txtMontoaPagar3.Text), entrada);
                    }

                    // Cheques en Cartera
                    if (cmbFormaPago3.SelectedValue == "2")
                        AgregarChequeCartera(idCajaDetalleFormaPago, float.Parse(txtMontoaPagar3.Text), txtBanco3.Text, txtNroCheque3.Text, txtFechaEmision3.Text, txtFechaCobro3.Text, idCliente);



                    // Cuenta Corriente Cliente
                    if (cmbFormaPago1.SelectedValue == "4" && txtMontoaPagar1.Text != "" && int.Parse(txtMontoaPagar1.Text) != 0)
                        AjustarCuentaCliente(idCuentaCliente, float.Parse(txtMontoaPagar1.Text));

                    if (cmbFormaPago2.SelectedValue == "4" && txtMontoaPagar2.Text != "" && int.Parse(txtMontoaPagar2.Text) != 0)
                        AjustarCuentaCliente(idCuentaCliente, float.Parse(txtMontoaPagar2.Text));

                    if (cmbFormaPago3.SelectedValue == "4" && txtMontoaPagar3.Text != "" && int.Parse(txtMontoaPagar3.Text) != 0)
                        AjustarCuentaCliente(idCuentaCliente, float.Parse(txtMontoaPagar3.Text));



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
                            bAddMovCC = AgregarDocumentosMovimientoCC(vIdCuentaClienteDetalle, tipoDoc, tipoPeriodo, NroDoc);
                            bAddMovCaja = AgregarDocumentosMovimientoCaja(vIdCajaDetalle, tipoDoc, tipoPeriodo, NroDoc);

                            CambioEstadoDocumentos(tipoDoc, tipoPeriodo, NroDoc);
                            //Cambiar estado
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
            }
        }


        private void ListadoDocumentosPendientesCobroClientes()
        {
            int vEstado = 1;
            if (chBorrador.Checked) vEstado = 3;
            int idCliente = int.Parse(hIdCliente.Value);
            if (txtFechaInicio.Text == "")
                txtFechaInicio.Text = DateTime.Today.AddYears(-1).ToShortDateString();
            FechaDesde = txtFechaInicio.Text;

            if (txtFechaFinal.Text == "")
                txtFechaFinal.Text = DateTime.Today.ToShortDateString();
            FechaHasta = txtFechaFinal.Text;

            GestorPreciosApp documentos = new GestorPreciosApp();
            documentos.ActualizarMontosDocumentos(idCliente, FechaDesde, FechaHasta);
            GVlistaCobrar.DataSource = documentos.ListaDocumentosPendientesCobrar(idCliente, FechaDesde, FechaHasta, vEstado);
            //GVlistaCobrar.DataSource = NorthwindData.GetAllProduct();
            GVlistaCobrar.DataBind();
        }

        protected void GVlistaCobrar_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //GridView1.PageIndex = e.NewPageIndex;
            //ListadoDocumentosPendientesCobroClientes();
            //pnlListadoPendiente.Visible = true;
            GVlistaCobrar.PageIndex = e.NewPageIndex;
            //GVlistaCobrar.DataBind();
            pnlListadoPendiente.Visible = true;
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

            if (SaldoCliente > 0)
            {
                ListItem iCC = new ListItem("Saldo en CC $ " + SaldoCliente.ToString(), "4");
                cmbFormaPago1.Items.Add(iCC);
                cmbFormaPago2.Items.Add(iCC);
                cmbFormaPago3.Items.Add(iCC);

                float vMonto = float.Parse(lblMonto.Text.Replace("$ ", ""));
                if (vMonto <= SaldoCliente)
                    txtMontoaPagar1.Text = vMonto.ToString();
                else
                    txtMontoaPagar1.Text = SaldoCliente.ToString();
            }
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

        private int AgregarMovimientoCaja(int idCajaDiaria, int entrada, int idConcepto, string concepto, float montoDebe, float montoPagar, string observaciones)
        {
            CuentaCorrienteApp ccMovimiento = new CuentaCorrienteApp();
            return ccMovimiento.AgregarMovimientoCaja(idCajaDiaria, entrada, idConcepto, concepto, montoDebe, montoPagar, observaciones);
        }

        private bool AgregarDocumentosMovimientoCC(int idCuentaClienteDetalle, int tipoDoc, int tipoPeriodo, float NroDoc)
        {
            CuentaCorrienteApp ccMovimiento = new CuentaCorrienteApp();
            return ccMovimiento.AgregarDocumentosMovimientoCC(idCuentaClienteDetalle, tipoDoc, tipoPeriodo, NroDoc);
        }

        private bool AgregarDocumentosMovimientoCaja(int idCajaDetalle, int tipoDoc, int tipoPeriodo, float NroDoc)
        {
            CuentaCorrienteApp ccMovimiento = new CuentaCorrienteApp();
            return ccMovimiento.AgregarDocumentosMovimientoCaja(idCajaDetalle, tipoDoc, tipoPeriodo, NroDoc);
        }

            private void CambioEstadoDocumentos(int tipoDoc, int tipoPeriodo, float NroDoc)
        {
            CuentaCorrienteApp ccMovimiento = new CuentaCorrienteApp();
            ccMovimiento.CambioEstadoDocumentos(tipoDoc, tipoPeriodo, NroDoc);
        }

        private int AgregarFormaPago(int idCajaDetalle, int idFormaPago, float MontoaPagar, int entradasalida)
        {
            CuentaCorrienteApp ccMovimiento = new CuentaCorrienteApp();
            return ccMovimiento.AgregarFormaPago(idCajaDetalle, idFormaPago, MontoaPagar, entradasalida);
        }

        private void AgregarChequeCartera(int idCajaDetalleFormaPago, float MontoaPagar, string vBanco, string vNroCheque, string vFechaEmision, string vFechaCobro, int idCliente)
        {
            CuentaCorrienteApp ccMovimiento = new CuentaCorrienteApp();
            ccMovimiento.AgregarChequeCartera(idCajaDetalleFormaPago, MontoaPagar, vBanco, vNroCheque, vFechaEmision, vFechaCobro, idCliente);
        }

        private void AjustarCuentaCliente(int idCuentaCliente, float MontoaPagar)
        {
            CuentaCorrienteApp ccMovimiento = new CuentaCorrienteApp();
            ccMovimiento.AjustarCuentaCliente(idCuentaCliente, MontoaPagar);
        }
        

        protected void btnPendientes_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Admin/Cuentas/ListaCobranzasPendientes.aspx");
        }

        protected void cmbFormaPago1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFormaPago1.SelectedValue == "2")
                pnlCheque1.Visible = true;
            else
                pnlCheque1.Visible = false;
        }

        protected void cmbFormaPago2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFormaPago2.SelectedValue == "2")
                pnlCheque2.Visible = true;
            else
                pnlCheque2.Visible = false;
        }

        protected void cmbFormaPago3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFormaPago3.SelectedValue == "2")
                pnlCheque3.Visible = true;
            else
                pnlCheque3.Visible = false;
        }
        protected void AgregarPago2_Click(object sender, EventArgs e)
        {

            if (pnlPago2.Visible)
            {
                pnlPago2.Visible = false;
                btnAgregarPago2.Text = "+";
            }
            else
            {
                pnlPago2.Visible = true;
                btnAgregarPago2.Text = "-";
            }
        }
        protected void AgregarPago3_Click(object sender, EventArgs e)
        {
            if (pnlPago3.Visible)
            {
                pnlPago3.Visible = false;
                btnAgregarPago3.Text = "+";
            }
            else
            {
                pnlPago3.Visible = true;
                btnAgregarPago3.Text = "-";
            }
        }
}
}