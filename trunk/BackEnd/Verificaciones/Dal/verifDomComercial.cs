using System;
using System.Data;
using System.Data.Odbc;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;

namespace ar.com.TiempoyGestion.BackEnd.Verificaciones.Dal
{
	/// <summary>
	/// Summary description for ClienteDal.
	/// </summary>
	public class VerifDomComercialApp : GenericDal
	{
		#region Atributos y Contructores

		private int intIdCliente;
		private int intIdUsuario;
		private int intIdInforme;
		private string strNombre;
		private string strApellido;
		private int intTipoDocumento;
		private string strDocumento;
		private string strCalle;
		private string strBarrio;
		private string strNro;
		private string strPiso;
		private string strDepto;
		private string strCP;
		private int intIdProvincia;
		private int intIdLocalidad;

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

		private string strTelefono;
		private string strFecha;
		private string strOcupacion;
		private string strCategoria;
		private string strMovComercial;
		private string strActividad;
		private string strRubrosAdicionales;
		private string strHorario;
		private string strAntiguedad;
		private string strCantPersonal;
		private int intCaractZona;
		private int intDocVerificado;
		private int intUbicacion;
		private int intTamLocal;
		private int intInmueble;
		private int intEstado;
		private int intPublicidad;
		private int intVigilancia;
		private string strFechaInicio;
		private string strCatIVA;
		private string strInformo;
		private string strCargo;
		private string strNombreVecino;
		private string strDomicilioVecino;
		private string strConoceVecino;
		private string strObservaciones;
		private string strPlanoA;
		private string strPlanoB;
		private string strPlanoC;
		private string strPlanoD;
		private int intConFoto;

		public VerifDomComercialApp() : base()
		{
		}

		#endregion

		#region Propiedades

		public int IdInforme
		{
			get { return intIdInforme; }
			set { intIdInforme = value; }
		}

		public int IdCliente
		{
			get { return intIdCliente; }
			set { intIdCliente = value; }
		}

		public int IdUsuario
		{
			get { return intIdUsuario; }
			set { intIdUsuario = value; }
		}

		public int IdTipoPersona
		{
			get { return intIdTipoPersona; }
			set { intIdTipoPersona = value; }
		}

		public string Nombre
		{
			get { return strNombre; }
			set { strNombre = value; }
		}

		public string Apellido
		{
			get { return strApellido; }
			set { strApellido = value; }
		}

		public int TipoDocumento
		{
			get { return intTipoDocumento; }
			set { intTipoDocumento = value; }
		}

		public string Documento
		{
			get { return strDocumento; }
			set { strDocumento = value; }
		}


		public string Calle
		{
			get { return strCalle; }
			set { strCalle = value; }
		}

		public string Barrio
		{
			get { return strBarrio; }
			set { strBarrio = value; }
		}

		public string Nro
		{
			get { return strNro; }
			set { strNro = value; }
		}

		public string Piso
		{
			get { return strPiso; }
			set { strPiso = value; }
		}

		public string Depto
		{
			get { return strDepto; }
			set { strDepto = value; }
		}

		public string CP
		{
			get { return strCP; }
			set { strCP = value; }
		}

		public int IdProvincia
		{
			get { return intIdProvincia; }
			set { intIdProvincia = value; }
		}

		public int IdLocalidad
		{
			get { return intIdLocalidad; }
			set { intIdLocalidad = value; }
		}

		public string Telefono
		{
			get { return strTelefono; }
			set { strTelefono = value; }
		}


		// EMPRESA
		public String RazonSocial
		{
			get { return strRazonSocial; }
			set { strRazonSocial = value; }
		}

		public String NombreFantasia
		{
			get { return strNombreFantasia; }
			set { strNombreFantasia = value; }
		}

		public String TelefonoEmpresa
		{
			get { return strTelefonoEmpresa; }
			set { strTelefonoEmpresa = value; }
		}

		public String Rubro
		{
			get { return strRubro; }
			set { strRubro = value; }
		}

		public String Cuit
		{
			get { return strCuit; }
			set { strCuit = value; }
		}

		public String CalleEmpresa
		{
			get { return strCalleEmpresa; }
			set { strCalleEmpresa = value; }
		}

		public String NroEmpresa
		{
			get { return strNroEmpresa; }
			set { strNroEmpresa = value; }
		}

