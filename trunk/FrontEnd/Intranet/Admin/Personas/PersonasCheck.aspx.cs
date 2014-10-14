using System;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.Admin.Personas
{
	/// <summary>
	/// Summary description for PersonasCheck.
	/// </summary>
	public partial class PersonasCheck : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				string strNumero;
				try
				{
					strNumero = Request.QueryString["Numero"];
					dgPersonas.DataSource = ControlPersonasDal.ControlarDocumento(strNumero);
					dgPersonas.DataBind();
					if(dgPersonas.Items.Count == 0)
						btnCerrar_Click(null, null);
					else
						lblFiltro.Text = "Documento Nro.: " + strNumero;
				}
				catch
				{
					btnCerrar_Click(null, null);
				}
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

		}
		#endregion

		protected void btnCerrar_Click(object sender, System.EventArgs e)
		{
			string strScript = "<script languaje=\"Javascript\">";
			strScript += "window.close();";
			strScript += "</script>";

			Page.RegisterStartupScript("Cerrar", strScript);
			this.Dispose();

		}

		protected void dgPersonas_PreRender(object sender, System.EventArgs e)
		{
			foreach (DataGridItem myItem in dgPersonas.Items)
			{
				((ImageButton)myItem.FindControl("ibutPredeterminar")).Attributes.Add("onclick",@"javascript: descargarDatos('" + myItem.Cells[2].Text + "', '" + myItem.Cells[3].Text + "');");
			}
		}
	}
}
