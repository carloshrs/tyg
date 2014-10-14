using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;
using ar.com.TiempoyGestion.BackEnd.Verificaciones.Dal;


public partial class verifDomParticular_a_barrios : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UtilesApp util = new UtilesApp();
        DataTable datos = util.TraerBarrios(Int32.Parse(Request.Params["localidad"]), Request.Params["query"]);
        bool prim = true;
        foreach (DataRow fila in datos.Rows)
        {
            if (!prim)
                Response.Output.Write('^');
            prim = false;
            string id = fila["NOM_BAR"].ToString().Trim();
            string nombre = fila["NOM_BAR"].ToString().Trim();
            Response.Output.Write(id + "|" + nombre);
        }
        Response.Flush();
        Response.End();
        return;
    }
}
