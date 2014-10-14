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

public partial class InformePropiedadOtrasProvincias_listadopendientes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        listarInformesPropiedadEnProceso();
    }

    private void listarInformesPropiedadEnProceso()
    {
        string FechaDesde = DateTime.Today.AddYears(-1).ToShortDateString();
        string FechaHasta = DateTime.Today.ToShortDateString();
        lblFechaActual.Text = FechaHasta + " " + DateTime.Now.ToShortTimeString();

        int intGrupo = int.Parse(Request.QueryString["idGrupo"]);

        BandejaEntradaApp bandeja = new BandejaEntradaApp();
        bandeja.RegPorPagina = 1000;
        bandeja.Pagina = 1;
        dlSUrgente.DataSource = bandeja.ListaEncabezadosGrupos(-1, -1, 1, "2", 3, FechaDesde, FechaHasta, 0, false, intGrupo);
        dlSUrgente.DataBind();

        dlUrgente.DataSource = bandeja.ListaEncabezadosGrupos(-1, -1, 1, "2", 2, FechaDesde, FechaHasta, 0, false, intGrupo);
        dlUrgente.DataBind();

        dlNormal.DataSource = bandeja.ListaEncabezadosGrupos(-1, -1, 1, "2", 1, FechaDesde, FechaHasta, 0, false, intGrupo);
        dlNormal.DataBind();
        
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("propiedad_registro.aspx");
    }
}
