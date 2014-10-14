using System;
using System.Data;
using System.Text;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;

namespace ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal
{
	/// <summary>
	/// Summary description for ControlPersonasDal.
	/// </summary>
	public class ControlPersonasDal : GenericDal
	{
		public ControlPersonasDal() {	}

		public static DataTable ControlarDocumento(string lNumero)
		{
			StringBuilder strQuery = new StringBuilder(512);
			DataTable dtSalida = null;
			strQuery.Append("Select * ");
			strQuery.Append(" From Personas ");
			strQuery.Append(" Where DNI = " + StaticDal.Traduce(lNumero));
			strQuery.Append(" Order By Apellido, Nombre ");

			try
			{
				dtSalida = StaticDal.EjecutarDataSet(strQuery.ToString(), "Personas").Tables["Personas"];
			}
			catch
			{
				throw;
			}

			return dtSalida;

		}

        public static DataTable ControlarDocumento(int tipodoc, string lNumero)
        {
            StringBuilder strQuery = new StringBuilder(512);
            DataTable dtSalida = null;
            strQuery.Append("Select * ");
            strQuery.Append(" From Personas ");
            strQuery.Append(" Where DNI = " + StaticDal.Traduce(lNumero));
            strQuery.Append(" And Tipodni = " + StaticDal.Traduce(tipodoc));
            strQuery.Append(" Order By Apellido, Nombre ");

            try
            {
                dtSalida = StaticDal.EjecutarDataSet(strQuery.ToString(), "Personas").Tables["Personas"];
            }
            catch
            {
                throw;
            }

            return dtSalida;

        }

	}
}
