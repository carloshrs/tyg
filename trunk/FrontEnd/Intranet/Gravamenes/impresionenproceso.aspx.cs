using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.App;

public partial class InformeGravamenes_listadopendientes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        listarInformesGravamenesEnProceso();
    }

    private void listarInformesGravamenesEnProceso()
    {
        string FechaDesde = DateTime.Today.AddYears(-1).ToShortDateString();
        string FechaHasta = DateTime.Today.ToShortDateString();
        lblFechaActual.Text = FechaHasta + " " + DateTime.Now.ToShortTimeString();

        int intGrupo = int.Parse(Request.QueryString["idGrupo"]);
        string estado = "2";
        if (Request.QueryString["estado"] != null) estado = Request.QueryString["estado"];

        BandejaEntradaApp bandeja = new BandejaEntradaApp();
        bandeja.RegPorPagina = 1000;
        bandeja.Pagina = 1;

        dlSUrgente.DataSource = bandeja.ListaEncabezadosGrupos(-1, -1, 3, estado, 3, FechaDesde, FechaHasta, 0, false, intGrupo, "");
        dlSUrgente.DataBind();
        if (dlSUrgente.Items.Count == 0)
            lblSUrgente.Visible = false;


        dlUrgente.DataSource = bandeja.ListaEncabezadosGrupos(-1, -1, 3, estado, 2, FechaDesde, FechaHasta, 0, false, intGrupo, "");
        dlUrgente.DataBind();
        if (dlUrgente.Items.Count == 0)
            lblUrgente.Visible = false;


        dlNormal.DataSource = bandeja.ListaEncabezadosGrupos(-1, -1, 3, estado, 1, FechaDesde, FechaHasta, 0, false, intGrupo, "");
        dlNormal.DataBind();
        if (dlNormal.Items.Count == 0)
            lblNormal.Visible = false;

        
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("../BandejaEntrada/Principal.aspx?idTipo=3");
    }
}
