using System;
using System.Data;
using System.Text;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;

namespace ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal
{
	/// <summary>
	/// Summary description for ControlEmpresasDal.
	/// </summary>
	public class ControlEmpresasDal: GenericDal
	{
		public ControlEmpresasDal() {	}

		public static DataTable ControlarCUIT(string lCUIT)
		{
			StringBuilder strQuery = new StringBuilder(512);
			DataTable dtSalida = null;
			strQuery.Append("Select * ");
			strQuery.Append(" From Empresas ");
			strQuery.Append(" Where CUIT = " + StaticDal.Traduce(lCUIT));
			strQuery.Append(" Order By NombreFantasia ");

			try
			{
				dtSalida = StaticDal.EjecutarDataSet(strQuery.ToString(), "Empresas").Tables["Empresas"];
			}
			catch
			{
				throw;
			}
			return dtSalida;

		}

		public static DataTable ControlarNombre(string lNombre)
		{
			StringBuilder strQuery = new StringBuilder(512);
			DataTable dtSalida = null;
			strQuery.Append("Select * ");
			strQuery.Append(" From Empresas ");
			strQuery.Append(" Where NombreFantasia = " + StaticDal.Traduce(lNombre));
			strQuery.Append(" Order By NombreFantasia ");

			try
			{
				dtSalida = StaticDal.EjecutarDataSet(strQuery.ToString(), "Empresas").Tables["Empresas"];
			}
			catch
			{
				throw;
			}
			return dtSalida;

		}


	}
}
