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
using System.Globalization;

public partial class InformePartidasDefuncion_listadopendientes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        listarInformesDefuncionEnProceso();
    }

    private void listarInformesDefuncionEnProceso()
    {
        string FechaDesde = DateTime.Today.AddYears(-1).ToShortDateString();
        string FechaHasta = DateTime.Today.ToShortDateString();
        DateTimeFormatInfo fmt = (new CultureInfo("es-AR")).DateTimeFormat;
        lblFechaActual.Text = "Córdoba, " + DateTime.Now.ToString("d MMMM yyyy", fmt);

        int intGrupo = int.Parse(Request.QueryString["idGrupo"]);
        string vSexo = Request.QueryString["Sexo"];
        if (vSexo == "M")
            lblSexo.Text = "Masculino";
        else
            lblSexo.Text = "Femenino";

        string estado = "2";
        if (Request.QueryString["estado"] != null) estado = Request.QueryString["estado"];


        BandejaEntradaApp bandeja = new BandejaEntradaApp();
        bandeja.RegPorPagina = 1000;
        bandeja.Pagina = 1;
        dlSUrgente.DataSource = bandeja.ListaEncabezadosGrupos(-1, -1, 19, estado, 1, FechaDesde, FechaHasta, 0, false, intGrupo, vSexo);
        dlSUrgente.DataBind();
        if (dlSUrgente.Items.Count == 0)
            lblSUrgente.Visible = false;

    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("importar.aspx");
    }

    protected void btnVolver_Click(object sender, EventArgs e)
    {
        Response.Redirect("historialimpresiones.aspx?idTipo=19");
    }
}
