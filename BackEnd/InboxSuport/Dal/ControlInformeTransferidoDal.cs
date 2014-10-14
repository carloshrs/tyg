using System;
using System.Data;
using System.Text;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.App;

namespace ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal
{
	/// <summary>
	/// Summary description for ControlPersonasDal.
	/// </summary>
	public class ControlInformeTransferidoDal : GenericDal
	{
		public ControlInformeTransferidoDal() {	}

        public static DataTable ControlInformesTransferidos(int lid)
		{
			StringBuilder strQuery = new StringBuilder(512);
			DataTable dtSalida = null;

            strQuery.Append("SELECT BE.FechaCarga as Fecha, BE.DescripcionInf "); 
            strQuery.Append(" FROM bandejaentrada BE ");
            strQuery.Append(" INNER JOIN informepropiedadtransferido T ON T.idEncabezado = BE.idEncabezado ");
            strQuery.Append(" WHERE ");
            strQuery.Append(" T.idEncabezadoPadre = " + StaticDal.Traduce(lid));
            strQuery.Append(" AND NOT BE.estado=4 ");
            
			try
			{
				dtSalida = StaticDal.EjecutarDataSet(strQuery.ToString(), "Matriculas").Tables["Matriculas"];
			}
			catch
			{
				throw;
			}

			return dtSalida;
		}



        public static DataTable ControlVieneTransferidoInforme(int lid)
        {
            StringBuilder strQuery = new StringBuilder(512);
            DataTable dtSalida = null;

            strQuery.Append("SELECT BE.FechaCarga as Fecha, BE.DescripcionInf ");
            strQuery.Append(" FROM bandejaentrada BE ");
            strQuery.Append(" INNER JOIN informepropiedadtransferido T ON T.idEncabezadoPadre = BE.idEncabezado ");
            strQuery.Append(" WHERE ");
            strQuery.Append(" T.idEncabezado = " + StaticDal.Traduce(lid));
            strQuery.Append(" AND NOT BE.estado=4 ");

            try
            {
                dtSalida = StaticDal.EjecutarDataSet(strQuery.ToString(), "Matriculas").Tables["Matriculas"];
            }
            catch
            {
                throw;
            }

            return dtSalida;
        }

	}
}
