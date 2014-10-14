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

public partial class InformePropiedad_listadocondicionales : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        listarInformesPropiedadCondicionales();
    }

    private void listarInformesPropiedadCondicionales()
    {
        string FechaDesde = DateTime.Today.AddYears(-1).ToShortDateString();
        string FechaHasta = DateTime.Today.ToShortDateString();
        lblFechaActual.Text = FechaHasta + " " + DateTime.Now.ToShortTimeString();

        string estado = "11";

        //En seguimiento

        BandejaEntradaApp bandeja = new BandejaEntradaApp();
        bandeja.RegPorPagina = 1000;
        bandeja.Pagina = 1;
        dlSUrgenteSeg.DataSource = bandeja.ListaEncabezadosCondicionales(-1, -1, 1, estado, 3, FechaDesde, FechaHasta, 0, false, 2);
        dlSUrgenteSeg.DataBind();
        if (dlSUrgenteSeg.Items.Count == 0)
        {
            lblSUrgenteSeg.Visible = false;
            pnSUrgenteSeg.Visible = false;
        }

        dlUrgenteSeg.DataSource = bandeja.ListaEncabezadosCondicionales(-1, -1, 1, estado, 2, FechaDesde, FechaHasta, 0, false, 2);
        dlUrgenteSeg.DataBind();
        if (dlUrgenteSeg.Items.Count == 0)
        {
            lblUrgenteSeg.Visible = false;
            pnUrgenteSeg.Visible = false;
        }

        dlNormalSeg.DataSource = bandeja.ListaEncabezadosCondicionales(-1, -1, 1, estado, 1, FechaDesde, FechaHasta, 0, false, 2);
        dlNormalSeg.DataBind();
        if (dlNormalSeg.Items.Count == 0)
        {
            lblNormalSeg.Visible = false;
            pnNormalSeg.Visible = false;
        }


        if ((dlSUrgenteSeg.Items.Count == 0) && (dlUrgenteSeg.Items.Count == 0) && (dlNormalSeg.Items.Count == 0))
            pnEnSeguimiento.Visible = false;



        //Pendiente confirmación

        dlSUrgentePen.DataSource = bandeja.ListaEncabezadosCondicionales(-1, -1, 1, estado, 3, FechaDesde, FechaHasta, 0, false, 1);
        dlSUrgentePen.DataBind();
        if (dlSUrgentePen.Items.Count == 0)
        {
            lblSUrgentePen.Visible = false;
            pnSUrgentePen.Visible = false;
        }

        dlUrgentePen.DataSource = bandeja.ListaEncabezadosCondicionales(-1, -1, 1, estado, 2, FechaDesde, FechaHasta, 0, false, 1);
        dlUrgentePen.DataBind();
        if (dlUrgentePen.Items.Count == 0)
        {
            lblUrgentePen.Visible = false;
            pnUrgentePen.Visible = false;
        }

        dlNormalPen.DataSource = bandeja.ListaEncabezadosCondicionales(-1, -1, 1, estado, 1, FechaDesde, FechaHasta, 0, false, 1);
        dlNormalPen.DataBind();
        if (dlNormalPen.Items.Count == 0)
        {
            lblNormalPen.Visible = false;
            pnNormalPen.Visible = false;
        }


        if ((dlSUrgentePen.Items.Count == 0) && (dlUrgentePen.Items.Count == 0) && (dlNormalPen.Items.Count == 0))
            pnPendiente.Visible = false;

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("propiedad_registro.aspx");
    }
}
