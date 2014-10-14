using System;
using System.Web;
using System.Web.Services;
using System.Xml;
using System.Web.Services.Protocols;
using System.Web.Script.Services;
using System.Data;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;


namespace Tiempoygestion.Intranet
{

    /// <summary>
    /// Descripción breve de padron
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 

    public class padron : System.Web.Services.WebService
    {

        public padron()
        {

            //Eliminar la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
            //InitializeComponent(); 
        }

        /*
        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }
        */

        [WebMethod]
        public string GetNombrePersona(int valor)
        {
            string cuit = "";
            string nombre = "";
            string tmpDNI = "";
            PadronDal padron = new PadronDal();
            DataTable myTable = padron.TraerDatos(valor);
            if (myTable.Rows.Count > 0)
            {
                for (int j = 0; j < myTable.Rows.Count; j++)
                {
                    string tmpCuit = myTable.Rows[j]["cuit"].ToString();
                    tmpDNI = tmpCuit.Substring(2, tmpCuit.Length - 3);
                    int dni = int.Parse(myTable.Rows[j]["dni"].ToString());
                    if (dni == valor)
                    {
                        cuit = myTable.Rows[j]["cuit"].ToString();
                        nombre = myTable.Rows[j]["nombre"].ToString();
                        dni = int.Parse(myTable.Rows[j]["dni"].ToString());
                    }
                }
            }
            else
            {
                nombre = "Persona no existe en la Base de Padron";
            }

            return nombre;
        }
    }

}