using System;
using System.Collections;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Script.Services;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;
using System.Data;

/// <summary>
/// Descripción breve de informeExistente
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
[ScriptService]
public class informeExistente : System.Web.Services.WebService
{
    [WebMethod]
    public string verificarInformeExistente(string valor)
    {

        //valor = ("cmbClientes") + "|" + ("cmbTipoInforme") + "|" + ("cmbTipoPropiedad") + "|" + ("txtLegajo");
        //valor = valor + "|" + ("cmbProvinciaOtra");

        //valor = ("cmbClientes") + "|" + ("cmbTipoInforme") + "|" + ("cmbTipoPropiedad") + "|" + ("txtFolio") + "|" + ("txtAno");
        //valor = valor + "|" + ("cmbProvinciaOtra");


        char[] separadores = new char[] { '|' };
        //string[] arrValor;
        //= valor.Split("|");
        string Matricula = "";
        string Folio = "";
        string Ano = "";
        string nombre = "";
        string[] arreglo = valor.Split(separadores);
        int idCliente = int.Parse(arreglo[0]);
        int tipoInforme = int.Parse(arreglo[1]);
        int tipoPropiedad = int.Parse(arreglo[2]);
        int idProvincia = 2;

        if (tipoPropiedad == 1 || tipoPropiedad == 4)
            Matricula = arreglo[3];

        if (tipoPropiedad == 2)
        {
            Folio = arreglo[3];
            Ano = arreglo[4];
        }

        if (tipoPropiedad == 3)
        {
            Matricula = arreglo[3];
            Folio = arreglo[4];
        }

        if (tipoInforme == 11)
        {
            if (tipoPropiedad == 1 || tipoPropiedad == 4)
                idProvincia = int.Parse(arreglo[4]);

            if (tipoPropiedad == 2 || tipoPropiedad == 3)
                idProvincia = int.Parse(arreglo[5]);
        }

        DataTable MyBase = ControlMatriculasDal.ControlarMatriculaSolicitadaExistente(0, idCliente, tipoInforme, tipoPropiedad, idProvincia, Matricula, Folio, Ano);

        if (MyBase.Rows.Count > 0)
        {
            for (int j = 0; j < MyBase.Rows.Count; j++)
            {
                if (j > 0) nombre = nombre + "|";
                nombre = nombre + MyBase.Rows[j]["idEncabezado"].ToString().Trim() + "," + MyBase.Rows[j]["fecha"].ToString().Trim() + "," + MyBase.Rows[j]["usuariocliente"].ToString().Trim() + "," + MyBase.Rows[j]["nombreestado"].ToString().Trim();
            }
        }

        string valorFinal = nombre;// +"," + cuit + "," + tmpDNI;
        return valorFinal;
    }

}

