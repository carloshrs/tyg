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
				try
				{
					TipoInformeDal tipoInforme = new TipoInformeDal();
					intIdTipoInforme = int.Parse(Request.QueryString["IdTipo"]);
					tipoInforme.Cargar(intIdTipoInforme);
					lblTipoInforme.Text = tipoInforme.Descripcion;
					ViewState["IdTipoInforme"] = intIdTipoInforme.ToString();
					ListaCaracteres();
                    if (intIdTipoInforme != 1 && intIdTipoInforme != 3 && intIdTipoInforme != 13 && intIdTipoInforme != 16)
						ddlTipoPrecio.Visible = false;
				}
				catch
				{
					Response.Redirect("/Admin/TipoInforme/abmlTipoInforme.aspx");
				}
				ActualizarGrilla();
			}
			else
				intIdTipoInforme = int.Parse(ViewState["IdTipoInforme"].ToString());

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
			this.dgTipoInforme.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgTipoInforme_ItemCommand);

		}

		#endregion

		protected void dgTipoInforme_PreRender(object sender, EventArgs e)
		{
			string [] strTiposPrecio = {"Normal", "Urgente", "Super Urgente"};
			
			foreach (DataGridItem myItem in dgTipoInforme.Items)
			{
				((ImageButton) myItem.FindControl("Editar")).ToolTip = "Modificar Precio";
                if (intIdTipoInforme != 1 && intIdTipoInforme != 3 && intIdTipoInforme != 13 && intIdTipoInforme != 16)
					((Label) myItem.FindControl("lblTipoPrecio")).Text = "No Aplica";
				else
					((Label) myItem.FindControl("lblTipoPrecio")).Text = strTiposPrecio[int.Parse(myItem.Cells[1].Text) - 1];

				if (myItem.Cells[4].Text == "1")
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

		private void dgTipoInforme_ItemCommand(object source, DataGridCommandEventArgs e)
		{
			txtPrecio.Text = e.Item.Cells[3].Text;
			hidFecha.Value = e.Item.Cells[0].Text;
            if (intIdTipoInforme == 1 || intIdTipoInforme == 3 || intIdTipoInforme == 13 || intIdTipoInforme == 16)
				ddlTipoPrecio.SelectedValue = e.Item.Cells[1].Text;
			btnAceptar.Text = "Guardar";
		}

		protected void btnAceptar_Click(object sender, EventArgs e)
		{
			if (txtPrecio.Text != "")
			{
				if (hidFecha.Value != "")
				{
					try
					{
						float flPrecio = float.Parse(txtPrecio.Text, NumberStyles.Currency);
						DateTime dtFecha = DateTime.ParseExact(hidFecha.Value, "dd-MMM-yyyy HH:mm:ss", null);
                        if (intIdTipoInforme != 1 && intIdTipoInforme != 3 && intIdTipoInforme != 13 && intIdTipoInforme != 16)
							GestorPrecios.ModificarPrecio(dtFecha, 1, intIdTipoInforme, flPrecio);
						else
							GestorPrecios.ModificarPrecio(dtFecha, byte.Parse(ddlTipoPrecio.SelectedValue), intIdTipoInforme, flPrecio);
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
                        if (intIdTipoInforme != 1 && intIdTipoInforme != 3 && intIdTipoInforme != 13 && intIdTipoInforme != 16)
							GestorPrecios.AgregarPrecio(flPrecio, intIdTipoInforme, 1);
						else
							GestorPrecios.AgregarPrecio(flPrecio, intIdTipoInforme, byte.Parse(ddlTipoPrecio.SelectedValue));
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
			hidFecha.Value = "";
            if (intIdTipoInforme == 1 || intIdTipoInforme == 3 || intIdTipoInforme == 13 || intIdTipoInforme == 16)
				ddlTipoPrecio.SelectedValue = "1";
			btnAceptar.Text = "Agregar";
		}

		private void ActualizarGrilla()
		{
			dgTipoInforme.DataSource = GestorPrecios.TraerPrecios(intIdTipoInforme);
			dgTipoInforme.DataBind();
		}

		protected void btnCerrar_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("/Admin/TipoInforme/abmlTipoInforme.aspx");

		}

		private void ListaCaracteres()
		{
			UtilesApp Tipos = new UtilesApp();
			ddlTipoPrecio.Items.Clear();
			DataTable myTb;
			myTb = Tipos.TraerCaracter();
			ListItem myItem;
			foreach (DataRow myRow in myTb.Rows)
			{
				myItem = new ListItem(myRow[1].ToString(), myRow[0].ToString());
				ddlTipoPrecio.Items.Add(myItem);
			}
		}
	}
}