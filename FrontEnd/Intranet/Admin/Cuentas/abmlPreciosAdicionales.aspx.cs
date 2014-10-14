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

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.Admin.Cuentas
{
	/// <summary>
	/// Summary description for abmPreciosTipoInforme.
	/// </summary>
	public partial class abmlPreciosAdicionales : Page
	{
        private int intServicioAdicional;

		protected void Page_Load(object sender, EventArgs e)
		{

            
			if (!Page.IsPostBack)
			{
                ListaAdicionales();
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
			this.dgInformesAdicionales.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgInformesAdicionales_ItemCommand);

		}

		#endregion

        protected void dgInformesAdicionales_PreRender(object sender, EventArgs e)
		{
			//string [] strTiposPrecio = {"Normal", "Urgente", "Super Urgente"};

            foreach (DataGridItem myItem in dgInformesAdicionales.Items)
			{
				((ImageButton) myItem.FindControl("Editar")).ToolTip = "Modificar Precio";

				if (myItem.Cells[5].Text == "1")
				{
					myItem.ForeColor = Color.Green;
					((ImageButton) myItem.FindControl("Editar")).ToolTip = "Modificar Precio";
				}
				else
				{
					myItem.ForeColor = Color.Red;
					((ImageButton) myItem.FindControl("Editar")).Visible = false;
				}

			}
		}

        private void dgInformesAdicionales_ItemCommand(object source, DataGridCommandEventArgs e)
		{
            txtPrecio.Text = e.Item.Cells[4].Text;
            hidPrecioAdicional.Value = e.Item.Cells[1].Text;
            ddAdicional.SelectedValue = e.Item.Cells[2].Text;
            btnAceptar.Text = "Guardar";
		}

		protected void btnAceptar_Click(object sender, EventArgs e)
		{
			if (txtPrecio.Text != "")
			{
                if (hidPrecioAdicional.Value != "")
				{
					try
					{
						float flPrecio = float.Parse(txtPrecio.Text, NumberStyles.Currency);
						//DateTime dtFecha = DateTime.ParseExact(hidFecha.Value, "dd-MMM-yyyy HH:mm:ss", null);
                        int idPrecioAdicional = int.Parse(hidPrecioAdicional.Value);
                        intServicioAdicional = int.Parse(ddAdicional.SelectedValue);
                        GestorPrecios.ModificarPrecioAdicional(idPrecioAdicional, intServicioAdicional, flPrecio);
					}
					catch
					{ 
						txtPrecio.Text = "";
						valPrecio.IsValid = false;
					}
				}
				else
				{
					try
					{
						float flPrecio = float.Parse(txtPrecio.Text);
						GestorPrecios.AgregarPrecioAdicional(flPrecio, int.Parse(ddAdicional.SelectedValue));
					}
					catch
					{
						txtPrecio.Text = "";
						valPrecio.IsValid = false;
					}
				}
			}
			ActualizarGrilla();
			btnCancelar_Click(null, null);

		}


		protected void btnCancelar_Click(object sender, EventArgs e)
		{
			txtPrecio.Text = "";
			hidPrecioAdicional.Value = "";
			btnAceptar.Text = "Agregar";
		}

		private void ActualizarGrilla()
		{
            dgInformesAdicionales.DataSource = GestorPrecios.TraerPreciosAdicionales();
            dgInformesAdicionales.DataBind();
		}

		protected void btnCerrar_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("/Admin/Cuentas/abmlPreciosAdicionales.aspx");

		}

		private void ListaAdicionales()
		{
			ddAdicional.Items.Clear();
			DataTable myTb;
            myTb = GestorPrecios.ListarAdicionales("");
			ListItem myItem;
			foreach (DataRow myRow in myTb.Rows)
			{
				myItem = new ListItem(myRow[1].ToString(), myRow[0].ToString());
                ddAdicional.Items.Add(myItem);
			}
		}


	}
}