using System;
using System.Data;
using System.Data.Odbc;

namespace ar.com.TiempoyGestion.BackEnd.ImportadorFox.Dal
{
    class FoxDal
    {
        private string strConnectionString;
		private OdbcConnection oConnection;

		protected FoxDal(string strOdbcFox)
		{
            strConnectionString = strOdbcFox;
		}

		public string connectionString
		{
			get
			{
				if (strConnectionString == "")
					throw new Exception();
				return strConnectionString;
			}
            set
            {
                strConnectionString = value;
            }
			
		}

		public OdbcConnection OpenConnection()
		{

			if (oConnection == null)
				oConnection = new OdbcConnection(connectionString);
			else if (oConnection.State == ConnectionState.Closed || oConnection.ConnectionString == "")
				oConnection.ConnectionString = connectionString;
			try
			{
				if (oConnection.State != ConnectionState.Open)
				{
					oConnection.Open();
			
					if (oConnection.State != ConnectionState.Open)
						throw new Exception();
				}
			}
			catch(Exception e) 
			{
				Console.WriteLine(e.Message + Environment.NewLine + e.StackTrace);
			}
			
			return oConnection;

		}

		public void CloseConnection()
		{
			if (oConnection != null && oConnection.State != ConnectionState.Closed)
				oConnection.Close();
			oConnection.Dispose();

		}

		public OdbcTransaction NewTransaction()
		{
			return OpenConnection().BeginTransaction();
		}
	
		public DataSet EjecutarDataSet(string lQuery, string lTableName)
		{
			DataSet dsSalida = new DataSet();
			try
			{
				OdbcDataAdapter oAdapter = new OdbcDataAdapter(lQuery, this.OpenConnection());
				oAdapter.Fill(dsSalida, lTableName);
				this.CloseConnection();
			}
			catch
			{
				throw;
			}

			return dsSalida;

		}

		public IDataReader EjecutarDataReader(string lQuery)
		{
			OdbcDataReader drSalida = null;
			try
			{
				OdbcCommand oCommand = new OdbcCommand(lQuery, this.OpenConnection());
				drSalida = oCommand.ExecuteReader(CommandBehavior.CloseConnection);
			}
			catch
			{
				throw;
			}

			return drSalida;

		}

		public int EjecutarComando(string lComando)
		{
			int intResult = 0;
			try
			{
				OdbcCommand oCommand = new OdbcCommand(lComando, this.OpenConnection());
				intResult = oCommand.ExecuteNonQuery();
			}
			catch
			{
				throw;
			}

			return intResult;

		}

		public string Traduce(Object lData)
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
				default:
					strSalida = "null";
					break;

			}

			return strSalida;
		}
    }
}
