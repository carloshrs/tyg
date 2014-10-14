using System;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Extranet.Informes
{
	/// <summary>
	/// Summary description for VerHistorial.
	/// </summary>
	public partial class VerHistorialReferencias : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			int idEncabezado= int.Parse(Request.QueryString["id"]);
			UtilesApp Historico = new UtilesApp();
			dgridHistorico.DataSource = Historico.TraerHistorial(idEncabezado, 3);
			dgridHistorico.DataBind();
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

		}
		#endregion

		protected void dgridHistorico_PreRender(object sender, System.EventArgs e)
		{
			foreach (DataGridItem myItem in dgridHistorico.Items)
			{
				myItem.Cells[6].Text= "<IMG SRC='/img/Estado" + myItem.Cells[7].Text + ".gif' widht='14' height='14' border='0'>&nbsp;&nbsp;&nbsp;" + myItem.Cells[5].Text;
			}
		}
	}
}
