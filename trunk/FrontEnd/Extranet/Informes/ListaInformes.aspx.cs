using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;
using System.Globalization;

namespace ar.com.TiempoyGestion.FrontEnd.Extranet.Informes
{
    /// <summary>
    /// Summary description for ListaInformes.
    /// </summary>
    public partial class ListaInformes : Page
    {
        private int paginaActual = 1;
        private int IdUsuario = 1; //VALOR QUE SE OBTENDRA DEL CONTEXTO
        private bool blObtenerClienteMensual = false;
        private bool blHabilitarFinalizados = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            blObtenerClienteMensual = ObtenerClienteMensual();
            blHabilitarFinalizados = ObtenerHabilitarFinalizados();
            VerificarPrimerUsuarioLogueado();
            this.GetPostBackEventReference(this);
            paginaActual = int.Parse(hPagina.Value);
            // Put user code to initialize the page here
            if (!Page.IsPostBack)
            {
                ListaBandeja();
                ListaEstados();
                BandejaEntradaDal Tipos = new BandejaEntradaDal();
                cmbTipoInforme.Items.Clear();
                DataTable myTable = Tipos.TraerTiposInformes();
                cmbTipoInforme.Items.Add("Todos los Tipos de Informes");
                ListItem myItem;
                foreach (DataRow myRow in myTable.Rows)
                {
                    myItem = new ListItem(myRow[0].ToString(), myRow[1].ToString());
                    cmbTipoInforme.Items.Add(myItem);
                }
            }
        }

