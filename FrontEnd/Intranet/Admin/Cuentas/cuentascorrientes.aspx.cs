using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.App;
using ar.com.TiempoyGestion.BackEnd.Clientes.Dal;
using ar.com.TiempoyGestion.BackEnd.Clientes.App;
using System.Data;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.App;
using System.Globalization;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.Admin.Cuentas
{
    public partial class Admin_Cuentas_remitos : System.Web.UI.Page
    {
        string FechaDesde = "";
        string FechaHasta = "";
        int idCliente = 0;
        int idTipoDocumento = 2;
        DataTable dtAdicional = null;
        int [] ServAdicional = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ViewState["ActiveTabIndex"] = TabCuentaCorriente.ActiveTabIndex;
                idTipoDocumento = setTipoDocumento(int.Parse(ViewState["ActiveTabIndex"].ToString()));
                Session["ArrayAdicionales"] = new int[30];
                pnCliente.Visible = false;
                //pnAdicionales.Visible = false;
                //pnRemito.Visible = false;

                if (txtFechaInicio.Text == "")
                    txtFechaInicio.Text = DateTime.Today.AddMonths(-3).ToShortDateString();
                if (txtFechaFinal.Text == "")
                    txtFechaFinal.Text = DateTime.Today.ToShortDateString();

                if (Request.QueryString["idCliente"] != null)
                {
                    hIdCliente.Value = Request.QueryString["idCliente"];
                    ClienteDal cargarCliente = new ClienteDal();
                    cargarCliente.Cargar(int.Parse(hIdCliente.Value));
                    txtCliente.Text = cargarCliente.NombreFantasia;
                    ActualizarListadoInformes(idTipoDocumento);
                }
                //ListaAdicionales();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (hIdCliente.Value != "" && txtFechaInicio.Text != "" && txtFechaFinal.Text != "")
            {
                //InicializarTablaAdicionales();
                idTipoDocumento = setTipoDocumento(int.Parse(ViewState["ActiveTabIndex"].ToString()));
                ActualizarListadoInformes(idTipoDocumento);
                //GenerarRemitoTipoPropiedad(int.Parse(hIdCliente.Value), txtFechaInicio.Text, txtFechaFinal.Text);
            }
        }

        
        protected void btnCerrar_Click(object sender, EventArgs e)
        {

        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            //GenerarRemito();
        }

        private void ActualizarListadoInformes(int idTipoDocumento)
        {
            pnListadoRemitos.Visible = true;
            pnListadoPartes.Visible = true;
            pnCliente.Visible = true;
            //pnAdicionales.Visible = true;
            //pnRemito.Visible = true;
            //int idUser = -1;
            idCliente = int.Parse(hIdCliente.Value);
            lblCliente.Text = txtCliente.Text;

            if (txtFechaInicio.Text == "")
                txtFechaInicio.Text = DateTime.Today.AddDays(-5).ToShortDateString();
            FechaDesde = txtFechaInicio.Text;

            if (txtFechaFinal.Text == "")
                txtFechaFinal.Text = DateTime.Today.ToShortDateString();
            FechaHasta = txtFechaFinal.Text;

            GestorPreciosApp remitos = new GestorPreciosApp();
            if (idTipoDocumento == 1)
            {
                dgridMovimientosRemitos.DataSource = remitos.ListaMovimientosCliente(idTipoDocumento, idCliente, FechaDesde, FechaHasta);
                dgridMovimientosRemitos.DataBind();
            }
            if (idTipoDocumento == 2)
            {
                dgridMovimientosPartes.DataSource = remitos.ListaMovimientosCliente(idTipoDocumento, idCliente, FechaDesde, FechaHasta);
                dgridMovimientosPartes.DataBind();
            }


        }

        protected void TabCuentaCorriente_ActiveTabChanged(object sender, EventArgs e)
        {
            ViewState["ActiveTabIndex"] = TabCuentaCorriente.ActiveTabIndex;
            idTipoDocumento = setTipoDocumento(int.Parse(ViewState["ActiveTabIndex"].ToString()));
            if (hIdCliente.Value != "")
                ActualizarListadoInformes(idTipoDocumento);
        } 

        protected void btnAceptar_Click1(object sender, EventArgs e)
        {
            int idTipoDocumento = setTipoDocumento(int.Parse(ViewState["ActiveTabIndex"].ToString()));
            Response.Redirect("AbmMovimiento.aspx?idTipo=" + idTipoDocumento);
        }

        protected void dgridMovimientos_PreRender(object sender, EventArgs e)
        {
            idTipoDocumento = setTipoDocumento(int.Parse(ViewState["ActiveTabIndex"].ToString()));
            if (idTipoDocumento == 1)
            {
                foreach (DataGridItem myItem in dgridMovimientosRemitos.Items)
                {
                    try
                    {
                        ((Label)myItem.FindControl("lblFecha")).Text = DateTime.Parse(myItem.Cells[1].Text).ToShortDateString() + " " + DateTime.Parse(myItem.Cells[1].Text).ToShortTimeString();
                    }
                    catch (Exception exc)
                    { }
                }
            }

            if (idTipoDocumento == 2)
            {
                foreach (DataGridItem myItem in dgridMovimientosPartes.Items)
                {
                    try
                    {
                        ((Label)myItem.FindControl("lblFecha")).Text = DateTime.Parse(myItem.Cells[1].Text).ToShortDateString() + " " + DateTime.Parse(myItem.Cells[1].Text).ToShortTimeString();
                    }
                    catch (Exception exc)
                    { }
                }
            }
        }

        protected void dgridMovimientos_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            int idTipoDocumento = setTipoDocumento(int.Parse(ViewState["ActiveTabIndex"].ToString()));
            switch (((ImageButton)e.CommandSource).CommandName)
            {
                case "Ver":
                    Response.Redirect("VerMovimiento.aspx?idTipo=" + idTipoDocumento + "&nroMovimiento=" + e.Item.Cells[0].Text + "&idCliente=" + hIdCliente.Value);
                    break;

                case "Editar":
                    Response.Redirect("AbmMovimiento.aspx?idTipo=" + idTipoDocumento + "&nroMovimiento=" + e.Item.Cells[0].Text + "&idCliente=" + hIdCliente.Value);
                    break;
            }
        }

        private int setTipoDocumento(int idTipoDocumento)
        {
            if(idTipoDocumento == 0)
                idTipoDocumento = 2;

            return idTipoDocumento;
        }
    }
}