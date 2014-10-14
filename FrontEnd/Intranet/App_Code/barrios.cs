using System;
using System.Collections;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
//using System.Xml.Linq;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;
using ar.com.TiempoyGestion.BackEnd.Verificaciones.Dal;
using System.Data;
using System.Web.Script.Services;

/// <summary>
/// Descripción breve de autocomplete
/// </summary>
/// 
/*
namespace Samples.AspNet
{*/

    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ScriptService]

    public class barrios : System.Web.Services.WebService
    {

        [WebMethod]
        public string[] BuscarBarrio(string prefixText, string contextKey)
        {
            string filtro = prefixText;
            int idLocalidad = int.Parse(contextKey);
            UtilesApp util = new UtilesApp();


            DataTable datos = null;
            datos = util.TraerBarrios(idLocalidad, filtro);

            bool prim = true;
            string nombre = "";
            //string id = "";
            int i = 1;
            List<string> arrBarrios = new List<string>();
            //ArrayList arrEmpresas = new ArrayList();
            //string[] arrEmpresas = new string[datos.Rows.Count];


            foreach (DataRow fila in datos.Rows)
            {
                /*
                if (!prim)
                    Response.Output.Write('^');
                 */
                prim = false;
                //id = fila["cod_bar"].ToString();
                nombre = "";
                nombre = fila["nom_bar"].ToString().Trim();
                //Response.Output.Write(id + "|" + nombre);
                //arrEmpresas.SetValue(id.ToString() + "|" + nombre.ToString(), i);
                arrBarrios.Add(nombre.ToString());
                i ++;
            }
            //Response.Flush();
            //Response.End();
            return arrBarrios.ToArray();

            /*
            Dim lista As New List(Of String)
        While dr.Read
            lista.Add(dr.Item("PeliculaNombre"))
        End While
        comando.Connection.Close()
        Return lista.ToArray
            //return "Hola a todos";
             */ 
        }

    }

//}