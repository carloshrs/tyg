using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.Admin.Seguridad.Admin.Seguridad
{
	/// <summary>
	/// Summary description for ListaRoles.
	/// </summary>
	public partial class ListaRoles : Page
	{
	
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				CargarRoles();

			}
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
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
			this.dgRoles.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgRoles_ItemCommand);

		}
		#endregion

		protected void btnNuevoRol_Click(object sender, EventArgs e)
		{
			Response.Redirect("AbmRol.aspx");

		}

		private void CargarRoles()
		{
			Rol rol = new Rol();
			dgRoles.DataSource = rol.Listar("");
			dgRoles.DataBind();

		}

		private void BorrarRol(int lId)
		{	
			Rol rol = new Rol();
			rol.Eliminar(lId);

		}

		private void dgRoles_ItemCommand(object source, DataGridCommandEventArgs e)
		{
			if (e.Item.Cells[0].Text != "")
			{
				switch(((ImageButton)e.CommandSource).CommandName)
				{
					case "Borrar":
						int IdRol = int.Parse(e.Item.Cells[0].Text);
						BorrarRol(IdRol);
						Response.Redirect("ListaRoles.aspx");
						break;

					case "Editar":
						Response.Redirect("AbmRol.aspx?IdRol="+ e.Item.Cells[0].Text);
						break;

					case "Funciones":
						Response.Redirect("FuncionAddRol.aspx?IdRol=" + e.Item.Cells[0].Text + "&From=List");
						break;

				}
			}
		}

		protected void dgRoles_PreRender(object sender, System.EventArgs e)
		{
			foreach (DataGridItem myItem in dgRoles.Items)
			{
				
				if (myItem.Cells[8].Text != "0")
					((Label) myItem.FindControl("lblAutomatico")).Visible = true;
				if (myItem.Cells[9].Text != "0")
					((Label) myItem.FindControl("lblExtranet")).Visible = true;

			}
		}
	}
}
