using System;
using System.Data;
using System.Data.Odbc;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;

namespace ar.com.TiempoyGestion.BackEnd.Automotores.Dal
{
	/// <summary>
	/// Summary description for ClienteDal.
	/// </summary>
	public class AutomotoresApp : GenericDal
	{
		#region Atributos y Contructores
			
		private int intIdCliente;
		private int intIdUsuario;
		private int intIdInforme;
		private int intEstado;

		private string strNombre;
		private string strApellido;
		private int intTipoDocumento;
		private string strDocumento;
		private int intEstadoCivil;
		private string strCalle;
		private string strBarrio;
		private string strNro;
		private string strPiso;
		private string strDepto;
		private string strCP;
		private int intIdLocalidad = 67;
		private int intIdProvincia = 23;
		
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

		//AUTOMOTORES
		private String strDominio;
		private String strRegistro;
		private String strCalleRegistro;
		private String strNroRegistro;
		private String strDptoRegistro;
		private String strPisoRegistro;
		private String strBarrioRegistro;
		private String strCPRegistro;
		private int intLocalidadRegistro = 67;
		private int intProvinciaRegistro = 23;

		private String strMarca;
		private String strModelo;
		private String strAno;
		private String strNroChasis;
		private String strNroMotor;

		private String strObservaciones;
		private String strGravamenes;
		private String strDatosNegativos;
		private String strResultado;

		private int intIdTitular;
		private string strNombreTitular;
		private string strApellidoTitular;
		private int intTipoDocTitular;
		private string strNroDocTitular;
		private int intEstadoCivilTitular;
		private string strCUITTitular;
		private string strNombreFantasiaTitular;
		private string strRazonSocialTitular;
		private string strRubroTitular;
		private string strPorcentajeTitular;


		public AutomotoresApp() : base()
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
		
		public String Dominio
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
		public String Registro
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
		public String CalleRegistro
		{
			get
			{
				return strCalleRegistro;
			}
			set
			{
				strCalleRegistro = value;
			}
		}
		public String NroRegistro
		{
			get
			{
				return strNroRegistro;
			}
			set
			{
				strNroRegistro = value;
			}
		}
		public String DptoRegistro
		{
			get
			{
				return strDptoRegistro;
			}
			set
			{
				strDptoRegistro = value;
			}
		}
		public String PisoRegistro
		{
			get
			{
				return strPisoRegistro;
			}
			set
			{
				strPisoRegistro = value;
			}
		}
		public String BarrioRegistro
		{
			get
			{
				return strBarrioRegistro;
			}
			set
			{
				strBarrioRegistro = value;
			}
		}
		public String CPRegistro
		{
			get
			{
				return strCPRegistro;
			}
			set
			{
				strCPRegistro = value;
			}
		}
		public int LocalidadRegistro
		{
			get
			{
				return intLocalidadRegistro;
			}
			set
			{
				intLocalidadRegistro = value;
			}
		}
		public int ProvinciaRegistro
		{
			get
			{
				return intProvinciaRegistro;
			}
			set
			{
				intProvinciaRegistro = value;
			}
		}

		public string Marca
		{
			get
			{
				return strMarca;
			}
			set
			{
				strMarca = value;
			}
		}

