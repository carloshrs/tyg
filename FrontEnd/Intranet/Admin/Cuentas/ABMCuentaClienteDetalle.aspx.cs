using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.Clientes.Dal;
using System.Data;
using ar.com.TiempoyGestion.BackEnd.Cobranzas.App;
using ar.com.TiempoyGestion.BackEnd.Cobranzas.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.Admin.Cuentas
{
	/// <summary>
	/// Summary description for ListaFunciones.
	/// </summary>
    public partial class ABMCuentaClienteDetalle : Page
	{
	
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
                string idCliente = "";

                idCliente = Request.QueryString["id"];
                CuentaCorrienteApp vCCCliente = new CuentaCorrienteApp();
                vCCCliente.ValClienteCC(int.Parse(idCliente));
                int idCuentaCliente = vCCCliente.ObtenerNroClienteCC(int.Parse(idCliente));
                hdIdCuentaCliente.Value = idCuentaCliente.ToString();

                ListaConceptos(1);
                    
                pnlEncabezado.Visible = true;
                CargarEncabezadoCCDetalle(idCuentaCliente);
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
		}
		#endregion

        protected void btnNuevaApertura_Click(object sender, EventArgs e)
		{
            Response.Redirect("ABMCuentaClienteDetalle.aspx");
		}





        private void CargarEncabezadoCCDetalle(int idCuentaCliente)
        {
            GestorPrecios CajaEncabezado = new GestorPrecios();
            //CajaEncabezado.CargarCaja(int.Parse(idCaja));
            //lblFechaApertura.Text = CajaEncabezado.Apertura;
            //lblFechaCierre.Text = CajaEncabezado.Cierre;
            //lblEfectivoInicial.Text = CajaEncabezado.EfectivoInicial.ToString();
            //lblChequeInicial.Text = CajaEncabezado.ChequeInicial.ToString();
            //lblSaldoEfectivo.Text = CajaEncabezado.SaldoEfectivo.ToString();
            //lblSaldoCheque.Text = CajaEncabezado.SaldoCheque.ToString();
        }


        private void ListaConceptos(int idTipoIngreso)
        {
            cmbConcepto.Items.Clear();
            DataTable myTb;
            myTb = GestorPrecios.ListarConceptos("", 2, idTipoIngreso);
            ListItem myItem;
            foreach (DataRow myRow in myTb.Rows)
            {
                myItem = new ListItem(myRow[1].ToString(), myRow[0].ToString());
                cmbConcepto.Items.Add(myItem);
            }
        }

        protected void cmbTipoIngreso_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListaConceptos(int.Parse(cmbTipoIngreso.SelectedValue));
        }


        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            int vIdCajaDetalle = 0;
            CuentaCorrienteApp ccCliente = new CuentaCorrienteApp();
            //ccCliente.ValClienteCC(hdIdCuentaCliente);
            int idCuentaCliente = int.Parse(hdIdCuentaCliente.Value);
            int idCajaDiaria = ccCliente.ObtenerNroCajaDiaria();

            //GestorPrecios CajaEncabezado = new GestorPrecios();

            GestorPrecios.CrearCuentaClienteDetalle(int.Parse(hdIdCuentaCliente.Value), int.Parse(cmbTipoIngreso.SelectedValue), cmbConcepto.SelectedItem.ToString() + ", " + txtConceptoAdicional.Text, int.Parse(cmbFormaPago.SelectedValue), float.Parse(txtMonto.Text));

            ClienteDal dalCliente = new ClienteDal();
            int idCliente = int.Parse(Request.QueryString["id"]);
            dalCliente.Cargar(idCliente);
            string NombreCliente = dalCliente.NombreFantasia;
            if (dalCliente.Sucursal != "")
                NombreCliente = NombreCliente + "( " + dalCliente.Sucursal + ")";
            NombreCliente = NombreCliente + ": ";


            if (raIngresaCaja.SelectedItem.Text == "SI")
            {
                int idCajaDetalleFormaPago = 0;
                vIdCajaDetalle = AgregarMovimientoCaja(idCajaDiaria, int.Parse(cmbTipoIngreso.SelectedValue), NombreCliente + cmbConcepto.SelectedItem.ToString() + ", " + txtConceptoAdicional.Text, float.Parse(txtMonto.Text), float.Parse(txtMonto.Text), txtObservaciones.Text);

                // Se agrega Forma de Pago
                if (txtMonto.Text != "" && int.Parse(txtMonto.Text) != 0)
                    idCajaDetalleFormaPago = AgregarFormaPago(vIdCajaDetalle, int.Parse(cmbFormaPago.SelectedValue), float.Parse(txtMonto.Text), int.Parse(cmbTipoIngreso.SelectedValue));

                // Cheques en Cartera
                if (cmbFormaPago.SelectedValue == "2")
                    AgregarChequeCartera(idCajaDetalleFormaPago, float.Parse(txtMonto.Text), txtBanco.Text, txtNroCheque.Text, txtFechaEmision.Text, txtFechaCobro.Text, idCliente);

            }

            Response.Redirect("ListaCuentaCorrienteCliente.aspx?idCliente=" + Request.QueryString["id"]);
        }

        private int AgregarMovimientoCaja(int idCuentaCliente, int entrada, string concepto, float montoDebe, float montoPagar, string observaciones)
        {
            //return GestorPrecios.CrearCajaDetalle(0, int.Parse(cmbTipoIngreso.SelectedValue), cmbConcepto.SelectedItem.ToString(), float.Parse(txtMonto.Text), txtObservaciones.Text);
            CuentaCorrienteApp ccMovimiento = new CuentaCorrienteApp();
            return ccMovimiento.AgregarMovimientoCaja(idCuentaCliente, entrada, concepto, montoDebe, montoPagar, observaciones);
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

        protected void cmbFormaPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFormaPago.SelectedValue == "2")
                pnlCheque.Visible = true;
            else
                pnlCheque.Visible = false;
        }
}
}
