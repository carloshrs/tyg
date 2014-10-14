using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.Extranet.TipoPropiedad
{
	/// <summary>
	/// Summary description for ListaTipoPropiedad.
	/// </summary>
	public partial class ListaTipoPropiedad : Page
	{
		protected HtmlInputHidden hidEstadoCivil;

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.QueryString["id"] != null) cargarTipoPropiedad(int.Parse(Request.QueryString["id"]));
				TipoPropiedadApp objTipoPropiedad = new TipoPropiedadApp();
				dgTipoPropiedad.DataSource = objTipoPropiedad.TraerDatos();
				dgTipoPropiedad.DataBind();
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
			this.dgTipoPropiedad.ItemCommand += new DataGridCommandEventHandler(this.dgTipoPropiedad_ItemCommand);
			this.dgTipoPropiedad.PreRender += new EventHandler(this.dgTipoPropiedad_PreRender);
			this.btnAceptar.Click += new EventHandler(this.btnAceptar_Click);
			this.btnCancelar.Click += new EventHandler(this.btnCancelar_Click);
			this.Load += new EventHandler(this.Page_Load);

		}

		#endregion

		private void dgTipoPropiedad_PreRender(object sender, EventArgs e)
		{
			foreach (DataGridItem myItem in dgTipoPropiedad.Items)
			{
				((ImageButton) myItem.FindControl("Editar")).Attributes.Add("src", @"/img/modificar_general.gif");
				((ImageButton) myItem.FindControl("Editar")).ToolTip = "Modificar estado civil";
				((ImageButton) myItem.FindControl("Cancelar")).Attributes.Add("onclick", @"javascript: return confirm('¿Está seguro que desea eliminar el tipo de propiedad?');");
			}
		}

		private void dgTipoPropiedad_ItemCommand(object source, DataGridCommandEventArgs e)
		{
			if (e.Item.Cells[0].Text != "")
			{
				switch (((ImageButton) e.CommandSource).CommandName)
				{
					case "Cancelar":
						int IdCodigo = int.Parse(e.Item.Cells[0].Text);
						TipoPropiedadApp objTipoPropiedad = new TipoPropiedadApp();
						objTipoPropiedad.Eliminar(IdCodigo);
						Response.Redirect("abmlTipoPropiedad.aspx");
						break;

					case "Editar":
						Response.Redirect("abmlTipoPropiedad.aspx?id=" + e.Item.Cells[0].Text);
						break;
				}
			}
		}

		private void btnAceptar_Click(object sender, EventArgs e)
		{
			if (TxtTipoPropiedad.Text != "")
			{
				if (hidTipoPropiedad.Value != "")
				{
					TipoPropiedadApp objTipoPropiedad = new TipoPropiedadApp();
					objTipoPropiedad.Modificar(int.Parse(hidTipoPropiedad.Value), TxtTipoPropiedad.Text);
				}
				else
				{
					TipoPropiedadApp objTipoPropiedad = new TipoPropiedadApp();
					objTipoPropiedad.Crear(TxtTipoPropiedad.Text);
				}
			}
			Response.Redirect("abmlTipoPropiedad.aspx");
		}

		private void cargarTipoPropiedad(int id)
		{
			TipoPropiedadDal objTipoPropiedad = new TipoPropiedadDal();
			objTipoPropiedad.Cargar(id);
			TxtTipoPropiedad.Text = objTipoPropiedad.Descripcion;
			lblEstado.Text = "Edición de tipo de propiedad";
			hidTipoPropiedad.Value = objTipoPropiedad.Id.ToString();
		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			Response.Redirect("abmlTipoPropiedad.aspx");
		}
	}
}