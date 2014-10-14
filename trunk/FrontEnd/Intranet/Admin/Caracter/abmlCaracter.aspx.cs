using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.Admin.Caracter
{
	/// <summary>
	/// Summary description for ListaCaracter.
	/// </summary>
	public partial class ListaCaracter : Page
	{
		protected HtmlInputHidden hidEstadoCivil;
		protected HtmlInputHidden hidTipoCatastral;

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.QueryString["id"] != null) cargarCaracter(int.Parse(Request.QueryString["id"]));
				CaracterApp objCaracter = new CaracterApp();
				dgCaracter.DataSource = objCaracter.TraerDatos();
				dgCaracter.DataBind();
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
			this.dgCaracter.ItemCommand += new DataGridCommandEventHandler(this.dgCaracter_ItemCommand);
			this.dgCaracter.PreRender += new EventHandler(this.dgCaracter_PreRender);
			this.btnAceptar.Click += new EventHandler(this.btnAceptar_Click);
			this.btnCancelar.Click += new EventHandler(this.btnCancelar_Click);
			this.Load += new EventHandler(this.Page_Load);

		}

		#endregion

		private void dgCaracter_PreRender(object sender, EventArgs e)
		{
			foreach (DataGridItem myItem in dgCaracter.Items)
			{
				((ImageButton) myItem.FindControl("Editar")).Attributes.Add("src", @"/img/modificar_general.gif");
				((ImageButton) myItem.FindControl("Editar")).ToolTip = "Modificar estado civil";
				((ImageButton) myItem.FindControl("Cancelar")).Attributes.Add("onclick", @"javascript: return confirm('¿Está seguro que desea eliminar el caracter?');");
			}
		}

		private void dgCaracter_ItemCommand(object source, DataGridCommandEventArgs e)
		{
			if (e.Item.Cells[0].Text != "")
			{
				switch (((ImageButton) e.CommandSource).CommandName)
				{
					case "Cancelar":
						int IdCodigo = int.Parse(e.Item.Cells[0].Text);
						CaracterApp objCaracter = new CaracterApp();
						objCaracter.Eliminar(IdCodigo);
						Response.Redirect("abmlCaracter.aspx");
						break;

					case "Editar":
						Response.Redirect("abmlCaracter.aspx?id=" + e.Item.Cells[0].Text);
						break;
				}
			}
		}

		private void btnAceptar_Click(object sender, EventArgs e)
		{
			if (TxtCaracter.Text != "")
			{
				if (hidCaracter.Value != "")
				{
					CaracterApp objCaracter = new CaracterApp();
					objCaracter.Modificar(int.Parse(hidCaracter.Value), TxtCaracter.Text);
				}
				else
				{
					CaracterApp objCaracter = new CaracterApp();
					objCaracter.Crear(TxtCaracter.Text);
				}
			}
			Response.Redirect("abmlCaracter.aspx");
		}

		private void cargarCaracter(int id)
		{
			CaracterDal objCaracter = new CaracterDal();
			objCaracter.Cargar(id);
			TxtCaracter.Text = objCaracter.Descripcion;
			lblEstado.Text = "Edición de caracter";
			hidCaracter.Value = objCaracter.Id.ToString();
		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			Response.Redirect("abmlCaracter.aspx");
		}
	}
}