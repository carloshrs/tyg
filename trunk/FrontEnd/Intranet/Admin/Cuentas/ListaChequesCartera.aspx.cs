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
    public partial class ListaChequesCartera : Page
	{
	
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
                string idCaja = "";
                //idCaja = Request.QueryString["id"];
                //hdIdCaja.Value = idCaja;
                //pnlEncabezado.Visible = true;
				ListarCheques();

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
            this.dgChequesCartera.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgChequesCartera_ItemCommand);

		}
		#endregion



        private void ListarCheques()
		{
			//GestorPrecios Adicionales = new GestorPrecios();
            dgChequesCartera.DataSource = GestorPrecios.ListarChequesCartera().DefaultView;
			dgChequesCartera.DataBind();

		}

		private void BorrarCaja(int lId)
		{
            GestorPrecios.EliminarCaja(lId);
		}

        protected void dgChequesCartera_ItemCommand(object source, DataGridCommandEventArgs e)
		{
			if (e.Item.Cells[0].Text != "")
			{
				switch(((ImageButton)e.CommandSource).CommandName)
				{

                    case "Detalle":
                        Response.Redirect("ABMChequesCartera.aspx?id=" + e.Item.Cells[0].Text);
                        break;

				}
			}
		}




        protected void dgChequesCartera_PreRender(object sender, EventArgs e)
        {
            float vTotal = 0;
            foreach (DataGridItem myItem in dgChequesCartera.Items)
            {
                
                try
                {
                    ((Label)myItem.FindControl("lblFechaCobro")).Text = DateTime.Parse(myItem.Cells[1].Text).ToShortDateString();
                    vTotal = vTotal + float.Parse(myItem.Cells[5].Text);
                    
                }
                catch (Exception exc)
                { }

            }
            lblTotal.Text = "$ " + vTotal;
        }


    }
}
