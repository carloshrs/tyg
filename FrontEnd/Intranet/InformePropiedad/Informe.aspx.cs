using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;
using ar.com.TiempoyGestion.BackEnd.Informes.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.InformePropiedad
{
	/// <summary>
	/// Summary description for altaInforme.
	/// </summary>
	public partial class Informe : Page
	{
		#region Elemento Web

		protected TextBox Provincia;
		protected Image Image1;
		protected Image Image2;
		protected Image Image3;
		protected Image Image4;
		protected Label lblObservaciones;
		protected Button Cerrar;
		protected Label txtDocumento;


		#endregion
	
		#region Page_Load(object sender, EventArgs e)

		protected void Page_Load(object sender, EventArgs e)
		{
			// El id del informe Seleccionado
			this.GetPostBackEventReference(this);
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    idInformePropiedad.Value = Request.QueryString["id"];
                    LoadInformePropiedad(int.Parse(idInformePropiedad.Value));
                    ListarTitulares(int.Parse(Request.QueryString["id"]));
                    imgCheckMatricula.Attributes.Add("onClick", "Javascript:ChequearMatricula();return false;");
                }
            }
        }

		#endregion

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			// Put user code to initialize the page here
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.dgTitulares.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgTitulares_ItemCommand);

		}
		#endregion

		#region Métodos Privados

		#region ActualizarInforme()
			
		private void ActualizarInforme()
		{
            bool ret = false;
			InformePropiedadApp oInformePropiedad = new InformePropiedadApp();
			oInformePropiedad.cargarInformePropiedad(int.Parse(idInformePropiedad.Value));
			// Usuario Logueado
			UsuarioAutenticado Usuario = (UsuarioAutenticado)Session["UsuarioAutenticado"];
			oInformePropiedad.IdCliente = Usuario.IdCliente;
			oInformePropiedad.IdUsuario = Usuario.IdUsuario;
			
			oInformePropiedad.IdInforme = int.Parse(idInformePropiedad.Value);
			oInformePropiedad.Matricula = txtLegajo.Text;
			oInformePropiedad.TipoProp = int.Parse(idTipoProp.Value);
			oInformePropiedad.Folio = txtFolio.Text;
			oInformePropiedad.Tomo = txtTomo.Text;
			oInformePropiedad.Ano = txtAno.Text;
			oInformePropiedad.Barrio = txtBarrio.Text.ToString();
			oInformePropiedad.Pedania = txtPedania.Text;
			oInformePropiedad.Departamento = txtDepartamento.Text.ToString();
			oInformePropiedad.PH = txtPH.Text.ToString();
			oInformePropiedad.Lote = txtLote.Text.ToString();
			oInformePropiedad.Manzana = txtManzana.Text.ToString();
			oInformePropiedad.Superficie = txtSuperficie.Text;
			oInformePropiedad.IdLocalidad = int.Parse(cmbLocalidad.SelectedValue);
			oInformePropiedad.IdProvincia = int.Parse(cmbProvincia.SelectedValue);			
			oInformePropiedad.Proporcion = "";
			oInformePropiedad.Gravamenes = txtGravamenes.Text;
            oInformePropiedad.InformesAnteriores = txtInformesAnteriores.Text;
			oInformePropiedad.Observaciones = txtObservaciones.Text;
			//oInformePropiedad.Morosidad = txtMorosidad.Text;
			oInformePropiedad.Resultado = txtResultado.Text;
            oInformePropiedad.PropiedadDe = txtPropiedadDe.Text;
            oInformePropiedad.UbicadaEn = txtUbicadaEn.Text;
            oInformePropiedad.DominioAntecedente = txtDominioAntecedente.Text;

			if(int.Parse(idReferencia.Value) == 0)
				ret = oInformePropiedad.Crear();
			else
				ret = oInformePropiedad.Modificar(int.Parse(idInformePropiedad.Value));

            if (!ret)
            {
                string strScript;
                strScript = "<script languaje=\"Javascript\">";
                strScript += "alert('Ocurrió un error al guardar el informe!');";
                strScript += "</script>";
                Page.RegisterStartupScript("OK", strScript);
            }
            else
                idReferencia.Value = (1).ToString();
		}

		#endregion

		#region CargarComboLocalidades(DropDownList comboProvincias, DropDownList comboLocalidades, int IdLocalidad)

		private void CargarComboLocalidades(DropDownList comboProvincias, DropDownList comboLocalidades, string IdLocalidad)
		{
			UtilesApp Tipos = new UtilesApp();
			comboLocalidades.Items.Clear();
			DataTable myTb;
			myTb = Tipos.TraerLocalidades(int.Parse(comboProvincias.SelectedItem.Value));
			ListItem myItem;
			foreach(DataRow myRow in myTb.Rows)
			{
				myItem = new ListItem(myRow[1].ToString(), myRow[0].ToString());
				if(IdLocalidad == myRow[0].ToString())
				{
					comboLocalidades.SelectedIndex = -1;
					myItem.Selected = true;
				}
				comboLocalidades.Items.Add(myItem);
			}
		}

		#endregion

		#region CargarComboProvincias(DropDownList comboProvincia, int IdProvincia)
		
		private void CargarComboProvincias(DropDownList comboProvincia, int IdProvincia)
		{
			UtilesApp Tipos = new UtilesApp();
			comboProvincia.Items.Clear();
			DataTable myTb;
			myTb = Tipos.TraerProvincias();
			ListItem myItem;
			foreach(DataRow myRow in myTb.Rows)
			{
				myItem = new ListItem(myRow[1].ToString(), myRow[0].ToString());
				if(IdProvincia == int.Parse(myRow[0].ToString()))
				{
					comboProvincia.SelectedIndex = -1;
					myItem.Selected = true;
				}
				comboProvincia.Items.Add(myItem);
			}
		}

		#endregion

		#region ControlarSolicitudesMatricula (int idInforme)
        private void ControlarSolicitudesMatricula(int id, int tipoInforme, int tipoPropiedad, int idProvincia, string leg, string folio, string tomo, string ano)
		{
			// Si no están anotadas las solicitudes anteriores...
            //if (txtInformesAnteriores.Text.StartsWith("MATRICULA SOLICITADA ANTERIORMENTE:") == false)
            if (txtInformesAnteriores.Text == "")
            {
                // Busco las solicitudes anteriores de la matrícula...
                int idInforme = id;

                string legajo = leg;
                string mensaje = "";//"MATRICULA SOLICITADA ANTERIORMENTE: \r";
                    
                // Si el informe tiene nºro de matrícula
                DataTable solicitudes = null;
                switch (tipoPropiedad)
                {
                    case 1: solicitudes = ControlMatriculasDal.ControlarMatricula(idInforme, tipoInforme, tipoPropiedad, idProvincia, legajo);
                            break;
                    case 2: solicitudes = ControlMatriculasDal.ControlarMatricula(idInforme, tipoInforme, tipoPropiedad, idProvincia, legajo, tomo, folio, ano);
                            break;
                    case 3: solicitudes = ControlMatriculasDal.ControlarMatricula(idInforme, tipoInforme, tipoPropiedad, idProvincia, legajo, tomo, folio, ano);
                            break;
                }
                if ( solicitudes != null && solicitudes.Rows.Count != 0)
                {
                    int idCliente = -1;
                    mensaje += "CONSULTADO ANTERIORMENTE POR: ";
                    foreach (DataRow solicitud in solicitudes.Rows)
                    {
                        bool cambio = false;
                        if (idCliente == -1)
                        {
                            mensaje += solicitud[1].ToString() + ", ";
                            idCliente = int.Parse(solicitud[2].ToString());
                            cambio = true;
                        }
                        if (idCliente != int.Parse(solicitud[2].ToString()))
                        {
                            //mensaje += "\r";
                            mensaje += " - ";
                            mensaje += solicitud[1].ToString() + ", ";
                            idCliente = int.Parse(solicitud[2].ToString());
                            cambio = true;
                        }
                        if (!cambio) mensaje += ", ";
                        mensaje += (solicitud[0].ToString()).Substring(0,10);
                    }
                    txtInformesAnteriores.Text = mensaje += "\r" + txtInformesAnteriores.Text;
                }
            }
			txtInformesAnteriores.Text = esVacio(txtInformesAnteriores.Text);
		}
		#endregion



        #region ControlarInformesTransferidos(int idEncabezado)
        private void ControlarInformesTransferidos(int idEncabezado)
        {
            //string strTransferidos = "";
            string mensaje = "";


            DataTable solicitudTransferida = null;
            solicitudTransferida = ControlInformeTransferidoDal.ControlVieneTransferidoInforme(idEncabezado);


            if (solicitudTransferida != null && solicitudTransferida.Rows.Count != 0)
            {
                mensaje += "VIENE DE INFORME TRANSFERIDO: \r";
                foreach (DataRow solicitud2 in solicitudTransferida.Rows)
                {

                    //mensaje += "; ";
                    mensaje += solicitud2[1].ToString().Replace("<B>", "").Replace("</B>", "").Replace("NO REGISTRA", "");
                    mensaje += "\r";
                    //mensaje += (solicitud[0].ToString()).Substring(0, 10);
                }
                txtObservaciones.Text = mensaje;
            }
            //txtObservaciones.Text = esVacio(strTransferidos);

            // Si el informe tiene nºro de matrícula
            DataTable solicitudes = null;
            solicitudes = ControlInformeTransferidoDal.ControlInformesTransferidos(idEncabezado);
            

            if (solicitudes != null && solicitudes.Rows.Count != 0)
            {
                mensaje += "INFORMES TRANSFERIDOS A: ";
                foreach (DataRow solicitud in solicitudes.Rows)
                {
                    mensaje += "\r";
                    //mensaje += "; ";
                    mensaje += solicitud[1].ToString().Replace("<B>", "").Replace("</B>", "").Replace("NO REGISTRA", "");
                    //mensaje += (solicitud[0].ToString()).Substring(0, 10);
                }
                txtObservaciones.Text = mensaje;
            }


            
        }
        #endregion


        #region CargarEncabezado(EncabezadoApp oEncabezado)

        private void CargarEncabezado(EncabezadoApp oEncabezado)
		{
			//Visualiza el icono de traer más datos			
			SelectTipoPropiedad(oEncabezado.PropTipo);					
			idTipoProp.Value = oEncabezado.PropTipo.ToString();
			txtLegajo.Text = oEncabezado.Matricula;
			txtFolio.Text = oEncabezado.PropFolio;
			txtTomo.Text = oEncabezado.PropTomo;
			txtAno.Text = oEncabezado.PropAno;
			CargarComboProvincias(cmbProvincia, 2);
			CargarComboLocalidades(cmbProvincia, cmbLocalidad, "1");
            txtGravamenes.Text = esVacio("");
            //txtInformesAnteriores.Text = esVacio("");
            txtObservaciones.Text = esVacio("");
            //txtMorosidad.Text = esVacio("");
		}

		#endregion
		
		#region CargarForm(InformePropiedadApp oInformePropiedad)

		private void CargarForm(InformePropiedadApp oInformePropiedad)
		{
			idInformePropiedad.Value= oInformePropiedad.IdInforme.ToString();
			txtLegajo.Text= oInformePropiedad.Matricula;
			idTipoProp.Value = oInformePropiedad.TipoProp.ToString();
			txtFolio.Text = oInformePropiedad.Folio;
			txtTomo.Text = oInformePropiedad.Tomo;
			txtAno.Text = oInformePropiedad.Ano;
			SelectTipoPropiedad(oInformePropiedad.TipoProp);
			txtBarrio.Text= oInformePropiedad.Barrio;
			txtPedania.Text= oInformePropiedad.Pedania;
			CargarComboProvincias(cmbProvincia, oInformePropiedad.IdProvincia);
			CargarComboLocalidades(cmbProvincia, cmbLocalidad, oInformePropiedad.IdLocalidad.ToString());
			txtDepartamento.Text= oInformePropiedad.Departamento;
			txtPH.Text = oInformePropiedad.PH;
			txtLote.Text = oInformePropiedad.Lote;
			txtManzana.Text = oInformePropiedad.Manzana;
			txtSuperficie.Text = oInformePropiedad.Superficie;
			txtGravamenes.Text = esVacio(oInformePropiedad.Gravamenes);
            txtInformesAnteriores.Text = oInformePropiedad.InformesAnteriores;
            if(txtObservaciones.Text != "")
			    txtObservaciones.Text = oInformePropiedad.Observaciones;
            else
                txtObservaciones.Text = esVacio(oInformePropiedad.Observaciones);
			//txtMorosidad.Text = esVacio(oInformePropiedad.Morosidad);
			txtResultado.Text = oInformePropiedad.Resultado;
            txtPropiedadDe.Text = oInformePropiedad.PropiedadDe.ToUpper();
            txtUbicadaEn.Text = oInformePropiedad.UbicadaEn.ToUpper();
            txtDominioAntecedente.Text = oInformePropiedad.DominioAntecedente.ToUpper();

            EncabezadoApp oEncabezado = new EncabezadoApp();
            //CargarEncabezado(oEncabezado);
            oEncabezado.Leido = 1;
            oEncabezado.CambiarLeido(oInformePropiedad.IdInforme);

		}

		#endregion

		#region ListarTitulares(int idInforme)

		private void ListarTitulares(int idInforme)
		{
			InformePropiedadApp objInformePropiedad = new InformePropiedadApp();
			dgTitulares.DataSource = objInformePropiedad.TraerTitulares(idInforme);
			dgTitulares.DataBind();
		}

		#endregion
		
		#region LoadInformePropiedad(int Id)

		private void LoadInformePropiedad(int Id)
		{
			InformePropiedadApp oInformePropiedad = new InformePropiedadApp();
            EncabezadoApp oEncabezado = new EncabezadoApp();
            oEncabezado.cargarEncabezado(Id);
            CargarDatosContacto(oEncabezado);

            cargarPaneles(oEncabezado.PropTipo);

            bool cargar = oInformePropiedad.cargarInformePropiedad(Id);

			if (cargar)
			{
				idReferencia.Value = (1).ToString();
				CargarForm(oInformePropiedad);
				ControlarSolicitudesMatricula(Id, oEncabezado.IdTipoInforme, oInformePropiedad.TipoProp, oInformePropiedad.IdProvincia, oInformePropiedad.Matricula, oInformePropiedad.Folio, oInformePropiedad.Tomo, oInformePropiedad.Ano);
			}
			else
			{
				idReferencia.Value = (0).ToString();
				CargarEncabezado(oEncabezado);
				ControlarSolicitudesMatricula(Id, oEncabezado.IdTipoInforme, oEncabezado.PropTipo, oEncabezado.ProvinciaOtra, oEncabezado.Matricula, oEncabezado.PropFolio, oEncabezado.PropTomo, oEncabezado.PropAno);
                ControlarInformesTransferidos(Id);
			}
		}

		#endregion

        
        #region void CargarDatosContacto(EncabezadoApp enc)

        private void CargarDatosContacto(EncabezadoApp enc)
        {
            lblEncTelefono.Text = enc.AMBTelefono;
            lblEncMail.Text = enc.AMBEMail;
            lblEncApeCon.Text = enc.ApellidoCony;
            lblEncNomCon.Text = enc.NombreCony;
            lblEncNroDocCon.Text = enc.AMBDocumento;
            TipoDocumentoApp objTipoDocumento = new TipoDocumentoApp();
            DataTable dtTipoDoc = objTipoDocumento.TraerDatos();
            foreach (DataRow myRow in dtTipoDoc.Rows)
            {
                if (enc.AMBTipoDoc == int.Parse(myRow[0].ToString()))
                {
                    lblEncTipoDocCon.Text = myRow[1].ToString();
                    break;
                }
            }
            lblEncObservaciones.Text = enc.Comentarios;
        }

        #endregion


        void cargarPaneles(int tipoPropiedad)
        {
            if (tipoPropiedad != 4)
            {
                pnUbicacion.Visible = true;
                pnTitulares.Visible = true;
                pnGravamenes.Visible = true;
                pnInformesAnteriores.Visible = true;
                pnResultado.Visible = true;
                pnPlanilla.Visible = false;

            }
            else
            {
                pnUbicacion.Visible = false;
                pnTitulares.Visible = false;
                pnGravamenes.Visible = false;
                pnInformesAnteriores.Visible = false;
                pnResultado.Visible = false;
                pnPlanilla.Visible = true;
            }
        }
        
        #region SelectTipoPropiedad(int idTipo)

        private void SelectTipoPropiedad(int idTipo)
		{
			switch(idTipo)
			{
				case 1:
				{
					lblFolio.Visible = false;
					txtFolio.Visible = false;
					lblAno.Visible = false;
					txtAno.Visible = false;
					lblTomo.Visible = false;
					txtTomo.Visible = false;
					lblTipoPropiedad.Text = "Nro. de Matricula";
					break;
				}
				case 2: 
				{
					lblTipoPropiedad.Text = "Dominio";
					break;
				}
				case 3: 
				{
					lblTipoPropiedad.Text = "Nro. de Legajo Especial";
					break;
				}
                case 4:
                {
                    lblFolio.Visible = false;
                    txtFolio.Visible = false;
                    lblAno.Visible = false;
                    txtAno.Visible = false;
                    lblTomo.Visible = false;
                    txtTomo.Visible = false;
                    lblTipoPropiedad.Text = "Planilla de subdivision Nº:";
                    break;
                }
			}
		}

		#endregion

        #region CambiarEstado(int idEstado)
        private void CambiarEstado(int idEstado)
        {
            EncabezadoApp Encabezado = new EncabezadoApp();
            Encabezado.cargarEncabezado(int.Parse(idInformePropiedad.Value));

            // Usuario Logueado
            UsuarioAutenticado Usuario = (UsuarioAutenticado)Session["UsuarioAutenticado"];
            Encabezado.IdUsuario = Usuario.IdUsuario;

            Encabezado.Estado = idEstado;
            Encabezado.CambiarEstado(int.Parse(idInformePropiedad.Value));
        }
        #endregion

        #endregion

        #region Eventos

        #region Aceptar_Click(object sender, EventArgs e)

        protected void Aceptar_Click(object sender, EventArgs e)
		{
			ActualizarInforme();
            CambiarEstado(7);		
			//Response.Redirect("/BandejaEntrada/Principal.aspx?idTipo=1");
		}

		#endregion

		#region AceptarFinalizar_Click(object sender, System.EventArgs e)
			
		protected void AceptarFinalizar_Click(object sender, System.EventArgs e)
		{
			string strScript;
			strScript = "<script languaje=\"Javascript\">";
            strScript += "window.showModalDialog('/BandejaEntrada/PopUpCambioEstado.aspx?idTipo=1&idInforme=" + idInformePropiedad.Value + "&Finalizar=1','','dialogWidth:400px;dialogHeight:250px');";
			strScript += "document.location.href = '/BandejaEntrada/Principal.aspx?idTipo=1'";
			strScript += "</script>";

			ActualizarInforme();
			Page.RegisterStartupScript("CambiarEstado", strScript);
		}

		#endregion

		#region Cancelar_Click(object sender, EventArgs e)

		protected void Cancelar_Click(object sender, EventArgs e)
		{
			if (idReferencia.Value == "0")
				InformePropiedadApp.BorrarTitulares(int.Parse(idInformePropiedad.Value));
			Response.Redirect("/BandejaEntrada/Principal.aspx?idTipo=1");
		}

		#endregion

		#region dgTitulares_ItemCommand(object source, DataGridCommandEventArgs e)

		private void dgTitulares_ItemCommand(object source, DataGridCommandEventArgs e)
		{
			if (e.Item.Cells[0].Text != "")
			{
				switch(((ImageButton)e.CommandSource).CommandName)
				{
					case "Borrar":
						InformePropiedadApp objInformePropiedad = new InformePropiedadApp();
						bool borrar = objInformePropiedad.BorrarTitular(Convert.ToInt32(e.Item.Cells[0].Text));
						break;
				}
				ListarTitulares(int.Parse(idInformePropiedad.Value));
			}

		}

		#endregion

		#region dgTitulares_PreRender(object sender, System.EventArgs e)

		protected void dgTitulares_PreRender(object sender, System.EventArgs e)
		{
			foreach(DataGridItem myItem in dgTitulares.Items)
			{
				if (int.Parse(myItem.Cells[1].Text) == 2)
				{
					myItem.Cells[2].Text = myItem.Cells[8].Text;
					myItem.Cells[3].Text = myItem.Cells[10].Text;
				}
			    ((ImageButton)myItem.FindControl("Editar")).Attributes.Add("onclick", "javascript: EditarTitular('" + myItem.Cells[0].Text + "');");
				((ImageButton) myItem.FindControl("Borrar")).Attributes.Add("onclick", @"javascript: return confirm('¿Está seguro que desea eliminar el Titular?');");
			}
		}

		#endregion

        #region cmbProvincia_SelectedIndexChanged(object sender, System.EventArgs e)
        protected void cmbProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarComboLocalidades(cmbProvincia, cmbLocalidad, "");
            cmbProvincia.Focus();
        }

        #endregion
        

