using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.Clientes.Dal;
using System.Data;

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
                hdIdCaja.Value = idCuentaCliente;

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

            //GestorPrecios CajaEncabezado = new GestorPrecios();

            GestorPrecios.CrearCajaDetalle(int.Parse(hdIdCaja.Value), int.Parse(cmbTipoIngreso.SelectedValue), cmbConcepto.SelectedItem.ToString(), float.Parse(txtMonto.Text), txtObservaciones.Text);
            Response.Redirect("ListaCuentaCorrienteCliente.aspx?id=" + hdIdCaja.Value);
        }
}
}
