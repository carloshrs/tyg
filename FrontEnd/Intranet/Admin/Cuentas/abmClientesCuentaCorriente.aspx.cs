using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;
using ar.com.TiempoyGestion.BackEnd.Clientes.Dal;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.Admin.TipoInforme
{
	/// <summary>
	/// Summary description for abmPreciosTipoInforme.
	/// </summary>
	public partial class abmPreciosTipoInforme : Page
	{
		private int intIdTipoInforme;

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				ActualizarGrilla();
			}

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

		}

		#endregion



		protected void btnAceptar_Click(object sender, EventArgs e)
		{
			if (hIdCliente.Value != "")
			{
				try
				{
					int idCliente = int.Parse(hIdCliente.Value);
                    if (intIdTipoInforme != 1 && intIdTipoInforme != 13)
						GestorPrecios.AgregarClienteCuentaCorriente(idCliente);
				}
				catch
				{
				}

			}
			ActualizarGrilla();
			btnCancelar_Click(null, null);

		}


		protected void btnCancelar_Click(object sender, EventArgs e)
		{
		}

		private void ActualizarGrilla()
		{
			dgridClientes.DataSource = GestorPrecios.TraerCuentasClientes();
			dgridClientes.DataBind();
		}

		protected void btnCerrar_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("/Admin/Cuentas/abmClientesCuentaCorriente.aspx");

		}

        protected void dgridClientes_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.Item.Cells[0].Text != "")
            {
                switch (((ImageButton)e.CommandSource).CommandName)
                {
                    case "Eliminar":
                        int IdCliente = int.Parse(e.Item.Cells[0].Text);
                        BorrarCliente(IdCliente);
                        Response.Redirect("abmClientesCuentaCorriente.aspx");
                        break;
                }
            }
        }

        private void BorrarCliente(int idCliente)
        {
            GestorPrecios.EliminarClienteCC(idCliente);
        }
}
}