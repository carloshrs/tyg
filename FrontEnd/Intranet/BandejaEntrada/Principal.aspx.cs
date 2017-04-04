using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.Clientes.Dal;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.BandejaEntrada
{
	/// <summary>
	/// Summary description for Principal.
	/// </summary>
	public partial class Principal : Page
	{
		private int IdTipo;
		protected Button Button1;
		private int IdUsuario = 1; //VALOR QUE SE OBTENDRA DEL CONTEXTO
        private int paginaActual = 1;
        //protected int tipoBusqueda = 0;
        protected bool bsqRapida = false;

		protected void Page_Load(object sender, EventArgs e)
		{
            this.GetPostBackEventReference(this);
            paginaActual = int.Parse(hPagina.Value);
            if (!Page.IsPostBack)
            {
                ListaBandeja();
            }
		}

		#region Web Form Designer generated code

		protected override void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
            if (Request.QueryString["bsqrapida"] != null) bsqRapida = true;

			if (Request.QueryString["IdTipo"] != null) IdTipo = int.Parse(Request.QueryString["IdTipo"]);
			else IdTipo = -1;

            if (IdTipo == 1) btnPropiedadRegistro.Visible = true;
            if (IdTipo == 6 || IdTipo == 17) btnImprimir.Visible = true;
			
			UsuarioAutenticado Usuario = (UsuarioAutenticado) Session["UsuarioAutenticado"];
			IdUsuario = Usuario.IdUsuario;

            if (bsqRapida)
            {
                btnInforme.Visible = false;
                btnFiltro.Visible = false;
            }
			ListaClientes();
            ListaEstados();
            ListaInformes(IdTipo);
            EnviarRegistro(IdTipo);

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

		private void ListaBandeja()
		{
            hTipoBusqueda.Value = "0";
            int idUser = -1;
			string pFiltro = txtContengan.Text;
            string FechaDesde = "";
            string FechaHasta = "";
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

            BandejaEntradaApp bandeja = new BandejaEntradaApp();
            bandeja.RegPorPagina = 10;
            bandeja.Pagina = paginaActual;
            if (!bsqRapida)
            {
                dgridEncabezados.DataSource = bandeja.ListaEncabezados(IdTipo, pFiltro, -1, idUser, "-1", -1, FechaDesde, FechaHasta, 0, false);
                dgridEncabezados.DataBind();

                litPaginador.Text = bandeja.GetPaginador(10);
            }
            else
                litPaginador.Text = "<b><i>Ingrese criterio de búsqueda</i></b>";
            
			PonerTitulo(IdTipo);
		}

		private void ListaClientes()
		{
			ClienteDal Clientes = new ClienteDal();
			cmbClientes.Items.Clear();
			DataTable myTable = Clientes.CargarDatos();
			cmbClientes.Items.Add("Todos los Clientes");
			ListItem myItem;
            string nombreEmpresa = "";
			foreach (DataRow myRow in myTable.Rows)
			{
                if (myRow[2].ToString() != "")
                {
                    nombreEmpresa = myRow[2].ToString();
                    if (myRow[3].ToString() != "")
                        nombreEmpresa = nombreEmpresa + " (" + myRow[3].ToString() + ")";
                }
                else
                    nombreEmpresa = myRow[1].ToString();

                myItem = new ListItem(nombreEmpresa.Trim(), myRow[0].ToString());
				cmbClientes.Items.Add(myItem);
			}
		}

		private void ListaEstados()
		{
			EncabezadoApp Estados = new EncabezadoApp();
			cmbEstados.Items.Clear();
			DataTable myTable = Estados.TraerEstados(true);
			cmbEstados.Items.Add("Todos los Estados");
			ListItem myItem;
			foreach (DataRow myRow in myTable.Rows)
			{
				myItem = new ListItem(myRow[1].ToString(), myRow[0].ToString());
				cmbEstados.Items.Add(myItem);
			}
		}

        private void ListaInformes(int idTipo)
		{
			BandejaEntradaDal Tipos = new BandejaEntradaDal();
			cmbTipoInforme.Items.Clear();
			DataTable myTable = Tipos.TraerTiposInformes();
			cmbTipoInforme.Items.Add("Todos los Tipos de Informes");
			ListItem myItem;
			foreach (DataRow myRow in myTable.Rows)
			{
				myItem = new ListItem(myRow[0].ToString(), myRow[1].ToString());
				cmbTipoInforme.Items.Add(myItem);
                if (idTipo == int.Parse(myRow[1].ToString()))
                {
                    cmbTipoInforme.SelectedIndex = -1;
                    myItem.Selected = true;
                }
			}
		}

		protected void btnFiltro_Click(object sender, EventArgs e)
		{
            paginaActual = 1;
            ListaBandejaFiltro();
		}

        private void ListaBandejaFiltro()
        {
            hTipoBusqueda.Value = "1";
            int idUser = -1;
            string pFiltro = txtContengan.Text.Replace("'", "''");
            if (chkSoloMias.Checked) idUser = IdUsuario;
            int idCliente = -1;
            string Estado = "-1";
            int IdTipoInforme = -1;
            int Caracter = -1;
            if (cmbClientes.SelectedValue != "Todos los Clientes") idCliente = int.Parse(cmbClientes.SelectedValue);
            if (cmbEstados.SelectedValue != "Todos los Estados") Estado = cmbEstados.SelectedValue;
            if (cmbTipoInforme.SelectedValue != "Todos los Tipos de Informes") IdTipoInforme = int.Parse(cmbTipoInforme.SelectedValue);
            String FechaDesde = "";
            string[] faux;
            if (txtFechaInicio.Text != "")
            {
                //faux = txtFechaInicio.Text.Split("/".ToCharArray());
                //FechaDesde = faux[2] + "/" + faux[1] + "/" + faux[0];
                FechaDesde = txtFechaInicio.Text;
            }
            String FechaHasta = "";
            if (txtFechaFinal.Text != "")
            {
                //faux = txtFechaFinal.Text.Split("/".ToCharArray());
                //FechaHasta = faux[2] + "/" + faux[1] + "/" + faux[0];
                FechaHasta = txtFechaFinal.Text;
            }
            BandejaEntradaApp bandeja = new BandejaEntradaApp();
            bandeja.RegPorPagina = 10;
            bandeja.Pagina = paginaActual;
            dgridEncabezados.DataSource = bandeja.ListaEncabezados(IdTipoInforme, pFiltro, idCliente, idUser, Estado, Caracter, FechaDesde, FechaHasta, 0, false);
            dgridEncabezados.DataBind();
            litPaginador.Text = bandeja.GetPaginador(10);
        }

		protected void dgridEncabezados_PreRender(object sender, EventArgs e)
		{
			string strRedir = "";
			string strRedirCalle = "";
            string strFechaCondicional = "";
            string strEmpresa = "";
			foreach (DataGridItem myItem in dgridEncabezados.Items)
			{
                try
                {
                    ((Label)myItem.FindControl("lblFecha")).Text = DateTime.Parse(myItem.Cells[1].Text).ToShortDateString() + " " + DateTime.Parse(myItem.Cells[1].Text).ToShortTimeString();
                }
                catch (Exception exc)
                { }

                if (myItem.Cells[12].Text == "1")
                {
                    ((ImageButton)myItem.FindControl("Borrar")).Attributes.Add("onclick", @"javascript: return confirm('¿Está seguro que desea eliminar DEFINITIVAMENTE el Informe?');");
                    ((ImageButton)myItem.FindControl("Borrar")).ToolTip = "Eliminar DEFINITIVAMENTE el informe";
                }
                else
                {
                    ((ImageButton)myItem.FindControl("Borrar")).Attributes.Add("onclick", @"javascript: return confirm('¿Desea cancelar el Informe?');");
                    ((ImageButton)myItem.FindControl("Borrar")).ToolTip = "Cancelar el informe";
                }

                strFechaCondicional = "";
                if (myItem.Cells[18].Text != null && myItem.Cells[18].Text != "&nbsp;" && myItem.Cells[12].Text == "11")
                    strFechaCondicional = diferenciaFecha(myItem.Cells[18].Text.ToString());

                myItem.Cells[7].Text = "<IMG SRC='/img/Estado" + myItem.Cells[12].Text + ".gif' widht='14' height='14' border='0' title='" + myItem.Cells[17].Text + strFechaCondicional + "'>&nbsp;&nbsp;&nbsp;" + myItem.Cells[6].Text;

				switch(myItem.Cells[14].Text)
				{
					case "1": //Realizar Informe de Propiedad
						strRedir = "/InformePropiedad/VerInforme.aspx?id="+ myItem.Cells[0].Text + "&IdTipo=1";
						//strRedirCalle = "/InformePropiedad/VerInformeCalle.aspx?id="+ myItem.Cells[0].Text + "&IdTipo=1";
						break;
					case "2": //Realizar Informe de Automotor
						strRedir = "/Automotores/VerInforme.aspx?id="+ myItem.Cells[0].Text + "&IdTipo=2";
						strRedirCalle = "/Automotores/VerInformeCalle.aspx?id="+ myItem.Cells[0].Text + "&IdTipo=2";
						break;
					case "3": //Gravamenes
						switch(myItem.Cells[15].Text)
						{
							case "1": //Hipoteca
								strRedir = "/Hipoteca/VerInforme.aspx?id="+ myItem.Cells[0].Text + "&IdTipo=3";
								strRedirCalle = "/Hipoteca/VerInformeCalle.aspx?id="+ myItem.Cells[0].Text + "&IdTipo=3";
								break;
							case "2": //Usufructo
								strRedir = "/Usufructo/VerInforme.aspx?id="+ myItem.Cells[0].Text + "&IdTipo=3";
								strRedirCalle = "/Usufructo/VerInformeCalle.aspx?id="+ myItem.Cells[0].Text + "&IdTipo=3";
								break;
							//case "3": //Inhibición
							//	strRedir = "/Inhibicion/VerInforme.aspx?id="+ myItem.Cells[0].Text + "&IdTipo=3";
							//	strRedirCalle = "/Inhibicion/VerInformeCalle.aspx?id="+ myItem.Cells[0].Text + "&IdTipo=3";
							//	break;
							case "4": //Embargo
								strRedir = "/Embargo/VerInforme.aspx?id="+ myItem.Cells[0].Text + "&IdTipo=3";
								strRedirCalle = "/Embargo/VerInformeCalle.aspx?id="+ myItem.Cells[0].Text + "&IdTipo=3";
								break;
							case "5": //Bien de Familia
								strRedir = "/BienFamilia/VerInforme.aspx?id="+ myItem.Cells[0].Text + "&IdTipo=3";
								strRedirCalle = "/BienFamilia/VerInformeCalle.aspx?id="+ myItem.Cells[0].Text + "&IdTipo=3";
								break;
                            case "6": //Servidumbre
                                strRedir = "/Servidumbre/VerInforme.aspx?id=" + myItem.Cells[0].Text + "&IdTipo=3";
                                strRedirCalle = "/Servidumbre/VerInformeCalle.aspx?id=" + myItem.Cells[0].Text + "&IdTipo=3";
                                break;
                            case "7": //Providencia cautelar
                                strRedir = "/Gravamenes/ProvidenciaCautelar/VerInforme.aspx?id=" + myItem.Cells[0].Text + "&IdTipo=3";
                                strRedirCalle = "/Gravamenes/ProvidenciaCautelar/VerInformeCalle.aspx?id=" + myItem.Cells[0].Text + "&IdTipo=3";
                                break;
                            case "8": //Mandato
                                strRedir = "/Gravamenes/mandato/VerInforme.aspx?id=" + myItem.Cells[0].Text + "&IdTipo=3";
                                strRedirCalle = "/Gravamenes/mandato/VerInformeCalle.aspx?id=" + myItem.Cells[0].Text + "&IdTipo=3";
                                break;


                        }
						break;
                    case "4": //Realizar Informe Ambiental
                        strRedir = "/socioAmbiental/VerInforme.aspx?id=" + myItem.Cells[0].Text + "&IdTipo=4";
                        strRedirCalle = "/socioAmbiental/VerFormularioCalle.aspx?id=" + myItem.Cells[0].Text + "&IdTipo=4";
                        break;
					case "5": //Realizar Verificacion de domicilio particular
						strRedir = "/verifDomParticular/VerInforme.aspx?id="+ myItem.Cells[0].Text + "&IdTipo=5";
						strRedirCalle = "/verifDomParticular/VerInformeCalle.aspx?id="+ myItem.Cells[0].Text + "&IdTipo=5";
						break;
					case "6": //Realizar Verificacion de domicilio laboral
						strRedir = "/verifDomLaboral/VerInforme.aspx?id="+ myItem.Cells[0].Text + "&IdTipo=6";
						strRedirCalle = "/verifDomLaboral/VerInformeCalle.aspx?id="+ myItem.Cells[0].Text + "&IdTipo=6";
						break;
					case "7": //Realizar Verificacion de domicilio comercial
						strRedir = "/verifDomComercial/VerInforme.aspx?id="+ myItem.Cells[0].Text + "&IdTipo=7";
						strRedirCalle = "/verifDomComercial/VerInformeCalle.aspx?id="+ myItem.Cells[0].Text + "&IdTipo=7";
						break;
                    case "9":
                        ((ImageButton)myItem.FindControl("Realizar")).Attributes.Add("onclick", "cambioEstado(9, " + myItem.Cells[0].Text + ")");
                        break;
                    case "10": //Busqueda Automotor
						strRedir = "/BusquedaAutomotor/VerInforme.aspx?id="+ myItem.Cells[0].Text + "&IdTipo=10";
						//strRedirCalle = "/BusquedaAutomotor/VerInformeCalle.aspx?id="+ myItem.Cells[0].Text + "&IdTipo=10";
						break;
                    case "11": //Realizar Informe de Propiedad otras Provincias
                        strRedir = "/InformePropiedadProvincias/VerInforme.aspx?id=" + myItem.Cells[0].Text + "&IdTipo=11";
                        //strRedirCalle = "/InformePropiedad/VerInformeCalle.aspx?id="+ myItem.Cells[0].Text + "&IdTipo=11";
                        break;
                    case "12": //Informe Catastral
                        strRedir = "/Catastral/VerInforme.aspx?id=" + myItem.Cells[0].Text + "&IdTipo=12";
                        break;
					case "13": //Busqueda Propiedad
						strRedir = "/BusquedaPropiedad/VerInforme.aspx?id="+ myItem.Cells[0].Text + "&IdTipo=13";
						//strRedirCalle = "/BusquedaPropiedad/VerInformeCalle.aspx?id="+ myItem.Cells[0].Text + "&IdTipo=13";
						break;
					case "14": //Realizar Verificacion de Contrato
						strRedir = "/verifContrato/VerInforme.aspx?id="+ myItem.Cells[0].Text + "&IdTipo=14";
						break;
                    case "15": //Realizar Relevamiento Ambiental BANCOR
                        strRedir = "/ambientalBancor/VerInforme.aspx?id=" + myItem.Cells[0].Text + "&IdTipo=15";
                        strRedirCalle = "/ambientalBancor/VerInformeCalle.aspx?id=" + myItem.Cells[0].Text + "&IdTipo=15";
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
                    case "21": //Realizar Inspeccion Socio Ambiental BANCOR
                        strRedir = "/InspeccionAmbientalBancor/VerInforme.aspx?id=" + myItem.Cells[0].Text + "&IdTipo=21";
                        strRedirCalle = "/InspeccionAmbientalBancor/VerInformeCalle.aspx?id=" + myItem.Cells[0].Text + "&IdTipo=21";
                        break;

				}
				if (myItem.Cells[12].Text == "3")
				{
					((ImageButton) myItem.FindControl("VerEncabezado")).ToolTip = "Ver Informe";
					((ImageButton) myItem.FindControl("VerEncabezado")).Attributes.Add("onclick", "javascript: window.open('" + strRedir + "','','tools=no,width=720,menus=no,scrollbars=yes'); return false;");
					//Alejandro necesita modificar los informes finalizados
					//((ImageButton) myItem.FindControl("realizar")).Visible = false;
					((ImageButton) myItem.FindControl("Borrar")).Visible = false;
					((ImageButton) myItem.FindControl("Editar")).Visible = false;
                    
                    // Informe de morosidad y registro publico de comercio no tiene vista de impresion
                    if (myItem.Cells[14].Text == "9")
                    { 
                        ((ImageButton)myItem.FindControl("VerEncabezado")).Visible = false;
                        ((ImageButton)myItem.FindControl("realizar")).Visible = false;
                    }
                    // Informe de morosidad no tiene vista de impresion
                    // if (myItem.Cells[14].Text == "9" || myItem.Cells[14].Text == "17")
                    //{
                    //    ((ImageButton)myItem.FindControl("VerEncabezado")).Visible = false;
                    //    ((ImageButton)myItem.FindControl("realizar")).Visible = false;
                    //}
                    // se anula lo anterior para agregar la funcionalidad de confeccion de morosidad con PDF

				} else {
					((ImageButton) myItem.FindControl("VerEncabezado")).Attributes.Add("onclick", "javascript: window.open('" + strRedirCalle + "','','tools=no,width=720,menus=no,scrollbars=yes');return false;");
					((ImageButton) myItem.FindControl("VerEncabezado")).ToolTip = "Imprimir Formulario para Calle";
					((ImageButton)myItem.FindControl("VerEncabezado")).Attributes.Add("src",@"/img/printer.gif");

                    // Informes que NO visualiza la impresion de form. calle
                    if (myItem.Cells[14].Text == "1" || myItem.Cells[14].Text == "2" || myItem.Cells[14].Text == "3" || myItem.Cells[14].Text == "10" || myItem.Cells[14].Text == "11" || myItem.Cells[14].Text == "12" || myItem.Cells[14].Text == "13" || myItem.Cells[14].Text == "14" || myItem.Cells[14].Text == "16" || myItem.Cells[14].Text == "17" || myItem.Cells[14].Text == "18" || myItem.Cells[14].Text == "19" || myItem.Cells[14].Text == "20") ((ImageButton)myItem.FindControl("VerEncabezado")).Visible = false;

                    // Informe de Morosidad
                    if (myItem.Cells[14].Text == "17" && myItem.Cells[12].Text != "2") { ((ImageButton)myItem.FindControl("realizar")).Visible = false; }

					((ImageButton) myItem.FindControl("Borrar")).Visible = true;
					((ImageButton) myItem.FindControl("Editar")).Visible = true;
				}
                if (myItem.Cells[16].Text == "0")  //no leida
                {
                    myItem.Font.Bold = true;
                    myItem.Font.Name = "Arial";
                }

                if (myItem.Cells[20].Text != "&nbsp;")  //Nombre de Fantasia o Razon Social?
                {
                    strEmpresa = (myItem.Cells[20].Text).ToString();
                    if (myItem.Cells[21].Text != "&nbsp;")
                        strEmpresa = strEmpresa + " (" + (myItem.Cells[21].Text).ToString() + ")";
                }
                else
                    strEmpresa = (myItem.Cells[19].Text).ToString();

                ((Label)myItem.FindControl("lblEmpresa")).Text = strEmpresa;

			}
		}

		private void dgridEncabezados_ItemCommand(object source, DataGridCommandEventArgs e)
		{
			if (e.Item.Cells[0].Text != "")
			{
				switch (((ImageButton) e.CommandSource).CommandName)
				{
					case "Borrar":
						int IdCodigo = int.Parse(e.Item.Cells[0].Text);
                        if (e.Item.Cells[12].Text == "1")
                            BorrarInforme(IdCodigo);
                        else
                            CancelarEncabezado(IdCodigo);
						Response.Redirect("Principal.aspx?IdTipo=" + IdTipo.ToString());
						break;

					case "Editar":
							Response.Redirect("abmInforme.aspx?id=" + e.Item.Cells[0].Text + "&IdTipo=" + IdTipo.ToString());

						break;
					case "Historico":
						Response.Redirect("VerHistorial.aspx?id=" + e.Item.Cells[0].Text + "&IdTipo=" + IdTipo.ToString());
						break;
					case "Realizar":
						switch(e.Item.Cells[14].Text)
						{
							case "1": //Realizar Informe de Propiedad
								Response.Redirect("/InformePropiedad/Informe.aspx?id="+ e.Item.Cells[0].Text + "&IdTipo=1");
								break;
							case "2": //Realizar Informe de Automotores
								Response.Redirect("/Automotores/Informe.aspx?id="+ e.Item.Cells[0].Text + "&IdTipo=2");
								break;
							case "3": //Embargos
								switch(e.Item.Cells[15].Text)
								{
									case "1": //Hipoteca
										Response.Redirect("/Hipoteca/Informe.aspx?id="+ e.Item.Cells[0].Text + "&IdTipo=3");
										break;
									case "2": //Usufructo
										Response.Redirect("/Usufructo/Informe.aspx?id="+ e.Item.Cells[0].Text + "&IdTipo=3");
										break;
									case "4": //Embargo
										Response.Redirect("/Embargo/Informe.aspx?id="+ e.Item.Cells[0].Text + "&IdTipo=3");
										break;
									case "5": //Bien de Familia
										Response.Redirect("/BienFamilia/Informe.aspx?id="+ e.Item.Cells[0].Text + "&IdTipo=3");
										break;
                                    case "6": //Servidumbre
                                        
                                        Response.Redirect("/Servidumbre/Informe.aspx?id=" + e.Item.Cells[0].Text + "&IdTipo=3");
                                        break;
                                    case "7": //Providencia cautelar
                                        Response.Redirect("/Gravamenes/ProvidenciaCautelar/Informe.aspx?id=" + e.Item.Cells[0].Text + "&IdTipo=3");
                                        break;
                                    case "8": //Mandato
                                        Response.Redirect("/Gravamenes/Mandato/Informe.aspx?id=" + e.Item.Cells[0].Text + "&IdTipo=3");
                                        break;
								}
								break;
                            case "4": //Realizar Informe Ambiental
                                Response.Redirect("/socioAmbiental/Informe.aspx?id=" + e.Item.Cells[0].Text + "&IdTipo=4");
                                break;
							case "5": //Realizar Verificacion de domicilio particular
								Response.Redirect("/verifDomParticular/Informe.aspx?id="+ e.Item.Cells[0].Text + "&IdTipo=5");
								break;
							case "6": //Realizar Verificacion de domicilio laboral
								Response.Redirect("/verifDomLaboral/Informe.aspx?id="+ e.Item.Cells[0].Text + "&IdTipo=6");
								break;
							case "7": //Realizar Verificacion de domicilio comercial
								Response.Redirect("/verifDomComercial/Informe.aspx?id="+ e.Item.Cells[0].Text + "&IdTipo=7");
								break;
							case "10": //Busqueda de Automotor
								Response.Redirect("/BusquedaAutomotor/Informe.aspx?id="+ e.Item.Cells[0].Text + "&IdTipo=10");
								break;
                            case "11": //Realizar Informe de Propiedad otras Provincias
                                Response.Redirect("/InformePropiedadProvincias/Informe.aspx?id=" + e.Item.Cells[0].Text + "&IdTipo=11");
                                break;
                            case "12": //Informe Catastral
                                Response.Redirect("/Catastral/Informe.aspx?id=" + e.Item.Cells[0].Text + "&IdTipo=12");
                                break;
                            case "13": //Busqueda de Propiedad
								Response.Redirect("/BusquedaPropiedad/Informe.aspx?id="+ e.Item.Cells[0].Text + "&IdTipo=10");
								break;
							case "14": //Realizar Verificacion de Contrato
								Response.Redirect("/verifContrato/Informe.aspx?id="+ e.Item.Cells[0].Text + "&IdTipo=14");
								break;
                            case "15": //Realizar Relevamiento Ambiental BANCOR
                                Response.Redirect("/ambientalBancor/Informe.aspx?id=" + e.Item.Cells[0].Text + "&IdTipo=15");
                                break;
                            case "16": //Inhibición
                                Response.Redirect("/Inhibicion/Informe.aspx?id=" + e.Item.Cells[0].Text + "&IdTipo=16");
                                break;
                            case "17":
                                Response.Redirect("/Morosidad/Informe.aspx?id=" + e.Item.Cells[0].Text + "&IdTipo=17");
                                //Response.Redirect("Principal.aspx?idTipo=17");
                                //ListaBandejaFiltro();
                                break;
                            case "18": //Gravámenes DIR
                                Response.Redirect("/gravamenesDIR/Informe.aspx?id=" + e.Item.Cells[0].Text + "&IdTipo=18");
                                break;
                            case "19": //verificacion de defunción
                                Response.Redirect("/verifDefuncion/Informe.aspx?id=" + e.Item.Cells[0].Text + "&IdTipo=19");
                                break;
                            case "20": //Partidas de defunción
                                //ListaBandejaFiltro();
                                Response.Redirect("/InformePartidasDefuncion/Informe.aspx?id=" + e.Item.Cells[0].Text + "&IdTipo=20");
                                break;
                            case "21": //Realizar Inspeccion Socio Ambiental BANCOR
                                Response.Redirect("/InspeccionAmbientalBancor/Informe.aspx?id=" + e.Item.Cells[0].Text + "&IdTipo=21");
                                break;
							default:
								Response.Redirect("principal.aspx");
								break;
						}
						break;

				}
			}
		}

		private void BorrarInforme(int idEncabezado)
		{
			EncabezadoApp Encabezado = new EncabezadoApp();
			Encabezado.cargarEncabezado(idEncabezado);

			// Usuario Logueado
			UsuarioAutenticado Usuario = (UsuarioAutenticado) Session["UsuarioAutenticado"];
			Encabezado.IdUsuario = Usuario.IdUsuario;

			Encabezado.Borrar(idEncabezado);

            ReferenciasApp Referencia = new ReferenciasApp();
            Referencia.Estado = 4;
            Referencia.IdCliente = Encabezado.IdCliente;
            Referencia.IdUsuario = Encabezado.IdUsuario;
            Referencia.Borrar(Encabezado.idReferencia);
		}


        private void CancelarEncabezado(int idEncabezado)
        {
            EncabezadoApp Encabezado = new EncabezadoApp();
            Encabezado.cargarEncabezado(idEncabezado);

            // Usuario Logueado
            UsuarioAutenticado Usuario = (UsuarioAutenticado)Session["UsuarioAutenticado"];
            Encabezado.IdCliente = Usuario.IdCliente;
            Encabezado.IdUsuario = Usuario.IdUsuario;

            Encabezado.Cancelar(idEncabezado);
        }


		protected void btnBuscar_Click(object sender, EventArgs e)
		{
            paginaActual = 1;
            ListaBandejaFiltro();
		}

		protected void btnInforme_Click(object sender, EventArgs e)
		{
            Response.Redirect("altaInforme.aspx?IdTipo=" + IdTipo);
		}

		protected void dgridEncabezados_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            
		}

		private void PonerTitulo(int IdTipo){
			switch (IdTipo)
			{
				case 1: // Propiedad
					lblTipo.Text = " - Propiedad";
					break;
				case 2: // Automotor
					lblTipo.Text = " - Automotor";
                    btnPropiedadRegistro.Text = "Registro del automotor";
					break;
				case 3: // Gravámenes
					lblTipo.Text = " - Gravámenes (folios)";
					break;
				case 4: // Ambiental
					lblTipo.Text = " - Ambiental";
					break;
				case 5: // Dom Particular
					lblTipo.Text = " - Verificación de Domicilio Particular";
					break;
				case 6:
					lblTipo.Text = " - Verificación de Domicilio Laboral";
					break;
				case 7:
					lblTipo.Text = " - Verificación de Domicilio Comercial";
					break;
				case 8:
					lblTipo.Text = " - Verificación Especial";
					break;
				case 9: // Registro Publico de Comercio
					lblTipo.Text = " - Registro Público de Comercio";
					break;
				case 10: // Busqueda Automotor
					lblTipo.Text = " - Busqueda Automotor";
                    btnPropiedadRegistro.Text = "Registro del automotor";
					break;
				case 11: // Informe Propiedad Otras Provincias
					lblTipo.Text = " - Informe Propiedad Otras Provincias";
					break;
				case 12: // Informe Catastral
					lblTipo.Text = " - Informe Catastral";
					break;
				case 13: // Búsqueda Propiedad
					lblTipo.Text = " - Búsqueda Propiedad";
					break;
				case 14: // Informe Contractual
					lblTipo.Text = " - Informe Contractual";
					break;
                case 15: // Relevamiento ambiental BANCOR
                    lblTipo.Text = " - Entrevista de Relevamiento Habitacional";
                    btnPropiedadRegistro.Text = "Importar / Exportar";
                    break;
                case 16: // Informe Inhibición
                    lblTipo.Text = " - Informe Inhibición";
                    break;
                case 17: // Informe Morosidad
                    lblTipo.Text = " - Informe Morosidad";
                    break;
                case 18: // Informe Gravamen DIR
                    lblTipo.Text = " - Informe de Gravámenes (DIR)";
                    break;
                case 19: // Verificación de Defunción
                    lblTipo.Text = " - Verificación de Defunción";
                    btnPropiedadRegistro.Text = "Importar / Imprimir";
                    break;
                case 20: // Informe Partidas de Defunción
                    lblTipo.Text = " - Informe de Partidas de Defunción";
                    btnPropiedadRegistro.Text = "Importar / Imprimir";
                    break;

                case 21: // Inspeccion Socio Ambiental
                    lblTipo.Text = " - Inspección Socio Ambiental";
                    //btnPropiedadRegistro.Text = "Importar / Imprimir";
                    break;

			}
		}

        private void EnviarRegistro(int idTipo)
        {
            btnPropiedadRegistro.Visible = false;
            if (idTipo == 1 || idTipo == 2 || idTipo == 3 || idTipo == 10 || idTipo == 12 || idTipo == 13 || IdTipo == 15 || IdTipo == 16 || IdTipo == 19 || IdTipo == 20) { btnPropiedadRegistro.Visible = true; }
        }

        protected void btnPropiedadRegistro_Click(object sender, EventArgs e)
        {
            switch (IdTipo)
            {
                case 1:
                    Response.Redirect("../InformePropiedad/propiedad_registro.aspx");
                    break;
                case 2:
                    Response.Redirect("../Automotores/automotor_registro.aspx");
                    break;
                case 3:
                    Response.Redirect("../Gravamenes/gravamenes_registro.aspx");
                    break;
                case 10:
                    Response.Redirect("../BusquedaAutomotor/busautomotor_registro.aspx");
                    break;
                case 12:
                    Response.Redirect("../Catastral/catastral_registro.aspx");
                    break;
                case 13:
                    Response.Redirect("../BusquedaPropiedad/busquedapropiedad_registro.aspx");
                    break;
                case 15:
                    Response.Redirect("../ambientalBancor/importar.aspx");
                    break;
                case 16:
                    Response.Redirect("../Inhibicion/inhibicion_registro.aspx");
                    break;
                case 19:
                    Response.Redirect("../verifDefuncion/importar.aspx");
                    break;
                case 20:
                    Response.Redirect("../verifDefuncion/importar_partidas.aspx");
                    break;
            }
        }

        protected void btnImprimir_Click(object sender, EventArgs e)
        {
            switch (IdTipo)
            {
                case 6:
                    Response.Redirect("../verifDomLaboral/pendientes.aspx");
                    break;
                case 17:
                    Response.Redirect("../Morosidad/pendientes.aspx");
                    break;
            }
        }

        protected void dgridEncabezados_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
           // dgridEncabezados.CurrentPageIndex = e.NewPageIndex;
           // ListaBandejaFiltro();
        }
        protected void hPagina_ValueChanged(object sender, EventArgs e)
        {
            paginaActual = int.Parse(hPagina.Value);
            if (hTipoBusqueda.Value == "1")
                ListaBandejaFiltro();
            else
                ListaBandeja();
        }


        protected string diferenciaFecha(string fecha)
        {
            DateTime fechaActual = DateTime.Now;
            DateTime fechaCon = DateTime.Parse(fecha);
            TimeSpan dif;
            string difFecha = "";
            int d;
            int h;
            int m;
            dif = fechaActual - fechaCon;
            d = dif.Days;
            h = dif.Hours;
            m = dif.Minutes;

            if (d > 0)
            {
                difFecha = " " + d.ToString() + " día";
                if (d > 1)
                    difFecha = difFecha + "s ";
                else
                    difFecha = difFecha + " ";
            }

            if (h > 0)
            {
                difFecha = " " + difFecha + h.ToString() + " hora";
                if (h > 1)
                    difFecha = difFecha + "s ";
                else
                    difFecha = difFecha + " ";
            }

            if (m > 0)
            {
                difFecha = " " + difFecha + m.ToString() + " minuto";
                if (m > 1)
                    difFecha = difFecha + "s ";
                else
                    difFecha = difFecha + " ";
            }
            
            return ". Lleva condicional " + difFecha;
        }
    }
}