        #region Web Form Designer generated code
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: This call is required by the ASP.NET Web Form Designer.
            //
            InitializeComponent();
            UsuarioAutenticado Usuario = (UsuarioAutenticado)Session["UsuarioAutenticado"];
            IdUsuario = Usuario.IdUsuario;
            base.OnInit(e);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgridEncabezados.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgridEncabezados_ItemCommand);

        }
        #endregion

        protected void btnInforme_Click(object sender, EventArgs e)
        {
            Response.Redirect("altaInforme.aspx");
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            ListaBandejaFiltro();
        }

        protected void dgridEncabezados_PreRender(object sender, EventArgs e)
        {
            string strRedir = "";
            bool blInformePagado = false;
            DateTime FechaLimite = DateTime.Today.AddYears(-1);
            foreach (DataGridItem myItem in dgridEncabezados.Items)
            {
                ((ImageButton)myItem.FindControl("Pdf")).Visible = false;
                ((Label)myItem.FindControl("lblFecha")).Text = DateTime.Parse(myItem.Cells[1].Text).ToShortDateString() + " " + DateTime.Parse(myItem.Cells[1].Text).ToShortTimeString();
                //((ImageButton)myItem.FindControl("Editar")).Attributes.Add("src",@"/img/modificar_general.gif");
                //((ImageButton)myItem.FindControl("Editar")).ToolTip = "Modificar Informe";
                if (int.Parse(myItem.Cells[10].Text) == 6) myItem.Cells[7].Text = "<IMG SRC='/img/Estado2.gif' widht='14' height='14' border='0'>&nbsp;&nbsp;&nbsp;En Proceso";
                else myItem.Cells[7].Text = "<IMG SRC='/img/Estado" + myItem.Cells[10].Text + ".gif' widht='14' height='14' border='0'>&nbsp;&nbsp;&nbsp;" + myItem.Cells[6].Text;
                if (int.Parse(myItem.Cells[10].Text) == 1 || int.Parse(myItem.Cells[10].Text) == 5) // || int.Parse(myItem.Cells[10].Text) == 9 se quita
                {
                    ((ImageButton)myItem.FindControl("Editar")).Visible = true;
                    ((ImageButton)myItem.FindControl("Cancelar")).Attributes.Add("onclick", @"javascript: return confirm('¿Está seguro que desea Cancelar el Informe?');");
                }
                else
                {
                    ((ImageButton)myItem.FindControl("Editar")).Visible = false;
                    ((ImageButton)myItem.FindControl("Cancelar")).Attributes.Add("src", @"/img/reloj.jpg");
                    ((ImageButton)myItem.FindControl("Cancelar")).ToolTip = "Ver Historial";
                }
                if (myItem.Cells[10].Text == "3")
                {
                    ((ImageButton)myItem.FindControl("Ver")).Attributes.Add("src", @"/img/printer.gif");

                    switch (myItem.Cells[12].Text)
                    {
                        case "1": //Realizar Informe de Propiedad
                            strRedir = "/InformePropiedad/VerInforme.aspx?id=" + myItem.Cells[0].Text + "&IdTipo=1";
                            break;
                        case "2": //Ver Informe de Automotores
                            strRedir = "/Automotores/VerInforme.aspx?id=" + myItem.Cells[0].Text + "&IdTipo=2";
                            break;
                        case "3": //Gravamenes
                            switch (myItem.Cells[13].Text)
                            {
                                case "1": //Hipoteca
                                    strRedir = "/Hipoteca/VerInforme.aspx?id=" + myItem.Cells[0].Text + "&IdTipo=3";
                                    break;
                                case "2": //Usufructo
                                    strRedir = "/Usufructo/VerInforme.aspx?id=" + myItem.Cells[0].Text + "&IdTipo=3";
                                    break;
                                case "3": //Inhibición
                                    strRedir = "/Inhibicion/VerInforme.aspx?id=" + myItem.Cells[0].Text + "&IdTipo=3";
                                    break;
                                case "4": //Embargo
                                    strRedir = "/Embargo/VerInforme.aspx?id=" + myItem.Cells[0].Text + "&IdTipo=3";
                                    break;
                                case "5": //Bien de Familia
                                    strRedir = "/BienFamilia/VerInforme.aspx?id=" + myItem.Cells[0].Text + "&IdTipo=3";
                                    break;
                            }
                            break;
                        case "4": //Socio Ambiental
                            //								Response.Redirect("/verifDomParticular/VerInforme.aspx?id="+ e.Item.Cells[0].Text + "&IdTipo=5");
                            strRedir = "/socioAmbiental/VerInforme.aspx?id=" + myItem.Cells[0].Text + "&IdTipo=4";
                            break;
                        case "5": //Realizar Verificacion de domicilio particular
                            //								Response.Redirect("/verifDomParticular/VerInforme.aspx?id="+ e.Item.Cells[0].Text + "&IdTipo=5");
                            strRedir = "/verifDomParticular/VerInforme.aspx?id=" + myItem.Cells[0].Text + "&IdTipo=5";
                            break;
                        case "6": //Realizar Verificacion de domicilio laboral
                            //								Response.Redirect("/verifDomLaboral/VerInforme.aspx?id="+ e.Item.Cells[0].Text + "&IdTipo=6");
                            strRedir = "/verifDomLaboral/VerInforme.aspx?id=" + myItem.Cells[0].Text + "&IdTipo=6";
                            break;
                        case "7": //Realizar Verificacion de domicilio comercial
                            //								Response.Redirect("/verifDomComercial/VerInforme.aspx?id="+ e.Item.Cells[0].Text + "&IdTipo=7");
                            strRedir = "/verifDomComercial/VerInforme.aspx?id=" + myItem.Cells[0].Text + "&IdTipo=7";
                            break;
                        case "10": //Busqueda de Automotores
                            strRedir = "/BusquedaAutomotor/VerInforme.aspx?id=" + myItem.Cells[0].Text + "&IdTipo=10";
                            break;
                        case "11": //Realizar Informe de Propiedad otras Provincias
                            strRedir = "/InformePropiedadProvincias/VerInforme.aspx?id=" + myItem.Cells[0].Text + "&IdTipo=11";
                            break;
                        case "12": //Catastral
                            strRedir = "/Catastral/VerInforme.aspx?id=" + myItem.Cells[0].Text + "&IdTipo=12";
                            break;
                        case "13": //Busqueda de Propiedades
                            strRedir = "/BusquedaPropiedad/VerInforme.aspx?id=" + myItem.Cells[0].Text + "&IdTipo=13";
                            break;
                        case "14": //Realizar Verificacion de Contrato
                            strRedir = "/verifContrato/VerInforme.aspx?id=" + myItem.Cells[0].Text + "&IdTipo=14";
                            break;
                        case "15": //Realizar Relevamiento Ambiental BANCOR
                            strRedir = "/ambientalBancor/VerInforme.aspx?id=" + myItem.Cells[0].Text + "&IdTipo=15";
                            break;
                        case "16": //Realizar Informe de Inhibición
                            strRedir = "/Inhibicion/VerInforme.aspx?id=" + myItem.Cells[0].Text + "&IdTipo=16";
                            break;
                        case "17":
                            //((ImageButton)myItem.FindControl("Realizar")).Attributes.Add("onclick", "cambioEstado(17, " + myItem.Cells[0].Text  + ")");
                            strRedir = "/Morosidad/VerInforme.aspx?id=" + myItem.Cells[0].Text + "&IdTipo=17";
                            break;
                        case "18": //Realizar Informe de Gravámenes DIR
                            strRedir = "/gravamenesDIR/VerInforme.aspx?id=" + myItem.Cells[0].Text + "&IdTipo=18";
                            break;
                        case "19": //Realizar Verificacion de Defunción
                            strRedir = "/verifDefuncion/VerInforme.aspx?id=" + myItem.Cells[0].Text + "&IdTipo=19";
                            break;
                        case "20": //Realizar Informe de Partidas de Defunción
                            //((ImageButton)myItem.FindControl("Realizar")).Attributes.Add("onclick", "cambioEstado(20, " + myItem.Cells[0].Text  + ")");
                            break;
                        case "21": //Realizar Relevamiento Ambiental BANCOR
                            strRedir = "/InspeccionAmbientalBancor/VerInforme.aspx?id=" + myItem.Cells[0].Text + "&IdTipo=21";
                            break;

                    }

                    //Verifica si el informe esta pagado o no
                    if (myItem.Cells[14].Text == "1")
                        blInformePagado = true;
                    else
                        blInformePagado = false;

                    // Se habilita la opcion de imprimir informe si reune 2 condiciones:
                    // 1- Es cliente mensual; 2- Es cliente diarios y está abonado el informe; 3- Si el informe esta pagado
                    if (strRedir != "" && (blObtenerClienteMensual || blHabilitarFinalizados || blInformePagado))
                    {
                        if (myItem.Cells[12].Text == "1" || myItem.Cells[12].Text == "4" || myItem.Cells[12].Text == "5" || myItem.Cells[12].Text == "6" || myItem.Cells[12].Text == "7" || myItem.Cells[12].Text == "12" || myItem.Cells[12].Text == "13" || myItem.Cells[12].Text == "21")
                            ((ImageButton)myItem.FindControl("Ver")).Attributes.Add("onclick", "javascript: window.open('" + strRedir + "','','tools=no,width=720,scrollbars=yes,menus=no'); return false;");


                        //Se filtran los informes de inhibicion, propiedad y morosidad (pdf), en estado finalizado, fecha limite 1 mes a la fecha actual
                        if ((myItem.Cells[12].Text == "1" || myItem.Cells[12].Text == "2" || myItem.Cells[12].Text == "10" || myItem.Cells[12].Text == "12" || myItem.Cells[12].Text == "13" || myItem.Cells[12].Text == "16" || myItem.Cells[12].Text == "17") && myItem.Cells[10].Text == "3" && (DateTime.Parse(myItem.Cells[1].Text) >= FechaLimite) && myItem.Cells[16].Text != "&nbsp;")
                        {
                            ((ImageButton)myItem.FindControl("Pdf")).Visible = true;
                            ((ImageButton)myItem.FindControl("Pdf")).Attributes.Add("onclick", "javascript: window.open('" + myItem.Cells[16].Text + "','','tools=no,width=720,scrollbars=yes,menus=no'); return false;");
                        }
                    }
                }
            }
        }

        private void dgridEncabezados_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.Item.Cells[0].Text != "")
            {
                switch (((ImageButton)e.CommandSource).CommandName)
                {
                    case "Cancelar":
                        int IdCodigo = int.Parse(e.Item.Cells[0].Text);
                        if (int.Parse(e.Item.Cells[10].Text) == 1 || int.Parse(e.Item.Cells[10].Text) == 5)
                        {
                            CancelarEncabezado(IdCodigo);
                            Response.Redirect("ListaInformes.aspx");
                        }
                        else
                        {
                            Response.Redirect("VerHistorial.aspx?id=" + e.Item.Cells[0].Text);
                        }
                        break;

                    case "Editar":
                        if (int.Parse(e.Item.Cells[10].Text) == 1 || int.Parse(e.Item.Cells[10].Text) == 5 || int.Parse(e.Item.Cells[10].Text) == 9)
                        {
                            Response.Redirect("abmInforme.aspx?id=" + e.Item.Cells[0].Text);
                        }
                        break;
                    case "Ver":
                        //if (e.Item.Cells[10].Text != "3")	
                        Response.Redirect("VerInforme.aspx?id=" + e.Item.Cells[0].Text + "&IdTipo=" + Request.QueryString["idTipo"]);
                        break;
                }
            }
        }

        private void CancelarEncabezado(int idEncabezado)
        {
            EncabezadoApp Encabezado = new EncabezadoApp();
            Encabezado.cargarEncabezado(idEncabezado);

            Encabezado.Cancelar(idEncabezado, true);
        }

        private void ListaBandeja()
        {
            DateTimeFormatInfo fmt = (new CultureInfo("es-AR")).DateTimeFormat;

            string FechaDesde = DateTime.Today.AddYears(-1).ToShortDateString();
            string FechaHasta = DateTime.Today.ToShortDateString();
            
            //lblFechaActual.Text = "Córdoba, " + DateTime.Now.ToString("d MMMM yyyy", fmt);

            hTipoBusqueda.Value = "0";
            //string FechaDesde = "";
            //string FechaHasta = "";
            int idUser = -1;
            if (chkSoloMias.Checked) idUser = IdUsuario;
            if (txtFechaInicio.Text == "")
            {
                txtFechaInicio.Text = DateTime.Today.AddMonths(-3).ToShortDateString();
                FechaDesde = txtFechaInicio.Text;
            }
            if (txtFechaFinal.Text == "")
            {
                txtFechaFinal.Text = DateTime.Today.ToShortDateString();
                FechaHasta = txtFechaFinal.Text;
            }

            // Usuario Logueado
            UsuarioAutenticado Usuario = (UsuarioAutenticado)Session["UsuarioAutenticado"];
            BandejaEntradaApp bandeja = new BandejaEntradaApp();
            bandeja.RegPorPagina = 10;
            bandeja.Pagina = paginaActual;
            dgridEncabezados.DataSource = bandeja.ListaEncabezados(-1, "", Usuario.IdCliente, idUser, "-1", -1, FechaDesde, FechaHasta, 0, true);
            dgridEncabezados.DataBind();
            litPaginador.Text = bandeja.GetPaginador(10);
        }


        private void ListaBandejaFiltro()
        {
            UsuarioAutenticado Usuario = (UsuarioAutenticado)(Session["UsuarioAutenticado"]);
            int idCliente = Usuario.IdCliente;
            hTipoBusqueda.Value = "1";
            int idTipoInforme;
            string idEstado;
            int idUser = -1;
            if (chkSoloMias.Checked) idUser = IdUsuario;

            string FechaDesde = "";
            if (txtFechaInicio.Text != "")
                FechaDesde = txtFechaInicio.Text;
            string FechaHasta = "";
            if (txtFechaFinal.Text != "")
                FechaHasta = txtFechaFinal.Text;
            string pFiltro = TxtContengan.Text;
            if (cmbTipoInforme.SelectedValue == "Todos los Tipos de Informes") idTipoInforme = -1;
            else idTipoInforme = int.Parse(cmbTipoInforme.SelectedValue);
            if (cmbEstados.SelectedValue == "Todos los Estados") idEstado = "-1";
            else idEstado = cmbEstados.SelectedValue;

            BandejaEntradaApp bandeja = new BandejaEntradaApp();
            bandeja.RegPorPagina = 10;
            bandeja.Pagina = paginaActual;
            dgridEncabezados.DataSource = bandeja.ListaEncabezados(idTipoInforme, pFiltro, idCliente, idUser, idEstado, -1, FechaDesde, FechaHasta, 0, true);
            dgridEncabezados.DataBind();
            litPaginador.Text = bandeja.GetPaginador(10);
        }


        private void ListaEstados()
        {
            EncabezadoApp Estados = new EncabezadoApp();
            cmbEstados.Items.Clear();
            DataTable myTable = Estados.TraerEstados(false);
            cmbEstados.Items.Add("Todos los Estados");
            ListItem myItem;
            foreach (DataRow myRow in myTable.Rows)
            {
                myItem = new ListItem(myRow[1].ToString(), myRow[0].ToString());
                cmbEstados.Items.Add(myItem);
            }
        }

        protected void dgridEncabezados_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void hPagina_ValueChanged(object sender, EventArgs e)
        {
            paginaActual = int.Parse(hPagina.Value);
            if (hTipoBusqueda.Value == "1")
                ListaBandejaFiltro();
            else
                ListaBandeja();
        }


        private void VerificarPrimerUsuarioLogueado()
        {
            DateTime fechaUltimoIngreso = new DateTime();
            // Put user code to initialize the page here
            UsuarioAutenticado Usuario = (UsuarioAutenticado)Context.User;
            if (Session["UsuarioAutenticado"] != null)
            {
                Session["fechaUltimoIngreso"] = Usuario.UltimoIngreso;
                fechaUltimoIngreso = (DateTime)Session["fechaUltimoIngreso"];
            }

            if (fechaUltimoIngreso.ToShortDateString() == ("01/01/1900").ToString()) //Al ser la primera vez que ingresa al sistema, se activa el saludo de bienvenida y carga de datos de usuario/empresa
                Response.Redirect("/Admin/Clientes/AbmUsuario.aspx");
        }

        private bool ObtenerClienteMensual()
        {
            bool esMensual = false;
            // Put user code to initialize the page here
            UsuarioAutenticado Usuario = (UsuarioAutenticado)Context.User;

            if (Usuario.TipoPeriodo != null)
            {
                if (Usuario.TipoPeriodo == 2)
                    esMensual = true;
            }

            return esMensual;

        }

        private bool ObtenerHabilitarFinalizados()
        {
            bool esHabilitado = false;
            // Put user code to initialize the page here
            UsuarioAutenticado Usuario = (UsuarioAutenticado)Context.User;


            if (Usuario.HabilitarFinalizados != null)
            {
                if (Usuario.HabilitarFinalizados == 1)
                    esHabilitado = true;
            }

            return esHabilitado;

        }
        
    }
}
