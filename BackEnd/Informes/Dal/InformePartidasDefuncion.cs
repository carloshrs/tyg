using System;
using System.Data;
using System.Data.Odbc;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;

namespace ar.com.TiempoyGestion.BackEnd.Informes.Dal
{
	/// <summary>
	/// Summary description for ClienteDal.
	/// </summary>
	public class InformePartidasDefuncionDal : GenericDal
	{
		#region Atributos y Contructores
			
		private int intIdCliente;
		private int intIdUsuario;
        private int intEstado;
		private int intIdInforme;
		private string strNombre;
		private string strApellido;
		private int intTipoDocumento;
		private string strDocumento;
		private string strCuit;
		private string strObservaciones;


        public InformePartidasDefuncionDal()
            : base()
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

        public int Estado
        {
            get
            {
                return intEstado;
            }
            set
            {
                intEstado = value;
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

		public string Apellido
		{
			get
			{
				return strApellido;
			}
			set
			{
				strApellido = value;
			}
		}

		public int TipoDocumento
		{
			get
			{
				return intTipoDocumento;
			}
			set
			{
				intTipoDocumento = value;
			}
		}

		public string Documento
		{
			get
			{
				return strDocumento;
			}
			set
			{
				strDocumento = value;
			}
		}


		public string Cuit
		{
			get
			{
				return strCuit;
			}
			set
			{
				strCuit = value;
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

		public bool Crear()
		{
			OdbcConnection oConnection = this.OpenConnection();
            String strSQL = "Insert into informepartidadefuncion (IdInforme, Nombre, Apellido, idTipoDoc, NroDoc, Observaciones, Cuit) " +
			" values (" + intIdInforme + ", '" + strNombre + "', '" + strApellido + "', " + intTipoDocumento + ", '" + strDocumento + "', '" + strObservaciones + "', '" +	strCuit + "')";

            String strMaxID = "SELECT MAX(idInforme) as MaxId FROM informepartidadefuncion";

			try
			{
				OdbcCommand	myCommand = new OdbcCommand(strSQL, oConnection);
				myCommand.ExecuteNonQuery();

				int MaxID = ObtenerMaxID(strMaxID, oConnection); 

				String strAuditoria = "INSERT INTO HistoricoAcciones (idCliente, idUsuario, Instante, Evento, Observaciones, idTipoObjeto, idEstado, idReferencia) VALUES (";
                strAuditoria = strAuditoria + intIdCliente + "," + intIdUsuario + ", getdate(), 'Crear Informe Partida Defunción', 'Crear Informe Partida Defunción', 1" + ", 2," + MaxID.ToString() + ")";

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

		public bool Modificar(int idInforme){
			OdbcConnection oConnection = this.OpenConnection();
            String strSQL = "UPDATE informepartidadefuncion SET ";
			strSQL = strSQL  + " Nombre = '" + strNombre + "', Apellido = '" + strApellido + "', idTipoDoc = " + intTipoDocumento + ", NroDoc = '" + strDocumento;
			strSQL = strSQL  + "', Observaciones = '" + strObservaciones ;
			strSQL = strSQL  + "', Cuit = '" + strCuit;
			strSQL = strSQL  + " WHERE idInforme =  " + idInforme.ToString();
			try
			{
				OdbcCommand	myCommand = new OdbcCommand(strSQL, oConnection);
				myCommand.ExecuteNonQuery();

				int MaxID = idInforme; 

				String strAuditoria = "INSERT INTO HistoricoAcciones (idCliente, idUsuario, Instante, Evento, Observaciones, idTipoObjeto, idEstado, idReferencia) VALUES (";
                strAuditoria = strAuditoria + intIdCliente + "," + intIdUsuario + ", getdate(), 'Modificación Informe Partida Defunción', 'Modificación Informe Partida Defunción', 1" + ", 5," + MaxID.ToString() + ")";

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

		public bool Cargar(int idInforme)
		{
			
			OdbcConnection oConnection = this.OpenConnection();
			DataSet ds = new DataSet();
            String strSQL = "SELECT * FROM informemorosidad ";
			strSQL = strSQL + "WHERE idInforme = " + idInforme.ToString();
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
			strNombre = ds.Tables[0].Rows[0]["Nombre"].ToString();
			strApellido = ds.Tables[0].Rows[0]["Apellido"].ToString();
			intTipoDocumento = int.Parse(ds.Tables[0].Rows[0]["idTipoDoc"].ToString());
			strDocumento = ds.Tables[0].Rows[0]["NroDoc"].ToString();
			strCuit= ds.Tables[0].Rows[0]["Cuit"].ToString();
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
