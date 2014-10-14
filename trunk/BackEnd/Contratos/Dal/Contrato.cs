using System;
using System.Data;
using System.Data.Odbc;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;

namespace ar.com.TiempoyGestion.BackEnd.Contratos.Dal
{
	/// <summary>
	/// Summary description for ClienteDal.
	/// </summary>
	public class ContratoAPP : GenericDal
	{
		#region Atributos y Contructores
			
		private int intIdContrato;
		private int intIdTipo;
		private String strNumero;
		private String strDescripcion;
		private String strFechaInicio;
		private String strFechaFin;
		private int intIdUsuario;
		private String strUsuarioCliente;
		private int intIdCliente;
		private String strTipoContrato;

		public ContratoAPP() : base()
		{		}

		#endregion

		#region Propiedades
		public int IdContrato
		{
			get
			{
				return intIdContrato;
			}
			set
			{
				intIdContrato = value;
			}
		}
		public int IdTipo
		{
			get
			{
				return intIdTipo;
			}
			set
			{
				intIdTipo = value;
			}
		}
		public int IdCliente
		{
			get
			{
				return intIdCliente;
			}
			set
			{
				intIdCliente = value;
			}
		}
		public int IdUsuario
		{
			get
			{
				return intIdUsuario;
			}
			set
			{
				intIdUsuario = value;
			}
		}
		public String Numero
		{
			get
			{
				return strNumero;
			}
			set
			{
				strNumero = value;
			}
		}

		public String UsuarioCliente
		{
			get
			{
				return strUsuarioCliente;
			}
			set
			{
				strUsuarioCliente = value;
			}
		}

		public String Descripcion
		{
			get
			{
				return strDescripcion;
			}
			set
			{
				strDescripcion = value;
			}
		}

		public String FechaInicio
		{
			get
			{
				return strFechaInicio;
			}
			set
			{
				strFechaInicio = value;
			}
		}

		public String FechaFin
		{
			get
			{
				return strFechaFin;
			}
			set
			{
				strFechaFin = value;
			}
		}
		public String TipoContrato
		{
			get
			{
				return strTipoContrato;
			}
			set
			{
				strTipoContrato = value;
			}
		}
		

		#endregion

		#region Métodos Publicos

		

		public int Crear()
		{
			//string[] fecha = strFechaInicio.Split("/".ToCharArray());
            string ConvFechaInicio = strFechaInicio; // fecha[2] + "/" + fecha[1] + "/" + fecha[0];

			//fecha = strFechaFin.Split("/".ToCharArray());
            string ConvFechaFin = strFechaFin; // fecha[2] + "/" + fecha[1] + "/" + fecha[0];

			OdbcConnection oConnection = this.OpenConnection();
			String strSQL = "Insert into Contratos (idTipo, idCliente, idUsuario, UsuarioCliente, FechaInicio, FechaFin, Descripcion, Numero) ";

			strSQL = strSQL  + " values (" + intIdTipo + "," + intIdCliente + "," + intIdUsuario + ",'" + strUsuarioCliente + "','" + ConvFechaInicio + "','" + ConvFechaFin + "','" + strDescripcion + "','" + strNumero + "')";

			String strMaxID = "SELECT MAX(idContrato) as MaxId FROM Contratos";
			int MaxID = 0;

			try
			{
				OdbcCommand	myCommand = new OdbcCommand(strSQL, oConnection);
				myCommand.ExecuteNonQuery();

				MaxID = ObtenerMaxID(strMaxID, oConnection); 

				oConnection.Close();
			} 			
			catch (Exception e)
			{	
				string p = e.Message;
				return -1;
			}
			return MaxID;
		}


