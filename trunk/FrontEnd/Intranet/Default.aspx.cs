using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.App;
using ar.com.TiempoyGestion.BackEnd.Clientes.Dal;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;


namespace ar.com.TiempoyGestion.FrontEnd.Intranet
{
	/// <summary>
	/// Summary description for _Default.
	/// </summary>
	public partial class _Default : Page
	{
        protected bool bsqRapida = false;
		protected void Page_Load(object sender, EventArgs e)
		{
           
            if (txtFechaInicio.Text == "")
                txtFechaInicio.Text = DateTime.Today.AddMonths(-3).ToShortDateString();

            if (txtFechaFinal.Text == "")
                txtFechaFinal.Text = DateTime.Today.ToShortDateString();

            if (!Page.IsPostBack)
            {
                //txtFechaInicio.Text = DateTime.Today.AddMonths(-3).ToShortDateString();
                //txtFechaFinal.Text = DateTime.Today.ToShortDateString();
            }
			// Put user code to initialize the page here
			//Response.Redirect("/BandejaEntrada/Principal.aspx?idTipo=2");
			
            //BandejaEntradaApp bandeja = new BandejaEntradaApp();
			//litGrupos.Text = bandeja.InformesEstadisticosHOME().ToString();
		}

		#region Web Form Designer generated code

		protected override void OnInit(EventArgs e)
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
			this.Load += new EventHandler(this.Page_Load);

		}

