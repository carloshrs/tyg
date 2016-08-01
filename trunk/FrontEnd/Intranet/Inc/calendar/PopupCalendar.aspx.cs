using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.Inc
{
	/// <summary>
	/// Summary description for PopupCalendar.
	/// </summary>
	public partial class PopupCalendar : Page
	{

		protected void Page_Load(object sender, EventArgs e)
		{
			// Put user code to initialize the page here
			control.Value = Request.QueryString["textbox"].ToString();
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
			this.Load += new EventHandler(this.Page_Load);

		}

		#endregion

		protected void Change_Date(object sender, EventArgs e)
		{
			string strScript = "<script>window.opener.document.forms(0)." + control.Value + ".value = '";
			strScript += calDate.SelectedDate.ToString("dd/MM/yyyy");
			strScript += "';self.close()";
			strScript += "</" + "script>";
			RegisterClientScriptBlock("anything", strScript);

		}
	}
}