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
        listarInformesDefuncionFinalizados();
    }

    private void listarInformesDefuncionFinalizados()
    {
        string FechaDesde = DateTime.Today.AddYears(-1).ToShortDateString();
        string FechaHasta = DateTime.Today.ToShortDateString();
        DateTimeFormatInfo fmt = (new CultureInfo("es-AR")).DateTimeFormat;
        lblFechaActual.Text = "Córdoba, " + DateTime.Now.ToString("d MMMM yyyy", fmt);

        int intGrupo = int.Parse(Request.QueryString["idGrupo"]);
        string estado = "3";
        if (Request.QueryString["estado"] != null) estado = Request.QueryString["estado"];


        BandejaEntradaApp bandeja = new BandejaEntradaApp();
        bandeja.RegPorPagina = 1000;
        bandeja.Pagina = 1;
        gvFinalizados.DataSource = bandeja.ListaInformesFinalizados(-1, -1, 19, estado, 1, FechaDesde, FechaHasta, 0, false, intGrupo);
        gvFinalizados.DataBind();
        //if (gvFinalizados.Items.Count == 0)
        //    lblSUrgente.Visible = false;

    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("importar.aspx");
    }



    protected void gvFinalizados_PreRender(object sender, EventArgs e)
    {
        string resultado = "";
        foreach (DataGridItem myItem in gvFinalizados.Items)
        {
            try
            {
                //((Label)myItem.FindControl("lblFecha")).Text = DateTime.Parse(myItem.Cells[1].Text).ToShortDateString() + " " + DateTime.Parse(myItem.Cells[1].Text).ToShortTimeString();
                if (myItem.Cells[1].Text == "1")
                    ((Label)myItem.FindControl("lblSexo")).Text = "Masculino";
                else
                    ((Label)myItem.FindControl("lblSexo")).Text = "Femenino";
                ((Label)myItem.FindControl("lblNombre")).Text = myItem.Cells[4].Text + ", " + myItem.Cells[5].Text;
                if (myItem.Cells[7].Text != "&nbsp;")
                {
                    if ((myItem.Cells[7].Text == "1"))
                    {
                        resultado = "FALLECIDO/A." + myItem.Cells[9].Text + " ACTA: " + myItem.Cells[9].Text + " TOMO: " + myItem.Cells[10].Text + " FOLIO: " + myItem.Cells[11].Text;
                        ((Label)myItem.FindControl("lblResultado")).Text = resultado;
                    }
                    else
                        ((Label)myItem.FindControl("lblResultado")).Text = "El Re.Na.Per. no ha remitido aviso de fallecimiento de esa persona.";
                }
            }
            catch (Exception exc)
            { }

        }
    }
}
