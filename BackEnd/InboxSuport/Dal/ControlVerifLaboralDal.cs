using System;
using System.Data;
using System.Text;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;

namespace ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal
{
	/// <summary>
	/// Summary description for ControlPersonasDal.
	/// </summary>
	public class ControlVerifLaboralDal : GenericDal
	{
		public ControlVerifLaboralDal() {	}

        public static DataTable ControlarSolicitudesDNI(int lid, string dni)
		{
			StringBuilder strQuery = new StringBuilder(512);
			DataTable dtSalida = null;

            strQuery.Append("SELECT BE.FechaCarga as Fecha, C.RazonSocial as Cliente, C.idCliente, BE.nombre, BE.apellido " +
            "FROM bandejaentrada BE " +
            " INNER JOIN clientes C ON C.idCliente = BE.idCliente " + 
            " WHERE " +
            " NOT BE.idEncabezado = " + lid +
            " AND BE.documento='" + dni + "' " +
            " AND NOT BE.estado=4 " + 
            " AND idTipoInforme=6 " + 
            " ORDER BY C.RazonSocial, BE.FechaCarga DESC ");
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
