using System;
using System.Data;
using System.Data.Odbc;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;


namespace ar.com.TiempoyGestion.BackEnd.Informes.Dal
{
	/// <summary>
	/// Summary description for ClienteDal.
	/// </summary>
	public class InformeCatastralApp : GenericDal
	{
		#region Atributos y Contructores
			
		private int intIdCliente;
		private int intIdUsuario;
		private int intEstado;
		private int intIdInforme;
		private int intTipoProp;
		private int intTipoPersona;
		private string strMatricula;
		private string strFolio;
		private string strTomo;
		private string strAno;
		private string strCalle;
		private string strBarrio;
		private string strNro;
		private string strPiso;
		private string strDepto;
		private string strCP;
        private string strLote;
        private string strManzana;
        private string strComplejo;
        private string strTorre;
		private int intIdLocalidad;
		private int intIdProvincia;
        private string strNomenclatura;
		private string strNroCuenta;
		private string strObservaciones;


		public InformeCatastralApp() : base()
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

		public int TipoProp
		{
			get
			{
				return intTipoProp;
			}
			set
			{
				intTipoProp = value;
			}
		}

		public int TipoPersona
		{
			get
			{
				return intTipoPersona;
			}
			set
			{
				intTipoPersona = value;
			}
		}


		public string Matricula
		{
			get
			{
				return strMatricula;
			}
			set
			{
				strMatricula = value;
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

        public string Calle
        {
            get
            {
                return strCalle;
            }
            set
            {
                strCalle = value;
            }
        }

        public string Barrio
        {
            get
            {
                return strBarrio;
            }
            set
            {
                strBarrio = value;
            }
        }

        public string Nro
        {
            get
            {
                return strNro;
            }
            set
            {
                strNro = value;
            }
        }

        public string Piso
        {
            get
            {
                return strPiso;
            }
            set
            {
                strPiso = value;
            }
        }

        public string Depto
        {
            get
            {
                return strDepto;
            }
            set
            {
                strDepto = value;
            }
        }

        public string CP
        {
            get
            {
                return strCP;
            }
            set
            {
                strCP = value;
            }
        }

        public string Lote
        {
            get
            {
                return strLote;
            }
            set
            {
                strLote = value;
            }
        }

        public string Manzana
        {
            get
            {
                return strManzana;
            }
            set
            {
                strManzana = value;
            }
        }

        public string Complejo
        {
            get
            {
                return strComplejo;
            }
            set
            {
                strComplejo = value;
            }
        }

        public string Torre
        {
            get
            {
                return strTorre;
            }
            set
            {
                strTorre = value;
            }
        }

        public int IdLocalidad
        {
            get
            {
                return intIdLocalidad;
            }
            set
            {
                intIdLocalidad = value;
            }
        }

        public int IdProvincia
        {
            get
            {
                return intIdProvincia;
            }
            set
            {
                intIdProvincia = value;
            }
        }

        public string Nomenclatura
        {
            get
            {
                return strNomenclatura;
            }
            set
            {
                strNomenclatura = value;
            }
        }

        public string NroCuenta
        {
            get
            {
                return strNroCuenta;
            }
            set
            {
                strNroCuenta = value;
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

		#region Crear()

		public bool Crear()
		{
			OdbcConnection oConnection = this.OpenConnection();
            String strSQL = "Insert into InformeCatastral (idInforme, idTipo, Matricula, Folio, Tomo, Anio, Calle, CalleNro, Piso, Depto, CP, Complejo, Torre, " +
                "Barrio, idProvincia, idLocalidad, Lote, Manzana, Observaciones, Nomenclatura, NCuenta) " + 
                " values (" + intIdInforme + ", " + intTipoProp + ",'" + strMatricula + "', '" + strFolio + "', '" + strTomo + "', '" + strAno + "','" + strCalle + "'" +
                ",'" + strNro + "','" + strPiso + "','" + strDepto + "','" + strCP + "','" + strComplejo + "','" + strTorre + "','" + strBarrio + "'," + intIdProvincia + "," + intIdLocalidad +
                ",'" + strLote + "','" + strManzana + "','" + strObservaciones.Replace("'", "''") + "','" + strNomenclatura + "','" + strNroCuenta + "')"; 

			String strMaxID = "SELECT MAX(idInforme) as MaxId FROM InformeCatastral";

			try
			{
				OdbcCommand	myCommand = new OdbcCommand(strSQL, oConnection);
				myCommand.ExecuteNonQuery();

				int MaxID = ObtenerMaxID(strMaxID, oConnection); 

				String strAuditoria = "INSERT INTO HistoricoAcciones (idCliente, idUsuario, Instante, Evento, Observaciones, idTipoObjeto, idEstado, idReferencia) VALUES (";
				strAuditoria = strAuditoria  + intIdCliente + "," + intIdUsuario  + ", getdate(), 'Creación de Informe Catastral', 'Solicitud de Informe', 1" + ", 1," + MaxID.ToString() + ")";

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

		#endregion

		#region Modificar(int idInforme)

		public bool Modificar(int idInforme)
		{
			OdbcConnection oConnection = this.OpenConnection();
			String strSQL = "UPDATE InformeCatastral SET " +
			    "IdTipo = " + intTipoProp + ", Matricula = '" + strMatricula + "', Folio = '" + strFolio + "', Tomo = '" + strTomo + "', Anio = '" + strAno + "', " +
                "Calle = '" + strCalle + "', CalleNro = '" + strNro + "', Piso = '" + strPiso + "', Depto = '" + strDepto + "', CP = '" + strCP + "'," + 
                "Complejo = '" + strComplejo + "', Torre = '" + strTorre + "', Barrio = '" + strBarrio + "', idProvincia = " + intIdProvincia + ", idLocalidad = " + intIdLocalidad + ", " +
			    "Lote = '" + strLote + "', Manzana = '" + strManzana + "', Observaciones = '" + strObservaciones.Replace("'", "''") + "', " +
			    "Nomenclatura = '" + strNomenclatura + "', NCuenta = '" + strNroCuenta + "' " +
			    " WHERE idInforme =  " + idInforme.ToString();
			try
			{
				OdbcCommand	myCommand = new OdbcCommand(strSQL, oConnection);
				myCommand.ExecuteNonQuery();

				int MaxID = idInforme; 

				String strAuditoria = "INSERT INTO HistoricoAcciones (idCliente, idUsuario, Instante, Evento, Observaciones, idTipoObjeto, idEstado, idReferencia) VALUES (";
				strAuditoria = strAuditoria  + intIdCliente + "," + intIdUsuario  + ", getdate(), 'Modificación de Informe Catastral', 'Modificación de Informe Catastral', 1" + ", 5," + MaxID.ToString() + ")";

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

		#endregion
		
		#region Borrar(int idInforme)

		public bool Borrar(int idInforme)
		{
			OdbcConnection oConnection = this.OpenConnection();
			String strSQL = "Delete from InformeCatastral where idInforme = " + intIdInforme.ToString();
			
			String strAuditoria = "INSERT INTO HistoricoAcciones (idCliente, idUsuario, Instante, Evento, Observaciones, idTipoObjeto, idReferencia, idEstado) VALUES (";
			strAuditoria = strAuditoria  + intIdCliente + "," + intIdUsuario  + ", getdate(), 'Eliminación de Informe Catastral', 'Eliminación del Informe Nro." + idInforme.ToString() + "' ,1," + idInforme.ToString() + "," + Estado.ToString() + ")";

			try
			{
				OdbcCommand	myCommand = new OdbcCommand(strSQL, oConnection);
				myCommand.ExecuteNonQuery();
				myCommand = new OdbcCommand(strAuditoria, oConnection);
				myCommand.ExecuteNonQuery();
				oConnection.Close();
			} 			
			catch 
			{
				return false;
			}
			return true;
		}

		#endregion

		#region TraerEstados()

		public DataTable TraerEstados()
		{			
			OdbcConnection oConnection = this.OpenConnection();
			DataSet ds = new DataSet();
			OdbcDataAdapter myConsulta = new OdbcDataAdapter("select * from InformePropiedad", oConnection);
			myConsulta.Fill(ds);
			try
			{
				oConnection.Close();
			} 			
			catch {}

			return ds.Tables[0];
		}

		#endregion

		#region cargarInformeCatastral(int idInforme)

        public bool cargarInformeCatastral(int idInforme)
		{			
			OdbcConnection oConnection = this.OpenConnection();
			DataSet ds = new DataSet();
			String strSQL = "SELECT * FROM InformeCatastral ";
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

			intIdInforme = int.Parse(ds.Tables[0].Rows[0]["idInforme"].ToString()); 
			intTipoProp = int.Parse(ds.Tables[0].Rows[0]["IdTipo"].ToString());
			strMatricula = ds.Tables[0].Rows[0]["Matricula"].ToString();
			strFolio = ds.Tables[0].Rows[0]["Folio"].ToString();
			strTomo = ds.Tables[0].Rows[0]["Tomo"].ToString();
			strAno = ds.Tables[0].Rows[0]["Anio"].ToString();
            strCalle = ds.Tables[0].Rows[0]["Calle"].ToString();
            strBarrio = ds.Tables[0].Rows[0]["Barrio"].ToString();
            strNro = ds.Tables[0].Rows[0]["CalleNro"].ToString();
            strPiso = ds.Tables[0].Rows[0]["Piso"].ToString();
            strDepto = ds.Tables[0].Rows[0]["Depto"].ToString();
            strCP = ds.Tables[0].Rows[0]["CP"].ToString();
            strLote = ds.Tables[0].Rows[0]["Lote"].ToString();
            strManzana = ds.Tables[0].Rows[0]["Manzana"].ToString();
            strComplejo = ds.Tables[0].Rows[0]["Complejo"].ToString();
            strTorre = ds.Tables[0].Rows[0]["Torre"].ToString();
            if (ds.Tables[0].Rows[0]["idLocalidad"].ToString() != "")
                intIdLocalidad = int.Parse(ds.Tables[0].Rows[0]["idLocalidad"].ToString());
            if (ds.Tables[0].Rows[0]["idProvincia"].ToString() != "")
                intIdProvincia = int.Parse(ds.Tables[0].Rows[0]["idProvincia"].ToString());
			strObservaciones = ds.Tables[0].Rows[0]["Observaciones"].ToString();
			strNomenclatura = ds.Tables[0].Rows[0]["Nomenclatura"].ToString();
			strNroCuenta = ds.Tables[0].Rows[0]["Ncuenta"].ToString();
			return true;
		}

		#endregion


		#endregion
		
		#region Métodos Privados

		#region ObtenerMaxID(string strMaxID, OdbcConnection oConnection)

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

		#endregion

		#endregion
	}
}
