using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.App;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.imagenes
{
	/// <summary>
	/// Summary description for lista.
	/// </summary>
	public partial class lista : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
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

		}
		#endregion
	

		private string SubirArchivo(string Tipo, string idInforme)
		{
			string strFileName = "";
			try
			{
				if (txtArchivo.Value != "")
				{
					// subo el Archivo
					UploadFile(ref strFileName, Tipo, idInforme);
				}
			}
			catch (Exception e)
			{
				String Error = e.Message.ToString();
			}
			return strFileName;
		}

		private void UploadFile(ref string strFileName, string Tipo, string idInforme)
		{
			if (txtArchivo.PostedFile != null)
			{
				string strPath = ConfigurationSettings.AppSettings["PATH"];
				HttpPostedFile myFile = txtArchivo.PostedFile;

				// Obtengo el tamaño del archivo
				int nFileLen = myFile.ContentLength;

				// Me aseguro que el tamaño del archivo sea > 0
				if (nFileLen > 0)
				{
					// Coloco la Info en un Buffer y para luego leerla
					byte[] myData = new byte[nFileLen];

					// La Info a Subir
					myFile.InputStream.Read(myData, 0, nFileLen);

					// Nombre del Archivo a Subir
					strFileName = Path.GetFileName(myFile.FileName);
					
					FileInfo ArchivoServer = new FileInfo(Server.MapPath(strPath + Tipo + "/" + idInforme + "/" + strFileName));
					// Escribo en disco
					
					WriteToFile(Server.MapPath(strPath + Tipo + "/" + idInforme + "/" + strFileName), ref myData);
					this.ViewState.Add("FileName", strFileName);
				}
			}
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

		protected void Aceptar_Click(object sender, System.EventArgs e)
		{
			//ImagenesApp Imagenes = new ImagenesApp();
			string idInforme = Request.QueryString["idInforme"];
			string Tipo = Request.QueryString["Tipo"];

			string Path = "";
			//int intIsFile = 0;
			Path = SubirArchivo(Tipo, idInforme);
			//intIsFile = 1;
			//Imagenes.Path = Path;
			UsuarioAutenticado Usuario = (UsuarioAutenticado) Session["UsuarioAutenticado"];
			//	int idNewReferencia = Imagenes.Crear();
//				if (Aceptar.Text == "Aceptar")
//					Response.Redirect("ListaReferencias.aspx");
//				else
//					Response.Redirect("altaReferencia.aspx?IdReferencia=" + idNewReferencia);

		}

	}
}