#endregion



    public string esVacio(string txt)
    {
        if (txt == "")
        { return "NO REGISTRA"; }
        else
        { return txt;}
    }


protected void  btnImprimir_Click(object sender, EventArgs e)
{
    ActualizarInforme();
    CambiarEstado(7);		

    string strScript;
	strScript = "<script languaje=\"Javascript\">";
    strScript += "window.open('/InformePropiedad/VerInforme.aspx?id=" + idInformePropiedad.Value + "&IdTipo=1','','tools=no,width=720,menus=no,scrollbars=yes');";
	//strScript += "return false;";
	strScript += "</script>";
	Page.RegisterStartupScript("Imprimir", strScript);
}
protected void hAccion_ValueChanged(object sender, EventArgs e)
{
    ListarTitulares(int.Parse(idInformePropiedad.Value));
    hAccion.Value = "0";
    btnNuevo.Focus();
}

protected void Rechazar_Click(object sender, EventArgs e)
{
    string strScript;
    strScript = "<script languaje=\"Javascript\">";
    strScript += "window.showModalDialog('/BandejaEntrada/PopUpCambioEstado.aspx?idTipo=1&idInforme=" + idInformePropiedad.Value + "&Rechazar=1','','dialogWidth:400px;dialogHeight:250px');";
    strScript += "document.location.href = '/BandejaEntrada/Principal.aspx?idTipo=1'";
    strScript += "</script>";

    Page.RegisterStartupScript("CambiarEstado", strScript);
}
}
}
