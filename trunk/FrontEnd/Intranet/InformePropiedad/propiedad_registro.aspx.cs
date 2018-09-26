using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.Clientes.Dal;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.BandejaEntrada
{
    /// <summary>
    /// Summary description for Principal.
    /// </summary>
    public partial class propiedad_registro : Page
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
            else if (contenedor.ActiveViewIndex == 4) //Transferidos
            {
                if (menuTab.SelectedItem != null)
                    Response.Write("<script>menu = " + menuTab.SelectedItem.Value + ";</script>");

                actualizarEstados();
                
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
            IdTipo = 1;
            string pFiltro = "";
            string Estados = "1,5";
            lblMensaje.Text = "";

            if (idTab == 0)
            {
                pnEnEsperaDigitales.Visible = true;
                pnEnEsperaSUrgentes.Visible = true;
                pnEnEsperaUrgentes.Visible = true;
                pnEnEsperaNormales.Visible = true;

                BandejaEntradaApp bandeja = new BandejaEntradaApp();
                //if (chkSoloMias.Checked) idUser = IdUsuario;

                dgridEnEsperaDigitales.DataSource = bandeja.ListaEncabezados(IdTipo, pFiltro, -1, idUser, Estados, 4, "", "", 100, false);
                dgridEnEsperaDigitales.DataBind();
                if (dgridEnEsperaDigitales.Items.Count == 0)
                    pnEnEsperaDigitales.Visible = false;

                dgridEnEsperaSUrgentes.DataSource = bandeja.ListaEncabezados(IdTipo, pFiltro, -1, idUser, Estados, 3, "", "", 100, false);
                dgridEnEsperaSUrgentes.DataBind();
                if (dgridEnEsperaSUrgentes.Items.Count == 0)
                    pnEnEsperaSUrgentes.Visible = false;

                dgridEnEsperaUrgentes.DataSource = bandeja.ListaEncabezados(IdTipo, pFiltro, -1, idUser, Estados, 2, "", "", 100, false);
                dgridEnEsperaUrgentes.DataBind();

                if (dgridEnEsperaUrgentes.Items.Count == 0)
                    pnEnEsperaUrgentes.Visible = false;

                dgridEnEsperaNormales.DataSource = bandeja.ListaEncabezados(IdTipo, pFiltro, -1, idUser, Estados, 1, "", "", 100, false);
                dgridEnEsperaNormales.DataBind();

                if (dgridEnEsperaNormales.Items.Count == 0)
                    pnEnEsperaNormales.Visible = false;


                if ((dgridEnEsperaDigitales.Items.Count == 0) && (dgridEnEsperaSUrgentes.Items.Count == 0) && (dgridEnEsperaUrgentes.Items.Count == 0) && (dgridEnEsperaNormales.Items.Count == 0))
                {
                    lblMensaje.Text = "No hay Informes de Propiedad para generar el formulario taza.";
                    lblMensaje.Visible = true;
                    //btnImprimir.Visible = false;
                }
            }

            if (idTab == 1)
            {
                pnEnProcesoDigitales.Visible = true;
                pnEnProcesoSUrgentes.Visible = true;
                pnEnProcesoUrgentes.Visible = true;
                pnEnProcesoNormales.Visible = true;

                Estados = "2";
                BandejaEntradaApp bandeja = new BandejaEntradaApp();
                //if (chkSoloMias.Checked) idUser = IdUsuario;
                dgridEnProcesoDigitales.DataSource = bandeja.ListaEncabezados(IdTipo, pFiltro, -1, idUser, Estados, 4, "", "", 100, false);
                dgridEnProcesoDigitales.DataBind();
                if (dgridEnProcesoDigitales.Items.Count == 0)
                    pnEnProcesoDigitales.Visible = false;

                dgridEnProcesoSUrgentes.DataSource = bandeja.ListaEncabezados(IdTipo, pFiltro, -1, idUser, Estados, 3, "", "", 100, false);
                dgridEnProcesoSUrgentes.DataBind();
                if (dgridEnProcesoSUrgentes.Items.Count == 0)
                    pnEnProcesoSUrgentes.Visible = false;

                dgridEnProcesoUrgentes.DataSource = bandeja.ListaEncabezados(IdTipo, pFiltro, -1, idUser, Estados, 2, "", "", 100, false);
                dgridEnProcesoUrgentes.DataBind();
                if (dgridEnProcesoUrgentes.Items.Count == 0)
                    pnEnProcesoUrgentes.Visible = false;

                dgridEnProcesoNormales.DataSource = bandeja.ListaEncabezados(IdTipo, pFiltro, -1, idUser, Estados, 1, "", "", 100, false);
                dgridEnProcesoNormales.DataBind();
                if (dgridEnProcesoNormales.Items.Count == 0)
                    pnEnProcesoNormales.Visible = false;


                if ((dgridEnProcesoDigitales.Items.Count == 0) && (dgridEnProcesoSUrgentes.Items.Count == 0) && (dgridEnProcesoUrgentes.Items.Count == 0) && (dgridEnProcesoNormales.Items.Count == 0))
                {
                    lblMensaje.Text = "No hay Informes de Propiedad para enviar al registro";
                    lblMensaje.Visible = true;
                    //btnImprimir.Visible = false;
                }
            }

            if (idTab == 2)
            {
                pnProblemaDigitales.Visible = true;
                pnProblemaSUrgentes.Visible = true;
                pnProblemaUrgentes.Visible = true;
                pnProblemaNormales.Visible = true;

                Estados = "9";
                BandejaEntradaApp bandeja = new BandejaEntradaApp();
                //if (chkSoloMias.Checked) idUser = IdUsuario;
                dgridProblemaDigitales.DataSource = bandeja.ListaEncabezados(IdTipo, pFiltro, -1, idUser, Estados, 4, "", "", 100, false);
                dgridProblemaDigitales.DataBind();
                if (dgridProblemaDigitales.Items.Count == 0)
                    pnProblemaDigitales.Visible = false;

                dgridProblemaSUrgentes.DataSource = bandeja.ListaEncabezados(IdTipo, pFiltro, -1, idUser, Estados, 3, "", "", 100, false);
                dgridProblemaSUrgentes.DataBind();
                if (dgridProblemaSUrgentes.Items.Count == 0)
                    pnProblemaSUrgentes.Visible = false;

                dgridProblemaUrgentes.DataSource = bandeja.ListaEncabezados(IdTipo, pFiltro, -1, idUser, Estados, 2, "", "", 100, false);
                dgridProblemaUrgentes.DataBind();
                if (dgridProblemaUrgentes.Items.Count == 0)
                    pnProblemaUrgentes.Visible = false;

                dgridProblemaNormales.DataSource = bandeja.ListaEncabezados(IdTipo, pFiltro, -1, idUser, Estados, 1, "", "", 100, false);
                dgridProblemaNormales.DataBind();
                if (dgridProblemaNormales.Items.Count == 0)
                    pnProblemaNormales.Visible = false;


                if ((dgridProblemaDigitales.Items.Count == 0) && (dgridProblemaSUrgentes.Items.Count == 0) && (dgridProblemaUrgentes.Items.Count == 0) && (dgridProblemaNormales.Items.Count == 0))
                {
                    lblMensaje.Text = "No hay Informes de Propiedad con problemas.";
                    lblMensaje.Visible = true;
                    //btnImprimir.Visible = false;
                }
            }


            if (idTab == 3)
            {
                pnTransferidoDigitales.Visible = true;
                pnTransferidoSUrgentes.Visible = true;
                pnTransferidoUrgentes.Visible = true;
                pnTransferidoNormales.Visible = true;
                pnTransferidoDetalles.Visible = false;

                Estados = "10";
                BandejaEntradaApp bandeja = new BandejaEntradaApp();
                //if (chkSoloMias.Checked) idUser = IdUsuario;
                dgridTransferidoDigitales.DataSource = bandeja.ListaEncabezados(IdTipo, pFiltro, -1, idUser, Estados, 4, "", "", 100, false);
                dgridTransferidoDigitales.DataBind();
                if (dgridTransferidoDigitales.Items.Count == 0)
                    pnTransferidoDigitales.Visible = false;

                dgridTransferidoSUrgentes.DataSource = bandeja.ListaEncabezados(IdTipo, pFiltro, -1, idUser, Estados, 3, "", "", 100, false);
                dgridTransferidoSUrgentes.DataBind();
                if (dgridTransferidoSUrgentes.Items.Count == 0)
                    pnTransferidoSUrgentes.Visible = false;

                dgridTransferidoUrgentes.DataSource = bandeja.ListaEncabezados(IdTipo, pFiltro, -1, idUser, Estados, 2, "", "", 100, false);
                dgridTransferidoUrgentes.DataBind();
                if (dgridTransferidoUrgentes.Items.Count == 0)
                    pnTransferidoUrgentes.Visible = false;

                dgridTransferidoNormales.DataSource = bandeja.ListaEncabezados(IdTipo, pFiltro, -1, idUser, Estados, 1, "", "", 100, false);
                dgridTransferidoNormales.DataBind();
                if (dgridTransferidoNormales.Items.Count == 0)
                    pnTransferidoNormales.Visible = false;


                if ((dgridTransferidoDigitales.Items.Count == 0) && (dgridTransferidoSUrgentes.Items.Count == 0) && (dgridTransferidoUrgentes.Items.Count == 0) && (dgridTransferidoNormales.Items.Count == 0))
                {
                    lblMensaje.Text = "No hay Informes de Propiedad Transferidos.";
                    lblMensaje.Visible = true;
                    //btnImprimir.Visible = false;
                }
            }

            if (idTab == 4)
            {
                pnCondicionalDigitales.Visible = true;
                pnCondicionalSUrgentes.Visible = true;
                pnCondicionalUrgentes.Visible = true;
                pnCondicionalNormales.Visible = true;

                Estados = "11";
                BandejaEntradaApp bandeja = new BandejaEntradaApp();
                //if (chkSoloMias.Checked) idUser = IdUsuario;
                dgridCondicionalDigitales.DataSource = bandeja.ListaEncabezados(IdTipo, pFiltro, -1, idUser, Estados, 4, "", "", 100, false);
                dgridCondicionalDigitales.DataBind();
                if (dgridCondicionalDigitales.Items.Count == 0)
                    pnCondicionalDigitales.Visible = false;

                dgridCondicionalSUrgentes.DataSource = bandeja.ListaEncabezados(IdTipo, pFiltro, -1, idUser, Estados, 3, "", "", 100, false);
                dgridCondicionalSUrgentes.DataBind();
                if (dgridCondicionalSUrgentes.Items.Count == 0)
                    pnCondicionalSUrgentes.Visible = false;

                dgridCondicionalUrgentes.DataSource = bandeja.ListaEncabezados(IdTipo, pFiltro, -1, idUser, Estados, 2, "", "", 100, false);
                dgridCondicionalUrgentes.DataBind();

                if (dgridCondicionalUrgentes.Items.Count == 0)
                    pnCondicionalUrgentes.Visible = false;

                dgridCondicionalNormales.DataSource = bandeja.ListaEncabezados(IdTipo, pFiltro, -1, idUser, Estados, 1, "", "", 100, false);
                dgridCondicionalNormales.DataBind();

                if (dgridCondicionalNormales.Items.Count == 0)
                    pnCondicionalNormales.Visible = false;


                if ((dgridCondicionalDigitales.Items.Count == 0) && (dgridCondicionalSUrgentes.Items.Count == 0) && (dgridCondicionalUrgentes.Items.Count == 0) && (dgridCondicionalNormales.Items.Count == 0))
                {
                    lblMensaje.Text = "No hay Informes de Propiedad condicionales.";
                    lblMensaje.Visible = true;
                    //btnImprimir.Visible = false;
                }
            }

        }


        protected void dgridEnEsperaDigitales_PreRender(object sender, EventArgs e)
        {
            string strDescripcion = "";
            foreach (DataGridItem myItem in dgridEnEsperaDigitales.Items)
            {
                ((Label)myItem.FindControl("lblFecha")).Text = DateTime.Parse(myItem.Cells[2].Text).ToShortDateString() + " " + DateTime.Parse(myItem.Cells[2].Text).ToShortTimeString();
                if (int.Parse(myItem.Cells[4].Text) == 1)
                    strDescripcion = "<b>Mat.</b> " + myItem.Cells[5].Text;
                if (int.Parse(myItem.Cells[4].Text) == 2)
                    strDescripcion = "<b>Dom.</b> " + myItem.Cells[5].Text + " / <b>F°</b> " + myItem.Cells[6].Text + " / <b>T°</b> " + myItem.Cells[7].Text + " / <b>A°</b> " + myItem.Cells[8].Text;
                if (int.Parse(myItem.Cells[4].Text) == 3)
                    strDescripcion = "<b>LE</b> " + myItem.Cells[5].Text + " / <b>F°</b> " + myItem.Cells[6].Text + " / <b>T°</b> " + myItem.Cells[7].Text + " / <b>A°</b> " + myItem.Cells[8].Text;
                if (int.Parse(myItem.Cells[4].Text) == 4)
                    strDescripcion = "<b>Planilla</b> " + myItem.Cells[5].Text;

                ((Label)myItem.FindControl("lblDescripcion")).Text = strDescripcion;

            }
        }

        protected void dgridEnEsperaSUrgentes_PreRender(object sender, EventArgs e)
        {
            string strDescripcion = "";
            foreach (DataGridItem myItem in dgridEnEsperaSUrgentes.Items)
            {
                ((Label)myItem.FindControl("lblFecha")).Text = DateTime.Parse(myItem.Cells[2].Text).ToShortDateString() + " " + DateTime.Parse(myItem.Cells[2].Text).ToShortTimeString();
                if (int.Parse(myItem.Cells[4].Text) == 1)
                    strDescripcion = "<b>Mat.</b> " + myItem.Cells[5].Text;
                if (int.Parse(myItem.Cells[4].Text) == 2)
                    strDescripcion = "<b>Dom.</b> " + myItem.Cells[5].Text + " / <b>F°</b> " + myItem.Cells[6].Text + " / <b>T°</b> " + myItem.Cells[7].Text + " / <b>A°</b> " + myItem.Cells[8].Text;
                if (int.Parse(myItem.Cells[4].Text) == 3)
                    strDescripcion = "<b>LE</b> " + myItem.Cells[5].Text + " / <b>F°</b> " + myItem.Cells[6].Text + " / <b>T°</b> " + myItem.Cells[7].Text + " / <b>A°</b> " + myItem.Cells[8].Text;
                if (int.Parse(myItem.Cells[4].Text) == 4)
                    strDescripcion = "<b>Planilla</b> " + myItem.Cells[5].Text;

                ((Label)myItem.FindControl("lblDescripcion")).Text = strDescripcion;

            }
        }

        protected void dgridEnProcesoDigitales_PreRender(object sender, EventArgs e)
        {
            string strDescripcion = "";
            foreach (DataGridItem myItem in dgridEnProcesoDigitales.Items)
            {
                ((Label)myItem.FindControl("lblFecha")).Text = DateTime.Parse(myItem.Cells[2].Text).ToShortDateString() + " " + DateTime.Parse(myItem.Cells[2].Text).ToShortTimeString();
                if (int.Parse(myItem.Cells[4].Text) == 1)
                    strDescripcion = "<b>Mat.</b> " + myItem.Cells[5].Text;
                if (int.Parse(myItem.Cells[4].Text) == 2)
                    strDescripcion = "<b>Dom.</b> " + myItem.Cells[5].Text + " / <b>F°</b> " + myItem.Cells[6].Text + " / <b>T°</b> " + myItem.Cells[7].Text + " / <b>A°</b> " + myItem.Cells[8].Text;
                if (int.Parse(myItem.Cells[4].Text) == 3)
                    strDescripcion = "<b>LE</b> " + myItem.Cells[5].Text + " / <b>F°</b> " + myItem.Cells[6].Text + " / <b>T°</b> " + myItem.Cells[7].Text + " / <b>A°</b> " + myItem.Cells[8].Text;
                if (int.Parse(myItem.Cells[4].Text) == 4)
                    strDescripcion = "<b>Planilla</b> " + myItem.Cells[5].Text;

                ((Label)myItem.FindControl("lblDescripcion")).Text = strDescripcion;

                string strScript1 = "cambiarEstado(1, " + myItem.Cells[0].Text + "); return false;";
                ((ImageButton)myItem.FindControl("Problema")).OnClientClick = strScript1;

                //string strScript2 = "cambiarEstado(2, " + myItem.Cells[0].Text + "); return false;";
                //((ImageButton)myItem.FindControl("Transferido")).OnClientClick = strScript2;
                string strScript2 = "if (confirm('¿Desea transferir el informe?')) {TransferirInforme(" + myItem.Cells[0].Text + "); return false;} else return false;";
                ((ImageButton)myItem.FindControl("Transferido")).OnClientClick = strScript2;


                string strScript3 = "cambiarEstado(3, " + myItem.Cells[0].Text + "); return false;";
                ((ImageButton)myItem.FindControl("Condicional")).OnClientClick = strScript3;

            }
        }

        protected void dgridEnProcesoSUrgentes_PreRender(object sender, EventArgs e)
        {
            string strDescripcion = "";
            foreach (DataGridItem myItem in dgridEnProcesoSUrgentes.Items)
            {
                ((Label)myItem.FindControl("lblFecha")).Text = DateTime.Parse(myItem.Cells[2].Text).ToShortDateString() + " " + DateTime.Parse(myItem.Cells[2].Text).ToShortTimeString();
                if (int.Parse(myItem.Cells[4].Text) == 1)
                    strDescripcion = "<b>Mat.</b> " + myItem.Cells[5].Text;
                if (int.Parse(myItem.Cells[4].Text) == 2)
                    strDescripcion = "<b>Dom.</b> " + myItem.Cells[5].Text + " / <b>F°</b> " + myItem.Cells[6].Text + " / <b>T°</b> " + myItem.Cells[7].Text + " / <b>A°</b> " + myItem.Cells[8].Text;
                if (int.Parse(myItem.Cells[4].Text) == 3)
                    strDescripcion = "<b>LE</b> " + myItem.Cells[5].Text + " / <b>F°</b> " + myItem.Cells[6].Text + " / <b>T°</b> " + myItem.Cells[7].Text + " / <b>A°</b> " + myItem.Cells[8].Text;
                if (int.Parse(myItem.Cells[4].Text) == 4)
                    strDescripcion = "<b>Planilla</b> " + myItem.Cells[5].Text;

                ((Label)myItem.FindControl("lblDescripcion")).Text = strDescripcion;

                string strScript1 = "cambiarEstado(1, " + myItem.Cells[0].Text + "); return false;";
                ((ImageButton)myItem.FindControl("Problema")).OnClientClick = strScript1;

                //string strScript2 = "cambiarEstado(2, " + myItem.Cells[0].Text + "); return false;";
                //((ImageButton)myItem.FindControl("Transferido")).OnClientClick = strScript2;
                string strScript2 = "if (confirm('¿Desea transferir el informe?')) {TransferirInforme(" + myItem.Cells[0].Text + "); return false;} else return false;";
                ((ImageButton)myItem.FindControl("Transferido")).OnClientClick = strScript2;


                string strScript3 = "cambiarEstado(3, " + myItem.Cells[0].Text + "); return false;";
                ((ImageButton)myItem.FindControl("Condicional")).OnClientClick = strScript3;

            }
        }

        protected void dgridProblemaDigitales_PreRender(object sender, EventArgs e)
        {
            string strDescripcion = "";
            foreach (DataGridItem myItem in dgridProblemaDigitales.Items)
            {
                ((Label)myItem.FindControl("lblFecha")).Text = DateTime.Parse(myItem.Cells[1].Text).ToShortDateString() + " " + DateTime.Parse(myItem.Cells[1].Text).ToShortTimeString();
                if (int.Parse(myItem.Cells[3].Text) == 1)
                    strDescripcion = "<b>Mat.</b> " + myItem.Cells[4].Text;
                if (int.Parse(myItem.Cells[3].Text) == 2)
                    strDescripcion = "<b>Dom.</b> " + myItem.Cells[4].Text + " / <b>F°</b> " + myItem.Cells[5].Text + " / <b>T°</b> " + myItem.Cells[6].Text + " / <b>A°</b> " + myItem.Cells[7].Text;
                if (int.Parse(myItem.Cells[3].Text) == 3)
                    strDescripcion = "<b>LE</b> " + myItem.Cells[4].Text + " / <b>F°</b> " + myItem.Cells[5].Text + " / <b>T°</b> " + myItem.Cells[6].Text + " / <b>A°</b> " + myItem.Cells[7].Text;
                if (int.Parse(myItem.Cells[3].Text) == 4)
                    strDescripcion = "<b>Planilla</b> " + myItem.Cells[4].Text;

                ((Label)myItem.FindControl("lblDescripcion")).Text = strDescripcion;

                //string strScript2 = "cambiarEstado(2, " + myItem.Cells[0].Text + "); return false;";
                //((ImageButton)myItem.FindControl("Transferido")).OnClientClick = strScript2;
                string strScript2 = "if (confirm('¿Desea transferir el informe?')) {TransferirInforme(" + myItem.Cells[0].Text + "); return false;} else return false;";
                ((ImageButton)myItem.FindControl("Transferido")).OnClientClick = strScript2;

            }
        }

        protected void dgridProblemaSUrgentes_PreRender(object sender, EventArgs e)
        {
            string strDescripcion = "";
            foreach (DataGridItem myItem in dgridProblemaSUrgentes.Items)
            {
                ((Label)myItem.FindControl("lblFecha")).Text = DateTime.Parse(myItem.Cells[1].Text).ToShortDateString() + " " + DateTime.Parse(myItem.Cells[1].Text).ToShortTimeString();
                if (int.Parse(myItem.Cells[3].Text) == 1)
                    strDescripcion = "<b>Mat.</b> " + myItem.Cells[4].Text;
                if (int.Parse(myItem.Cells[3].Text) == 2)
                    strDescripcion = "<b>Dom.</b> " + myItem.Cells[4].Text + " / <b>F°</b> " + myItem.Cells[5].Text + " / <b>T°</b> " + myItem.Cells[6].Text + " / <b>A°</b> " + myItem.Cells[7].Text;
                if (int.Parse(myItem.Cells[3].Text) == 3)
                    strDescripcion = "<b>LE</b> " + myItem.Cells[4].Text + " / <b>F°</b> " + myItem.Cells[5].Text + " / <b>T°</b> " + myItem.Cells[6].Text + " / <b>A°</b> " + myItem.Cells[7].Text;
                if (int.Parse(myItem.Cells[3].Text) == 4)
                    strDescripcion = "<b>Planilla</b> " + myItem.Cells[4].Text;

                ((Label)myItem.FindControl("lblDescripcion")).Text = strDescripcion;

                //string strScript2 = "cambiarEstado(2, " + myItem.Cells[0].Text + "); return false;";
                //((ImageButton)myItem.FindControl("Transferido")).OnClientClick = strScript2;
                string strScript2 = "if (confirm('¿Desea transferir el informe?')) {TransferirInforme(" + myItem.Cells[0].Text + "); return false;} else return false;";
                ((ImageButton)myItem.FindControl("Transferido")).OnClientClick = strScript2;

            }
        }


        protected void dgridTransferidoDigitales_PreRender(object sender, EventArgs e)
        {
            string strDescripcion = "";
            foreach (DataGridItem myItem in dgridTransferidoDigitales.Items)
            {
                ((Label)myItem.FindControl("lblFecha")).Text = DateTime.Parse(myItem.Cells[1].Text).ToShortDateString() + " " + DateTime.Parse(myItem.Cells[1].Text).ToShortTimeString();
                if (int.Parse(myItem.Cells[3].Text) == 1)
                    strDescripcion = "<b>Mat.</b> " + myItem.Cells[4].Text;
                if (int.Parse(myItem.Cells[3].Text) == 2)
                    strDescripcion = "<b>Dom.</b> " + myItem.Cells[4].Text + " / <b>F°</b> " + myItem.Cells[5].Text + " / <b>T°</b> " + myItem.Cells[6].Text + " / <b>A°</b> " + myItem.Cells[7].Text;
                if (int.Parse(myItem.Cells[3].Text) == 3)
                    strDescripcion = "<b>LE</b> " + myItem.Cells[4].Text + " / <b>F°</b> " + myItem.Cells[5].Text + " / <b>T°</b> " + myItem.Cells[6].Text + " / <b>A°</b> " + myItem.Cells[7].Text;
                if (int.Parse(myItem.Cells[3].Text) == 4)
                    strDescripcion = "<b>Planilla</b> " + myItem.Cells[4].Text;

                ((Label)myItem.FindControl("lblDescripcion")).Text = strDescripcion;

                ((ImageButton)myItem.FindControl("Cancelar")).Attributes.Add("onclick", @"javascript: return confirm('¿Desea cancelar el Informe?');");
                //((ImageButton)myItem.FindControl("Agregar")).Attributes.Add("onclick", @"javascript: TransferirInforme(" + myItem.Cells[0].Text + "); return false;");
                string strScript2 = "if (confirm('¿Desea transferir el informe?')) {TransferirInforme(" + myItem.Cells[0].Text + "); return false;} else return false;";
                ((ImageButton)myItem.FindControl("Transferido")).OnClientClick = strScript2;
            }
        }

        protected void dgridTransferidoSUrgentes_PreRender(object sender, EventArgs e)
        {
            string strDescripcion = "";
            foreach (DataGridItem myItem in dgridTransferidoSUrgentes.Items)
            {
                ((Label)myItem.FindControl("lblFecha")).Text = DateTime.Parse(myItem.Cells[1].Text).ToShortDateString() + " " + DateTime.Parse(myItem.Cells[1].Text).ToShortTimeString();
                if (int.Parse(myItem.Cells[3].Text) == 1)
                    strDescripcion = "<b>Mat.</b> " + myItem.Cells[4].Text;
                if (int.Parse(myItem.Cells[3].Text) == 2)
                    strDescripcion = "<b>Dom.</b> " + myItem.Cells[4].Text + " / <b>F°</b> " + myItem.Cells[5].Text + " / <b>T°</b> " + myItem.Cells[6].Text + " / <b>A°</b> " + myItem.Cells[7].Text;
                if (int.Parse(myItem.Cells[3].Text) == 3)
                    strDescripcion = "<b>LE</b> " + myItem.Cells[4].Text + " / <b>F°</b> " + myItem.Cells[5].Text + " / <b>T°</b> " + myItem.Cells[6].Text + " / <b>A°</b> " + myItem.Cells[7].Text;
                if (int.Parse(myItem.Cells[3].Text) == 4)
                    strDescripcion = "<b>Planilla</b> " + myItem.Cells[4].Text;

                ((Label)myItem.FindControl("lblDescripcion")).Text = strDescripcion;
                
                ((ImageButton)myItem.FindControl("Cancelar")).Attributes.Add("onclick", @"javascript: return confirm('¿Desea cancelar el Informe?');");
                //((ImageButton)myItem.FindControl("Agregar")).Attributes.Add("onclick", @"javascript: TransferirInforme(" + myItem.Cells[0].Text + "); return false;");
                string strScript2 = "if (confirm('¿Desea transferir el informe?')) {TransferirInforme(" + myItem.Cells[0].Text + "); return false;} else return false;";
                ((ImageButton)myItem.FindControl("Transferido")).OnClientClick = strScript2;
            }
        }

        protected void dgridCondicionalDigitales_PreRender(object sender, EventArgs e)
        {
            string strDescripcion = "";
            string strDuracion = "";
            string estado = "";

            foreach (DataGridItem myItem in dgridCondicionalDigitales.Items)
            {
                ((Label)myItem.FindControl("lblFecha")).Text = DateTime.Parse(myItem.Cells[1].Text).ToShortDateString() + " " + DateTime.Parse(myItem.Cells[1].Text).ToShortTimeString();
                if (int.Parse(myItem.Cells[3].Text) == 1)
                    strDescripcion = "<b>Mat.</b> " + myItem.Cells[4].Text;
                if (int.Parse(myItem.Cells[3].Text) == 2)
                    strDescripcion = "<b>Dom.</b> " + myItem.Cells[4].Text + " / <b>F°</b> " + myItem.Cells[5].Text + " / <b>T°</b> " + myItem.Cells[6].Text + " / <b>A°</b> " + myItem.Cells[7].Text;
                if (int.Parse(myItem.Cells[3].Text) == 3)
                    strDescripcion = "<b>LE</b> " + myItem.Cells[4].Text + " / <b>F°</b> " + myItem.Cells[5].Text + " / <b>T°</b> " + myItem.Cells[6].Text + " / <b>A°</b> " + myItem.Cells[7].Text;
                if (int.Parse(myItem.Cells[3].Text) == 4)
                    strDescripcion = "<b>Planilla</b> " + myItem.Cells[4].Text;

                ((Label)myItem.FindControl("lblDescripcion")).Text = strDescripcion;

                if (myItem.Cells[13].Text != null && myItem.Cells[13].Text != "" && myItem.Cells[13].Text != "&nbsp;")
                    strDuracion = diferenciaFecha(myItem.Cells[13].Text.ToString());
                ((Label)myItem.FindControl("lblDuracion")).Text = strDuracion;

                estado = myItem.Cells[14].Text.ToString();
                ((DropDownList)myItem.FindControl("ddEstadoCondicional")).SelectedValue = estado;

                ((ImageButton)myItem.FindControl("Cancelar")).Attributes.Add("onclick", @"javascript: return confirm('¿Desea cancelar el Informe?');");
            }
        }

        protected void dgridCondicionalSUrgentes_PreRender(object sender, EventArgs e)
        {
            string strDescripcion = "";
            string strDuracion = "";
            string estado = "";

            foreach (DataGridItem myItem in dgridCondicionalSUrgentes.Items)
            {
                ((Label)myItem.FindControl("lblFecha")).Text = DateTime.Parse(myItem.Cells[1].Text).ToShortDateString() + " " + DateTime.Parse(myItem.Cells[1].Text).ToShortTimeString();
                if (int.Parse(myItem.Cells[3].Text) == 1)
                    strDescripcion = "<b>Mat.</b> " + myItem.Cells[4].Text;
                if (int.Parse(myItem.Cells[3].Text) == 2)
                    strDescripcion = "<b>Dom.</b> " + myItem.Cells[4].Text + " / <b>F°</b> " + myItem.Cells[5].Text + " / <b>T°</b> " + myItem.Cells[6].Text + " / <b>A°</b> " + myItem.Cells[7].Text;
                if (int.Parse(myItem.Cells[3].Text) == 3)
                    strDescripcion = "<b>LE</b> " + myItem.Cells[4].Text + " / <b>F°</b> " + myItem.Cells[5].Text + " / <b>T°</b> " + myItem.Cells[6].Text + " / <b>A°</b> " + myItem.Cells[7].Text;
                if (int.Parse(myItem.Cells[3].Text) == 4)
                    strDescripcion = "<b>Planilla</b> " + myItem.Cells[4].Text;

                ((Label)myItem.FindControl("lblDescripcion")).Text = strDescripcion;

                if (myItem.Cells[13].Text != null && myItem.Cells[13].Text != "" && myItem.Cells[13].Text != "&nbsp;")
                    strDuracion = diferenciaFecha(myItem.Cells[13].Text.ToString());
                ((Label)myItem.FindControl("lblDuracion")).Text = strDuracion;

                estado = myItem.Cells[14].Text.ToString();
                ((DropDownList)myItem.FindControl("ddEstadoCondicional")).SelectedValue = estado;

                ((ImageButton)myItem.FindControl("Cancelar")).Attributes.Add("onclick", @"javascript: return confirm('¿Desea cancelar el Informe?');");
            }
        }

        protected void dgridEnEsperaUrgentes_PreRender(object sender, EventArgs e)
        {
            string strDescripcion = "";
            foreach (DataGridItem myItem in dgridEnEsperaUrgentes.Items)
            {
                ((Label)myItem.FindControl("lblFecha")).Text = DateTime.Parse(myItem.Cells[2].Text).ToShortDateString() + " " + DateTime.Parse(myItem.Cells[2].Text).ToShortTimeString();
                if (int.Parse(myItem.Cells[4].Text) == 1)
                    strDescripcion = "<b>Mat.</b> " + myItem.Cells[5].Text;
                if (int.Parse(myItem.Cells[4].Text) == 2)
                    strDescripcion = "<b>Dom.</b> " + myItem.Cells[5].Text + " / <b>F°</b> " + myItem.Cells[6].Text + " / <b>T°</b> " + myItem.Cells[7].Text + " / <b>A°</b> " + myItem.Cells[8].Text;
                if (int.Parse(myItem.Cells[4].Text) == 3)
                    strDescripcion = "<b>LE</b> " + myItem.Cells[5].Text + " / <b>F°</b> " + myItem.Cells[6].Text + " / <b>T°</b> " + myItem.Cells[7].Text + " / <b>A°</b> " + myItem.Cells[8].Text;
                if (int.Parse(myItem.Cells[4].Text) == 4)
                    strDescripcion = "<b>Planilla</b> " + myItem.Cells[5].Text;

                ((Label)myItem.FindControl("lblDescripcion")).Text = strDescripcion;
            }
        }

        protected void dgridEnProcesoUrgentes_PreRender(object sender, EventArgs e)
        {
            string strDescripcion = "";
            foreach (DataGridItem myItem in dgridEnProcesoUrgentes.Items)
            {
                ((Label)myItem.FindControl("lblFecha")).Text = DateTime.Parse(myItem.Cells[2].Text).ToShortDateString() + " " + DateTime.Parse(myItem.Cells[2].Text).ToShortTimeString();
                if (int.Parse(myItem.Cells[4].Text) == 1)
                    strDescripcion = "<b>Mat.</b> " + myItem.Cells[5].Text;
                if (int.Parse(myItem.Cells[4].Text) == 2)
                    strDescripcion = "<b>Dom.</b> " + myItem.Cells[5].Text + " / <b>F°</b> " + myItem.Cells[6].Text + " / <b>T°</b> " + myItem.Cells[7].Text + " / <b>A°</b> " + myItem.Cells[8].Text;
                if (int.Parse(myItem.Cells[4].Text) == 3)
                    strDescripcion = "<b>LE</b> " + myItem.Cells[5].Text + " / <b>F°</b> " + myItem.Cells[6].Text + " / <b>T°</b> " + myItem.Cells[7].Text + " / <b>A°</b> " + myItem.Cells[8].Text;
                if (int.Parse(myItem.Cells[4].Text) == 4)
                    strDescripcion = "<b>Planilla</b> " + myItem.Cells[5].Text;

                ((Label)myItem.FindControl("lblDescripcion")).Text = strDescripcion;
                
                string strScript1 = "cambiarEstado(1, " + myItem.Cells[0].Text + "); return false;";
                ((ImageButton)myItem.FindControl("Problema")).OnClientClick = strScript1;

                //string strScript2 = "cambiarEstado(2, " + myItem.Cells[0].Text + "); return false;";
                //((ImageButton)myItem.FindControl("Transferido")).OnClientClick = strScript2;
                string strScript2 = "if (confirm('¿Desea transferir el informe?')) {TransferirInforme(" + myItem.Cells[0].Text + "); return false;} else return false;";
                ((ImageButton)myItem.FindControl("Transferido")).OnClientClick = strScript2;


                string strScript3 = "cambiarEstado(3, " + myItem.Cells[0].Text + "); return false;";
                ((ImageButton)myItem.FindControl("Condicional")).OnClientClick = strScript3;
            }
        }

        protected void dgridProblemaUrgentes_PreRender(object sender, EventArgs e)
        {
            string strDescripcion = "";
            foreach (DataGridItem myItem in dgridProblemaUrgentes.Items)
            {
                ((Label)myItem.FindControl("lblFecha")).Text = DateTime.Parse(myItem.Cells[1].Text).ToShortDateString() + " " + DateTime.Parse(myItem.Cells[1].Text).ToShortTimeString();
                if (int.Parse(myItem.Cells[3].Text) == 1)
                    strDescripcion = "<b>Mat.</b> " + myItem.Cells[4].Text;
                if (int.Parse(myItem.Cells[3].Text) == 2)
                    strDescripcion = "<b>Dom.</b> " + myItem.Cells[4].Text + " / <b>F°</b> " + myItem.Cells[5].Text + " / <b>T°</b> " + myItem.Cells[6].Text + " / <b>A°</b> " + myItem.Cells[7].Text;
                if (int.Parse(myItem.Cells[3].Text) == 3)
                    strDescripcion = "<b>LE</b> " + myItem.Cells[4].Text + " / <b>F°</b> " + myItem.Cells[5].Text + " / <b>T°</b> " + myItem.Cells[6].Text + " / <b>A°</b> " + myItem.Cells[7].Text;
                if (int.Parse(myItem.Cells[3].Text) == 4)
                    strDescripcion = "<b>Planilla</b> " + myItem.Cells[4].Text;

                ((Label)myItem.FindControl("lblDescripcion")).Text = strDescripcion;

                //string strScript2 = "cambiarEstado(2, " + myItem.Cells[0].Text + "); return false;";
                //((ImageButton)myItem.FindControl("Transferido")).OnClientClick = strScript2;
                string strScript2 = "if (confirm('¿Desea transferir el informe?')) {TransferirInforme(" + myItem.Cells[0].Text + "); return false;} else return false;";
                ((ImageButton)myItem.FindControl("Transferido")).OnClientClick = strScript2;

            }
        }

        protected void dgridTransferidoUrgentes_PreRender(object sender, EventArgs e)
        {
            string strDescripcion = "";
            foreach (DataGridItem myItem in dgridTransferidoUrgentes.Items)
            {
                ((Label)myItem.FindControl("lblFecha")).Text = DateTime.Parse(myItem.Cells[1].Text).ToShortDateString() + " " + DateTime.Parse(myItem.Cells[1].Text).ToShortTimeString();
                if (int.Parse(myItem.Cells[3].Text) == 1)
                    strDescripcion = "<b>Mat.</b> " + myItem.Cells[4].Text;
                if (int.Parse(myItem.Cells[3].Text) == 2)
                    strDescripcion = "<b>Dom.</b> " + myItem.Cells[4].Text + " / <b>F°</b> " + myItem.Cells[5].Text + " / <b>T°</b> " + myItem.Cells[6].Text + " / <b>A°</b> " + myItem.Cells[7].Text;
                if (int.Parse(myItem.Cells[3].Text) == 3)
                    strDescripcion = "<b>LE</b> " + myItem.Cells[4].Text + " / <b>F°</b> " + myItem.Cells[5].Text + " / <b>T°</b> " + myItem.Cells[6].Text + " / <b>A°</b> " + myItem.Cells[7].Text;
                if (int.Parse(myItem.Cells[3].Text) == 4)
                    strDescripcion = "<b>Planilla</b> " + myItem.Cells[4].Text;

                ((Label)myItem.FindControl("lblDescripcion")).Text = strDescripcion;

                ((ImageButton)myItem.FindControl("Cancelar")).Attributes.Add("onclick", @"javascript: return confirm('¿Desea cancelar el Informe?');");

                string strScript2 = "if (confirm('¿Desea transferir el informe?')) {TransferirInforme(" + myItem.Cells[0].Text + "); return false;} else return false;";
                ((ImageButton)myItem.FindControl("Transferido")).OnClientClick = strScript2;

                //((ImageButton)myItem.FindControl("Agregar")).Attributes.Add("onclick", @"javascript: TransferirInforme(" + myItem.Cells[0].Text + "); return false;");
                //string strScript2 = "cambiarEstado(2, " + myItem.Cells[0].Text + "); return false;";
                //((ImageButton)myItem.FindControl("Transferido")).OnClientClick = strScript2;
            }
        }

        protected void dgridCondicionalUrgentes_PreRender(object sender, EventArgs e)
        {
            string strDescripcion = "";
            string strDuracion = "";
            string estado = "";

            foreach (DataGridItem myItem in dgridCondicionalUrgentes.Items)
            {
                ((Label)myItem.FindControl("lblFecha")).Text = DateTime.Parse(myItem.Cells[1].Text).ToShortDateString() + " " + DateTime.Parse(myItem.Cells[1].Text).ToShortTimeString();
                if (int.Parse(myItem.Cells[3].Text) == 1)
                    strDescripcion = "<b>Mat.</b> " + myItem.Cells[4].Text;
                if (int.Parse(myItem.Cells[3].Text) == 2)
                    strDescripcion = "<b>Dom.</b> " + myItem.Cells[4].Text + " / <b>F°</b> " + myItem.Cells[5].Text + " / <b>T°</b> " + myItem.Cells[6].Text + " / <b>A°</b> " + myItem.Cells[7].Text;
                if (int.Parse(myItem.Cells[3].Text) == 3)
                    strDescripcion = "<b>LE</b> " + myItem.Cells[4].Text + " / <b>F°</b> " + myItem.Cells[5].Text + " / <b>T°</b> " + myItem.Cells[6].Text + " / <b>A°</b> " + myItem.Cells[7].Text;
                if (int.Parse(myItem.Cells[3].Text) == 4)
                    strDescripcion = "<b>Planilla</b> " + myItem.Cells[4].Text;

                ((Label)myItem.FindControl("lblDescripcion")).Text = strDescripcion;

                if (myItem.Cells[13].Text != null && myItem.Cells[13].Text != "" && myItem.Cells[13].Text != "&nbsp;")
                    strDuracion = diferenciaFecha(myItem.Cells[13].Text.ToString());
                ((Label)myItem.FindControl("lblDuracion")).Text = strDuracion;

                estado = myItem.Cells[14].Text.ToString();
                ((DropDownList)myItem.FindControl("ddEstadoCondicional")).SelectedValue = estado;

                ((ImageButton)myItem.FindControl("Cancelar")).Attributes.Add("onclick", @"javascript: return confirm('¿Desea cancelar el Informe?');");
            }
        }

        protected void dgridEnEsperaNormales_PreRender(object sender, EventArgs e)
        {
            string strDescripcion = "";
            foreach (DataGridItem myItem in dgridEnEsperaNormales.Items)
            {
                ((Label)myItem.FindControl("lblFecha")).Text = DateTime.Parse(myItem.Cells[2].Text).ToShortDateString() + " " + DateTime.Parse(myItem.Cells[2].Text).ToShortTimeString();
                if (int.Parse(myItem.Cells[4].Text) == 1)
                    strDescripcion = "<b>Mat.</b> " + myItem.Cells[5].Text;
                if (int.Parse(myItem.Cells[4].Text) == 2)
                    strDescripcion = "<b>Dom.</b> " + myItem.Cells[5].Text + " / <b>F°</b> " + myItem.Cells[6].Text + " / <b>T°</b> " + myItem.Cells[7].Text + " / <b>A°</b> " + myItem.Cells[8].Text;
                if (int.Parse(myItem.Cells[4].Text) == 3)
                    strDescripcion = "<b>LE</b> " + myItem.Cells[5].Text + " / <b>F°</b> " + myItem.Cells[6].Text + " / <b>T°</b> " + myItem.Cells[7].Text + " / <b>A°</b> " + myItem.Cells[8].Text;
                if (int.Parse(myItem.Cells[4].Text) == 4)
                    strDescripcion = "<b>Planilla</b> " + myItem.Cells[5].Text;
                ((Label)myItem.FindControl("lblDescripcion")).Text = strDescripcion;
            }
        }


        protected void dgridEnProcesoNormales_PreRender(object sender, EventArgs e)
        {
            string strDescripcion = "";
            foreach (DataGridItem myItem in dgridEnProcesoNormales.Items)
            {
                ((Label)myItem.FindControl("lblFecha")).Text = DateTime.Parse(myItem.Cells[2].Text).ToShortDateString() + " " + DateTime.Parse(myItem.Cells[2].Text).ToShortTimeString();
                if (int.Parse(myItem.Cells[4].Text) == 1)
                    strDescripcion = "<b>Mat.</b> " + myItem.Cells[5].Text;
                if (int.Parse(myItem.Cells[4].Text) == 2)
                    strDescripcion = "<b>Dom.</b> " + myItem.Cells[5].Text + " / <b>F°</b> " + myItem.Cells[6].Text + " / <b>T°</b> " + myItem.Cells[7].Text + " / <b>A°</b> " + myItem.Cells[8].Text;
                if (int.Parse(myItem.Cells[4].Text) == 3)
                    strDescripcion = "<b>LE</b> " + myItem.Cells[5].Text + " / <b>F°</b> " + myItem.Cells[6].Text + " / <b>T°</b> " + myItem.Cells[7].Text + " / <b>A°</b> " + myItem.Cells[8].Text;
                if (int.Parse(myItem.Cells[4].Text) == 4)
                    strDescripcion = "<b>Planilla</b> " + myItem.Cells[5].Text;

                ((Label)myItem.FindControl("lblDescripcion")).Text = strDescripcion;

                string strScript1 = "cambiarEstado(1, " + myItem.Cells[0].Text + "); return false;";
                ((ImageButton)myItem.FindControl("Problema")).OnClientClick = strScript1;

                //string strScript2 = "cambiarEstado(2, " + myItem.Cells[0].Text + "); return false;";
                //((ImageButton)myItem.FindControl("Transferido")).OnClientClick = strScript2;
                string strScript2 = "if (confirm('¿Desea transferir el informe?')) {TransferirInforme(" + myItem.Cells[0].Text + "); return false;} else return false;";
                ((ImageButton)myItem.FindControl("Transferido")).OnClientClick = strScript2;


                string strScript3 = "cambiarEstado(3, " + myItem.Cells[0].Text + "); return false;";
                ((ImageButton)myItem.FindControl("Condicional")).OnClientClick = strScript3;
            }
        }

        protected void dgridProblemaNormales_PreRender(object sender, EventArgs e)
        {
            string strDescripcion = "";
            foreach (DataGridItem myItem in dgridProblemaNormales.Items)
            {
                ((Label)myItem.FindControl("lblFecha")).Text = DateTime.Parse(myItem.Cells[1].Text).ToShortDateString() + " " + DateTime.Parse(myItem.Cells[1].Text).ToShortTimeString();
                if (int.Parse(myItem.Cells[3].Text) == 1)
                    strDescripcion = "<b>Mat.</b> " + myItem.Cells[4].Text;
                if (int.Parse(myItem.Cells[3].Text) == 2)
                    strDescripcion = "<b>Dom.</b> " + myItem.Cells[4].Text + " / <b>F°</b> " + myItem.Cells[5].Text + " / <b>T°</b> " + myItem.Cells[6].Text + " / <b>A°</b> " + myItem.Cells[7].Text;
                if (int.Parse(myItem.Cells[3].Text) == 3)
                    strDescripcion = "<b>LE</b> " + myItem.Cells[4].Text + " / <b>F°</b> " + myItem.Cells[5].Text + " / <b>T°</b> " + myItem.Cells[6].Text + " / <b>A°</b> " + myItem.Cells[7].Text;
                if (int.Parse(myItem.Cells[3].Text) == 4)
                    strDescripcion = "<b>Planilla</b> " + myItem.Cells[4].Text;

                ((Label)myItem.FindControl("lblDescripcion")).Text = strDescripcion;

                //string strScript2 = "cambiarEstado(2, " + myItem.Cells[0].Text + "); return false;";
                //((ImageButton)myItem.FindControl("Transferido")).OnClientClick = strScript2;
                string strScript2 = "if (confirm('¿Desea transferir el informe?')) {TransferirInforme(" + myItem.Cells[0].Text + "); return false;} else return false;";
                ((ImageButton)myItem.FindControl("Transferido")).OnClientClick = strScript2;

            }
        }


        protected void dgridTransferidoNormales_PreRender(object sender, EventArgs e)
        {
            string strDescripcion = "";
            foreach (DataGridItem myItem in dgridTransferidoNormales.Items)
            {
                ((Label)myItem.FindControl("lblFecha")).Text = DateTime.Parse(myItem.Cells[1].Text).ToShortDateString() + " " + DateTime.Parse(myItem.Cells[1].Text).ToShortTimeString();
                if (int.Parse(myItem.Cells[3].Text) == 1)
                    strDescripcion = "<b>Mat.</b> " + myItem.Cells[4].Text;
                if (int.Parse(myItem.Cells[3].Text) == 2)
                    strDescripcion = "<b>Dom.</b> " + myItem.Cells[4].Text + " / <b>F°</b> " + myItem.Cells[5].Text + " / <b>T°</b> " + myItem.Cells[6].Text + " / <b>A°</b> " + myItem.Cells[7].Text;
                if (int.Parse(myItem.Cells[3].Text) == 3)
                    strDescripcion = "<b>LE</b> " + myItem.Cells[4].Text + " / <b>F°</b> " + myItem.Cells[5].Text + " / <b>T°</b> " + myItem.Cells[6].Text + " / <b>A°</b> " + myItem.Cells[7].Text;
                if (int.Parse(myItem.Cells[3].Text) == 4)
                    strDescripcion = "<b>Planilla</b> " + myItem.Cells[4].Text;

                ((Label)myItem.FindControl("lblDescripcion")).Text = strDescripcion;

                ((ImageButton)myItem.FindControl("Cancelar")).Attributes.Add("onclick", @"javascript: return confirm('¿Desea cancelar el Informe?');");

                string strScript2 = "if (confirm('¿Desea transferir el informe?')) {TransferirInforme(" + myItem.Cells[0].Text + "); return false;} else return false;";
                ((ImageButton)myItem.FindControl("Transferido")).OnClientClick = strScript2;

                //((ImageButton)myItem.FindControl("Agregar")).Attributes.Add("onclick", @"javascript: TransferirInforme(" + myItem.Cells[0].Text + "); return false;");
                //string strScript2 = "cambiarEstado(2, " + myItem.Cells[0].Text + "); return false;";
                //((ImageButton)myItem.FindControl("Transferido")).OnClientClick = strScript2;
            }
        }


        protected void dgridCondicionalNormales_PreRender(object sender, EventArgs e)
        {
            string strDescripcion = "";
            string strDuracion = "";
            string estado = "";

            foreach (DataGridItem myItem in dgridCondicionalNormales.Items)
            {
                ((Label)myItem.FindControl("lblFecha")).Text = DateTime.Parse(myItem.Cells[1].Text).ToShortDateString() + " " + DateTime.Parse(myItem.Cells[1].Text).ToShortTimeString();
                if (int.Parse(myItem.Cells[3].Text) == 1)
                    strDescripcion = "<b>Mat.</b> " + myItem.Cells[4].Text;
                if (int.Parse(myItem.Cells[3].Text) == 2)
                    strDescripcion = "<b>Dom.</b> " + myItem.Cells[4].Text + " / <b>F°</b> " + myItem.Cells[5].Text + " / <b>T°</b> " + myItem.Cells[6].Text + " / <b>A°</b> " + myItem.Cells[7].Text;
                if (int.Parse(myItem.Cells[3].Text) == 3)
                    strDescripcion = "<b>LE</b> " + myItem.Cells[4].Text + " / <b>F°</b> " + myItem.Cells[5].Text + " / <b>T°</b> " + myItem.Cells[6].Text + " / <b>A°</b> " + myItem.Cells[7].Text;
                if (int.Parse(myItem.Cells[3].Text) == 4)
                    strDescripcion = "<b>Planilla</b> " + myItem.Cells[4].Text;

                ((Label)myItem.FindControl("lblDescripcion")).Text = strDescripcion;

                if (myItem.Cells[13].Text != null && myItem.Cells[13].Text != "" && myItem.Cells[13].Text != "&nbsp;")
                    strDuracion = diferenciaFecha(myItem.Cells[13].Text.ToString());
                ((Label)myItem.FindControl("lblDuracion")).Text = strDuracion;

                estado = myItem.Cells[14].Text.ToString();
                ((DropDownList)myItem.FindControl("ddEstadoCondicional")).SelectedValue = estado;

                ((ImageButton)myItem.FindControl("Cancelar")).Attributes.Add("onclick", @"javascript: return confirm('¿Desea cancelar el Informe?');");
            }
        }


        protected void dgridTransferidoDetalles_PreRender(object sender, EventArgs e)
        {
            foreach (DataGridItem myItem in dgridTransferidoDetalles.Items)
            {
                ((Label)myItem.FindControl("lblFecha")).Text = DateTime.Parse(myItem.Cells[1].Text).ToShortDateString() + " " + DateTime.Parse(myItem.Cells[1].Text).ToShortTimeString();
                //myItem.Cells[7].Text = "<IMG SRC='/img/Estado" + myItem.Cells[12].Text + ".gif' widht='14' height='14' border='0' title='" + myItem.Cells[17].Text + strFechaCondicional + "'>&nbsp;&nbsp;&nbsp;" + myItem.Cells[6].Text;
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
            CheckBox chkSelDigital;
            CheckBox chkSelSUrgente;
            CheckBox chkSelUrgente;
            CheckBox chkSelNormal;
            int intIdInforme;
            int intGrupo = 0;
            EncabezadoApp Encabezado = new EncabezadoApp();
            UsuarioAutenticado Usuario = (UsuarioAutenticado)Session["UsuarioAutenticado"];

            if (dgridEnEsperaDigitales.Items.Count > 0 || dgridEnEsperaSUrgentes.Items.Count > 0 || dgridEnEsperaUrgentes.Items.Count > 0 || dgridEnEsperaNormales.Items.Count > 0)
                intGrupo = Encabezado.crearGrupoCambioEstado(Usuario.IdUsuario, 1);

            foreach (DataGridItem dgDigi in dgridEnEsperaDigitales.Items)
            {

                chkSelDigital = (CheckBox)dgDigi.FindControl("chkDigital");
                if (chkSelDigital.Checked)
                {
                    intIdInforme = int.Parse(dgDigi.Cells[0].Text);
                    Encabezado.cargarEncabezado(intIdInforme);
                    if (Encabezado.Estado == 5)
                    {
                        Encabezado.Comentarios = "** MODIFICADO ** " + Encabezado.Comentarios;
                        Encabezado.Modificar(intIdInforme);
                    }
                    Encabezado.Estado = 2;
                    Encabezado.IdUsuario = Usuario.IdUsuario;
                    Encabezado.CambiarEstado(intIdInforme);
                    Encabezado.Leido = 1;
                    Encabezado.CambiarLeido(intIdInforme);
                    Encabezado.crearCambiosEstadoInformes(intGrupo, intIdInforme, 2);
                }
            }

            foreach (DataGridItem dgSUrg in dgridEnEsperaSUrgentes.Items)
			{
				chkSelSUrgente = (CheckBox)dgSUrg.FindControl("chkSUrgente");
				if(chkSelSUrgente.Checked)
				{
                    intIdInforme = int.Parse(dgSUrg.Cells[0].Text);
                    Encabezado.cargarEncabezado(intIdInforme);
                    if (Encabezado.Estado == 5)
                    {
                        Encabezado.Comentarios = "** MODIFICADO ** " + Encabezado.Comentarios;
                        Encabezado.Modificar(intIdInforme);
                    }
                    Encabezado.Estado = 2;
                    Encabezado.IdUsuario = Usuario.IdUsuario;
                    Encabezado.CambiarEstado(intIdInforme);
                    Encabezado.Leido = 1;
                    Encabezado.CambiarLeido(intIdInforme);
                    Encabezado.crearCambiosEstadoInformes(intGrupo, intIdInforme, 2);
				}
			}


            foreach (DataGridItem dgUrg in dgridEnEsperaUrgentes.Items)
            {
                chkSelUrgente = (CheckBox)dgUrg.FindControl("chkUrgente");
                if (chkSelUrgente.Checked)
                {
                    intIdInforme = int.Parse(dgUrg.Cells[0].Text);
                    Encabezado.cargarEncabezado(intIdInforme);
                    if (Encabezado.Estado == 5)
                    {
                        Encabezado.Comentarios = "** MODIFICADO ** " + Encabezado.Comentarios;
                        Encabezado.Modificar(intIdInforme);
                    }
                    Encabezado.Estado = 2;
                    Encabezado.IdUsuario = Usuario.IdUsuario;
                    Encabezado.CambiarEstado(intIdInforme);
                    Encabezado.Leido = 1;
                    Encabezado.CambiarLeido(intIdInforme);
                    Encabezado.crearCambiosEstadoInformes(intGrupo, intIdInforme, 2);
                }
            }


            foreach (DataGridItem dgNorm in dgridEnEsperaNormales.Items)
            {
                chkSelNormal = (CheckBox)dgNorm.FindControl("chkNormal");
                if (chkSelNormal.Checked)
                {
                    intIdInforme = int.Parse(dgNorm.Cells[0].Text);
                    Encabezado.cargarEncabezado(intIdInforme);
                    if (Encabezado.Estado == 5)
                    {
                        Encabezado.Comentarios = "** MODIFICADO ** " + Encabezado.Comentarios;
                        Encabezado.Modificar(intIdInforme);
                    }
                    Encabezado.Estado = 2;
                    Encabezado.IdUsuario = Usuario.IdUsuario;
                    Encabezado.CambiarEstado(intIdInforme);
                    Encabezado.Leido = 1;
                    Encabezado.CambiarLeido(intIdInforme);
                    Encabezado.crearCambiosEstadoInformes(intGrupo, intIdInforme, 2);
                }
            }
            Response.Redirect("impresionenproceso.aspx?idGrupo=" + intGrupo);
       }


        protected void btnAceptar2_Click(object sender, EventArgs e)
        {
            CheckBox chkSelDigital;
            CheckBox chkSelSUrgente;
            CheckBox chkSelUrgente;
            CheckBox chkSelNormal;
            int intIdInforme;
            EncabezadoApp Encabezado = new EncabezadoApp();


            foreach (DataGridItem dgDigi in dgridEnProcesoDigitales.Items)
            {
                chkSelDigital = (CheckBox)dgDigi.FindControl("chkDigital");
                if (chkSelDigital.Checked)
                {
                    intIdInforme = int.Parse(dgDigi.Cells[0].Text);
                    Encabezado.cargarEncabezado(intIdInforme);
                    Encabezado.Estado = 6;
                    Encabezado.CambiarEstado(intIdInforme);
                }
            }


            foreach (DataGridItem dgUrg in dgridEnProcesoUrgentes.Items)
            {
                chkSelUrgente = (CheckBox)dgUrg.FindControl("chkUrgente");
                if (chkSelUrgente.Checked)
                {
                    intIdInforme = int.Parse(dgUrg.Cells[0].Text);
                    Encabezado.cargarEncabezado(intIdInforme);
                    Encabezado.Estado = 6;
                    Encabezado.CambiarEstado(intIdInforme);
                }
            }


            foreach (DataGridItem dgNorm in dgridEnProcesoNormales.Items)
            {
                chkSelNormal = (CheckBox)dgNorm.FindControl("chkNormal");
                if (chkSelNormal.Checked)
                {
                    intIdInforme = int.Parse(dgNorm.Cells[0].Text);
                    Encabezado.cargarEncabezado(intIdInforme);
                    Encabezado.Estado = 6;
                    Encabezado.CambiarEstado(intIdInforme);
                }
            }

            Response.Redirect("../BandejaEntrada/Principal.aspx?idTipo=1");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("../BandejaEntrada/Principal.aspx?idTipo=1");
        }



        protected void btnVolverTransferidos_Click(object sender, EventArgs e)
        {
            Response.Write("<script>menu = " + menuTab.SelectedItem.Value + ";</script>");
            ListaBandeja(3);
        }

        protected void menuTab_MenuItemClick(object sender, MenuEventArgs e)
        {
            contenedor.ActiveViewIndex = Int32.Parse(e.Item.Value);
            e.Item.Selected = true;
            if (menuTab.SelectedItem != null)
                Response.Write("<script>menu = " + menuTab.SelectedItem.Value + ";</script>");

            ListaBandeja(Int32.Parse(e.Item.Value));
        }

        protected void dgridProblemaDigitales_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.Item.Cells[0].Text != "")
            {
                switch (((ImageButton)e.CommandSource).CommandName)
                {
                    case "Editar":
                        Response.Redirect("../BandejaEntrada/abmInforme.aspx?id=" + e.Item.Cells[0].Text + "&IdTipo=1");
                        break;

                }
            }
        }

        protected void dgridProblemaSUrgentes_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.Item.Cells[0].Text != "")
            {
                switch (((ImageButton)e.CommandSource).CommandName)
                {
                    case "Editar":
                        Response.Redirect("../BandejaEntrada/abmInforme.aspx?id=" + e.Item.Cells[0].Text + "&IdTipo=1");
                        break;

                }
            }
        }

        protected void dgridTransferidoDigitales_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.Item.Cells[0].Text != "")
            {
                switch (((ImageButton)e.CommandSource).CommandName)
                {
                    case "Cancelar":
                        CancelarEncabezado(int.Parse(e.Item.Cells[0].Text));
                        Response.Redirect("/BandejaEntrada/Principal.aspx?IdTipo=1");
                        break;
                    /*
                case "Agregar":
                    Response.Redirect("/BandejaEntrada/altaInforme.aspx?idTransferido=" + int.Parse(e.Item.Cells[0].Text));
                    break;
                     */
                    case "Detalle":
                        ListarDetallesTransferidos(int.Parse(e.Item.Cells[0].Text));
                        break;
                }
            }
        }

        protected void dgridTransferidoSUrgentes_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.Item.Cells[0].Text != "")
            {
                switch (((ImageButton)e.CommandSource).CommandName)
                {
                    case "Cancelar":
                        CancelarEncabezado(int.Parse(e.Item.Cells[0].Text));
                        Response.Redirect("/BandejaEntrada/Principal.aspx?IdTipo=1");
                        break;
                        /*
                    case "Agregar":
                        Response.Redirect("/BandejaEntrada/altaInforme.aspx?idTransferido=" + int.Parse(e.Item.Cells[0].Text));
                        break;
                         */
                    case "Detalle":
                        ListarDetallesTransferidos(int.Parse(e.Item.Cells[0].Text));
                        break;
                }
            }
        }


        protected void dgridCondicionalDigitales_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.Item.Cells[0].Text != "")
            {
                switch (((ImageButton)e.CommandSource).CommandName)
                {
                    case "Editar":
                        Response.Redirect("../BandejaEntrada/abmInforme.aspx?id=" + e.Item.Cells[0].Text + "&IdTipo=1");
                        break;

                    case "Cancelar":
                        CancelarEncabezado(int.Parse(e.Item.Cells[0].Text));
                        Response.Redirect("/BandejaEntrada/Principal.aspx?IdTipo=1");
                        break;
                }
            }
        }

        protected void dgridCondicionalSUrgentes_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.Item.Cells[0].Text != "")
            {
                switch (((ImageButton)e.CommandSource).CommandName)
                {
                    case "Editar":
                        Response.Redirect("../BandejaEntrada/abmInforme.aspx?id=" + e.Item.Cells[0].Text + "&IdTipo=1");
                        break;
                        
                    case "Cancelar":
                        CancelarEncabezado(int.Parse(e.Item.Cells[0].Text));
                        Response.Redirect("/BandejaEntrada/Principal.aspx?IdTipo=1");
                        break;
                }
            }
        }

        protected void dgridProblemaUrgentes_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.Item.Cells[0].Text != "")
            {
                switch (((ImageButton)e.CommandSource).CommandName)
                {
                    case "Editar":
                        Response.Redirect("../BandejaEntrada/abmInforme.aspx?id=" + e.Item.Cells[0].Text + "&IdTipo=1");
                        break;
                }
            }
        }

        protected void dgridTransferidoUrgentes_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.Item.Cells[0].Text != "")
            {
                switch (((ImageButton)e.CommandSource).CommandName)
                {
                    case "Cancelar":
                        CancelarEncabezado(int.Parse(e.Item.Cells[0].Text));
                        Response.Redirect("/BandejaEntrada/Principal.aspx?IdTipo=1");
                        break;
                        /*
                    case "Agregar":
                        Response.Redirect("/BandejaEntrada/altaInforme.aspx?idTransferido=" + int.Parse(e.Item.Cells[0].Text));
                        break;
                        */
                    case "Detalle":
                        ListarDetallesTransferidos(int.Parse(e.Item.Cells[0].Text));
                        break;
                }
            }
        }

        protected void dgridCondicionalUrgentes_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.Item.Cells[0].Text != "")
            {
                switch (((ImageButton)e.CommandSource).CommandName)
                {
                    case "Editar":
                        Response.Redirect("../BandejaEntrada/abmInforme.aspx?id=" + e.Item.Cells[0].Text + "&IdTipo=1");
                        break;
                    case "Cancelar":
                        CancelarEncabezado(int.Parse(e.Item.Cells[0].Text));
                        Response.Redirect("/BandejaEntrada/Principal.aspx?IdTipo=1");
                        break;
                }
            }
        }

        protected void dgridProblemaNormales_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.Item.Cells[0].Text != "")
            {
                switch (((ImageButton)e.CommandSource).CommandName)
                {
                    case "Editar":
                        Response.Redirect("../BandejaEntrada/abmInforme.aspx?id=" + e.Item.Cells[0].Text + "&IdTipo=1");
                        break;
                }
            }
        }

        protected void dgridTransferidoNormales_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.Item.Cells[0].Text != "")
            {
                switch (((ImageButton)e.CommandSource).CommandName)
                {
                    case "Cancelar":
                        CancelarEncabezado(int.Parse(e.Item.Cells[0].Text));
                        Response.Redirect("/BandejaEntrada/Principal.aspx?IdTipo=1");
                        break;
                        /*

                    case "Agregar":
                        Response.Redirect("/BandejaEntrada/altaInforme.aspx?idTransferido=" + int.Parse(e.Item.Cells[0].Text));
                        break;
                        */
                    case "Detalle":
                        ListarDetallesTransferidos(int.Parse(e.Item.Cells[0].Text));
                        break;
                }
            }
        }

        protected void dgridCondicionalNormales_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.Item.Cells[0].Text != "")
            {
                switch (((ImageButton)e.CommandSource).CommandName)
                {
                    case "Editar":
                        Response.Redirect("../BandejaEntrada/abmInforme.aspx?id=" + e.Item.Cells[0].Text + "&IdTipo=1");
                        break;
                    case "Cancelar":
                        CancelarEncabezado(int.Parse(e.Item.Cells[0].Text));
                        Response.Redirect("/BandejaEntrada/Principal.aspx?IdTipo=1");
                        break;
                }
            }
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
                pnEnEsperaDigitales.Visible = true;
                pnEnEsperaSUrgentes.Visible = true;
                pnEnEsperaUrgentes.Visible = true;
                pnEnEsperaNormales.Visible = true;

                Response.Write("<script>var menu = 0;</script>");    
                BandejaEntradaApp bandeja = new BandejaEntradaApp();
                //if (chkSoloMias.Checked) idUser = IdUsuario;
                dgridEnEsperaDigitales.DataSource = bandeja.ListaEncabezados(IdTipo, pFiltro, idCliente, idUser, Estados, 4, "", "", 100, false);
                dgridEnEsperaDigitales.DataBind();
                if (dgridEnEsperaDigitales.Items.Count == 0)
                    pnEnEsperaDigitales.Visible = false;

                dgridEnEsperaSUrgentes.DataSource = bandeja.ListaEncabezados(IdTipo, pFiltro, idCliente, idUser, Estados, 3, "", "", 100, false);
                dgridEnEsperaSUrgentes.DataBind();
                if (dgridEnEsperaSUrgentes.Items.Count == 0)
                    pnEnEsperaSUrgentes.Visible = false;

                dgridEnEsperaUrgentes.DataSource = bandeja.ListaEncabezados(IdTipo, pFiltro, idCliente, idUser, Estados, 2, "", "", 100, false);
                dgridEnEsperaUrgentes.DataBind();

                if (dgridEnEsperaUrgentes.Items.Count == 0)
                    pnEnEsperaUrgentes.Visible = false;

                dgridEnEsperaNormales.DataSource = bandeja.ListaEncabezados(IdTipo, pFiltro, idCliente, idUser, Estados, 1, "", "", 100, false);
                dgridEnEsperaNormales.DataBind();

                if (dgridEnEsperaNormales.Items.Count == 0)
                    pnEnEsperaNormales.Visible = false;


                if ((dgridEnEsperaDigitales.Items.Count == 0) && (dgridEnEsperaSUrgentes.Items.Count == 0) && (dgridEnEsperaUrgentes.Items.Count == 0) && (dgridEnEsperaNormales.Items.Count == 0))
                {
                    lblMensaje.Text = "No hay Informes de Propiedad para generar el formulario taza para la búsqueda <b> " + pFiltro + "</b>.";
                    lblMensaje.Visible = true;
                    //btnImprimir.Visible = false;
                }
            }

            if (idTab == 1)
            {
                pnEnProcesoDigitales.Visible = true;
                pnEnProcesoSUrgentes.Visible = true;
                pnEnProcesoUrgentes.Visible = true;
                pnEnProcesoNormales.Visible = true;

                Estados = "2";
                Response.Write("<script>var menu = 1;</script>");    
                BandejaEntradaApp bandeja = new BandejaEntradaApp();
                //if (chkSoloMias.Checked) idUser = IdUsuario;
                dgridEnProcesoDigitales.DataSource = bandeja.ListaEncabezados(IdTipo, pFiltro, idCliente, idUser, Estados, 4, "", "", 100, false);
                dgridEnProcesoDigitales.DataBind();
                if (dgridEnProcesoDigitales.Items.Count == 0)
                    pnEnProcesoDigitales.Visible = false;

                dgridEnProcesoSUrgentes.DataSource = bandeja.ListaEncabezados(IdTipo, pFiltro, idCliente, idUser, Estados, 3, "", "", 100, false);
                dgridEnProcesoSUrgentes.DataBind();
                if (dgridEnProcesoSUrgentes.Items.Count == 0)
                    pnEnProcesoSUrgentes.Visible = false;

                dgridEnProcesoUrgentes.DataSource = bandeja.ListaEncabezados(IdTipo, pFiltro, idCliente, idUser, Estados, 2, "", "", 100, false);
                dgridEnProcesoUrgentes.DataBind();

                if (dgridEnProcesoUrgentes.Items.Count == 0)
                    pnEnProcesoUrgentes.Visible = false;

                dgridEnProcesoNormales.DataSource = bandeja.ListaEncabezados(IdTipo, pFiltro, idCliente, idUser, Estados, 1, "", "", 100, false);
                dgridEnProcesoNormales.DataBind();

                if (dgridEnProcesoNormales.Items.Count == 0)
                    pnEnProcesoNormales.Visible = false;


                if ((dgridEnProcesoDigitales.Items.Count == 0) && (dgridEnProcesoSUrgentes.Items.Count == 0) && (dgridEnProcesoUrgentes.Items.Count == 0) && (dgridEnProcesoNormales.Items.Count == 0))
                {
                    lblMensaje.Text = "No hay Informes de Propiedad para enviar al registro para la búsqueda <b> " + pFiltro + "</b>.";
                    lblMensaje.Visible = true;
                    //btnImprimir.Visible = false;
                }
            }


            if (idTab == 2)
            {
                pnProblemaDigitales.Visible = true;
                pnProblemaSUrgentes.Visible = true;
                pnProblemaUrgentes.Visible = true;
                pnProblemaNormales.Visible = true;

                Estados = "9";
                Response.Write("<script>var menu = 2;</script>");    
                BandejaEntradaApp bandeja = new BandejaEntradaApp();
                //if (chkSoloMias.Checked) idUser = IdUsuario;
                dgridProblemaDigitales.DataSource = bandeja.ListaEncabezados(IdTipo, pFiltro, idCliente, idUser, Estados, 4, "", "", 100, false);
                dgridProblemaDigitales.DataBind();
                if (dgridProblemaDigitales.Items.Count == 0)
                    pnProblemaDigitales.Visible = false;

                dgridProblemaSUrgentes.DataSource = bandeja.ListaEncabezados(IdTipo, pFiltro, idCliente, idUser, Estados, 3, "", "", 100, false);
                dgridProblemaSUrgentes.DataBind();
                if (dgridProblemaSUrgentes.Items.Count == 0)
                    pnProblemaSUrgentes.Visible = false;

                dgridProblemaUrgentes.DataSource = bandeja.ListaEncabezados(IdTipo, pFiltro, idCliente, idUser, Estados, 2, "", "", 100, false);
                dgridProblemaUrgentes.DataBind();

                if (dgridProblemaUrgentes.Items.Count == 0)
                    pnProblemaUrgentes.Visible = false;

                dgridProblemaNormales.DataSource = bandeja.ListaEncabezados(IdTipo, pFiltro, idCliente, idUser, Estados, 1, "", "", 100, false);
                dgridProblemaNormales.DataBind();

                if (dgridProblemaNormales.Items.Count == 0)
                    pnProblemaNormales.Visible = false;


                if ((dgridProblemaDigitales.Items.Count == 0) && (dgridProblemaSUrgentes.Items.Count == 0) && (dgridProblemaUrgentes.Items.Count == 0) && (dgridProblemaNormales.Items.Count == 0))
                {
                    lblMensaje.Text = "No hay Informes de Propiedad con problemas para la búsqueda <b> " + pFiltro + "</b>.";
                    lblMensaje.Visible = true;
                    //btnImprimir.Visible = false;
                }
            }


            if (idTab == 3)
            {
                pnTransferidoDigitales.Visible = true;
                pnTransferidoSUrgentes.Visible = true;
                pnTransferidoUrgentes.Visible = true;
                pnTransferidoNormales.Visible = true;

                Estados = "10";
                Response.Write("<script>var menu = 3;</script>");    
                BandejaEntradaApp bandeja = new BandejaEntradaApp();
                //if (chkSoloMias.Checked) idUser = IdUsuario;
                dgridTransferidoDigitales.DataSource = bandeja.ListaEncabezados(IdTipo, pFiltro, idCliente, idUser, Estados, 4, "", "", 100, false);
                dgridTransferidoDigitales.DataBind();
                if (dgridTransferidoDigitales.Items.Count == 0)
                    pnTransferidoDigitales.Visible = false;

                dgridTransferidoSUrgentes.DataSource = bandeja.ListaEncabezados(IdTipo, pFiltro, idCliente, idUser, Estados, 3, "", "", 100, false);
                dgridTransferidoSUrgentes.DataBind();
                if (dgridTransferidoSUrgentes.Items.Count == 0)
                    pnTransferidoSUrgentes.Visible = false;

                dgridTransferidoUrgentes.DataSource = bandeja.ListaEncabezados(IdTipo, pFiltro, idCliente, idUser, Estados, 2, "", "", 100, false);
                dgridTransferidoUrgentes.DataBind();

                if (dgridTransferidoUrgentes.Items.Count == 0)
                    pnTransferidoUrgentes.Visible = false;

                dgridTransferidoNormales.DataSource = bandeja.ListaEncabezados(IdTipo, pFiltro, idCliente, idUser, Estados, 1, "", "", 100, false);
                dgridTransferidoNormales.DataBind();

                if (dgridTransferidoNormales.Items.Count == 0)
                    pnTransferidoNormales.Visible = false;


                if ((dgridTransferidoDigitales.Items.Count == 0) && (dgridTransferidoSUrgentes.Items.Count == 0) && (dgridTransferidoUrgentes.Items.Count == 0) && (dgridTransferidoNormales.Items.Count == 0))
                {
                    lblMensaje.Text = "No hay Informes de Propiedad transferidos para la búsqueda <b> " + pFiltro + "</b>.";
                    lblMensaje.Visible = true;
                    //btnImprimir.Visible = false;
                }
            }



            if (idTab == 4)
            {
                pnCondicionalDigitales.Visible = true;
                pnCondicionalSUrgentes.Visible = true;
                pnCondicionalUrgentes.Visible = true;
                pnCondicionalNormales.Visible = true;

                Estados = "11";
                Response.Write("<script>var menu = 4;</script>");    
                BandejaEntradaApp bandeja = new BandejaEntradaApp();
                //if (chkSoloMias.Checked) idUser = IdUsuario;
                dgridCondicionalDigitales.DataSource = bandeja.ListaEncabezados(IdTipo, pFiltro, idCliente, idUser, Estados, 4, "", "", 100, false);
                dgridCondicionalDigitales.DataBind();
                if (dgridCondicionalDigitales.Items.Count == 0)
                    pnCondicionalDigitales.Visible = false;

                dgridCondicionalSUrgentes.DataSource = bandeja.ListaEncabezados(IdTipo, pFiltro, idCliente, idUser, Estados, 3, "", "", 100, false);
                dgridCondicionalSUrgentes.DataBind();
                if (dgridCondicionalSUrgentes.Items.Count == 0)
                    pnCondicionalSUrgentes.Visible = false;

                dgridCondicionalUrgentes.DataSource = bandeja.ListaEncabezados(IdTipo, pFiltro, idCliente, idUser, Estados, 2, "", "", 100, false);
                dgridCondicionalUrgentes.DataBind();

                if (dgridCondicionalUrgentes.Items.Count == 0)
                    pnCondicionalUrgentes.Visible = false;

                dgridCondicionalNormales.DataSource = bandeja.ListaEncabezados(IdTipo, pFiltro, idCliente, idUser, Estados, 1, "", "", 100, false);
                dgridCondicionalNormales.DataBind();

                if (dgridCondicionalNormales.Items.Count == 0)
                    pnCondicionalNormales.Visible = false;


                if ((dgridCondicionalDigitales.Items.Count == 0) && (dgridCondicionalSUrgentes.Items.Count == 0) && (dgridCondicionalUrgentes.Items.Count == 0) && (dgridCondicionalNormales.Items.Count == 0))
                {
                    lblMensaje.Text = "No hay Informes de Propiedad condicionales para la búsqueda <b> " + pFiltro + "</b>.";
                    lblMensaje.Visible = true;
                    //btnImprimir.Visible = false;
                }
            }
        }


        protected void btnImpresiones_Click(object sender, EventArgs e)
        {
            Response.Redirect("historialimpresiones.aspx?idTipo=1");
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

			Encabezado.Cancelar(idEncabezado, false);
		}


        private void cambiarEstadoCondicional(int idEncabezado, string idEstado)
        {
            EncabezadoApp Encabezado = new EncabezadoApp();
            Encabezado.cargarEncabezado(idEncabezado);

            Encabezado.CambiarEstadoCondicional(idEncabezado, idEstado);
        }

        private void actualizarEstados()
        {
            string estado;
            string estadoSel;
            bool modificado = false;

            foreach (DataGridItem myItem in dgridCondicionalDigitales.Items)
            {
                estado = "";
                estadoSel = "";

                estado = myItem.Cells[14].Text.ToString();
                estadoSel = ((DropDownList)myItem.FindControl("ddEstadoCondicional")).SelectedValue;

                if (estado != estadoSel)
                {
                    cambiarEstadoCondicional(int.Parse(myItem.Cells[0].Text.ToString()), estadoSel);
                    modificado = true;
                }
            }

            foreach (DataGridItem myItem in dgridCondicionalSUrgentes.Items)
            {
                estado = "";
                estadoSel = "";

                estado = myItem.Cells[14].Text.ToString();
                estadoSel = ((DropDownList)myItem.FindControl("ddEstadoCondicional")).SelectedValue;

                if (estado != estadoSel)
                {
                    cambiarEstadoCondicional(int.Parse(myItem.Cells[0].Text.ToString()), estadoSel);
                    modificado = true;
                }
            }


            foreach (DataGridItem myItem in dgridCondicionalUrgentes.Items)
            {
                estado = "";
                estadoSel = "";
                

                estado = myItem.Cells[14].Text.ToString();
                estadoSel = ((DropDownList)myItem.FindControl("ddEstadoCondicional")).SelectedValue;

                if (estado != estadoSel)
                {
                    cambiarEstadoCondicional(int.Parse(myItem.Cells[0].Text.ToString()), estadoSel);
                    modificado = true;
                }
            }


            foreach (DataGridItem myItem in dgridCondicionalNormales.Items)
            {
                estado = "";
                estadoSel = "";

                estado = myItem.Cells[14].Text.ToString();
                estadoSel = ((DropDownList)myItem.FindControl("ddEstadoCondicional")).SelectedValue;

                if (estado != estadoSel)
                {
                    cambiarEstadoCondicional(int.Parse(myItem.Cells[0].Text.ToString()), estadoSel);
                    modificado = true;
                }
            }

            if (modificado)
                ListaBandeja(4);
        }


        private void ListarDetallesTransferidos(int idEncabezado)
        {
            EncabezadoApp oEncabezado = new EncabezadoApp();
            oEncabezado.cargarEncabezado(idEncabezado);
            lblTitTransferidoDetalle.Text = oEncabezado.TraerDescripcionInforme();

            pnTransferidoDigitales.Visible = false;
            pnTransferidoSUrgentes.Visible = false;
            pnTransferidoUrgentes.Visible = false;
            pnTransferidoNormales.Visible = false;
            pnTransferidoDetalles.Visible = true;
            Button1.Visible = false;

            Response.Write("<script>menu = " + menuTab.SelectedItem.Value + ";</script>");

            IdTipo = 1;
            string Estados = "-1";
            lblMensaje.Text = "";

            BandejaEntradaApp bandeja = new BandejaEntradaApp();
            dgridTransferidoDetalles.DataSource = bandeja.ListaEncabezadosTransferidos(-1, -1, IdTipo, Estados, -1, "", "", 100, false, idEncabezado);
            dgridTransferidoDetalles.DataBind();
            if (dgridTransferidoDetalles.Items.Count == 0)
                pnTransferidoDetalles.Visible = false;
        
        }

        protected void btnCondicionales_Click(object sender, EventArgs e)
        {
            Response.Redirect("impresioncondicionales.aspx");
        }

        /*
        protected void btnBuscarExistente_Click(object sender, EventArgs e)
         {
             IdTipo = 1;
             string Estados = "-1";
            string filtroBuscar = txtBuscarExistente.Text;
             //BandejaEntradaApp bandeja = new BandejaEntradaApp();
             //dgridInformesExistentes.DataSource = bandeja.ListaEncabezados(IdTipo, filtroBuscar, -1, -1, Estados, -1, "", "", 100, false);
             //dgridInformesExistentes.DataBind();
            lblConUDP.Text = "Presionó el boton de carga asincrono con Update Panel. Note que la pagina no se refresco";
        }
         */
 

        protected void btnConUDP_Click(object sender, EventArgs e)
        {
            lblConUDP.Text = "Presionó el boton de carga asincrono con Update Panel. Note que la pagina no se refresco";
        }
    }
}