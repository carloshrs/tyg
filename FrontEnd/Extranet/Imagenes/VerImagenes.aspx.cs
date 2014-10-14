using System;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.Admin.Imagenes
{
	/// <summary>
	/// Summary description for ABMImagenes.
	/// </summary>
	public partial class VerImagenes : Page
	{
		int intIdInforme;
	
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				try
				{
					intIdInforme = int.Parse(Request.QueryString["Informe"]);
					ViewState["IdInforme"] = intIdInforme.ToString();
					CargarImagenes();
				}
				catch
				{
					string strScript = "<script languaje=\"Javascript\" >window.close();</script>";
					Page.RegisterStartupScript("CerrarError", strScript);
				}

			}
			else
				intIdInforme = int.Parse(ViewState["IdInforme"].ToString());
		}

		private void CargarImagenes()
		{
			ImagenDal imagenDal = new ImagenDal();
			dgImagenes.DataSource = imagenDal.Listar(intIdInforme).DefaultView;
			dgImagenes.DataBind();

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
			this.dgImagenes.PreRender += new EventHandler(this.dgImagenes_PreRender);
			this.btnCerrar.Click += new EventHandler(this.btnCerrar_Click);
			this.Load += new EventHandler(this.Page_Load);

		}
		#endregion

		private void dgImagenes_PreRender(object sender, EventArgs e)
		{
			foreach(DataGridItem myItem in dgImagenes.Items)
			{
				((ImageButton)myItem.FindControl("ibutVer")).Attributes.Add("onClick","Javascript:Mostrar('/Imagenes/VerImagen.aspx?path=" + myItem.Cells[4].Text + "&desc=" + myItem.Cells[1].Text + "');return false;");

				if (myItem.Cells[5].Text == "1")
				{
					myItem.ForeColor = Color.Blue;
					((ImageButton)myItem.FindControl("ibutPredeterminar")).Visible = true;
				}
				else
					((ImageButton)myItem.FindControl("ibutPredeterminar")).Visible = false;

			}
		}

		private void btnCerrar_Click(object sender, EventArgs e)
		{
			string strScript = "<script languaje=\"Javascript\">";
			strScript += "window.close();";
			strScript += "</script>";

			Page.RegisterStartupScript("Cerrar", strScript);
		}

		
	}
}