		public String DptoEmpresa
		{
			get { return strDptoEmpresa; }
			set { strDptoEmpresa = value; }
		}

		public String PisoEmpresa
		{
			get { return strPisoEmpresa; }
			set { strPisoEmpresa = value; }
		}

		public String BarrioEmpresa
		{
			get { return strBarrioEmpresa; }
			set { strBarrioEmpresa = value; }
		}

		public String CPEmpresa
		{
			get { return strCPEmpresa; }
			set { strCPEmpresa = value; }
		}

		public int LocalidadEmpresa
		{
			get { return intLocalidadEmpresa; }
			set { intLocalidadEmpresa = value; }
		}

		public int ProvinciaEmpresa
		{
			get { return intProvinciaEmpresa; }
			set { intProvinciaEmpresa = value; }
		}


		public string Fecha
		{
			get { return strFecha; }
			set { strFecha = value; }
		}

		public string Ocupacion
		{
			get { return strOcupacion; }
			set { strOcupacion = value; }
		}

		public string Categoria
		{
			get { return strCategoria; }
			set { strCategoria = value; }
		}

		public string MovComercial
		{
			get { return strMovComercial; }
			set { strMovComercial = value; }
		}

		public string Actividad
		{
			get { return strActividad; }
			set { strActividad = value; }
		}

		public string RubrosAdicionales
		{
			get { return strRubrosAdicionales; }
			set { strRubrosAdicionales = value; }
		}

		public string Horario
		{
			get { return strHorario; }
			set { strHorario = value; }
		}

		public string Antiguedad
		{
			get { return strAntiguedad; }
			set { strAntiguedad = value; }
		}

		public string CantPersonal
		{
			get { return strCantPersonal; }
			set { strCantPersonal = value; }
		}

		public int CaractZona
		{
			get { return intCaractZona; }
			set { intCaractZona = value; }
		}

		public int DocVerificado
		{
			get { return intDocVerificado; }
			set { intDocVerificado = value; }
		}

		public int Ubicacion
		{
			get { return intUbicacion; }
			set { intUbicacion = value; }
		}

		public int TamLocal
		{
			get { return intTamLocal; }
			set { intTamLocal = value; }
		}

		public int Inmueble
		{
			get { return intInmueble; }
			set { intInmueble = value; }
		}

		public int Estado
		{
			get { return intEstado; }
			set { intEstado = value; }
		}

		public int Publicidad
		{
			get { return intPublicidad; }
			set { intPublicidad = value; }
		}

		public int Vigilancia
		{
			get { return intVigilancia; }
			set { intVigilancia = value; }
		}

		public string FechaInicio
		{
			get { return strFechaInicio; }
			set { strFechaInicio = value; }
		}

		public string CatIVA
		{
			get { return strCatIVA; }
			set { strCatIVA = value; }
		}

		public string Informo
		{
			get { return strInformo; }
			set { strInformo = value; }
		}

		public string Cargo
		{
			get { return strCargo; }
			set { strCargo = value; }
		}

		public string NombreVecino
		{
			get { return strNombreVecino; }
			set { strNombreVecino = value; }
		}

		public string DomicilioVecino
		{
			get { return strDomicilioVecino; }
			set { strDomicilioVecino = value; }
		}

		public string ConoceVecino
		{
			get { return strConoceVecino; }
			set { strConoceVecino = value; }
		}

		public string Observaciones
		{
			get { return strObservaciones; }
			set { strObservaciones = value; }
		}

		public string PlanoA
		{
			get { return strPlanoA; }
			set { strPlanoA = value; }
		}

		public string PlanoB
		{
			get { return strPlanoB; }
			set { strPlanoB = value; }
		}

		public string PlanoC
		{
			get { return strPlanoC; }
			set { strPlanoC = value; }
		}

		public string PlanoD
		{
			get { return strPlanoD; }
			set { strPlanoD = value; }
		}

		public int ConFoto
		{
			get { return intConFoto; }
			set { intConFoto = value; }
		}

		#endregion

		#region Métodos Publicos

		#region Crear()