		public string Modelo
		{
			get
			{
				return strModelo;
			}
			set
			{
				strModelo = value;
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

		public string NroChasis
		{
			get
			{
				return strNroChasis;
			}
			set
			{
				strNroChasis = value;
			}
		}

		public string NroMotor
		{
			get
			{
				return strNroMotor;
			}
			set
			{
				strNroMotor = value;
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
		public string Gravamenes
		{
			get
			{
				return strGravamenes;
			}
			set
			{
				strGravamenes = value;
			}
		}

		public string DatosNegativos
		{
			get
			{
				return strDatosNegativos;
			}
			set
			{
				strDatosNegativos = value;
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

		public int IdTitular
		{
			get
			{
				return intIdTitular;
			}
			set
			{
				intIdTitular = value;
			}

		}

		public string NombreTitular
		{
			get
			{
				return strNombreTitular;
			}
			set
			{
				strNombreTitular = value;
			}
		}


		public string ApellidoTitular
		{
			get
			{
				return strApellidoTitular;
			}
			set
			{
				strApellidoTitular = value;
			}
		}

		public int TipoDocTitular
		{
			get
			{
				return intTipoDocTitular;
			}
			set
			{
				intTipoDocTitular = value;
			}
		}

		public string NroDocTitular
		{
			get
			{
				return strNroDocTitular;
			}
			set
			{
				strNroDocTitular = value;
			}
		}

		public int EstadoCivilTitular
		{
			get
			{
				return intEstadoCivilTitular;
			}
			set
			{
				intEstadoCivilTitular = value;
			}
		}

		public string CUITTitular
		{
			get
			{
				return strCUITTitular;
			}
			set
			{
				strCUITTitular = value;
			}
		}

		public string NombreFantasiaTitular
		{
			get
			{
				return strNombreFantasiaTitular;
			}
			set
			{
				strNombreFantasiaTitular = value;
			}
		}

		public string RazonSocialTitular
		{
			get
			{
				return strRazonSocialTitular;
			}
			set
			{
				strRazonSocialTitular = value;
			}
		}

		public string RubroTitular
		{
			get
			{
				return strRubroTitular;
			}
			set
			{
				strRubroTitular = value;
			}
		}
				

		public string PorcentajeTitular
		{
			get
			{
				return strPorcentajeTitular;
			}
			set
			{
				strPorcentajeTitular = value;
			}
		}


		#endregion

		#region Métodos Publicos

		public bool Crear()
		{
			OdbcConnection oConnection = this.OpenConnection();
			String strSQL = "Insert into Automotores (IdInforme, " +
			"Dominio, Registro, BarrioRegistro, PisoRegistro, DptoRegistro, NroRegistro, CPRegistro, CalleRegistro, ProvinciaRegistro, LocalidadRegistro, " +
			"Marca, Modelo, Ano, NroChasis, NroMotor, " +
			"Observaciones, Gravamenes, DatosNegativos, Resultado) " + 
			" values (" + intIdInforme + ", '" + strDominio + "', '" + strRegistro + "', '" + strBarrioRegistro + "', '" + strPisoRegistro + "', '" + strDptoRegistro + "', " +
			"'" + strNroRegistro + "', '" + CPRegistro + "', '" + strCalleRegistro + "', " + intProvinciaRegistro + ", " + intLocalidadRegistro + ",'" +
			strMarca + "', '" + strModelo + "', '" + strAno + "', '" + strNroChasis + "', '" + strNroMotor +  "','" + 
			strObservaciones + "', '" + strGravamenes + "', '" + strDatosNegativos + "', '" + strResultado + "')"; 
	 

			String strMaxID = "SELECT MAX(idInforme) as MaxId FROM verifDomParticular";

			try
			{
				OdbcCommand	myCommand = new OdbcCommand(strSQL, oConnection);
				myCommand.ExecuteNonQuery();

				int MaxID = ObtenerMaxID(strMaxID, oConnection); 

				String strAuditoria = "INSERT INTO HistoricoAcciones (idCliente, idUsuario, Instante, Evento, Observaciones, idTipoObjeto, idEstado, idReferencia) VALUES (";
				strAuditoria = strAuditoria  + intIdCliente + "," + intIdUsuario  + ", getdate(), 'Crear Informe de Automotor', 'Crear Informe de Automotor', 1" + ", 2," + MaxID.ToString() + ")";

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
			String strSQL = "UPDATE Automotores SET " +
			" Dominio = '" + strDominio + "', Registro = '" + strRegistro + "', CalleRegistro = '" + strCalleRegistro + "', NroRegistro = '" + strNroRegistro + "', DptoRegistro = '" + strDptoRegistro + "', PisoRegistro = '" + strPisoRegistro + "', LocalidadRegistro = " + intLocalidadRegistro + ", ProvinciaRegistro = " + intProvinciaRegistro + ", CPRegistro = '" + strCPRegistro + "', " +
			" BarrioRegistro = '" + strBarrioRegistro + "', Observaciones = '" + strObservaciones + "', Gravamenes = '" + strGravamenes + "', DatosNegativos = '" + strDatosNegativos + "', Resultado = '" + strResultado + "', " +
			" Marca = '" + strMarca + "', Modelo = '" + strModelo + "', Ano = '" + strAno + "', NroChasis = '" + strNroChasis + "', NroMotor = '" + strNroMotor + "'" +
			" WHERE idInforme =  " + idInforme.ToString();
			try
			{
				OdbcCommand	myCommand = new OdbcCommand(strSQL, oConnection);
				myCommand.ExecuteNonQuery();

				int MaxID = idInforme; 

				String strAuditoria = "INSERT INTO HistoricoAcciones (idCliente, idUsuario, Instante, Evento, Observaciones, idTipoObjeto, idEstado, idReferencia) VALUES (";
				strAuditoria = strAuditoria  + intIdCliente + "," + intIdUsuario  + ", getdate(), 'Modificación de Informe Automotor', 'Modificación de Informe Automotor', 1" + ", 2," + MaxID.ToString() + ")";

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
			String strSQL = "SELECT * FROM Automotores ";
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

			// AUTOMOTOR
			strDominio = ds.Tables[0].Rows[0]["Dominio"].ToString();
			strRegistro = ds.Tables[0].Rows[0]["Registro"].ToString();
			strCalleRegistro = ds.Tables[0].Rows[0]["CalleRegistro"].ToString();
			strBarrioRegistro = ds.Tables[0].Rows[0]["BarrioRegistro"].ToString();
			strNroRegistro = ds.Tables[0].Rows[0]["NroRegistro"].ToString();
			strPisoRegistro = ds.Tables[0].Rows[0]["PisoRegistro"].ToString();
			strDptoRegistro = ds.Tables[0].Rows[0]["DptoRegistro"].ToString();
			strCPRegistro = ds.Tables[0].Rows[0]["CPRegistro"].ToString();
			intLocalidadRegistro = int.Parse(ds.Tables[0].Rows[0]["LocalidadRegistro"].ToString());
			intProvinciaRegistro = int.Parse(ds.Tables[0].Rows[0]["ProvinciaRegistro"].ToString());

			strMarca = ds.Tables[0].Rows[0]["Marca"].ToString();
			strModelo = ds.Tables[0].Rows[0]["Modelo"].ToString();
			strAno = ds.Tables[0].Rows[0]["Ano"].ToString();
			strNroChasis = ds.Tables[0].Rows[0]["NroChasis"].ToString();
			strNroMotor = ds.Tables[0].Rows[0]["NroMotor"].ToString();
			
			strObservaciones = ds.Tables[0].Rows[0]["Observaciones"].ToString();
			strGravamenes = ds.Tables[0].Rows[0]["Gravamenes"].ToString();
			strDatosNegativos = ds.Tables[0].Rows[0]["DatosNegativos"].ToString();
			strResultado = ds.Tables[0].Rows[0]["Resultado"].ToString();
			
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



		public bool CrearTitular()
		{
			OdbcConnection oConnection = this.OpenConnection();
            String strSQL = "Insert into AutomotoresTitulares (idInforme, idTipoPersona, Nombre, Apellido, IdTipoDocumento, NroDoc, IdEstadoCivil, Calle, Barrio, CalleNro, Piso, Depto, CP, IdLocalidad, IdProvincia, Cuit, NombreFantasia, RazonSocial, Rubro, CalleEmpresa, NroEmpresa, DptoEmpresa, PisoEmpresa, BarrioEmpresa, CPEmpresa, LocalidadEmpresa, ProvinciaEmpresa, Porcentaje) " +
            " values (" + intIdInforme + ", " + intIdTipoPersona + ",'" + strNombreTitular + "','" + strApellidoTitular + "'," + intTipoDocTitular + ",'" + strNroDocTitular + "'," + intEstadoCivilTitular + ", '" + strCalle + "', '" + strBarrio + "', '" + strNro + "', '" + strPiso + "', " +
            "'" + strDepto + "', '" + strCP + "', " + intIdLocalidad + ", " + intIdProvincia + ", '" + strCUITTitular + "', '" + strNombreFantasiaTitular + "', '" + strRazonSocialTitular + "', '" + strRubroTitular + "','" + strCalleEmpresa + "','" + strNroEmpresa + "','" + strDptoEmpresa + "','" + strPisoEmpresa + "','" + strBarrioEmpresa + "','" + strCPEmpresa + "'," + intLocalidadEmpresa + "," + intProvinciaEmpresa + ", '" + strPorcentajeTitular + "')"; 

			String strMaxID = "SELECT MAX(idInforme) as MaxId FROM AutomotoresTitulares";

			try
			{
				OdbcCommand	myCommand = new OdbcCommand(strSQL, oConnection);
				myCommand.ExecuteNonQuery();

				int MaxID = ObtenerMaxID(strMaxID, oConnection); 

				String strAuditoria = "INSERT INTO HistoricoAcciones (idCliente, idUsuario, Instante, Evento, Observaciones, idTipoObjeto, idEstado, idReferencia) VALUES (";
				strAuditoria = strAuditoria  + intIdCliente + "," + intIdUsuario  + ", getdate(), 'Creación de titular en Automotores', 'Solicitud de Titular de Automotores', 1" + ", 1," + MaxID.ToString() + ")";

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


		public bool ModificarTitular(int idTitular)
		{
			OdbcConnection oConnection = this.OpenConnection();
			String strSQL = "UPDATE AutomotoresTitulares SET " +
			        "IdTipoPersona = " + intIdTipoPersona + ", Nombre = '" + strNombreTitular + "', " +
                    "Apellido = '" + strApellidoTitular + "', IdTipoDocumento = " + intTipoDocTitular + ", " + 
                    "NroDoc = '" + strNroDocTitular + "', IdEstadoCivil = " + intEstadoCivilTitular + ",Calle = '" + strCalle + "', " +
                    "Barrio = '" + strBarrio + "', CalleNro = '" + strNro + "', Piso = '" + strPiso + "', Depto = '" + strDepto + "', " +
                    "CP = '" + strCP + "', idLocalidad = " + intIdLocalidad + ", idProvincia = " + intIdProvincia + ", " +
                    "Cuit = '" + strCUITTitular + "', NombreFantasia = '" + strNombreFantasiaTitular + "', " +
                    "RazonSocial = '" + strRazonSocialTitular + "', Rubro = '" + strRubroTitular + "', Porcentaje = '" + strPorcentajeTitular +
			        "' WHERE idTitular =  " + idTitular.ToString();
			try
			{
				OdbcCommand	myCommand = new OdbcCommand(strSQL, oConnection);
				myCommand.ExecuteNonQuery();

				int MaxID = IdTitular;

				String strAuditoria = "INSERT INTO HistoricoAcciones (idCliente, idUsuario, Instante, Evento, Observaciones, idTipoObjeto, idEstado, idReferencia) VALUES (";
				strAuditoria = strAuditoria  + intIdCliente + "," + intIdUsuario  + ", getdate(), 'Modificación de titular de Automotores', 'Modificación de titular de Automotores', 1" + ", 5," + MaxID.ToString() + ")";

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



		public bool BorrarTitular(int idTitular)
		{
			OdbcConnection oConnection = this.OpenConnection();
			String strSQL = "Delete from AutomotoresTitulares where idTitular = " + idTitular.ToString();
			
			String strAuditoria = "INSERT INTO HistoricoAcciones (idCliente, idUsuario, Instante, Evento, Observaciones, idTipoObjeto, idReferencia, idEstado) VALUES (";
			strAuditoria = strAuditoria  + intIdCliente + "," + intIdUsuario  + ", getdate(), 'Eliminación de Titular de Automotor', 'Eliminación de Titular de Informe de Automotor" + idTitular.ToString() + "' ,1," + idTitular.ToString() + "," + Estado.ToString() + ")";

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

		public static void BorrarTitulares(int lIdEncabezado)
		{
			String strSQL = "Delete from AutomotoresTitulares where idInforme = " + lIdEncabezado.ToString();
			
			try
			{
				StaticDal.EjecutarComando(strSQL);
			} 			
			catch 
			{}
		}

		public DataTable TraerTitulares(int idInforme)
		{
			
			OdbcConnection oConnection = this.OpenConnection();
			DataSet ds = new DataSet();
			string strSQL = "SELECT it.idTitular, it.idTipoPersona, (it.Nombre +' '+ it.Apellido) AS Nombre, "+ 
				"(td.descripcion +' '+ it.NroDoc) as NroDoc, ec.descripcion as EstadoCivil, it.Cuit, it.NombreFantasia, " +
                "it.RazonSocial, it.Rubro, it.Porcentaje, it.calle, it.calleNro, it.piso, it.depto, it.cp, it.barrio, it.idLocalidad, it.idProvincia, "+ 
                "it.cpEmpresa, it.barrioempresa, it.pisoempresa, it.dptoEmpresa, it.nroEmpresa, it.calleEmpresa, " +
                "it.telefonoEmpresa, it.provinciaEmpresa, it.localidadEmpresa " +
				"FROM AutomotoresTitulares it " +
                "INNER JOIN tipodocumento td ON td.idTipoDocumento = it.idTipoDocumento " +
                "INNER JOIN estadocivil ec ON ec.idEstadoCivil = it.idEstadoCivil " +
				"WHERE it.idInforme = " + idInforme.ToString();
			OdbcDataAdapter myConsulta = new OdbcDataAdapter(strSQL, oConnection);
			myConsulta.Fill(ds);
			try
			{
				oConnection.Close();
			} 			
			catch {}

			return ds.Tables[0];

		}

		public bool cargarTitular(int idTitular)
		{
			
			OdbcConnection oConnection = this.OpenConnection();
			DataSet ds = new DataSet();
			String strSQL = "SELECT * FROM AutomotoresTitulares ";
			strSQL = strSQL + "WHERE idTitular = " + idTitular.ToString();
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
			intIdTipoPersona = int.Parse(ds.Tables[0].Rows[0]["idTipoPersona"].ToString()); 
			strNombreTitular = ds.Tables[0].Rows[0]["Nombre"].ToString();
			strApellidoTitular = ds.Tables[0].Rows[0]["Apellido"].ToString();
			intTipoDocTitular = int.Parse(ds.Tables[0].Rows[0]["IdTipoDocumento"].ToString());
			strNroDocTitular = ds.Tables[0].Rows[0]["NroDoc"].ToString();
			intEstadoCivilTitular = int.Parse(ds.Tables[0].Rows[0]["IdEstadoCivil"].ToString());
            strCalle = ds.Tables[0].Rows[0]["Calle"].ToString();
            strBarrio = ds.Tables[0].Rows[0]["Barrio"].ToString();
            strNro = ds.Tables[0].Rows[0]["CalleNro"].ToString();
            strPiso = ds.Tables[0].Rows[0]["Piso"].ToString();
            strDepto = ds.Tables[0].Rows[0]["Depto"].ToString();
            strCP = ds.Tables[0].Rows[0]["CP"].ToString();
            intIdLocalidad = int.Parse(ds.Tables[0].Rows[0]["idLocalidad"].ToString());
            intIdProvincia = int.Parse(ds.Tables[0].Rows[0]["idProvincia"].ToString());

            //EMPRESAS
            strRazonSocial = ds.Tables[0].Rows[0]["RazonSocial"].ToString();
            strNombreFantasia = ds.Tables[0].Rows[0]["NombreFantasia"].ToString();
            strTelefonoEmpresa = ds.Tables[0].Rows[0]["TelefonoEmpresa"].ToString();
            strRubro = ds.Tables[0].Rows[0]["Rubro"].ToString();
            strCuit = ds.Tables[0].Rows[0]["Cuit"].ToString();
            strCalleEmpresa = ds.Tables[0].Rows[0]["CalleEmpresa"].ToString();
            strNroEmpresa = ds.Tables[0].Rows[0]["NroEmpresa"].ToString();
            strDptoEmpresa = ds.Tables[0].Rows[0]["DptoEmpresa"].ToString();
            strPisoEmpresa = ds.Tables[0].Rows[0]["PisoEmpresa"].ToString();
            strBarrioEmpresa = ds.Tables[0].Rows[0]["BarrioEmpresa"].ToString();
            strCPEmpresa = ds.Tables[0].Rows[0]["CPEmpresa"].ToString();
            intLocalidadEmpresa = int.Parse(ds.Tables[0].Rows[0]["LocalidadEmpresa"].ToString());
            intProvinciaEmpresa = int.Parse(ds.Tables[0].Rows[0]["ProvinciaEmpresa"].ToString());

			strCUITTitular = ds.Tables[0].Rows[0]["Cuit"].ToString();
			strNombreFantasiaTitular = ds.Tables[0].Rows[0]["NombreFantasia"].ToString();
			strRazonSocialTitular = ds.Tables[0].Rows[0]["RazonSocial"].ToString();
			strRubroTitular = ds.Tables[0].Rows[0]["Rubro"].ToString();
			strPorcentajeTitular = ds.Tables[0].Rows[0]["Porcentaje"].ToString();
			return true;
		}



		#endregion

		#region Métodos Privados
		#endregion


	}
}
