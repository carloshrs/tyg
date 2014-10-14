using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.BandejaEntrada
{
	/// <summary>
	/// Summary description for VerHistorial.
	/// </summary>
	public partial class VerHistorial : Page
	{
		protected Button Cerrar;

		protected void Page_Load(object sender, EventArgs e)
		{
			// Put user code to initialize the page here
			int idEncabezado = int.Parse(Request.QueryString["id"]);
			UtilesApp Historico = new UtilesApp();
			dgridHistorico.DataSource = Historico.TraerHistorial(idEncabezado, 1);
			dgridHistorico.DataBind();
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
			this.dgridHistorico.PreRender += new EventHandler(this.dgridHistorico_PreRender);
			this.Load += new EventHandler(this.Page_Load);

		}

		#endregion

		private void dgridHistorico_PreRender(object sender, EventArgs e)
		{
			foreach (DataGridItem myItem in dgridHistorico.Items)
			{
				myItem.Cells[7].Text = "<IMG SRC='/img/Estado" + myItem.Cells[8].Text + ".gif' widht='14' height='14' border='0'>&nbsp;&nbsp;&nbsp;" + myItem.Cells[6].Text;
				myItem.Cells[1].Text = myItem.Cells[10].Text + ", " + myItem.Cells[9].Text;
			}
		}

	}
}