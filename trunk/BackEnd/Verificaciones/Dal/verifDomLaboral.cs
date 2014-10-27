using System;
using System.Data;
using System.Data.Odbc;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;

namespace ar.com.TiempoyGestion.BackEnd.Verificaciones.Dal
{
	/// <summary>
	/// Summary description for ClienteDal.
	/// </summary>
	public class VerifDomLaboralApp : GenericDal
	{
		#region Atributos y Contructores
			
		private int intIdCliente;
		private int intIdUsuario;
		private int intIdInforme;
		private string strNombre;
		private string strApellido;
		private int intTipoDocumento;
		private string strDocumento;
		private int intEstadoCivil;
		private string strNombreFantasia;
		private string strRazonSocial;
		private string strRubro;
		private string strCuit;
		private string strCalle;
		private string strBarrio;
		private string strNro;
		private string strPiso;
		private string strDepto;
		private string strCP;
		private int intIdLocalidad;
		private int intIdProvincia;
		private string strTelefono;
		private string strFecha; 
		private string strOcupacion;
		private string strCargo;
		private string strAntiguedad;
		private string strFechaFinalizacion;
		private string strSueldo;
		private string strAFavor;
		private int intTrabajaLugar;
		private int intPermanente;
		private int intContratado;
		private int intEmbargos;
		private int intUbicacion;
		private int intZona;
		private string strInformo;
		private string strCargoInformo;
		private string strNombreVecino;
		private string strDomicilioVecino;
		private string strConoceVecino;
		private string strInformesAnteriores;
        private string strObservaciones;		

		public VerifDomLaboralApp() : base()
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


		public string NombreFantasia
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

		public string RazonSocial
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

		public string Rubro
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


		public string Telefono
		{
			get
			{
				return strTelefono;
			}
			set
			{
				strTelefono = value;
			}
		}

		public string Fecha
		{
			get
			{
				return strFecha;
			}
			set
			{
				strFecha = value;
			}
		}

		public string Ocupacion
		{
			get
			{
				return strOcupacion;
			}
			set
			{
				strOcupacion = value;
			}
		}

		public string Cargo
		{
			get
			{
				return strCargo;
			}
			set
			{
				strCargo = value;
			}
		}

		public string Antiguedad
		{
			get
			{
				return strAntiguedad;
			}
			set
			{
				strAntiguedad = value;
			}
		}

		public string FechaFinalizacion
		{
			get
			{
				return strFechaFinalizacion;
			}
			set
			{
				strFechaFinalizacion = value;
			}
		}

		public string Sueldo
		{
			get
			{
				return strSueldo;
			}
			set
			{
				strSueldo = value;
			}
		}

		public string AFavor
		{
			get
			{
				return strAFavor;
			}
			set
			{
				strAFavor = value;
			}
		}

		public int TrabajaLugar
		{
			get
			{
				return intTrabajaLugar;
			}
			set
			{
				intTrabajaLugar = value;
			}
		}

		public int Permanente
		{
			get
			{
				return intPermanente;
			}
			set
			{
				intPermanente = value;
			}
		}

		public int Contratado
		{
			get
			{
				return intContratado;
			}
			set
			{
				intContratado = value;
			}
		}

		public int Embargos
		{
			get
			{
				return intEmbargos;
			}
			set
			{
				intEmbargos = value;
			}
		}

		public int Ubicacion
		{
			get
			{
				return intUbicacion;
			}
			set
			{
				intUbicacion = value;
			}
		}

		public int Zona
		{
			get
			{
				return intZona;
			}
			set
			{
				intZona = value;
			}
		}


		public string Informo
		{
			get
			{
				return strInformo;
			}
			set
			{
				strInformo = value;
			}
		}

		public string CargoInformo
		{
			get
			{
				return strCargoInformo;
			}
			set
			{
				strCargoInformo = value;
			}
		}

		public string NombreVecino
		{
			get
			{
				return strNombreVecino;
			}
			set
			{
				strNombreVecino = value;
			}
		}

