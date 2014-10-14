using System;
using System.Web;
using System.Web.Services;
using System.Xml;
using System.Web.Services.Protocols;
using System.Web.Script.Services;
using System.Data;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;

namespace Samples.AspNet
{

    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ScriptService]
    public class ServerTime : System.Web.Services.WebService
    {

        [WebMethod]
        public string GetServerTime(int valor)
        {
            string cuit = "";
            string nombre = "";
            string tmpDNI = "";
            
            DataTable MyBase = ControlPersonasDal.ControlarDocumento(valor.ToString());

            if (MyBase.Rows.Count > 0)
            {
                nombre = "1," + MyBase.Rows[0]["apellido"].ToString().Trim() + "," + MyBase.Rows[0]["nombre"].ToString().Trim();
            }
            else
            {
                PadronDal padron = new PadronDal();
                DataTable myTable = padron.TraerDatos(valor);
                if (myTable.Rows.Count > 0)
                {
                    for (int j = 0; j < myTable.Rows.Count; j++)
                    {
                        //string tmpCuit = myTable.Rows[j]["cuit"].ToString();
                        //tmpDNI = tmpCuit.Substring(2, tmpCuit.Length - 3);
                        //int dni = int.Parse(myTable.Rows[j]["dni"].ToString());
                        //if (dni == valor)
                        //{
                        //    cuit = myTable.Rows[j]["cuit"].ToString();
                        if (j > 0) nombre = nombre + "|";
                        nombre = nombre + "1," + myTable.Rows[j]["nombre"].ToString();

                        //    dni = int.Parse(myTable.Rows[j]["dni"].ToString());
                        //}
                    }
                }
                else
                {
                    nombre = "1,Persona no existe en la base";
                }
            }
            //string valorFinal = String.Format("DNI: " + tmpDNI + " // Fecha verificación: {0}",
            //    DateTime.Now) +
            //    "<br>Nombre: " + nombre+
            //    "<br>Cuit: " + cuit;
            string valorFinal = nombre;// +"," + cuit + "," + tmpDNI;
            return valorFinal;

        }

    }

}

