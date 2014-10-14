using System;
using System.Data;
using System.Data.Odbc;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;

namespace ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal
{
	/// <summary>
	/// Summary description for TipoDocumentoDal.
	/// </summary>
	public class TipoDocumentoDal : GenericDal
	{
		#region Atributos y Contructores
		private int intId;
		private string strDescripcion;
		
		public TipoDocumentoDal() : base()
		{		}

		#endregion

		#region Propiedades

		public int Id
		{
			get
			{
				return intId;
			}
			set
			{
				intId = value;
			}
		}

		public string Descripcion
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

		#endregion

		#region Métodos Publicos
		public bool Crear()
		{
			OdbcConnection oConnection = OpenConnection();
			String strSQL = "Insert into TipoDocumento (Descripcion) values ('" + strDescripcion + "');";
			try
			{
				OdbcCommand	myCommand = new OdbcCommand(strSQL, oConnection);
				myCommand.ExecuteNonQuery();
				oConnection.Close();
			} 			
			catch {
				return false;
			}
			return true;
		}

		public bool Modificar(int lid)
		{
			OdbcConnection oConnection = OpenConnection();
			String strSQL = "Update TipoDocumento set Descripcion ='" + strDescripcion + "' where IdTipoDocumento =" + lid + ";";
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

		public bool Borrar()
		{

			OdbcConnection oConnection = OpenConnection();
			String strSQL = "Delete from TipoDocumento where IdTipoDocumento =" + Id + ";";
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

		public void Cargar(int Id)
		{
			OdbcConnection oConnection = OpenConnection();
			String strSql = "select * from TipoDocumento where idTipoDocumento=" + Id.ToString();
			//try
			{
				OdbcDataAdapter myConsulta = new OdbcDataAdapter(strSql, oConnection);
				DataSet myDataSet = new DataSet();
				myConsulta.Fill(myDataSet);
				intId = int.Parse(myDataSet.Tables[0].Rows[0]["idTipoDocumento"].ToString());
				strDescripcion = myDataSet.Tables[0].Rows[0]["Descripcion"].ToString();
				
				oConnection.Close();
			} 			
		//	catch {}
		}

		public DataTable TraerDatos()
		{
			
			OdbcConnection oConnection = OpenConnection();
			DataSet ds = new DataSet();
			OdbcDataAdapter myConsulta = new OdbcDataAdapter("select * from TipoDocumento", oConnection);
			myConsulta.Fill(ds);
			try
			{
				
				oConnection.Close();
			} 			
			catch {}

			return ds.Tables[0];

		}

		#endregion

		#region Métodos Privados
		#endregion

	}
}