		private int ObtenerMaxID(string strMaxID, OdbcConnection oConnection)
		{
			DataSet ds = new DataSet();
			OdbcDataAdapter myConsulta = new OdbcDataAdapter(strMaxID, oConnection);
			myConsulta.Fill(ds);
			int MaxID = 0;
			try
			{
				MaxID = int.Parse(ds.Tables[0].Rows[0]["Maxid"].ToString());
			} 			
			catch 
			{
				return 0;
			}
			return MaxID;
		}

		
		public bool Cargar(int idContrato)
		{
			
			OdbcConnection oConnection = this.OpenConnection();
			DataSet ds = new DataSet();
			String strSQL = "SELECT C.idContrato, Numero, C.Descripcion, C.idCliente, idTipo, idUsuario, fechainicio, fechafin, T.Descripcion as TIDescripcion ";
			strSQL = strSQL + " FROM Contratos C, tipoContrato T ";
			strSQL = strSQL + " WHERE C.idTipo = T.idTipoContrato ";
			strSQL = strSQL + " AND idContrato = " + idContrato.ToString();
			OdbcDataAdapter myConsulta = new OdbcDataAdapter(strSQL, oConnection);
			myConsulta.Fill(ds);
			try
			{
				oConnection.Close();
			} 			
			catch {
				return false;	
			}

			intIdContrato = int.Parse(ds.Tables[0].Rows[0]["IdContrato"].ToString()); 
			intIdTipo = int.Parse(ds.Tables[0].Rows[0]["IdTipo"].ToString());
			intIdCliente = int.Parse(ds.Tables[0].Rows[0]["idCliente"].ToString());
			intIdUsuario = int.Parse(ds.Tables[0].Rows[0]["idUsuario"].ToString());
			strFechaInicio = ds.Tables[0].Rows[0]["FechaInicio"].ToString();
			strFechaFin= ds.Tables[0].Rows[0]["FechaFin"].ToString();
			strNumero= ds.Tables[0].Rows[0]["Numero"].ToString();
			strDescripcion = ds.Tables[0].Rows[0]["Descripcion"].ToString();
			strTipoContrato = ds.Tables[0].Rows[0]["TIDescripcion"].ToString();
			return true;	
	
		}

		public bool Eliminar(int idContrato)
		{
			OdbcConnection oConnection = this.OpenConnection();
			String strSQL = "Delete from Contratos WHERE idContrato = " + idContrato.ToString();
			String strSQLPersonas = "Delete from PersonasContrato WHERE idContrato = " + idContrato.ToString();
			try
			{
				OdbcCommand	myCommand = new OdbcCommand(strSQLPersonas, oConnection);
				myCommand.ExecuteNonQuery();
				myCommand = new OdbcCommand(strSQL, oConnection);
				myCommand.ExecuteNonQuery();
				
				oConnection.Close();
			} 			
			catch 
			{
				return false;
			}
			return true;
		}

		public bool EliminarHistorico(int id)
		{
			OdbcConnection oConnection = this.OpenConnection();
			String strSQL = "Delete from HistorialContratos WHERE id = " + id.ToString();
			try
			{
				OdbcCommand	myCommand = new OdbcCommand(strSQL, oConnection);
				myCommand.ExecuteNonQuery();
				
				oConnection.Close();
			} 			
			catch 
			{
				return false;
			}
			return true;
		}

		public bool CrearHistorico(string Observaciones, int idContrato, int IdUsuario)
		{

			OdbcConnection oConnection = this.OpenConnection();
			String strSQL = "Insert into HistorialContratos (idContrato, idUsuario, Fecha, Descripcion) ";
			strSQL = strSQL  + " values (" + idContrato + "," + IdUsuario + ",getdate(), '" + Observaciones + "')";

			try
			{
				OdbcCommand	myCommand = new OdbcCommand(strSQL, oConnection);
				myCommand.ExecuteNonQuery();

				oConnection.Close();
			} 			
			catch (Exception e)
			{	
				string p = e.Message;
				return false;
			}
			return true;
		}

		
		public bool CargarHistorico(int id, ref string fecha, ref string observaciones)
		{
			OdbcConnection oConnection = this.OpenConnection();
			DataSet ds = new DataSet();
			String strSQL = "SELECT descripcion, DATE_FORMAT(fecha, '%d/%m/%Y') as Fecha ";
			strSQL = strSQL + " FROM HistorialContratos ";
			strSQL = strSQL + " WHERE id = " + id.ToString();
			OdbcDataAdapter myConsulta = new OdbcDataAdapter(strSQL, oConnection);
			myConsulta.Fill(ds);
			try
			{
				oConnection.Close();
			} 			
			catch 
			{
				return false;	
			}

			fecha= ds.Tables[0].Rows[0]["Fecha"].ToString();
			observaciones = ds.Tables[0].Rows[0]["Descripcion"].ToString();
			return true;	
	
		}

		public bool ModificarHistorico(int id, string Observaciones, int idContrato, int Usuario)
		{
			OdbcConnection oConnection = this.OpenConnection();
			DataSet ds = new DataSet();
			String strSQL = "UPDATE HistorialContratos SET ";
			strSQL = strSQL  + "idUsuario = " + Usuario + ", Descripcion = '" + Observaciones + "' ";
			strSQL = strSQL  + " WHERE id =  " + id.ToString();
			try
			{
				OdbcCommand	myCommand = new OdbcCommand(strSQL, oConnection);
				myCommand.ExecuteNonQuery();

				oConnection.Close();
			} 			
			catch (Exception e)
			{	
				string p = e.Message;
				return false;
			}
			return true;
		}
		#endregion

		#region Métodos Privados
		#endregion


	}
}
