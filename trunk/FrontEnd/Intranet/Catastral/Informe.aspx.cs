using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;
using ar.com.TiempoyGestion.BackEnd.Informes.Dal;
using System.Configuration;
using System.Web;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.Catastral
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
			idInforme.Value = Request.QueryString["id"];

			if (!Page.IsPostBack)
			{
				if(Request.QueryString["id"] != null)
				{	
					LoadInformeCatastral(int.Parse(idInforme.Value));
				}
                txtBarrio_AutoCompleteExtender.ContextKey = cmbLocalidad.SelectedValue;
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

        private void LoadInformeCatastral(int Id)
		{
            int idTipo=1;
            InformeCatastralApp oCatastral = new InformeCatastralApp();
			EncabezadoApp oEncabezado = new EncabezadoApp();
			oEncabezado.cargarEncabezado(Id);
            CargarDatosContacto(oEncabezado);
            if (oCatastral.TipoProp != 0) idTipo = oCatastral.TipoProp;
            SelectTipoPropiedad(idTipo);
			bool cargar = oCatastral.cargarInformeCatastral(Id);
            
			if (cargar)
			{
				idReferencia.Value = (1).ToString();
				CargarForm(oCatastral);
			}
			else
			{
				idReferencia.Value = (0).ToString();
				CargarEncabezado(oEncabezado);
			}
            if (oEncabezado.Leido == 0)
            {
                oEncabezado.Leido = 1;
                oEncabezado.CambiarLeido(Id);
            }
		}


		
		private void CargarEncabezado(EncabezadoApp oEncabezado)
		{
			idTipoPersona.Value = oEncabezado.IdTipoPersona.ToString();

			CargarComboProvincias(cmbProvincia, oEncabezado.Provincia);
			CargarComboLocalidades(cmbProvincia, cmbLocalidad, oEncabezado.Localidad.ToString());
            txtCalle.Text = oEncabezado.Calle;
            txtBarrio.Text = oEncabezado.Barrio;
            txtNro.Text = oEncabezado.Nro;
            txtPiso.Text = oEncabezado.Piso;
            txtDepto.Text = oEncabezado.Dpto;
            txtLote.Text = oEncabezado.Lote;
            txtManzana.Text = oEncabezado.Manzana;
            txtCP.Text = oEncabezado.CP;
            txtComplejo.Text = oEncabezado.Complejo;
            txtTorre.Text = oEncabezado.Torre;
            if (oEncabezado.TipoCatastro == 1)
                txtNomenclatura.Text = oEncabezado.NumeroCatastro;
            else if(oEncabezado.TipoCatastro == 2)
                txtCuenta.Text = oEncabezado.NumeroCatastro;
            txtObservaciones.Text = oEncabezado.Observaciones;

		}


		private void CargarForm(InformeCatastralApp oCatastral)
		{
			CultureInfo myInfo = new CultureInfo("es-AR");

			idInforme.Value= oCatastral.IdInforme.ToString();
            txtLegajo.Text = oCatastral.Matricula;
            if (oCatastral.TipoProp == 2 || oCatastral.TipoProp == 3)
            {
                txtFolio.Text = oCatastral.Folio;
                txtTomo.Text = oCatastral.Tomo;
                txtAno.Text = oCatastral.Ano;
            }
            txtCalle.Text = oCatastral.Calle;
            txtBarrio.Text = oCatastral.Barrio;
            txtNro.Text = oCatastral.Nro;
            txtPiso.Text = oCatastral.Piso;
            txtDepto.Text = oCatastral.Depto;
            txtLote.Text = oCatastral.Lote;
            txtManzana.Text = oCatastral.Manzana;
            txtCP.Text = oCatastral.CP;
            txtComplejo.Text = oCatastral.Complejo;
            txtTorre.Text = oCatastral.Torre;
            CargarComboProvincias(cmbProvincia, oCatastral.IdProvincia);
            CargarComboLocalidades(cmbProvincia, cmbLocalidad, oCatastral.IdLocalidad.ToString());
            txtNomenclatura.Text = oCatastral.Nomenclatura;
            txtCuenta.Text = oCatastral.NroCuenta;
			txtObservaciones.Text = oCatastral.Observaciones;

            ArchivoDal vArchivo = new ArchivoDal();
            vArchivo.Cargar(oCatastral.IdInforme);
            hlArchivo.Text = "<b>Descargar archivo</b>";
            hlArchivo.NavigateUrl = vArchivo.Path;
            if (vArchivo.Extension == ".pdf")
                imgArchivo.ImageUrl = "/img/menu/pdf.png";

            if (vArchivo.Path != "")
                reqArchivo.Enabled = false;
		}



        #region void CargarDatosContacto(EncabezadoApp enc)

        private void CargarDatosContacto(EncabezadoApp enc)
        {
            lblEncObservaciones.Text = enc.Comentarios;
        }

        #endregion


		protected void Aceptar_Click(object sender, EventArgs e)
		{
			ActualizarInforme();
			
			Response.Redirect("/BandejaEntrada/Principal.aspx?idTipo=12");

		}

		protected void Cancelar_Click(object sender, EventArgs e)
		{
			Response.Redirect("/BandejaEntrada/Principal.aspx?idTipo=12");
		}

		protected void cmbProvincia_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			CargarComboLocalidades(cmbProvincia, cmbLocalidad, "");
            cmbProvincia.Focus();
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
			

		protected void AceptarFinalizar_Click(object sender, System.EventArgs e)
		{
			EncabezadoApp oEncabezado = new EncabezadoApp();
			oEncabezado.cargarEncabezado(int.Parse(idInforme.Value));

			string strScript;
			strScript = "<script languaje=\"Javascript\">";
            strScript += "window.showModalDialog('/BandejaEntrada/PopUpCambioEstado.aspx?idTipo=12&idInforme=" + idInforme.Value + "&Finalizar=1','','dialogWidth:400px;dialogHeight:250px');";
			strScript += "document.location.href = '/BandejaEntrada/Principal.aspx?idTipo=12'";
			strScript += "</script>";

			ActualizarInforme();
			Page.RegisterStartupScript("CambiarEstado", strScript);

		}

		private void ActualizarInforme()
		{
			InformeCatastralApp oCatastral = new InformeCatastralApp();
			bool cargar = oCatastral.cargarInformeCatastral(int.Parse(idInforme.Value));
			// Usuario Logueado
			UsuarioAutenticado Usuario = (UsuarioAutenticado)Session["UsuarioAutenticado"];
			oCatastral.IdCliente = Usuario.IdCliente;
			oCatastral.IdUsuario = Usuario.IdUsuario;
			
			oCatastral.IdInforme = int.Parse(idInforme.Value);
            oCatastral.TipoProp = int.Parse(cmbTipoPropiedad.SelectedValue);
            oCatastral.Matricula = txtLegajo.Text;
            if (int.Parse(cmbTipoPropiedad.SelectedValue) == 2 || int.Parse(cmbTipoPropiedad.SelectedValue) == 3)
            {
                oCatastral.Folio = txtFolio.Text;
                oCatastral.Tomo = txtTomo.Text;
                oCatastral.Ano = txtAno.Text;
            }
            oCatastral.Calle = txtCalle.Text;
            oCatastral.Barrio = txtBarrio.Text;
            oCatastral.Nro = txtNro.Text;
            oCatastral.Piso = txtPiso.Text;
            oCatastral.Depto = txtDepto.Text;
            oCatastral.CP = txtCP.Text;
            oCatastral.Lote = txtLote.Text;
            oCatastral.Manzana = txtManzana.Text;
            oCatastral.Complejo = txtComplejo.Text;
            oCatastral.Torre = txtTorre.Text;
			oCatastral.IdProvincia = int.Parse(cmbProvincia.SelectedValue);
			oCatastral.IdLocalidad = int.Parse(cmbLocalidad.SelectedValue);
            oCatastral.Nomenclatura = txtNomenclatura.Text;
            oCatastral.NroCuenta = txtCuenta.Text;
			oCatastral.Observaciones = txtObservaciones.Text;

            SubirArchivo();

			if(int.Parse(idReferencia.Value) == 0)
				oCatastral.Crear();
			else
				oCatastral.Modificar(int.Parse(idInforme.Value));


		}

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectTipoPropiedad(int.Parse(cmbTipoPropiedad.SelectedValue));
            cmbTipoPropiedad.Focus();
        }


        #region SelectTipoPropiedad(int idTipo)

        private void SelectTipoPropiedad(int idTipo)
        {
            switch (idTipo)
            {
                case 1:
                    pnlDominioLegEspecial.Visible = false;
                    ValtxtFolio.Visible = false;
                    ValMatricula.Visible = true;
                    RequiredFieldValidator6.Enabled = true;
                    lblTipoPropiedad.Text = "Nro. de Matricula";
                    break;
                case 2:
                    lblTipoPropiedad.Text = "Dominio";
                    ValtxtFolio.Visible = true;
                    ValMatricula.Visible = false;
                    pnlDominioLegEspecial.Visible = true;
                    RequiredFieldValidator6.Enabled = true;
                    break;
                case 3:
                    lblTipoPropiedad.Text = "Nro. de Legajo Especial";
                    ValtxtFolio.Visible = true;
                    RequiredFieldValidator6.Enabled = false;
                    ValMatricula.Visible = true;
                    pnlDominioLegEspecial.Visible = true;
                    break;
            }
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
                string strPath = ConfigurationManager.AppSettings["PATH"] + "Informes/Catastral/" + DateTime.Today.Year + "/";
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
