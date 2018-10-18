<%@ WebHandler Language="C#" Class="Search" %>

using System;
using System.Data.SqlClient;
using System.Text;
using System.Web;

public class Search : IHttpHandler {
    
    public void ProcessRequest (HttpContext context)
    {
        string searchText = context.Request.QueryString["q"];
        SqlConnection con = new SqlConnection("Data Source=CARLOS-SSD; Initial Catalog=tiempoygestion; Password=r3d3f1n3;Persist Security Info=True;User ID=sa;");
        con.Open();
        string mySQL = "select distinct c.IdCliente, c.nombrefantasia, c.sucursal, c.Calle, c.Numero, c.piso, c.office, c.telefono, c.email, " +
            "(select STUFF( " +
            "(Select nombre + ' ' + apellido + ' (' + loginname + ')' + CAST('-' AS varchar(MAX)) " +
            "from usuarios where not apellido like 'Solicitud Tele%' and estado=1 AND idCliente=c.idCliente " +
            "FOR XML PATH('')), 1, 0, '')) as usuarios" +
            " from clientes c " +
            " left outer join usuarios u on c.idCliente=u.idCliente and not u.loginName like ('UserTel%') AND u.estado=1 " +
            " where (c.razonsocial Like '%' + @Search + '%' OR c.nombrefantasia Like '%' + @Search + '%')" +
            " AND c.activo = 1 " +
            " order by c.nombrefantasia";
        SqlCommand cmd = new SqlCommand(mySQL , con);
        cmd.Parameters.AddWithValue("@Search",searchText);
        StringBuilder sb = new StringBuilder();
        string empresa = "";
        string direccion = "";
        using(SqlDataReader dr=cmd.ExecuteReader())
        {
            while(dr.Read())
            {
                empresa = dr["nombrefantasia"].ToString();
                if (dr["sucursal"].ToString() != "")
                    empresa += " (" + dr["sucursal"].ToString() + ")";

                direccion = dr["calle"].ToString() + " " + dr["Numero"].ToString();
                if (dr["piso"].ToString() != "")
                    direccion += " Piso: " + dr["piso"].ToString() + " Of:" + dr["Office"].ToString();
                direccion += " - Tel: " + dr["telefono"].ToString();

                sb.Append(string.Format("{0},{1},{2},{3},{4}{5}", dr["idCliente"].ToString(), empresa, direccion, dr["email"].ToString(), dr["usuarios"].ToString(), Environment.NewLine));
            }
        }
        con.Close();
        context.Response.Write(sb.ToString());
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}

