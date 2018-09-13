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
                

			}

            int vEntradaSalida = 0;
            if (raEntrada.Checked)
                vEntradaSalida = 1;
            else
                vEntradaSalida = 0;
            ListaConceptos(vEntradaSalida);

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
            FechaDesde = txtFechaInicio.Text + " 00:00:00";

            if (txtFechaFinal.Text == "")
                txtFechaFinal.Text = DateTime.Today.ToShortDateString();
            FechaHasta = txtFechaFinal.Text +  " 23:59:59";

            if (raSalida.Checked)
                entradasalida = 0;

            if (raEntrada.Checked)
                entradasalida = 1;

            string vConcepto = cmbConcepto.SelectedValue;
            //GestorPrecios Adicionales = new GestorPrecios();
            if (rbConceptos.Checked)
            {
                // Listado de conceptos
                dgCajaDiariaDetalle.Columns[5].Visible = false;
                dgCajaDiariaDetalle.DataSource = ReportesCobranzas.ListarCajaMovimientos(FechaDesde, FechaHasta, int.Parse(vConcepto), entradasalida).DefaultView;
            }
            else
            {
                // Listado de informes
                dgCajaDiariaDetalle.Columns[5].Visible = true;
                dgCajaDiariaDetalle.DataSource = ReportesCobranzas.ListarCajaMovimientos(FechaDesde, FechaHasta, 0, entradasalida, 0).DefaultView;
            }
            dgCajaDiariaDetalle.DataBind();
        }


        private void ListaConceptos(int idTipoIngreso)
        {
            string vConcepto = cmbConcepto.SelectedValue;
            cmbConcepto.Items.Clear();
            DataTable myTb;
            myTb = ReportesCobranzas.ListarConceptos("", 1, idTipoIngreso);
            ListItem myItem;
            foreach (DataRow myRow in myTb.Rows)
            {
                myItem = new ListItem(myRow[1].ToString(), myRow[0].ToString());
                cmbConcepto.Items.Add(myItem);

                if (vConcepto == myRow[0].ToString())
				{
					cmbConcepto.SelectedIndex = -1;
					myItem.Selected = true;
				}
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

                    vTotal = vTotal + float.Parse(myItem.Cells[6].Text);
                }
                catch (Exception exc)
                { }

            }

            lblTotal.Text = "$ " + vTotal;
        }
        protected void cmbConcepto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void rbInformes_PreRender(object sender, EventArgs e)
        {
            CambiarConcepto();
        }
        protected void rbConceptos_CheckedChanged(object sender, EventArgs e)
        {
            CambiarConcepto();
        }

        protected void rbInformes_CheckedChanged(object sender, EventArgs e)
        {
            CambiarConcepto();
        }


        private void CambiarConcepto()
        {
            if (rbInformes.Checked)
                cmbConcepto.Enabled = false;
            else
                cmbConcepto.Enabled = true;
        }
        
}
}
