using System;
using System.Data;
using System.Data.Odbc;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;

namespace ar.com.TiempoyGestion.BackEnd.Verificaciones.Dal
{
	/// <summary>
    /// Summary description for AmbientalBancorApp.
	/// </summary>
	public class InspeccionAmbientalBancorApp : GenericDal
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

        private int intIdHabita;
        private string strSICantidadIntegranGrupo;
	    private string strNOQuienHabita;
	    private string strNOCalidadDe;

	    private int intIdAmpliaciones;
	    private string strSICuales;

	    private int intIdDepIndep;
	    private string strDEPEmpresa;
	    private string strDEPDireccion;
	    private string strDEPIngresosMensuales;
	    private string strDEPBanco;

	    private string strINDEPActividad;
	    private string strINDEPDesarrolla;

	    private string strIngresos;
        private int intIdServicios;
		
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

        public InspeccionAmbientalBancorApp()
            : base()
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


        public int IdHabita
		{
			get
			{
                return intIdHabita;
			}
			set
			{
                intIdHabita = value;
			}
		}

        public string SICantidadIntegranGrupo
		{
			get
			{
                return strSICantidadIntegranGrupo;
			}
			set
			{
                strSICantidadIntegranGrupo = value;
			}
		}


        public string NOQuienHabita
		{
			get
			{
                return strNOQuienHabita;
			}
			set
			{
                strNOQuienHabita = value;
			}
		}

        public string NOCalidadDe
        {
            get
            {
                return strNOCalidadDe;
            }
            set
            {
                strNOCalidadDe = value;
            }
        }


        public int IdAmpliaciones
        {
            get
            {
                return intIdAmpliaciones;
            }
            set
            {
                intIdAmpliaciones = value;
            }
        }

		public string SICuales
		{
			get
			{
				return strSICuales;
			}
			set
			{
				strSICuales = value;
			}
		}

        public int IdDepIndep
		{
			get
			{
                return intIdDepIndep;
			}
			set
			{
                intIdDepIndep = value;
			}
		}

 
        public string DEPEmpresa
        {
            get
            {
                return strDEPEmpresa;
            }
            set
            {
                strDEPEmpresa = value;
            }
        }
        
        public string DEPDireccion
        {
            get
            {
                return strDEPDireccion;
            }
            set
            {
                strDEPDireccion = value;
            }
        }
        
        public string DEPIngresosMensuales
        {
            get
            {
                return strDEPIngresosMensuales;
            }
            set
            {
                strDEPIngresosMensuales = value;
            }
        }
        
        public string DEPBanco
        {
            get
            {
                return strDEPBanco;
            }
            set
            {
                strDEPBanco = value;
            }
        }

        
        public string INDEPActividad
        {
            get
            {
                return strINDEPActividad;
            }
            set
            {
                strINDEPActividad = value;
            }
        }

        public string INDEPDesarrolla
        {
            get
            {
                return strINDEPDesarrolla;
            }
            set
            {
                strINDEPDesarrolla = value;
            }
        }


        public string Ingresos
        {
            get
            {
                return strIngresos;
            }
            set
            {
                strIngresos = value;
            }
        }

