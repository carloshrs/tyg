using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.Clientes.Dal;
using ar.com.TiempoyGestion.BackEnd.Reportes.Dal;
using System.Data;
using System.Globalization;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.Admin.Reportes
{
	/// <summary>
	/// Summary description for ListaFunciones.
	/// </summary>
    public partial class ReMovimientosCuentas : Page
	{

        string FechaDesde = "";
        string FechaHasta = "";

		protected void Page_Load(object sender, EventArgs e)
		{
            
			if (!Page.IsPostBack)
			{

                ListaConceptos(0);

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

       



        protected void dgCajaDiariaDetalle_PreRender(object sender, EventArgs e)
        {
            foreach (DataGridItem myItem in dgCajaDiariaDetalle.Items)
            {
                try
                {
                    if (myItem.Cells[4].Text == "1")  //Ingreso
                    {
                        ((Label)myItem.FindControl("lblEntrada")).Text = "Ingreso";
                        ((Label)myItem.FindControl("lblEntrada")).ForeColor = System.Drawing.Color.BlueViolet;
                        ((Label)myItem.FindControl("lblEntrada")).Font.Bold = true; 
                        //myItem.Font.Bold = true;
                        //myItem.Font.Name = "blue";
                    }
                    else    //salida
                    {
                        ((Label)myItem.FindControl("lblEntrada")).Text = "Egreso";
                        ((Label)myItem.FindControl("lblEntrada")).ForeColor = System.Drawing.Color.Red;
                        ((Label)myItem.FindControl("lblEntrada")).Font.Bold = true;
                    }
                }
                catch (Exception exc)
                { }

            }
        }

      

       
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            int entradasalida = 0;
            if (txtFechaInicio.Text == "")
                txtFechaInicio.Text = DateTime.Today.AddDays(-60).ToShortDateString();
            FechaDesde = txtFechaInicio.Text;

            if (txtFechaFinal.Text == "")
                txtFechaFinal.Text = DateTime.Today.ToShortDateString();
            FechaHasta = txtFechaFinal.Text;

            if (raSalida.Checked)
                entradasalida = 0;

            if (raEntrada.Checked)
                entradasalida = 1;

            string vConcepto = cmbConcepto.SelectedItem.Text;
            //GestorPrecios Adicionales = new GestorPrecios();
            dgCajaDiariaDetalle.DataSource = ReportesCobranzas.ListarCajaMovimientos(FechaDesde, FechaHasta, vConcepto, entradasalida).DefaultView;
            dgCajaDiariaDetalle.DataBind();
        }


        private void ListaConceptos(int idTipoIngreso)
        {
            cmbConcepto.Items.Clear();
            DataTable myTb;
            myTb = ReportesCobranzas.ListarConceptos("", 1, idTipoIngreso);
            ListItem myItem;
            foreach (DataRow myRow in myTb.Rows)
            {
                myItem = new ListItem(myRow[1].ToString(), myRow[0].ToString());
                cmbConcepto.Items.Add(myItem);
            }
        }


        protected void dgCajaDiariaDetalle_PreRender1(object sender, EventArgs e)
        {
            float vTotal = 0;
            foreach (DataGridItem myItem in dgCajaDiariaDetalle.Items)
            {
                try
                {
                    if (myItem.Cells[2].Text == "1")  //Ingreso
                    {
                        ((Label)myItem.FindControl("lblEntrada")).Text = "Ingreso";
                        ((Label)myItem.FindControl("lblEntrada")).ForeColor = System.Drawing.Color.BlueViolet;
                        ((Label)myItem.FindControl("lblEntrada")).Font.Bold = true;
                        //myItem.Font.Bold = true;
                        //myItem.Font.Name = "blue";
                    }
                    else    //salida
                    {
                        ((Label)myItem.FindControl("lblEntrada")).Text = "Egreso";
                        ((Label)myItem.FindControl("lblEntrada")).ForeColor = System.Drawing.Color.Red;
                        ((Label)myItem.FindControl("lblEntrada")).Font.Bold = true;
                    }

                    vTotal = vTotal + float.Parse(myItem.Cells[5].Text);
                }
                catch (Exception exc)
                { }

            }

            lblTotal.Text = "$ " + vTotal;
        }
}
}
