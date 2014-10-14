using System;
using System.Web;
using System.Web.UI.WebControls;
using System.IO;
using System.Configuration;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Extranet.Informes
{
	/// <summary>
	/// Summary description for altaInforme.
	/// </summary>
	public partial class altaReferencia : System.Web.UI.Page
	{
		private int IdReferencia;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			lblFile.Visible = false;
			if(Request.QueryString["IdReferencia"] != null)
			{	
				IdReferencia = int.Parse(Request.QueryString["IdReferencia"]);
				if(Request.QueryString["isFile"] == "1")
				{	
					pnlInformes.Visible = false;
					txtArchivo.Visible = false;
					Aceptar.Text= "Finalizar";
					chkFile.Visible = true;
					chkFile.Enabled = false;
					chkFile.Checked = true;
					if (! Page.IsPostBack)
					{
						ReferenciasApp Referencia = new ReferenciasApp();
						Referencia.Cargar(IdReferencia);
						txtDescripcion.Text = Referencia.Descripcion;
						txtObservaciones.Text = Referencia.Observaciones;
						lblFile.Visible = true;
						lblFile.Text = "<B>Archivo:</B>&nbsp;" + Referencia.Path;
					}
				} 
				else 
				{
					pnlInformes.Visible = true;
					chkFile.Visible = false;
					txtArchivo.Visible=false;
					Aceptar.Text= "Finalizar";
					if (! Page.IsPostBack)
					{
						ReferenciasApp Referencia = new ReferenciasApp();
						Referencia.Cargar(IdReferencia);
						txtDescripcion.Text = Referencia.Descripcion;
						txtObservaciones.Text = Referencia.Observaciones;
						ListaEncabezados(IdReferencia);
					}
				}
			} 
			else {
				pnlInformes.Visible = false;
				if (! Page.IsPostBack)
				{
					txtArchivo.Visible=false;
					Aceptar.Text= "Siguiente >>";
				} 
				else 
				{
					if (chkFile.Checked)
					{
						txtArchivo.Visible = true;
						Aceptar.Text= "Aceptar";
					} 
					else 
					{
						txtArchivo.Visible = false;
						Aceptar.Text= "Siguiente >>";
					}
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
            Aceptar.Attributes.Add("onclick", "javascript: deshabilitarBotones(" + Aceptar.ClientID + ");");
			InitializeComponent();
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



		protected void Aceptar_Click(object sender, System.EventArgs e)
		{
			ReferenciasApp Referencia = new ReferenciasApp();
			Referencia.Descripcion = txtDescripcion.Text;
			Referencia.Observaciones = txtObservaciones.Text;

			UsuarioAutenticado Usuario = (UsuarioAutenticado)Session["UsuarioAutenticado"];

			Referencia.IdCliente = Usuario.IdCliente;
			Referencia.Estado = 1;
			string Path="";
			int intIsFile = 0;
			if (chkFile.Checked) 
			{
				Path = SubirArchivo();
				intIsFile = 1;
			}
			Referencia.Path = Path;
			Referencia.isFile = intIsFile;
			if (Aceptar.Text == "Finalizar")
			{
				Referencia.Modificar(IdReferencia);
				Response.Redirect("ListaReferencias.aspx");
			} 
			else
			{
				int idNewReferencia = Referencia.Crear();
				if (Aceptar.Text == "Aceptar")
				{
					Response.Redirect("ListaReferencias.aspx");
				}
				else
				{
					Response.Redirect("altaReferencia.aspx?IdReferencia=" + idNewReferencia);
				}
			}
		}

		protected void chkFile_CheckedChanged(object sender, System.EventArgs e)
		{
			txtArchivo.Visible = chkFile.Checked;
			if (chkFile.Checked)
			{
				Aceptar.Text = "Aceptar";
			} 
			else 
			{
				Aceptar.Text = "Siguiente >>";
			}
		}

		private string SubirArchivo()
		{
			string strFileName = "";
			try
			{
				if (txtArchivo.Value != "") 
				{
					// subo el Archivo
					UploadFile(ref strFileName);
				}
			}
			catch (Exception e)
			{	
				String Error = e.Message.ToString();
			}
			return strFileName;
		}

		private void UploadFile(ref string strFileName) 
		{
			if(txtArchivo.PostedFile != null )
			{
				string strPath = ConfigurationSettings.AppSettings["PATH"];
				HttpPostedFile myFile = txtArchivo.PostedFile;

				// Obtengo el tamaño del archivo
				int nFileLen = myFile.ContentLength; 

				// Me aseguro que el tamaño del archivo sea > 0
				if( nFileLen > 0 )
				{
					// Coloco la Info en un Buffer y para luego leerla
					byte[] myData = new byte[nFileLen];

					// La Info a Subir
					myFile.InputStream.Read(myData, 0, nFileLen);

					// Nombre del Archivo a Subir
					strFileName = Path.GetFileName(myFile.FileName);
					FileInfo ArchivoServer = new FileInfo(Server.MapPath(strPath + strFileName));
					// Escribo en disco
					WriteToFile(Server.MapPath(strPath + strFileName), ref myData);
					this.ViewState.Add("FileName",strFileName);
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

		private void ListaEncabezados(int IdRef)
		{
			BandejaEntradaApp bandeja = new BandejaEntradaApp();
			dgridEncabezados.DataSource = bandeja.ListaEncabezados(IdRef);
			dgridEncabezados.DataBind();
		}

		protected void btnInforme_Click(object sender, System.EventArgs e)
		{
            Response.Redirect("/Informes/altaInforme.aspx?desdeRef=1&IdReferencia=" + IdReferencia);
		}

		protected void dgridEncabezados_PreRender(object sender, System.EventArgs e)
		{
			foreach (DataGridItem myItem in dgridEncabezados.Items)
			{
				myItem.Cells[6].Text= "<IMG SRC='/img/Estado" + myItem.Cells[9].Text + ".gif' widht='14' height='14' border='0'>&nbsp;&nbsp;&nbsp;" + myItem.Cells[5].Text;
				if (int.Parse(myItem.Cells[9].Text) == 1 || int.Parse(myItem.Cells[9].Text) == 5)
				{
					((ImageButton)myItem.FindControl("Editar")).Attributes.Add("src",@"/img/modificar_general.gif");
					((ImageButton)myItem.FindControl("Editar")).ToolTip = "Modificar Informe";
					((ImageButton)myItem.FindControl("Cancelar")).Attributes.Add("onclick",@"javascript: return confirm('¿Está seguro que desea Cancelar el Informe?');");
				}
				else
				{
					((ImageButton)myItem.FindControl("Editar")).Attributes.Add("src",@"/img/lupita.gif");
					((ImageButton)myItem.FindControl("Editar")).ToolTip = "Visualizar Informe";
					((ImageButton)myItem.FindControl("Cancelar")).Attributes.Add("src",@"/img/reloj.jpg");
					((ImageButton)myItem.FindControl("Cancelar")).ToolTip = "Ver Historial";
				}
			}
		}

		private void CancelarEncabezado(int idEncabezado)
		{
			EncabezadoApp Encabezado = new EncabezadoApp();
			Encabezado.cargarEncabezado(idEncabezado);

			// Usuario Logueado
			UsuarioAutenticado Usuario = (UsuarioAutenticado)Session["UsuarioAutenticado"];
			Encabezado.IdCliente = Usuario.IdCliente;

			Encabezado.Cancelar(idEncabezado);
		}

		private void dgridEncabezados_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.Item.Cells[0].Text != "")
			{
				switch(((ImageButton)e.CommandSource).CommandName)
				{
					case "Cancelar":
						int IdCodigo = int.Parse(e.Item.Cells[0].Text);
						if (int.Parse(e.Item.Cells[9].Text) == 1 || int.Parse(e.Item.Cells[9].Text) == 5)
						{
							CancelarEncabezado(IdCodigo);
							Response.Redirect("altaReferencia.aspx?IdReferencia=" + IdReferencia);
						}
						else
						{
							Response.Redirect("/Informes/VerHistorial.aspx?id="+ e.Item.Cells[0].Text);
						}
						break;

					case "Editar":
						if (int.Parse(e.Item.Cells[9].Text) == 1 || int.Parse(e.Item.Cells[9].Text) == 5)
						{
                            Response.Redirect("/Informes/abmInforme.aspx?desdeRef=1&id=" + e.Item.Cells[0].Text);
						}
						else
						{
							Response.Redirect("/Informes/VerInforme.aspx?id="+ e.Item.Cells[0].Text);
						}
						break;
				}
			}
		}

	}
}
