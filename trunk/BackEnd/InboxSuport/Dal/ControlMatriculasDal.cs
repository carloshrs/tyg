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
	public class ControlMatriculasDal : GenericDal
	{
		public ControlMatriculasDal() {	}

		public static DataTable ControlarMatricula(int lid, int lTipoInforme, int lTipoPropiedad, int lProvincia, string lMatricula, string lTomo, string lFolio, string lAno)
		{
			StringBuilder strQuery = new StringBuilder(512);
			DataTable dtSalida = null;

            strQuery.Append("SELECT BE.FechaCarga as Fecha, C.RazonSocial as Cliente, C.idCliente, BE.PROPMatricula "); 
            strQuery.Append(" FROM bandejaentrada BE ");
            strQuery.Append(" INNER JOIN clientes C ON C.idCliente = BE.idCliente ");
            strQuery.Append(" WHERE ");
            if (lTipoPropiedad == 2) // Dominio
            {
                strQuery.Append(" (BE.PROPFolio= " + StaticDal.Traduce(lFolio) + " AND BE.PROPAno= " + StaticDal.Traduce(lAno) + ") ");
            }
            else // Legajo especial
            {
                strQuery.Append(" (BE.PROPMatricula = " + StaticDal.Traduce(lMatricula) + " AND BE.PROPFolio= " + StaticDal.Traduce(lFolio) + ") " );
            }
            strQuery.Append(" AND NOT BE.idEncabezado = " + StaticDal.Traduce(lid));
            strQuery.Append(" AND BE.PROPTipo=" + StaticDal.Traduce(lTipoPropiedad));
            
            if (lTipoInforme == 1)
                strQuery.Append(" AND BE.idTipoInforme=" + StaticDal.Traduce(lTipoInforme));
            else
                strQuery.Append(" AND BE.PROPProvincia=" + StaticDal.Traduce(lProvincia));

            strQuery.Append(" AND NOT BE.estado=4 ");
            strQuery.Append(" ORDER BY C.RazonSocial, BE.FechaCarga DESC ");
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


        public static DataTable ControlarMatricula(int lid, int lTipoInforme, int lTipoPropiedad, int lProvincia, string lMatricula)
		{
			StringBuilder strQuery = new StringBuilder(512);
			DataTable dtSalida = null;

            strQuery.Append("Select BE.FechaCarga AS Fecha, C.RazonSocial as Cliente, C.idCliente ");
			strQuery.Append(" FROM bandejaentrada BE ");
            strQuery.Append(" INNER JOIN clientes C ON C.idCliente = BE.idCliente ");
			strQuery.Append(" WHERE BE.PROPMatricula = " + StaticDal.Traduce(lMatricula));
			strQuery.Append(" AND NOT BE.idEncabezado = " + StaticDal.Traduce(lid));
			strQuery.Append(" AND BE.PROPTipo=" + StaticDal.Traduce(lTipoPropiedad));

            if (lTipoInforme == 1)
                strQuery.Append(" AND BE.idTipoInforme=" + StaticDal.Traduce(lTipoInforme));
            else
                strQuery.Append(" AND BE.PROPProvincia=" + StaticDal.Traduce(lProvincia));

            strQuery.Append(" AND NOT BE.estado=4 ");
			strQuery.Append(" Order By C.RazonSocial, BE.FechaCarga DESC");

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


        public static DataTable ControlarMatriculaSolicitadaExistente(int lid, int idCliente, int lTipoInforme, int lTipoPropiedad, int lProvincia, string lMatricula, string lFolio, string lAno)
        {
            StringBuilder strQuery = new StringBuilder(512);
            DataTable dtSalida = null;

            strQuery.Append("SELECT BE.idEncabezado, BE.FechaCarga AS Fecha, BE.usuariocliente, e.nombreestado ");
            strQuery.Append("FROM bandejaentrada BE  ");
            strQuery.Append("INNER JOIN estadoinformes e ON BE.estado = e.idEstado ");
            strQuery.Append("WHERE (IsNumeric(BE.usuariocliente) = 0 OR BE.usuariocliente ='-' OR BE.usuariocliente ='.') ");
            if (lTipoPropiedad == 1)
                strQuery.Append(" AND BE.PROPMatricula = " + StaticDal.Traduce(lMatricula));
            if (lTipoPropiedad == 2)
                strQuery.Append(" AND BE.PROPFolio = " + StaticDal.Traduce(lFolio) + " AND BE.PROPAno = " + StaticDal.Traduce(lAno));
            if (lTipoPropiedad == 3)
                strQuery.Append(" AND BE.PROPMatricula = " + StaticDal.Traduce(lMatricula) + " AND BE.PROPFolio = " + StaticDal.Traduce(lFolio));

            if(lid != 0)
                strQuery.Append(" AND NOT BE.idEncabezado = " + StaticDal.Traduce(lid));
            strQuery.Append(" AND BE.PROPTipo=" + StaticDal.Traduce(lTipoPropiedad));
            
            if (lTipoInforme == 1)
                strQuery.Append(" AND BE.idTipoInforme=" + StaticDal.Traduce(lTipoInforme));
            else
                strQuery.Append(" AND BE.PROPProvincia=" + StaticDal.Traduce(lProvincia));
            
            strQuery.Append(" AND NOT BE.estado=4 ");
            strQuery.Append(" AND BE.idCliente=" + StaticDal.Traduce(idCliente));

            strQuery.Append(" UNION ");

            strQuery.Append(" SELECT BE.idEncabezado, BE.FechaCarga AS Fecha, (U.Nombre +' '+ U.Apellido) as usuariocliente, e.nombreestado ");
            strQuery.Append(" FROM bandejaentrada BE INNER JOIN usuarios u ON BE.usuariocliente = u.idUsuario ");
            strQuery.Append(" INNER JOIN estadoinformes e ON BE.estado = e.idEstado ");
            strQuery.Append(" WHERE IsNumeric(BE.usuariocliente) = 1  AND NOT BE.usuariocliente = '.' AND NOT BE.usuariocliente ='-' ");
            if (lTipoPropiedad == 1)
                strQuery.Append(" AND BE.PROPMatricula = " + StaticDal.Traduce(lMatricula));
            if (lTipoPropiedad == 2)
                strQuery.Append(" AND BE.PROPFolio = " + StaticDal.Traduce(lFolio) + " AND BE.PROPAno = " + StaticDal.Traduce(lAno));
            if (lTipoPropiedad == 3)
                strQuery.Append(" AND BE.PROPMatricula = " + StaticDal.Traduce(lMatricula) + " AND BE.PROPFolio = " + StaticDal.Traduce(lFolio));

            if(lid != 0)
                strQuery.Append(" AND NOT BE.idEncabezado = " + StaticDal.Traduce(lid));
            strQuery.Append(" AND BE.PROPTipo=" + StaticDal.Traduce(lTipoPropiedad));

            if (lTipoInforme == 1)
                strQuery.Append(" AND BE.idTipoInforme=" + StaticDal.Traduce(lTipoInforme));
            else
                strQuery.Append(" AND BE.PROPProvincia=" + StaticDal.Traduce(lProvincia));

            strQuery.Append(" AND NOT BE.estado=4 ");
            strQuery.Append(" AND BE.idCliente=" + StaticDal.Traduce(idCliente));

            strQuery.Append(" ORDER BY BE.FechaCarga DESC");

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
