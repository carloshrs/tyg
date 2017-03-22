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
    public partial class ListaAdicionales : Page
	{
	
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				CargarAdicionales();

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
			this.dgAdicionales.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgAdicionales_ItemCommand);

		}
		#endregion

        protected void btnNuevoAdicional_Click(object sender, EventArgs e)
		{
			Response.Redirect("AbmAdicionales.aspx");
		}

        private void CargarAdicionales()
		{
			//GestorPrecios Adicionales = new GestorPrecios();
            dgAdicionales.DataSource = GestorPrecios.ListarAdicionales("").DefaultView;
			dgAdicionales.DataBind();

		}

		private void BorrarAdicional(int lId)
		{
            GestorPrecios.EliminarAdicional(lId);
		}

        private void dgAdicionales_ItemCommand(object source, DataGridCommandEventArgs e)
		{
			if (e.Item.Cells[0].Text != "")
			{
				switch(((ImageButton)e.CommandSource).CommandName)
				{
					case "Borrar":
						int IdFuncion = int.Parse(e.Item.Cells[0].Text);
						BorrarAdicional(IdFuncion);
						Response.Redirect("ListaAdicionales.aspx");
						break;

					case "Editar":
						Response.Redirect("AbmAdicionales.aspx?id="+ e.Item.Cells[0].Text);
						break;

				}
			}
		}
	}
}
