using System;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.Admin.Informes
{
	/// <summary>
	/// Summary description for PersonasCheck.
	/// </summary>
	public partial class MatriculaCheck : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				int intId;
				int intTipo=1;
                int intTipoInforme = 1;
                int intIdProvincia = 2;
				string strLegajo="";
				string strFolio="";
				string strAno="";
                string strTomo = "";
				try
				{
					intId = int.Parse(Request.QueryString["Id"]);
					intTipo = int.Parse(Request.QueryString["Tipo"]);
                    intTipoInforme = int.Parse(Request.QueryString["tipoInforme"]);
                    intIdProvincia = int.Parse(Request.QueryString["idProvincia"]);

                    strLegajo = Request.QueryString["Legajo"];
					if(intTipo == 2 || intTipo == 3)
					{
						strFolio = Request.QueryString["Folio"];
						strAno = Request.QueryString["Ano"];
                        strTomo = Request.QueryString["Tomo"];
						dgMatriculas.DataSource = ControlMatriculasDal.ControlarMatricula(intId, intTipoInforme, intTipo, intIdProvincia, strLegajo, strTomo, strFolio, strAno);
						txtTipo.Text = "Matricula, Folio y Año ";
					}
					else
					{
						dgMatriculas.DataSource = ControlMatriculasDal.ControlarMatricula(intId, intTipoInforme, intTipo, intIdProvincia, strLegajo);
						txtTipo.Text = "Matricula ";
					}
					dgMatriculas.DataBind();
					if(dgMatriculas.Items.Count == 0)
						btnCerrar_Click(null, null);
					else
					{
						if (intTipo == 2 || intTipo == 3)
							lblFiltro.Text = "Matricula: " + strLegajo + ", Folio: " + strFolio + ", Año: " + strAno;
						else
							lblFiltro.Text = "Matricula: " + strLegajo;
					}
				}
				catch
				{
					//btnCerrar_Click(null, null);
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

		protected void dgMatriculas_PreRender(object sender, System.EventArgs e)
		{
			foreach (DataGridItem myItem in dgMatriculas.Items)
			{
				((Label)myItem.FindControl("lblFecha")).Text = DateTime.Parse(myItem.Cells[0].Text).ToShortDateString() + " " + DateTime.Parse(myItem.Cells[0].Text).ToShortTimeString();
			}
		}
	}
}
