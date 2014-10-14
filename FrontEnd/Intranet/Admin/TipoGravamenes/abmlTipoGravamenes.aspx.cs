using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.Extranet.TipoGravamenes
{
	/// <summary>
	/// Summary description for ListaTipoGravamenes.
	/// </summary>
	public partial class ListaTipoGravamenes : Page
	{
		protected HtmlInputHidden hidEstadoCivil;

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.QueryString["id"] != null) cargarTipoGravamenes(int.Parse(Request.QueryString["id"]));
				TipoGravamenesApp objTipoGravamenes = new TipoGravamenesApp();
				dgTipoGravamenes.DataSource = objTipoGravamenes.TraerDatos();
				dgTipoGravamenes.DataBind();
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
			this.dgTipoGravamenes.ItemCommand += new DataGridCommandEventHandler(this.dgTipoGravamenes_ItemCommand);
			this.dgTipoGravamenes.PreRender += new EventHandler(this.dgTipoGravamenes_PreRender);
			this.btnAceptar.Click += new EventHandler(this.btnAceptar_Click);
			this.btnCancelar.Click += new EventHandler(this.btnCancelar_Click);
			this.Load += new EventHandler(this.Page_Load);

		}

		#endregion

		private void dgTipoGravamenes_PreRender(object sender, EventArgs e)
		{
			foreach (DataGridItem myItem in dgTipoGravamenes.Items)
			{
				((ImageButton) myItem.FindControl("Editar")).Attributes.Add("src", @"/img/modificar_general.gif");
				((ImageButton) myItem.FindControl("Editar")).ToolTip = "Modificar estado civil";
				((ImageButton) myItem.FindControl("Cancelar")).Attributes.Add("onclick", @"javascript: return confirm('¿Está seguro que desea eliminar el tipo de gravamen?');");
			}
		}

		private void dgTipoGravamenes_ItemCommand(object source, DataGridCommandEventArgs e)
		{
			if (e.Item.Cells[0].Text != "")
			{
				switch (((ImageButton) e.CommandSource).CommandName)
				{
					case "Cancelar":
						int IdCodigo = int.Parse(e.Item.Cells[0].Text);
						TipoGravamenesApp objTipoGravamenes = new TipoGravamenesApp();
						objTipoGravamenes.Eliminar(IdCodigo);
						Response.Redirect("abmlTipoGravamenes.aspx");
						break;

					case "Editar":
						Response.Redirect("abmlTipoGravamenes.aspx?id=" + e.Item.Cells[0].Text);
						break;
				}
			}
		}

		private void btnAceptar_Click(object sender, EventArgs e)
		{
			if (TxtTipoGravamen.Text != "")
			{
				if (hidTipoGravamen.Value != "")
				{
					TipoGravamenesApp objTipoGravamenes = new TipoGravamenesApp();
					objTipoGravamenes.Modificar(int.Parse(hidTipoGravamen.Value), TxtTipoGravamen.Text);
				}
				else
				{
					TipoGravamenesApp objTipoGravamenes = new TipoGravamenesApp();
					objTipoGravamenes.Crear(TxtTipoGravamen.Text);
				}
			}
			Response.Redirect("abmlTipoGravamenes.aspx");
		}

		private void cargarTipoGravamenes(int id)
		{
			TipoGravamenesDal objTipoGravamenes = new TipoGravamenesDal();
			objTipoGravamenes.Cargar(id);
			TxtTipoGravamen.Text = objTipoGravamenes.Descripcion;
			lblEstado.Text = "Edición de tipo de gravamen";
			hidTipoGravamen.Value = objTipoGravamenes.Id.ToString();
		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			Response.Redirect("abmlTipoGravamenes.aspx");
		}
	}
}