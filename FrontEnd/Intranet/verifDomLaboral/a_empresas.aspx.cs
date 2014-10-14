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


public partial class verifDomLaboral_a_empresas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        EmpresasAPP empresas = new EmpresasAPP();
        string filtro = Request.Params["query"];
        bool razonsocial = true;
        if (filtro == null)
        {
            filtro = Request.Params["queryF"];
            razonsocial = false;
        }
        DataTable datos = null;
        if( razonsocial )
            datos = empresas.ListaEmpresas(1, filtro);
        else
            datos = empresas.ListaEmpresasFantasia(filtro);
        bool prim = true;
        foreach (DataRow fila in datos.Rows)
        {
            if (!prim)
                Response.Output.Write('^');
            prim = false;
            string id = fila["idEmpresa"].ToString();
            string nombre = "";
            if( razonsocial )
                nombre = fila["RazonSocial"].ToString().Trim();
            else
                nombre = fila["NombreFantasia"].ToString().Trim();
            Response.Output.Write(id + "|" + nombre);
        }
        Response.Flush();
        Response.End();
        return;
    }
}
