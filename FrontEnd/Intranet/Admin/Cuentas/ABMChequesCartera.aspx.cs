using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.Clientes.Dal;
using System.Data;
using ar.com.TiempoyGestion.BackEnd.Cobranzas.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.Admin.Cuentas
{
	/// <summary>
	/// Summary description for ListaFunciones.
	/// </summary>
    public partial class ABMChequesCartera : Page
	{
	
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
                string idChequeCartera = "";
                idChequeCartera = Request.QueryString["id"];
                hdIdChequeCartera.Value = idChequeCartera;

                ListaEstados();
                    
                pnlEncabezado.Visible = true;
                CargarEncabezadoChequeCartera(idChequeCartera);
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


        private void CargarEncabezadoChequeCartera(string idChequeCartera)
        {
            GestorPrecios ChequeCarteraEncabezado = new GestorPrecios();
            ChequeCarteraEncabezado.CargarChequeCartera(int.Parse(idChequeCartera));
            lblFechaCobro.Text = DateTime.Parse(ChequeCarteraEncabezado.CHFechaCobro).ToShortDateString();
            lblFechaEmision.Text = DateTime.Parse(ChequeCarteraEncabezado.CHFechaEmision).ToShortDateString();
            lblNroCheque.Text = ChequeCarteraEncabezado.CHNumero;
            lblMontoCheque.Text = ChequeCarteraEncabezado.CHMonto.ToString();
            hdMonto.Value = ChequeCarteraEncabezado.CHMonto.ToString();
            lblBanco.Text = ChequeCarteraEncabezado.CHBanco;
        }


        private void ListaEstados()
        {
            cmbEstado.Items.Clear();
            DataTable myTb;
            myTb = GestorPrecios.ListarEstadosCheques("");
            ListItem myItem;
            foreach (DataRow myRow in myTb.Rows)
            {
                myItem = new ListItem(myRow[1].ToString(), myRow[0].ToString());
                cmbEstado.Items.Add(myItem);
            }
        }

        
        protected void btnAgregar_Click(object sender, EventArgs e)
        {

            //GestorPrecios CajaEncabezado = new GestorPrecios();

            GestorPrecios.CambiarEstadoCheque(int.Parse(hdIdChequeCartera.Value), float.Parse(lblMontoCheque.Text), int.Parse(cmbEstado.SelectedValue));
            Response.Redirect("ListaChequesCartera.aspx");
        }
    }
}
