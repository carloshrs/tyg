using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.Clientes.Dal;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.InformePropiedadOtrasProvincias
{
    /// <summary>
    /// Summary description for Principal.
    /// </summary>
    public partial class propiedad_registro : Page
    {
        private int IdTipo;
        protected Button Button1;
        private int IdUsuario = 1; //VALOR QUE SE OBTENDRA DEL CONTEXTO
        private int intIndex = 0;

        protected void Page_Load(object sender, EventArgs e)
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

            if (!Page.IsPostBack)
            {
                ListaBandeja(intIndex);
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
                BandejaEntradaApp bandeja = new BandejaEntradaApp();
                //if (chkSoloMias.Checked) idUser = IdUsuario;
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


                if ((dgridEnEsperaSUrgentes.Items.Count == 0) && (dgridEnEsperaUrgentes.Items.Count == 0) && (dgridEnEsperaNormales.Items.Count == 0))
                {
                    lblMensaje.Text = "No hay Informes de Propiedad para generar el formulario taza.";
                    lblMensaje.Visible = true;
                    //btnImprimir.Visible = false;
                }
            }

            if (idTab == 1)
            {
                Estados = "2";
                BandejaEntradaApp bandeja = new BandejaEntradaApp();
                //if (chkSoloMias.Checked) idUser = IdUsuario;
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


                if ((dgridEnProcesoSUrgentes.Items.Count == 0) && (dgridEnProcesoUrgentes.Items.Count == 0) && (dgridEnProcesoNormales.Items.Count == 0))
                {
                    lblMensaje.Text = "No hay Informes de Propiedad para enviar al registro";
                    lblMensaje.Visible = true;
                    //btnImprimir.Visible = false;
                }
            }

            if (idTab == 2)
            {
                Estados = "9";
                BandejaEntradaApp bandeja = new BandejaEntradaApp();
                //if (chkSoloMias.Checked) idUser = IdUsuario;
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


                if ((dgridProblemaSUrgentes.Items.Count == 0) && (dgridProblemaUrgentes.Items.Count == 0) && (dgridProblemaNormales.Items.Count == 0))
                {
                    lblMensaje.Text = "No hay Informes de Propiedad con problemas.";
                    lblMensaje.Visible = true;
                    //btnImprimir.Visible = false;
                }
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

                ((Label)myItem.FindControl("lblDescripcion")).Text = strDescripcion;
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

                ((Label)myItem.FindControl("lblDescripcion")).Text = strDescripcion;

                string strScript = "cambiarEstado(" + myItem.Cells[0].Text + "); return false;";
                ((ImageButton)myItem.FindControl("Problema")).OnClientClick = strScript;
            }
        }

        protected void dgridProblemaSUrgentes_PreRender(object sender, EventArgs e)
        {
            string strDescripcion = "";
            foreach (DataGridItem myItem in dgridProblemaSUrgentes.Items)
            {
                ((Label)myItem.FindControl("lblFecha")).Text = DateTime.Parse(myItem.Cells[2].Text).ToShortDateString() + " " + DateTime.Parse(myItem.Cells[2].Text).ToShortTimeString();
                if (int.Parse(myItem.Cells[4].Text) == 1)
                    strDescripcion = "<b>Mat.</b> " + myItem.Cells[5].Text;
                if (int.Parse(myItem.Cells[4].Text) == 2)
                    strDescripcion = "<b>Dom.</b> " + myItem.Cells[5].Text + " / <b>F°</b> " + myItem.Cells[6].Text + " / <b>T°</b> " + myItem.Cells[7].Text + " / <b>A°</b> " + myItem.Cells[8].Text;
                if (int.Parse(myItem.Cells[4].Text) == 3)
                    strDescripcion = "<b>LE</b> " + myItem.Cells[5].Text + " / <b>F°</b> " + myItem.Cells[6].Text + " / <b>T°</b> " + myItem.Cells[7].Text + " / <b>A°</b> " + myItem.Cells[8].Text;

                ((Label)myItem.FindControl("lblDescripcion")).Text = strDescripcion;
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

                ((Label)myItem.FindControl("lblDescripcion")).Text = strDescripcion;
                
                string strScript = "cambiarEstado(" + myItem.Cells[0].Text + "); return false;";
                ((ImageButton)myItem.FindControl("Problema")).OnClientClick = strScript;
            }
        }

        protected void dgridProblemaUrgentes_PreRender(object sender, EventArgs e)
        {
            string strDescripcion = "";
            foreach (DataGridItem myItem in dgridProblemaUrgentes.Items)
            {
                ((Label)myItem.FindControl("lblFecha")).Text = DateTime.Parse(myItem.Cells[2].Text).ToShortDateString() + " " + DateTime.Parse(myItem.Cells[2].Text).ToShortTimeString();
                if (int.Parse(myItem.Cells[4].Text) == 1)
                    strDescripcion = "<b>Mat.</b> " + myItem.Cells[5].Text;
                if (int.Parse(myItem.Cells[4].Text) == 2)
                    strDescripcion = "<b>Dom.</b> " + myItem.Cells[5].Text + " / <b>F°</b> " + myItem.Cells[6].Text + " / <b>T°</b> " + myItem.Cells[7].Text + " / <b>A°</b> " + myItem.Cells[8].Text;
                if (int.Parse(myItem.Cells[4].Text) == 3)
                    strDescripcion = "<b>LE</b> " + myItem.Cells[5].Text + " / <b>F°</b> " + myItem.Cells[6].Text + " / <b>T°</b> " + myItem.Cells[7].Text + " / <b>A°</b> " + myItem.Cells[8].Text;

                ((Label)myItem.FindControl("lblDescripcion")).Text = strDescripcion;
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

                ((Label)myItem.FindControl("lblDescripcion")).Text = strDescripcion;

                string strScript = "cambiarEstado(" + myItem.Cells[0].Text + "); return false;";
                ((ImageButton)myItem.FindControl("Problema")).OnClientClick = strScript;
            }
        }

        protected void dgridProblemaNormales_PreRender(object sender, EventArgs e)
        {
            string strDescripcion = "";
            foreach (DataGridItem myItem in dgridProblemaNormales.Items)
            {
                ((Label)myItem.FindControl("lblFecha")).Text = DateTime.Parse(myItem.Cells[2].Text).ToShortDateString() + " " + DateTime.Parse(myItem.Cells[2].Text).ToShortTimeString();
                if (int.Parse(myItem.Cells[4].Text) == 1)
                    strDescripcion = "<b>Mat.</b> " + myItem.Cells[5].Text;
                if (int.Parse(myItem.Cells[4].Text) == 2)
                    strDescripcion = "<b>Dom.</b> " + myItem.Cells[5].Text + " / <b>F°</b> " + myItem.Cells[6].Text + " / <b>T°</b> " + myItem.Cells[7].Text + " / <b>A°</b> " + myItem.Cells[8].Text;
                if (int.Parse(myItem.Cells[4].Text) == 3)
                    strDescripcion = "<b>LE</b> " + myItem.Cells[5].Text + " / <b>F°</b> " + myItem.Cells[6].Text + " / <b>T°</b> " + myItem.Cells[7].Text + " / <b>A°</b> " + myItem.Cells[8].Text;

                ((Label)myItem.FindControl("lblDescripcion")).Text = strDescripcion;
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
            CheckBox chkSelUrgente;
            CheckBox chkSelNormal;
            int intIdInforme;
            int intGrupo = 0;
            EncabezadoApp Encabezado = new EncabezadoApp();
            UsuarioAutenticado Usuario = (UsuarioAutenticado)Session["UsuarioAutenticado"];

            if (dgridEnEsperaSUrgentes.Items.Count > 0 || dgridEnEsperaUrgentes.Items.Count > 0 || dgridEnEsperaNormales.Items.Count > 0)
                intGrupo = Encabezado.crearGrupoCambioEstado(Usuario.IdUsuario, 11);

            foreach (DataGridItem dgSUrg in dgridEnEsperaSUrgentes.Items)
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


            foreach (DataGridItem dgUrg in dgridEnEsperaUrgentes.Items)
            {
                chkSelUrgente = (CheckBox)dgUrg.FindControl("chkUrgente");
                if (chkSelUrgente.Checked)
                {
                    intIdInforme = int.Parse(dgUrg.Cells[0].Text);
                    Encabezado.cargarEncabezado(intIdInforme);
                    Encabezado.Estado = 2;
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
                    Encabezado.Estado = 2;
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
            CheckBox chkSelSUrgente;
            CheckBox chkSelUrgente;
            CheckBox chkSelNormal;
            int intIdInforme;
            EncabezadoApp Encabezado = new EncabezadoApp();


            foreach (DataGridItem dgSUrg in dgridEnProcesoSUrgentes.Items)
            {
                chkSelSUrgente = (CheckBox)dgSUrg.FindControl("chkSUrgente");
                if (chkSelSUrgente.Checked)
                {
                    intIdInforme = int.Parse(dgSUrg.Cells[0].Text);
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

        protected void menuTab_MenuItemClick(object sender, MenuEventArgs e)
        {
            contenedor.ActiveViewIndex = Int32.Parse(e.Item.Value);
            e.Item.Selected = true;
            if (menuTab.SelectedItem != null)
                Response.Write("<script>menu = " + menuTab.SelectedItem.Value + ";</script>");

            ListaBandeja(Int32.Parse(e.Item.Value));
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
                Response.Write("<script>var menu = 0;</script>");    
                BandejaEntradaApp bandeja = new BandejaEntradaApp();
                //if (chkSoloMias.Checked) idUser = IdUsuario;
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


                if ((dgridEnEsperaSUrgentes.Items.Count == 0) && (dgridEnEsperaUrgentes.Items.Count == 0) && (dgridEnEsperaNormales.Items.Count == 0))
                {
                    lblMensaje.Text = "No hay Informes de Propiedad para generar el formulario taza.";
                    lblMensaje.Visible = true;
                    //btnImprimir.Visible = false;
                }
            }

            if (idTab == 1)
            {
                Response.Write("<script>var menu = 1;</script>");    
                BandejaEntradaApp bandeja = new BandejaEntradaApp();
                //if (chkSoloMias.Checked) idUser = IdUsuario;
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


                if ((dgridEnProcesoSUrgentes.Items.Count == 0) && (dgridEnProcesoUrgentes.Items.Count == 0) && (dgridEnProcesoNormales.Items.Count == 0))
                {
                    lblMensaje.Text = "No hay Informes de Propiedad para enviar al registro";
                    lblMensaje.Visible = true;
                    //btnImprimir.Visible = false;
                }
            }
        }

        protected void btnImpresiones_Click(object sender, EventArgs e)
        {
            Response.Redirect("historialimpresiones.aspx?idTipo=11");
        }
    }
}