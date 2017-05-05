﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.App;
using ar.com.TiempoyGestion.BackEnd.Clientes.Dal;
using ar.com.TiempoyGestion.BackEnd.Cobranzas.App;
using System.Data;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.App;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;
using System.Globalization;
using ar.com.TiempoyGestion.BackEnd.Cobranzas.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.Admin.Cuentas
{
    public partial class imprimirdeudadetalle : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                
                lblFecha.Text = DateTime.Today.ToShortDateString();

                if (Request.QueryString["tipoPeriodo"] != null && Request.QueryString["tipoPeriodo"] != "")
                    ListadoDeuda(int.Parse(Request.QueryString["tipoPeriodo"]));
            }
        }



        private void ListadoDeuda(int tipoPeriodo)
        {
            string fechaDesde = "";
            string fechaHasta = "";
            string clientes = "";

            lblTipoPeriodo.Text = (tipoPeriodo == 2) ? "Mensuales" : "Diarios";

            fechaDesde = Request.QueryString["fechaDesde"];
            fechaHasta = Request.QueryString["fechaHasta"];
            clientes = Request.QueryString["clientes"];
            lblTotal.Visible = (Request.QueryString["subtotal"] == "1") ? true : false;

            if (fechaDesde == "")
                lblFechaDesde.Text = lblFechaDesde.Text = DateTime.Today.AddYears(-7).ToShortDateString();
            else
                lblFechaDesde.Text = fechaDesde;

            if (lblFechaHasta.Text == "")
                lblFechaHasta.Text = DateTime.Today.ToShortDateString();
            else
                lblFechaHasta.Text = fechaHasta;

            
            lvListadoClientes.DataSource = GestorPrecios.ListaPendientesCobrosClientes(tipoPeriodo, fechaDesde, fechaHasta, clientes).DefaultView;
            lvListadoClientes.DataBind();

        }


        protected void InformeDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListViewDataItem di = (ListViewDataItem)e.Item;
                DataRow row = ((DataRowView)di.DataItem).Row;
                int idCliente = int.Parse(row.ItemArray[2].ToString());
                int idTipoPeriodo = 0;
                ListView lvInformes = (ListView)e.Item.FindControl("lvInformes");

                GestorPrecios gp = new GestorPrecios();
                if (Request.QueryString["tipoPeriodo"] != null && Request.QueryString["tipoPeriodo"] != "")
                    idTipoPeriodo = int.Parse(Request.QueryString["tipoPeriodo"]);
                else
                    idTipoPeriodo = 2;

                lvInformes.DataSource = GestorPrecios.ListaPendientesCobrosClientesDocumentos(idTipoPeriodo, idCliente, lblFechaDesde.Text, lblFechaHasta.Text);
                lvInformes.DataBind();

                
            }
        }



        protected void lvListadoClientes_PreRender(object sender, EventArgs e)
        {
            float vTotal = 0;
            //float montoTotal = float.Parse(row.ItemArray[4].ToString());
            foreach (ListViewDataItem myItem in lvListadoClientes.Items)
            {
                try
                {
                    //((Label)myItem.FindControl("lblPrecioUnitario")).Text = "$ " + System.Math.Round(decimal.Parse(myItem.Cells[2].Text), 2).ToString();
                    //((Label)myItem.FindControl("lblPrecioTotal")).Text = "$ " + System.Math.Round(decimal.Parse(myItem.Cells[4].Text), 2).ToString();
                    //vTotal = vTotal + float.Parse(myItem.DataItem[2].Text);
                    vTotal = vTotal + float.Parse(((Label)myItem.FindControl("lblSubtotal")).Text.Replace("$ ", ""), CultureInfo.InvariantCulture);
                }
                catch (Exception exc)
                { }
            }

            lblTotal.Text = "$ " + vTotal;
        }
    }
}