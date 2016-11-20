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
using ar.com.TiempoyGestion.BackEnd.Verificaciones.Dal;
//using iTextSharp.text;
//using iTextSharp.text.html;
//using iTextSharp.text.pdf;
using System.IO;
//using iTextSharp.text.html.simpleparser;
using System.Collections.Generic;
using System.Net;
using System.Collections;
using System.Diagnostics;
//using System.Drawing;
//using System.Drawing.Imaging;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.inspeccionAmbientalBancor
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
            //GenerarPDF.Visible = false;
			if (!Page.IsPostBack)
			{
				if(Request.QueryString["id"] != null)
				{	
					IdInforme = int.Parse(Request.QueryString["id"]);
					LoadInforme(IdInforme);
				}
				//lblTools.Text = "<input onclick=\"panel.style.visibility='hidden';window.print();panel.style.visibility='visible';\" type=\"image\" src=\"/img/imprimir-2.gif\"> " +
				//	"<input onclick=\"window.close();\" type=\"image\" src=\"/img/log_off.gif\"> " +
				//	"<img src=\"/img/Eterno.gif\"> <input onclick=\"window.showModalDialog('/Admin/Imagenes/VerImagenes.aspx?Informe=" + IdInforme.ToString() + "', '', 'dialogWidth:640px;dialogHeight:480px');\" type=\"image\" src=\"/img/Imagenes.gif\" title=\"Ver más imágenes...\"> ";

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
            InspeccionAmbientalBancorApp oInspeccionAmbientalBancorApp = new InspeccionAmbientalBancorApp();

			EncabezadoApp oEncabezado = new EncabezadoApp();
			oEncabezado.cargarEncabezado(Id);
			ClienteDal cliente = new ClienteDal();
			cliente.Cargar(oEncabezado.IdCliente);
			Usuario usuario = new Usuario();
			usuario.Cargar(oEncabezado.IdUsuario);
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
            }

            bool cargar = oInspeccionAmbientalBancorApp.cargarInspeccionAmbientalBancor(Id);

			if (cargar)
			{
				lblNum.Text = Id.ToString();
				//lblFec.Text = DateTime.Today.ToShortDateString();
                if (oEncabezado.FechaFin != "")
                    lblFec.Text = Convert.ToDateTime(oEncabezado.FechaFin).ToShortDateString();
				lblSolicitante.Text = cliente.RazonSocial;

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
                    //lblDireccionSolicitanteCopy.Text = lblDireccionSolicitante.Text;
                    lblRefCopy.Text = lblRef.Text;
                    //lblNroPagina1.Text = "Página 1 de 2";
                    //lblNroPagina2.Text = "Página 2 de 2";
                }
                CargarForm(oInspeccionAmbientalBancorApp);
			}
			else
			{
				CargarEncabezado(oEncabezado);
			}

		}


        private void CargarEncabezado(EncabezadoApp oEncabezado)
		{
			lblNombre.Text= oEncabezado.Nombre;
			lblApellido.Text = oEncabezado.Apellido;
			lblTipoDocumento.Text = LoadTipoDNI(oEncabezado.TipoDocumento);
			lblDocumento.Text = oEncabezado.Documento;
			lblCalle.Text= oEncabezado.Calle;
			lblBarrio.Text= oEncabezado.Barrio;
			lblNro.Text= oEncabezado.Nro;
			lblPiso.Text= oEncabezado.Piso;
			lblDepto.Text= oEncabezado.Dpto;
			lblCP.Text= oEncabezado.CP;
            lblLote.Text = oEncabezado.Lote;
            lblManzana.Text = oEncabezado.Manzana;
            lblComplejo.Text = oEncabezado.Complejo;
            lblTorre.Text = oEncabezado.Torre;
		}


        private void CargarForm(InspeccionAmbientalBancorApp oInspeccionAmbientalBancor)
		{
			lblNombre.Text= oInspeccionAmbientalBancor.Nombre;
			lblApellido.Text = oInspeccionAmbientalBancor.Apellido;
			lblTipoDocumento.Text = LoadTipoDNI(oInspeccionAmbientalBancor.TipoDocumento);
			lblDocumento.Text = oInspeccionAmbientalBancor.Documento;
			lblCalle.Text= oInspeccionAmbientalBancor.Calle;
			lblBarrio.Text= oInspeccionAmbientalBancor.Barrio;
			lblNro.Text= oInspeccionAmbientalBancor.Nro;
			lblPiso.Text= oInspeccionAmbientalBancor.Piso;
			lblDepto.Text= oInspeccionAmbientalBancor.Depto;
			lblCP.Text= oInspeccionAmbientalBancor.CP;
            lblLote.Text = oInspeccionAmbientalBancor.Lote;
            lblManzana.Text = oInspeccionAmbientalBancor.Manzana;
            lblComplejo.Text = oInspeccionAmbientalBancor.Complejo;
            lblTorre.Text = oInspeccionAmbientalBancor.Torre;
            
			lblTelefono.Text= oInspeccionAmbientalBancor.Telefono;
			lblProvincia.Text = CargarProvincias(oInspeccionAmbientalBancor.IdProvincia);
			lblLocalidad.Text = CargarLocalidades(oInspeccionAmbientalBancor.IdProvincia, oInspeccionAmbientalBancor.IdLocalidad);

			if(oInspeccionAmbientalBancor.Fecha != "")
				lblFecha.Text= DateTime.Parse(oInspeccionAmbientalBancor.Fecha).ToString("dd/MM/yyyy",DateTimeFormatInfo.InvariantInfo);
            if (oInspeccionAmbientalBancor.IdHabita == 1)
                lblHabita.Text = "SI";
            else
                lblHabita.Text = "NO";

            lblCantidad.Text = oInspeccionAmbientalBancor.SICantidadIntegranGrupo;
            lblQuienHabita.Text = oInspeccionAmbientalBancor.NOQuienHabita;
            lblCalidadDe.Text = oInspeccionAmbientalBancor.NOCalidadDe;

            if (oInspeccionAmbientalBancor.IdAmpliaciones == 1)
                lblAmpliaciones.Text = "SI";
            else
                lblAmpliaciones.Text = "NO";

            lblCualesAmpliaciones.Text = oInspeccionAmbientalBancor.SICuales;

            if (oInspeccionAmbientalBancor.IdDepIndep == 1)
                lblDepeIndepe.Text = "SI";
            else
                lblDepeIndepe.Text = "NO";

            lblEmpresa.Text = oInspeccionAmbientalBancor.DEPEmpresa;
            lblDireccion.Text = oInspeccionAmbientalBancor.DEPDireccion;
            lblIngresosMensuales.Text = oInspeccionAmbientalBancor.DEPIngresosMensuales;
            lblBanco.Text = oInspeccionAmbientalBancor.DEPBanco;

            lblActividad.Text = oInspeccionAmbientalBancor.INDEPActividad;
            lblDesarrolla.Text = oInspeccionAmbientalBancor.INDEPDesarrolla;

            lblIngresosFamiliares.Text = oInspeccionAmbientalBancor.Ingresos;

            if (oInspeccionAmbientalBancor.IdServicios == 1)
                lblImpuestos.Text = "SI";
            else
                lblImpuestos.Text = "NO";
			//lblAccesoDomicilio.Text = oInspeccionAmbientalBancor.AccesoDomicilio;
			lblInformo.Text = oInspeccionAmbientalBancor.Informo;
			lblRelacion.Text = oInspeccionAmbientalBancor.Relacion;
			lblNombreVecino.Text = oInspeccionAmbientalBancor.NombreVecino;
			lblDomicilioVecino.Text = oInspeccionAmbientalBancor.DomicilioVecino;
			lblConoceVecino.Text = oInspeccionAmbientalBancor.ConoceVecino;
            lblNombreVecino2.Text = oInspeccionAmbientalBancor.NombreVecino2;
            lblDomicilioVecino2.Text = oInspeccionAmbientalBancor.DomicilioVecino2;
            lblConoceVecino2.Text = oInspeccionAmbientalBancor.ConoceVecino2;
			lblObservaciones.Text = oInspeccionAmbientalBancor.Observaciones;
			lblPlanoA.Text = oInspeccionAmbientalBancor.PlanoA;
			lblPlanoB.Text = oInspeccionAmbientalBancor.PlanoB;
			lblPlanoC.Text = oInspeccionAmbientalBancor.PlanoC;
			lblPlanoD.Text = oInspeccionAmbientalBancor.PlanoD;
            
		}

		private void Cancelar_Click(object sender, EventArgs e)
		{
//			if(idReferencia.Value != null) 
//			{
//				if (int.Parse(idReferencia.Value) > 0) Response.Redirect("/Extranet/Referencias/altaReferencia.aspx?IdReferencia=" + idReferencia.Value);
//				else Response.Redirect("ListaInformes.aspx");
//			} 				
//			else Response.Redirect("ListaInformes.aspx");
			Response.Redirect("/BandejaEntrada/Principal.aspx?idTipo=" + Request.QueryString["idTipo"]);
		}




