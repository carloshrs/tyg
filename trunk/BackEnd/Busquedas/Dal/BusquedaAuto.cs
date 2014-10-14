using System;
using System.Data;
using System.Data.Odbc;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;

namespace ar.com.TiempoyGestion.BackEnd.Busquedas.Dal
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class BusquedaAutomotorApp : GenericDal
	{
		#region Atributos y Contructores
			
		private int intIdCliente;
		private int intIdUsuario;
		private int intEstado;
		private int intIdInforme;
		private string strNombre;
		private string strApellido;
		private int intIdTipoDoc;
		private string strNroDoc;
		private int intEstadoCivil;
		private string strResultado;
		private string strObservaciones;
		private int intIdDominio;
		private string strDominio;
		private string strRegistro;

		private int intIdTipoPersona;

		//EMPRESAS
		private String strRazonSocial;
		private String strNombreFantasia;
		private String strTelefonoEmpresa;
		private String strRubro;
		private String strCuit;
		private String strCalleEmpresa;
		private String strNroEmpresa;
		private String strDptoEmpresa;
		private String strPisoEmpresa;
		private String strBarrioEmpresa;
		private String strCPEmpresa;
		private int intLocalidadEmpresa = 67;
		private int intProvinciaEmpresa = 23;


		public BusquedaAutomotorApp() : base()
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


		public int IdTipoDoc
		{
			get
			{
				return intIdTipoDoc;
			}
			set
			{
				intIdTipoDoc = value;
			}
		}

		public string NroDoc
		{
			get
			{
				return strNroDoc;
			}
			set
			{
				strNroDoc = value;
			}
		}
		public int EstadoCivil
		{
			get
			{
				return intEstadoCivil;
			}
			set
			{
				intEstadoCivil = value;
			}
		}

		public string Resultado
		{
			get
			{
				return strResultado;
			}
			set
			{
				strResultado = value;
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
		public String NombreFantasia
		{
			get
			{
				return strNombreFantasia;
			}
			set
			{
				strNombreFantasia = value;
			}
		}
		public String TelefonoEmpresa
		{
			get
			{
				return strTelefonoEmpresa;
			}
			set
			{
				strTelefonoEmpresa = value;
			}
		}
		public String Rubro
		{
			get
			{
				return strRubro;
			}
			set
			{
				strRubro = value;
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
		public String CalleEmpresa
		{
			get
			{
				return strCalleEmpresa;
			}
			set
			{
				strCalleEmpresa = value;
			}
		}
		public String NroEmpresa
		{
			get
			{
				return strNroEmpresa;
			}
			set
			{
				strNroEmpresa = value;
			}
		}
		public String DptoEmpresa
		{
			get
			{
				return strDptoEmpresa;
			}
			set
			{
				strDptoEmpresa = value;
			}
		}
		public String PisoEmpresa
		{
			get
			{
				return strPisoEmpresa;
			}
			set
			{
				strPisoEmpresa = value;
			}
		}
		public String BarrioEmpresa
		{
			get
			{
				return strBarrioEmpresa;
			}
			set
			{
				strBarrioEmpresa = value;
			}
		}
		public String CPEmpresa
		{
			get
			{
				return strCPEmpresa;
			}
			set
			{
				strCPEmpresa = value;
			}
		}
		public int LocalidadEmpresa
		{
			get
			{
				return intLocalidadEmpresa;
			}
			set
			{
				intLocalidadEmpresa = value;
			}
		}
		public int ProvinciaEmpresa
		{
			get
			{
				return intProvinciaEmpresa;
			}
			set
			{
				intProvinciaEmpresa = value;
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
		public int IdDominio
		{
			get
			{
				return intIdDominio;
			}
			set
			{
				intIdDominio = value;
			}
		}


		public string Dominio
		{
			get
			{
				return strDominio;
			}
			set
			{
				strDominio = value;
			}

		}

		public string Registro
		{
			get
			{
				return strRegistro;
			}
			set
			{
				strRegistro = value;
			}
		}



		#endregion

		#region Métodos Publicos

		

		public bool Crear()
		{
			OdbcConnection oConnection = this.OpenConnection();
			String strSQL = "Insert into BusquedaAuto (idInforme, Nombre, Apellido, idTipoDoc, NroDoc, idEstadoCivil, IdTipoPersona, Resultado, Observaciones, ";
			strSQL = strSQL  + "RazonSocial, NombreFantasia, TelefonoEmpresa, Rubro, Cuit, CalleEmpresa, NroEmpresa, DptoEmpresa, PisoEmpresa, BarrioEmpresa, CPEmpresa, LocalidadEmpresa, ProvinciaEmpresa)";

			strSQL = strSQL  + " values (" + intIdInforme + ", '" + strNombre + "', '" + strApellido + "', " + intIdTipoDoc + ",'" + NroDoc + "'," + intEstadoCivil + ", " + intIdTipoPersona + ", '" + strResultado + "', '" + strObservaciones; 
			strSQL = strSQL  + "','" + strRazonSocial + "','" + strNombreFantasia + "','" + strTelefonoEmpresa + "','" + strRubro + "','" +	strCuit + "','" + strCalleEmpresa + "','" + strNroEmpresa + "','" + strDptoEmpresa + "','" + strPisoEmpresa + "','" + strBarrioEmpresa + "','" + strCPEmpresa + "'," + intLocalidadEmpresa + "," + intProvinciaEmpresa + ")"; 	

			String strMaxID = "SELECT MAX(idInforme) as MaxId FROM BusquedaAuto";

			try
			{
				OdbcCommand	myCommand = new OdbcCommand(strSQL, oConnection);
				myCommand.ExecuteNonQuery();

				int MaxID = ObtenerMaxID(strMaxID, oConnection); 

				String strAuditoria = "INSERT INTO HistoricoAcciones (idCliente, idUsuario, Instante, Evento, Observaciones, idTipoObjeto, idEstado, idReferencia) VALUES (";
				strAuditoria = strAuditoria  + intIdCliente + "," + intIdUsuario  + ", getdate(), 'Creación de Busqueda', 'Solicitud de Busqueda', 1" + ", 1," + MaxID.ToString() + ")";

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

		public bool Modificar(int idInforme)
		{
			OdbcConnection oConnection = this.OpenConnection();
			String strSQL = "UPDATE BusquedaAuto SET ";
			strSQL = strSQL  + "Nombre = '" + strNombre + "', Apellido = '" + strApellido + "', IdTipoDoc = " + intIdTipoDoc + ", NroDoc = '" + strNroDoc + "', " ;
			strSQL = strSQL  + "idEstadoCivil = " + intEstadoCivil + ", Resultado = '" + strResultado + "', Observaciones = '" + strObservaciones + "', ";
			strSQL = strSQL  + "RazonSocial = '" + strRazonSocial + "', NombreFantasia = '" + strNombreFantasia + "', TelefonoEmpresa = '" + strTelefonoEmpresa + "', Rubro = '" + strRubro + "', Cuit = '" + strCuit + "', CalleEmpresa = '" + strCalleEmpresa + "', NroEmpresa = '" + strNroEmpresa + "', DptoEmpresa = '" + strDptoEmpresa + "', PisoEmpresa = '" + strPisoEmpresa + "', BarrioEmpresa = '" + strBarrioEmpresa + "', CPEmpresa = '" + strCPEmpresa + "', LocalidadEmpresa = " + intLocalidadEmpresa + ", ProvinciaEmpresa = " + intProvinciaEmpresa;
			strSQL = strSQL  + " WHERE idInforme =  " + idInforme.ToString();
			try
			{
				OdbcCommand	myCommand = new OdbcCommand(strSQL, oConnection);
				myCommand.ExecuteNonQuery();

				int MaxID = idInforme; 

				String strAuditoria = "INSERT INTO HistoricoAcciones (idCliente, idUsuario, Instante, Evento, Observaciones, idTipoObjeto, idEstado, idReferencia) VALUES (";
				strAuditoria = strAuditoria  + intIdCliente + "," + intIdUsuario  + ", getdate(), 'Modificación de Busqueda', 'Modificación de Busqueda', 1" + ", 5," + MaxID.ToString() + ")";

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

		public bool Borrar(int idInforme)
		{
			OdbcConnection oConnection = this.OpenConnection();
			String strSQL = "Delete from BusquedaAuto where idInforme = " + intIdInforme.ToString();
			
			String strAuditoria = "INSERT INTO HistoricoAcciones (idCliente, idUsuario, Instante, Evento, Observaciones, idTipoObjeto, idReferencia, idEstado) VALUES (";
			strAuditoria = strAuditoria  + intIdCliente + "," + intIdUsuario  + ", getdate(), 'Eliminación de Busqueda', 'Eliminación del Busqueda" + idInforme.ToString() + "' ,1," + idInforme.ToString() + "," + Estado.ToString() + ")";

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

		public DataTable TraerEstados()
		{
			
			OdbcConnection oConnection = this.OpenConnection();
			DataSet ds = new DataSet();
			OdbcDataAdapter myConsulta = new OdbcDataAdapter("select * from BusquedaAuto", oConnection);
			myConsulta.Fill(ds);
			try
			{
				oConnection.Close();
			} 			
			catch {}

			return ds.Tables[0];

		}

		public bool Cargar(int idInforme)
		{
			
			OdbcConnection oConnection = this.OpenConnection();
			DataSet ds = new DataSet();
			String strSQL = "SELECT * FROM BusquedaAuto ";
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
			intIdTipoPersona = int.Parse(ds.Tables[0].Rows[0]["IdTipoPersona"].ToString()); 
			strNombre = ds.Tables[0].Rows[0]["Nombre"].ToString();
			strApellido = ds.Tables[0].Rows[0]["Apellido"].ToString();
			intIdTipoDoc = int.Parse(ds.Tables[0].Rows[0]["IdTipoDoc"].ToString());
			strNroDoc = ds.Tables[0].Rows[0]["NroDoc"].ToString();
			intEstadoCivil = int.Parse(ds.Tables[0].Rows[0]["idEstadoCivil"].ToString());
			strResultado = ds.Tables[0].Rows[0]["Resultado"].ToString();
			//EMPRESAS
			strRazonSocial= ds.Tables[0].Rows[0]["RazonSocial"].ToString();
			strNombreFantasia= ds.Tables[0].Rows[0]["NombreFantasia"].ToString();
			strTelefonoEmpresa= ds.Tables[0].Rows[0]["TelefonoEmpresa"].ToString();
			strRubro= ds.Tables[0].Rows[0]["Rubro"].ToString();
			strCuit= ds.Tables[0].Rows[0]["Cuit"].ToString();
			strCalleEmpresa= ds.Tables[0].Rows[0]["CalleEmpresa"].ToString();
			strNroEmpresa= ds.Tables[0].Rows[0]["NroEmpresa"].ToString();
			strDptoEmpresa= ds.Tables[0].Rows[0]["DptoEmpresa"].ToString();
			strPisoEmpresa= ds.Tables[0].Rows[0]["PisoEmpresa"].ToString();
			strBarrioEmpresa= ds.Tables[0].Rows[0]["BarrioEmpresa"].ToString();
			strCPEmpresa= ds.Tables[0].Rows[0]["CPEmpresa"].ToString();
			intLocalidadEmpresa= int.Parse(ds.Tables[0].Rows[0]["LocalidadEmpresa"].ToString());
			intProvinciaEmpresa= int.Parse(ds.Tables[0].Rows[0]["ProvinciaEmpresa"].ToString());

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
			catch 
			{
				return 0;
			}
			return MaxID;
		}



		#endregion



		public bool CrearDominio()
		{
			OdbcConnection oConnection = this.OpenConnection();
			String strSQL = "Insert into BusquedaAutoDominio (idInforme, Dominio, Registro) ";
			strSQL = strSQL  + " values (" + intIdInforme + ",'" + strDominio + "','" + strRegistro + "')"; 

			String strMaxID = "SELECT MAX(idInforme) as MaxId FROM BusquedaAutoDominio";

			try
			{
				OdbcCommand	myCommand = new OdbcCommand(strSQL, oConnection);
				myCommand.ExecuteNonQuery();

				int MaxID = ObtenerMaxID(strMaxID, oConnection); 

				String strAuditoria = "INSERT INTO HistoricoAcciones (idCliente, idUsuario, Instante, Evento, Observaciones, idTipoObjeto, idEstado, idReferencia) VALUES (";
				strAuditoria = strAuditoria  + intIdCliente + "," + intIdUsuario  + ", getdate(), 'Creación de dominio en Busqueda de Automotor', 'Solicitud de Dominio en Busqueda de Automotor', 1" + ", 1," + MaxID.ToString() + ")";

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


		public bool ModificarDominio(int idDominio)
		{
			OdbcConnection oConnection = this.OpenConnection();
			String strSQL = "UPDATE BusquedaAutoDominio SET ";
			strSQL = strSQL  + "Dominio = '" + strDominio + "', Registro = '" + strRegistro + "' " ;
			strSQL = strSQL  + " WHERE IdDominio =  " + idDominio.ToString();
			try
			{
				OdbcCommand	myCommand = new OdbcCommand(strSQL, oConnection);
				myCommand.ExecuteNonQuery();

				int MaxID = idDominio;

				String strAuditoria = "INSERT INTO HistoricoAcciones (idCliente, idUsuario, Instante, Evento, Observaciones, idTipoObjeto, idEstado, idReferencia) VALUES (";
				strAuditoria = strAuditoria  + intIdCliente + "," + intIdUsuario  + ", getdate(), 'Modificación de dominio en Busqueda de Automotor', 'Modificación de dominio en Busqueda de Automotor', 1" + ", 5," + MaxID.ToString() + ")";

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



		public bool BorrarDominio(int idDominio)
		{
			OdbcConnection oConnection = this.OpenConnection();
			String strSQL = "Delete from busquedaautodominio where idDominio = " + idDominio.ToString();
			
			String strAuditoria = "INSERT INTO HistoricoAcciones (idCliente, idUsuario, Instante, Evento, Observaciones, idTipoObjeto, idReferencia, idEstado) VALUES (";
			strAuditoria = strAuditoria  + intIdCliente + "," + intIdUsuario  + ", getdate(), 'Eliminación de Dominio en Busqueda de Automotor', 'Eliminación de Dominio en Busqueda de Automotor" + idDominio.ToString() + "' ,1," + idDominio.ToString() + "," + Estado.ToString() + ")";

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

		public static void BorrarDominios(int lIdEncabezado)
		{
			String strSQL = "Delete from busquedaautodominio where idInforme = " + lIdEncabezado.ToString();
			
			try
			{
				StaticDal.EjecutarComando(strSQL);
			} 			
			catch 
			{}
		}

		public DataTable TraerDominios(int idInforme)
		{
			
			OdbcConnection oConnection = this.OpenConnection();
			DataSet ds = new DataSet();
			string strSQL = "select idDominio, Dominio, Registro "+ 
				"from busquedaautodominio  "+
				"where idInforme = " + idInforme.ToString() + " ";
			OdbcDataAdapter myConsulta = new OdbcDataAdapter(strSQL, oConnection);
			myConsulta.Fill(ds);
			try
			{
				oConnection.Close();
			} 			
			catch {}

			return ds.Tables[0];

		}

		public bool cargarDominio(int idDominio)
		{
			
			OdbcConnection oConnection = this.OpenConnection();
			DataSet ds = new DataSet();
			String strSQL = "SELECT * FROM busquedaAutoDominio ";
			strSQL = strSQL + "WHERE idDominio = " + idDominio.ToString();
			OdbcDataAdapter myConsulta = new OdbcDataAdapter(strSQL, oConnection);
			myConsulta.Fill(ds);
			try
			{
				oConnection.Close();
				intIdInforme = int.Parse(ds.Tables[0].Rows[0]["idInforme"].ToString()); 
			} 			
			catch 
			{
				return false;
			}

			intIdInforme = int.Parse(ds.Tables[0].Rows[0]["idInforme"].ToString()); 
			strDominio = ds.Tables[0].Rows[0]["Dominio"].ToString();
			strRegistro = ds.Tables[0].Rows[0]["Registro"].ToString();
			return true;
		}




		#region Métodos Privados
		#endregion

	}
}
