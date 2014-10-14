using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.Admin.Seguridad.Admin.Seguridad
{
	/// <summary>
	/// Summary description for ListaFunciones.
	/// </summary>
	public partial class ListaFunciones : Page
	{
	
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				CargarFunciones();

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
			this.dgFunciones.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgFunciones_ItemCommand);

		}
		#endregion

		protected void btnNuevaFuncion_Click(object sender, EventArgs e)
		{
			Response.Redirect("AbmFuncion.aspx");
		}

		private void CargarFunciones()
		{
			Funcion funcion = new Funcion();
			dgFunciones.DataSource = funcion.Listar("").DefaultView;
			dgFunciones.DataBind();

		}

		private void BorrarFuncion(int lId)
		{	
			Funcion funcion = new Funcion();
			funcion.Eliminar(lId);

		}

		private void dgFunciones_ItemCommand(object source, DataGridCommandEventArgs e)
		{
			if (e.Item.Cells[0].Text != "")
			{
				switch(((ImageButton)e.CommandSource).CommandName)
				{
					case "Borrar":
						int IdFuncion = int.Parse(e.Item.Cells[0].Text);
						BorrarFuncion(IdFuncion);
						Response.Redirect("ListaFunciones.aspx");
						break;

					case "Editar":
						Response.Redirect("AbmFuncion.aspx?IdFuncion="+ e.Item.Cells[0].Text);
						break;

				}
			}
		}
	}
}
