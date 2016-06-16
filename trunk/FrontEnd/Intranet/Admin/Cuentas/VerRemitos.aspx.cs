using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.App;
using ar.com.TiempoyGestion.BackEnd.Clientes.Dal;
using ar.com.TiempoyGestion.BackEnd.Clientes.App;
using System.Data;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.App;
using System.Globalization;
using System.Web.UI.HtmlControls;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.Admin.Cuentas
{
    public partial class Admin_Cuentas_remitos : System.Web.UI.Page
    {
        int idCliente = 0;
        int nroRemito = 0;
        int idTipoDocumentacion = 0;
        //protected System.Web.UI.HtmlControls.HtmlGenericControl idImprimir;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                idTipoDocumentacion = int.Parse(Request.QueryString["idTipo"]);
                setTipoCobranza(idTipoDocumentacion);
                pnCliente.Visible = false;
                cargarRemito(idTipoDocumentacion);
                ListarServicios(idTipoDocumentacion);
            }
        }

        private void cargarRemito(int idTipoDocumentacion)
        {
            idCliente = int.Parse(Request.QueryString["idCliente"]);
            nroRemito = int.Parse(Request.QueryString["nroRemito"]);
            //HtmlControl frImprimir = (HtmlControl)this.FindControl("idImprimir");
            //frImprimir.Attributes["src"] = "imprimirRemito.aspx?nroRemito=" + nroRemito + "&idCliente=" + idCliente;

            HtmlControl frImprimirDetalle = (HtmlControl)this.FindControl("idImprimirDetalle");
            frImprimirDetalle.Attributes["src"] = "imprimirRemitoDetalle.aspx?idTipo=" + Request.QueryString["idTipo"] + "&nroRemito=" + nroRemito + "&idCliente=" + idCliente;
            HtmlControl frImprimirDetalleRef = (HtmlControl)this.FindControl("idImprimirDetalleRef");
            frImprimirDetalleRef.Attributes["src"] = "imprimirRemitoDetalleRef.aspx?idTipo=" + Request.QueryString["idTipo"] + "&nroRemito=" + nroRemito + "&idCliente=" + idCliente;

            ClienteDal oCliente = new ClienteDal();
            oCliente.Cargar(idCliente);
            lblCliente.Text = oCliente.NombreFantasia + ((oCliente.Sucursal != "") ? " (" + oCliente.Sucursal + ")" : "");

            lblNroRemito.Text = nroRemito.ToString();
        }


        private void ListarServicios(int idTipoDocumentacion)
        {
            pnListadoInformes.Visible = true;
            pnCliente.Visible = true;

            GestorPreciosApp gp = new GestorPreciosApp();
            dgridRemitoServicios.DataSource = gp.ListaDetallesRemitoParteEntrega(idTipoDocumentacion, nroRemito, false);
            dgridRemitoServicios.DataBind();
        }



        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            StringBuilder cstext2 = new StringBuilder();
            String csname2 = "ButtonClickScript";
            Type cstype = this.GetType();
            ClientScriptManager cs = Page.ClientScript;
            //string tipoImpresion = "";
            //tipoImpresion = (chkd)
            cstext2.Append("<script type=\"text/javascript\"> ");
            cstext2.Append("iPrint(idImprimir); </");
            cstext2.Append("script>");
            cs.RegisterClientScriptBlock(cstype, csname2, cstext2.ToString(), false);


        }
        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("remitos.aspx?idTipo=" + Request.QueryString["idTipo"] + "&idCliente=" + Request.QueryString["idCliente"]);
        }

        private void setTipoCobranza(int idTipoDocumentacion)
        {
            if (idTipoDocumentacion == 1)
                lblDocumento.Text = "REMITO";
            else
                lblDocumento.Text = "PARTE DE ENTREGA";
        }
}
}