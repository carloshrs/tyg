using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.Clientes.Dal;
using ar.com.TiempoyGestion.BackEnd.Reportes.Dal;
using System.Data;
using System.Globalization;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.Admin.Reportes
{
	/// <summary>
	/// Summary description for ListaFunciones.
	/// </summary>
    public partial class ReCantidadInformes : Page
	{

        string FechaDesde = "";
        string FechaHasta = "";

		protected void Page_Load(object sender, EventArgs e)
		{
            
			if (!Page.IsPostBack)
			{

                ListaTiposInformes();

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

       



      

      

       
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string vTiposInformes = "";
            int vPeriodo = 1;
            string FechaDesde2 = "";
            string FechaHasta2 = "";
            string FechaDesde3 = "";
            string FechaHasta3 = "";
            string FechaDesde4 = "";
            string FechaHasta4 = "";
            string FechaDesde5 = "";
            string FechaHasta5 = "";

            if (txtFechaInicio.Text == "")
                txtFechaInicio.Text = DateTime.Today.AddDays(-60).ToShortDateString();
            FechaDesde = txtFechaInicio.Text;

            if (txtFechaFinal.Text == "")
                txtFechaFinal.Text = DateTime.Today.ToShortDateString();
            FechaHasta = txtFechaFinal.Text;

            foreach (ListItem myItem in chkInformes.Items)
            {

                if (myItem.Selected)
                    vTiposInformes = vTiposInformes + myItem.Value + ",";

            }

            vTiposInformes = vTiposInformes.Substring(0, vTiposInformes.Length - 1);

            lblCantidadInformes1.Text = "Informes del " + FechaDesde + " al " + FechaHasta;
            ReportesCobranzas rsReportes1 = new ReportesCobranzas();
            dgCantidadInformes1.DataSource = ReportesCobranzas.ListarCantidadInformes(FechaDesde, FechaHasta, vTiposInformes, int.Parse(cmbEstado.SelectedValue)).DefaultView;
            dgCantidadInformes1.DataBind();

            if (int.Parse(cmbPeriodo.SelectedValue) == 1) // Meses 1, Años 2
                vPeriodo = 1;
            else
                vPeriodo = 2;

            if (int.Parse(cmbCantidad.SelectedValue) >= 2)
            {
                pnPanel2.Visible = true;
                if (vPeriodo == 1)
                {
                    FechaDesde2 = DateTime.Parse(FechaDesde).AddMonths(-1).ToShortDateString();
                    FechaHasta2 = DateTime.Parse(FechaHasta).AddMonths(-1).ToShortDateString();
                }
                else
                {
                    FechaDesde2 = DateTime.Parse(FechaDesde).AddYears(-1).ToShortDateString();
                    FechaHasta2 = DateTime.Parse(FechaHasta).AddYears(-1).ToShortDateString();
                }

                lblCantidadInformes2.Text = "Informes del " + FechaDesde2 + " al " + FechaHasta2;
                ReportesCobranzas rsReportes2 = new ReportesCobranzas();
                dgCantidadInformes2.DataSource = ReportesCobranzas.ListarCantidadInformes(FechaDesde, FechaHasta, vTiposInformes, int.Parse(cmbEstado.SelectedValue)).DefaultView;
                dgCantidadInformes2.DataBind();
            }


            if (int.Parse(cmbCantidad.SelectedValue) >= 3)
            {
                pnPanel3.Visible = true;
                if (vPeriodo == 1)
                {
                    FechaDesde3 = DateTime.Parse(FechaDesde).AddMonths(-2).ToShortDateString();
                    FechaHasta3 = DateTime.Parse(FechaHasta).AddMonths(-2).ToShortDateString();
                }
                else
                {
                    FechaDesde3 = DateTime.Parse(FechaDesde).AddYears(-2).ToShortDateString();
                    FechaHasta3 = DateTime.Parse(FechaHasta).AddYears(-2).ToShortDateString();
                }

                lblCantidadInformes3.Text = "Informes del " + FechaDesde3 + " al " + FechaHasta3;
                ReportesCobranzas rsReportes3 = new ReportesCobranzas();
                dgCantidadInformes3.DataSource = ReportesCobranzas.ListarCantidadInformes(FechaDesde, FechaHasta, vTiposInformes, int.Parse(cmbEstado.SelectedValue)).DefaultView;
                dgCantidadInformes3.DataBind();
            }



            if (int.Parse(cmbCantidad.SelectedValue) >= 4)
            {
                pnPanel4.Visible = true;
                if (vPeriodo == 1)
                {
                    FechaDesde4 = DateTime.Parse(FechaDesde).AddMonths(-3).ToShortDateString();
                    FechaHasta4 = DateTime.Parse(FechaHasta).AddMonths(-3).ToShortDateString();
                }
                else
                {
                    FechaDesde4 = DateTime.Parse(FechaDesde).AddYears(-3).ToShortDateString();
                    FechaHasta4 = DateTime.Parse(FechaHasta).AddYears(-3).ToShortDateString();
                }

                lblCantidadInformes4.Text = "Informes del " + FechaDesde4 + " al " + FechaHasta4;
                ReportesCobranzas rsReportes4 = new ReportesCobranzas();
                dgCantidadInformes4.DataSource = ReportesCobranzas.ListarCantidadInformes(FechaDesde, FechaHasta, vTiposInformes, int.Parse(cmbEstado.SelectedValue)).DefaultView;
                dgCantidadInformes4.DataBind();
            }


            if (int.Parse(cmbCantidad.SelectedValue) == 5)
            {
                pnPanel5.Visible = true;
                if (vPeriodo == 1)
                {
                    FechaDesde5 = DateTime.Parse(FechaDesde).AddMonths(-4).ToShortDateString();
                    FechaHasta5 = DateTime.Parse(FechaHasta).AddMonths(-4).ToShortDateString();
                }
                else
                {
                    FechaDesde5 = DateTime.Parse(FechaDesde).AddYears(-4).ToShortDateString();
                    FechaHasta5 = DateTime.Parse(FechaHasta).AddYears(-4).ToShortDateString();
                }

                lblCantidadInformes5.Text = "Informes del " + FechaDesde5 + " al " + FechaHasta5;
                ReportesCobranzas rsReportes5 = new ReportesCobranzas();
                dgCantidadInformes5.DataSource = ReportesCobranzas.ListarCantidadInformes(FechaDesde, FechaHasta, vTiposInformes, int.Parse(cmbEstado.SelectedValue)).DefaultView;
                dgCantidadInformes5.DataBind();
            }
        }



        private void ListaTiposInformes()
        {

            BandejaEntradaDal Tipos = new BandejaEntradaDal();
            chkInformes.Items.Clear();
            DataTable myTable = Tipos.TraerTiposInformes();
            ListItem myItem;
            foreach (DataRow myRow in myTable.Rows)
            {
                myItem = new ListItem(myRow[0].ToString(), myRow[1].ToString());
                chkInformes.Items.Add(myItem);
                
            }
        }


        protected void dgCajaDiariaDetalle_PreRender1(object sender, EventArgs e)
        {
            float vTotal = 0;
            foreach (DataGridItem myItem in dgCantidadInformes1.Items)
            {
                try
                {
                    

                    vTotal = vTotal + float.Parse(myItem.Cells[5].Text);
                }
                catch (Exception exc)
                { }

            }

            lblTotal1.Text = "$ " + vTotal;
        }
}
}
