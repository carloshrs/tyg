using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.Extranet.TipoCatastral
{
	/// <summary>
	/// Summary description for ListaTipoCatastral.
	/// </summary>
	public partial class ListaTipoCatastral : Page
	{
		protected HtmlInputHidden hidEstadoCivil;

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.QueryString["id"] != null) cargarTipoCatastral(int.Parse(Request.QueryString["id"]));
				TipoCatastralApp objTipoCatastral = new TipoCatastralApp();
				dgTipoCatastral.DataSource = objTipoCatastral.TraerDatos();
				dgTipoCatastral.DataBind();
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
			this.dgTipoCatastral.ItemCommand += new DataGridCommandEventHandler(this.dgTipoCatastral_ItemCommand);
			this.dgTipoCatastral.PreRender += new EventHandler(this.dgTipoCatastral_PreRender);
			this.btnAceptar.Click += new EventHandler(this.btnAceptar_Click);
			this.btnCancelar.Click += new EventHandler(this.btnCancelar_Click);
			this.Load += new EventHandler(this.Page_Load);

		}

		#endregion

		private void dgTipoCatastral_PreRender(object sender, EventArgs e)
		{
			foreach (DataGridItem myItem in dgTipoCatastral.Items)
			{
				((ImageButton) myItem.FindControl("Editar")).Attributes.Add("src", @"/img/modificar_general.gif");
				((ImageButton) myItem.FindControl("Editar")).ToolTip = "Modificar estado civil";
				((ImageButton) myItem.FindControl("Cancelar")).Attributes.Add("onclick", @"javascript: return confirm('¿Está seguro que desea eliminar el tipo catastral?');");
			}
		}

		private void dgTipoCatastral_ItemCommand(object source, DataGridCommandEventArgs e)
		{
			if (e.Item.Cells[0].Text != "")
			{
				switch (((ImageButton) e.CommandSource).CommandName)
				{
					case "Cancelar":
						int IdCodigo = int.Parse(e.Item.Cells[0].Text);
						TipoCatastralApp objTipoCatastral = new TipoCatastralApp();
						objTipoCatastral.Eliminar(IdCodigo);
						Response.Redirect("abmlTipoCatastral.aspx");
						break;

					case "Editar":
						Response.Redirect("abmlTipoCatastral.aspx?id=" + e.Item.Cells[0].Text);
						break;
				}
			}
		}

		private void btnAceptar_Click(object sender, EventArgs e)
		{
			if (TxtTipoCatastral.Text != "")
			{
				if (hidTipoCatastral.Value != "")
				{
					TipoCatastralApp objTipoCatastral = new TipoCatastralApp();
					objTipoCatastral.Modificar(int.Parse(hidTipoCatastral.Value), TxtTipoCatastral.Text);
				}
				else
				{
					TipoCatastralApp objTipoCatastral = new TipoCatastralApp();
					objTipoCatastral.Crear(TxtTipoCatastral.Text);
				}
			}
			Response.Redirect("abmlTipoCatastral.aspx");
		}

		private void cargarTipoCatastral(int id)
		{
			TipoCatastralDal objTipoCatastral = new TipoCatastralDal();
			objTipoCatastral.Cargar(id);
			TxtTipoCatastral.Text = objTipoCatastral.Descripcion;
			lblEstado.Text = "Edición de tipo catastral";
			hidTipoCatastral.Value = objTipoCatastral.Id.ToString();
		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			Response.Redirect("abmlTipoCatastral.aspx");
		}
	}
}