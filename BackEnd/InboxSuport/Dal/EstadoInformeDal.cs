using System;
using System.Data;
using System.Data.Odbc;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;

namespace ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal
{
	/// <summary>
	/// Summary description for EstadoInformeDal.
	/// </summary>
	public class EstadoInformeDal : GenericDal
	{
		#region Atributos y Contructores
		private int intId;
		private string strNombre;
		private string strDescripcion;
		
		public EstadoInformeDal() : base()
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

		public string Nombre
		{
			get
			{
				return strNombre;
			}
			set
			{
				strNombre = value;
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
			String strSQL = "Insert into EstadoInformes (NombreEstado, DescripcionEstado) values ('" + strNombre + "', '" + strDescripcion + "');";
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
			String strSQL = "Update EstadoInformes set NombreEstado = '" + strNombre + "', DescripcionEstado ='" + strDescripcion + "' where IdEstado =" + lid + ";";
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
			String strSQL = "Delete from EstadoInformes where IdEstado =" + Id + ";";
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
			String strSql = "select * from EstadoInformes where idEstado=" + Id.ToString();
			//try
			{
				OdbcDataAdapter myConsulta = new OdbcDataAdapter(strSql, oConnection);
				DataSet myDataSet = new DataSet();
				myConsulta.Fill(myDataSet);
				intId = int.Parse(myDataSet.Tables[0].Rows[0]["idEstado"].ToString());
				strNombre = myDataSet.Tables[0].Rows[0]["NombreEstado"].ToString();
				strDescripcion = myDataSet.Tables[0].Rows[0]["DescripcionEstado"].ToString();
				
				oConnection.Close();
			} 			
		//	catch {}
		}

		public DataTable TraerDatos()
		{
			
			OdbcConnection oConnection = OpenConnection();
			DataSet ds = new DataSet();
			OdbcDataAdapter myConsulta = new OdbcDataAdapter("select * from EstadoInformes", oConnection);
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