//		private void CambioPaneles(int Informe) 
//		{
//			pnlTitulo.Visible = false;
//			pnlParticulares.Visible= false;
//			pnlAutomotor.Visible = false;
//			pnlGravamenes.Visible = false;
//			pnlPropiedad.Visible= false;
//			pnlAmbiental.Visible = false;
//			pnlDomParticular.Visible = false;
//			pnlDomicilioParticular.Visible = false;
//			pnlParticulares.Visible = false;
//			pnlCatastral.Visible = false;
//			pnlFoto.Visible = false;
//			pnlUrgencia.Visible= false;
//			switch(Informe)
//			{
//				case 1: // Propiedad
//					pnlPropiedad.Visible= true;
//					pnlUrgencia.Visible= true;
//					break;
//				case 2: // Automotor
//					pnlAutomotor.Visible = true;
//					break;
//				case 3: // Gravámenes
//					pnlGravamenes.Visible = true;
//					break;
//				case 4: // Ambiental
//					pnlParticulares.Visible = true;
//					pnlAmbiental.Visible = true;
//					break;
//				case 5: // Dom Particular
//					pnlParticulares.Visible = true;
//					pnlDomicilioParticular.Visible = true;
//					pnlFoto.Visible = true;
//					break;
//				case 6:
//					lblInforme.Text = "Verificación de Domicilio Laboral";
//					pnlParticulares.Visible = true;
//					pnlDomParticular.Visible = true;
//					pnlFoto.Visible = true;
//					break;
//				case 7:
//					lblInforme.Text = "Verificación de Domicilio Particular";
//					pnlParticulares.Visible = true;
//					pnlDomParticular.Visible = true;
//					pnlFoto.Visible = true;
//					break;
//				case 8:
//					lblInforme.Text = "Verificación Especial";
//					pnlDomParticular.Visible = true;
//					pnlParticulares.Visible = true;
//					break;
//				case 9:
//					lblTitulo.Text = "Registro Público de Comercio";
//					pnlTitulo.Visible = true;
//					break;
//				case 10: // Busqueda Automotor
//					pnlParticulares.Visible = true;
//					break;
//				case 11: // Informe Propiedad Otras Provincias
//					lblTitulo.Text = "Informe Propiedad Otras Provincias";
//					pnlTitulo.Visible = true;
//					break;
//				case 12: // Informe Catastral
//					pnlCatastral.Visible = true;
//					break;
//				case 13: // Búsqueda Propiedad
//					pnlParticulares.Visible = true;
//					pnlUrgencia.Visible= true;
//					break;
//			}
//		}

