using System;
using System.Data;
using System.Data.Odbc;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;

namespace ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal
{
    /// <summary>
    /// Summary description for EstadoCivilDal.
    /// </summary>
    public class PadronDal : GenericDal
    {
        #region Atributos y Contructores
        private string strCUIT;
        private string strNombre;
        private int intDni;

        public PadronDal()
            : base()
        { }

        #endregion

        #region Propiedades

        public string Cuit
        {
            get
            {
                return strCUIT;
            }
        }

        public string Nombre
        {
            get
            {
                return strNombre;
            }
        }

        public int Dni
        {
            get
            {
                return intDni;
            }
        }
        #endregion

        #region Métodos Publicos


        public DataTable TraerDatos(int dniParam)
        {

            OdbcConnection oConnection = OpenConnection(true);
            DataSet myDataSet = new DataSet();
            DataTable myDataTable = new DataTable();
            DataColumn column = new DataColumn("nombre");
            myDataTable.Columns.Add(column);

            try
            {
                int i = 1;
                //bool corte = true;

                while(i < 6)
                {
                    String strSql = "SELECT cuit, nombre, dni FROM Padron" + i + " WHERE dni = " + dniParam;
                    OdbcDataAdapter myConsulta = new OdbcDataAdapter(strSql, oConnection);

                    myConsulta.Fill(myDataSet);
                    i++;
                }

                if (myDataSet.Tables[0].Rows.Count > 0)
                {
                    for (int j = 0; j < myDataSet.Tables[0].Rows.Count; j++)
                    {
                        //string tmpCuit = myDataSet.Tables[0].Rows[j]["cuit"].ToString();
                        //string tmpDNI = tmpCuit.Substring(2, tmpCuit.Length - 3);
                        //int intDni = int.Parse(myDataSet.Tables[0].Rows[j]["dni"].ToString());
                        //if (intDni == dniParam)
                        //{
                            //strCUIT = myDataSet.Tables[0].Rows[j]["cuit"].ToString();
                            strNombre = myDataSet.Tables[0].Rows[j]["nombre"].ToString();
                            DataRow myNewRow;
                            myNewRow = myDataTable.NewRow();
                            myNewRow["nombre"] = strNombre;
                            myDataTable.Rows.Add(myNewRow);

                            //corte = false;
                        //}
                    }
                }



                oConnection.Close();
            }
            catch (Exception e)
            { }
            return myDataTable;
            //return myDataSet.Tables[0];

        }

        #endregion

        #region Métodos Privados
        #endregion

    }
}
