using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.Clientes.Dal;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;
using System.Text;
using Microsoft.Office.Interop.Excel;
using System.Reflection;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.Dal;
using ar.com.TiempoyGestion.BackEnd.Informes.Dal;
using System.Net;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.ambientalBancor
{
    /// <summary>
    /// Summary description for Principal.
    /// </summary>
    public partial class importar : System.Web.UI.Page
    {
        private int IdTipo;
        private int idGrupo = 0;
        protected System.Web.UI.WebControls.Button Button1;
        private int IdUsuario = 1; //VALOR QUE SE OBTENDRA DEL CONTEXTO
        private int intIndex = 0;

        private Microsoft.Office.Interop.Excel.Application ApExcel = new Microsoft.Office.Interop.Excel.Application();
        private object opc = Type.Missing;
        private Microsoft.Office.Interop.Excel.Workbook libro;

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
                ListaBandeja();
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

        private void ListaBandeja()
        {
            IdTipo = 15;

            string Estados = "3";
            string FechaDesde = "";
            string FechaHasta = "";
            int Entregado = 0;
            if (chkEntregado.Checked) Entregado = 1;
            if (txtFechaDesde.Text == "")
                txtFechaDesde.Text = DateTime.Today.AddMonths(-3).ToShortDateString();
            FechaDesde = txtFechaDesde.Text;

            if (txtFechaHasta.Text == "")
                txtFechaHasta.Text = DateTime.Today.ToShortDateString();
            FechaHasta = txtFechaHasta.Text;


            if (Request.QueryString["idGrupo"] != null && Request.QueryString["idGrupo"] != "")
            {
                idGrupo = int.Parse(Request.QueryString["idGrupo"]);
                Entregado = 1;
            }

            InformeAmbiental IA = new InformeAmbiental();

            InformeBancorApp informes = new InformeBancorApp();

            dgExportar.DataSource = informes.ListaInformesBancor(IdTipo, Estados, FechaDesde, FechaHasta, Entregado, idGrupo);
            dgExportar.DataBind();
            /*
            if (dgLaboralesPendientes.Items.Count == 0)
            {
                dgLaboralesPendientes.Visible = false;
                //lblTitSUrgentes.Visible = false;
            }


            if (dgLaboralesPendientes.Items.Count == 0)
            {
                lblMensaje.Text = "No hay verificaciones laborales para procesar";
                lblMensaje.Visible = true;
                //btnImprimir.Visible = false;
            }
            */
        }


        protected void dgInformesImportados_PreRender(object sender, EventArgs e)
        {
            string strDescripcion = "";
            foreach (DataGridItem myItem in dgInformesImportados.Items)
            {
                //((Label)myItem.FindControl("lblFecha")).Text = DateTime.Parse(myItem.Cells[2].Text).ToShortDateString() + " " + DateTime.Parse(myItem.Cells[2].Text).ToShortTimeString();
            }
        }


        protected void dgInformesExportar_PreRender(object sender, EventArgs e)
        {
            string strDescripcion = "";
            foreach (DataGridItem myItem in dgExportar.Items)
            {
                ((System.Web.UI.WebControls.Label)myItem.FindControl("lblFecha")).Text = DateTime.Parse(myItem.Cells[2].Text).ToShortDateString() + " " + DateTime.Parse(myItem.Cells[2].Text).ToShortTimeString();
            }
        }


        protected void btnAceptar_Click(object sender, EventArgs e)
        {

            System.Web.UI.WebControls.CheckBox chkPersona;
            int intIdInforme;
            int intGrupo = 0;
            EncabezadoApp Encabezado = new EncabezadoApp();
            UsuarioAutenticado Usuario = (UsuarioAutenticado)Session["UsuarioAutenticado"];

            if (dgInformesImportados.Items.Count > 0)
                intGrupo = Encabezado.crearGrupoCambioEstado(Usuario.IdUsuario, 15);

            int idRef;
            ReferenciasApp Referencia = new ReferenciasApp();
            DateTime ahora = DateTime.Now;
            Usuario nUsuario = new Usuario();
            nUsuario.Cargar(2698);

            Referencia.Descripcion = nUsuario.Apellido + ", " + nUsuario.Nombre + " " + ahora.Day + "/" + ahora.Month;
            Referencia.Estado = 1;
            Referencia.Observaciones = "";
            Referencia.Path = "";
            Referencia.isFile = 0;
            //Referencia.IdUsuario = Usuario.IdUsuario;
            Referencia.UsuarioCliente = "";
            Referencia.IdCliente = 3490;
            idRef = Referencia.Crear();


			foreach(DataGridItem dgPerso in dgInformesImportados.Items)
			{
                chkPersona = (System.Web.UI.WebControls.CheckBox)dgPerso.FindControl("chkPersona");
				if(chkPersona.Checked)
				{
                    intIdInforme = crearEncabezado(dgPerso, idRef);
                    Encabezado.crearCambiosEstadoInformes(intGrupo, intIdInforme, 1);
				}
			}

            Response.Redirect("../BandejaEntrada/Principal.aspx?idTipo=15");
            //System.Threading.Thread.Sleep(0);
        }
         
         
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("../BandejaEntrada/Principal.aspx?idTipo=15");
        }

/*
        protected int crearGrupoCambioEstado()
        {
        
        }
*/
        protected void btnImpresiones_Click(object sender, EventArgs e)
        {
            Response.Redirect("historialimpresiones.aspx?idTipo=15");
        }


        protected void btnImportar_Click(object sender, EventArgs e)
        {
            string archivo = fuImportar.FileName;

            DataSet ds = GetExcel(archivo);
            dgInformesImportados.DataSource = ds;
            dgInformesImportados.DataBind();
            //GridView1.DataBind();
        }


        public DataSet GetExcel(string fileName)
        {
            Application oXL;
            Workbook oWB;
            Worksheet oSheet;
            Range oRng;
            try
            {
                //  creat a Application object
                oXL = new ApplicationClass();
                //   get   WorkBook  object
                oWB = oXL.Workbooks.Open(fileName, Missing.Value, Missing.Value,
                        Missing.Value, Missing.Value, Missing.Value,
                        Missing.Value, Missing.Value, Missing.Value,
                        Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                        Missing.Value, Missing.Value);

                //   get   WorkSheet object
                oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oWB.Sheets[1];
                System.Data.DataTable dt = new System.Data.DataTable("dtExcel");
                DataSet ds = new DataSet();
                ds.Tables.Add(dt);
                DataRow dr;
                bool bandera = true;
                StringBuilder sb = new StringBuilder();
                int jValue = oSheet.UsedRange.Cells.Columns.Count;
                int iValue = oSheet.UsedRange.Cells.Rows.Count;
                //  get data columns
                for (int j = 1; j <= jValue; j++)
                {
                    dt.Columns.Add("column" + j, System.Type.GetType("System.String"));
                }

                //  get data in cell
                for (int i = 2; i <= iValue; i++)
                {
                    dr = ds.Tables["dtExcel"].NewRow();
                    for (int j = 1; j <= jValue; j++)
                    {
                        oRng = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[i, j];
                        string strValue = oRng.Text.ToString();
                        if (j == 2 || j == 7 || j == 8)
                            strValue = strValue.Replace(".", "");
                        dr["column" + j] = strValue;
                        if (strValue.Trim() == "" && j == 1)
                            bandera = false;
                    }
                    if (bandera)
                        ds.Tables["dtExcel"].Rows.Add(dr);
                    bandera = true;                        
                }

                lblMensajeImportacion.Text = "Se encontraron <b>" + ds.Tables["dtExcel"].Rows.Count + "</b> registros para importar (" + fileName + ")";
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                Dispose();
            }
        }


        public int crearEncabezado(DataGridItem dgPerso, int idRef)
        {

            UsuarioAutenticado Usuario = (UsuarioAutenticado)Session["UsuarioAutenticado"];

            // Crear la referencia cuando se genera una nueva solicitud.
            // Tambien sirve de bandera para identificar si se crea o modifica un informe.
            

            EncabezadoApp Encabezado = new EncabezadoApp();
            Encabezado.IdTipoInforme = 15;
            // Usuario Logueado
            Encabezado.IdUsuario = Usuario.IdUsuario;
            Encabezado.IdCliente = 3490;
            Encabezado.UsuarioCliente = "2698";
            
            Encabezado.idReferencia = idRef;
            Encabezado.Estado = 1;
            Encabezado.ConFoto = 1;
            Encabezado.Caracter = 1;
            Encabezado.IdTipoPersona = 1;
            //string[] NyA;
            //if (dgPerso.Cells[1].Text != "")
            string[] NyA = dgPerso.Cells[1].Text.Split(',');
            if (NyA.Length > 1)
            {
                Encabezado.Nombre = NyA[1];
                Encabezado.Apellido = NyA[0];
            }
            else
            {
                Encabezado.Nombre = NyA[0];
                Encabezado.Apellido = "";
            }
            Encabezado.EstadoCivil = 2;
            Encabezado.TipoDocumento = 1;
            //Encabezado.txtTipoDocumento = dgPerso.Cells[1].Text;
            Encabezado.Barrio = "";
            Encabezado.Documento = dgPerso.Cells[2].Text;
            Encabezado.Calle = dgPerso.Cells[3].Text;
            Encabezado.Nro = dgPerso.Cells[4].Text;
            Encabezado.CP = dgPerso.Cells[5].Text;
            Encabezado.Localidad = 1;
            Encabezado.Provincia = 2;
            Encabezado.LocalidadTxt = dgPerso.Cells[6].Text;
            Encabezado.RazonSocial = "";
            Encabezado.CalleEmpresa = "";
            Encabezado.BarrioEmpresa = "";
            // Automotores
            
            bool est = Encabezado.Crear();
            if (est)
                return Encabezado.ObtenerUltimoInforme();
            else
                return 0;
        }

        protected void menuTab_MenuItemClick(object sender, MenuEventArgs e)
        {
            contenedor.ActiveViewIndex = Int32.Parse(e.Item.Value);
            e.Item.Selected = true;
            if (menuTab.SelectedItem != null)
                Response.Write("<script>menu = " + menuTab.SelectedItem.Value + ";</script>");

            //ListaBandeja(Int32.Parse(e.Item.Value));
        }
        protected void btnAplicar_Click(object sender, EventArgs e)
        {
            if (menuTab.SelectedItem != null)
                Response.Write("<script>menu = " + menuTab.SelectedItem.Value + ";</script>");
            ListaBandeja();
        }

        protected void btnGenerarExcel_Click(object sender, EventArgs e)
        {
            int intIdInforme;
            int intGrupo = 0;
            int idUsuario = 2698; // Usuario Bancor
            int idCliente = 3490; // Cliente Bancor

            EncabezadoApp Encabezado = new EncabezadoApp();
            UsuarioAutenticado Usuario = (UsuarioAutenticado)Session["UsuarioAutenticado"];

            if (dgExportar.Items.Count > 0)
                intGrupo = Encabezado.crearGrupoCambioEstado(Usuario.IdUsuario, 15);

            int idRef;
            ReferenciasApp Referencia = new ReferenciasApp();
            DateTime ahora = DateTime.Now;
            Usuario nUsuario = new Usuario();
            nUsuario.Cargar(idUsuario);

            Referencia.Descripcion = nUsuario.Apellido + ", " + nUsuario.Nombre + " " + ahora.Day + "/" + ahora.Month;
            Referencia.Estado = 1;
            Referencia.Observaciones = "";
            Referencia.Path = "";
            Referencia.isFile = 0;
            //Referencia.IdUsuario = Usuario.IdUsuario;
            Referencia.UsuarioCliente = "";
            Referencia.IdCliente = idCliente;
            idRef = Referencia.Crear();

            Response.Write("<script>menu = " + menuTab.SelectedItem.Value + ";</script>");
            /*
            Microsoft.Office.Interop.Excel.ApplicationClass ExcelApp = new Microsoft.Office.Interop.Excel.ApplicationClass();
            ExcelApp.Application.Workbooks.Add(Type.Missing);
            ExcelApp.Columns.ColumnWidth = 30;

            for (int i = 0; i < dgExportar.Rows.Count; i++)
            {
                DataGridViewRow row = ReportDataGridView.Rows[i];
                for (int j = 0; j < row.Cells.Count; j++)
                {
                    ExcelApp.Cells[i + 1, j + 1] = row.Cells[j].ToString();
                }
            }
            */

            
            libro = ApExcel.Workbooks.Add(opc);
            ApExcel.Visible = true;

            libro = ApExcel.Workbooks.Add(opc);
            Microsoft.Office.Interop.Excel.Worksheet hoja1 = new Microsoft.Office.Interop.Excel.Worksheet();

            hoja1 = (Microsoft.Office.Interop.Excel.Worksheet)libro.Sheets.Add(opc, opc, opc, opc);

            hoja1.Activate();
            //hoja1.Cells[1,1] = 100;

            int ac = 1;
            System.Web.UI.WebControls.CheckBox chkPersona;

            hoja1.Cells[1, 1] = "Apellido y nombre";
            hoja1.Cells[1, 2] = "Documento";
            hoja1.Cells[1, 3] = "Tipo de vivienda";
            hoja1.Cells[1, 4] = "Destino del inmueble";
            hoja1.Cells[1, 5] = "Estado de conservacion";
            hoja1.Cells[1, 6] = "Habita/vive en caracter de ";
            hoja1.Cells[1, 7] = "Resultado";
            hoja1.Cells[1, 8] = "Observaciones";
            hoja1.Range["a1:h1"].Font.Bold = true;
            //hoja1.Range["a1:h1"].colorIndex = 15;
            foreach (DataGridItem myItem in dgExportar.Items)
            {
                chkPersona = ((System.Web.UI.WebControls.CheckBox)dgExportar.Items[myItem.DataSetIndex].FindControl("chkSUrgente"));
                //chkPersona = (System.Web.UI.WebControls.CheckBox)dgExportar.FindControl("chkSUrgente");
                if (chkPersona.Checked)
                {
                    //ac = myItem.ItemIndex + 2;
                    ac += 1;
                    hoja1.Cells[ac, 1] = myItem.Cells[4].Text;
                    hoja1.Cells.Columns.ColumnWidth = 25;
                    hoja1.Cells[ac, 2] = myItem.Cells[5].Text;
                    hoja1.Cells.Columns.ColumnWidth = 11;
                    hoja1.Cells[ac, 3] = myItem.Cells[6].Text;
                    hoja1.Cells.Columns.ColumnWidth = 15;
                    hoja1.Cells[ac, 4] = myItem.Cells[7].Text;
                    hoja1.Cells.Columns.ColumnWidth = 20;
                    hoja1.Cells[ac, 5] = myItem.Cells[8].Text;
                    hoja1.Cells.Columns.ColumnWidth = 20;
                    hoja1.Cells[ac, 6] = myItem.Cells[9].Text;
                    hoja1.Cells.Columns.ColumnWidth = 16;
                    hoja1.Cells[ac, 7] = myItem.Cells[10].Text;
                    hoja1.Cells.Columns.ColumnWidth = 10;
                    hoja1.Cells[ac, 8] = myItem.Cells[11].Text.Replace("&nbsp;", "");
                    //hoja1.Cells.Columns.ColumnWidth = 80;
                    Encabezado.Entregado = 1;
                    Encabezado.CambiarEntregado(int.Parse(myItem.Cells[1].Text));
                    Encabezado.crearCambiosEstadoInformes(intGrupo, int.Parse(myItem.Cells[1].Text), 3);
                }
            }
            /*
            for (int i = 0; i < dgExportar.Items.Count; i++)
            {
                DataGridRow row = ReportDataGridView.Rows[i];
                for (int j = 0; j < row.Cells.Count; j++)
                {
                    ExcelApp.Cells[i + 1, j + 1] = row.Cells[j].ToString();
                }
            }
             */
            DateTime fechaActual = DateTime.Now;
            string fechaArchivo = fechaActual.Year.ToString() + fechaActual.Month.ToString() + fechaActual.Day.ToString();

            //hoja1.SaveAs("D:\\Sitios\\TyG\trunk\\FrontEnd\\Intranet\\res\\bancor\\bancor_" + fechaArchivo);
            hoja1.SaveAs("F:\\Sitios\\Res\\bancor\\bancor_" + fechaArchivo);


            hoja1 = null;
            libro.Close(false);
            libro = null;
            ApExcel.Quit();
            ApExcel = null;

            //WebClient webClient = new WebClient();
            string urlDw = "http://www.tiempoygestion.com.ar:81/Res/bancor/";
            string fileDw = "bancor_" + fechaArchivo + ".xls";
            lblDescargar.Visible = true;
            hlDescargar.Visible = true;
            lblDescargar.Text = "Descargar planilla ";
            hlDescargar.Text = fileDw;
            hlDescargar.NavigateUrl = urlDw + fileDw;

            //webClient.DownloadFile(urlDw + fileDw, fileDw);

            //System.IO.FileInfo toDownload =new System.IO.FileInfo(urlDw + fileDw); 

            //Response.AddHeader("Content-Disposition", "attachment; filename=" + fileDw);
            //Response.AddHeader("Content-Length", toDownload.Length.ToString());
            //Response.ContentType = "application/octet-stream";
            //Response.WriteFile(urlDw + fileDw);
            //Response.End();

            /*
             //FUNCA
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=FileName.xls");
            Response.Charset = "";
            //Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.xls";
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            dgExportar.RenderControl(htmlWrite);
            Response.Write(stringWrite.ToString());
            Response.End();
            */

        }



}
}