//		private void SelectTipoPropiedad(int idTipo)
//		{
//			switch(idTipo)
//			{
//				case 1: 
//					pnlDominioLegEspecial.Visible = false;
//					lblTipoPropiedad.Text = "Nro. de Matricula";
//					break;
//				case 2: 
//					lblTipoPropiedad.Text = "Dominio";
//					pnlDominioLegEspecial.Visible = true;
//					break;
//				case 3: 
//					lblTipoPropiedad.Text = "Nro. de Legajo Especial";
//					pnlDominioLegEspecial.Visible = true;
//					break;
//			}
//		}

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
			VerifDomComercialApp oVerif = new VerifDomComercialApp();
			DataTable myTb;
			string TipoCampo = "";

			myTb = oVerif.TraerCampo(idTipo);
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
                if (vImagen == "/img/shim.gif")
                    imgFoto.Visible = false;
            }
            if (lNroImagen == 2)
            {
                imgFoto2.ImageUrl = vImagen;
                imgFoto2.ToolTip = imagen.Descripcion;
                if (vImagen == "/img/shim.gif")
                    imgFoto2.Visible = false;
            }
        }


        protected void GenerarPDF_Click(object sender, ImageClickEventArgs e)
        {
            SendToPrinter();
            //ASPXToPDF1.RenderAsPDF();
            /*
            string urlOrHtmlFile;
            string outputFileName;
            urlOrHtmlFile = Request.Url.AbsoluteUri;
            outputFileName = Server.MapPath("~/res/pdf/") + "br" + Request.QueryString["id"] + ".pdf";
            */

            /*
            HtmlToPdf.ConvertUrl(urlOrHtmlFile, outputFileName);

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(urlOrHtmlFile);

            using (Stream stream = request.GetResponse().GetResponseStream())
            {

                using (StreamReader reader = new StreamReader(stream))
                {

                    string response = reader.ReadToEnd();
                    HtmlToPdf.ConvertHtml(response, outputFileName);

                    //return response;

                }
            }
             */
            /***
            Document myDocument = new Document(PageSize.A4);
            PdfWriter.GetInstance(myDocument, new FileStream(Server.MapPath("~/res/pdf/") + "br" + Request.QueryString["id"] + ".pdf", FileMode.Create));

            myDocument.Open();

            StreamReader tempReader = new StreamReader(urlOrHtmlFile);
            ArrayList p = HTMLWorker.ParseToList(tempReader, st);
            for (int k = 0; k < p.Count; k++)
            {
                myDocument.Add((IElement)p[k]);
            }
            tempReader.Dispose();
            myDocument.Close(); 
            ***/
          
            /* FUNCA PERO NO LOGUEA
            Document myDocument = new Document(PageSize.A4);
            PdfWriter.GetInstance(myDocument, new FileStream(Server.MapPath("~/res/pdf/") + "br" + Request.QueryString["id"] +".pdf", FileMode.Create));
            
            myDocument.Open();
            //string htmlPagina = getHTML2(urlOrHtmlFile);
            WebClient client = new WebClient();

            string pathImagenes = "http://" + Request.Url.Host + ":" + Request.Url.Port;
            string htmlPagina = client.DownloadString(urlOrHtmlFile).Replace("/img/", pathImagenes + "/img/").Replace("/Img/", pathImagenes + "/img/");
            
            
            //string htmlPagina = "<table border='1' width='100%'><tr><td>hola<br>veamos</td></tr></table>";
            using (TextReader sReader = new StringReader(htmlPagina))
            {
                List<IElement> list = HTMLWorker.ParseToList(sReader, new StyleSheet());
                foreach (IElement elm in list)
                {
                    myDocument.Add(elm);
                }
            }
            
            myDocument.Close(); 
            */


            //HtmlParser.Parse(myDocument, urlOrHtmlFile);
            //myDocument.Add(new Paragraph("Probando el generador de PDF"));
            //myDocument.Close();

            /*
            HttpContext.Current.Response.Clear();

            // add the HTTP header to tell the browser to accept this as a file.  Also, the friendlypdfname.pdf is the name 

            // of the PDF as you want it to appear to the user (regardless of what it is named in your file system).

            HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "friendlypdfname.pdf"));

            // tell the browser what type of file this is so it can have a mime type associated with it.

            HttpContext.Current.Response.ContentType = "application/pdf";


            // pass the path that you wrote the file to on your file system as the parameter to WriteFile()


            HttpContext.Current.Response.WriteFile(sPathToWritePdfTo);

            // end the response and commit the file to the stream

            HttpContext.Current.Response.End();
            */



        }


        private void SendToPrinter()
        {
            ProcessStartInfo info = new ProcessStartInfo();
            info.Verb = "print";
            info.FileName = @"c:\output.pdf";
            info.CreateNoWindow = true;
            info.WindowStyle = ProcessWindowStyle.Hidden;

            Process p = new Process();
            p.StartInfo = info;
            p.Start();

            p.WaitForInputIdle();
            System.Threading.Thread.Sleep(3000);
            if (false == p.CloseMainWindow())
                p.Kill();
        }
      


    }
}