        public int IdServicios
        {
            get
            {
                return intIdServicios;
            }
            set
            {
                intIdServicios = value;
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
			strSQL+="Insert into inspeccionambientalbancor (IdInforme, Nombre, Apellido, idTipoDoc, NroDoc, "+ 
			        "Calle, Barrio, CalleNro, Piso, Depto, Lote, Manzana, CP, Complejo, Torre, IdLocalidad, IdProvincia, Telefono, "+
			        "FechaVerificacion, idHabitaLugar, SICantidadIntegranGrupo, NOQuienHabita, NOCalidadDe, idAmpliaciones, SICuales, "+
                    "idDepIndep, DEPEmpresa, DEPDireccion, DEPIngresosMensuales, DEPBanco, INDEPActividad, INDEPDesarrolla, Ingresos, idServicios, " +
                    "Informo, Relacion, VecinalNombre, VecinalDomicilio, VecinalConoce, VecinalNombre2, VecinalDomicilio2, VecinalConoce2, " +
                    "Observaciones, PlanoA, PlanoB, PlanoC, PlanoD, idFoto, idResultado) ";

			// El id del Informe y la razón social de la empresa son los únicos valores que no admiten null
			// Y los valores que siempre voy a recibir son:
			// IdInforme, IdTipoPersona, nombre, apellido, TipoDocumento, documento, calle, Nro,
			// EstadoCivil, Localidad y Provincia de la persona, Localidad y Provincia de la empresa.
			
			// DATOS PERSONALES //
			strSQL+=" values ("+ intIdInforme; 
			
			// DOMICILIO A VERIFICAR //

			if (strNombre.Trim() != "") strSQL+=",'"+strNombre.Trim() + "'"; // Nombre de la Persona
			else strSQL+=",null";

            if (strApellido.Trim() != "") strSQL += ",'" + strApellido.Trim().Replace("'", "''") + "'"; // Apellido de la Persona
			else strSQL+=",null";

			strSQL+="," + intTipoDocumento;

			if (strDocumento.Trim() != "") strSQL+=",'"+strDocumento.Trim() + "'"; // Documento de la Persona
			else strSQL+=",null";
			
			//strSQL+="," + intEstadoCivil;

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

            strSQL+=","+ intIdHabita;

			if (strSICantidadIntegranGrupo.Trim() != "") strSQL+=",'"+strSICantidadIntegranGrupo.Trim()+"'"; // cantidad
			else strSQL+=",null";

			if (strNOQuienHabita.Trim() != "") strSQL+=",'"+strNOQuienHabita.Trim()+"'"; // Quien
			else strSQL+=",null";

            if (strNOCalidadDe.Trim() != "") strSQL += ",'" + strNOCalidadDe.Trim() + "'"; // Calidad de
            else strSQL += ",null";

            strSQL+=","+ intIdAmpliaciones;

            if (strSICuales.Trim() != null && strSICuales.Trim() != "") strSQL+=",'"+strSICuales.Trim()+"'"; // Cuales
			else strSQL+=",null";

            strSQL+=","+ intIdDepIndep;


			if (strDEPEmpresa.Trim() != "") strSQL+=",'"+strDEPEmpresa.Trim()+"'"; // Empresa
			else strSQL+=",null";

            if (strDEPDireccion.Trim() != "") strSQL+=",'"+strDEPDireccion.Trim()+"'"; // Direccion
			else strSQL+=",null";

            if (strDEPIngresosMensuales.Trim() != "") strSQL+=",'"+strDEPIngresosMensuales.Trim()+"'"; // Ingresos mensuales
			else strSQL+=",null";

            if (strDEPBanco.Trim() != "") strSQL+=",'"+strDEPBanco.Trim()+"'"; // Banco
			else strSQL+=",null";

            if (strINDEPActividad.Trim() != "") strSQL+=",'"+strINDEPActividad.Trim()+"'"; // Actividad
			else strSQL+=",null";

            if (strINDEPDesarrolla.Trim() != "") strSQL+=",'"+strINDEPDesarrolla.Trim()+"'"; // Desarrolla
			else strSQL+=",null";

            if (strIngresos.Trim() != "") strSQL+=",'"+strIngresos.Trim()+"'"; // Ingresos
			else strSQL+=",null";

            strSQL+=","+ intIdServicios;

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
			String strSQL = "UPDATE inspeccionambientalbancor SET ";

			// DATOS PERSONALES //
			//strSQL+="IdTipoPersona="+ intIdTipoPersona;      // El tipo de Persona 

			if (strNombre.Trim()!="")                        // Nombre
				strSQL+="Nombre ='" + strNombre.Trim()+"'";
			else
				strSQL+="Nombre =null";
			
			if (strApellido.Trim()!="")                      // Apellido
                strSQL += ",Apellido ='" + strApellido.Trim().Replace("'", "''") + "'";
			else
				strSQL+=",Apellido =null";
			
			strSQL+=",idTipoDoc="+ intTipoDocumento;         // Tipo de Documento

			if (strDocumento.Trim()!="")                     // Nro de Documento
				strSQL+=",NroDoc ='" + strDocumento.Trim()+"'";
			else
				strSQL+=",NroDoc =null";
			
			//strSQL+=",idEstadoCivil="+ intEstadoCivil;       // Estado Civil

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

            strSQL+=",idHabitaLugar =" + intIdHabita;		   // Habita

			if (strSICantidadIntegranGrupo.Trim()!="")                          // Cantidad
				strSQL+=",SICantidadIntegranGrupo ='" + strSICantidadIntegranGrupo.Trim()+"'";
			else
				strSQL+=",SICantidadIntegranGrupo =null";

			if (strNOQuienHabita.Trim()!="")                           // Antiguedad
				strSQL+=",NOQuienHabita ='" + strNOQuienHabita.Trim()+"'";
			else
				strSQL+=",Antiguedad =null";

			if (strNOCalidadDe.Trim()!="")                          // Calidad de
				strSQL+=",NOCalidadDe ='" + strNOCalidadDe.Trim()+"'";
			else
				strSQL+=",NOCalidadDe =null";

            strSQL+=",idAmpliaciones =" + intIdAmpliaciones;		   // Ampliaciones

            if (strSICuales.Trim() != "")                          // Email
                strSQL += ",SICuales ='" + strSICuales.Trim() + "'";
            else
                strSQL += ",SICuales =null";

            strSQL+=",idDepIndep =" + intIdDepIndep;		   // Ampliaciones


			if (strDEPEmpresa.Trim()!="")                      // Empresa
				strSQL+=",DEPEmpresa ='" + strDEPEmpresa.Trim()+"'";
			else
				strSQL+=",DEPEmpresa =null";

            if (strDEPDireccion.Trim()!="")                      // Direccion
				strSQL+=",DEPDireccion ='" + strDEPDireccion.Trim()+"'";
			else
				strSQL+=",DEPDireccion =null";

            if (strDEPIngresosMensuales.Trim()!="")                      // Ingresos
				strSQL+=",DEPIngresosMensuales ='" + strDEPIngresosMensuales.Trim()+"'";
			else
				strSQL+=",DEPIngresosMensuales =null";

            if (strDEPBanco.Trim()!="")                      // Banco
				strSQL+=",DEPBanco ='" + strDEPBanco.Trim()+"'";
			else
				strSQL+=",DEPBanco =null";

            if (strINDEPActividad.Trim()!="")                      // Banco
				strSQL+=",INDEPActividad ='" + strINDEPActividad.Trim()+"'";
			else
				strSQL+=",INDEPActividad =null";

            if (strINDEPDesarrolla.Trim()!="")                      // Desarrolla
				strSQL+=",INDEPDesarrolla ='" + strINDEPDesarrolla.Trim()+"'";
			else
				strSQL+=",INDEPDesarrolla =null";

            if (strIngresos.Trim()!="")                      // Ingresos
				strSQL+=",Ingresos ='" + strIngresos.Trim()+"'";
			else
				strSQL+=",Ingresos =null";
           
            strSQL+=",idServicios =" + intIdServicios;		   // Ampliaciones

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

		public bool cargarInspeccionAmbientalBancor(int idInforme)
		{
			
			OdbcConnection oConnection = this.OpenConnection();
			DataSet ds = new DataSet();
			String strSQL = "SELECT * FROM inspeccionambientalbancor ";
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
			//if(ds.Tables[0].Rows[0]["IdTipoPersona"].ToString() != "")
				//intIdTipoPersona = int.Parse(ds.Tables[0].Rows[0]["IdTipoPersona"].ToString()); 
			strNombre = ds.Tables[0].Rows[0]["Nombre"].ToString();
			strApellido = ds.Tables[0].Rows[0]["Apellido"].ToString();
			intTipoDocumento = int.Parse(ds.Tables[0].Rows[0]["idTipoDoc"].ToString());
			strDocumento = ds.Tables[0].Rows[0]["NroDoc"].ToString();
			//intEstadoCivil = int.Parse(ds.Tables[0].Rows[0]["idEstadoCivil"].ToString());
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

            intIdHabita = int.Parse(ds.Tables[0].Rows[0]["idHabitaLugar"].ToString());
			strSICantidadIntegranGrupo = ds.Tables[0].Rows[0]["SICantidadIntegranGrupo"].ToString();
			strNOQuienHabita = ds.Tables[0].Rows[0]["NOQuienHabita"].ToString();
            strNOCalidadDe = ds.Tables[0].Rows[0]["NOCalidadDe"].ToString();
			intIdAmpliaciones = int.Parse(ds.Tables[0].Rows[0]["idAmpliaciones"].ToString());
            strSICuales = ds.Tables[0].Rows[0]["SICuales"].ToString();
			intIdDepIndep = int.Parse(ds.Tables[0].Rows[0]["idDepIndep"].ToString());
            strDEPEmpresa = ds.Tables[0].Rows[0]["DEPEmpresa"].ToString();
            strDEPDireccion = ds.Tables[0].Rows[0]["DEPDireccion"].ToString();
            strDEPIngresosMensuales = ds.Tables[0].Rows[0]["DEPIngresosMensuales"].ToString();
            strDEPBanco = ds.Tables[0].Rows[0]["DEPBanco"].ToString();
            strINDEPActividad = ds.Tables[0].Rows[0]["INDEPActividad"].ToString();
            strINDEPDesarrolla = ds.Tables[0].Rows[0]["INDEPDesarrolla"].ToString();
            strIngresos = ds.Tables[0].Rows[0]["Ingresos"].ToString();
			intIdServicios = int.Parse(ds.Tables[0].Rows[0]["idServicios"].ToString());

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
