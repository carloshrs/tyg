using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.Extranet.TipoDocumento
{
	/// <summary>
	/// Summary description for ListaTipoDocumento.
	/// </summary>
	public partial class ListaTipoDocumento : Page
	{
		protected HtmlInputHidden hidEstadoCivil;

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.QueryString["id"] != null) cargarTipoDocumento(int.Parse(Request.QueryString["id"]));
				TipoDocumentoApp objTipoDocumento = new TipoDocumentoApp();
				dgTipoDocumento.DataSource = objTipoDocumento.TraerDatos();
				dgTipoDocumento.DataBind();
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
			this.dgTipoDocumento.ItemCommand += new DataGridCommandEventHandler(this.dgTipoDocumento_ItemCommand);
			this.dgTipoDocumento.PreRender += new EventHandler(this.dgTipoDocumento_PreRender);
			this.btnAceptar.Click += new EventHandler(this.btnAceptar_Click);
			this.btnCancelar.Click += new EventHandler(this.btnCancelar_Click);
			this.Load += new EventHandler(this.Page_Load);

		}

		#endregion

		private void dgTipoDocumento_PreRender(object sender, EventArgs e)
		{
			foreach (DataGridItem myItem in dgTipoDocumento.Items)
			{
				((ImageButton) myItem.FindControl("Editar")).Attributes.Add("src", @"/img/modificar_general.gif");
				((ImageButton) myItem.FindControl("Editar")).ToolTip = "Modificar estado civil";
				((ImageButton) myItem.FindControl("Cancelar")).Attributes.Add("onclick", @"javascript: return confirm('¿Está seguro que desea eliminar el tipo de documento?');");
			}
		}

		private void dgTipoDocumento_ItemCommand(object source, DataGridCommandEventArgs e)
		{
			if (e.Item.Cells[0].Text != "")
			{
				switch (((ImageButton) e.CommandSource).CommandName)
				{
					case "Cancelar":
						int IdCodigo = int.Parse(e.Item.Cells[0].Text);
						TipoDocumentoApp objTipoDocumento = new TipoDocumentoApp();
						objTipoDocumento.Eliminar(IdCodigo);
						Response.Redirect("abmlTipoDocumento.aspx");
						break;

					case "Editar":
						Response.Redirect("abmlTipoDocumento.aspx?id=" + e.Item.Cells[0].Text);
						break;
				}
			}
		}

		private void btnAceptar_Click(object sender, EventArgs e)
		{
			if (TxtTipoDocumento.Text != "")
			{
				if (hidTipoDocumento.Value != "")
				{
					TipoDocumentoApp objTipoDocumento = new TipoDocumentoApp();
					objTipoDocumento.Modificar(int.Parse(hidTipoDocumento.Value), TxtTipoDocumento.Text);
				}
				else
				{
					TipoDocumentoApp objTipoDocumento = new TipoDocumentoApp();
					objTipoDocumento.Crear(TxtTipoDocumento.Text);
				}
			}
			Response.Redirect("abmlTipoDocumento.aspx");
		}

		private void cargarTipoDocumento(int id)
		{
			TipoDocumentoDal objTipoDocumento = new TipoDocumentoDal();
			objTipoDocumento.Cargar(id);
			TxtTipoDocumento.Text = objTipoDocumento.Descripcion;
			lblEstado.Text = "Edición de tipo de documento";
			hidTipoDocumento.Value = objTipoDocumento.Id.ToString();
		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			Response.Redirect("abmlTipoDocumento.aspx");
		}
	}
}