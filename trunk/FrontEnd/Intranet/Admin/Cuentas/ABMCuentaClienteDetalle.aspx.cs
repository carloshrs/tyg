using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.Clientes.Dal;
using System.Data;
using ar.com.TiempoyGestion.BackEnd.Clientes.App;

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
                string idCuentaCliente = "";
                idCuentaCliente = Request.QueryString["idCuentaCliente"];
                hdIdCuentaCliente.Value = idCuentaCliente;

                ListaConceptos(0);
                    
                pnlEncabezado.Visible = true;
                CargarEncabezadoCaja(idCuentaCliente);
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





        private void CargarEncabezadoCaja(string idCaja)
        {
            GestorPrecios CajaEncabezado = new GestorPrecios();
            CajaEncabezado.CargarCaja(int.Parse(idCaja));
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

            GestorPrecios.CrearCuentaClienteDetalle(int.Parse(hdIdCuentaCliente.Value), int.Parse(cmbTipoIngreso.SelectedValue), cmbConcepto.SelectedItem.ToString(), int.Parse(cmbFormaPago.SelectedValue), float.Parse(txtMonto.Text), txtObservaciones.Text);

            ClienteDal dalCliente = new ClienteDal();
            dalCliente.Cargar(hdIdCuentaCliente.Value);
            string NombreCliente = dalCliente.NombreFantasia;
            if (dalCliente.Sucursal != "")
                NombreCliente = NombreCliente + "( " + dalCliente.Sucursal + ")";
            NombreCliente = NombreCliente + ": ";

            vIdCajaDetalle = AgregarMovimientoCaja(idCuentaCliente, int.Parse(cmbTipoIngreso.SelectedValue), NombreCliente + cmbConcepto.SelectedItem.ToString(), float.Parse(txtMonto.Text), float.Parse(txtMonto.Text));


            // Se agrega Forma de Pago
            if (txtMonto.Text != "" && int.Parse(txtMonto.Text) != 0)
                AgregarFormaPago(vIdCajaDetalle, int.Parse(cmbFormaPago.SelectedValue), float.Parse(txtMonto.Text), int.Parse(cmbTipoIngreso.SelectedValue));


            Response.Redirect("ListaCuentaCorrienteCliente.aspx?id=" + hdIdCuentaCliente.Value);
        }

        private int AgregarMovimientoCaja(int idCuentaCliente, int entrada, string concepto, float montoDebe, float montoPagar)
        {
            CuentaCorrienteApp ccMovimiento = new CuentaCorrienteApp();
            return ccMovimiento.AgregarMovimientoCaja(idCuentaCliente, entrada, concepto, montoDebe, montoPagar);
        }

        private void AgregarFormaPago(int idCajaDetalle, int idFormaPago, float MontoaPagar, int entradasalida)
        {
            CuentaCorrienteApp ccMovimiento = new CuentaCorrienteApp();
            ccMovimiento.AgregarFormaPago(idCajaDetalle, idFormaPago, MontoaPagar, entradasalida);
        }
}
}