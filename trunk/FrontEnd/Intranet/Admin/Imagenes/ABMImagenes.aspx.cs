using System;
using System.Configuration;
//using System.Drawing;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;
using System.Data;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.Admin.Imagenes
{
	/// <summary>
	/// Summary description for ABMImagenes.
	/// </summary>
	public partial class ABMImagenes : Page
	{
		int intIdInforme;
	
		protected void Page_Load(object sender, EventArgs e)
		{
            //rpGaleriaImagenes.ItemDataBound += new RepeaterItemEventHandler(this.Item_Bound);

			if (!Page.IsPostBack)
			{
				try
				{
					intIdInforme = int.Parse(Request.QueryString["Informe"]);
					ViewState["IdInforme"] = intIdInforme.ToString();
					CargarImagenes();
				}
				catch
				{
					string strScript = "<script languaje=\"Javascript\" >window.close();</script>";
					Page.RegisterStartupScript("CerrarError", strScript);
				}

			}
			else
				intIdInforme = int.Parse(ViewState["IdInforme"].ToString());
		}

		private void CargarImagenes()
		{
			ImagenDal imagenDal = new ImagenDal();
			//dgImagenes.DataSource = imagenDal.Listar(intIdInforme).DefaultView;
			//dgImagenes.DataBind();
			//if (dgImagenes.Items.Count == 0)
            rpGaleriaImagenes.DataSource = imagenDal.Listar(intIdInforme);
            rpGaleriaImagenes.DataBind();
            if (rpGaleriaImagenes.Items.Count == 0)
				chkPredeterminada.Checked = true;
			else
				chkPredeterminada.Checked = false;

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
			this.dgImagenes.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgImagenes_ItemCommand);

		}
		#endregion

		protected void dgImagenes_PreRender(object sender, EventArgs e)
		{
			foreach(DataGridItem myItem in dgImagenes.Items)
			{
				((ImageButton)myItem.FindControl("ibutVer")).Attributes.Add("onClick","Javascript:Mostrar('" + myItem.Cells[5].Text + "');return false;");

				if (myItem.Cells[6].Text == "1")
				{
					//myItem.ForeColor = Color.Blue;
					((ImageButton)myItem.FindControl("ibutPredeterminar")).Visible = false;
				}
			}
		}

		private void dgImagenes_ItemCommand(object source, DataGridCommandEventArgs e)
		{
			if (e.Item.Cells[0].Text != "")
			{
				ImagenDal imagenDal = new ImagenDal();
				imagenDal.Cargar(intIdInforme, int.Parse(e.Item.Cells[0].Text));
				switch(((ImageButton)e.CommandSource).CommandName)
				{
					case "Predeterminar":
						imagenDal.Predeterminada = true;
						imagenDal.Modificar();
						CargarImagenes();
						break;

					case "Editar":
						CargarImagen(imagenDal);
						break;
				}
			}		
		}

		private void CargarImagen(ImagenDal lData)
		{
			txtDescripcion.Text = lData.Descripcion;
			//txtAncho.Text = lData.Width.ToString();
			//txtAlto.Text = lData.Height.ToString();
			chkPredeterminada.Checked = lData.Predeterminada;
			lblImagen.Text = "<a href=\"#\" onClick=\"Javascript:Mostrar('" + lData.Path + "')\">" + lData.Path + "</a>";
			lblImagen.Visible = true;
			txtImagen.Visible = false;
			ViewState["NroImagen"] = lData.NumeroImagen;
			btnAceptar.Text = "Guardar";
			reqTxtImagen.Enabled = false;

		}

		private void LimpiarForm()
		{
			txtDescripcion.Text = "";
			//txtAncho.Text = "";
			//txtAlto.Text = "";
			lblImagen.Text = "";
			lblImagen.Visible = false;
			txtImagen.Visible = true;
			ViewState.Remove("NroImagen");
			btnAceptar.Text = "Aceptar";
			reqTxtImagen.Enabled = true;

		}

		protected void btnCerrar_Click(object sender, EventArgs e)
		{
			string strScript = "<script languaje=\"Javascript\">";
			strScript += "window.close();";
			strScript += "</script>";

            ClientScript.RegisterStartupScript(Page.GetType(), "Cerrar", strScript);
		}

		protected void btnAceptar_Click(object sender, EventArgs e)
		{
			ImagenDal imagen = new ImagenDal();
			string strPath = "";
			if(ViewState["NroImagen"] != null)
				imagen.Cargar(intIdInforme, (int)ViewState["NroImagen"]);
			else
				strPath = SubirArchivo();

			imagen.Descripcion = txtDescripcion.Text;
            
			try
			{
				imagen.Width = 0;
				imagen.Height = 0;
			}
             
			catch {	}
            
			imagen.Predeterminada = chkPredeterminada.Checked;
			if(ViewState["NroImagen"] != null)
				imagen.Modificar();
			else
				imagen.Crear(intIdInforme, strPath);
			LimpiarForm();
			CargarImagenes();

		}

		private string SubirArchivo()
		{
			string strFileName = "";
			try
			{
				if (txtImagen.Value != "") 
				{
					// subo el Archivo
					UploadFile(ref strFileName);
				}
			}
			catch {		}

			return strFileName;
		}

		private void UploadFile(ref string strFileName) 
		{
			if(txtImagen.PostedFile != null )
			{
				string strPath = ConfigurationSettings.AppSettings["PATH"] + "Verificaciones/";
				HttpPostedFile myFile = txtImagen.PostedFile;

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
					strFileName = ImagenDal.NextImage(intIdInforme) + Path.GetExtension(myFile.FileName);
					strPath = ChequearCarpeta(strPath);
					strFileName = strPath + "/" + strFileName;
					
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
			string strFinalPath = lPath + intIdInforme.ToString();
			try
			{
				if (!Directory.Exists(Server.MapPath(strFinalPath)))
					Directory.CreateDirectory(Server.MapPath(strFinalPath));
			}
			catch
			{	}

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


        protected void rpGaleria_PreRender(object sender, EventArgs e)
        {
            foreach (RepeaterItem myItem in rpGaleriaImagenes.Items)
            {
                //((ImageButton)myItem.FindControl("ibutVer")).Attributes.Add("onClick", "Javascript:Mostrar('" + myItem.Cells[5].Text + "');return false;");

                //if (myItem.ItemIndex[6].Text == "1")
                {
                    //myItem.ForeColor = Color.Blue;
                    //((ImageButton)myItem.FindControl("ibutPredeterminar")).Visible = false;
                }
            }
        }

        /*
        protected void Item_Bound(Object sender, DataListItemEventArgs e)
        {

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                ((Image)e.Item.FindControl("imgPropiedad")).ImageUrl = ((DataRowView)e.Item.DataItem).Row.ItemArray[2].ToString();
                ((Image)e.Item.FindControl("imgPropiedad")).Width = 200;
                ((Label)e.Item.FindControl("lblDescripcion")).Text = ((DataRowView)e.Item.DataItem).Row.ItemArray[1].ToString();
            }
            //((Label)e.Item.FindControl("lblFecha")).Text = ((DataRowView)e.Item.DataItem).Row.ItemArray[7].ToString();
        }*/
        protected void rpGaleriaImagenes_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (((HiddenField)e.Item.FindControl("hdImagen")).Value != "")
            {
                ImagenDal imagenDal = new ImagenDal();
                imagenDal.Cargar(intIdInforme, int.Parse(((HiddenField)e.Item.FindControl("hdImagen")).Value));
                switch (((ImageButton)e.CommandSource).CommandName)
                {
                    case "Predeterminar":
                        imagenDal.Predeterminada = true;
                        imagenDal.Modificar();
                        CargarImagenes();
                        break;

                    case "Editar":
                        CargarImagen(imagenDal);
                        break;
                }
            }		
        }
}
}
