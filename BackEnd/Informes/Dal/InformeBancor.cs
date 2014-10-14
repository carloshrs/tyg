using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Odbc;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;
using System.Data;

namespace ar.com.TiempoyGestion.BackEnd.Informes.Dal
{
    public class InformeBancorApp : GenericDal
    {

        #region Atributos y Contructores
        public InformeBancorApp() : base()
		{		}

		#endregion


        public DataTable ListaInformesBancor(int tipo, string Estado, String FechaDesde, String FechaHasta, int Entregado, int idGrupo)
        {
            if (FechaDesde != "")
                FechaDesde = "'" + FechaDesde + " 00:00:00.000'";
            else
            {
                FechaDesde = DateTime.Today.AddMonths(-3).ToShortDateString();
                FechaDesde = "'" + FechaDesde + " 00:00:00.000'";
            }

            if (FechaHasta != "")
                FechaHasta = "'" + FechaHasta + " 23:59:59.999'";
            else
            {
                FechaHasta = DateTime.Today.ToShortDateString();
                FechaHasta = "'" + FechaHasta + " 23:59:59.999'";
            }

            OdbcConnection oConnection = this.OpenConnection();
            DataSet ds = new DataSet();
            String strSQL = "SELECT B.idEncabezado, B.FechaCarga, (isnull(b.apellido,'') + ', ' + isnull(B.nombre,'')) as nombre, B.documento, " +
                "TV.descripcion AS TipoVivienda, D.descripcion AS DestinoVivienda, e.descripcion AS EstadoConservacion, " +
                "HV.descripcion AS HabitaVive, R.descripcion AS Resultado, AB.Observaciones " +
                "FROM bandejaentrada B " +
                "INNER JOIN ambientalbancor AB ON B.idEncabezado=AB.idInforme ";
            if (idGrupo != 0)
                strSQL = strSQL + "INNER JOIN informesCambioEstado ICE ON B.idEncabezado=ICE.idInforme ";
            strSQL = strSQL + "LEFT OUTER JOIN campo TV ON AB.idTipoVivienda = TV.id " +
                "LEFT OUTER JOIN campo D ON AB.idDestino = D.id " +
                "LEFT OUTER JOIN campo e ON AB.idEstado = e.id " +
                "LEFT OUTER JOIN campo HV ON AB.idInteresado = HV.id " +
                "LEFT OUTER JOIN campo R ON AB.idResultado = R.id ";

            strSQL = strSQL + "WHERE 1=1 " +
                " AND B.idTipoInforme = " + tipo + 
                " AND B.Estado = " + Estado +
                " AND B.Entregado = " + Entregado + 
                " AND B.FechaCarga BETWEEN " + FechaDesde + " AND " + FechaHasta;
            if (idGrupo != 0)
                strSQL = strSQL + " AND ICE.idTipoGrupo=" + idGrupo;
            //String strSQLSP = "execute_query '" + strSQL + "', 'FechaCarga DESC', 1, 1000, 10";

            OdbcDataAdapter myConsulta = new OdbcDataAdapter(strSQL, oConnection);
            myConsulta.Fill(ds);
            try
            {

                oConnection.Close();
            }
            catch { }

            return ds.Tables[0];

        }
    }
}
