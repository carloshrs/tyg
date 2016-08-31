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
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.Admin.Cuentas
{
    public partial class Admin_Cuentas_remitos : System.Web.UI.Page
    {
        string FechaDesde = "";
        string FechaHasta = "";
        int idCliente = 0;
        int nroRemito = 0;
        int idTipoDocumentacion = 0;
        DataTable dtAdicional = null;
        int [] ServAdicional = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                //idTipoDocumentacion = int.Parse(Request.QueryString["idTipo"]);
                //tipoDocumentacion.Value = Request.QueryString["idTipo"];
                //setTipoDocumentacion(idTipoDocumentacion);
                if (Request.QueryString["idTipo"] != null && Request.QueryString["idTipo"] != "")
                    tipoDocumentacion.Value = Request.QueryString["idTipo"];
                else
                    tipoDocumentacion.Value = raTipoDocumento.SelectedValue;

                Session["ArrayAdicionales"] = new int[30];
                //pnCliente.Visible = false;
                pnAdicionales.Visible = false;
                pnRemito.Visible = false;

                if (txtFechaInicio.Text == "")
                    txtFechaInicio.Text = DateTime.Today.AddDays(-15).ToShortDateString();
                if (txtFechaFinal.Text == "")
                    txtFechaFinal.Text = DateTime.Today.ToShortDateString();

                cargarCliente();

                if (Request.QueryString["id"] != null)
                {
                    Panel1TipoDoc.Visible = true;
                    pnlTipoDocumento.Visible = true;
                    pnlTipoPeriodo.Visible = true;
                    pnListadoInformes.Visible = true;
                    //btnAceptar.Visible = false;
                    hNroRemito.Value = Request.QueryString["id"];
                    hIdCliente.Value = Request.QueryString["idCliente"];
                    nroRemito = int.Parse(hNroRemito.Value);
                    ClienteDal oCargarCliente = new ClienteDal();
                    oCargarCliente.Cargar(int.Parse(hIdCliente.Value));
                    txtCliente.Text = oCargarCliente.NombreFantasia;
                    txtCliente.ReadOnly = true;

                    GestorPrecios cargarRemito = new GestorPrecios();
                    cargarRemito.cargarRemitoParte(int.Parse(tipoDocumentacion.Value), nroRemito);

                    if (int.Parse(tipoDocumentacion.Value) != 0)
                    {
                        if (int.Parse(tipoDocumentacion.Value) == 1)
                            raTipoDocumento.SelectedIndex = 0;
                        else
                            raTipoDocumento.SelectedIndex = 1;
                    }

                    if (cargarRemito.TipoPeriodo != 0)
                    {
                        if (cargarRemito.TipoPeriodo == 1)
                            raTipoPeriodo.SelectedIndex = 0;
                        else
                            raTipoPeriodo.SelectedIndex = 1;
                    }

                    ActualizarListadoInformes(int.Parse(tipoDocumentacion.Value), nroRemito);
                    CargarRemitoTipoPropiedad(int.Parse(hIdCliente.Value), txtFechaInicio.Text, txtFechaFinal.Text, int.Parse(tipoDocumentacion.Value), nroRemito);
                    InicializarTablaAdicionales();
                    CargarAdicionales(int.Parse(tipoDocumentacion.Value), nroRemito);
                }
                else
                    resultadoBusqueda();
                ListaAdicionales();
            }
            else
            {
                if ((Request.Params["__EVENTTARGET"]) == "ctl00$DeleteManager")
                {
                    if (Request.Params["__EVENTARGUMENT"] != "")
                    {
                        if (hNroRemito.Value != "")
                            nroRemito = int.Parse(hNroRemito.Value);
                        else
                            nroRemito = 0;
                        //
                        EliminarItemRemito(int.Parse(tipoDocumentacion.Value), nroRemito, Request.Params["__EVENTARGUMENT"]);
                    }
                            
                }
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            resultadoBusqueda();
        }


        private void resultadoBusqueda() 
        {
            if (hIdCliente.Value != "" && txtFechaInicio.Text != "" && txtFechaFinal.Text != "")
            {
                InicializarTablaAdicionales();
                //int.Parse(tipoDocumentacion.Value)
                ActualizarListadoInformes(1, nroRemito);
                CargarRemitoTipoPropiedad(int.Parse(hIdCliente.Value), txtFechaInicio.Text, txtFechaFinal.Text);
            }
        }

        protected void dgridEncabezados_PreRender(object sender, EventArgs e)
        {
            
            foreach (DataGridItem myItem in dgridEncabezados.Items)
			{
                ((Label)myItem.FindControl("lblFecha")).Text = DateTime.Parse(myItem.Cells[1].Text).ToShortDateString() + " " + DateTime.Parse(myItem.Cells[1].Text).ToShortTimeString();
            }
            /*
            addServicio
             */ 
        }


        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("remitos.aspx?idCliente=" + hIdCliente.Value);
        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            int idRemito = GenerarRemito();
            Response.Redirect("VerRemitos.aspx?idCliente=" + hIdCliente.Value + "&nroRemito=" + idRemito + "&idTipo=" + raTipoDocumento.Text);
        }

        private void ActualizarListadoInformes(int tipoDocumentacion, int nroRemito)
        {
            //pnlTipoDocumento.Visible = false;
            //pnlTipoPeriodo.Visible = false;
            pnListadoInformes.Visible = false;
            pnCliente.Visible = true;
            pnAdicionales.Visible = true;
            pnRemito.Visible = true;
            int idUser = -1;
            idCliente = int.Parse(hIdCliente.Value);
            lblCliente.Text = txtCliente.Text;

            ClienteDal oCliente = new ClienteDal();
            oCliente.Cargar(idCliente);
            //lblDireccion.Text = oCliente.Calle + " " + oCliente.Numero;
            //if (oCliente.IdLocalidad != 1)
            //    lblDireccion.Text = lblDireccion.Text + " - Localidad: " + CargarLocalidades(oCliente.IdProvincia, oCliente.IdLocalidad);

            if (txtFechaInicio.Text == "")
                txtFechaInicio.Text = DateTime.Today.AddDays(-5).ToShortDateString();
            FechaDesde = txtFechaInicio.Text;

            if (txtFechaFinal.Text == "")
                txtFechaFinal.Text = DateTime.Today.ToShortDateString();
            FechaHasta = txtFechaFinal.Text;

            BandejaEntradaApp bandeja = new BandejaEntradaApp();
            bandeja.RegPorPagina = 100;
            bandeja.Pagina = 1;
            dgridEncabezados.DataSource = bandeja.ListaEncabezados(idCliente, idUser, "3", FechaDesde, FechaHasta, 0, 1);
            dgridEncabezados.DataBind();

        }

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

        protected void CargarRemitoTipoPropiedad(int lidCliente, string lFechaDesde, string lFechaHasta)
        {
            GestorPreciosApp gp = new GestorPreciosApp();
            lvTiposInformes.DataSource = gp.listarTiposInformesRemito(lidCliente, lFechaDesde, lFechaHasta);
            lvTiposInformes.DataBind();
        }

        protected void CargarRemitoTipoPropiedad(int lidCliente, string lFechaDesde, string lFechaHasta, int lTipoDocumentacion, int lNroRemito)
        {
            GestorPreciosApp gp = new GestorPreciosApp();
            lvTiposInformes.DataSource = gp.listarTiposInformesRemito(lidCliente, lFechaDesde, lFechaHasta, lTipoDocumentacion, lNroRemito);
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
                if (Request.QueryString["idTipo"] != null && Request.QueryString["idTipo"] != "")
                    tipoDocumentacion.Value = Request.QueryString["idTipo"];
                else
                    tipoDocumentacion.Value = raTipoDocumento.SelectedValue;

                int idTipoDocumentacion = 0;
                if(tipoDocumentacion.Value != "")
                    idTipoDocumentacion = int.Parse(tipoDocumentacion.Value);
                //int idTipoDocumentacion = 1;

                if (nroRemito != 0)
                    lvInformes.DataSource = gp.listarInformesRemitoParteEntrega(idTipoDocumentacion, nroRemito, idTipoInfo);
                else
                    lvInformes.DataSource = gp.listarInformesRemitoParteEntrega(idTipoDocumentacion, idTipoInfo, idCliente, FechaDesde, FechaHasta);
                lvInformes.DataBind();

                if (nroRemito != 0)
                {
                    foreach (ListViewItem myItem1 in lvInformes.Items)
                    {
                        //chkIdEncabezado
                        ((CheckBox)myItem1.FindControl("chkIdEncabezado")).Checked = true;// DateTime.Parse(myItem.Cells[1].Text).ToShortDateString() + " " + DateTime.Parse(myItem.Cells[1].Text).ToShortTimeString();
                        ((CheckBox)myItem1.FindControl("chkIdEncabezado")).Enabled = false;
                    }
                }
            }
        }


        private void EliminarItemRemito(int idTipoDocumentacion, int nroRemito, string item)
        {
            UsuarioAutenticado Usuario = (UsuarioAutenticado)Session["UsuarioAutenticado"];
            string[] DelItem = item.Split('_');
            GestorPreciosApp gp = new GestorPreciosApp();
            if (DelItem[0] == "Delinf")
            {
                if (nroRemito != 0)
                    gp.eliminarInformeRemito(idTipoDocumentacion, nroRemito, int.Parse(DelItem[1].ToString()));
                //else
                    //ClientScript.RegisterClientScriptBlock(this.GetType(), "eliminar", "<script>eliminarFilaInforme(" + DelItem[1] + ")</script>");
            }
            if (DelItem[0] == "Deladi")
            {
                if (nroRemito != 0)
                    gp.eliminarAdicionalRemito(idTipoDocumentacion, nroRemito, int.Parse(DelItem[1].ToString()));
                //else

            }
            //idTipo=" + idTipoDocumentacion + "&
            gp.setearMontoRemito(nroRemito, idTipoDocumentacion, 1);
            Response.Redirect("AbmRemitos.aspx?id=" + nroRemito + "&idTipo=" + idTipoDocumentacion + "&idCliente=" + hIdCliente.Value);
        }

        private int GenerarRemito()
        {
            UsuarioAutenticado Usuario = (UsuarioAutenticado)Session["UsuarioAutenticado"];
            GestorPreciosApp gp = new GestorPreciosApp();

            int idCliente = int.Parse(hIdCliente.Value);
            int idUsuarioIntra = Usuario.IdUsuario;
            int idtipoCobranza = int.Parse(raTipoPeriodo.Text);
            idTipoDocumentacion = int.Parse(raTipoDocumento.Text); // int.Parse(tipoDocumentacion.Value);
            if (hNroRemito.Value != "")
                nroRemito = int.Parse(hNroRemito.Value);
            
            int idRemito =  0;
            int idTipoInforme = 0;
            int idEncabezado = 0;
            int idAdicional = 0;
            decimal Precio = 0;
            decimal PrecioUnitario = 0;
            int Cantidad = 0;

            //Si no tiene seteado el Tipo de documento (remito o parte) o periodo (diario o mensual)
            ClienteDal oCargarCliente = new ClienteDal();
            oCargarCliente.Cargar(int.Parse(hIdCliente.Value));
            if (oCargarCliente.TipoDocumento == 0 || oCargarCliente.TipoPeriodo == 0)
            {
                oCargarCliente.TipoDocumento = idTipoDocumentacion;
                oCargarCliente.TipoPeriodo = idtipoCobranza;
                oCargarCliente.Modificar();
            }

            if (nroRemito == 0)
                idRemito = gp.crearRemitoParte(idTipoDocumentacion, idtipoCobranza, idCliente, idUsuarioIntra);
            else
            {
                gp.modificarRemitoParte(idTipoDocumentacion, idtipoCobranza, nroRemito);
                idRemito = nroRemito;
            }

            
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
                        if (((CheckBox)lvInforme.FindControl("chkIdEncabezado")).Checked)
                        {
                            Precio = decimal.Parse(((TextBox)lvInforme.FindControl("txtPrecio")).Text, CultureInfo.InvariantCulture);
                            if(nroRemito ==0)
                                gp.agregarInformesRemitoParte(idTipoDocumentacion, idRemito, idTipoInforme, idEncabezado, Precio);
                            else
                                gp.modificarInformesRemitoParte(idTipoDocumentacion, idRemito, idTipoInforme, idEncabezado, Precio);

                        }
                    }
                }
            }

            string decimalSeparator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            string PrecioUnitario1 ="";

            if (nroRemito != 0)
                gp.eliminarTodosAdicionalesRemitosParteEntrega(idTipoDocumentacion, idRemito);

            foreach (ListViewDataItem lvAdicional in lvAdicionales.Items)
            {
                idAdicional = int.Parse(((HiddenField)lvAdicional.FindControl("hdIdAdicional")).Value);
                Cantidad = int.Parse(((TextBox)lvAdicional.FindControl("txtCantidad")).Text);
                PrecioUnitario1 = ((TextBox)lvAdicional.FindControl("txtPrecioUnitario")).Text;
                PrecioUnitario1 = PrecioUnitario1.Replace(",", decimalSeparator);
                PrecioUnitario = decimal.Parse(PrecioUnitario1, CultureInfo.InvariantCulture);
                gp.agregarAdicionalRemito(idTipoDocumentacion, idRemito, idAdicional, Cantidad, PrecioUnitario);
            }

            gp.setearMontoRemito(idRemito, idTipoDocumentacion, 1);

            return idRemito;
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


        private void CargarAdicionales(int tipoDocumentacion, int nroRemito)
        {
            GestorPreciosApp gp = new GestorPreciosApp();

            dtAdicional = gp.ListarAdicionalesRemito(tipoDocumentacion, nroRemito);
            Session["Adicionales"] = dtAdicional;

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

        private void setTipoDocumentacion(int idTipoDocumentacion)
        {
            if (idTipoDocumentacion == 1)
            {
                lblTipo.Text = "Remito";
                btnAceptar.Text = "Finalizar remito";
            }
            else
            {
                lblTipo.Text = "Parte de entrega";
                btnAceptar.Text = "Finalizar parte de entrega";
            }
        }



        private void cargarCliente()
        {
            ClienteDal nCargarCliente = new ClienteDal();
            hIdCliente.Value = Request.QueryString["idCliente"];
            nCargarCliente.Cargar(int.Parse(hIdCliente.Value));
            lblCliente.Text = nCargarCliente.NombreFantasia;
            txtCliente.Text = nCargarCliente.NombreFantasia;
            txtCliente.ReadOnly = true;
            lblDireccion.Text = nCargarCliente.Calle + " " + nCargarCliente.Numero + ", " + CargarLocalidades(nCargarCliente.IdProvincia, nCargarCliente.IdLocalidad) + ".";
            //txtCliente.ReadOnly = true;
            if (nCargarCliente.TipoDocumento != null)
                raTipoDocumento.SelectedIndex = nCargarCliente.TipoDocumento - 1;

            if (nCargarCliente.TipoPeriodo != null)
                raTipoPeriodo.SelectedIndex = nCargarCliente.TipoPeriodo - 1;
        
        }


        private String CargarLocalidades(int idProvincia, int IdLocalidad)
        {
            UtilesApp Tipos = new UtilesApp();
            DataTable myTb;
            string Localidad = "";
            myTb = Tipos.TraerLocalidades(idProvincia);
            foreach (DataRow myRow in myTb.Rows)
            {
                if (IdLocalidad.ToString() == myRow[0].ToString())
                {
                    Localidad = myRow[1].ToString();
                }
            }
            return Localidad;
        }
    }
}