using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.Extranet.EstadoCivil
{
	/// <summary>
	/// Summary description for ListaEstadoCivil.
	/// </summary>
	public partial class ListaEstadoCivil : Page
	{

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.QueryString["id"] != null) cargarEstadoCivil(int.Parse(Request.QueryString["id"]));
				EstadoCivilApp objEstadoCivil = new EstadoCivilApp();
				dgEstadoCivil.DataSource = objEstadoCivil.TraerDatos();
				dgEstadoCivil.DataBind();
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
			this.dgEstadoCivil.ItemCommand += new DataGridCommandEventHandler(this.dgEstadoCivil_ItemCommand);
			this.dgEstadoCivil.PreRender += new EventHandler(this.dgEstadoCivil_PreRender);
			this.btnAceptar.Click += new EventHandler(this.btnAceptar_Click);
			this.btnCancelar.Click += new EventHandler(this.btnCancelar_Click);
			this.Load += new EventHandler(this.Page_Load);

		}

		#endregion

		private void dgEstadoCivil_PreRender(object sender, EventArgs e)
		{
			foreach (DataGridItem myItem in dgEstadoCivil.Items)
			{
				((ImageButton) myItem.FindControl("Editar")).Attributes.Add("src", @"/img/modificar_general.gif");
				((ImageButton) myItem.FindControl("Editar")).ToolTip = "Modificar estado civil";
				((ImageButton) myItem.FindControl("Cancelar")).Attributes.Add("onclick", @"javascript: return confirm('¿Está seguro que desea eliminar el estado civil?');");
			}
		}

		private void dgEstadoCivil_ItemCommand(object source, DataGridCommandEventArgs e)
		{
			if (e.Item.Cells[0].Text != "")
			{
				switch (((ImageButton) e.CommandSource).CommandName)
				{
					case "Cancelar":
						int IdCodigo = int.Parse(e.Item.Cells[0].Text);
						EstadoCivilApp objEstadoCivil = new EstadoCivilApp();
						objEstadoCivil.Eliminar(IdCodigo);
						Response.Redirect("abmlEstadoCivil.aspx");
						break;

					case "Editar":
						Response.Redirect("abmlEstadoCivil.aspx?id=" + e.Item.Cells[0].Text);
						break;
				}
			}
		}

		private void btnAceptar_Click(object sender, EventArgs e)
		{
			if (TxtEstadoCivil.Text != "")
			{
				if (hidEstadoCivil.Value != "")
				{
					EstadoCivilApp objEstadoCivil = new EstadoCivilApp();
					objEstadoCivil.Modificar(int.Parse(hidEstadoCivil.Value), TxtEstadoCivil.Text);
				}
				else
				{
					EstadoCivilApp objEstadoCivil = new EstadoCivilApp();
					objEstadoCivil.Crear(TxtEstadoCivil.Text);
				}
			}
			Response.Redirect("abmlEstadoCivil.aspx");
		}

		private void cargarEstadoCivil(int id)
		{
			EstadoCivilDal objEstadoCivil = new EstadoCivilDal();
			objEstadoCivil.Cargar(id);
			TxtEstadoCivil.Text = objEstadoCivil.Descripcion;
			lblEstado.Text = "Edición de estado civil";
			hidEstadoCivil.Value = objEstadoCivil.Id.ToString();
		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			Response.Redirect("abmlEstadoCivil.aspx");
		}
	}
}