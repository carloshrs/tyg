using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.App;
using ar.com.TiempoyGestion.BackEnd.Clientes.Dal;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;
using ar.com.TiempoyGestion.BackEnd.Clientes.App;


namespace ar.com.TiempoyGestion.FrontEnd.Intranet.Admin.Cuentas
{
	/// <summary>
	/// Summary description for _Default.
	/// </summary>
	public partial class CuentaCorrienteCliente : Page
	{
        protected bool bsqRapida = false;
		protected void Page_Load(object sender, EventArgs e)
		{
           
            if (txtFechaInicio.Text == "")
                txtFechaInicio.Text = DateTime.Today.AddMonths(-3).ToShortDateString();

            if (txtFechaFinal.Text == "")
                txtFechaFinal.Text = DateTime.Today.ToShortDateString();

            hIdCliente.Value = Request.QueryString["idCliente"];
            if (!Page.IsPostBack)
            {
                ClienteDal vCliente = new ClienteDal();
                vCliente.Cargar(int.Parse(hIdCliente.Value));
                string cliente = "";
                if (vCliente.NombreFantasia != null && vCliente.NombreFantasia != "")
                    cliente = vCliente.NombreFantasia;
                else
                    cliente = vCliente.RazonSocial;
                if (vCliente.Sucursal != null && vCliente.Sucursal != "")
                    cliente = cliente + " (" + vCliente.Sucursal + ")";

                lblCliente.Text = cliente;

                CuentaCorrienteApp vCCCliente = new CuentaCorrienteApp();
                int idCuentaCliente = vCCCliente.ObtenerNroClienteCC(int.Parse(hIdCliente.Value));
                if (vCCCliente.ObtenerSaldoClienteCC(idCuentaCliente) != -1)
                    lblSaldo.Text = "$ " + vCCCliente.ObtenerSaldoClienteCC(idCuentaCliente).ToString();
                else
                    lblSaldo.Text = "$ 0,00";
                //txtFechaInicio.Text = DateTime.Today.AddMonths(-3).ToShortDateString();
                //txtFechaFinal.Text = DateTime.Today.ToShortDateString();
                ListaBandeja();
            }
			// Put user code to initialize the page here
			//Response.Redirect("/BandejaEntrada/Principal.aspx?idTipo=2");
			
            //BandejaEntradaApp bandeja = new BandejaEntradaApp();
			//litGrupos.Text = bandeja.InformesEstadisticosHOME().ToString();
		}

		#region Web Form Designer generated code

		protected override void OnInit(EventArgs e)
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
			this.Load += new EventHandler(this.Page_Load);

		}

		#endregion
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            //udpListaInformes.Visible = true;
            ListaBandeja();
        }

        protected void dgridCCCliente_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {

        }

        protected void dgridCCCliente_PreRender(object sender, EventArgs e)
        {
            
           

            foreach (DataGridItem myItem in dgridCCCliente.Items)
            {
                try
                {
                    ((Label)myItem.FindControl("lblFecha")).Text = DateTime.Parse(myItem.Cells[1].Text).ToShortDateString() + " " + DateTime.Parse(myItem.Cells[1].Text).ToShortTimeString();
                    if (int.Parse(myItem.Cells[5].Text) == 0)
                        ((Label)myItem.FindControl("lblDebe")).Text = "$ " + myItem.Cells[4].Text;
                    else
                        ((Label)myItem.FindControl("lblHaber")).Text = "$ " + myItem.Cells[4].Text;
                }
                catch (Exception exc)
                { }



                
             
                
            }
        }

        protected void dgridCCCliente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ListaBandeja()
        {
            
            bool bsqRapida = false;
            int paginaActual = 1;
            string fechaDesde ="";
            string fechaHasta = "";

            if (txtFechaInicio.Text != null)
                fechaDesde = txtFechaInicio.Text;
            else
                fechaDesde = DateTime.Today.AddMonths(-1).ToShortDateString();

            if (txtFechaInicio.Text != null)
                fechaHasta = txtFechaFinal.Text;
            else
                fechaHasta = DateTime.Today.ToShortDateString();

            int idCliente = -1;
                        
            if (hIdCliente.Value != "")
            {
                idCliente = int.Parse(hIdCliente.Value);
            }

            BandejaEntradaApp bandeja = new BandejaEntradaApp();
            bandeja.RegPorPagina = 10;
            bandeja.Pagina = paginaActual;
            if (!bsqRapida)
            {
                dgridCCCliente.DataSource = bandeja.ListaCuentaCorrienteCliente(idCliente, fechaDesde, fechaHasta, 0);
                dgridCCCliente.DataBind();

                //litPaginador.Text = bandeja.GetPaginador(10);
            }
            //else
            //litPaginador.Text = "<b><i>Ingrese criterio de búsqueda</i></b>";

            //PonerTitulo(IdTipo);
        }


    protected void  dgridCCCliente_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        			if (e.Item.Cells[0].Text != "")
			{
				switch (((ImageButton) e.CommandSource).CommandName)
				{
					
					case "Historico":
                        Response.Redirect("/BandejaEntrada/VerHistorial.aspx?id=" + e.Item.Cells[0].Text + "&IdTipo=" + e.Item.Cells[15].Text);
						break;
				}
			}
    }

		
        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            //udpListaInformes.Visible = true;
            ListaBandeja();
        }



        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Admin/Cuentas/ABMCuentaClienteDetalle.aspx?id=" + hIdCliente.Value);
        }
}
}