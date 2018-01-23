using System;
using System.Data;
using System.Configuration;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.App;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.Dal;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;
using ar.com.TiempoyGestion.BackEnd.Clientes.Dal; 

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.BandejaEntrada.Referencia
{
	/// <summary>
	/// Summary description for altaInforme.
	/// </summary>
	public partial class altaReferencia : Page
	{
		private int IdReferencia;

		protected void Page_Load(object sender, EventArgs e)
		{
			lblFile.Visible = false;
			if (Request.QueryString["IdReferencia"] != null)
			{
				IdReferencia = int.Parse(Request.QueryString["IdReferencia"]);
				if (Request.QueryString["isFile"] == "1")
				{
					pnlInformes.Visible = false;
					txtArchivo.Visible = false;
					Aceptar.Text = "Finalizar";
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
					txtArchivo.Visible = false;
					Aceptar.Text = "Finalizar";
					if (! Page.IsPostBack)
					{
						ReferenciasApp Referencia = new ReferenciasApp();
						Referencia.Cargar(IdReferencia);
						txtDescripcion.Text = Referencia.Descripcion;
						txtObservaciones.Text = Referencia.Observaciones;
						ListaEncabezados(IdReferencia);
                        //ListaClientes(Referencia.IdCliente);
                        ListaUsuarios(Referencia.IdCliente, Referencia.IdUsuario);
                        txtPersona.Text = Referencia.UsuarioCliente;
                        setValidaPersona();

                        ClienteDal Clientes = new ClienteDal();
                        Clientes.Cargar(Referencia.IdCliente);
                        string nombreEmpresa = "";
                        //string direccionEmpresa = "";

                        if (Clientes.Sucursal != null && Clientes.Sucursal != "")
                            nombreEmpresa = Clientes.NombreFantasia + " (" + Clientes.Sucursal + ")";
                        else
                            nombreEmpresa = Clientes.NombreFantasia;

                        txtCliente.Text = nombreEmpresa;
                        txtCliente.ReadOnly = true;
					}

				}
			}
			else
			{
				pnlInformes.Visible = false;
				if (! Page.IsPostBack)
				{
					txtArchivo.Visible = false;
					Aceptar.Text = "Siguiente >>";
                    //ListaClientes(-1);    
				}
				else
				{
					if (chkFile.Checked)
					{
						txtArchivo.Visible = true;
						Aceptar.Text = "Aceptar";
					}
					else
					{
						txtArchivo.Visible = false;
						Aceptar.Text = "Siguiente >>";
					}
				}
			}

            if (Request.Form["__EVENTTARGET"] == "SelectCliente")
            {
                //call your button click function, and pass the button to it (can pass null as the EventArgs)
                //Button1_Click(Button1, null);
                //SelectCliente
                SubcmbClientes(hdIdCliente.Value);
            }
		}

		#region Web Form Designer generated code

		protected override void OnInit(EventArgs e)
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
			this.chkFile.CheckedChanged += new EventHandler(this.chkFile_CheckedChanged);
			this.dgridEncabezados.ItemCommand += new DataGridCommandEventHandler(this.dgridEncabezados_ItemCommand);
			this.dgridEncabezados.PreRender += new EventHandler(this.dgridEncabezados_PreRender);
			this.btnInforme.Click += new EventHandler(this.btnInforme_Click);
			this.Aceptar.Click += new EventHandler(this.Aceptar_Click);
			this.Load += new EventHandler(this.Page_Load);

		}

		#endregion

		private void Aceptar_Click(object sender, EventArgs e)
		{
			ReferenciasApp Referencia = new ReferenciasApp();
			Referencia.Descripcion = txtDescripcion.Text.ToUpper();
			Referencia.Observaciones = txtObservaciones.Text.ToUpper();

			string Path = "";
			int intIsFile = 0;
			if (chkFile.Checked)
			{
				Path = SubirArchivo();
				intIsFile = 1;
			}
			Referencia.Path = Path;
			Referencia.isFile = intIsFile;
			//UsuarioAutenticado Usuario = (UsuarioAutenticado) Session["UsuarioAutenticado"];
			if (Aceptar.Text == "Finalizar")
			{
				Referencia.Cargar(IdReferencia);

				Referencia.Descripcion = txtDescripcion.Text;
				Referencia.Observaciones = txtObservaciones.Text;
				Referencia.Path = Path;
				Referencia.isFile = intIsFile;
                
                if (cmbUsuarios.SelectedValue != "")
                    Referencia.IdUsuario = int.Parse(cmbUsuarios.SelectedValue);
                if (cmbUsuarios.SelectedValue.ToString() != "") Referencia.UsuarioCliente = cmbUsuarios.SelectedValue.ToString();
                else Referencia.UsuarioCliente = txtPersona.Text.ToUpper();
				Referencia.Estado = 5;

				Referencia.Modificar(IdReferencia);
				Response.Redirect("ListaReferencias.aspx");
			}
			else
			{
                if (cmbUsuarios.SelectedValue != "")
                    Referencia.IdUsuario = int.Parse(cmbUsuarios.SelectedValue);
                Referencia.IdCliente = int.Parse(hdIdCliente.Value);
                if (cmbUsuarios.SelectedValue != "") Referencia.UsuarioCliente = cmbUsuarios.SelectedValue.ToString();
                else Referencia.UsuarioCliente = txtPersona.Text.ToUpper();
				Referencia.Estado = 5;
				int idNewReferencia = Referencia.Crear();
				if (Aceptar.Text == "Aceptar")
					Response.Redirect("ListaReferencias.aspx");
				else
					Response.Redirect("altaReferencia.aspx?IdReferencia=" + idNewReferencia);
			}
		}

		private void chkFile_CheckedChanged(object sender, EventArgs e)
		{
			txtArchivo.Visible = chkFile.Checked;
			if (chkFile.Checked)
				Aceptar.Text = "Aceptar";
			else
				Aceptar.Text = "Siguiente >>";
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
					FileInfo ArchivoServer = new FileInfo(Server.MapPath(strPath + strFileName));
					// Escribo en disco
					WriteToFile(Server.MapPath(strPath + strFileName), ref myData);
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

		private void ListaEncabezados(int IdRef)
		{
			BandejaEntradaApp bandeja = new BandejaEntradaApp();
			dgridEncabezados.DataSource = bandeja.ListaEncabezados(IdRef);
			dgridEncabezados.DataBind();
		}

		private void btnInforme_Click(object sender, EventArgs e)
		{
            Response.Redirect("/BandejaEntrada/altaInforme.aspx?desdeRef=1&IdReferencia=" + IdReferencia);
		}

		private void dgridEncabezados_PreRender(object sender, EventArgs e)
		{
			foreach (DataGridItem myItem in dgridEncabezados.Items)
			{
				myItem.Cells[6].Text = "<IMG SRC='/img/Estado" + myItem.Cells[9].Text + ".gif' widht='14' height='14' border='0'>&nbsp;&nbsp;&nbsp;" + myItem.Cells[5].Text;
				if (int.Parse(myItem.Cells[9].Text) == 1 || int.Parse(myItem.Cells[9].Text) == 5)
				{
					((ImageButton) myItem.FindControl("Editar")).Attributes.Add("src", @"/img/modificar_general.gif");
					((ImageButton) myItem.FindControl("Editar")).ToolTip = "Modificar Informe";
					((ImageButton) myItem.FindControl("Cancelar")).Attributes.Add("onclick", @"javascript: return confirm('¿Está seguro que desea Cancelar el Informe?');");
				}
				else
				{
					((ImageButton) myItem.FindControl("Editar")).Attributes.Add("src", @"/img/lupita.gif");
					((ImageButton) myItem.FindControl("Editar")).ToolTip = "Visualizar Informe";
					((ImageButton) myItem.FindControl("Cancelar")).Attributes.Add("src", @"/img/reloj.jpg");
					((ImageButton) myItem.FindControl("Cancelar")).ToolTip = "Ver Historial";
				}
			}
		}

		private void CancelarEncabezado(int idEncabezado)
		{
			EncabezadoApp Encabezado = new EncabezadoApp();
			Encabezado.cargarEncabezado(idEncabezado);

			// Usuario Logueado
			UsuarioAutenticado Usuario = (UsuarioAutenticado) Session["UsuarioAutenticado"];
			Encabezado.IdCliente = Usuario.IdCliente;

			Encabezado.Cancelar(idEncabezado, false);
		}

		private void dgridEncabezados_ItemCommand(object source, DataGridCommandEventArgs e)
		{
			if (e.Item.Cells[0].Text != "")
			{
				switch (((ImageButton) e.CommandSource).CommandName)
				{
					case "Cancelar":
						int IdCodigo = int.Parse(e.Item.Cells[0].Text);
						if (int.Parse(e.Item.Cells[9].Text) == 1)
						{
							CancelarEncabezado(IdCodigo);
							Response.Redirect("altaReferencia.aspx?IdReferencia=" + IdReferencia);
						}
						else
							Response.Redirect("/BandejaEntrada/VerHistorial.aspx?id=" + e.Item.Cells[0].Text);
						break;

					case "Editar":
						if (int.Parse(e.Item.Cells[9].Text) == 1 || int.Parse(e.Item.Cells[9].Text) == 5)
							Response.Redirect("/BandejaEntrada/abmInforme.aspx?desdeRef=1&id=" + e.Item.Cells[0].Text);
						else
                            Response.Redirect("/BandejaEntrada/VerInforme.aspx?id=" + e.Item.Cells[0].Text);
						break;
				}
			}
        }
        /*
        #region ListaClientes(int idCliente)

        private void ListaClientes(int idCliente)
        {
            ClienteDal Clientes = new ClienteDal();
            cmbClientes.Items.Clear();
            DataTable myTable = Clientes.CargarDatos();
            ListItem myItemSeleccione = new ListItem("Seleccione un Cliente", "");
            cmbClientes.Items.Add(myItemSeleccione);
            ListItem myItem;
            string nombreEmpresa = "";
            foreach (DataRow myRow in myTable.Rows)
            {
                if (myRow[2].ToString() != "")
                {
                    nombreEmpresa = myRow[2].ToString();
                    if (myRow[3].ToString() != "")
                        nombreEmpresa = nombreEmpresa + " (" + myRow[3].ToString() + ")";
                }
                else
                    nombreEmpresa = myRow[1].ToString();

                myItem = new ListItem(nombreEmpresa.Trim(), myRow[0].ToString());
                if (idCliente == int.Parse(myRow[0].ToString()))
                {
                    cmbClientes.SelectedIndex = -1;
                    myItem.Selected = true;
                }

                cmbClientes.Items.Add(myItem);
            }
        }

        #endregion
         

        #region cmbClientes_SelectedIndexChanged

        protected void cmbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbClientes.SelectedValue != "")
                ListaUsuarios(int.Parse(cmbClientes.SelectedValue),-1);
            cmbClientes.Focus();
        }

        #endregion
        */


        #region ListaUsuarios(int idCliente, int idUsuario)

        private void ListaUsuarios(int idCliente, int idUsuario)
        {
            Usuario Usuarios = new Usuario();
            cmbUsuarios.Items.Clear();
            DataTable myTable = Usuarios.Listar("", idCliente);
            ListItem myItemSeleccione = new ListItem("Seleccione un Usuario", "");
            cmbUsuarios.Items.Add(myItemSeleccione);
            ListItem myItem;
            foreach (DataRow myRow in myTable.Rows)
            {
                if (myRow[2].ToString() != "")
                    myItem = new ListItem(myRow[3].ToString() + ", " + myRow[2].ToString(), myRow[0].ToString());
                else
                    myItem = new ListItem(myRow[3].ToString(), myRow[0].ToString());

                if (idUsuario == int.Parse(myRow[0].ToString()))
                {
                    cmbUsuarios.SelectedIndex = -1;
                    myItem.Selected = true;
                }

                cmbUsuarios.Items.Add(myItem);
            }
        }

        #endregion

        #region cmbUsuarios_SelectedIndexChanged

        /*
        protected void cmbUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            setValidaPersona();

/ *            if (cmbUsuarios.SelectedValue != "Seleccione un Usuario")
            {
                valPersona.Visible = false;
                txtPersona.Enabled = false;
                txtPersona.Text = "";
            }
            else
            {
                valPersona.Visible = true;
                txtPersona.Enabled = true;
            }
            cmbUsuarios.Focus();
 * /
        }
    */

        #endregion


        private void setValidaPersona()
        {
            if (cmbUsuarios.SelectedValue != "")
            {
                valPersona.Visible = false;
                txtPersona.Enabled = false;
                txtPersona.Text = "";
            }
            else
            {
                valPersona.Visible = true;
                txtPersona.Enabled = true;
            }
            cmbUsuarios.Focus();
        }


        protected void txtPersona_PreRender(object sender, EventArgs e)
        {
            txtPersona.Attributes.Add("onblur", "setearReferencia(this);");
        }


        #region cmbUsuarios_SelectedIndexChanged

        protected void cmbUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            //setValidaPersona();
            if (cmbUsuarios.SelectedValue != "")
            {
                valPersona.Visible = false;
                txtPersona.Enabled = false;
                txtPersona.Text = "";
                //ListaReferencia(int.Parse(cmbClientes.SelectedValue), int.Parse(cmbUsuarios.SelectedValue));
                DateTime ahora = DateTime.Now;
                Usuario nUsuario = new Usuario();
                nUsuario.Cargar(int.Parse(cmbUsuarios.SelectedValue));
                string nomUsuario = nUsuario.Apellido + ", " + nUsuario.Nombre + " " + ahora.Day + "/" + ahora.Month;
                if (txtDescripcion.Text == "" || nomUsuario != txtDescripcion.Text)
                    txtDescripcion.Text = nomUsuario;
            }
            else
            {
                valPersona.Visible = true;
                txtPersona.Enabled = true;
            }
            cmbUsuarios.Focus();
        }

        #endregion



        #region SubcmbClientes
        protected void SubcmbClientes(string IdCliente)
        {
            if (IdCliente != "")
            {
                if (cmbUsuarios.SelectedValue != "")
                    ListaUsuarios(int.Parse(IdCliente), int.Parse(cmbUsuarios.SelectedValue));
                else
                    ListaUsuarios(int.Parse(IdCliente), 0);
            }
            //cmbClientes.Focus();
            string direccion = "";
            ClienteDal dCliente = new ClienteDal();
            dCliente.Cargar(int.Parse(IdCliente));
            direccion = dCliente.Calle + " " + dCliente.Numero;
            if (dCliente.Piso != "")
                direccion = direccion + " Piso:" + dCliente.Piso;
            if (dCliente.Departamento != "")
                direccion = direccion + " Dpto:" + dCliente.Departamento;
            txtDireccion.Text = direccion;


            //VisualizarRecomendado();

        }

        #endregion
    }
}