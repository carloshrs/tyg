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
using System.Globalization;
//using System.Globalization;
//using System.IO;


namespace ar.com.TiempoyGestion.FrontEnd.Intranet.socioAmbiental
{
	/// <summary>
	/// Summary description for altaInforme.
	/// </summary>
	public partial class Informe : Page
	{
		protected TextBox Provincia;
		protected Image Image1;
		protected Image Image2;
		protected Image Image3;
		protected Image Image4;
		protected Label lblObservaciones;
		protected Button Cerrar;
		protected Label Label2;
		protected Label Label8;
		protected TextBox txtMovParticular;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidConFoto;
	    


        protected void Page_Load(object sender, EventArgs e)
		{
            Response.Write("<script>var menu = 0;</script>");
            Response.Write("<script>var mostrarenc = " + hdEncAbierto.Value + ";</script>");
            menuTab.Items[0].Selected = true;
            idInforme.Value = Request.QueryString["id"];
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    CargarCampos(raTipoVivienda, 7, -1);
                    CargarCampos(raEstadoCons, 6, -1);
                    CargarCampos(raTipoConstruccion, 8, -1);
                    CargarCampos(raTipoZona, 9, -1);
                    CargarCampos(raTipoCalle, 10, -1);
                    CargarCampos(raInteresado, 11, -1);
                    LoadInfAmbiental(int.Parse(idInforme.Value));
                }

