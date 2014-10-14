using System;
using System.Data;
using System.Data.Odbc;
using System.Diagnostics;
using ar.com.TiempoyGestion.BackEnd.BackServices.Services;

namespace ar.com.TiempoyGestion.BackEnd.BackServices.Dal
{
	/// <summary>
	/// Summary description for GenericDal.
	/// </summary>
	public class GenericDal
	{
		private static string strConnectionString;
        private static string strConnectionStringPadron;
		private OdbcConnection oConnection;

		protected GenericDal()
		{
			if (strConnectionString == null || strConnectionString == "")
			{
				RegistryReader myRegReader = new RegistryReader();
                myRegReader.path = @"Software\TiempoyGestion\Intranet";
				strConnectionString = myRegReader.getStringValue("ConnectionString",false);
                strConnectionStringPadron = myRegReader.getStringValue("ConnectionStringPadron", false);
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

        public static string connectionStringPadron
        {
            get
            {
                if (strConnectionStringPadron == "")
                    throw new Exception();
                return strConnectionStringPadron;
            }
        }


        public OdbcConnection OpenConnection()
		{
            //if (intDb == 0)
            //{
                if (oConnection == null)
                    oConnection = new OdbcConnection(connectionString);
                else if (oConnection.State == ConnectionState.Closed || oConnection.ConnectionString == "")
                    oConnection.ConnectionString = connectionString;
            /*}
            else
            {
                if (oConnection == null)
                    oConnection = new OdbcConnection(connectionStringPadron);
                else if (oConnection.State == ConnectionState.Closed || oConnection.ConnectionString == "")
                    oConnection.ConnectionString = connectionStringPadron;
            }*/

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
                EventLog.WriteEntry("TyG-GenericDal", "Error al abrir conexión con DB: "+ e.Message, EventLogEntryType.Error);
			}
			return oConnection;
		}


        public OdbcConnection OpenConnection(bool padron)
        {
            if (oConnection == null)
                oConnection = new OdbcConnection(connectionStringPadron);
            else if (oConnection.State == ConnectionState.Closed || oConnection.ConnectionString == "")
                oConnection.ConnectionString = connectionStringPadron;
            try
            {
                if (oConnection.State != ConnectionState.Open)
                {
                    oConnection.Open();

                    if (oConnection.State != ConnectionState.Open)
                        throw new Exception();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + Environment.NewLine + e.StackTrace);
                EventLog.WriteEntry("TyG-GenericDal", "Error al abrir conexión con DB: " + e.Message, EventLogEntryType.Error);
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
				oConnection = this.OpenConnection();
                OdbcCommand oCommand = new OdbcCommand(lQuery, oConnection);
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