		public bool Crear()
		{
			string ConvFecha = "";
			string ConvFechaInicio = "";

			if (strFecha != "")
			{
				//string[] fecha = strFecha.Split("/".ToCharArray());
				//ConvFecha = fecha[2] + "/" + fecha[1] + "/" + fecha[0];
                ConvFecha = strFecha;
			}

			if (strFechaInicio != "")
			{
				//string[] fechaContrato = strFechaInicio.Split("/".ToCharArray());
				//ConvFechaInicio = fechaContrato[2] + "/" + fechaContrato[1] + "/" + fechaContrato[0];
                ConvFechaInicio = strFechaInicio;
			}

			OdbcConnection oConnection = this.OpenConnection();

			String strSQL = "INSERT INTO verifDomComercial (IdTipoPersona, IdInforme, Nombre, ";
			strSQL += "Apellido, idTipoDoc, NroDoc, Calle, Barrio, CalleNro, Piso, Depto, CP, ";
			strSQL += "Localidad, Provincia, Telefono, RazonSocial, NombreFantasia, TelefonoEmpresa, ";
			strSQL += "Rubro, Cuit, CalleEmpresa, NroEmpresa, DptoEmpresa, PisoEmpresa, BarrioEmpresa, ";
			strSQL += "CPEmpresa, LocalidadEmpresa, ProvinciaEmpresa, FechaVerificacion, ";
			strSQL += "Ocupacion, CatAutonomo, MovComercial, ActividadPrincipal, RubrosAdicionales, ";
			strSQL += "HorarioAtencion, AntiguedadDom, CantPersonal, idZona, idDocumentoVerificado, ";
			strSQL += "idUbicacion, idTamanioLocal, idInmueble, idEstadoConservacion, Publicidad, ";
			strSQL += "Vigilancia, FechaInicio, CatIVA, Informo, Cargo, VecinalNombre, VecinalDomicilio, ";
			strSQL += "VecinalConoce, Observaciones, PlanoA, PlanoB, PlanoC, PlanoD, idFoto) ";

			strSQL = strSQL + " VALUES (" + intIdTipoPersona + ", " + intIdInforme;
			
			if (strNombre.Trim() != "") strSQL+=",'"+strNombre.Trim()+"'"; 
			else strSQL+=",null";

            if (strApellido.Trim() != "") strSQL += ",'" + strApellido.Trim().Replace("'", "''") + "'"; 
			else strSQL+=",null";

			strSQL+="," + intTipoDocumento;

			if (strDocumento.Trim() != "") strSQL+=",'"+strDocumento.Trim()+"'"; 
			else strSQL+=",null";

            if (strCalle.Trim() != "") strSQL += ",'" + strCalle.Trim().Replace("'", "''") + "'"; 
			else strSQL+=",null";

            if (strBarrio.Trim() != "") strSQL += ",'" + strBarrio.Trim().Replace("'", "''") + "'"; 
			else strSQL+=",null";

			if (strNro.Trim() != "") strSQL+=",'"+strNro.Trim()+"'"; 
			else strSQL+=",null";

			if (strPiso.Trim() != "") strSQL+=",'"+strPiso.Trim()+"'"; 
			else strSQL+=",null";

			if (strDepto.Trim() != "") strSQL+=",'"+strDepto.Trim()+"'"; 
			else strSQL+=",null";

			if (strCP.Trim() != "") strSQL+=",'"+strCP.Trim()+"'"; 
			else strSQL+=",null";

			strSQL+="," + intIdLocalidad + "," + intIdProvincia; 
			
			if (strTelefono.Trim() != "") strSQL+=",'"+strTelefono+"'"; 
			else strSQL+=",null";

            if (strRazonSocial.Trim() != "") strSQL += ",'" + strRazonSocial.Trim().Replace("'", "''") + "'"; 
			else strSQL+=",null";

            if (strNombreFantasia.Trim() != "") strSQL += ",'" + strNombreFantasia.Trim().Replace("'", "''") + "'"; 
			else strSQL+=",null";

			if (strTelefonoEmpresa.Trim() != "") strSQL+=",'"+strTelefonoEmpresa.Trim()+"'"; 
			else strSQL+=",null";

			if (strRubro.Trim() != "") strSQL+=",'"+strRubro.Trim()+"'"; 
			else strSQL+=",null";
 
			if (strCuit.Trim() != "") strSQL+=",'"+strCuit.Trim()+"'"; 
			else strSQL+=",null";

            if (strCalleEmpresa.Trim() != "") strSQL += ",'" + strCalleEmpresa.Trim().Replace("'", "''") + "'"; 
			else strSQL+=",null";

			if (strNroEmpresa.Trim() != "") strSQL+=",'"+strNroEmpresa.Trim()+"'"; 
			else strSQL+=",null";

			if (strDptoEmpresa.Trim() != "") strSQL+=",'"+strDptoEmpresa.Trim()+"'"; 
			else strSQL+=",null";

			if (strPisoEmpresa.Trim() != "") strSQL+=",'"+strPisoEmpresa.Trim()+"'"; 
			else strSQL+=",null";

			if (strBarrioEmpresa.Trim() != "") strSQL+=",'"+strBarrioEmpresa.Trim()+"'"; 
			else strSQL+=",null";

			if (strCPEmpresa.Trim() != "") strSQL+=",'"+strCPEmpresa.Trim()+"'"; 
			else strSQL+=",null";
			
			strSQL+="," + intLocalidadEmpresa + "," + intProvinciaEmpresa;

			if (ConvFecha.Trim() != "") strSQL+=",'"+ConvFecha.Trim()+"'"; 
			else strSQL+=",null";

			if (strOcupacion.Trim() != "") strSQL+=",'"+strOcupacion.Trim()+"'"; 
			else strSQL+=",null";

			if (strCategoria.Trim() != "") strSQL+=",'"+strCategoria.Trim()+"'"; 
			else strSQL+=",null";

			if (strMovComercial.Trim() != "") strSQL+=",'"+strMovComercial.Trim()+"'"; 
			else strSQL+=",null";

			if (strActividad.Trim() != "") strSQL+=",'"+strActividad.Trim()+"'"; 
			else strSQL+=",null";

			if (strRubrosAdicionales.Trim() != "") strSQL+=",'"+strRubrosAdicionales.Trim()+"'"; 
			else strSQL+=",null";

			if (strHorario.Trim() != "") strSQL+=",'"+strHorario.Trim()+"'"; 
			else strSQL+=",null";

			if (strAntiguedad.Trim() != "") strSQL+=",'"+strAntiguedad.Trim()+"'"; 
			else strSQL+=",null";

			if (strCantPersonal.Trim() != "") strSQL+=",'"+strCantPersonal.Trim()+"'"; 
			else strSQL+=",null";
			
			strSQL+="," + intCaractZona;
			strSQL+="," + intDocVerificado;
			strSQL+="," + intUbicacion;
			strSQL+="," + intTamLocal;
			strSQL+="," + intInmueble;
			strSQL+="," + intEstado;
			strSQL+="," + intPublicidad;
			strSQL+="," + intVigilancia;

			if (ConvFechaInicio.Trim() != "") strSQL+=",'"+ConvFechaInicio.Trim()+"'"; 
			else strSQL+=",null";

			if (strCatIVA.Trim() != "") strSQL+=",'"+strCatIVA.Trim()+"'"; 
			else strSQL+=",null";

			if (strInformo.Trim() != "") strSQL+=",'"+strInformo.Trim()+"'"; 
			else strSQL+=",null";

			if (strCargo.Trim() != "") strSQL+=",'"+strCargo.Trim()+"'"; 
			else strSQL+=",null";

			// REFERENCIA VECINAL //
			if (strNombreVecino.Trim() != "") strSQL+=",'"+strNombreVecino.Trim()+"'"; 
			else strSQL+=",null";

			if (strDomicilioVecino.Trim() != "") strSQL+=",'"+strDomicilioVecino.Trim()+"'";  
			else strSQL+=",null";

			if (strConoceVecino.Trim() != "") strSQL+=",'"+strConoceVecino.Trim()+"'"; 
			else strSQL+=",null";

			if (strObservaciones.Trim() != "") strSQL+=",'"+strObservaciones.Trim()+"'"; 
			else strSQL+=",null";

			if (strPlanoA.Trim() != "") strSQL+=",'"+strPlanoA.Trim()+"'";
			else strSQL+=",null";

			if (strPlanoB.Trim() != "") strSQL+=",'"+strPlanoB.Trim()+"'";
			else strSQL+=",null";

			if (strPlanoC.Trim() != "") strSQL+=",'"+strPlanoC.Trim()+"'";
			else strSQL+=",null";

			if (strPlanoD.Trim() != "") strSQL+=",'"+strPlanoD.Trim()+"'";
			else strSQL+=",null";

			strSQL+=","+intConFoto+")";
									
			String strMaxID = "SELECT MAX(idInforme) AS MaxId FROM VerifDomComercial";

			try
			{
				OdbcCommand myCommand = new OdbcCommand(strSQL, oConnection);
				myCommand.ExecuteNonQuery();

				int MaxID = ObtenerMaxID(strMaxID, oConnection);

				String strAuditoria = "INSERT INTO HistoricoAcciones (idCliente, idUsuario, Instante, Evento, Observaciones, idTipoObjeto, idEstado, idReferencia) VALUES (";
				strAuditoria = strAuditoria + intIdCliente + "," + intIdUsuario + ", getdate(), 'Crear verificación de domicilio comercial', 'Solicitud de verificación de domicilio comercial', 1" + ", 1," + MaxID.ToString() + ")";

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
			string ConvFecha = "";
			string ConvFechaInicio = "";

			if (strFecha != "")
			{
				//string[] fecha = strFecha.Split("/".ToCharArray());
				//ConvFecha = fecha[2] + "/" + fecha[1] + "/" + fecha[0];
                ConvFecha = strFecha;
			}

			if (strFechaInicio != "")
			{
				//string[] fechaContrato = strFechaInicio.Split("/".ToCharArray());
				//ConvFechaInicio = fechaContrato[2] + "/" + fechaContrato[1] + "/" + fechaContrato[0];
                ConvFechaInicio = strFechaInicio;
			}

			OdbcConnection oConnection = this.OpenConnection();
			// Armando Consulta a realizar...
			String strSQL = "UPDATE VerifDomComercial SET ";

			strSQL+="IdTipoPersona="+ intIdTipoPersona;

			if (strNombre.Trim()!="")
                strSQL += ",Nombre ='" + strNombre.Trim().Replace("'", "''") + "'";
			else
				strSQL+=",Nombre =null";
			
			if (strApellido.Trim()!="")
                strSQL += ",Apellido ='" + strApellido.Trim().Replace("'", "''") + "'";
			else
				strSQL+=",Apellido =null";
			
			strSQL+=",idTipoDoc="+ intTipoDocumento;         

			if (strDocumento.Trim()!="")                     
				strSQL+=",NroDoc ='" + strDocumento.Trim()+"'";
			else
				strSQL+=",NroDoc =null";

			if (strCalle.Trim()!="")
                strSQL += ",Calle ='" + strCalle.Trim().Replace("'", "''") + "'";
			else
				strSQL+=",Calle =null";
			
			if (strBarrio.Trim()!="")
                strSQL += ",Barrio ='" + strBarrio.Trim().Replace("'", "''") + "'";
			else
				strSQL+=",Barrio =null";

			if (strNro.Trim()!="")                         
				strSQL+=",CalleNro ='" + strNro.Trim()+"'";
			else
				strSQL+=",CalleNro =null";

			if (strPiso.Trim()!="")                             
				strSQL+=",Piso ='" + strPiso.Trim()+"'";
			else
				strSQL+=",Piso =null";

			if (strDepto.Trim()!="")                            
				strSQL+=",Depto ='" + strDepto.Trim()+"'";
			else
				strSQL+=",Depto =null";

			if (strCP.Trim()!="")                               
				strSQL+=",CP ='" + strCP.Trim()+"'";
			else
				strSQL+=",CP =null";
			
			strSQL+=",Localidad =" + intIdLocalidad;		 
			strSQL+=",Provincia =" + intIdProvincia;       
			
			if (strTelefono.Trim()!="")                         
				strSQL+=",Telefono ='" + strTelefono.Trim()+"'";
			else
				strSQL+=",Telefono =null";

			if (strRazonSocial.Trim()!="")                   
				strSQL+=",RazonSocial ='" + strRazonSocial.Trim()+"'";
			else
				strSQL+=",RazonSocial =null";

			if (strNombreFantasia.Trim()!="")
                strSQL += ",NombreFantasia ='" + strNombreFantasia.Trim().Replace("'", "''") + "'";
			else
				strSQL+=",NombreFantasia =null";

			if (strTelefonoEmpresa.Trim()!="")                  
				strSQL+=",TelefonoEmpresa ='" + strTelefonoEmpresa.Trim()+"'";
			else
				strSQL+=",TelefonoEmpresa =null";

			if (strRubro.Trim()!="")                            
				strSQL+=",Rubro ='" + strRubro.Trim()+"'";
			else
				strSQL+=",Rubro =null";

			if (strCuit.Trim()!="")                             
				strSQL+=",Cuit ='" + strCuit.Trim()+"'";
			else
				strSQL+=",Cuit =null";

			if (strCalleEmpresa.Trim()!="")
                strSQL += ",CalleEmpresa ='" + strCalleEmpresa.Trim().Replace("'", "''") + "'";
			else
				strSQL+=",CalleEmpresa =null";

			if (strNroEmpresa.Trim()!="")                       
				strSQL+=",NroEmpresa ='" + strNroEmpresa.Trim()+"'";
			else
				strSQL+=",NroEmpresa =null";

			if (strDptoEmpresa.Trim()!="")                      
				strSQL+=",DptoEmpresa ='" + strDptoEmpresa.Trim()+"'";
			else
				strSQL+=",DptoEmpresa =null";
 
			if (strPisoEmpresa.Trim()!="")                      
				strSQL+=",PisoEmpresa ='" + strPisoEmpresa.Trim()+"'";
			else
				strSQL+=",PisoEmpresa =null";

			if (strBarrioEmpresa.Trim()!="")
                strSQL += ",BarrioEmpresa ='" + strBarrioEmpresa.Trim().Replace("'", "''") + "'";
			else
				strSQL+=",BarrioEmpresa =null";

			if (strCPEmpresa.Trim()!="")                        
				strSQL+=",CPEmpresa ='" + strCPEmpresa.Trim()+"'";
			else
				strSQL+=",CPEmpresa =null";
			
			strSQL+=",LocalidadEmpresa =" + intLocalidadEmpresa; 
			strSQL+=",ProvinciaEmpresa =" + intProvinciaEmpresa; 

			if (ConvFecha.Trim()!="")                        
				strSQL+=",FechaVerificacion ='" + ConvFecha.Trim()+"'";
			else
				strSQL+=",FechaVerificacion =null";

			if (strOcupacion.Trim()!="")                        
				strSQL+=",Ocupacion ='" + strOcupacion.Trim()+"'";
			else
				strSQL+=",Ocupacion =null";

			if (strCategoria.Trim()!="")                        
				strSQL+=",CatAutonomo ='" + strCategoria.Trim()+"'";
			else
				strSQL+=",CatAutonomo =null";

			if (strMovComercial.Trim()!="")                        
				strSQL+=",MovComercial ='" + strMovComercial.Trim()+"'";
			else
				strSQL+=",MovComercial =null";

			if (strActividad.Trim()!="")                        
				strSQL+=",ActividadPrincipal ='" + strActividad.Trim()+"'";
			else
				strSQL+=",ActividadPrincipal =null";

			if (strRubrosAdicionales.Trim()!="")                        
				strSQL+=",RubrosAdicionales ='" + strRubrosAdicionales.Trim()+"'";
			else
				strSQL+=",RubrosAdicionales =null";

			if (strHorario.Trim()!="")                        
				strSQL+=",HorarioAtencion ='" + strHorario.Trim()+"'";
			else
				strSQL+=",HorarioAtencion =null";

			if (strAntiguedad.Trim()!="")                        
				strSQL+=",AntiguedadDom ='" + strAntiguedad.Trim()+"'";
			else
				strSQL+=",AntiguedadDom =null";

			if (strCantPersonal.Trim()!="")                        
				strSQL+=",CantPersonal ='" + strCantPersonal.Trim()+"'";
			else
				strSQL+=",CantPersonal =null";

			strSQL+=",idZona =" + intCaractZona; 
			strSQL+=",idDocumentoVerificado =" + intDocVerificado; 
			strSQL+=",idUbicacion =" + intUbicacion; 
			strSQL+=",idTamanioLocal =" + intTamLocal; 
			strSQL+=",idInmueble =" + intInmueble; 
			strSQL+=",idEstadoConservacion =" + intEstado; 
			strSQL+=",Publicidad =" + intPublicidad; 
			strSQL+=",Vigilancia =" + intVigilancia; 

			if (ConvFechaInicio.Trim()!="")                   
				strSQL+=",FechaInicio ='" + ConvFecha.Trim()+"'";
			else
				strSQL+=",FechaInicio =null";

			if (strCatIVA.Trim()!="")                    
				strSQL+=",CatIVA ='" + strCatIVA.Trim()+"'";
			else
				strSQL+=",CatIVA =null";

			if (strInformo.Trim()!="")                    
				strSQL+=",Informo ='" + strInformo.Trim()+"'";
			else
				strSQL+=",Informo =null";

			if (strCargo.Trim()!="")                    
				strSQL+=",Cargo ='" + strCargo.Trim()+"'";
			else
				strSQL+=",Cargo =null";

			if (strNombreVecino.Trim()!="")                       
				strSQL+=",VecinalNombre ='" + strNombreVecino.Trim()+"'";
			else
				strSQL+=",VecinalNombre =null";

			if (strDomicilioVecino.Trim()!="")                     
				strSQL+=",VecinalDomicilio ='" + strDomicilioVecino.Trim()+"'";
			else
				strSQL+=",VecinalDomicilio =null";

			if (strConoceVecino.Trim()!="")                        
				strSQL+=",VecinalConoce ='" + strConoceVecino.Trim()+"'";
			else
				strSQL+=",VecinalConoce =null";

			if (strObservaciones.Trim()!="")
                strSQL += ",Observaciones ='" + strObservaciones.Trim().Replace("'", "''") + "'";
			else
				strSQL+=",Observaciones =null";

			if (strPlanoA.Trim()!="")                              
				strSQL+=",PlanoA ='" + strPlanoA.Trim()+"'";
			else
				strSQL+=",PlanoA =null";

			if (strPlanoB.Trim()!="")                              
				strSQL+=",PlanoB ='" + strPlanoB.Trim()+"'";
			else
				strSQL+=",PlanoB =null";

			if (strPlanoC.Trim()!="")                              
				strSQL+=",PlanoC ='" + strPlanoC.Trim()+"'";
			else
				strSQL+=",PlanoC =null";

			if (strPlanoD.Trim()!="")                              
				strSQL+=",PlanoD ='" + strPlanoD.Trim()+"'";
			else
				strSQL+=",PlanoD =null";

			strSQL+=",idFoto =" + intConFoto;
						
			strSQL = strSQL + " WHERE idInforme =  " + idInforme.ToString();
			try
			{
				OdbcCommand myCommand = new OdbcCommand(strSQL, oConnection);
				myCommand.ExecuteNonQuery();

				int MaxID = idInforme;

				String strAuditoria = "INSERT INTO HistoricoAcciones (idCliente, idUsuario, Instante, Evento, Observaciones, idTipoObjeto, idEstado, idReferencia) VALUES (";
				strAuditoria = strAuditoria + intIdCliente + "," + intIdUsuario + ", getdate(), 'Modificación de Informe', 'Modificación de Informe', 1" + ", 5," + MaxID.ToString() + ")";

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

		#region TraerCampo(int tipo)

		public DataTable TraerCampo(int tipo)
		{
			OdbcConnection oConnection = this.OpenConnection();
			DataSet ds = new DataSet();
			OdbcDataAdapter myConsulta = new OdbcDataAdapter("select id, descripcion from Campo Where idGrupo = " + tipo + "", oConnection);
			myConsulta.Fill(ds);
			try
			{
				oConnection.Close();
			}
			catch
			{
			}

			return ds.Tables[0];

		}

		#endregion

		#region cargarVerifDomComercial(int idInforme)

		public bool cargarVerifDomComercial(int idInforme)
		{
			OdbcConnection oConnection = this.OpenConnection();
			DataSet ds = new DataSet();
			String strSQL = "SELECT * FROM VerifDomComercial ";
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

			if (ds.Tables[0].Rows.Count == 0)
				return false;

			intIdInforme = int.Parse(ds.Tables[0].Rows[0]["IdInforme"].ToString());
			intIdTipoPersona = int.Parse(ds.Tables[0].Rows[0]["IdTipoPersona"].ToString());
			strNombre = ds.Tables[0].Rows[0]["Nombre"].ToString();
			strApellido = ds.Tables[0].Rows[0]["Apellido"].ToString();
			intTipoDocumento = int.Parse(ds.Tables[0].Rows[0]["idTipoDoc"].ToString());
			strDocumento = ds.Tables[0].Rows[0]["NroDoc"].ToString();
			strNombreFantasia = ds.Tables[0].Rows[0]["NombreFantasia"].ToString();
			strRazonSocial = ds.Tables[0].Rows[0]["RazonSocial"].ToString();
			strRubro = ds.Tables[0].Rows[0]["Rubro"].ToString();
			strCuit = ds.Tables[0].Rows[0]["Cuit"].ToString();
			strCalle = ds.Tables[0].Rows[0]["Calle"].ToString();
			strBarrio = ds.Tables[0].Rows[0]["Barrio"].ToString();
			strNro = ds.Tables[0].Rows[0]["CalleNro"].ToString();
			strPiso = ds.Tables[0].Rows[0]["Piso"].ToString();
			strDepto = ds.Tables[0].Rows[0]["Depto"].ToString();
			strCP = ds.Tables[0].Rows[0]["CP"].ToString();
			intIdProvincia = int.Parse(ds.Tables[0].Rows[0]["Provincia"].ToString());
			intIdLocalidad = int.Parse(ds.Tables[0].Rows[0]["Localidad"].ToString());
			strTelefono = ds.Tables[0].Rows[0]["Telefono"].ToString();
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

			strFecha = ds.Tables[0].Rows[0]["FechaVerificacion"].ToString();
			strOcupacion = ds.Tables[0].Rows[0]["Ocupacion"].ToString();
			strCategoria = ds.Tables[0].Rows[0]["CatAutonomo"].ToString();
			strMovComercial = ds.Tables[0].Rows[0]["MovComercial"].ToString();
			strActividad = ds.Tables[0].Rows[0]["ActividadPrincipal"].ToString();
			strRubrosAdicionales = ds.Tables[0].Rows[0]["RubrosAdicionales"].ToString();
			strHorario = ds.Tables[0].Rows[0]["HorarioAtencion"].ToString();
			strAntiguedad = ds.Tables[0].Rows[0]["AntiguedadDom"].ToString();
			strCantPersonal = ds.Tables[0].Rows[0]["CantPersonal"].ToString();
			intCaractZona = int.Parse(ds.Tables[0].Rows[0]["idZona"].ToString());
			intDocVerificado = int.Parse(ds.Tables[0].Rows[0]["idDocumentoVerificado"].ToString());
			intUbicacion = int.Parse(ds.Tables[0].Rows[0]["idUbicacion"].ToString());
			intTamLocal = int.Parse(ds.Tables[0].Rows[0]["idTamanioLocal"].ToString());
			intInmueble = int.Parse(ds.Tables[0].Rows[0]["idInmueble"].ToString());
			intEstado = int.Parse(ds.Tables[0].Rows[0]["idEstadoConservacion"].ToString());
			intPublicidad = int.Parse(ds.Tables[0].Rows[0]["Publicidad"].ToString());
			intVigilancia = int.Parse(ds.Tables[0].Rows[0]["Vigilancia"].ToString());
			strFechaInicio = ds.Tables[0].Rows[0]["FechaInicio"].ToString();
			strCatIVA = ds.Tables[0].Rows[0]["CatIVA"].ToString();
			strInformo = ds.Tables[0].Rows[0]["Informo"].ToString();
			strCargo = ds.Tables[0].Rows[0]["Cargo"].ToString();
			strNombreVecino = ds.Tables[0].Rows[0]["VecinalNombre"].ToString();
			strDomicilioVecino = ds.Tables[0].Rows[0]["VecinalDomicilio"].ToString();
			strConoceVecino = ds.Tables[0].Rows[0]["VecinalConoce"].ToString();
			strObservaciones = ds.Tables[0].Rows[0]["Observaciones"].ToString();
			strPlanoA = ds.Tables[0].Rows[0]["PlanoA"].ToString();
			strPlanoB = ds.Tables[0].Rows[0]["PlanoB"].ToString();
			strPlanoC = ds.Tables[0].Rows[0]["PlanoC"].ToString();
			strPlanoD = ds.Tables[0].Rows[0]["PlanoD"].ToString();
			if (ds.Tables[0].Rows[0]["idFoto"].ToString() != "")
				intConFoto = int.Parse(ds.Tables[0].Rows[0]["idFoto"].ToString());

			return true;
		}

		#endregion

		#endregion

		#region Métodos Privados

		# region ObtenerMaxID(string strMaxID, OdbcConnection oConnection)

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