		#endregion
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            //udpListaInformes.Visible = true;
            ListaBandeja();
        }

        protected void dgridEncabezados_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {

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

                if (myItem.Cells[13].Text == "1")
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
                if (myItem.Cells[19].Text != null && myItem.Cells[19].Text != "&nbsp;" && myItem.Cells[13].Text == "11")
                    strFechaCondicional = diferenciaFecha(myItem.Cells[19].Text.ToString());


                myItem.Cells[8].Text = "<IMG SRC='/img/Estado" + myItem.Cells[13].Text + ".gif' widht='14' height='14' border='0' title='" + myItem.Cells[18].Text + strFechaCondicional + "'>&nbsp;&nbsp;&nbsp;" + myItem.Cells[7].Text;
                switch (myItem.Cells[15].Text)//---hasta aca
                {
                    case "1": //Realizar Informe de Propiedad
                        strRedir = "/InformePropiedad/VerInforme.aspx?id=" + myItem.Cells[0].Text + "&IdTipo=1";
                        //strRedirCalle = "/InformePropiedad/VerInformeCalle.aspx?id="+ myItem.Cells[0].Text + "&IdTipo=1";
                        break;
                    case "2": //Realizar Informe de Automotor
                        strRedir = "/Automotores/VerInforme.aspx?id=" + myItem.Cells[0].Text + "&IdTipo=2";
                        strRedirCalle = "/Automotores/VerInformeCalle.aspx?id=" + myItem.Cells[0].Text + "&IdTipo=2";
                        break;
                    case "3": //Gravamenes
                        switch (myItem.Cells[16].Text)
                        {
                            case "1": //Hipoteca
                                strRedir = "/Hipoteca/VerInforme.aspx?id=" + myItem.Cells[0].Text + "&IdTipo=3";
                                strRedirCalle = "/Hipoteca/VerInformeCalle.aspx?id=" + myItem.Cells[0].Text + "&IdTipo=3";
                                break;
                            case "2": //Usufructo
                                strRedir = "/Usufructo/VerInforme.aspx?id=" + myItem.Cells[0].Text + "&IdTipo=3";
                                strRedirCalle = "/Usufructo/VerInformeCalle.aspx?id=" + myItem.Cells[0].Text + "&IdTipo=3";
                                break;
                            case "3": //Inhibición
                                strRedir = "/Inhibicion/VerInforme.aspx?id=" + myItem.Cells[0].Text + "&IdTipo=3";
                                strRedirCalle = "/Inhibicion/VerInformeCalle.aspx?id=" + myItem.Cells[0].Text + "&IdTipo=3";
                                break;
                            case "4": //Embargo
                                strRedir = "/Embargo/VerInforme.aspx?id=" + myItem.Cells[0].Text + "&IdTipo=3";
                                strRedirCalle = "/Embargo/VerInformeCalle.aspx?id=" + myItem.Cells[0].Text + "&IdTipo=3";
                                break;
                            case "5": //Bien de Familia
                                strRedir = "/BienFamilia/VerInforme.aspx?id=" + myItem.Cells[0].Text + "&IdTipo=3";
                                strRedirCalle = "/BienFamilia/VerInformeCalle.aspx?id=" + myItem.Cells[0].Text + "&IdTipo=3";
                                break;
                        }
                        break;
                    case "4": //Realizar Informe Ambiental
                        strRedir = "/socioAmbiental/VerInforme.aspx?id=" + myItem.Cells[0].Text + "&IdTipo=4";
                        strRedirCalle = "/socioAmbiental/VerFormularioCalle.aspx?id=" + myItem.Cells[0].Text + "&IdTipo=4";
                        break;
                    case "5": //Realizar Verificacion de domicilio particular
                        strRedir = "/verifDomParticular/VerInforme.aspx?id=" + myItem.Cells[0].Text + "&IdTipo=5";
                        strRedirCalle = "/verifDomParticular/VerInformeCalle.aspx?id=" + myItem.Cells[0].Text + "&IdTipo=5";
                        break;
                    case "6": //Realizar Verificacion de domicilio laboral
                        strRedir = "/verifDomLaboral/VerInforme.aspx?id=" + myItem.Cells[0].Text + "&IdTipo=6";
                        strRedirCalle = "/verifDomLaboral/VerInformeCalle.aspx?id=" + myItem.Cells[0].Text + "&IdTipo=6";
                        break;
                    case "7": //Realizar Verificacion de domicilio comercial
                        strRedir = "/verifDomComercial/VerInforme.aspx?id=" + myItem.Cells[0].Text + "&IdTipo=7";
                        strRedirCalle = "/verifDomComercial/VerInformeCalle.aspx?id=" + myItem.Cells[0].Text + "&IdTipo=7";
                        break;
                    case "10": //Busqueda Automotor
                        strRedir = "/BusquedaAutomotor/VerInforme.aspx?id=" + myItem.Cells[0].Text + "&IdTipo=10";
                        strRedirCalle = "/BusquedaAutomotor/VerInformeCalle.aspx?id=" + myItem.Cells[0].Text + "&IdTipo=10";
                        break;
                    case "11": //Realizar Informe de Propiedad otras Provincias
                        strRedir = "/InformePropiedadProvincias/VerInforme.aspx?id=" + myItem.Cells[0].Text + "&IdTipo=11";
                        //strRedirCalle = "/InformePropiedad/VerInformeCalle.aspx?id="+ myItem.Cells[0].Text + "&IdTipo=11";
                        break;
                    case "12": //Informe Catastral
                        strRedir = "/Catastral/VerInforme.aspx?id=" + myItem.Cells[0].Text + "&IdTipo=12";
                        break;
                    case "13": //Busqueda Propiedad
                        strRedir = "/BusquedaPropiedad/VerInforme.aspx?id=" + myItem.Cells[0].Text + "&IdTipo=13";
                        strRedirCalle = "/BusquedaPropiedad/VerInformeCalle.aspx?id=" + myItem.Cells[0].Text + "&IdTipo=13";
                        break;
                    case "14": //Realizar Verificacion de Contrato
                        strRedir = "/verifContrato/VerInforme.aspx?id=" + myItem.Cells[0].Text + "&IdTipo=14";
                        break;
                    case "15": //Realizar Relevamiento Ambiental BANCOR
                        strRedir = "/ambientalBancor/VerInforme.aspx?id=" + myItem.Cells[0].Text + "&IdTipo=15";
                        strRedirCalle = "/ambientalBancor/VerInformeCalle.aspx?id=" + myItem.Cells[0].Text + "&IdTipo=15";
                        break;
                    case "16": //Realizar Informe de Inhibición
                        strRedir = "/Inhibicion/VerInforme.aspx?id=" + myItem.Cells[0].Text + "&IdTipo=16";
                        break;
                    case "17":
                        ((ImageButton)myItem.FindControl("Realizar")).Attributes.Add("onclick", "cambioEstado(17, " + myItem.Cells[0].Text + ")");
                        break;

                }
                if (myItem.Cells[13].Text == "3")
                {
                    ((ImageButton)myItem.FindControl("VerEncabezado")).ToolTip = "Ver Informe";
                    ((ImageButton)myItem.FindControl("VerEncabezado")).Attributes.Add("onclick", "javascript: window.open('" + strRedir + "','','tools=no,width=720,menus=no,scrollbars=yes'); return false;");
                    //Alejandro necesita modificar los informes finalizados
                    //((ImageButton) myItem.FindControl("realizar")).Visible = false;
                    ((ImageButton)myItem.FindControl("Borrar")).Visible = false;
                    ((ImageButton)myItem.FindControl("Editar")).Visible = false;

                    // Informe de morosidad no tiene vista de impresion
                    if (myItem.Cells[15].Text == "17")
                    {
                        ((ImageButton)myItem.FindControl("VerEncabezado")).Visible = false;
                        ((ImageButton)myItem.FindControl("realizar")).Visible = false;
                    }

                }
                else
                {
                    ((ImageButton)myItem.FindControl("VerEncabezado")).Attributes.Add("onclick", "javascript: window.open('" + strRedirCalle + "','','tools=no,width=720,menus=no,scrollbars=yes');return false;");
                    ((ImageButton)myItem.FindControl("VerEncabezado")).ToolTip = "Imprimir Formulario para Calle";
                    ((ImageButton)myItem.FindControl("VerEncabezado")).Attributes.Add("src", @"/img/printer.gif");

                    // Informes que NO visualiza la impresion de form. calle
                    if (myItem.Cells[15].Text == "1" || myItem.Cells[15].Text == "2" || myItem.Cells[15].Text == "3" || myItem.Cells[15].Text == "10" || myItem.Cells[15].Text == "11" || myItem.Cells[15].Text == "12" || myItem.Cells[15].Text == "13" || myItem.Cells[15].Text == "14" || myItem.Cells[15].Text == "16" || myItem.Cells[15].Text == "17") ((ImageButton)myItem.FindControl("VerEncabezado")).Visible = false;

                    // Informe de Morosidad
                    if (myItem.Cells[15].Text == "17" && myItem.Cells[13].Text != "2") { ((ImageButton)myItem.FindControl("realizar")).Visible = false; }

                    ((ImageButton)myItem.FindControl("Borrar")).Visible = true;
                    ((ImageButton)myItem.FindControl("Editar")).Visible = true;
                }
                if (myItem.Cells[17].Text == "0")  //no leida
                {
                    myItem.Font.Bold = true;
                    myItem.Font.Name = "blue";
                }

                if (myItem.Cells[21].Text != "&nbsp;")  //Nombre de Fantasia o Razon Social?
                {
                    strEmpresa = (myItem.Cells[21].Text).ToString();
                    if (myItem.Cells[22].Text != "&nbsp;")
                        strEmpresa = strEmpresa + " (" + (myItem.Cells[22].Text).ToString() + ")";
                }
                else
                    strEmpresa = (myItem.Cells[20].Text).ToString();

                ((Label)myItem.FindControl("lblEmpresa")).Text = strEmpresa;
            }
        }

        protected void dgridEncabezados_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ListaBandeja()
        {
            int IdTipo = -1;
            bool bsqRapida = false;
            int paginaActual = 1;
            string fechaDesde ="";
            string fechaHasta = "";

            if (txtFechaInicio.Text != null)
                fechaDesde = txtFechaInicio.Text;
            else
                fechaDesde = DateTime.Today.AddMonths(-3).ToShortDateString();

            if (txtFechaInicio.Text != null)
                fechaHasta = txtFechaFinal.Text;
            else
                fechaHasta = DateTime.Today.ToShortDateString();

            //hTipoBusqueda.Value = "0";
            int idUser = -1;
            int idCliente = -1;
            string pFiltro = "";
            //if (chkSoloMias.Checked) idUser = IdUsuario;

            //string coso = txtBuscar.Text.Substring(0, 3).GetType().Name.ToString();
            /*
            if (txtBuscar.Text != "")
            {
                //if (txtBuscar.Text.Substring(0, 3).GetType().Name == "String")
                if(hIdCliente.Value != "")
                {
                    //buscar clientes
                    ClienteDal cliente = new ClienteDal();
                    cliente.Cargar(int.Parse(hIdCliente.Value));
                    idCliente = cliente.Id;
                }
                else
                {
                    //busca matriculas
                }
            }
            */
            if (hIdCliente.Value != "")
            {
                idCliente = int.Parse(hIdCliente.Value);
            }

            BandejaEntradaApp bandeja = new BandejaEntradaApp();
            bandeja.RegPorPagina = 10;
            bandeja.Pagina = paginaActual;
            if (!bsqRapida)
            {
                dgridEncabezados.DataSource = bandeja.ListaEncabezados(IdTipo, pFiltro, idCliente, idUser, "-1", -1, fechaDesde, fechaHasta, 0, false);
                dgridEncabezados.DataBind();

                //litPaginador.Text = bandeja.GetPaginador(10);
            }
            //else
            //litPaginador.Text = "<b><i>Ingrese criterio de búsqueda</i></b>";

            //PonerTitulo(IdTipo);
        }


    protected void  dgridEncabezados_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        			if (e.Item.Cells[0].Text != "")
			{
				switch (((ImageButton) e.CommandSource).CommandName)
				{
					case "Borrar":
						int IdCodigo = int.Parse(e.Item.Cells[0].Text);
						BorrarInforme(IdCodigo);
						Response.Redirect("Default.aspx");
						break;

					case "Editar":
                        Response.Redirect("/BandejaEntrada/abmInforme.aspx?id=" + e.Item.Cells[0].Text + "&IdTipo=" + e.Item.Cells[15].Text);

						break;
					case "Historico":
                        Response.Redirect("/BandejaEntrada/VerHistorial.aspx?id=" + e.Item.Cells[0].Text + "&IdTipo=" + e.Item.Cells[15].Text);
						break;
					case "Realizar":
						switch(e.Item.Cells[15].Text)
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
									//case "3": //Inhibición
									//	Response.Redirect("/Inhibicion/Informe.aspx?id="+ e.Item.Cells[0].Text + "&IdTipo=3");
									//	break;
									case "4": //Embargo
										Response.Redirect("/Embargo/Informe.aspx?id="+ e.Item.Cells[0].Text + "&IdTipo=3");
										break;
									case "5": //Bien de Familia
										Response.Redirect("/BienFamilia/Informe.aspx?id="+ e.Item.Cells[0].Text + "&IdTipo=3");
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
                                ListaBandeja();
                                break;
							default:
                                Response.Redirect("/BandejaEntrada/principal.aspx");
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
        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            //udpListaInformes.Visible = true;
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