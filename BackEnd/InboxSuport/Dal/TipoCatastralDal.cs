using System;
using System.Data;
using System.Data.Odbc;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;

namespace ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal
{
	/// <summary>
	/// Summary description for TipoCatastralDal.
	/// </summary>
	public class TipoCatastralDal : GenericDal
	{
		#region Atributos y Contructores
		private int intId;
		private string strDescripcion;
		
		public TipoCatastralDal() : base()
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
			String strSQL = "Insert into TipoCatastral (Descripcion) values ('" + strDescripcion + "');";
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
			String strSQL = "Update TipoCatastral set Descripcion ='" + strDescripcion + "' where IdTipoCatastral =" + lid + ";";
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
			String strSQL = "Delete from TipoCatastral where IdTipoCatastral =" + Id + ";";
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
			String strSql = "select * from TipoCatastral where idTipoCatastral=" + Id.ToString();
			//try
			{
				OdbcDataAdapter myConsulta = new OdbcDataAdapter(strSql, oConnection);
				DataSet myDataSet = new DataSet();
				myConsulta.Fill(myDataSet);
				intId = int.Parse(myDataSet.Tables[0].Rows[0]["idTipoCatastral"].ToString());
				strDescripcion = myDataSet.Tables[0].Rows[0]["Descripcion"].ToString();
				
				oConnection.Close();
			} 			
		//	catch {}
		}

		public DataTable TraerDatos()
		{
			
			OdbcConnection oConnection = OpenConnection();
			DataSet ds = new DataSet();
			OdbcDataAdapter myConsulta = new OdbcDataAdapter("select * from TipoCatastral", oConnection);
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
