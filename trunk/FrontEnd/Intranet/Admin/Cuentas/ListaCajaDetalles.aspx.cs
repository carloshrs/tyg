using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.Clientes.Dal;
using ar.com.TiempoyGestion.BackEnd.Cobranzas.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.Admin.Seguridad.Admin.Cuentas
{
	/// <summary>
	/// Summary description for ListaFunciones.
	/// </summary>
    public partial class ListaCajaDetalles : Page
	{
	
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
                string idCaja = "";
                idCaja = Request.QueryString["id"];
                hdIdCaja.Value = idCaja;
                pnlEncabezado.Visible = true;
                CargarEncabezadoCaja(idCaja);
				CargarCajas(idCaja);

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
            this.dgCajaDiariaDetalle.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgCajaDiaria_ItemCommand);

		}
		#endregion

        protected void btnNuevaApertura_Click(object sender, EventArgs e)
		{
			Response.Redirect("AbmCaja.aspx");
		}

        private void CargarCajas(string idCaja)
		{
			//GestorPrecios Adicionales = new GestorPrecios();
            dgCajaDiariaDetalle.DataSource = GestorPrecios.ListarCajasDetalle(idCaja).DefaultView;
			dgCajaDiariaDetalle.DataBind();

		}

		private void BorrarCaja(int lId)
		{
            GestorPrecios.EliminarCaja(lId);
		}

        private void dgCajaDiaria_ItemCommand(object source, DataGridCommandEventArgs e)
		{
			if (e.Item.Cells[0].Text != "")
			{
				switch(((ImageButton)e.CommandSource).CommandName)
				{
					case "Borrar":
						int IdFuncion = int.Parse(e.Item.Cells[0].Text);
                        BorrarCaja(IdFuncion);
						Response.Redirect("ListaCaja.aspx");
						break;

					case "Editar":
						Response.Redirect("AbmCaja.aspx?id="+ e.Item.Cells[0].Text);
						break;

                    case "Detalle":
                        Response.Redirect("ListaCajaDetalle.aspx?id=" + e.Item.Cells[0].Text);
                        break;

				}
			}
		}


        private void CargarEncabezadoCaja(string idCaja)
        {
            btnNuevo.Enabled = true;
            GestorPrecios CajaEncabezado = new GestorPrecios();
            CajaEncabezado.CargarCaja(int.Parse(idCaja));
            lblFechaApertura.Text = CajaEncabezado.Apertura;
            lblFechaCierre.Text = CajaEncabezado.Cierre;
            lblEfectivoInicial.Text = CajaEncabezado.EfectivoInicial.ToString();
            lblChequeInicial.Text = CajaEncabezado.ChequeInicial.ToString();
            lblSaldoEfectivo.Text = CajaEncabezado.SaldoEfectivo.ToString();
            lblSaldoCheque.Text = CajaEncabezado.SaldoCheque.ToString();

            if (CajaEncabezado.Cierre != "")
                btnNuevo.Enabled = false;
        }


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

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("AbmCajaDetalle.aspx?idCaja=" + hdIdCaja.Value);
        }


        protected void dgCajaDiariaDetalle_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.Item.Cells[0].Text != "")
            {
                switch (((ImageButton)e.CommandSource).CommandName)
                {
                    case "Detalle":
                        Response.Redirect("VerCajaDetalle.aspx?idCajaDetalle=" + e.Item.Cells[0].Text);
                        break;

                }
            }

        }
}
}
