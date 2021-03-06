﻿using System;
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

public partial class InformeInhibicion_listadopendientes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        listarInformesInhibicionEnProceso();
    }

    private void listarInformesInhibicionEnProceso()
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

        dlUrgente.DataSource = bandeja.ListaEncabezadosGrupos(-1, -1, 13, estado, 2, FechaDesde, FechaHasta, 0, false, intGrupo, "");
        dlUrgente.DataBind();

        dlNormal.DataSource = bandeja.ListaEncabezadosGrupos(-1, -1, 13, estado, 1, FechaDesde, FechaHasta, 0, false, intGrupo, "");
        dlNormal.DataBind();
        
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("../BandejaEntrada/Principal.aspx?idTipo=13");
    }
}
