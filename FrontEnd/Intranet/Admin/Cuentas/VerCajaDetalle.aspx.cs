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
    public partial class ListaCajaDetalles : Page
	{
	
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
                string idCajaDetalle = "";
                idCajaDetalle = Request.QueryString["idCajaDetalle"];
                hdIdCajaDetalle.Value = idCajaDetalle;
                 
                pnlEncabezado.Visible = true;
                CargarEncabezadoCaja(idCajaDetalle);
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
			Response.Redirect("AbmCaja.aspx");
		}





        private void CargarEncabezadoCaja(string idCajaDetalle)
        {

            GestorPrecios CajaEncabezadoDetalle = new GestorPrecios();
            CajaEncabezadoDetalle.CargarCajaDetalle(int.Parse(Request.QueryString["idCajaDetalle"]));
            lblConcepto.Text = CajaEncabezadoDetalle.Concepto;
            lblMonto.Text = CajaEncabezadoDetalle.MontoTotal.ToString();
            if (CajaEncabezadoDetalle.Entradasalida == 0)
                lblTipo.Text = "Egreso";
            else
                lblTipo.Text = "Ingreso";
            lblFecha.Text = CajaEncabezadoDetalle.Fecha;
            lblObservaciones.Text = CajaEncabezadoDetalle.Observaciones;


            GestorPrecios CajaEncabezado = new GestorPrecios();
            CajaEncabezado.CargarCaja(CajaEncabezadoDetalle.IdCaja);
            lblFechaApertura.Text = CajaEncabezado.Apertura;
            lblFechaCierre.Text = CajaEncabezado.Cierre;
            lblEfectivoInicial.Text = CajaEncabezado.EfectivoInicial.ToString();
            lblChequeInicial.Text = CajaEncabezado.ChequeInicial.ToString();
            lblSaldoEfectivo.Text = CajaEncabezado.SaldoEfectivo.ToString();
            lblSaldoCheque.Text = CajaEncabezado.SaldoCheque.ToString();

            
        }

        
    }
}
