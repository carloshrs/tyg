using System;
using System.Data;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;
using ar.com.TiempoyGestion.BackEnd.Gravamenes.Dal;
using ar.com.TiempoyGestion.BackEnd.Informes.Dal;
using System.Configuration;
using System.Web;
using System.IO;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.InformePartidasDefuncion
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
		protected Button Cerrar;
		protected Label Label2;
		protected Label Label8;
		protected TextBox txtMovParticular;
	
		protected void Page_Load(object sender, EventArgs e)
		{
			idInforme.Value = Request.QueryString["id"];
            //this.GetPostBackEventReference(this);

			if (!Page.IsPostBack)
			{
				if(Request.QueryString["id"] != null)
				{
                    CargarInformePartidasDefuncion(int.Parse(idInforme.Value));
                    //ListarResultados(int.Parse(idInforme.Value));
				}
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

        private void CargarInformePartidasDefuncion(int Id)
		{
            InformePartidasDefuncionDal oPartidasDefuncion = new InformePartidasDefuncionDal();
            bool cargar = oPartidasDefuncion.Cargar(Id);
			if (cargar)
			{
				idReferencia.Value = (1).ToString();
                CargarForm(oPartidasDefuncion);
			}
			else
			{
				idReferencia.Value = (0).ToString();
				EncabezadoApp oEncabezado = new EncabezadoApp();
				oEncabezado.cargarEncabezado(Id);
				CargarEncabezado(oEncabezado);
                CargarDatosContacto(oEncabezado);
			}
		}


		private void CargarEncabezado(EncabezadoApp oEncabezado)
		{
			

			txtNombre.Text = oEncabezado.Nombre;
			txtApellido.Text = oEncabezado.Apellido;
			CargarTipoDocumento(oEncabezado.TipoDocumento);
			txtDocumento.Text = oEncabezado.Documento;

			//EMPRESA
			
			//txtObservaciones.Text = oEncabezado.Comentarios;
		}


        private void CargarForm(InformePartidasDefuncionDal oPartidasDefuncion)
		{
			CultureInfo myInfo = new CultureInfo("es-AR");

            idInforme.Value = oPartidasDefuncion.IdInforme.ToString();

            txtNombre.Text = oPartidasDefuncion.Nombre;
            txtApellido.Text = oPartidasDefuncion.Apellido;
            CargarTipoDocumento(oPartidasDefuncion.TipoDocumento);
            txtDocumento.Text = oPartidasDefuncion.Documento;
            txtObservaciones.Text = oPartidasDefuncion.Observaciones;

            ArchivoDal vArchivo = new ArchivoDal();
            vArchivo.Cargar(oPartidasDefuncion.IdInforme);
            hlArchivo.Text = "<b>Descargar archivo</b>";
            hlArchivo.NavigateUrl = vArchivo.Path;
            if (vArchivo.Extension == ".pdf")
                imgArchivo.ImageUrl = "/img/menu/pdf.png";

		}


		protected void Cancelar_Click(object sender, EventArgs e)
		{
			Response.Redirect("/BandejaEntrada/Principal.aspx?idTipo=20");
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



		protected void AceptarFinalizar_Click(object sender, System.EventArgs e)
		{
			string strScript;
			strScript = "<script languaje=\"Javascript\">";
            strScript += "window.showModalDialog('/BandejaEntrada/PopUpCambioEstado.aspx?idTipo=20&idInforme=" + idInforme.Value + "&Finalizar=1','','dialogWidth:400px;dialogHeight:250px');";
			strScript += "document.location.href = '/BandejaEntrada/Principal.aspx?idTipo=20'";
			strScript += "</script>";
			ActualizarInforme();

			//Page.RegisterStartupScript("CambiarEstado", strScript);

            String csname2 = "CambiarEstado";
            Type cstype = this.GetType();
            ClientScriptManager cs = Page.ClientScript;
            cs.RegisterClientScriptBlock(cstype, csname2, strScript, false);
		}


		protected void Aceptar_Click(object sender, System.EventArgs e)
		{
			ActualizarInforme();
			
			Response.Redirect("/BandejaEntrada/Principal.aspx?idTipo=20");
		}

		private void ActualizarInforme()
		{
            InformePartidasDefuncionDal oPartidasDefuncion = new InformePartidasDefuncionDal();
            bool cargar = oPartidasDefuncion.Cargar(int.Parse(idInforme.Value));
			// Usuario Logueado
			UsuarioAutenticado Usuario = (UsuarioAutenticado)Session["UsuarioAutenticado"];
            oPartidasDefuncion.IdCliente = Usuario.IdCliente;
            oPartidasDefuncion.IdUsuario = Usuario.IdUsuario;

            oPartidasDefuncion.IdInforme = int.Parse(idInforme.Value);

            oPartidasDefuncion.Nombre = txtNombre.Text;
            oPartidasDefuncion.Apellido = txtApellido.Text;
            oPartidasDefuncion.TipoDocumento = int.Parse(cmbTipoDocumento.SelectedItem.Value);
            oPartidasDefuncion.Documento = txtDocumento.Text;

            oPartidasDefuncion.Observaciones = txtObservaciones.Text.ToUpper();

            SubirArchivo();

			if(int.Parse(idReferencia.Value) == 0)
                oPartidasDefuncion.Crear();
			else
                oPartidasDefuncion.Modificar(int.Parse(idInforme.Value));
		
		}

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



        private string SubirArchivo()
        {
            string strFileName = "";
            try
            {
                if (txtArchivo.PostedFile != null)
                {
                    // subo el Archivo
                    UploadFile(ref strFileName);
                }
            }
            catch { }

            return strFileName;
        }

        private void UploadFile(ref string strFileName)
        {
            if (txtArchivo.PostedFile != null)
            {
                string strPath = ConfigurationManager.AppSettings["PATH"] + "Informes/InformesPartidasDefuncion/" + DateTime.Today.Year + "/";
                HttpPostedFile myFile = txtArchivo.PostedFile;

                // Obtengo el tama�o del archivo
                int nFileLen = myFile.ContentLength;

                // Me aseguro que el tama�o del archivo sea > 0
                if (nFileLen > 0)
                {
                    // Coloco la Info en un Buffer y para luego leerla
                    byte[] myData = new byte[nFileLen];

                    // La Info a Subir
                    myFile.InputStream.Read(myData, 0, nFileLen);

                    // Nombre del Archivo a Subir
                    strFileName = idInforme.Value + "_" + DateTime.Today.Year + DateTime.Today.Month + DateTime.Today.Day + Path.GetExtension(myFile.FileName);
                    strPath = ChequearCarpeta(strPath);
                    strFileName = strPath + "/" + strFileName;

                    ArchivoDal vArchivo = new ArchivoDal();
                    vArchivo.Crear(int.Parse(idInforme.Value), strFileName, Path.GetExtension(myFile.FileName));

                    // Escribo en disco
                    WriteToFile(Server.MapPath(strFileName), ref myData);
                    /*
                    Image imgPhotoVert = Image.FromFile(Server.MapPath(strFileName));
                    Image imgPhoto = null;

                    imgPhoto = FixedSize(imgPhotoVert, 200, 200);
                    imgPhoto.Save(Server.MapPath(strFileName) + @"\imageresize_3.jpg", ImageFormat.Jpeg);
                    imgPhoto.Dispose();
                    */
                }
            }
        }

        private string ChequearCarpeta(string lPath)
        {
            string strFinalPath = lPath + idInforme.Value;
            try
            {
                if (!Directory.Exists(Server.MapPath(strFinalPath)))
                    Directory.CreateDirectory(Server.MapPath(strFinalPath));
            }
            catch
            { }

            return strFinalPath;
        }

        private void WriteToFile(string strPath, ref byte[] Buffer)
        {
            // Creo el Archivo
            FileStream newFile = new FileStream(strPath, FileMode.Create);

            // Escribo la Info en el Archivo
            newFile.Write(Buffer, 0, Buffer.Length);

            // Cierro
            newFile.Close();
        }


        

	}
}
