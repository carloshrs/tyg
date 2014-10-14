using System;
using System.Data;
using System.Data.Odbc;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;

namespace ar.com.TiempoyGestion.BackEnd.Verificaciones.Dal
{
	/// <summary>
    /// Summary description for AmbientalBancorApp.
	/// </summary>
	public class AmbientalBancorApp : GenericDal
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
		private string strTelefono;
		private int intIdTipoPersona;

		private string strFecha; 
		private string strHabita;
		private string strAntiguedad;
		private string strTelAlternativo;
        private string strEmail;
        private string strRelacionTitular;
		private int intTipoVivienda;
		private int intEstadoCons;
		private int intTipoConstruccion;
		private int intTipoZona;
		private int intDestino;
		private int intInteresado;
		private string strAccesoDomicilio;
		private string strInformo;
		private string strRelacion;
		private string strNombreVecino;
		private string strDomicilioVecino;
		private string strConoceVecino;
        private string strNombreVecino2;
        private string strDomicilioVecino2;
        private string strConoceVecino2;
		private string strObservaciones;
		private string strPlanoA;
		private string strPlanoB;
		private string strPlanoC;
		private string strPlanoD;
		private int intConFoto;
        private int intResultado;

		public AmbientalBancorApp() : base()
		{}

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

		public string Habita
		{
			get
			{
				return strHabita;
			}
			set
			{
				strHabita = value;
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


		public string TelAlternativo
		{
			get
			{
				return strTelAlternativo;
			}
			set
			{
				strTelAlternativo = value;
			}
		}

        public string Email
        {
            get
            {
                return strEmail;
            }
            set
            {
                strEmail = value;
            }
        }

        public string RelacionTitular
        {
            get
            {
                return strRelacionTitular;
            }
            set
            {
                strRelacionTitular = value;
            }
        }

		public int TipoVivienda
		{
			get
			{
				return intTipoVivienda;
			}
			set
			{
				intTipoVivienda = value;
			}
		}

		public int EstadoCons
		{
			get
			{
				return intEstadoCons;
			}
			set
			{
				intEstadoCons = value;
			}
		}

		public int TipoConstruccion
		{
			get
			{
				return intTipoConstruccion;
			}
			set
			{
				intTipoConstruccion = value;
			}
		}

		public int TipoZona
		{
			get
			{
				return intTipoZona;
			}
			set
			{
				intTipoZona = value;
			}
		}

		public int Destino
		{
			get
			{
				return intDestino;
			}
			set
			{
				intDestino = value;
			}
		}

		public int Interesado
		{
			get
			{
				return intInteresado;
			}
			set
			{
				intInteresado = value;
			}
		}


		public string AccesoDomicilio
		{
			get
			{
				return strAccesoDomicilio;
			}
			set
			{
				strAccesoDomicilio = value;
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

		public string Relacion
		{
			get
			{
				return strRelacion;
			}
			set
			{
				strRelacion = value;
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
        public string NombreVecino2
        {
            get
            {
                return strNombreVecino2;
            }
            set
            {
                strNombreVecino2 = value;
            }
        }

        public string DomicilioVecino2
        {
            get
            {
                return strDomicilioVecino2;
            }
            set
            {
                strDomicilioVecino2 = value;
            }
        }

        public string ConoceVecino2
        {
            get
            {
                return strConoceVecino2;
            }
            set
            {
                strConoceVecino2 = value;
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

		public string PlanoA
		{
			get
			{
				return strPlanoA;
			}
			set
			{
				strPlanoA = value;
			}
		}

		public string PlanoB
		{
			get
			{
				return strPlanoB;
			}
			set
			{
				strPlanoB = value;
			}
		}

		public string PlanoC
		{
			get
			{
				return strPlanoC;
			}
			set
			{
				strPlanoC = value;
			}
		}

		public string PlanoD
		{
			get
			{
				return strPlanoD;
			}
			set
			{
				strPlanoD = value;
			}
		}
		
		public int ConFoto
		{
			get
			{
				return intConFoto;
			}
			set
			{
				intConFoto = value;
			}
		}

        public int Resultado
        {
            get
            {
                return intResultado;
            }
            set
            {
                intResultado = value;
            }
        }


		#endregion

		#region Métodos Publicos
	
		#region Crear()

		public bool Crear()
		{
			string ConvFecha = "";

			if(strFecha.Trim() != "")
			{
				//string[] fecha = strFecha.Split("/".ToCharArray());
				//ConvFecha = fecha[2] + "/" + fecha[1] + "/" + fecha[0];
                ConvFecha = strFecha;
			}

			
			OdbcConnection oConnection = this.OpenConnection();

			// Armando Consulta a realizar...
			String strSQL ="";
			strSQL+="Insert into ambientalbancor (IdInforme, IdTipoPersona, Nombre, Apellido, idTipoDoc, NroDoc, "+ 
			        "idEstadoCivil, Calle, Barrio, CalleNro, Piso, Depto, Lote, Manzana, CP, Complejo, Torre, IdLocalidad, IdProvincia, Telefono, "+
			        "FechaVerificacion, HabitaLugar, Antiguedad, Email, TelefonoAlt, RelacionTitular, "+
                    "idTipoVivienda, idDestino, idTipoConstruccion, idEstado, idTipoZona, " +
                    "idInteresado, AccesoDomicilio, Informo, Relacion, VecinalNombre, VecinalDomicilio, VecinalConoce, VecinalNombre2, VecinalDomicilio2, VecinalConoce2, " +
                    "Observaciones, PlanoA, PlanoB, PlanoC, PlanoD, idFoto, idResultado) ";

			// El id del Informe y la razón social de la empresa son los únicos valores que no admiten null
			// Y los valores que siempre voy a recibir son:
			// IdInforme, IdTipoPersona, nombre, apellido, TipoDocumento, documento, calle, Nro,
			// EstadoCivil, Localidad y Provincia de la persona, Localidad y Provincia de la empresa.
			
			// DATOS PERSONALES //
			strSQL+=" values ("+ intIdInforme +"," + intIdTipoPersona; 
			
			// DOMICILIO A VERIFICAR //

			if (strNombre.Trim() != "") strSQL+=",'"+strNombre.Trim() + "'"; // Nombre de la Persona
			else strSQL+=",null";

            if (strApellido.Trim() != "") strSQL += ",'" + strApellido.Trim().Replace("'", "''") + "'"; // Apellido de la Persona
			else strSQL+=",null";

			strSQL+="," + intTipoDocumento;

			if (strDocumento.Trim() != "") strSQL+=",'"+strDocumento.Trim() + "'"; // Documento de la Persona
			else strSQL+=",null";
			
			strSQL+="," + intEstadoCivil;

            if (strCalle.Trim() != "") strSQL += ",'" + strCalle.Trim().Replace("'", "''") + "'"; // Calle de la Persona
			else strSQL+=",null";

            if (strBarrio.Trim() != "") strSQL += ",'" + strBarrio.Trim().Replace("'", "''") + "'"; // Barrio de la Persona
			else strSQL+=",null";

			if (strNro.Trim() != "") strSQL+=",'"+strNro.Trim()+"'"; // Nro de calle de la Persona
			else strSQL+=",null";

			if (strPiso.Trim() != "") strSQL+=",'"+strPiso.Trim()+"'"; // Piso de la casa de la Persona
			else strSQL+=",null";

			if (strDepto.Trim() != "") strSQL+=",'"+strDepto.Trim()+"'"; // Depto de la Persona
			else strSQL+=",null";

			if (strLote.Trim() != "") strSQL+=",'"+strLote.Trim()+"'"; // Lote de la Persona
			else strSQL+=",null";

			if (strManzana.Trim() != "") strSQL+=",'"+strManzana.Trim()+"'"; // Depto de la Persona
			else strSQL+=",null";

			if (strCP.Trim() != "") strSQL+=",'"+strCP.Trim()+"'"; // Código Postal de la Persona
			else strSQL+=",null";

            if (strComplejo.Trim() != "") strSQL += ",'" + strComplejo.Trim() + "'"; // Complejo donde vive la Persona
            else strSQL += ",null";

            if (strTorre.Trim() != "") strSQL += ",'" + strTorre.Trim() + "'"; // Torre donde vive la Persona
            else strSQL += ",null";

            strSQL+="," + intIdLocalidad + "," + intIdProvincia; // Localidad y Provincia de la Persona
			
			if (strTelefono.Trim() != "") strSQL+=",'"+strTelefono+"'"; // Teléfono de la Persona
			else strSQL+=",null";
			
			
			// GESTION SOBRE LA VERIFICACION //
			if (ConvFecha.Trim() != "") strSQL+=",'"+ConvFecha.Trim()+"'"; // Fecha
			else strSQL+=",null";

			if (strHabita.Trim() != "") strSQL+=",'"+strHabita.Trim()+"'"; // Habita en lugar declarado
			else strSQL+=",null";

			if (strAntiguedad.Trim() != "") strSQL+=",'"+strAntiguedad.Trim()+"'"; // Antiguedad
			else strSQL+=",null";

            if (strEmail.Trim() != "") strSQL += ",'" + strEmail.Trim() + "'"; // Email
            else strSQL += ",null";

            if (strTelAlternativo.Trim() != "") strSQL+=",'"+strTelAlternativo.Trim()+"'"; // Teléfono alternativo
			else strSQL+=",null";

            if (strRelacionTitular.Trim() != "") strSQL += ",'" + strRelacionTitular.Trim() + "'"; // Relacion con titular
            else strSQL += ",null";

            // Datos de los radio Button's
			strSQL+=","+ intTipoVivienda +","+ intDestino +","+ intTipoConstruccion;
			strSQL+=","+ intEstadoCons +","+ intTipoZona +","+ intInteresado;

			if (strAccesoDomicilio.Trim() != "") strSQL+=",'"+strAccesoDomicilio.Trim()+"'"; // Acceso a domicilio
			else strSQL+=",null";

			if (strInformo.Trim() != "") strSQL+=",'"+strInformo.Trim()+"'"; // Informó
			else strSQL+=",null";

			if (strRelacion.Trim() != "") strSQL+=",'"+strRelacion.Trim()+"'"; // Relación
			else strSQL+=",null";

			// REFERENCIA VECINAL //
			if (strNombreVecino.Trim() != "") strSQL+=",'"+strNombreVecino.Trim()+"'"; // Apellido y Nombre del Vecino
			else strSQL+=",null";

			if (strDomicilioVecino.Trim() != "") strSQL+=",'"+strDomicilioVecino.Trim()+"'"; // Domicilio del Vecino
			else strSQL+=",null";

			if (strConoceVecino.Trim() != "") strSQL+=",'"+strConoceVecino.Trim()+"'"; // Conoce a la persona
			else strSQL+=",null";

            // REFERENCIA VECINAL 2 //
            if (strNombreVecino2.Trim() != "") strSQL += ",'" + strNombreVecino2.Trim() + "'"; // Apellido y Nombre del Vecino
            else strSQL += ",null";

            if (strDomicilioVecino2.Trim() != "") strSQL += ",'" + strDomicilioVecino2.Trim() + "'"; // Domicilio del Vecino
            else strSQL += ",null";

            if (strConoceVecino2.Trim() != "") strSQL += ",'" + strConoceVecino2.Trim() + "'"; // Conoce a la persona
            else strSQL += ",null";

			if (strObservaciones.Trim() != "") strSQL+=",'"+strObservaciones.Trim().Replace("'","''") +"'"; // Observaciones
			else strSQL+=",null";

			if (strPlanoA.Trim() != "") strSQL+=",'"+strPlanoA.Trim()+"'"; // Ubicación A
			else strSQL+=",null";

			if (strPlanoB.Trim() != "") strSQL+=",'"+strPlanoB.Trim()+"'"; // Ubicación B
			else strSQL+=",null";

			if (strPlanoC.Trim() != "") strSQL+=",'"+strPlanoC.Trim()+"'"; // Ubicación C
			else strSQL+=",null";

			if (strPlanoD.Trim() != "") strSQL+=",'"+strPlanoD.Trim()+"'"; // Ubicación D
			else strSQL+=",null";
			
			strSQL+=","+intConFoto+", " + intResultado + ")"; // Con Foto 0=No 1=Si
						
			String strMaxID = "SELECT MAX(idInforme) as MaxId FROM ambientalbancor";

			try
			{
				OdbcCommand	myCommand = new OdbcCommand(strSQL, oConnection);
				myCommand.ExecuteNonQuery();

				int MaxID = ObtenerMaxID(strMaxID, oConnection); 

				String strAuditoria = "INSERT INTO HistoricoAcciones (idCliente, idUsuario, Instante, Evento, Observaciones, idTipoObjeto, idEstado, idReferencia) VALUES (";
				strAuditoria = strAuditoria  + intIdCliente + "," + intIdUsuario  + ", getdate(), 'Crear ambiental Bancor', 'Solicitud de Relevamiento Ambiental BANCOR', 1" + ", 1," + MaxID.ToString() + ")";

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

			if(strFecha != "")
			{
				//string[] fecha = strFecha.Split("/".ToCharArray());
				//ConvFecha = fecha[2] + "/" + fecha[1] + "/" + fecha[0];
                ConvFecha = strFecha;
			}


			OdbcConnection oConnection = this.OpenConnection();
			
			// El id del Informe y la razón social de la empresa son los únicos valores que no admiten null
			// Y los valores que siempre voy a recibir son:
			// IdInforme, IdTipoPersona, nombre, apellido, TipoDocumento, documento, calle, Nro,
			// EstadoCivil, Localidad y Provincia de la persona, Localidad y Provincia de la empresa.

			// Armando Consulta a realizar...
			String strSQL = "UPDATE ambientalbancor SET ";

			// DATOS PERSONALES //
			strSQL+="IdTipoPersona="+ intIdTipoPersona;      // El tipo de Persona 

			if (strNombre.Trim()!="")                        // Nombre
				strSQL+=",Nombre ='" + strNombre.Trim()+"'";
			else
				strSQL+=",Nombre =null";
			
			if (strApellido.Trim()!="")                      // Apellido
                strSQL += ",Apellido ='" + strApellido.Trim().Replace("'", "''") + "'";
			else
				strSQL+=",Apellido =null";
			
			strSQL+=",idTipoDoc="+ intTipoDocumento;         // Tipo de Documento

			if (strDocumento.Trim()!="")                     // Nro de Documento
				strSQL+=",NroDoc ='" + strDocumento.Trim()+"'";
			else
				strSQL+=",NroDoc =null";
			
			strSQL+=",idEstadoCivil="+ intEstadoCivil;       // Estado Civil

			// DOMICILIO A VERIFICAR //
			if (strCalle.Trim()!="")                            // Calle de la Persona
                strSQL += ",Calle ='" + strCalle.Trim().Replace("'", "''") + "'";
			else
				strSQL+=",Calle =null";
			
			if (strBarrio.Trim()!="")                           // Barrio de la Persona
                strSQL += ",Barrio ='" + strBarrio.Trim().Replace("'", "''") + "'";
			else
				strSQL+=",Barrio =null";

			if (strNro.Trim()!="")                         // Nro de calle de la Persona
				strSQL+=",CalleNro ='" + strNro.Trim()+"'";
			else
				strSQL+=",CalleNro =null";

			if (strPiso.Trim()!="")                             // Piso de la casa de la Persona
				strSQL+=",Piso ='" + strPiso.Trim()+"'";
			else
				strSQL+=",Piso =null";

			if (strDepto.Trim()!="")                            // Depto de la Persona
				strSQL+=",Depto ='" + strDepto.Trim()+"'";
			else
				strSQL+=",Depto =null";

            if (strLote.Trim() != "")                            // Lote de la Persona
                strSQL += ",Lote ='" + strLote.Trim() + "'";
            else
                strSQL += ",Lote =null";

            if (strManzana.Trim() != "")                            // Manzana de la Persona
                strSQL += ",Manzana ='" + strManzana.Trim() + "'";
            else
                strSQL += ",Manzana =null";

            if (strCP.Trim()!="")                               // Código Postal de la Persona
				strSQL+=",CP ='" + strCP.Trim()+"'";
			else
				strSQL+=",CP =null";

            if (strComplejo.Trim() != "")                            // Complejo donde vive la Persona
                strSQL += ",Complejo ='" + strComplejo.Trim() + "'";
            else
                strSQL += ",Complejo =null";

            if (strTorre.Trim() != "")                            // Torre donde vive la Persona
                strSQL += ",Torre ='" + strTorre.Trim() + "'";
            else
                strSQL += ",Torre =null";

			strSQL+=",idLocalidad =" + intIdLocalidad;		 // Localidad de la Persona				
			strSQL+=",idProvincia =" + intIdProvincia;       // Provincia de la Persona
			
			if (strTelefono.Trim()!="")                         // Teléfono de la Persona
				strSQL+=",Telefono ='" + strTelefono.Trim()+"'";
			else
				strSQL+=",Telefono =null";

			// GESTION SOBRE LA VERIFICACION //
			if (ConvFecha.Trim()!="")                    // Fecha    
				strSQL+=",FechaVerificacion ='" + ConvFecha.Trim()+"'";
			else
				strSQL+=",FechaVerificacion =null";

			if (strHabita.Trim()!="")                          // Habita en lugar declarado
				strSQL+=",HabitaLugar ='" + strHabita.Trim()+"'";
			else
				strSQL+=",HabitaLugar =null";

			if (strAntiguedad.Trim()!="")                           // Antiguedad
				strSQL+=",Antiguedad ='" + strAntiguedad.Trim()+"'";
			else
				strSQL+=",Antiguedad =null";

			if (strTelAlternativo.Trim()!="")                          // Teléfono alternativo
				strSQL+=",TelefonoAlt ='" + strTelAlternativo.Trim()+"'";
			else
				strSQL+=",TelefonoAlt =null";

            if (strEmail.Trim() != "")                          // Email
                strSQL += ",Email ='" + strEmail.Trim() + "'";
            else
                strSQL += ",Email =null";

            if (strRelacionTitular.Trim() != "")                          // Relación titular
                strSQL += ",RelacionTitular ='" + strRelacionTitular.Trim() + "'";
            else
                strSQL += ",RelacionTitular =null";

            strSQL+=",idTipoVivienda =" + intTipoVivienda;		   // Tipo de Vivienda
			strSQL+=",idEstado =" + intEstadoCons;                 // Estado de Conservación
			strSQL+=",idTipoConstruccion =" + intTipoConstruccion; // Tipo de Construcción
			strSQL+=",idTipoZona =" + intTipoZona;				   // Tipo de Zona	 
			strSQL+=",idDestino =" + intDestino;               // Destino
			strSQL+=",idInteresado =" + intInteresado;             // Vive en caracter de 

			if (strAccesoDomicilio.Trim()!="")                      // Acceso a domicilio   
				strSQL+=",AccesoDomicilio ='" + strAccesoDomicilio.Trim()+"'";
			else
				strSQL+=",AccesoDomicilio =null";

			if (strInformo.Trim()!="")                              // Informó
				strSQL+=",Informo ='" + strInformo.Trim()+"'";
			else
				strSQL+=",Informo =null";

			if (strRelacion.Trim()!="")                             // Relación
				strSQL+=",Relacion ='" + strRelacion.Trim()+"'";
			else
				strSQL+=",Relacion =null";

			// REFERENCIA VECINAL //
			if (strNombreVecino.Trim()!="")                        // Apellido y Nombre del Vecino     
				strSQL+=",VecinalNombre ='" + strNombreVecino.Trim()+"'";
			else
				strSQL+=",VecinalNombre =null";

			if (strDomicilioVecino.Trim()!="")                     // Domicilio del Vecino        
				strSQL+=",VecinalDomicilio ='" + strDomicilioVecino.Trim()+"'";
			else
				strSQL+=",VecinalDomicilio =null";

			if (strConoceVecino.Trim()!="")                        // Conoce a la persona     
				strSQL+=",VecinalConoce ='" + strConoceVecino.Trim()+"'";
			else
				strSQL+=",VecinalConoce =null";

            // REFERENCIA VECINAL 2 //
            if (strNombreVecino.Trim() != "")                        // Apellido y Nombre del Vecino     
                strSQL += ",VecinalNombre2 ='" + strNombreVecino2.Trim() + "'";
            else
                strSQL += ",VecinalNombre2 =null";

            if (strDomicilioVecino.Trim() != "")                     // Domicilio del Vecino        
                strSQL += ",VecinalDomicilio2 ='" + strDomicilioVecino2.Trim() + "'";
            else
                strSQL += ",VecinalDomicilio2 =null";

            if (strConoceVecino.Trim() != "")                        // Conoce a la persona     
                strSQL += ",VecinalConoce2 ='" + strConoceVecino2.Trim() + "'";
            else
                strSQL += ",VecinalConoce2 =null";

			if (strObservaciones.Trim()!="")                        // Observaciones     
				strSQL+=",Observaciones ='" + strObservaciones.Trim().Replace("'","''") + "'";
			else
				strSQL+=",Observaciones =null";

			if (strPlanoA.Trim()!="")                               // Ubicación A
				strSQL+=",PlanoA ='" + strPlanoA.Trim()+"'";
			else
				strSQL+=",PlanoA =null";

			if (strPlanoB.Trim()!="")                               // Ubicación B
				strSQL+=",PlanoB ='" + strPlanoB.Trim()+"'";
			else
				strSQL+=",PlanoB =null";

			if (strPlanoC.Trim()!="")                               // Ubicación C
				strSQL+=",PlanoC ='" + strPlanoC.Trim()+"'";
			else
				strSQL+=",PlanoC =null";

			if (strPlanoD.Trim()!="")                               // Ubicación D
				strSQL+=",PlanoD ='" + strPlanoD.Trim()+"'";
			else
				strSQL+=",PlanoD =null";

			strSQL+=",idFoto =" + intConFoto;                    // Con Foto 0=No 1=Si
            strSQL += ",idResultado =" + intResultado;                 // Resultado
			
			strSQL+=" WHERE idInforme =" + idInforme.ToString();

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
			OdbcDataAdapter myConsulta = new OdbcDataAdapter("select id, descripcion from Campo Where idGrupo = " + tipo + " AND activo=1 Order by orden", oConnection);
			myConsulta.Fill(ds);
			try
			{
				oConnection.Close();
			} 			
			catch {}

			return ds.Tables[0];
		}

		#endregion

		#region cargarAmbientalBancor(int idInforme)

		public bool cargarAmbientalBancor(int idInforme)
		{
			
			OdbcConnection oConnection = this.OpenConnection();
			DataSet ds = new DataSet();
			String strSQL = "SELECT * FROM ambientalBancor ";
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
			if(ds.Tables[0].Rows[0]["IdTipoPersona"].ToString() != "")
				intIdTipoPersona = int.Parse(ds.Tables[0].Rows[0]["IdTipoPersona"].ToString()); 
			strNombre = ds.Tables[0].Rows[0]["Nombre"].ToString();
			strApellido = ds.Tables[0].Rows[0]["Apellido"].ToString();
			intTipoDocumento = int.Parse(ds.Tables[0].Rows[0]["idTipoDoc"].ToString());
			strDocumento = ds.Tables[0].Rows[0]["NroDoc"].ToString();
			intEstadoCivil = int.Parse(ds.Tables[0].Rows[0]["idEstadoCivil"].ToString());
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
			if(ds.Tables[0].Rows[0]["idLocalidad"].ToString() != "")
			intIdLocalidad = int.Parse(ds.Tables[0].Rows[0]["idLocalidad"].ToString());
			if(ds.Tables[0].Rows[0]["idProvincia"].ToString() != "")
				intIdProvincia = int.Parse(ds.Tables[0].Rows[0]["idProvincia"].ToString());
			strTelefono = ds.Tables[0].Rows[0]["Telefono"].ToString();
			
			strFecha = ds.Tables[0].Rows[0]["FechaVerificacion"].ToString();
			strHabita = ds.Tables[0].Rows[0]["HabitaLugar"].ToString();
			strAntiguedad = ds.Tables[0].Rows[0]["Antiguedad"].ToString();
			strTelAlternativo = ds.Tables[0].Rows[0]["TelefonoAlt"].ToString();
            strEmail = ds.Tables[0].Rows[0]["Email"].ToString();
            strRelacionTitular = ds.Tables[0].Rows[0]["RelacionTitular"].ToString();
			intTipoVivienda = int.Parse(ds.Tables[0].Rows[0]["idTipoVivienda"].ToString());
			intEstadoCons = int.Parse(ds.Tables[0].Rows[0]["idEstado"].ToString());
			intTipoConstruccion = int.Parse(ds.Tables[0].Rows[0]["idTipoConstruccion"].ToString());
			intTipoZona = int.Parse(ds.Tables[0].Rows[0]["idTipoZona"].ToString());
			intDestino = int.Parse(ds.Tables[0].Rows[0]["idDestino"].ToString());
			intInteresado = int.Parse(ds.Tables[0].Rows[0]["idInteresado"].ToString());
			strAccesoDomicilio = ds.Tables[0].Rows[0]["AccesoDomicilio"].ToString();
			strInformo = ds.Tables[0].Rows[0]["Informo"].ToString();
			strRelacion = ds.Tables[0].Rows[0]["Relacion"].ToString();
			strNombreVecino = ds.Tables[0].Rows[0]["VecinalNombre"].ToString();
			strDomicilioVecino = ds.Tables[0].Rows[0]["VecinalDomicilio"].ToString();
			strConoceVecino = ds.Tables[0].Rows[0]["VecinalConoce"].ToString();
            strNombreVecino2 = ds.Tables[0].Rows[0]["VecinalNombre2"].ToString();
            strDomicilioVecino2 = ds.Tables[0].Rows[0]["VecinalDomicilio2"].ToString();
            strConoceVecino2 = ds.Tables[0].Rows[0]["VecinalConoce2"].ToString();
			strObservaciones = ds.Tables[0].Rows[0]["Observaciones"].ToString();
			strPlanoA = ds.Tables[0].Rows[0]["PlanoA"].ToString();
			strPlanoB = ds.Tables[0].Rows[0]["PlanoB"].ToString();
			strPlanoC = ds.Tables[0].Rows[0]["PlanoC"].ToString();
			strPlanoD = ds.Tables[0].Rows[0]["PlanoD"].ToString();
			intConFoto = int.Parse(ds.Tables[0].Rows[0]["idFoto"].ToString());
            if (ds.Tables[0].Rows[0]["idResultado"].ToString() != "")
                intResultado = int.Parse(ds.Tables[0].Rows[0]["idResultado"].ToString());
			
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