		public string DomicilioVecino
		{
			get
			{
				return strDomicilioVecino;
			}
			set
			{
				strDomicilioVecino = value;
			}
		}

		public string ConoceVecino
		{
			get
			{
				return strConoceVecino;
			}
			set
			{
				strConoceVecino = value;
			}
		}

		public string InformesAnteriores
		{
			get
			{
				return strInformesAnteriores;
			}
			set
			{
                strInformesAnteriores = value;
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
			string ConvFecha = "";
			string ConvFechaFin = "";

			if(strFecha != "")
			{
				//string[] fecha = strFecha.Split("/".ToCharArray());
				//ConvFecha = fecha[2] + "/" + fecha[1] + "/" + fecha[0];
                ConvFecha = strFecha;
			}

			if(strFechaFinalizacion != "")
			{
				//string[] fechaFin = strFechaFinalizacion.Split("/".ToCharArray());
				//ConvFechaFin = fechaFin[2] + "/" + fechaFin[1] + "/" + fechaFin[0];
                ConvFechaFin = strFechaFinalizacion;
			}

			OdbcConnection oConnection = this.OpenConnection();
			// Creando Consulta a Realizar
			String strSQL="INSERT INTO verifDomLaboral (IdInforme, Nombre, Apellido, ";
				   strSQL+="idTipoDoc, NroDoc, idEstadoCivil, NombreFantasia, RazonSocial, ";
				   strSQL+="Rubro, Cuit, Calle, Barrio, CalleNro, Piso, Depto, CP, ";
				   strSQL+="idLocalidad, Telefono, FechaVerificacion, Ocupacion, Cargo, ";
                   strSQL+="Antiguedad, FechaFinalizacion, Sueldo, AFavor, TrabajaLugar, ";
                   strSQL+="Permanente, Contratado, Embargos, idUbicacion, idZona, Informo, ";
				   strSQL+="Relacion, VecinalNombre, VecinalDomicilio, VecinalConoce, InformesAnteriores, Observaciones) "; 
				   strSQL+="VALUES (" + intIdInforme;
			
			// DATOS PERSONALES //
                   if (strNombre.Trim() != "") strSQL += ",'" + strNombre.Trim().Replace("'", "''") + "'"; 
			else strSQL+=",null";

                   if (strApellido.Trim() != "") strSQL += ",'" + strApellido.Trim().Replace("'", "''") + "'"; 
			else strSQL+=",null";

			strSQL+="," + intTipoDocumento;

			if (strDocumento.Trim() != "") strSQL+=",'"+strDocumento.Trim()+"'"; 
			else strSQL+=",null";
			
			strSQL+="," + intEstadoCivil;
			
			// DATOS DE LA EMPRESA //
            if (strNombreFantasia.Trim() != "") strSQL += ",'" + strNombreFantasia.Trim().Replace("'", "''") + "'"; 
			else strSQL+=",null";

            if (strRazonSocial.Trim() != "") strSQL += ",'" + strRazonSocial.Trim().Replace("'", "''") + "'"; 
			else strSQL+=",null";
			
			if (strRubro.Trim() != "") strSQL+=",'"+strRubro.Trim()+"'"; 
			else strSQL+=",null";
 
			if (strCuit.Trim() != "") strSQL+=",'"+strCuit.Trim()+"'"; 
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

			strSQL+="," + intIdLocalidad; 

			if (strTelefono.Trim() != "") strSQL+=",'"+strTelefono.Trim()+"'"; 
			else strSQL+=",null";
			
			// EMPRESA DONDE TRABAJA //
			if (ConvFecha.Trim() != "") strSQL+=",'"+ConvFecha.Trim()+"'"; 
			else strSQL+=",null";

			if (strOcupacion.Trim() != "") strSQL+=",'"+strOcupacion.Trim()+"'"; 
			else strSQL+=",null";

			if (strCargo.Trim() != "") strSQL+=",'"+strCargo.Trim()+"'"; 
			else strSQL+=",null";

            if (strAntiguedad.Trim() != "") strSQL += ",'" + strAntiguedad.Trim()+ "'"; 
			else strSQL+=",null";

			if (ConvFechaFin.Trim() != "") strSQL+=",'"+ConvFechaFin.Trim()+"'"; 
			else strSQL+=",null";

			if (strSueldo.Trim() != "") strSQL+=",'"+strSueldo.Trim()+"'"; 
			else strSQL+=",null";

			if (strAFavor.Trim() != "") strSQL+=",'"+strAFavor.Trim()+"'"; 
			else strSQL+=",null";

            strSQL+="," + intTrabajaLugar;
		    strSQL+="," + intPermanente;
		    strSQL+="," + intContratado;
   			strSQL+="," + intEmbargos;
		    strSQL+="," + intUbicacion;
		    strSQL+="," + intZona;

			if (strInformo.Trim() != "") strSQL+=",'"+strInformo.Trim()+"'"; 
			else strSQL+=",null";

			if (strCargoInformo.Trim() != "") strSQL+=",'"+strCargoInformo.Trim()+"'"; 
			else strSQL+=",null";

			// REFERENCIA VECINAL //
			if (strNombreVecino.Trim() != "") strSQL+=",'"+strNombreVecino.Trim()+"'"; 
			else strSQL+=",null";

			if (strDomicilioVecino.Trim() != "") strSQL+=",'"+strDomicilioVecino.Trim()+"'";  
			else strSQL+=",null";

			if (strConoceVecino.Trim() != "") strSQL+=",'"+strConoceVecino.Trim()+"'"; 
			else strSQL+=",null";

            if (strInformesAnteriores.Trim() != "") strSQL += ",'" + strInformesAnteriores.Trim().Replace("'", "''") + "'";
            else strSQL += ",null";

            if (strObservaciones.Trim() != "") strSQL += ",'" + strObservaciones.Trim().Replace("'", "''") + "')"; 
			else strSQL+=",null)";
			
			String strMaxID = "SELECT MAX(idInforme) AS MaxId FROM verifDomLaboral";

			try
			{
				OdbcCommand	myCommand = new OdbcCommand(strSQL, oConnection);
				myCommand.ExecuteNonQuery();

				int MaxID = ObtenerMaxID(strMaxID, oConnection); 

				String strAuditoria = "INSERT INTO HistoricoAcciones (idCliente, idUsuario, Instante, Evento, Observaciones, idTipoObjeto, idEstado, idReferencia) VALUES (";
				strAuditoria = strAuditoria  + intIdCliente + "," + intIdUsuario  + ", getdate(), 'Crear verificación de domicilio Laboral', 'Solicitud de verificación de domicilio Laboral', 1" + ", 1," + MaxID.ToString() + ")";

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
			string ConvFechaFin = "";

			if(strFecha != "")
			{
				//string[] fecha = strFecha.Split("/".ToCharArray());
				//ConvFecha = fecha[2] + "/" + fecha[1] + "/" + fecha[0];
                ConvFecha = strFecha;
			}

			if(strFechaFinalizacion != "")
			{
				//string[] fechaFin = strFechaFinalizacion.Split("/".ToCharArray());
				//ConvFechaFin = fechaFin[2] + "/" + fechaFin[1] + "/" + fechaFin[0];
                ConvFechaFin = strFechaFinalizacion;
			}
			
			OdbcConnection oConnection = this.OpenConnection();
			
			// Armando Consulta a realizar...
			String strSQL = "UPDATE verifDomLaboral SET ";

			// DATOS PERSONALES //			
			if (strNombre.Trim()!="")                        
				strSQL+="Nombre ='" + strNombre.Trim()+"'";
			else
				strSQL+="Nombre =null";
			
			if (strApellido.Trim()!="")
                strSQL += ",Apellido ='" + strApellido.Trim().Replace("'", "''") + "'";
			else
				strSQL+=",Apellido =null";
			
			strSQL+=",idTipoDoc="+ intTipoDocumento;         

			if (strDocumento.Trim()!="")                     
				strSQL+=",NroDoc ='" + strDocumento.Trim()+"'";
			else
				strSQL+=",NroDoc =null";
			
			strSQL+=",idEstadoCivil="+ intEstadoCivil;  
     
			// DATOS DE LA EMPRESA //
			if (strNombreFantasia.Trim()!="")
                strSQL += ",NombreFantasia ='" + strNombreFantasia.Trim().Replace("'", "''") + "'";
			else
				strSQL+=",NombreFantasia =null";

			if (strRazonSocial.Trim()!="")
                strSQL += ",RazonSocial ='" + strRazonSocial.Trim().Replace("'", "''") + "'";
			else
				strSQL+=",RazonSocial =null";
			
			if (strRubro.Trim()!="")                            
				strSQL+=",Rubro ='" + strRubro.Trim()+"'";
			else
				strSQL+=",Rubro =null";

			if (strCuit.Trim()!="")                             
				strSQL+=",Cuit ='" + strCuit.Trim()+"'";
			else
				strSQL+=",Cuit =null";

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
			
			strSQL+=",idLocalidad =" + intIdLocalidad; 
			
			if (strTelefono.Trim()!="")                        
				strSQL+=",Telefono ='" + strTelefono.Trim()+"'";
			else
				strSQL+=",Telefono =null";
			
			// EMPRESA DONDE TRABAJA //
			if (ConvFecha.Trim()!="")                        
				strSQL+=",FechaVerificacion ='" + ConvFecha.Trim()+"'";
			else
				strSQL+=",FechaVerificacion =null";

			if (strOcupacion.Trim()!="")                        
				strSQL+=",Ocupacion ='" + strOcupacion.Trim()+"'";
			else
				strSQL+=",Ocupacion =null";

			if (strCargo.Trim()!="")                        
				strSQL+=",Cargo ='" + strCargo.Trim()+"'";
			else
				strSQL+=",Cargo =null";

			if (strAntiguedad.Trim()!="")                        
				strSQL+=",Antiguedad ='" + strAntiguedad.Trim()+"'";
			else
				strSQL+=",Antiguedad =null";

			if (ConvFechaFin.Trim()!="")                        
				strSQL+=",FechaFinalizacion ='" + ConvFechaFin.Trim()+"'";
			else
				strSQL+=",FechaFinalizacion =null";

			if (strSueldo.Trim()!="")                        
				strSQL+=",Sueldo ='" + strSueldo.Trim()+"'";
			else
				strSQL+=",Sueldo =null";

			if (strAFavor.Trim()!="")                        
				strSQL+=",AFavor ='" + strAFavor.Trim()+"'";
			else
				strSQL+=",AFavor =null";

            strSQL+=",TrabajaLugar =" + intTrabajaLugar;
		    strSQL+=",Permanente =" + intPermanente;
		    strSQL+=",Contratado =" + intContratado;
            strSQL+=",Embargos =" + intEmbargos;
    	    strSQL+=",idUbicacion =" + intUbicacion;
   			strSQL+=",idZona =" + intZona; 

			if (strInformo.Trim()!="")                        
				strSQL+=",Informo ='" + strInformo.Trim()+"'";
			else
				strSQL+=",Informo =null";

			if (strCargoInformo.Trim()!="")                        
				strSQL+=",Relacion ='" + strCargoInformo.Trim()+"'";
			else
				strSQL+=",Relacion =null";
			
			// REFERENCIA VECINAL //
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

            if (strInformesAnteriores.Trim() != "")
                strSQL += ",InformesAnteriores ='" + strInformesAnteriores.Trim().Replace("'", "''") + "'";
            else
                strSQL += ",InformesAnteriores =null";

            if (strObservaciones.Trim()!="")
                strSQL += ",Observaciones ='" + strObservaciones.Trim().Replace("'", "''") + "'";
			else
				strSQL+=",Observaciones =null";

			
			strSQL+= " WHERE idInforme =  " + idInforme.ToString();

			try
			{
				OdbcCommand	myCommand = new OdbcCommand(strSQL, oConnection);
				myCommand.ExecuteNonQuery();

				int MaxID = idInforme; 

				String strAuditoria = "INSERT INTO HistoricoAcciones (idCliente, idUsuario, Instante, Evento, Observaciones, idTipoObjeto, idEstado, idReferencia) VALUES (";
				strAuditoria = strAuditoria  + intIdCliente + "," + intIdUsuario  + ", getdate(), 'Modificación de Informe', 'Modificación de Informe', 1" + ", 5," + MaxID.ToString() + ")";

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
			catch {}

			return ds.Tables[0];

		}

		#endregion

		#region cargarVerifDomLaboral(int idInforme)

		public bool cargarVerifDomLaboral(int idInforme)
		{
			
			OdbcConnection oConnection = this.OpenConnection();
			DataSet ds = new DataSet();
			String strSQL = "SELECT * FROM verifDomLaboral ";
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
			strNombreFantasia = ds.Tables[0].Rows[0]["NombreFantasia"].ToString();
			strRazonSocial = ds.Tables[0].Rows[0]["RazonSocial"].ToString();
			strDocumento = ds.Tables[0].Rows[0]["NroDoc"].ToString();
			intEstadoCivil = int.Parse(ds.Tables[0].Rows[0]["idEstadoCivil"].ToString());
			strRubro = ds.Tables[0].Rows[0]["Rubro"].ToString();
			strCuit = ds.Tables[0].Rows[0]["Cuit"].ToString();
			strCalle = ds.Tables[0].Rows[0]["Calle"].ToString();
			strBarrio = ds.Tables[0].Rows[0]["Barrio"].ToString();
			strNro = ds.Tables[0].Rows[0]["CalleNro"].ToString();
			strPiso = ds.Tables[0].Rows[0]["Piso"].ToString();
			strDepto = ds.Tables[0].Rows[0]["Depto"].ToString();
			strCP = ds.Tables[0].Rows[0]["CP"].ToString();
			intIdLocalidad = int.Parse(ds.Tables[0].Rows[0]["idLocalidad"].ToString());
			//intIdProvincia = int.Parse(ds.Tables[0].Rows[0]["idProvincia"].ToString());
			strTelefono = ds.Tables[0].Rows[0]["Telefono"].ToString();
			strFecha = ds.Tables[0].Rows[0]["FechaVerificacion"].ToString();
			strOcupacion = ds.Tables[0].Rows[0]["Ocupacion"].ToString();
			strCargo = ds.Tables[0].Rows[0]["Cargo"].ToString();
			strAntiguedad = ds.Tables[0].Rows[0]["Antiguedad"].ToString();
			strFechaFinalizacion = ds.Tables[0].Rows[0]["FechaFinalizacion"].ToString();
			strSueldo = ds.Tables[0].Rows[0]["Sueldo"].ToString();
			strAFavor = ds.Tables[0].Rows[0]["AFavor"].ToString();
			intTrabajaLugar = int.Parse(ds.Tables[0].Rows[0]["TrabajaLugar"].ToString());
			intPermanente = int.Parse(ds.Tables[0].Rows[0]["Permanente"].ToString());
			intContratado = int.Parse(ds.Tables[0].Rows[0]["Contratado"].ToString());
			intEmbargos = int.Parse(ds.Tables[0].Rows[0]["Embargos"].ToString());
			intUbicacion = int.Parse(ds.Tables[0].Rows[0]["idUbicacion"].ToString());
			intZona = int.Parse(ds.Tables[0].Rows[0]["idZona"].ToString());
			strInformo = ds.Tables[0].Rows[0]["Informo"].ToString();
			strCargoInformo = ds.Tables[0].Rows[0]["Relacion"].ToString();
			strNombreVecino = ds.Tables[0].Rows[0]["VecinalNombre"].ToString();
			strDomicilioVecino = ds.Tables[0].Rows[0]["VecinalDomicilio"].ToString();
			strConoceVecino = ds.Tables[0].Rows[0]["VecinalConoce"].ToString();
            strInformesAnteriores = ds.Tables[0].Rows[0]["InformesAnteriores"].ToString();
			strObservaciones = ds.Tables[0].Rows[0]["Observaciones"].ToString();
						
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
