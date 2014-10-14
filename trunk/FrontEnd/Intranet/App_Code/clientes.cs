using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.Odbc;
using ar.com.TiempoyGestion.BackEnd.Clientes.Dal;

/// <summary>
/// Descripción breve de _default
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
[System.Web.Script.Services.ScriptService]
public class _default : System.Web.Services.WebService
{

    public _default()
    {

        //Eliminar la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string[] getClientes(string prefixText, int count)
    {
        ClienteDal clientes = new ClienteDal();
        DataTable myTable = clientes.Listar(prefixText);

        //string[] cntName = new string[myTable.Rows.Count]; // dtst.Tables[0].Rows.Count
        List<string> cntName = new List<string>();
        string texto = "";
        //int i = 0;
        try
        {
            foreach (DataRow myRow in myTable.Rows) //dtst.Tables[0].Rows
            {
                //cntName.SetValue(myRow[1].ToString(), i);
                if (myRow[2].ToString() != "")
                {
                    texto = myRow[2].ToString();
                    if (myRow[3].ToString() != "")
                        texto = texto + " (" + myRow[3].ToString() + ")" + // + " " + myRow[8].ToString()
                            "/n" + myRow[8].ToString();
                }
                else
                    texto = myRow[1].ToString() + "\n" +
                          myRow[8].ToString();

                cntName.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(texto, myRow[0].ToString()));
                //i++;
            }
        }

        catch { }
        return cntName.ToArray();
    }

}

