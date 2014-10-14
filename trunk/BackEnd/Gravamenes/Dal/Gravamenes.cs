using System;
using System.Data;
using System.Data.Odbc;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;


namespace ar.com.TiempoyGestion.BackEnd.Gravamenes.Dal
{
	/// <summary>
	/// Summary description for ClienteDal.
	/// </summary>
	public class GravamenesDal : GenericDal
	{
		#region Atributos y Contructores
			
		private int intIdCliente;
		private int intIdUsuario;
		private int intIdInforme;
		private string strFolio;
		private string strTomo;
		private string strAno;
		private string strObservaciones;

		public GravamenesDal() : base()
		{		}

		#endregion

		#region Propiedades

		public int IdInforme
		{
			get
			{
				return intIdInforme;
			}
			set
			{
				intIdInforme = value;
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

		public string Folio
		{
			get
			{
				return strFolio;
			}
			set
			{
				strFolio = value;
			}
		}

		public string Tomo
		{
			get
			{
				return strTomo;
			}
			set
			{
				strTomo = value;
			}
		}

		public string Ano
		{
			get
			{
				return strAno;
			}
			set
			{
				strAno = value;
			}
		}

		public string Observaciones
		{
			get
			{
				return strObservaciones;
			}
			set
			{
				strObservaciones = value;
			}
		}


		#endregion

		#region Métodos Publicos

		public bool Crear(string strTabla)
		{
			OdbcConnection oConnection = this.OpenConnection();
			String strSQL = "Insert into " + strTabla + " (IdInforme,Folio, Tomo, Ano, Observaciones "+
			") values (" + intIdInforme + ", '" + strFolio + "', '" + strTomo + "', '" + strAno +
			"', '" + strObservaciones + "')"; 

			String strMaxID = "SELECT MAX(idInforme) as MaxId FROM Embargos";

			try
			{
				OdbcCommand	myCommand = new OdbcCommand(strSQL, oConnection);
				myCommand.ExecuteNonQuery();

				int MaxID = ObtenerMaxID(strMaxID, oConnection); 

				String strAuditoria = "INSERT INTO HistoricoAcciones (idCliente, idUsuario, Instante, Evento, Observaciones, idTipoObjeto, idEstado, idReferencia) VALUES (";
				strAuditoria = strAuditoria  + intIdCliente + "," + intIdUsuario  + ", getdate(), 'Crear Informe Embargo', 'Crear Informe Embargo', 1" + ", 1," + MaxID.ToString() + ")";

				myCommand = new OdbcCommand(strAuditoria, oConnection);
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

		public bool Modificar(int idInforme, string strTabla){
			OdbcConnection oConnection = this.OpenConnection();
			String strSQL = "UPDATE " + strTabla + "  SET ";
			strSQL = strSQL  + " Folio = '" + strFolio + "', Tomo = '" + strTomo + "', Ano = '" + strAno + "', ";
			strSQL = strSQL  + " Observaciones = '" + strObservaciones ;
			strSQL = strSQL  + "' WHERE idInforme =  " + idInforme.ToString();
			try
			{
				OdbcCommand	myCommand = new OdbcCommand(strSQL, oConnection);
				myCommand.ExecuteNonQuery();

				int MaxID = idInforme; 

				String strAuditoria = "INSERT INTO HistoricoAcciones (idCliente, idUsuario, Instante, Evento, Observaciones, idTipoObjeto, idEstado, idReferencia) VALUES (";
				strAuditoria = strAuditoria  + intIdCliente + "," + intIdUsuario  + ", getdate(), 'Modificación de Informe Embargo', 'Modificación de Informe Embargo', 1" + ", 5," + MaxID.ToString() + ")";

				myCommand = new OdbcCommand(strAuditoria, oConnection);
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

		public bool Cargar(int idInforme, string strTabla)
		{
			
			OdbcConnection oConnection = this.OpenConnection();
			DataSet ds = new DataSet();
			String strSQL = "SELECT * FROM " + strTabla ;
			strSQL = strSQL + " WHERE idInforme = " + idInforme.ToString();
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

			if(ds.Tables[0].Rows.Count == 0)
				return false;

			intIdInforme = int.Parse(ds.Tables[0].Rows[0]["IdInforme"].ToString()); 
			strFolio = ds.Tables[0].Rows[0]["Folio"].ToString();
			strTomo = ds.Tables[0].Rows[0]["Tomo"].ToString();
			strAno = ds.Tables[0].Rows[0]["Ano"].ToString();
			strObservaciones = ds.Tables[0].Rows[0]["Observaciones"].ToString();
			
			return true;
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
			catch {
				return 0;
			}
			return MaxID;
		}


		#endregion

		#region Métodos Privados
		#endregion


	}
}
