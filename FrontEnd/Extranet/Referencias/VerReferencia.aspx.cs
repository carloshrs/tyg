using System;
using System.Web.UI.WebControls;
using System.Configuration;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Extranet.Informes
{
	/// <summary>
	/// Summary description for altaInforme.
	/// </summary>
	public partial class VerReferencia : System.Web.UI.Page
	{
		private int IdReferencia;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			lblFile.Visible = false;
			if(Request.QueryString["IdReferencia"] != null)
			{	
				IdReferencia = int.Parse(Request.QueryString["IdReferencia"]);
				ReferenciasApp Referencia = new ReferenciasApp();
				Referencia.Cargar(IdReferencia);
				lblDescripcion.Text = Referencia.Descripcion;
				lblObservaciones.Text = Referencia.Observaciones;
				if(Request.QueryString["isFile"] == "1")
				{	
					lblFile.Visible = true;
					pnlInformes.Visible = false;
					lblFile.Text = "<a class='text' href='" + ConfigurationSettings.AppSettings["PATH"] + Referencia.Path + "' target='_blank'>" + Referencia.Path + "</a>";
				} 
				else 
				{
					pnlInformes.Visible = true;
					if (!Page.IsPostBack) ListaEncabezados(IdReferencia);
				}
			} 
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			// Put user code to initialize the page here
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.dgridEncabezados.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgridEncabezados_ItemCommand);

		}
		#endregion




		private void ListaEncabezados(int IdRef)
		{
			BandejaEntradaApp bandeja = new BandejaEntradaApp();
			dgridEncabezados.DataSource = bandeja.ListaEncabezados(IdRef);
			dgridEncabezados.DataBind();
		}

		protected void dgridEncabezados_PreRender(object sender, System.EventArgs e)
		{
			foreach (DataGridItem myItem in dgridEncabezados.Items)
			{
				myItem.Cells[6].Text= "<IMG SRC='/img/Estado" + myItem.Cells[9].Text + ".gif' widht='14' height='14' border='0'>&nbsp;&nbsp;&nbsp;" + myItem.Cells[5].Text;
			}
		}

		private void dgridEncabezados_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.Item.Cells[0].Text != "")
			{
				switch(((ImageButton)e.CommandSource).CommandName)
				{
					case "VerInforme":
						Response.Redirect("/Informes/VerInforme.aspx?id="+ e.Item.Cells[0].Text);
						break;

					case "VerHistorial":
						Response.Redirect("/Informes/VerHistorial.aspx?id="+ e.Item.Cells[0].Text);
						break;
				}
			}
		}

	}
}