                imgCheckPersona.Attributes.Add("onClick", "Javascript:ChequearPersona();return false;");
                //hypMasFotos.Attributes.Add("onClick", "javascript:mostrarImagenes('/Admin/Imagenes/AbmImagenes.aspx?Informe=" + idInforme.Value + "');");
            }
            /*else
            {
                InformeAmbiental oInfAmb = new InformeAmbiental();
                bool cargar = oInfAmb.Cargar(int.Parse(idInforme.Value));
                if (cargar)
                    idReferencia.Value = (1).ToString();
                else
                    idReferencia.Value = (0).ToString();
            }*/
            CargarImagen();
		}

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

		}
		#endregion

		private void LoadInfAmbiental(int Id)
		{
            InformeAmbiental oInfAmb = new InformeAmbiental();
			EncabezadoApp oEncabezado = new EncabezadoApp();
			oEncabezado.cargarEncabezado(Id);
            CargarDatosContacto(oEncabezado);
			ViewState["ConFoto"] = true;
            if (oEncabezado.ConFoto == 1)
            {
                pnlImagenes.Visible = true;
                hypMasFotos.Attributes.Add("onClick", "javascript:mostrarImagenes('/Admin/Imagenes/AbmImagenes.aspx?Informe=" + oEncabezado.IdEncabezado.ToString() + "');");
                CargarImagen();
            }
            else
                pnlImagenes.Visible = false;

            bool cargar = oInfAmb.Cargar(Id);
			if (cargar)
			{
				idReferencia.Value = (1).ToString();
				CargarTipoDocumento(-1);
				CargarEstadoCivil(-1);
				CargarForm(oInfAmb);
			}
			else
			{
				idReferencia.Value = (0).ToString();
				CargarEncabezado(oEncabezado);
                oEncabezado.Leido = 1;
                oEncabezado.CambiarLeido(Id);
			}
		}

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

		private void CargarEncabezado(EncabezadoApp oEncabezado)
		{
			idTipoPersona.Value = oEncabezado.IdTipoPersona.ToString();
            //idReferencia.Value = oEncabezado.idReferencia.ToString();
			txtNombre.Text = oEncabezado.Nombre;
			txtApellido.Text = oEncabezado.Apellido;
			CargarComboProvincias(cmbProvincia, oEncabezado.Provincia);
			CargarComboLocalidades(cmbProvincia, cmbLocalidad, oEncabezado.Localidad.ToString());
			CargarTipoDocumento(oEncabezado.TipoDocumento);
			CargarEstadoCivil(oEncabezado.EstadoCivil);
			txtDocumento.Text = oEncabezado.Documento;
			txtCalle.Text = oEncabezado.Calle;
			txtBarrio.Text = oEncabezado.Barrio;
			txtNro.Text = oEncabezado.Nro;
			txtPiso.Text = oEncabezado.Piso;
			txtDepto.Text = oEncabezado.Dpto;
			txtCP.Text = oEncabezado.CP;
			txtTelefono.Text = oEncabezado.AMBTelefono;
            if (oEncabezado.ApellidoCony != "" && oEncabezado.NombreCony != "")
            {
                cmbPersPar1.SelectedValue = "1";
                txtPersApe1.Text = oEncabezado.ApellidoCony + " " + oEncabezado.NombreCony;
            }
            //hidConFoto.Value = oEncabezado.ConFoto.ToString();
			//mostrarFoto(oEncabezado.ConFoto);
			
			
			//EMPRESA
			//RazonSocial.Text = oEncabezado.RazonSocial;
			//NombreFantasia.Text = oEncabezado.NombreFantasia;
			//Telefono.Text = oEncabezado.TelefonoEmpresa;
			//Rubro.Text = oEncabezado.Rubro;
			//Cuit.Text = oEncabezado.Cuit;
			//CalleEmpresa.Text = oEncabezado.CalleEmpresa;
			//NroEmpresa.Text = oEncabezado.NroEmpresa;
			//DptoEmpresa.Text = oEncabezado.DptoEmpresa;
			//PisoEmpresa.Text = oEncabezado.PisoEmpresa;
			//BarrioEmpresa.Text = oEncabezado.BarrioEmpresa;
			//CPEmpresa.Text = oEncabezado.CPEmpresa;
			// Empresas
			//CargarComboProvincias(cmbProvinciaEmpresas, oEncabezado.ProvinciaEmpresa);
			//CargarComboLocalidades(cmbProvinciaEmpresas, cmbLocalidadEmpresas, oEncabezado.LocalidadEmpresa.ToString());
            
		}


        private void CargarForm(InformeAmbiental oInfAmb)
		{
			CultureInfo myInfo = new CultureInfo("es-AR");

			idInforme.Value= oInfAmb.IdEncabezado.ToString();
			txtNombre.Text= oInfAmb.Nombre;
			txtApellido.Text = oInfAmb.Apellido;
			CargarTipoDocumento(oInfAmb.TipoDocumento);
			CargarEstadoCivil(oInfAmb.EstadoCivil);
			txtDocumento.Text = oInfAmb.Documento;
			txtCalle.Text= oInfAmb.Calle;
			txtBarrio.Text= oInfAmb.Barrio;
			txtNro.Text= oInfAmb.Nro;
			txtPiso.Text= oInfAmb.Piso;
			txtDepto.Text= oInfAmb.Depto;
			txtCP.Text= oInfAmb.CP;
			txtTelefono.Text= oInfAmb.Telefono;
			CargarComboProvincias(cmbProvincia, oInfAmb.Provincia);
			CargarComboLocalidades(cmbProvincia, cmbLocalidad, oInfAmb.Localidad.ToString());
            txtPersACargo.Text = oInfAmb.PersACargo;
            txtTieneHijos.Text = oInfAmb.TieneHijos;
            txtPersApe1.Text = oInfAmb.PersApe1;
            cmbPersPar1.SelectedValue = oInfAmb.PersPar1.ToString();
            txtPersEdad1.Text = oInfAmb.PersEdad1;
            txtPersApe2.Text = oInfAmb.PersApe2;
            cmbPersPar2.SelectedValue = oInfAmb.PersPar2.ToString();
            txtPersEdad2.Text = oInfAmb.PersEdad2;
            txtPersApe3.Text = oInfAmb.PersApe3;
            cmbPersPar3.SelectedValue = oInfAmb.PersPar3.ToString();
            txtPersEdad3.Text = oInfAmb.PersEdad3;
            txtPersApe4.Text = oInfAmb.PersApe4;
            cmbPersPar4.SelectedValue = oInfAmb.PersPar4.ToString();
            txtPersEdad4.Text = oInfAmb.PersEdad4;
            txtPersApe5.Text = oInfAmb.PersApe5;
            cmbPersPar5.SelectedValue = oInfAmb.PersPar5.ToString();
            txtPersEdad5.Text = oInfAmb.PersEdad5;
            txtObservacionesPersonales.Text = oInfAmb.ObsPersonales;
            rbtMovPropia.SelectedValue = oInfAmb.MovPropia.ToString();
            rbtMovMultas.SelectedValue = oInfAmb.MovMultas.ToString();
            txtMovCuantas.Text = oInfAmb.MovCuantas;
            txtAutomoto.Text = oInfAmb.Automoto;
            txtEstadoAutomoto.Text = oInfAmb.EstadoAutomoto;
            txtModeloAuto.Text = oInfAmb.ModeloAuto;
            txtAnioAuto.Text = oInfAmb.AnioAuto;
            txtPatenteAuto.Text = oInfAmb.PatenteAuto;
            txtSeguroAuto.Text = oInfAmb.SeguroAuto;
            txtCompaniaAuto.Text = oInfAmb.CompaniaAuto;
            txtOtrosMedios.Text = oInfAmb.OtrosMedios;
            txtCalidadMedios.Text = oInfAmb.CalidadMedios;

            txtEstPrimario.Text = oInfAmb.EstPrimario;
            txtEstabPrimario.Text = oInfAmb.EstabPrimario;
            txtTitPrimario.Text = oInfAmb.TitPrimario;
            txtEstSecundario.Text = oInfAmb.EstSecundario;
            txtEstabSecundario.Text = oInfAmb.EstabSecundario;
            txtTitSecundario.Text = oInfAmb.TitSecundario;
            txtEstTerciario.Text = oInfAmb.EstTerciario;
            txtEstabTerciario.Text = oInfAmb.EstabTerciario;
            txtTitTerciario.Text = oInfAmb.TitTerciario;
            txtEstUniversitario.Text = oInfAmb.EstUniversitario;
            txtEstabUniversitario.Text = oInfAmb.EstabUniversitario;
            txtTitUniversitario.Text = oInfAmb.TitUniversitario;
            txtOtrosCursos.Text = oInfAmb.OtrosCursos;
            txtIdiomas.Text = oInfAmb.Idiomas;
            txtComputacion.Text = oInfAmb.Computacion;

            txtEmpresa1.Text = oInfAmb.Empresa1;
            txtDomEmpresa1.Text = oInfAmb.DomEmpresa1;
            txtTelEmpresa1.Text = oInfAmb.TelEmpresa1;
            if (!oInfAmb.FecIngEmpresa1.Equals(""))
                txtFecIngEmpresa1.Text = DateTime.Parse(oInfAmb.FecIngEmpresa1).ToString("dd/MM/yyyy", DateTimeFormatInfo.InvariantInfo);
            if (!oInfAmb.FecEgEmpresa1.Equals(""))
                txtFecEgEmpresa1.Text = DateTime.Parse(oInfAmb.FecEgEmpresa1).ToString("dd/MM/yyyy", DateTimeFormatInfo.InvariantInfo); 
            txtCargoEmpresa1.Text = oInfAmb.CargoEmpresa1;
            txtUltSueldoEmpresa1.Text = oInfAmb.UltSueldoEmpresa1;
            txtDesvEmpresa1.Text = oInfAmb.DesvEmpresa1;
            txtContactoEmpresa1.Text = oInfAmb.ContactoEmpresa1;

            txtEmpresa2.Text = oInfAmb.Empresa2;
            txtDomEmpresa2.Text = oInfAmb.DomEmpresa2;
            txtTelEmpresa2.Text = oInfAmb.TelEmpresa2;
            if( !oInfAmb.FecIngEmpresa2.Equals("") )
                txtFecIngEmpresa2.Text = DateTime.Parse(oInfAmb.FecIngEmpresa2).ToString("dd/MM/yyyy", DateTimeFormatInfo.InvariantInfo);
            if (!oInfAmb.FecEgEmpresa2.Equals(""))
            txtFecEgEmpresa2.Text = DateTime.Parse(oInfAmb.FecEgEmpresa2).ToString("dd/MM/yyyy", DateTimeFormatInfo.InvariantInfo);
            txtCargoEmpresa2.Text = oInfAmb.CargoEmpresa2;
            txtUltSueldoEmpresa2.Text = oInfAmb.UltSueldoEmpresa2;
            txtDesvEmpresa2.Text = oInfAmb.DesvEmpresa2;
            txtContactoEmpresa2.Text = oInfAmb.ContactoEmpresa2;

            txtRefLaborales.Text = oInfAmb.RefLaborales;
            rbtClub.SelectedValue = oInfAmb.ParteClub.ToString();
            txtClub.Text = oInfAmb.Club;
            txtDeportes.Text = oInfAmb.Deportes;
            rbtConstante.SelectedValue = oInfAmb.Constante.ToString();
            txtIPolitica.Text = oInfAmb.IPolitica;
            txtIReligiosa.Text = oInfAmb.IReligiosa;
            rbtGSocial.SelectedValue = oInfAmb.GSocial.ToString();
            rbtFuma.SelectedValue = oInfAmb.Fuma.ToString();
            rbtBebe.SelectedValue = oInfAmb.Bebe.ToString();
            rbtMedFijo.SelectedValue = oInfAmb.MedFijo.ToString();
            txtEnfermedades.Text = oInfAmb.Enfermedades;
            txtPoliciales.Text = oInfAmb.Policiales;
            txtComFinal.Text = oInfAmb.ComFinal;
            rbtTelevision.SelectedValue = oInfAmb.Television.ToString();
            txtPrograma.Text = oInfAmb.Programa;
            rbtLee.SelectedValue = oInfAmb.Lee.ToString();
            txtLee.Text = oInfAmb.QLee;
            txtTiempoLibre.Text = oInfAmb.TiempoLibre;
            rbtTiempoFamilia.SelectedValue = oInfAmb.TiempoFamilia.ToString();
            txtActFamiliar.Text = oInfAmb.ActFamiliar;

            txtAntiguedad.Text = oInfAmb.Antiguedad;
            txtMontoAlquiler.Text = oInfAmb.MontoAlquiler;
            if (!oInfAmb.Vencimiento.Equals(""))
                txtVencimiento.Text = DateTime.Parse(oInfAmb.Vencimiento).ToString("dd/MM/yyyy", DateTimeFormatInfo.InvariantInfo);
            txtTelAlt.Text = oInfAmb.TelAlt;
            txtAccesoDomicilio.Text = oInfAmb.AccesoDomicilio;
            txtCantTel.Text = oInfAmb.CantTel;
            rbtTipoTele.SelectedValue = oInfAmb.TipoTele.ToString();
            txtEmpresaCable.Text = oInfAmb.EmpresaCable;
            txtComputadora.Text = oInfAmb.Computadora;
            txtInternet.Text = oInfAmb.Internet;
            txtEmpresaInternet.Text = oInfAmb.EmpresaInternet;
            rbtTipoEmpresa.SelectedValue = oInfAmb.TipoEmpresa.ToString();

            txtNombreVecino.Text = oInfAmb.NombreVecino1;
            txtDomicilioVecino.Text = oInfAmb.DomicilioVecino1;
            txtConoceVecino.Text = oInfAmb.ConoceVecino1;
            txtNombreVecino2.Text = oInfAmb.NombreVecino2;
            txtDomicilioVecino2.Text = oInfAmb.DomicilioVecino2;
            txtConoceVecino2.Text = oInfAmb.ConoceVecino2;
            txtNombreVecino3.Text = oInfAmb.NombreVecino3;
            txtDomicilioVecino3.Text = oInfAmb.DomicilioVecino3;
            txtConoceVecino3.Text = oInfAmb.ConoceVecino3;

            txtObservaciones.Text = oInfAmb.Observaciones;
            txtPlanoA.Text = oInfAmb.PlanoA;
            txtPlanoB.Text = oInfAmb.PlanoB;
            txtPlanoC.Text = oInfAmb.PlanoC;
            txtPlanoD.Text = oInfAmb.PlanoD;

            CargarCampos(raTipoVivienda, 7, int.Parse(oInfAmb.TipoVivienda));
            CargarCampos(raEstadoCons, 6, int.Parse(oInfAmb.EstadoCons));
            CargarCampos(raTipoConstruccion, 8, int.Parse(oInfAmb.TipoConstruccion));
            CargarCampos(raTipoZona, 9, int.Parse(oInfAmb.TipoZona));
            CargarCampos(raTipoCalle, 10, int.Parse(oInfAmb.TipoCalle));
            CargarCampos(raInteresado, 11, int.Parse(oInfAmb.Interesado));
			
            
		}

		protected void Aceptar_Click(object sender, EventArgs e)
		{
			ActualizarInforme();
            Response.Write("<script>alert('Los datos se guardaron exitosamente');</script>");
			//Response.Redirect("/BandejaEntrada/Principal.aspx?idTipo=4");
            if (menuTab.SelectedItem != null)
                Response.Write("<script>menu = " + menuTab.SelectedItem.Value + ";</script>");
		}

		protected void Cancelar_Click(object sender, EventArgs e)
		{
			Response.Redirect("/BandejaEntrada/Principal.aspx?idTipo=4");
		}

		protected void cmbProvincia_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			CargarComboLocalidades(cmbProvincia, cmbLocalidad, "");
		}

		private void CargarComboProvincias(DropDownList comboProvincia, int IdProvincia)
		{
			UtilesApp Tipos = new UtilesApp();
			comboProvincia.Items.Clear();
			DataTable myTb;
			myTb = Tipos.TraerProvincias();
			ListItem myItem;
			foreach (DataRow myRow in myTb.Rows)
			{
				myItem = new ListItem(myRow[1].ToString(), myRow[0].ToString());
				if (IdProvincia == int.Parse(myRow[0].ToString()))
				{
					comboProvincia.SelectedIndex = -1;
					myItem.Selected = true;
				}
				comboProvincia.Items.Add(myItem);
			}
		}


		private void CargarComboLocalidades(DropDownList comboProvincias, DropDownList comboLocalidades, string IdLocalidad)
		{
			UtilesApp Tipos = new UtilesApp();
			comboLocalidades.Items.Clear();
			DataTable myTb;
			myTb = Tipos.TraerLocalidades(int.Parse(comboProvincias.SelectedItem.Value));
			ListItem myItem;
			foreach (DataRow myRow in myTb.Rows)
			{
				myItem = new ListItem(myRow[1].ToString(), myRow[0].ToString());
				if (IdLocalidad == myRow[0].ToString())
				{
					comboLocalidades.SelectedIndex = -1;
					myItem.Selected = true;
				}
				comboLocalidades.Items.Add(myItem);
			}
		}
			


		private void CargarTipoDocumento(int idTipo)
		{
			cmbTipoDocumento.Items.Clear();
			TipoDocumentoApp objTipoDocumento = new TipoDocumentoApp();
			DataTable dtTipoDoc = objTipoDocumento.TraerDatos();
			ListItem myItem;

			foreach(DataRow myRow in dtTipoDoc.Rows)
			{
				myItem = new ListItem(myRow[1].ToString(), myRow[0].ToString());
				if(idTipo == int.Parse(myRow[0].ToString()))
				{
					cmbTipoDocumento.SelectedIndex = -1;
					myItem.Selected = true;
				}
				cmbTipoDocumento.Items.Add(myItem);
			}
		}

		private void CargarEstadoCivil(int idEstado)
		{
            cmbEstadoCivil.Items.Clear();
			EstadoCivilApp objEstadoCivil = new EstadoCivilApp();
			DataTable dtEstadoCivil = objEstadoCivil.TraerDatos();
			ListItem myItem;

			foreach(DataRow myRow in dtEstadoCivil.Rows)
			{
				myItem = new ListItem(myRow[1].ToString(), myRow[0].ToString());
				if(idEstado == int.Parse(myRow[0].ToString()))
				{
					cmbEstadoCivil.SelectedIndex = -1;
					myItem.Selected = true;
				}
				cmbEstadoCivil.Items.Add(myItem);
			}
		}


		private void CargarCampos(RadioButtonList campo,int idTipo, int valor)
		{
			campo.Items.Clear();
			InformeAmbiental oInfAmb = new InformeAmbiental();
			DataTable dtTraerCampo = oInfAmb.TraerCampo(idTipo);
			ListItem myItem;

			foreach(DataRow myRow in dtTraerCampo.Rows)
			{
				myItem = new ListItem(" " + myRow[1].ToString(), myRow[0].ToString());
				if(valor == int.Parse(myRow[0].ToString()))
				{
					campo.SelectedIndex = -1;
					myItem.Selected = true;
				}
					campo.Items.Add(myItem);
			}
		}

		protected void AceptarFinalizar_Click(object sender, System.EventArgs e)
		{
			//EncabezadoApp oEncabezado = new EncabezadoApp();
			//oEncabezado.cargarEncabezado(int.Parse(idInforme.Value));
			string strScript;
			strScript = "<script languaje=\"Javascript\">";
            strScript += "window.showModalDialog('/BandejaEntrada/PopUpCambioEstado.aspx?idTipo=4&idInforme=" + idInforme.Value + "&Finalizar=1','','dialogWidth:400px;dialogHeight:250px');";
			strScript += "document.location.href = '/BandejaEntrada/Principal.aspx?idTipo=4'";
			strScript += "</script>";
            ActualizarInforme();
			Page.RegisterStartupScript("CambiarEstado", strScript);
		}

		private void ActualizarInforme()
		{
            bool estado = false;
			InformeAmbiental oInfAbm = new InformeAmbiental();
			bool cargar = oInfAbm.Cargar(int.Parse(idInforme.Value));
			// Usuario Logueado
			UsuarioAutenticado Usuario = (UsuarioAutenticado)Session["UsuarioAutenticado"];
			oInfAbm.IdCliente = Usuario.IdCliente;
			oInfAbm.IdUsuario = Usuario.IdUsuario;
			oInfAbm.IdEncabezado = int.Parse(idInforme.Value);
			oInfAbm.Nombre = txtNombre.Text;
			oInfAbm.Apellido = txtApellido.Text;
			oInfAbm.TipoDocumento = int.Parse(cmbTipoDocumento.SelectedItem.Value);
			oInfAbm.Documento = txtDocumento.Text;
			oInfAbm.EstadoCivil = int.Parse(cmbEstadoCivil.SelectedValue);
			oInfAbm.Calle = txtCalle.Text;
			oInfAbm.Barrio = txtBarrio.Text;
			oInfAbm.Nro = txtNro.Text;
			oInfAbm.Piso = txtPiso.Text;
			oInfAbm.Depto = txtDepto.Text;
			oInfAbm.CP = txtCP.Text;
			oInfAbm.Telefono = txtTelefono.Text;
			oInfAbm.Provincia = int.Parse(cmbProvincia.SelectedValue);
			oInfAbm.Localidad = int.Parse(cmbLocalidad.SelectedValue);
            oInfAbm.PersACargo = txtPersACargo.Text;
            oInfAbm.TieneHijos = txtTieneHijos.Text;
            
            oInfAbm.PersApe1 = txtPersApe1.Text;
            oInfAbm.PersPar1 = int.Parse(cmbPersPar1.SelectedValue);
            oInfAbm.PersEdad1 = txtPersEdad1.Text;
            
            oInfAbm.PersApe2 = txtPersApe2.Text;
            oInfAbm.PersPar2 = int.Parse(cmbPersPar2.SelectedValue);
            oInfAbm.PersEdad2 = txtPersEdad2.Text;
            
            oInfAbm.PersApe3 = txtPersApe3.Text;
            oInfAbm.PersPar3 = int.Parse(cmbPersPar3.SelectedValue);
            oInfAbm.PersEdad3 = txtPersEdad3.Text;
            
            oInfAbm.PersApe4 = txtPersApe4.Text;
            oInfAbm.PersPar4 = int.Parse(cmbPersPar4.SelectedValue);
            oInfAbm.PersEdad4 = txtPersEdad4.Text;
            
            oInfAbm.PersApe5 = txtPersApe5.Text;
            oInfAbm.PersPar5 = int.Parse(cmbPersPar5.SelectedValue);
            oInfAbm.PersEdad5 = txtPersEdad5.Text;

            oInfAbm.ObsPersonales = txtObservacionesPersonales.Text;

            if(rbtMovPropia.SelectedValue != "")
                oInfAbm.MovPropia = int.Parse(rbtMovPropia.SelectedValue);
            if (rbtMovMultas.SelectedValue != "")
                oInfAbm.MovMultas = int.Parse(rbtMovMultas.SelectedValue);

            oInfAbm.MovCuantas = txtMovCuantas.Text;
            oInfAbm.Automoto = txtAutomoto.Text;
            oInfAbm.EstadoAutomoto = txtEstadoAutomoto.Text;
            oInfAbm.ModeloAuto = txtModeloAuto.Text;
            oInfAbm.AnioAuto = txtAnioAuto.Text;
            oInfAbm.PatenteAuto = txtPatenteAuto.Text;
            oInfAbm.SeguroAuto = txtSeguroAuto.Text;
            oInfAbm.CompaniaAuto = txtCompaniaAuto.Text;
            oInfAbm.OtrosMedios = txtOtrosMedios.Text;
            oInfAbm.CalidadMedios = txtCalidadMedios.Text;
            oInfAbm.EstPrimario = txtEstPrimario.Text;
            oInfAbm.EstabPrimario = txtEstabPrimario.Text;
            oInfAbm.TitPrimario = txtTitPrimario.Text;
            oInfAbm.EstSecundario = txtEstSecundario.Text;
            oInfAbm.EstabSecundario = txtEstabSecundario.Text;
            oInfAbm.TitSecundario = txtTitSecundario.Text;
            oInfAbm.EstTerciario = txtEstTerciario.Text;
            oInfAbm.EstabTerciario = txtEstabTerciario.Text;
            oInfAbm.TitTerciario = txtTitTerciario.Text;
            oInfAbm.EstUniversitario = txtEstUniversitario.Text;
            oInfAbm.EstabUniversitario = txtEstabUniversitario.Text;
            oInfAbm.TitUniversitario = txtTitUniversitario.Text;
            oInfAbm.OtrosCursos = txtOtrosCursos.Text;
            oInfAbm.Idiomas = txtIdiomas.Text;
            oInfAbm.Computacion = txtComputacion.Text;

            oInfAbm.Empresa1 = txtEmpresa1.Text;
            oInfAbm.DomEmpresa1 = txtDomEmpresa1.Text;
            oInfAbm.TelEmpresa1 = txtTelEmpresa1.Text;
            oInfAbm.FecIngEmpresa1 = txtFecIngEmpresa1.Text;
            oInfAbm.FecEgEmpresa1 = txtFecEgEmpresa1.Text;
            oInfAbm.CargoEmpresa1 = txtCargoEmpresa1.Text;
            oInfAbm.UltSueldoEmpresa1 = txtUltSueldoEmpresa1.Text;
            oInfAbm.DesvEmpresa1 = txtDesvEmpresa1.Text;
            oInfAbm.ContactoEmpresa1 = txtContactoEmpresa1.Text;

            oInfAbm.Empresa2 = txtEmpresa2.Text;
            oInfAbm.DomEmpresa2 = txtDomEmpresa2.Text;
            oInfAbm.TelEmpresa2 = txtTelEmpresa2.Text;
            oInfAbm.FecIngEmpresa2 = txtFecIngEmpresa2.Text;
            oInfAbm.FecEgEmpresa2 = txtFecEgEmpresa2.Text;
            oInfAbm.CargoEmpresa2 = txtCargoEmpresa2.Text;
            oInfAbm.UltSueldoEmpresa2 = txtUltSueldoEmpresa2.Text;
            oInfAbm.DesvEmpresa2 = txtDesvEmpresa2.Text;
            oInfAbm.ContactoEmpresa2 = txtContactoEmpresa2.Text;

            oInfAbm.RefLaborales = txtRefLaborales.Text;

            if( rbtClub.SelectedValue != "" )
                oInfAbm.ParteClub = int.Parse(rbtClub.SelectedValue);
            
            oInfAbm.Club = txtClub.Text;
            oInfAbm.Deportes = txtDeportes.Text;

            if (rbtConstante.SelectedValue != "")
                oInfAbm.Constante = int.Parse(rbtConstante.SelectedValue);

            oInfAbm.IPolitica = txtIPolitica.Text;
            oInfAbm.IReligiosa = txtIReligiosa.Text;

            if (rbtGSocial.SelectedValue != "")
                oInfAbm.GSocial = int.Parse(rbtGSocial.SelectedValue);
            if (rbtFuma.SelectedValue != "")
                oInfAbm.Fuma = int.Parse(rbtFuma.SelectedValue);
            if (rbtBebe.SelectedValue != "")
                oInfAbm.Bebe = int.Parse(rbtBebe.SelectedValue);
            if (rbtMedFijo.SelectedValue != "")
                oInfAbm.MedFijo = int.Parse(rbtMedFijo.SelectedValue);
            
            oInfAbm.Enfermedades = txtEnfermedades.Text;
            oInfAbm.Policiales = txtPoliciales.Text;
            oInfAbm.ComFinal = txtComFinal.Text;

            if (rbtTelevision.SelectedValue != "")
                oInfAbm.Television = int.Parse(rbtTelevision.SelectedValue);

            oInfAbm.Programa = txtPrograma.Text;

            if (rbtLee.SelectedValue != "")
                oInfAbm.Lee = int.Parse(rbtLee.SelectedValue);

            oInfAbm.QLee = txtLee.Text;
            oInfAbm.TiempoLibre = txtTiempoLibre.Text;

            if (rbtTiempoFamilia.SelectedValue != "")
                oInfAbm.TiempoFamilia = int.Parse(rbtTiempoFamilia.SelectedValue);

            oInfAbm.ActFamiliar = txtActFamiliar.Text;

            oInfAbm.Antiguedad = txtAntiguedad.Text;
            //oInfAbm.PropInq = txtPropInq.Text;
            oInfAbm.MontoAlquiler = txtMontoAlquiler.Text;
            oInfAbm.Vencimiento = txtVencimiento.Text;
            oInfAbm.TelAlt = txtTelAlt.Text;
            oInfAbm.AccesoDomicilio = txtAccesoDomicilio.Text;
            oInfAbm.TipoVivienda = raTipoVivienda.SelectedValue;
            oInfAbm.EstadoCons = raEstadoCons.SelectedValue;
            oInfAbm.TipoConstruccion = raTipoConstruccion.SelectedValue;
            oInfAbm.TipoZona = raTipoZona.SelectedValue;
            oInfAbm.TipoCalle = raTipoCalle.SelectedValue;
            oInfAbm.Interesado = raInteresado.SelectedValue;
            oInfAbm.CantTel = txtCantTel.Text;

            if( rbtTipoTele.SelectedValue != "" )
                oInfAbm.TipoTele = rbtTipoTele.SelectedValue;
            
            oInfAbm.EmpresaCable = txtEmpresaCable.Text;

            if (txtComputadora.SelectedValue != "")
                oInfAbm.Computadora = txtComputadora.SelectedValue;
            if (txtComputadora.SelectedValue != "")
                oInfAbm.Internet = txtInternet.SelectedValue;

            oInfAbm.EmpresaInternet = txtEmpresaInternet.Text;

            if (rbtTipoEmpresa.SelectedValue != "")
                oInfAbm.TipoEmpresa = rbtTipoEmpresa.SelectedValue;

            oInfAbm.NombreVecino1 = txtNombreVecino.Text;
            oInfAbm.DomicilioVecino1 = txtDomicilioVecino.Text;
            oInfAbm.ConoceVecino1 = txtConoceVecino.Text;
            oInfAbm.NombreVecino2 = txtNombreVecino2.Text;
            oInfAbm.DomicilioVecino2 = txtDomicilioVecino2.Text;
            oInfAbm.ConoceVecino2 = txtConoceVecino2.Text;
            oInfAbm.NombreVecino3 = txtNombreVecino3.Text;
            oInfAbm.DomicilioVecino3 = txtDomicilioVecino3.Text;
            oInfAbm.ConoceVecino3 = txtConoceVecino3.Text;

            oInfAbm.Observaciones = txtObservaciones.Text;
            oInfAbm.PlanoA = txtPlanoA.Text;
            oInfAbm.PlanoB = txtPlanoB.Text;
            oInfAbm.PlanoC = txtPlanoC.Text;
            oInfAbm.PlanoD = txtPlanoD.Text;

            if (int.Parse(idReferencia.Value) == 0)
            {
                estado = oInfAbm.Crear();
                if (estado)
                    idReferencia.Value = (1).ToString();
                else
                    idReferencia.Value = (0).ToString();
            }
            else
                estado = oInfAbm.Modificar(int.Parse(idInforme.Value));


		}

        protected void menuTab_MenuItemClick(object sender, MenuEventArgs e)
        {
            contenedor.ActiveViewIndex = Int32.Parse(e.Item.Value);
            e.Item.Selected = true;
            if (menuTab.SelectedItem != null)
                Response.Write("<script>menu = " + menuTab.SelectedItem.Value + ";</script>");
        }

        protected void dgFamiliares_PreRender(object sender, System.EventArgs e)
        {
            
            /*foreach (DataGridItem myItem in dgFamiliares.Items)
            {
                if (int.Parse(myItem.Cells[1].Text) == 2)
                {
                    myItem.Cells[2].Text = "J";
                    myItem.Cells[3].Text = myItem.Cells[8].Text + " de " + myItem.Cells[9].Text;
                    myItem.Cells[4].Text = myItem.Cells[11].Text;
                    myItem.Cells[5].Text = myItem.Cells[10].Text;
                }
                else
                {
                    myItem.Cells[2].Text = "F";
                }
                ((ImageButton)myItem.FindControl("Editar")).Attributes.Add("onclick", "window.showModalDialog('abmTitular.aspx?idInforme=" + idInforme.Value + "&IdTitular=" + myItem.Cells[0].Text + "&porc=" + myItem.Cells[6].Text + "&porcTotal='+document.Form1.totalPorcentaje.value+'' ,'','dialogWidth:510px;dialogHeight:300px');document.forms[0].submit();");
                ((ImageButton)myItem.FindControl("Borrar")).Attributes.Add("onclick", @"javascript: return confirm('¿Está seguro que desea eliminar el Titular?');");
                myItem.Cells[6].Text = myItem.Cells[6].Text + " %";
            }*/
        }
        protected void generales_Click(object sender, EventArgs e)
        {
            contenedor.ActiveViewIndex = 1;
            menuTab.Items[1].Selected = true;
            Response.Write("<script>menu = 1;</script>");
        }
        protected void personales_Click(object sender, EventArgs e)
        {
            contenedor.ActiveViewIndex = 0;
            menuTab.Items[0].Selected = true;
            Response.Write("<script>menu = 0;</script>");
        }
        protected void vivienda_Click(object sender, EventArgs e)
        {
            contenedor.ActiveViewIndex = 2;
            menuTab.Items[2].Selected = true;
            Response.Write("<script>menu = 2;</script>");
        }

        private void CargarImagen()
        {
            string vImagen = "/img/shim.gif";
            ImagenDal imagen = new ImagenDal();
            imagen.Cargar(int.Parse(idInforme.Value));
            if (imagen.Path != "")
                vImagen = imagen.Path;
            else
                imgFoto.BorderWidth = 0;
            imgFoto.ImageUrl = vImagen;
            imgFoto.ToolTip = imagen.Descripcion;
        }
    }
}
