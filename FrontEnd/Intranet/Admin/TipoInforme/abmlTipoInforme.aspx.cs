using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.Extranet.TipoInforme
{
	/// <summary>
	/// Summary description for ListaTipoInforme.
	/// </summary>
	public partial class ListaTipoInforme : Page
	{

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{

                btnVolver.Visible = false;
                dgTipoPropiedad.Visible = false;
                dgTipoInforme.Visible = true;
                TipoInformeApp objTipoInforme = new TipoInformeApp();
				dgTipoInforme.DataSource = objTipoInforme.TraerDatos();
				dgTipoInforme.DataBind();

                if (Request.QueryString["idTipo"] != null)
                {
                    btnVolver.Visible = true;
                    dgTipoPropiedad.Visible = true;
                    dgTipoInforme.Visible = false;

                    TipoPropiedadApp objTipoPropiedad = new TipoPropiedadApp();
                    dgTipoPropiedad.DataSource = objTipoPropiedad.TraerDatos();
                    dgTipoPropiedad.DataBind();
                }

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
			this.dgTipoInforme.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgTipoInforme_ItemCommand);
            this.dgTipoPropiedad.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgTipoPropiedad_ItemCommand);
		}

		#endregion

		private void dgTipoInforme_ItemCommand(object source, DataGridCommandEventArgs e)
		{
			if (e.Item.Cells[0].Text != "")
			{
                if (int.Parse(e.Item.Cells[0].Text) ==1)
                    Response.Redirect("/Admin/TipoInforme/abmlTipoInforme.aspx?idTipo=" + e.Item.Cells[0].Text);
                else

                Response.Redirect("/Admin/TipoInforme/abmPreciosTipoInforme.aspx?idTipo=" + e.Item.Cells[0].Text);
			}

		}


        private void dgTipoPropiedad_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.Item.Cells[0].Text != "")
            {
                Response.Redirect("/Admin/TipoInforme/abmPreciosTipoInforme.aspx?idTipoPropiedad=1&idTipo=" + e.Item.Cells[0].Text);
            }

        }

		protected void btnCerrar_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("/Default.aspx");

		}


        protected void btnVolver_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("abmlTipoInforme.aspx");

        }

	}
}