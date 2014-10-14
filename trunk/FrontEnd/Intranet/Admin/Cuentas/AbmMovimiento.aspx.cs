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
        int nroMovimiento = 0;
        int idTipoDocumentacion = 0;
        DataTable dtAdicional = null;
        int [] ServAdicional = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                pnCliente.Visible = false;
                pnRemito.Visible = false;

                idTipoDocumentacion = int.Parse(Request.QueryString["idTipo"]);
                tipoDocumentacion.Value = Request.QueryString["idTipo"];
                setTipoDocumentacion(idTipoDocumentacion);

                if (Session["txtFechaInicio"] != null && Session["txtFechaFinal"] != null)
                {
                    txtFechaInicio.Text = Session["txtFechaInicio"].ToString();
                    txtFechaFinal.Text = Session["txtFechaFinal"].ToString();
                }
                else
                {
                    if (txtFechaInicio.Text == "")
                        txtFechaInicio.Text = DateTime.Today.AddMonths(-2).ToShortDateString();
                    if (txtFechaFinal.Text == "")
                        txtFechaFinal.Text = DateTime.Today.ToShortDateString();
                    Session["txtFechaInicio"] = txtFechaInicio.Text;
                    Session["txtFechaFinal"] = txtFechaFinal.Text;

                }

                if (Request.QueryString["nroMovimiento"] != null)
                {
                    pnListadoInformes.Visible = true;
                    btnAceptar.Visible = false;
                    hNroMovimiento.Value = Request.QueryString["nroMovimiento"];
                    hIdCliente.Value = Request.QueryString["idCliente"];
                    nroMovimiento = int.Parse(hNroMovimiento.Value);
                    ClienteDal cargarCliente = new ClienteDal();
                    cargarCliente.Cargar(int.Parse(hIdCliente.Value));
                    txtCliente.Text = cargarCliente.NombreFantasia;
                    txtCliente.ReadOnly = true;
                    ActualizarListadoInformes();
                    CargarRemitosMovimientos(idTipoDocumentacion, nroMovimiento);
                }
            }
        }

        protected void CargarRemitosMovimientos(int idTipoDocumentacion, int lNroMovimiento)
        {
            pnListadoInformes.Visible = false;
            pnCliente.Visible = true;
            pnRemito.Visible = true;
            idCliente = int.Parse(hIdCliente.Value);
            lblCliente.Text = txtCliente.Text;
            lblCliente.Text = lblCliente.Text + " - Movimiento Nº: " + lNroMovimiento;
            GenerarRemitoTipoPropiedad(idTipoDocumentacion, idCliente, "", "", false, lNroMovimiento.ToString());
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (hIdCliente.Value != "" && txtFechaInicio.Text != "" && txtFechaFinal.Text != "")
            {
                Session["txtFechaInicio"] = txtFechaInicio.Text;
                Session["txtFechaFinal"] = txtFechaFinal.Text;
                int idTipoDocumentacion = int.Parse(tipoDocumentacion.Value);
                ActualizarListadoInformes();
                GenerarRemitoTipoPropiedad(idTipoDocumentacion, int.Parse(hIdCliente.Value), Session["txtFechaInicio"].ToString(), Session["txtFechaFinal"].ToString(), true, "");
            }
        }

        protected void dgridEncabezados_PreRender(object sender, EventArgs e)
        {
            
            foreach (DataGridItem myItem in dgridEncabezados.Items)
			{
                ((Label)myItem.FindControl("lblFecha")).Text = DateTime.Parse(myItem.Cells[2].Text).ToShortDateString() + " " + DateTime.Parse(myItem.Cells[2].Text).ToShortTimeString();
            }
            /*
            addServicio
             */ 
        }
        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("cuentascorrientes.aspx?idCliente=" + hIdCliente.Value);
        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            int idMovimiento = GenerarMovimiento();
            Response.Redirect("VerMovimiento.aspx?idCliente=" + hIdCliente.Value + "&nroMovimiento=" + idMovimiento + "&idTipo=" + tipoDocumentacion.Value);
        }

        private void ActualizarListadoInformes()
        {
            pnListadoInformes.Visible = false;
            pnCliente.Visible = true;
            pnRemito.Visible = true;
            int idUser = -1;
            idCliente = int.Parse(hIdCliente.Value);
            lblCliente.Text = txtCliente.Text;

            if (txtFechaInicio.Text == "")
                txtFechaInicio.Text = DateTime.Today.AddDays(-5).ToShortDateString();
            FechaDesde = txtFechaInicio.Text;

            if (txtFechaFinal.Text == "")
                txtFechaFinal.Text = DateTime.Today.ToShortDateString();
            FechaHasta = txtFechaFinal.Text;

            BandejaEntradaApp bandeja = new BandejaEntradaApp();
            bandeja.RegPorPagina = 100;
            bandeja.Pagina = 1;
            dgridEncabezados.DataSource = bandeja.ListaEncabezados(idCliente, idUser, "3", FechaDesde, FechaHasta, 0, 0); //CAMBIAR AQUI!!!! 
            dgridEncabezados.DataBind();

        }


        protected void GenerarRemitoTipoPropiedad(int idTipoDocumentacion, int lidCliente, string lFechaDesde, string lFechaHasta, bool sinMovimiento, string lNroMovimiento)
        {
            GestorPreciosApp remitos = new GestorPreciosApp();
            dgridRemitos.DataSource = remitos.ListaRemitosPartesEntrega(idTipoDocumentacion, idCliente, lFechaDesde, lFechaHasta, sinMovimiento, lNroMovimiento);
            dgridRemitos.DataBind();
        }




        private int GenerarMovimiento()
        {
            CheckBox chkEstado;
            UsuarioAutenticado Usuario = (UsuarioAutenticado)Session["UsuarioAutenticado"];
            int idCliente = int.Parse(hIdCliente.Value);
            int idUsuarioIntra = Usuario.IdUsuario;
            int idTipoDocumentacion = int.Parse(tipoDocumentacion.Value);
            GestorPreciosApp gp = new GestorPreciosApp();
            int idMovimiento = gp.crearMovimiento(idTipoDocumentacion, idCliente, idUsuarioIntra);


            foreach (DataGridItem myItem in dgridRemitos.Items)
            {
                chkEstado = (CheckBox)myItem.FindControl("chkEstado");
				if(chkEstado.Checked)
                    gp.agregarRemitoParteEntregaMovimiento(idTipoDocumentacion, idMovimiento, int.Parse(myItem.Cells[1].Text));
            }

            return idMovimiento;

        }



        protected void dgridRemitos_PreRender(object sender, EventArgs e)
        {
            string strRemito = "";
            if (tipoDocumentacion.Value == "1")
                strRemito = "Remito";
            else
                strRemito = "Parte";

            foreach (DataGridItem myItem in dgridRemitos.Items)
            {
                try
                {
                    ((Label)myItem.FindControl("lblFecha")).Text = DateTime.Parse(myItem.Cells[2].Text).ToShortDateString() + " " + DateTime.Parse(myItem.Cells[2].Text).ToShortTimeString();
                    ((ImageButton)myItem.FindControl("Eliminar")).Attributes.Add("onclick", @"javascript: return confirm('¿Desea eliminar el " + strRemito + " del movimiento?');");
                    if (Request.QueryString["nroMovimiento"] == null)
                    {
                        ((ImageButton)myItem.FindControl("Ver")).Visible = false;
                        ((ImageButton)myItem.FindControl("Eliminar")).Visible = false;
                    }
                }
                catch (Exception exc)
                { }
            }
            if (tipoDocumentacion.Value == "1")
                dgridRemitos.Columns[2].HeaderText = "Remito";
            else
                dgridRemitos.Columns[2].HeaderText = "Parte";
        }


        protected void dgridRemitos_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            int idTipoDocumentacion = int.Parse(tipoDocumentacion.Value);
            switch (((ImageButton)e.CommandSource).CommandName)
            {
                case "Ver":
                    Response.Redirect("VerMovimiento.aspx?idTipo=" + idTipoDocumentacion + "&nroMovimiento=" + Request.QueryString["nroMovimiento"] + "&idCliente=" + hIdCliente.Value);
                    break;

                case "Eliminar":
                    EliminarRemitoMovimiento(idTipoDocumentacion, Request.QueryString["nroMovimiento"], int.Parse(e.Item.Cells[1].Text));
                    Response.Redirect("AbmMovimiento.aspx?idTipo=" + idTipoDocumentacion + "&nroMovimiento=" + Request.QueryString["nroMovimiento"] + "&idCliente=" + hIdCliente.Value);
                    break;
            }
        }



        private void EliminarRemitoMovimiento(int idTipoDocumentacion, string nroMovimiento, int nroRemito)
        {
            UsuarioAutenticado Usuario = (UsuarioAutenticado)Session["UsuarioAutenticado"];
            GestorPreciosApp gp = new GestorPreciosApp();
            gp.eliminarRemitoMovimiento(idTipoDocumentacion, int.Parse(nroMovimiento), nroRemito);
            //Response.Redirect("AbmRemitos.aspx?id=" + nroRemito + "&idCliente=" + hIdCliente.Value);
        }


        private void setTipoDocumentacion(int idTipoDocumentacion)
        {
            if (idTipoDocumentacion == 1)
            {
                lblTipo.Text = "Remito";
                btnAceptar.Text = "Finalizar movimiento remito";
            }
            else
            {
                lblTipo.Text = "Parte de entrega";
                btnAceptar.Text = "Finalizar movimiento parte de entrega";
            }
        }
    }
}