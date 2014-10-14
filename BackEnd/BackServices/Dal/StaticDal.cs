using System;
using System.Configuration;
using System.Data;
using System.Data.Odbc;
using Microsoft.SqlServer.Server;
//Data.Odbc
using System.Globalization;
using ar.com.TiempoyGestion.BackEnd.BackServices.Services;

namespace ar.com.TiempoyGestion.BackEnd.BackServices.Dal
{
	/// <summary>
	/// Summary description for GenericDal.
	/// </summary>
	public class StaticDal
	{
		private static string strConnectionString;

		static StaticDal()
		{
			if (strConnectionString == null || strConnectionString == "")
			{
				RegistryReader myRegReader = new RegistryReader();
                myRegReader.path = @"Software\TiempoyGestion\Intranet";
				strConnectionString = myRegReader.getStringValue("ConnectionString",false);
                //"dsn = tiempoygestionSQL; uid = sa; pwd = r3d3f1n3;";
                //strConnectionString = "DRIVER={SQL Server};SERVER=SERVIDOR;UID=sa;PWD=r3d3f1n3;DATABASE=tiempoygestion;";
			}

		}

		public static string connectionString
		{
			get
			{
				if (strConnectionString == "")
					throw new Exception();
				return strConnectionString;
			}
			
		}

		public static DataSet EjecutarDataSet(string lQuery, string lTableName)
		{
			DataSet dsSalida = new DataSet();
			try
			{
				OdbcConnection oCon = new OdbcConnection(strConnectionString);
				oCon.Open();
				OdbcDataAdapter oAdapter = new OdbcDataAdapter(lQuery, oCon);
				oAdapter.Fill(dsSalida, lTableName);
				oCon.Close();
				oCon.Dispose();
			}
			catch
			{
				throw;
			}

			return dsSalida;

		}

		public static IDataReader EjecutarDataReader(string lQuery)
		{
			OdbcDataReader drSalida = null;
			try
			{
				OdbcConnection oCon = new OdbcConnection(strConnectionString);
				oCon.Open();
				OdbcCommand oCommand = new OdbcCommand(lQuery, oCon);
				drSalida = oCommand.ExecuteReader(CommandBehavior.CloseConnection);
			}
			catch (Exception e)
			{
				throw;
			}

			return drSalida;

		}

		public static int EjecutarComando(string lComando)
		{
			int intResult = 0;
			try
			{
				OdbcConnection oCon = new OdbcConnection(strConnectionString);
				oCon.Open();
				OdbcCommand oCommand = new OdbcCommand(lComando, oCon);
				intResult = oCommand.ExecuteNonQuery();
				oCon.Close();
				oCon.Dispose();
			}
			catch (Exception e)
			{
				throw;
			}

			return intResult;

		}

		public static string Traduce(Object lData)
		{
			string strSalida;
			switch(lData.GetType().Name)
			{
				case "Int32":
				case "Int16":
				case "Byte":
					strSalida = Convert.ToInt32(lData).ToString();
					break;
				case "Single": 
					if (Convert.ToSingle(lData) >= 0)
						strSalida = Convert.ToSingle(lData).ToString();
					else
						strSalida = "null";
					break;
				case "String":
					if (Convert.ToString(lData) != "")
						strSalida = "'" + Convert.ToString(lData) + "'";
					else
						strSalida = "null";
					break;
				case "Boolean":
					if (Convert.ToBoolean(lData))
						strSalida = "1";
					else
						strSalida = "0";
					break;
				case "DateTime":
					strSalida = ((DateTime)lData).ToString("yyyy-MM-dd HH:mm:ss");
					if (strSalida != "")
						strSalida = "'" + strSalida + "'";
					else
						strSalida = "null";
					break;
				default:
					strSalida = "null";
					break;

			}

			return strSalida;
		}
	}
}
