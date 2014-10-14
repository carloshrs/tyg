using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.Extranet.TipoObjetos
{
	/// <summary>
	/// Summary description for ListaTipoObjetos.
	/// </summary>
	public partial class ListaTipoObjetos : Page
	{
		protected HtmlInputHidden hidEstadoCivil;

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.QueryString["id"] != null) cargarTipoObjetos(int.Parse(Request.QueryString["id"]));
				TipoObjetosApp objTipoObjetos = new TipoObjetosApp();
				dgTipoObjetos.DataSource = objTipoObjetos.TraerDatos();
				dgTipoObjetos.DataBind();
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
			this.dgTipoObjetos.ItemCommand += new DataGridCommandEventHandler(this.dgTipoObjetos_ItemCommand);
			this.dgTipoObjetos.PreRender += new EventHandler(this.dgTipoObjetos_PreRender);
			this.btnAceptar.Click += new EventHandler(this.btnAceptar_Click);
			this.btnCancelar.Click += new EventHandler(this.btnCancelar_Click);
			this.Load += new EventHandler(this.Page_Load);

		}

		#endregion

		private void dgTipoObjetos_PreRender(object sender, EventArgs e)
		{
			foreach (DataGridItem myItem in dgTipoObjetos.Items)
			{
				((ImageButton) myItem.FindControl("Editar")).Attributes.Add("src", @"/img/modificar_general.gif");
				((ImageButton) myItem.FindControl("Editar")).ToolTip = "Modificar estado civil";
				((ImageButton) myItem.FindControl("Cancelar")).Attributes.Add("onclick", @"javascript: return confirm('¿Está seguro que desea eliminar el tipo de objeto?');");
			}
		}

		private void dgTipoObjetos_ItemCommand(object source, DataGridCommandEventArgs e)
		{
			if (e.Item.Cells[0].Text != "")
			{
				switch (((ImageButton) e.CommandSource).CommandName)
				{
					case "Cancelar":
						int IdCodigo = int.Parse(e.Item.Cells[0].Text);
						TipoObjetosApp objTipoObjetos = new TipoObjetosApp();
						objTipoObjetos.Eliminar(IdCodigo);
						Response.Redirect("abmlTipoObjetos.aspx");
						break;

					case "Editar":
						Response.Redirect("abmlTipoObjetos.aspx?id=" + e.Item.Cells[0].Text);
						break;
				}
			}
		}

		private void btnAceptar_Click(object sender, EventArgs e)
		{
			if (TxtTipoObjetos.Text != "")
			{
				if (hidTipoObjetos.Value != "")
				{
					TipoObjetosApp objTipoObjetos = new TipoObjetosApp();
					objTipoObjetos.Modificar(int.Parse(hidTipoObjetos.Value), TxtTipoObjetos.Text);
				}
				else
				{
					TipoObjetosApp objTipoObjetos = new TipoObjetosApp();
					objTipoObjetos.Crear(TxtTipoObjetos.Text);
				}
			}
			Response.Redirect("abmlTipoObjetos.aspx");
		}

		private void cargarTipoObjetos(int id)
		{
			TipoObjetosDal objTipoObjetos = new TipoObjetosDal();
			objTipoObjetos.Cargar(id);
			TxtTipoObjetos.Text = objTipoObjetos.Descripcion;
			lblEstado.Text = "Edición de tipo de objeto";
			hidTipoObjetos.Value = objTipoObjetos.Id.ToString();
		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			Response.Redirect("abmlTipoObjetos.aspx");
		}
	}
}