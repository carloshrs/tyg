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


            ReportesCobranzas rsReportes = new ReportesCobranzas();
            dgCantidadInformes1.DataSource = ReportesCobranzas.ListarCantidadInformes(FechaDesde, FechaHasta, vTiposInformes, int.Parse(cmbEstado.SelectedValue)).DefaultView;
            dgCantidadInformes1.DataBind();
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
