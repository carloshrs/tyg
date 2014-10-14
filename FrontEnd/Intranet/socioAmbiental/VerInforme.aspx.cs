using System;
using System.Data;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;
using ar.com.TiempoyGestion.BackEnd.Clientes.Dal;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.Dal;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;
using ar.com.TiempoyGestion.BackEnd.Informes.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.socioAmbiental
{
	/// <summary>
	/// Summary description for altaInforme.
	/// </summary>
	public partial class verInforme : Page
	{
		protected RequiredFieldValidator reqNombre;
		protected RequiredFieldValidator reqApellido;
		protected DropDownList cmbEstadoCivil;
		protected DropDownList cmbTipoDocumento;
		protected RequiredFieldValidator RequiredFieldValidator2;
		protected RequiredFieldValidator RequiredFieldValidator3;
		protected RequiredFieldValidator RequiredFieldValidator6;
		protected RequiredFieldValidator RequiredFieldValidator7;
		protected DropDownList cmbProvincia;
		protected DropDownList cmbLocalidad;
		private int IdInforme;
	
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if(Request.QueryString["id"] != null)
				{	
					IdInforme = int.Parse(Request.QueryString["id"]);
					LoadInforme(IdInforme);
				}
                lblTools.Text = "<input onclick=\"imprimir();\" type=\"image\" src=\"/img/imprimir-2.gif\"> " +
					"<input onclick=\"window.close();\" type=\"image\" src=\"/img/log_off.gif\"> " +
					"<img src=\"/img/Eterno.gif\"> <input onclick=\"window.showModalDialog('/Admin/Imagenes/VerImagenes.aspx?Informe=" + IdInforme.ToString() + "', '', 'dialogWidth:640px;dialogHeight:480px');\" type=\"image\" src=\"/img/Imagenes.gif\" title=\"Ver más imágenes...\"> ";

			}

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

		private void LoadInforme(int Id)
		{
			InformeAmbiental oInfAmb = new InformeAmbiental();

			EncabezadoApp oEncabezado = new EncabezadoApp();
			oEncabezado.cargarEncabezado(Id);
			ClienteDal cliente = new ClienteDal();
			cliente.Cargar(oEncabezado.IdCliente);
			Usuario usuario = new Usuario();
			usuario.Cargar(oEncabezado.IdUsuario);
			/*if (oEncabezado.ConFoto == 1)
				CargarImagen(oEncabezado.IdEncabezado);
			else
				imgFoto.Visible = false;*/

            if (oEncabezado.ConFoto == 1)
            {
                pnFotos.Visible = true;
                CargarImagen(oEncabezado.IdEncabezado, 1);
                CargarImagen(oEncabezado.IdEncabezado, 2);
            }
            else
            {
                imgFoto.Visible = false;
                pnFotos.Visible = false;
                //lblNroPagina1.Visible = false;
            }

            bool cargar = oInfAmb.Cargar(Id);

			if (cargar)
			{
				lblNum.Text = Id.ToString();
				lblFec.Text = DateTime.Today.ToShortDateString();
                string solicitante = "";
                if (cliente.NombreFantasia != null && cliente.NombreFantasia != "")
                    solicitante = cliente.NombreFantasia;
                else
                    solicitante = cliente.RazonSocial;
                if (cliente.Sucursal != null && cliente.Sucursal != "")
                    solicitante = solicitante + " (" + cliente.Sucursal + ")";
                lblSolicitante.Text = solicitante;

                string direccion = "";
                direccion = cliente.Calle + " " + cliente.Numero;
                if (cliente.Piso != "")
                {
                    direccion = direccion + " Piso: " + cliente.Piso;
                    direccion = direccion + " Dpto/Of: " + cliente.Departamento;
                }
                direccion = direccion + ". " + cliente.Barrio;
                lblDireccionSolicitante.Text = direccion;

                if (oEncabezado.idReferencia != 0)
                    lblRef.Text = oEncabezado.NombreReferencia.ToUpper();
                else if (oEncabezado.UsuarioCliente != "")
                    lblRef.Text = oEncabezado.UsuarioCliente.ToUpper();
                else
                    lblRef.Text = usuario.Apellido.ToUpper() + ", " + usuario.Nombre.ToUpper();


                if (oEncabezado.ConFoto == 1)
                {
                    lblNumCopy.Text = lblNum.Text;
                    lblFecCopy.Text = lblFec.Text;
                    lblSolicitanteCopy.Text = lblSolicitante.Text;
                    lblDireccionSolicitanteCopy.Text = lblDireccionSolicitante.Text;
                    lblRefCopy.Text = lblRef.Text;
                    //lblNroPagina1.Text = "Página 1 de 2";
                    //lblNroPagina2.Text = "Página 2 de 2";
                }
				CargarForm(oInfAmb);
			}
			else
			{
				CargarEncabezado(oEncabezado);
			}

		}


		private void CargarEncabezado(EncabezadoApp oVerifDom)
		{
			lblNombre.Text= oVerifDom.Nombre;
			lblApellido.Text = oVerifDom.Apellido;
			lblTipoDocumento.Text = LoadTipoDNI(oVerifDom.TipoDocumento);
			lblEstadoCivil.Text = LoadEstadoCivil(oVerifDom.EstadoCivil);
			lblDocumento.Text = oVerifDom.Documento;
			lblCalle.Text= oVerifDom.Calle;
			lblBarrio.Text= oVerifDom.Barrio;
			lblNro.Text= oVerifDom.Nro;
			lblPiso.Text= oVerifDom.Piso;
			lblDepto.Text= oVerifDom.Dpto;
			lblCP.Text= oVerifDom.CP;
		}

        private string CargarParentezco(int parent)
        {
            switch (parent)
            {
                case 0: return "Ninguno"; break;
                case 1: return "Esposa/Concubina"; break;
                case 2: return "Padre"; break;
                case 3: return "Madre"; break;
                case 4: return "Hijo/a"; break;
                case 5: return "Abuelo/a"; break;
                case 6: return "Tio/a"; break;
                case 7: return "Otro"; break;
                default: return "";

            }
        }

        private string CargarRBT(int radio)
        {
            switch (radio)
            {
                case 2: return "SI";
                case 1: return "NO";
                default: return "";
            }
        }

		private void CargarForm(InformeAmbiental oInfAmb)
		{
			lblNombre.Text= oInfAmb.Nombre;
			lblApellido.Text = oInfAmb.Apellido;
			lblTipoDocumento.Text = LoadTipoDNI(oInfAmb.TipoDocumento);
			lblEstadoCivil.Text = LoadEstadoCivil(oInfAmb.EstadoCivil);
			lblDocumento.Text = oInfAmb.Documento;
			lblCalle.Text= oInfAmb.Calle;
			lblBarrio.Text= oInfAmb.Barrio;
			lblNro.Text= oInfAmb.Nro;
			lblPiso.Text= oInfAmb.Piso;
			lblDepto.Text= oInfAmb.Depto;
			lblCP.Text= oInfAmb.CP;
			lblTelefono.Text= oInfAmb.Telefono;
			lblProvincia.Text = CargarProvincias(oInfAmb.Provincia);
			lblLocalidad.Text = CargarLocalidades(oInfAmb.Provincia, oInfAmb.Localidad);
            lblPersACargo.Text = oInfAmb.PersACargo;
            lblTieneHijos.Text = oInfAmb.TieneHijos;
            
            lblPersApe1.Text = oInfAmb.PersApe1;
            lblPersPar1.Text = CargarParentezco(oInfAmb.PersPar1);
            lblPersEdad1.Text = oInfAmb.PersEdad1;
            
            lblPersApe2.Text = oInfAmb.PersApe2;
            lblPersPar2.Text = CargarParentezco(oInfAmb.PersPar2);
            lblPersEdad2.Text = oInfAmb.PersEdad2;
            
            lblPersApe3.Text = oInfAmb.PersApe3;
            lblPersPar3.Text = CargarParentezco(oInfAmb.PersPar3);
            lblPersEdad3.Text = oInfAmb.PersEdad3;
            
            lblPersApe4.Text = oInfAmb.PersApe4;
            lblPersPar4.Text = CargarParentezco(oInfAmb.PersPar4);
            lblPersEdad4.Text = oInfAmb.PersEdad4;
            
            lblPersApe5.Text = oInfAmb.PersApe5;
            lblPersPar5.Text = CargarParentezco(oInfAmb.PersPar5);
            lblPersEdad5.Text = oInfAmb.PersEdad5;

            lblObsPersonales.Text = oInfAmb.ObsPersonales;
            
            lblMovPropia.Text = CargarRBT(oInfAmb.MovPropia);
            lblMovMultas.Text = CargarRBT(oInfAmb.MovMultas);
            lblMovCuantas.Text = oInfAmb.MovCuantas;
            lblAutomoto.Text = oInfAmb.Automoto;
            lblEstadoAutomoto.Text = oInfAmb.EstadoAutomoto;
            lblModeloAuto.Text = oInfAmb.ModeloAuto;
            lblAnioAuto.Text = oInfAmb.AnioAuto;
            lblPatenteAuto.Text = oInfAmb.PatenteAuto;
            lblSeguroAuto.Text = oInfAmb.SeguroAuto;
            lblCompaniaAuto.Text = oInfAmb.CompaniaAuto;

            lblOtrosMedios.Text = oInfAmb.OtrosMedios;
            lblCalidadMedios.Text = oInfAmb.CalidadMedios;

            lblEstPrimario.Text = oInfAmb.EstPrimario;
            lblEstabPrimario.Text = oInfAmb.EstabPrimario;
            lblTitPrimario.Text = oInfAmb.TitPrimario;

            lblEstSecundario.Text = oInfAmb.EstSecundario;
            lblEstabSecundario.Text = oInfAmb.EstabSecundario;
            lblTitSecundario.Text = oInfAmb.TitSecundario;

            lblEstTerciario.Text = oInfAmb.EstTerciario;
            lblEstabTerciario.Text = oInfAmb.EstabTerciario;
            lblTitTerciario.Text = oInfAmb.TitTerciario;

            lblEstUniversitario.Text = oInfAmb.EstUniversitario;
            lblEstabUniversitario.Text = oInfAmb.EstabUniversitario;
            lblTitUniversitario.Text = oInfAmb.TitUniversitario;

            lblOtrosCursos.Text = oInfAmb.OtrosCursos;
            lblIdiomas.Text = oInfAmb.Idiomas;
            lblComputacion.Text = oInfAmb.Computacion;

            lblEmpresa1.Text = oInfAmb.Empresa1;
            lblDomEmpresa1.Text = oInfAmb.DomEmpresa1;
            lblTelEmpresa1.Text = oInfAmb.TelEmpresa1;
            if (oInfAmb.FecIngEmpresa1 != "")
                lblFecIngEmpresa1.Text = DateTime.Parse(oInfAmb.FecIngEmpresa1).ToString("dd/MM/yyyy", DateTimeFormatInfo.InvariantInfo);
            if (oInfAmb.FecEgEmpresa1 != "")
                lblFecEgEmpresa1.Text = DateTime.Parse(oInfAmb.FecEgEmpresa1).ToString("dd/MM/yyyy", DateTimeFormatInfo.InvariantInfo);
            lblCargoEmpresa1.Text = oInfAmb.CargoEmpresa1;
            lblUltSueldoEmpresa1.Text = oInfAmb.UltSueldoEmpresa1;
            lblDesvEmpresa1.Text = oInfAmb.DesvEmpresa1;
            lblContactoEmpresa1.Text = oInfAmb.ContactoEmpresa1;

            lblEmpresa2.Text = oInfAmb.Empresa2;
            lblDomEmpresa2.Text = oInfAmb.DomEmpresa2;
            lblTelEmpresa2.Text = oInfAmb.TelEmpresa2;
            if (oInfAmb.FecIngEmpresa2 != "")
                lblFecIngEmpresa2.Text = DateTime.Parse(oInfAmb.FecIngEmpresa2).ToString("dd/MM/yyyy", DateTimeFormatInfo.InvariantInfo);
            if (oInfAmb.FecEgEmpresa2 != "")
                lblFecEgEmpresa2.Text = DateTime.Parse(oInfAmb.FecEgEmpresa2).ToString("dd/MM/yyyy", DateTimeFormatInfo.InvariantInfo);
            lblCargoEmpresa2.Text = oInfAmb.CargoEmpresa2;
            lblUltSueldoEmpresa2.Text = oInfAmb.UltSueldoEmpresa2;
            lblDesvEmpresa2.Text = oInfAmb.DesvEmpresa2;
            lblContactoEmpresa2.Text = oInfAmb.ContactoEmpresa2;

            lblRefLaborales.Text = oInfAmb.RefLaborales;
            lblParteClub.Text = CargarRBT(oInfAmb.ParteClub);
            lblClub.Text = oInfAmb.Club;
            lblDeportes.Text = oInfAmb.Deportes;
            lblConstante.Text = CargarRBT(oInfAmb.Constante);
            lblIPolitica.Text = oInfAmb.IPolitica;
            lblIReligiosa.Text = oInfAmb.IReligiosa;
            lblGSocial.Text = CargarRBT(oInfAmb.GSocial);
            lblFuma.Text = CargarRBT(oInfAmb.Fuma);
            lblBebe.Text = CargarRBT(oInfAmb.Bebe);
            lblMedFijo.Text = CargarRBT(oInfAmb.MedFijo);
            lblEnfermedades.Text = oInfAmb.Enfermedades;
            lblPoliciales.Text = oInfAmb.Policiales;
            lblComFinal.Text = oInfAmb.ComFinal;
            lblTelevision.Text = CargarRBT(oInfAmb.Television);
            lblPrograma.Text = oInfAmb.Programa;
            lblLee.Text = CargarRBT(oInfAmb.Lee);
            lblQLee.Text = oInfAmb.QLee;
            lblTiempoLibre.Text = oInfAmb.TiempoLibre;
            lblTiempoFamilia.Text = CargarRBT(oInfAmb.TiempoFamilia);
            lblActFamiliar.Text = oInfAmb.ActFamiliar;

            lblAntiguedad.Text = oInfAmb.Antiguedad;
            lblMontoAlquiler.Text = oInfAmb.MontoAlquiler;
            if (oInfAmb.Vencimiento != "")
                lblVencimiento.Text = DateTime.Parse(oInfAmb.Vencimiento).ToString("dd/MM/yyyy", DateTimeFormatInfo.InvariantInfo);
            lblTelAlt.Text = oInfAmb.TelAlt;
            lblAccesoDomicilio.Text = oInfAmb.AccesoDomicilio;
            lblTipoVivienda.Text = CargarTipoCampo(int.Parse(oInfAmb.TipoVivienda), 7);
            lblEstadoCons.Text = CargarTipoCampo(int.Parse(oInfAmb.EstadoCons), 6);
            lblTipoConstruccion.Text = CargarTipoCampo(int.Parse(oInfAmb.TipoConstruccion), 8);
            lblTipoZona.Text = CargarTipoCampo(int.Parse(oInfAmb.TipoZona), 9);
            lblTipoCalle.Text = CargarTipoCampo(int.Parse(oInfAmb.TipoCalle), 10);
            lblInteresado.Text = CargarTipoCampo(int.Parse(oInfAmb.Interesado), 11);
            lblCantTel.Text = oInfAmb.CantTel;
            switch(oInfAmb.TipoTele)
            {
                case "1": lblTipoTele.Text = "Aire"; break;
                case "2": lblTipoTele.Text = "Cable"; break;
                default: lblTipoTele.Text = ""; break;
            }
            lblEmpresaCable.Text = oInfAmb.EmpresaCable;
            lblComputadora.Text = CargarRBT(int.Parse(oInfAmb.Computadora));
            lblInternet.Text = CargarRBT(int.Parse(oInfAmb.Internet));
            lblEmpresaInternet.Text = oInfAmb.EmpresaInternet;

            switch (oInfAmb.TipoEmpresa)
            {
                case "1": lblTipoEmpresa.Text = "Familiar"; break;
                case "2": lblTipoEmpresa.Text = "Vertical"; break;
                case "3": lblTipoEmpresa.Text = "Horizontal"; break;
                case "4": lblTipoEmpresa.Text = "En equipo"; break;
                default: lblTipoEmpresa.Text = ""; break;
            }

            lblNombreVecino1.Text = oInfAmb.NombreVecino1;
            lblDomicilioVecino1.Text = oInfAmb.DomicilioVecino1;
            lblConoceVecino1.Text = oInfAmb.ConoceVecino1;

            lblNombreVecino2.Text = oInfAmb.NombreVecino2;
            lblDomicilioVecino2.Text = oInfAmb.DomicilioVecino2;
            lblConoceVecino2.Text = oInfAmb.ConoceVecino2;

            lblNombreVecino3.Text = oInfAmb.NombreVecino3;
            lblDomicilioVecino3.Text = oInfAmb.DomicilioVecino3;
            lblConoceVecino3.Text = oInfAmb.ConoceVecino3;

            lblObservaciones.Text = oInfAmb.Observaciones;
			
            lblPlanoA.Text = oInfAmb.PlanoA;
			lblPlanoB.Text = oInfAmb.PlanoB;
			lblPlanoC.Text = oInfAmb.PlanoC;
			lblPlanoD.Text = oInfAmb.PlanoD;
		}

		private void Cancelar_Click(object sender, EventArgs e)
		{
			Response.Redirect("/BandejaEntrada/Principal.aspx?idTipo=" + Request.QueryString["idTipo"]);
		}

		private string LoadEstadoCivil(int EstadoCivil)
		{
			UtilesApp Tipos = new UtilesApp();
			string Estado = "";
			DataTable myTb;
			myTb = Tipos.TraerEstadoCivil();
			foreach(DataRow myRow in myTb.Rows)
			{
				if(EstadoCivil.ToString() == myRow[0].ToString())
				{
					Estado= myRow[1].ToString();			
				}
			}
			return Estado;
		}

		private string LoadTipoDNI(int DNI)
		{
			UtilesApp Tipos = new UtilesApp();
			string TipoDNI="";
			DataTable myTb;
			myTb = Tipos.TraerTipoDocumento();
			foreach(DataRow myRow in myTb.Rows)
			{
				if(DNI.ToString() == myRow[0].ToString())
				{
					TipoDNI= myRow[1].ToString();			
				}
			}
			return TipoDNI;
		}


		private string LoadTipoPropiedad(int idTipoPropiedad)
		{
			UtilesApp Tipos = new UtilesApp();
			string TipoPropiedad= "";
			DataTable myTb;
			myTb = Tipos.TraerTipoPropiedad();
			foreach(DataRow myRow in myTb.Rows)
			{
				if(idTipoPropiedad.ToString() == myRow[0].ToString())
				{
					TipoPropiedad = myRow[1].ToString();
				}
			}
			//SelectTipoPropiedad(idTipoPropiedad);	
			return TipoPropiedad;
		}


		private string CargarProvincias(int IdProvincia)
		{
			UtilesApp Tipos = new UtilesApp();
			string Provincia= "";
			DataTable myTb;
			myTb = Tipos.TraerProvincias();
			foreach(DataRow myRow in myTb.Rows)
			{
				if(IdProvincia == int.Parse(myRow[0].ToString()))
				{
					Provincia = myRow[1].ToString();
				}
			}
			return Provincia;
		}

		private String CargarLocalidades(int idProvincia, int IdLocalidad)
		{
			UtilesApp Tipos = new UtilesApp();
			DataTable myTb;
			string Localidad = "";
			myTb = Tipos.TraerLocalidades(idProvincia);
			foreach(DataRow myRow in myTb.Rows)
			{
				if(IdLocalidad.ToString() == myRow[0].ToString())
				{
					Localidad = myRow[1].ToString();
				}
			}
			return Localidad;
		}


		private String CargarTipoCampo(int id, int idTipo)
		{
			InformeAmbiental oInfAmb = new InformeAmbiental();
			DataTable myTb;
			string TipoCampo = "";

			myTb = oInfAmb.TraerCampo(idTipo);
			foreach(DataRow myRow in myTb.Rows)
			{
				if(id.ToString() == myRow[0].ToString())
				{
					TipoCampo = myRow[1].ToString();
				}
			}
			return TipoCampo;
		}

        private void CargarImagen(int lIdInforme, int lNroImagen)
        {
            string vImagen = "/img/shim.gif";
            ImagenDal imagen = new ImagenDal();
            imagen.Cargar(lIdInforme, lNroImagen);
            if (imagen.Path != "")
                vImagen = imagen.Path;
            //else
            //imgFoto.BorderWidth = 0;
            if (lNroImagen == 1)
            {
                imgFoto.ImageUrl = vImagen;
                imgFoto.ToolTip = imagen.Descripcion;
            }
            if (lNroImagen == 2)
            {
                imgFoto2.ImageUrl = vImagen;
                imgFoto2.ToolTip = imagen.Descripcion;
            }
        }

	}
}
