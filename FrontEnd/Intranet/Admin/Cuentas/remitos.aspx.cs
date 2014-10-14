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
        int idTipoDocumentacion = 0;
        DataTable dtAdicional = null;
        int [] ServAdicional = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                idTipoDocumentacion = int.Parse(Request.QueryString["idTipo"]);
                tipoDocumentacion.Value = Request.QueryString["idTipo"];
                setTipoCobranza(idTipoDocumentacion);
                    
                Session["ArrayAdicionales"] = new int[30];
                pnCliente.Visible = false;
                //pnAdicionales.Visible = false;
                //pnRemito.Visible = false;

                if (txtFechaInicio.Text == "")
                    txtFechaInicio.Text = DateTime.Today.AddDays(-15).ToShortDateString();
                if (txtFechaFinal.Text == "")
                    txtFechaFinal.Text = DateTime.Today.ToShortDateString();

                if (Request.QueryString["idCliente"] != null)
                {
                    hIdCliente.Value = Request.QueryString["idCliente"];
                    tipoDocumentacion.Value = Request.QueryString["idTipo"];
                    ClienteDal cargarCliente = new ClienteDal();
                    cargarCliente.Cargar(int.Parse(hIdCliente.Value));
                    txtCliente.Text = cargarCliente.NombreFantasia;
                    ActualizarListadoInformes();
                }
                //ListaAdicionales();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (hIdCliente.Value != "" && txtFechaInicio.Text != "" && txtFechaFinal.Text != "")
            {
                //InicializarTablaAdicionales();
                ActualizarListadoInformes();
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

        private void ActualizarListadoInformes()
        {
            pnListadoRemitos.Visible = true;
            pnCliente.Visible = true;
            //pnAdicionales.Visible = true;
            //pnRemito.Visible = true;
            //int idUser = -1;
            idCliente = int.Parse(hIdCliente.Value);
            idTipoDocumentacion =  int.Parse(tipoDocumentacion.Value);
            lblCliente.Text = txtCliente.Text;

            if (txtFechaInicio.Text == "")
                txtFechaInicio.Text = DateTime.Today.AddDays(-5).ToShortDateString();
            FechaDesde = txtFechaInicio.Text;

            if (txtFechaFinal.Text == "")
                txtFechaFinal.Text = DateTime.Today.ToShortDateString();
            FechaHasta = txtFechaFinal.Text;

            GestorPreciosApp remitos = new GestorPreciosApp();
            dgridRemitos.DataSource = remitos.ListaRemitosPartesEntrega(idTipoDocumentacion, idCliente, FechaDesde, FechaHasta, false, "");
            dgridRemitos.DataBind();

        }
        /*
        private void ListaAdicionales()
        {
            ddAdicional.Items.Clear();
            DataTable myTb;
            myTb = GestorPrecios.ListarAdicionales("");
            ListItem myItem;
            foreach (DataRow myRow in myTb.Rows)
            {
                myItem = new ListItem(myRow[1].ToString(), myRow[0].ToString());
                ddAdicional.Items.Add(myItem);
            }
        }

        protected void GenerarRemitoTipoPropiedad(int lidCliente, string lFechaDesde, string lFechaHasta)
        {
            GestorPreciosApp gp = new GestorPreciosApp();
            lvTiposInformes.DataSource = gp.listarTiposInformesRemito(lidCliente, lFechaDesde, lFechaHasta);
            lvTiposInformes.DataBind();
        }

        protected void InformeDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListViewDataItem di = (ListViewDataItem)e.Item;
                DataRow row = ((DataRowView)di.DataItem).Row;
                int idTipoInfo=int.Parse(row.ItemArray[1].ToString());
                ListView lvInformes = (ListView)e.Item.FindControl("lvInformes");

                GestorPreciosApp gp = new GestorPreciosApp();
                lvInformes.DataSource = gp.listarInformesRemito(idTipoInfo, idCliente, FechaDesde, FechaHasta);
                lvInformes.DataBind();
            }
        }


        
        private void GenerarRemito()
        {
            UsuarioAutenticado Usuario = (UsuarioAutenticado)Session["UsuarioAutenticado"];
            int idCliente = int.Parse(hIdCliente.Value);
            int idUsuarioIntra = Usuario.IdUsuario;
            GestorPreciosApp gp = new GestorPreciosApp();
            int idRemito = gp.crearRemito(idCliente, idUsuarioIntra);
            int idTipoInforme = 0;
            int idEncabezado=0;
            int idAdicional = 0;
            decimal Precio=0;
            decimal PrecioUnitario = 0;
            int Cantidad = 0;
            ListView lvInf = null;

            foreach (ListViewDataItem lvTipos in lvTiposInformes.Items)
            {
                idTipoInforme = int.Parse(((HiddenField)lvTipos.FindControl("hdTipoInforme")).Value);
                lvInf = (ListView)lvTipos.FindControl("lvInformes");
                if (idTipoInforme != 0)
                {
                    foreach (ListViewDataItem lvInforme in lvInf.Items)
                    {
                        idEncabezado = int.Parse(((HiddenField)lvInforme.FindControl("hdIdEncabezado")).Value);
                        Precio = decimal.Parse(((TextBox)lvInforme.FindControl("txtPrecio")).Text, CultureInfo.InvariantCulture);
                        gp.agregarInformesRemito(idRemito, idTipoInforme, idEncabezado, Precio);
                    }
                }
            }

            string decimalSeparator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            string PrecioUnitario1 ="";


            foreach (ListViewDataItem lvAdicional in lvAdicionales.Items)
            {
                idAdicional = int.Parse(((HiddenField)lvAdicional.FindControl("hdIdAdicional")).Value);
                Cantidad = int.Parse(((TextBox)lvAdicional.FindControl("txtCantidad")).Text);
                PrecioUnitario1 = ((TextBox)lvAdicional.FindControl("txtPrecioUnitario")).Text;
                PrecioUnitario1 = PrecioUnitario1.Replace(",", decimalSeparator);
                PrecioUnitario = decimal.Parse(PrecioUnitario1, CultureInfo.InvariantCulture);
                gp.agregarAdicionalRemito(idRemito, idAdicional, Cantidad, PrecioUnitario);
            }
        }


        
        protected void btn_Click(object sender, EventArgs e)
        {
            int valor = int.Parse(ddAdicional.SelectedValue);
            AgregarAdicionales(valor);
        }
        protected void btnEnvio_Click(object sender, ImageClickEventArgs e)
        {
            AgregarAdicionales(2);
        }

        
        private void InicializarTablaAdicionales()
        {
            Session["Adicionales"] = null;
            dtAdicional = new DataTable();
            lvAdicionales.DataSource = dtAdicional;
            lvAdicionales.DataBind();

            DataColumn colInt32 = new DataColumn("idAdicional");
            colInt32.DataType = System.Type.GetType("System.Int32");
            dtAdicional.Columns.Add(colInt32);

            DataColumn colInt32_2 = new DataColumn("Cantidad");
            colInt32_2.DataType = System.Type.GetType("System.Int32");
            dtAdicional.Columns.Add(colInt32_2);

            DataColumn colString = new DataColumn("Adicional");
            colString.DataType = System.Type.GetType("System.String");
            dtAdicional.Columns.Add(colString);

            DataColumn colDecimal = new DataColumn("PrecioUnitario");
            colDecimal.DataType = System.Type.GetType("System.Decimal");
            dtAdicional.Columns.Add(colDecimal);

            DataColumn colDecimal2 = new DataColumn("Precio");
            colDecimal2.DataType = System.Type.GetType("System.Decimal");
            dtAdicional.Columns.Add(colDecimal2);

            Session["Adicionales"] = dtAdicional;
        }
        

        private void AgregarAdicionales(int idServicioAdicional)
        {
            DataRow dr;
            GestorPreciosApp gp = new GestorPreciosApp();

            dtAdicional = (DataTable)Session["Adicionales"];
            int cant = 1;
            float precioU = gp.obtenerPrecioAdicional(idServicioAdicional);

            if (AdicionalExistente(idServicioAdicional))
            {
                dr = dtAdicional.NewRow();
                dr["idAdicional"] = idServicioAdicional;
                dr["Cantidad"] = cant;
                dr["Adicional"] = gp.obtenerAdicional(idServicioAdicional);
                dr["PrecioUnitario"] = precioU;
                dr["Precio"] = precioU * cant;

                dtAdicional.Rows.Add(dr);
            }

            lvAdicionales.DataSource = dtAdicional;
            lvAdicionales.DataBind();
        }
        

        private bool AdicionalExistente(int idServicioAdicional)
        {
            ServAdicional = (int [])Session["ArrayAdicionales"];
            bool valido = true;
            if (ServAdicional[0] != 0)
            {
                for (int i = 0; i < ServAdicional.Length; i++)
                {
                    if (ServAdicional[i] == idServicioAdicional)
                        valido = false;
                }

                if (valido)
                {
                    for (int j = 0; j < ServAdicional.Length; j++)
                    {
                        if (ServAdicional[j] == 0)
                        {
                            ServAdicional[j] = idServicioAdicional;
                            break;
                        }
                    }
                }
            }
            else
                ServAdicional[0] = idServicioAdicional;
            return valido;
        }

        */

        protected void btnAceptar_Click1(object sender, EventArgs e)
        {
            int idTipo = int.Parse(Request.QueryString["idTipo"]);
            string cliente = "";
            //if (hIdCliente.Value != "")
                //cliente = "&idCliente=" + hIdCliente.Value;

            Response.Redirect("AbmRemitos.aspx?idTipo=" + idTipo + cliente);
        }

        protected void dgridRemitos_PreRender(object sender, EventArgs e)
        {
            int idTipo = int.Parse(Request.QueryString["idTipo"]);
            if (idTipo == 1)
                dgridRemitos.Columns[0].HeaderText = "Remito";
            else
                dgridRemitos.Columns[0].HeaderText = "Parte E.";

            foreach (DataGridItem myItem in dgridRemitos.Items)
            {
                try
                {
                    ((Label)myItem.FindControl("lblFecha")).Text = DateTime.Parse(myItem.Cells[1].Text).ToShortDateString() + " " + DateTime.Parse(myItem.Cells[1].Text).ToShortTimeString();
                }
                catch (Exception exc)
                { }
            }
        }

        protected void dgridRemitos_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            switch (((ImageButton)e.CommandSource).CommandName)
            {
                case "Ver":
                    Response.Redirect("VerRemitos.aspx?idTipo=" + tipoDocumentacion.Value + "&nroRemito=" + e.Item.Cells[0].Text + "&idCliente=" + hIdCliente.Value);
                    break;

                case "Editar":
                    Response.Redirect("AbmRemitos.aspx?idTipo=" + tipoDocumentacion.Value + "&id=" + e.Item.Cells[0].Text + "&idCliente=" + hIdCliente.Value);
                    break;
            }
        }


        private void setTipoCobranza(int idTipo)
        {
            if (idTipo == 1)
            {
                lblTipo.Text = "Remito";
                btnAceptar.Text = "Alta de remito";
            }
            else
            {
                lblTipo.Text = "Parte de entrega";
                btnAceptar.Text = "Alta de parte de entrega";
            }
        }
}
}