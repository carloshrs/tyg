using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.Clientes.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.Admin.Seguridad.Admin.Cuentas
{
	/// <summary>
	/// Summary description for ListaFunciones.
	/// </summary>
    public partial class ListaCaja : Page
	{
	
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				CargarCajas();

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
            this.dgCajaDiaria.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgCajaDiaria_ItemCommand);

		}
		#endregion

        protected void btnNuevaApertura_Click(object sender, EventArgs e)
		{
			Response.Redirect("AbmCaja.aspx");
		}

        private void CargarCajas()
		{
			//GestorPrecios Adicionales = new GestorPrecios();
            dgCajaDiaria.DataSource = GestorPrecios.ListarCajas("").DefaultView;
			dgCajaDiaria.DataBind();

		}

		private void BorrarCaja(int lId)
		{
            GestorPrecios.EliminarCaja(lId);
		}

        private void dgCajaDiaria_ItemCommand(object source, DataGridCommandEventArgs e)
		{
			if (e.Item.Cells[0].Text != "")
			{
				switch(((ImageButton)e.CommandSource).CommandName)
				{
					case "Borrar":
						int IdFuncion = int.Parse(e.Item.Cells[0].Text);
                        BorrarCaja(IdFuncion);
						Response.Redirect("ListaCaja.aspx");
						break;

					case "Editar":
						Response.Redirect("AbmCaja.aspx?id="+ e.Item.Cells[0].Text);
						break;

                    case "Detalle":
                        Response.Redirect("ListaCajaDetalles.aspx?id=" + e.Item.Cells[0].Text);
                        break;

				}
			}
		}
        
}
}
