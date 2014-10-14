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

    public class empresas : System.Web.Services.WebService
    {

        [WebMethod]
        public string[] BuscarEmpresa(string prefixText)
        {
            string filtro = prefixText;
            EmpresasAPP empresas = new EmpresasAPP();

            bool razonsocial = true;
            DataTable datos = null;
            if (razonsocial)
                datos = empresas.ListaEmpresas(1, filtro);
            else
                datos = empresas.ListaEmpresasFantasia(filtro);
            bool prim = true;
            string nombre = "";
            string id = "";
            int i = 1;
            List<string> arrEmpresas = new List<string>();

            foreach (DataRow fila in datos.Rows)
            {
                /*
                if (!prim)
                    Response.Output.Write('^');
                 */
                prim = false;
                id = fila["idEmpresa"].ToString();
                nombre = "";
                if (razonsocial)
                    nombre = fila["RazonSocial"].ToString().Trim();
                else
                    nombre = fila["NombreFantasia"].ToString().Trim();
                //Response.Output.Write(id + "|" + nombre);
                //arrEmpresas.SetValue(id.ToString() + "|" + nombre.ToString(), i);
                arrEmpresas.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(nombre.ToString(), id.ToString()));
                i ++;
            }
            //Response.Flush();
            //Response.End();
            return arrEmpresas.ToArray();

        }

    }

//}