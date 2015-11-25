using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.Clientes.Dal;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;
using System.Configuration;
using System.IO;
using System.Data.OleDb;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.BandejaEntrada
{
    /// <summary>
    /// Summary description for Principal.
    /// </summary>
    public partial class partidasdefuncion_importar : Page
    {
        private int IdTipo;
        private int IdUsuario = 1; //VALOR QUE SE OBTENDRA DEL CONTEXTO
        private int intIndex = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["Tab"] != null && Request.QueryString["Tab"] != "")
                {
                    intIndex = int.Parse(Request.QueryString["Tab"]);
                    contenedor.ActiveViewIndex = intIndex;
                    Response.Write("<script>var menu = 1;</script>");
                }
                else
                    Response.Write("<script>var menu = 0;</script>");

                menuTab.Items[intIndex].Selected = true;
                ListaBandeja(intIndex);
            }
            else
            {
                if (menuTab.SelectedItem != null)
                    Response.Write("<script>menu = " + menuTab.SelectedItem.Value + ";</script>");

                //actualizarEstados();
                
            }
        }


        #region Web Form Designer generated code

        protected override void OnInit(EventArgs e)
        {
            //
            // CODEGEN: This call is required by the ASP.NET Web Form Designer.
            //
            InitializeComponent();

            UsuarioAutenticado Usuario = (UsuarioAutenticado)Session["UsuarioAutenticado"];
            IdUsuario = Usuario.IdUsuario;

            base.OnInit(e);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            //this.dgridEncabezados.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgridEncabezados_ItemCommand);

        }

        #endregion

        private void ListaBandeja(int idTab)
        {
            int idUser = -1;
            IdTipo = 19;
            string pFiltro = "";
            string Estados = "1,5";
            lblMensaje.Text = "";

            if (idTab == 1)
            {
                pnEnEspera.Visible = true;

                BandejaEntradaApp bandeja = new BandejaEntradaApp();
                //if (chkSoloMias.Checked) idUser = IdUsuario;
                dgridEnEspera.DataSource = bandeja.ListaEncabezados(IdTipo, pFiltro, -1, idUser, Estados, 1, "", "", 300, false);
                dgridEnEspera.DataBind();
                if (dgridEnEspera.Items.Count == 0)
                    pnEnEspera.Visible = false;


                if (dgridEnEspera.Items.Count == 0)
                {
                    lblMensaje.Text = "No hay Informes de partidas de defunción en Espera";
                    lblMensaje.Visible = true;
                    //btnImprimir.Visible = false;
                }
            }

            if (idTab == 2)
            {
                int idTipo = 19;
                ListarHistorial(idTipo);
                
            }



        }


        private void ListarHistorial(int idTipo)
        {

            lblMensaje.Text = "";


            BandejaEntradaApp listado = new BandejaEntradaApp();
            //if (chkSoloMias.Checked) idUser = IdUsuario;
            rpHistorial.DataSource = listado.ListarHistorialInformesEnviados(idTipo);
            rpHistorial.DataBind();


            if (rpHistorial.Items.Count == 0)
            {
                lblMensaje.Text = "No hay historial de Informes de Partidas de Defunción.";
                lblMensaje.Visible = true;
            }

        }


        protected void dgridEnEspera_PreRender(object sender, EventArgs e)
        {
            string strDescripcion = "";
            foreach (DataGridItem myItem in dgridEnEspera.Items)
            {
                ((Label)myItem.FindControl("lblFecha")).Text = DateTime.Parse(myItem.Cells[2].Text).ToShortDateString() + " " + DateTime.Parse(myItem.Cells[2].Text).ToShortTimeString();
                //strDescripcion = "<b>Apellido y Nombre: </b> " + myItem.Cells[6].Text + " " + myItem.Cells[7].Text + ", DNI: " + myItem.Cells[4].Text + ", Sexo: " + myItem.Cells[5].Text;
                //((Label)myItem.FindControl("lblDescripcion")).Text = strDescripcion;

            }
        }


        

        /*
        protected void btnImprimir_PreRender(object sender, EventArgs e)
        {
            btnImprimir.Attributes.Add("onclick", "window.print();");
        }
        */

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            CheckBox chkSelSUrgente;
            int intIdInforme;
            int intGrupo = 0;
            EncabezadoApp Encabezado = new EncabezadoApp();
            UsuarioAutenticado Usuario = (UsuarioAutenticado)Session["UsuarioAutenticado"];

            if (dgridEnEspera.Items.Count > 0)
                intGrupo = Encabezado.crearGrupoCambioEstado(Usuario.IdUsuario, 19);
            
            foreach (DataGridItem dgSUrg in dgridEnEspera.Items)
			{
				chkSelSUrgente = (CheckBox)dgSUrg.FindControl("chkSUrgente");
				if(chkSelSUrgente.Checked)
				{
                    intIdInforme = int.Parse(dgSUrg.Cells[0].Text);
                    Encabezado.cargarEncabezado(intIdInforme);
                    Encabezado.Estado = 2;
                    Encabezado.CambiarEstado(intIdInforme);
                    Encabezado.Leido = 1;
                    Encabezado.CambiarLeido(intIdInforme);
                    Encabezado.crearCambiosEstadoInformes(intGrupo, intIdInforme, 2);
				}
			}


            Response.Redirect("historialimpresiones.aspx?idTipo=19");
       }


        

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("../BandejaEntrada/Principal.aspx?idTipo=19");
        }



        

        protected void menuTab_MenuItemClick(object sender, MenuEventArgs e)
        {
            contenedor.ActiveViewIndex = Int32.Parse(e.Item.Value);
            e.Item.Selected = true;
            if (menuTab.SelectedItem != null)
                Response.Write("<script>menu = " + menuTab.SelectedItem.Value + ";</script>");

            ListaBandeja(Int32.Parse(e.Item.Value));
        }

        

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            ListaBandejaFiltro();
        }

        private void ListaBandejaFiltro()
        {
            int idTab = contenedor.ActiveViewIndex;
            menuTab.Items[idTab].Selected = true;
            int idUser = -1;
            string pFiltro = txtContengan.Text;
            if (chkSoloMias.Checked) idUser = IdUsuario;
            int idCliente = -1;
            string Estados = "1,5";
            int IdTipo = 1;

            if (idTab == 0)
            {
                pnEnEspera.Visible = true;
                

                Response.Write("<script>var menu = 0;</script>");    
                BandejaEntradaApp bandeja = new BandejaEntradaApp();
                //if (chkSoloMias.Checked) idUser = IdUsuario;
                dgridEnEspera.DataSource = bandeja.ListaEncabezados(IdTipo, pFiltro, idCliente, idUser, Estados, 3, "", "", 100, false);
                dgridEnEspera.DataBind();
                if (dgridEnEspera.Items.Count == 0)
                    pnEnEspera.Visible = false;

                
            }

            if (idTab == 1)
            {
                
            }

        }

        protected void btnImpresiones_Click(object sender, EventArgs e)
        {
            Response.Redirect("historialimpresiones.aspx?idTipo=19");
        }


        protected string diferenciaFecha(string fecha)
        {
            DateTime fechaActual = DateTime.Now;
            DateTime fechaCon = DateTime.Parse(fecha);
            TimeSpan dif;
            string difFecha = "";
            int d;
            int h;
            int m;
            dif = fechaActual - fechaCon;
            d = dif.Days;
            h = dif.Hours;
            m = dif.Minutes;

            if (d > 0)
            {
                difFecha = " " + d.ToString() + " día";
                if (d > 1)
                    difFecha = difFecha + "s ";
                else
                    difFecha = difFecha + " ";
            }

            if (h > 0)
            {
                difFecha = " " + difFecha + h.ToString() + " hora";
                if (h > 1)
                    difFecha = difFecha + "s ";
                else
                    difFecha = difFecha + " ";
            }

            if (m > 0)
            {
                difFecha = " " + difFecha + m.ToString() + " minuto";
                if (m > 1)
                    difFecha = difFecha + "s ";
                else
                    difFecha = difFecha + " ";
            }
            else
                difFecha = "hace instantes";

            return difFecha;
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


        

   
        protected void btnConUDP_Click(object sender, EventArgs e)
        {
            //lblConUDP.Text = "Presionó el boton de carga asincrono con Update Panel. Note que la pagina no se refresco";
        }


        protected void btnProcesar_Click(object sender, EventArgs e)
        {
            pnExaminar.Visible = false;
            pnObtener.Visible = true;


            if (fuExcel.HasFile)
            {
                string FileName = Path.GetFileName(fuExcel.PostedFile.FileName);
                string Extension = Path.GetExtension(fuExcel.PostedFile.FileName);
                string FolderPath = ConfigurationManager.AppSettings["FolderPath"];

                string FilePath = Server.MapPath(FolderPath + FileName);
                fuExcel.SaveAs(FilePath);
                Import_To_Grid(FilePath, Extension, rbHDR.SelectedItem.Text);
            }

        }


        private void Import_To_Grid(string FilePath, string Extension, string isHDR)
        {
            string conStr = "";
            switch (Extension)
            {
                case ".xls": //Excel 97-03
                    conStr = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
                    break;
                case ".xlsx": //Excel 07
                    conStr = ConfigurationManager.ConnectionStrings["Excel07ConString"].ConnectionString;
                    break;
            }
            conStr = String.Format(conStr, FilePath, isHDR);
            OleDbConnection connExcel = new OleDbConnection(conStr);
            OleDbCommand cmdExcel = new OleDbCommand();
            OleDbDataAdapter oda = new OleDbDataAdapter();
            DataTable dt = new DataTable();
            cmdExcel.Connection = connExcel;

            //Get the name of First Sheet
            connExcel.Open();
            DataTable dtExcelSchema;
            dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
            connExcel.Close();

            //Read Data from First Sheet
            connExcel.Open();
            cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";
            oda.SelectCommand = cmdExcel;
            oda.Fill(dt);
            Session["dtGrilla"] = dt;
            connExcel.Close();

            //Bind Data to GridView
            GridView1.Caption = Path.GetFileName(FilePath);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            lblCantidad.Text = "Cantidad de registros a importar: " + dt.Rows.Count;
            lblMensaje.Visible = false;

        }
        protected void PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            string FolderPath = ConfigurationManager.AppSettings["FolderPath"];
            string FileName = GridView1.Caption;
            string Extension = Path.GetExtension(FileName);
            string FilePath = Server.MapPath(FolderPath + FileName);

            Import_To_Grid(FilePath, Extension, rbHDR.SelectedItem.Text);
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();
        }
        protected void btnFinalizar_Click(object sender, EventArgs e)
        {
            int vDNI = 0;
            int vNombre = 0;
            int vApellido = 0;
            int vSexo = 0;
            int vCUIT = 0;
            int idRef;

            vDNI = int.Parse(cmbColDNI.SelectedValue);
            vApellido = int.Parse(cmbColApellido.SelectedValue);
            if (cmbColNombre.SelectedValue != "")
                vNombre = int.Parse(cmbColNombre.SelectedValue);
            vSexo = int.Parse(cmbColSexo.SelectedValue);
            vCUIT = int.Parse(cmbColCUIT.SelectedValue);


            UsuarioAutenticado Usuario = (UsuarioAutenticado)Session["UsuarioAutenticado"];

            // Crear la referencia cuando se genera una nueva solicitud.
            ReferenciasApp Referencia = new ReferenciasApp();
            Referencia.Descripcion = "";
            Referencia.Estado = 1;
            Referencia.Observaciones = "";
            Referencia.Path = "";
            Referencia.isFile = 0;
            Referencia.IdUsuario = Usuario.IdUsuario;
            Referencia.IdCliente = 3490; // BANCOR
            idRef = Referencia.Crear();
            string tDNI = "";
            string tApellido = "";
            string tNombre = "";
            string tSexo = "";
            string tCUIT = "";


            DataTable dt = Session["dtGrilla"] as DataTable;

            foreach (DataRow dgImportar in dt.Rows)
            {
                //intIdInforme = int.Parse(dgImportar.Cells[0].Text);
                //Encabezado.crearCambiosEstadoInformes(intGrupo, intIdInforme, 2);
                tDNI = dgImportar[vDNI - 1].ToString();
                tApellido = dgImportar[vApellido - 1].ToString();
                if (vNombre !=0)
                    tNombre = dgImportar[vNombre - 1].ToString();
                tSexo = dgImportar[vSexo - 1].ToString();
                tCUIT = dgImportar[vCUIT - 1].ToString();

                InsertarEncabezadosPartidas(idRef, Usuario.IdUsuario, tDNI, tApellido, tNombre, tSexo, tCUIT);
            }

            pnObtener.Visible = false;
            pnProcesoFinalizado.Visible = true;
        }


            private void InsertarEncabezadosPartidas(int vReferencia, int vidUsuario, string vDNI, string vApellido, string vNombre, string vSexo, string vCUIT) 
            {
                EncabezadoApp Encabezado = new EncabezadoApp();
                Encabezado.IdTipoInforme = 19;
                // Usuario Logueado
                Encabezado.IdUsuario = vidUsuario;
                Encabezado.IdCliente = 3490;
                Encabezado.idReferencia = vReferencia;
                Encabezado.Estado = 1;
                Encabezado.Comentarios = "";
                Encabezado.ConFoto = 0;
                Encabezado.Caracter = 1;
                Encabezado.IdTipoPersona = 1;
                Encabezado.Nombre = vNombre;
                Encabezado.Apellido = vApellido;
                Encabezado.EstadoCivil = 1;
                Encabezado.TipoDocumento = 1;
                Encabezado.txtTipoDocumento = "DNI";
                Encabezado.Documento = vDNI;
                Encabezado.Cuit = vCUIT;
                Encabezado.Calle = "";
                Encabezado.Barrio = "";
                Encabezado.CatCalle = "";
                Encabezado.RazonSocial = "";
                Encabezado.CalleEmpresa = "";
                Encabezado.BarrioEmpresa = "";
                Encabezado.ProvinciaEmpresa = 2;
                Encabezado.LocalidadEmpresa = 1;
                Encabezado.Provincia = 2;
                Encabezado.Localidad = 1;

                if(vSexo != "") {
                    if(vSexo.ToLower() == "m")
                        Encabezado.Sexo = 1;
                    else
                        Encabezado.Sexo = 2;
                }
                
                Encabezado.Crear();
        }
    }
}