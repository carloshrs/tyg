using System;
using System.Data;
using System.Data.Odbc;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;

namespace ar.com.TiempoyGestion.BackEnd.Informes.Dal
{
	/// <summary>
	/// Summary description for ClienteDal.
	/// </summary>
	public class MorosidadDal : GenericDal
	{
		#region Atributos y Contructores
			
		private int intIdCliente;
		private int intIdUsuario;
        private int intEstado;
		private int intIdInforme;
        private int intIdResultado;
		private string strNombre;
		private string strApellido;
		private int intTipoDocumento;
		private string strDocumento;

		private int intIdTipoPersona;

		//EMPRESAS
		private string strRazonSocial;
		private string strCuit;
		private string strObservaciones;


		public MorosidadDal() : base()
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

        public int IdResultado
        {
            get
            {
                return intIdResultado;
            }
            set
            {
                intIdResultado = value;
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

		public int IdTipoPersona
		{
			get
			{
				return intIdTipoPersona;
			}
			set
			{
				intIdTipoPersona = value;
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



		// EMPRESA
		public String RazonSocial
		{
			get
			{
				return strRazonSocial;
			}
			set
			{
				strRazonSocial = value;
			}
		}

		public String Cuit
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
            String strSQL = "Insert into informemorosidad (IdInforme, IdTipoPersona, Nombre, Apellido, idTipoDoc, NroDoc, Observaciones, " +
			"RazonSocial, Cuit) values (" + intIdInforme + ", " + intIdTipoPersona + ", '" + strNombre + "', '" + strApellido + "', " + intTipoDocumento + ", '" + strDocumento + "', '" + strObservaciones + "', '" + 
			strRazonSocial + "','" +	strCuit + "')";

            String strMaxID = "SELECT MAX(idInforme) as MaxId FROM Inhibiciones";

			try
			{
				OdbcCommand	myCommand = new OdbcCommand(strSQL, oConnection);
				myCommand.ExecuteNonQuery();

				int MaxID = ObtenerMaxID(strMaxID, oConnection); 

				String strAuditoria = "INSERT INTO HistoricoAcciones (idCliente, idUsuario, Instante, Evento, Observaciones, idTipoObjeto, idEstado, idReferencia) VALUES (";
				strAuditoria = strAuditoria  + intIdCliente + "," + intIdUsuario  + ", getdate(), 'Crear Gravámenes - Inhibiciones', 'Crear Gravámenes - Inhibiciones', 1" + ", 2," + MaxID.ToString() + ")";

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
            String strSQL = "UPDATE informemorosidad SET ";
			strSQL = strSQL  + " Nombre = '" + strNombre + "', Apellido = '" + strApellido + "', idTipoDoc = " + intTipoDocumento + ", NroDoc = '" + strDocumento;
			strSQL = strSQL  + "', Observaciones = '" + strObservaciones ;
			strSQL = strSQL  + "', RazonSocial = '" + strRazonSocial + "', Cuit = '" + strCuit;
			strSQL = strSQL  + "', IdTipoPersona = " + IdTipoPersona; 
			strSQL = strSQL  + " WHERE idInforme =  " + idInforme.ToString();
			try
			{
				OdbcCommand	myCommand = new OdbcCommand(strSQL, oConnection);
				myCommand.ExecuteNonQuery();

				int MaxID = idInforme; 

				String strAuditoria = "INSERT INTO HistoricoAcciones (idCliente, idUsuario, Instante, Evento, Observaciones, idTipoObjeto, idEstado, idReferencia) VALUES (";
				strAuditoria = strAuditoria  + intIdCliente + "," + intIdUsuario  + ", getdate(), 'Modificación Gravamen - Inhibición', 'Modificación Gravamen - Inhibición', 1" + ", 5," + MaxID.ToString() + ")";

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
			intIdTipoPersona = int.Parse(ds.Tables[0].Rows[0]["IdTipoPersona"].ToString()); 

			strNombre = ds.Tables[0].Rows[0]["Nombre"].ToString();
			strApellido = ds.Tables[0].Rows[0]["Apellido"].ToString();
			intTipoDocumento = int.Parse(ds.Tables[0].Rows[0]["idTipoDoc"].ToString());
			strDocumento = ds.Tables[0].Rows[0]["NroDoc"].ToString();
			//EMPRESAS
			strRazonSocial= ds.Tables[0].Rows[0]["RazonSocial"].ToString();
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
