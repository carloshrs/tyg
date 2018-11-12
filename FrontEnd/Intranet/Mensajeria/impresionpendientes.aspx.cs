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
using ar.com.TiempoyGestion.BackEnd.Verificaciones.Dal;

public partial class mensajeria_listadopendientes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        dlMensajeria.ItemDataBound +=
             new DataListItemEventHandler(this.Item_Bound);

        listarInformesMensajeria();
    }

    private void listarInformesMensajeria()
    {
        string FechaDesde = DateTime.Today.AddYears(-1).ToShortDateString();
        string FechaHasta = DateTime.Today.ToShortDateString();
        lblFechaActual.Text = FechaHasta;

        int intGrupo = int.Parse(Request.QueryString["idGrupo"]);
        string estado = "2";
        if (Request.QueryString["estado"] != null) estado = Request.QueryString["estado"];

        BandejaEntradaApp bandeja = new BandejaEntradaApp();
        bandeja.RegPorPagina = 1000;
        bandeja.Pagina = 1;
        dlMensajeria.DataSource = bandeja.ListaEncabezadosGruposMensajeria(-1, -1, 22, estado, -1, FechaDesde, FechaHasta, 0, false, intGrupo, "");
        dlMensajeria.DataBind();
        int cantReg = dlMensajeria.Items.Count;
        
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("../BandejaEntrada/Principal.aspx?idTipo=22");
    }

    protected void Item_Bound(Object sender, DataListItemEventArgs e)
    {

        if (e.Item.ItemType == ListItemType.Item ||
            e.Item.ItemType == ListItemType.AlternatingItem)
        {
            //((Label)e.Item.FindControl("lblFecha")).Text = ((DataRowView)e.Item.DataItem).Row.ItemArray[7].ToString();
            int nroResto = int.Parse(((DataRowView)e.Item.DataItem).Row.ItemArray[26].ToString()) % 10;

            if (nroResto == 0)
                //pnSaltoPagina.Visible = true;
                e.Item.FindControl("pnSaltoPagina").Visible = true;
            
                /*
            else
                idSaltoPagina.visible = false;
             */
            // Retrieve the Label control in the current DataListItem.
            //Label PriceLabel = (Label)e.Item.FindControl("PriceLabel");

            // Retrieve the text of the CurrencyColumn from the DataListItem
            // and convert the value to a Double.
            //Double Price = Convert.ToDouble(((DataRowView)e.Item.DataItem).Row.ItemArray[2].ToString());

            // Format the value as currency and redisplay it in the DataList.
            //PriceLabel.Text = Price.ToString("c");

        }

    }

}
