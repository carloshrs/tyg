using System;
using System.Data;
using System.Data.Odbc;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;
//using ar.com.TiempoyGestion.BackEnd.Clientes.App;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.App;

namespace ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal
{
	/// <summary>
	/// Summary description for ClienteDal.
	/// </summary>
	public class EncabezadoApp : GenericDal
	{
		#region Atributos y Contructores
			
		private int intIdEncabezado;
		private int intIdTipoInforme;
		private int intidReferencia;
        private string strNombreReferencia;
		private int intIdCliente;
		private int intIdUsuario;
		private String strUsuarioCliente;
		private int intEstado = 1;
        private int intLeido = 0;
        private int intEntregado = 0;
		private int intIdTipoPersona;
		private String strNombre;
		private String strApellido;
		private int intEstadoCivil = 1;
		private int intTipoDocumento = 1;
		private String strTipoDocumento;
		private String strEstadoCivil;
		private String strDocumento;
		private String strCalle;
		private String strNro;
		private String strDpto;
		private String strPiso;
		private String strBarrio;
		private String strCP;
        private String strLote;
        private String strManzana;
        private String strComplejo;
        private String strTorre;
		private int intLocalidad = 67;
		private int intProvincia = 23;
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
		//GRAVAMENES
		private int intidTipoGravamen = 1;
		private String strTipoGravamen;
		private String strFolio;
		private String strTomo;
		private String strAno;
		//INFO PROPIEDAD
		private String strMatricula;
		private int intPropTipo = 1;
		private String strPropFolio;
		private String strPropTomo;
		private String strPropAno;
        // INFO PROPIEDAD OTRAS PROVINCIAS
        private int intLocalidadOtra = 24;
        private int intProvinciaOtra = 3;
		// INFO AMBIENTE
		private String strNombreCony;
		private String strApellidoCony;
		private int intAMBTipoDoc = 1;
		private String strAMBDocumento;
        private String strAMBTelefono;
        private String strAMBEMail;
		//EMPRESAS
		private String strRazonSocial;
		private String strNombreFantasia;
        private String strCargo;
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
		//CATASTRAL
		private int intTipoCatastro = 1;
		private String strNumeroCatastro;
		private String strCatCalle;
		private String strCatNro;
		private String strCatDpto;
		private String strCatPiso;
		private String strCatBarrio;
		private String strCatCP;
		private int intCatLocalidad = 67;
		private int intCatProvincia = 23;
        //BANCOR
        private string strLocalidad;
		//Registro Publico
		private String strRegPubFolio;
		private String strRegPubTomo;
		private String strRegPubAno;

		private int intConFoto;
		private int intCaracter = 1;
		private String strComentarios;
		private String strObservaciones;
		private String strApreciaciones;

        // Partidas defunción
        private int intSexo = 0;
        private string strFechaFallecido = "";
        private string strLugarFallecido = "";
        private string strActaFallecido = "";
        private string strTomoFallecido = "";
        private string strFolioFallecido = "";


        //Integración FOX
        private int intIdFOX = 0;

        private string strFechaCarga = "";
        private string strFechaFin = "";
        private string strFechaCondicional = "";
        private int intIdEncabezadoTransferido;

        private string strLogoEmpresa = "";
        
		public EncabezadoApp() : base()
		{		}

		#endregion

		#region Propiedades
		public int IdEncabezado
		{
			get
			{
				return intIdEncabezado;
			}
			set
			{
				intIdEncabezado = value;
			}
		}
		public int IdTipoInforme
		{
			get
			{
				return intIdTipoInforme;
			}
			set
			{
				intIdTipoInforme = value;
			}
		}
		public int idReferencia
		{
			get
			{
				return intidReferencia;
			}
			set
			{
				intidReferencia = value;
			}
		}
        public string NombreReferencia
        {
            get
            {
                return strNombreReferencia;
            }
            set
            {
                strNombreReferencia = value;
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

		public String UsuarioCliente
		{
			get
			{
				return strUsuarioCliente;
			}
			set
			{
				strUsuarioCliente = value;
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

        public int Leido
        {
            get
            {
                return intLeido;
            }
            set
            {
                intLeido = value;
            }
        }

        public int Entregado
        {
            get
            {
                return intEntregado;
            }
            set
            {
                intEntregado = value;
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

		public String Nombre
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
		public String Apellido
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

        public int Sexo
        {
            get
            {
                return intSexo;
            }
            set
            {
                intSexo = value;
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
		public String txtTipoDocumento
		{
			get
			{
				return strTipoDocumento;
			}
			set
			{
				strTipoDocumento = value;
			}
		}
		public String txtEstadoCivil
		{
			get
			{
				return strEstadoCivil;
			}
			set
			{
				strEstadoCivil = value;
			}
		}

		public String Documento
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
		public String Calle
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
		public String Nro
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
		public String Dpto
		{
			get
			{
				return strDpto;
			}
			set
			{
				strDpto = value;
			}
		}
		public String Piso
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

        public String Complejo
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

        public String Torre
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

        public String Lote
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

        public String Manzana
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

		public String Barrio
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
		public String CP
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
		public int Localidad
		{
			get
			{
				return intLocalidad;
			}
			set
			{
				intLocalidad = value;
			}
		}
		public int Provincia
		{
			get
			{
				return intProvincia;
			}
			set
			{
				intProvincia = value;
			}
		}
		public String Comentarios
		{
			get
			{
				return strComentarios;
			}
			set
			{
				strComentarios = value;
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
		public int idTipoGravamen
		{
			get
			{
				return intidTipoGravamen;
			}
			set
			{
				intidTipoGravamen = value;
			}
		}
		public String txtTipoGravamen
		{
			get
			{
				return strTipoGravamen;
			}
			set
			{
				strTipoGravamen = value;
			}
		}
		public String Folio
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
		public String Tomo
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
		public String Ano
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

		public String Matricula
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
		public int PropTipo
		{
			get
			{
				return intPropTipo;
			}
			set
			{
				intPropTipo = value;
			}
		}
		public String PropFolio
		{
			get
			{
				return strPropFolio;
			}
			set
			{
				strPropFolio = value;
			}
		}
		
		public String PropTomo
		{
			get
			{
				return strPropTomo;
			}
			set
			{
				strPropTomo = value;
			}
		}
		public String PropAno
		{
			get
			{
				return strPropAno;
			}
			set
			{
				strPropAno = value;
			}
		}
        public int LocalidadOtra
        {
            get
            {
                return intLocalidadOtra;
            }
            set
            {
                intLocalidadOtra = value;
            }
        }
        public int ProvinciaOtra
        {
            get
            {
                return intProvinciaOtra;
            }
            set
            {
                intProvinciaOtra = value;
            }
        }

		public String NombreCony
		{
			get
			{
				return strNombreCony;
			}
			set
			{
				strNombreCony = value;
			}
		}
		public String ApellidoCony
		{
			get
			{
				return strApellidoCony;
			}
			set
			{
				strApellidoCony = value;
			}
		}
		public int AMBTipoDoc
		{
			get
			{
				return intAMBTipoDoc;
			}
			set
			{
				intAMBTipoDoc = value;
			}
		}
		public String AMBDocumento
		{
			get
			{
				return strAMBDocumento;
			}
			set
			{
				strAMBDocumento = value;
			}
		}
        public String AMBTelefono
        {
            get
            {
                return strAMBTelefono;
            }
            set
            {
                strAMBTelefono = value;
            }
        }
        public String AMBEMail
        {
            get
            {
                return strAMBEMail;
            }
            set
            {
                strAMBEMail = value;
            }
        }
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
		public String Observaciones
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

		public String Apreciaciones
		{
			get
			{
				return strApreciaciones;
			}
			set
			{
				strApreciaciones = value;
			}
		}

		public int TipoCatastro
		{
			get
			{
				return intTipoCatastro;
			}
			set
			{
				intTipoCatastro = value;
			}
		}
			
		public String NumeroCatastro
		{
			get
			{
				return strNumeroCatastro;
			}
			set
			{
				strNumeroCatastro = value;
			}
		}

		public String CatCalle
		{
			get
			{
				return strCatCalle;
			}
			set
			{
				strCatCalle = value;
			}
		}

		public String CatNro
		{
			get
			{
				return strCatNro;
			}
			set
			{
				strCatNro = value;
			}
		}

		public String CatDpto
		{
			get
			{
				return strCatDpto;
			}
			set
			{
				strCatDpto = value;
			}
		}

		public String CatPiso
		{
			get
			{
				return strCatPiso;
			}
			set
			{
				strCatPiso = value;
			}
		}

		public String CatBarrio
		{
			get
			{
				return strCatBarrio;
			}
			set
			{
				strCatBarrio = value;
			}
		}

		public String CatCP
		{
			get
			{
				return strCatCP;
			}
			set
			{
				strCatCP = value;
			}
		}

		public int CatLocalidad
		{
			get
			{
				return intCatLocalidad;
			}
			set
			{
				intCatLocalidad = value;
			}
		}

		public int CatProvincia
		{
			get
			{
				return intCatProvincia;
			}
			set
			{
				intCatProvincia = value;
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
		public int Caracter
		{
			get
			{
				return intCaracter;
			}
			set
			{
				intCaracter = value;
			}
		}
		public String RegPubFolio
		{
			get
			{
				return strRegPubFolio;
			}
			set
			{
				strRegPubFolio = value;
			}
		}
		public String RegPubTomo
		{
			get
			{
				return strRegPubTomo;
			}
			set
			{
				strRegPubTomo = value;
			}
		}
		public String RegPubAno
		{
			get
			{
				return strRegPubAno;
			}
			set
			{
				strRegPubAno = value;
			}
		}
        public int IdFOX
        {
            get
            {
                return intIdFOX;
            }
            set
            {
                intIdFOX = value;
            }
        }
        public string FechaCarga
        {
            set
            {
                strFechaCarga = value;
            }
        }

        public string FechaFin
        {
            set
            {
                strFechaFin = value;
            }
            get 
            {
                return strFechaFin;
            }
        }

        public string FechaCondicional
        {
            set
            {
                strFechaCondicional = value;
            }
            get
            {
                return strFechaCondicional;
            }
        }

        public int IdEncabezadoTransferido
        {
            set
            {
                intIdEncabezadoTransferido = value;
            }
            get
            {
                return intIdEncabezadoTransferido;
            }
        }

        public string LocalidadTxt
        {
            get
            {
                return strLocalidad;
            }
            set
            {
                strLocalidad = value;
            }
        }

        public string FechaFallecido
        {
            get
            {
                return strFechaFallecido;
            }
            set
            {
                strFechaFallecido = value;
            }
        }

        public string LugarFallecido
        {
            get
            {
                return strLugarFallecido;
            }
            set
            {
                strLugarFallecido = value;
            }
        }

        public string ActaFallecido
        {
            get
            {
                return strActaFallecido;
            }
            set
            {
                strActaFallecido = value;
            }
        }

        public string TomoFallecido
        {
            get
            {
                return strTomoFallecido;
            }
            set
            {
                strTomoFallecido = value;
            }
        }

        public string FolioFallecido
        {
            get
            {
                return strFolioFallecido;
            }
            set
            {
                strFolioFallecido = value;
            }
        }

        public string LogoEmpresa
        {
            get
            {
                return strLogoEmpresa;
            }
            set
            {
                strLogoEmpresa = value;
            }
        }

		#endregion

		#region Métodos Publicos

		public bool Crear()
		{

            string dtFechaCarga = strFechaCarga;
            
            /*
            if (strFechaCarga != "")
            {
                string[] fechai1 = strFechaCarga.Split("/".ToCharArray());
                dtFechaCarga = "'" + fechai1[2] + "/" + fechai1[1] + "/" + fechai1[0] + "'";
            }
             */
            
            String strSQL = "Insert into BandejaEntrada (idTipoInforme, idCliente, idUsuario, UsuarioCliente, Estado, Comentarios, Nombre, Apellido, ";
			if (intidReferencia != 0)
			{
				strSQL = strSQL  + "idReferencia, ";
			}
			strSQL = strSQL  + "idTipoPersona, EstadoCivil, TipoDocumento, Documento, Calle, Nro, Dpto, Piso, Lote, Manzana, Complejo, Torre, Barrio, CP, Localidad, Provincia, ";
			//AUTOMOVILES
			strSQL = strSQL  + "AUTDominio, AUTRegistro, AUTCalleRegistro, AUTNroRegistro, AUTDptoRegistro, AUTPisoRegistro, AUTBarrioRegistro, AUTCPRegistro, AUTLocalidadRegistro, AUTProvinciaRegistro, ";
			//GRAVAMENES
			strSQL = strSQL  + "GRAVidTipoGravamen, GRAVFolio, GRAVTomo, GRAVAno, ";
			//PROPIEDADES
			strSQL = strSQL  + "PROPMatricula, PropTipo, PROPFolio, PROPTomo, PROPAno, ";
            //PROPIEDADES OTRAS PROVINCIAS
            strSQL = strSQL + "PROPProvincia, PROPLocalidad, ";
			// AMBIENTAL
			strSQL = strSQL  + "AMBNombreCony, AMBApellidoCony, AMBTipoDoc, AMBDocumento, AMBTelefono, AMBEMail, ";
			// CATASTRO
			strSQL = strSQL  + "TipoCatastro, CatNumero, CatCalle, CatNro, CatDepto, CatPiso, CatBarrio, CatCP, CatLocalidad, CatProvincia, ";
			//EMPRESA
			strSQL = strSQL  + "RazonSocial, NombreFantasia, CargoEmpresa, TelefonoEmpresa, Rubro, Cuit, CalleEmpresa, NroEmpresa, DptoEmpresa, PisoEmpresa, BarrioEmpresa, CPEmpresa, LocalidadEmpresa, ProvinciaEmpresa,";
			strSQL = strSQL  + "RegPubFolio, RegPubTomo, RegPubAno, ";

            strSQL = strSQL + "ConFoto, Caracter, DescripcionInf,FechaCarga,IdFOX,leido, txtLocalidad, Sexo, FechaFallecido, LugarFallecido, ActaFallecido, TomoFallecido, FolioFallecido) values (" + intIdTipoInforme + "," + intIdCliente + "," + intIdUsuario + ",'" + strUsuarioCliente + "'," + intEstado + ",'" + Comentarios + "','" + Nombre.Replace("'", "''") + "','" + Apellido.Replace("'", "''") + "',";
			if (intidReferencia != 0)
			{
				strSQL = strSQL  + intidReferencia.ToString() + ",";
			}
			strSQL = strSQL  + intIdTipoPersona + "," + intEstadoCivil + "," + intTipoDocumento + ",'" + strDocumento;
            strSQL = strSQL + "','" + strCalle.Replace("'", "''") + "','" + strNro + "','" + strDpto + "','" + strPiso + "','" + strLote + "','" + strManzana + "','" + strComplejo + "','" + strTorre + "','" + strBarrio.Replace("'", "''") + "','" + strCP + "'," + intLocalidad + "," + intProvincia;
			strSQL = strSQL  + ",'" + strDominio + "','" + strRegistro + "','" + strCalleRegistro + "','" + strNroRegistro + "','" + strDptoRegistro + "','" + strPisoRegistro;
			strSQL = strSQL  + "','" + strBarrioRegistro + "','" + strCPRegistro + "'," + intLocalidadRegistro + "," + intProvinciaRegistro ; 
			strSQL = strSQL  + "," + intidTipoGravamen + ",'" + strFolio + "','" + strTomo + "','" + strAno;
			strSQL = strSQL  + "','" + strMatricula + "'," + intPropTipo + ",'" + strPropFolio + "','" + strPropTomo + "','" + strPropAno ;
            strSQL = strSQL + "'," + intProvinciaOtra + "," + intLocalidadOtra; 
			strSQL = strSQL  + ",'" + strNombreCony + "','" + strApellidoCony + "'," +  intAMBTipoDoc + ",'" + strAMBDocumento + "','" + strAMBTelefono + "','" + AMBEMail;
            strSQL = strSQL + "'," + intTipoCatastro.ToString() + ",'" + strNumeroCatastro + "','" + strCatCalle.Replace("'", "''") + "','" + strCatNro + "','" + strCatDpto + "','" + strCatPiso + "','" + strCatBarrio + "','" + strCatCP + "'," + intCatLocalidad + "," + intCatProvincia;
            strSQL = strSQL + ",'" + strRazonSocial.Replace("'", "''") + "','" + strNombreFantasia + "','" + strCargo + "','" + strTelefonoEmpresa + "','" + strRubro + "','" + strCuit + "','" + strCalleEmpresa.Replace("'", "''") + "','" + strNroEmpresa + "','" + strDptoEmpresa + "','" + strPisoEmpresa + "','" + strBarrioEmpresa.Replace("'", "''") + "','" + strCPEmpresa + "'," + intLocalidadEmpresa + "," + intProvinciaEmpresa; 	
			strSQL = strSQL  + ",'" + strRegPubFolio + "','" + strRegPubTomo + "','" + strRegPubAno;
            strSQL = strSQL + "'," + ConFoto.ToString() + "," + Caracter.ToString() + ",'" + TraerDescripcionInforme().Replace("'", "''") + "'";
            if (dtFechaCarga != "")
                strSQL = strSQL + ",'" + dtFechaCarga +"'";
            else
                strSQL = strSQL + ", getdate()";
            strSQL = strSQL + ",'" + IdFOX + "'," + Leido.ToString() + ", '" + strLocalidad + "', " + intSexo + ", '" + strFechaFallecido + "', '" + strLugarFallecido + "', '" + strActaFallecido + "', '" + strTomoFallecido + "', '" + strFolioFallecido + "')"; 

			String strMaxID = "SELECT MAX(idEncabezado) as MaxId FROM BandejaEntrada";

			try
			{
                OdbcConnection oConnection = this.OpenConnection();
			    OdbcCommand	myCommand = new OdbcCommand(strSQL, oConnection);
				myCommand.ExecuteNonQuery();

				int MaxID = ObtenerMaxID(strMaxID, oConnection); 

				String strAuditoria = "INSERT INTO HistoricoAcciones (idCliente, idUsuario, Instante, Evento, Observaciones, idTipoObjeto, idEstado, idReferencia) VALUES (";
				strAuditoria = strAuditoria  + intIdCliente + "," + intIdUsuario  + ", getdate(), 'Solicitud de Informe', 'Solicitud de Informe', 1" + ", 1," + MaxID.ToString() + ")";

				myCommand = new OdbcCommand(strAuditoria, oConnection);
				myCommand.ExecuteNonQuery();


                //Transferido
                string strEstadoTransferido = "";
                string strTransferido = "";
                string descrInformeHistorial = "";
                if (IdEncabezadoTransferido != null)
                {
                    strEstadoTransferido = "UPDATE bandejaentrada SET Estado=10 " +
                    " WHERE idEncabezado=" + IdEncabezadoTransferido ;

                    myCommand = new OdbcCommand(strEstadoTransferido, oConnection);
                    myCommand.ExecuteNonQuery();

                    strTransferido = "INSERT INTO informepropiedadtransferido " +
                        "(idEncabezadoPadre, idEncabezado, fecha) VALUES " +
                        "(" + IdEncabezadoTransferido + ", " + MaxID + ", getdate())";

                    myCommand = new OdbcCommand(strTransferido, oConnection);
                    myCommand.ExecuteNonQuery();
                    descrInformeHistorial = TraerDescripcionInforme().Replace("'", "''").Replace("<B>", "").Replace("</B>","");
                    String strAuditoria2 = "INSERT INTO HistoricoAcciones (idCliente, idUsuario, Instante, Evento, Observaciones, idTipoObjeto, idEstado, idReferencia) VALUES " +
                        "(" + intIdCliente + "," + intIdUsuario + ", getdate(), 'Informe Transferido', 'Informe Transferido a " + descrInformeHistorial + "', 1" + ", 10," + IdEncabezadoTransferido + ")";

                    myCommand = new OdbcCommand(strAuditoria2, oConnection);
                    myCommand.ExecuteNonQuery();
                }

				oConnection.Close();
			} 			
			catch (Exception e)
			{	
				string p = e.Message;
				return false;
			}
			return true;
		}

		public String TraerDescripcionInforme(){
			String Descripcion = "";
			switch(intIdTipoInforme)
			{
				case 1: // Propiedad
					switch(intPropTipo)
					{
						case 1: // Matricula
							Descripcion = "<B>Matricula Nro:</B> " + strMatricula;
							break;
						case 2: // Dominio
							if (strMatricula == "") 
							{
								Descripcion = "<B>Folio:</B> " + strPropFolio + " - <B>Tomo:</B> " + strPropTomo + " - <B>Año: </B>" + strPropAno;
							} 
							else {
								Descripcion = "<B>Dominio:</B> " + strMatricula + " - <B>Folio:</B> " + strPropFolio + " - <B>Tomo: </B>" + strPropTomo + " - <B>Año: </B>" + strPropAno;
							}
							break;
						case 3: // Matricula
							Descripcion = "<B>Leg.Especial:</B> " + strMatricula + " - <B>Folio:</B> " + strPropFolio + " - <B>Tomo: </B>" + strPropTomo + " - <B>Año: </B>" + strPropAno;
							break;
                        case 4: // Planilla
                            Descripcion = "<B>Planilla Nro:</B> " + strMatricula;
                            break;
                    }
                    if (intPropTipo != 1 && intPropTipo != 2)
                    {
                        if (intCaracter == 1) Descripcion = Descripcion + " - <B>Carácter: </B> Normal";
                        if (intCaracter == 2) Descripcion = Descripcion + " - <B>Carácter: </B> Urgente";
                        if (intCaracter == 3) Descripcion = Descripcion + " - <B>Carácter: </B> Super Urgente";
                    }
					break;
				case 2: // Automotor
					Descripcion = "<B>Dominio:</B> " + strDominio;
					break;
				case 3: // Gravámenes
					switch(intidTipoGravamen)
					{
						case 1: // Hipoteca
							Descripcion = "<B>Tipo:</B> Hipoteca - <B>Folio:</B> " + strFolio + " - <B>Tomo: </B>" + strTomo + " - <B>Año: </B>" + strAno;
							break;
						case 2: // Usufructo
							Descripcion = "<B>Tipo:</B> Usufructo - <B>Folio:</B> " + strFolio + " - <B>Tomo: </B>" + strTomo + " - <B>Año: </B>" + strAno;
							break;
						case 4: // Embargo
							Descripcion = "<B>Tipo: </B> Embargo - <B>Folio:</B> " + strFolio + " - <B>Tomo: </B>" + strTomo + " - <B>Año: </B>" + strAno;
							break;
						case 5: // Bien de Familia
							Descripcion = "<B>Tipo: </B> Bien de Familia - <B>Folio:</B> " + strFolio + " - <B>Tomo: </B>" + strTomo + " - <B>Año: </B>" + strAno;
							break;
                        case 6: // Servidumbre
                            Descripcion = "<B>Tipo: </B> Servidumbre - <B>Folio:</B> " + strFolio + " - <B>Tomo: </B>" + strTomo + " - <B>Año: </B>" + strAno;
                            break;
                        case 7: // Providencia cautelar
                            Descripcion = "<B>Tipo: </B> Providencia cautelar - <B>Folio:</B> " + strFolio + " - <B>Tomo: </B>" + strTomo + " - <B>Año: </B>" + strAno;
                            break;
                        case 8: // Mandato
                            Descripcion = "<B>Tipo: </B> Mandato - <B>Folio:</B> " + strFolio + " - <B>Tomo: </B>" + strTomo + " - <B>Año: </B>" + strAno;
                            break;
					}
                    if (intCaracter == 1) Descripcion = Descripcion + " - <B>Carácter: </B> Normal";
                    if (intCaracter == 2) Descripcion = Descripcion + " - <B>Carácter: </B> Urgente";
                    if (intCaracter == 3) Descripcion = Descripcion + " - <B>Carácter: </B> Super Urgente";

					break;
				case 4: // Ambiental
                    Descripcion = "<B>Apellido y Nombre: </B>" + strApellido + ", " + strNombre + " - <B>" + strTipoDocumento + ":</B> " + strDocumento;
					break;
				case 5: // Dom Particular
                    Descripcion = "<B>Apellido y Nombre: </B>" + strApellido + ", " + strNombre + " - <B>" + strTipoDocumento + ":</B> " + strDocumento;
					break;
				case 6: //Verificación de Domicilio Laboral
					Descripcion = "<B>Apellido y Nombre: </B>" + strApellido + ", " + strNombre + " - <B>" + strTipoDocumento + ":</B> " + strDocumento + " - Razón Social: " + strRazonSocial;
					break;
				case 7: //Verificación de Domicilio Comercial
                    Descripcion = "<B>Apellido y Nombre: </B>" + strApellido + ", " + strNombre + " - <B>" + strTipoDocumento + ":</B> " + strDocumento + " - Razón Social: " + strRazonSocial;
					break;
				case 8: // Verificación Especial
					Descripcion = "<B>Apellido y Nombre: </B>" + strApellido + ", " + strNombre + " - <B>" + strTipoDocumento + ":</B> " + strDocumento;
					break;
				case 9: // Registro Público de Comercio
					Descripcion = "Registro Público de Comercio";
					break;
				case 10: // Busqueda Automotor
					if (intIdTipoPersona == 1) Descripcion = "<B>Apellido y Nombre: </B>" + strApellido + ", " + strNombre + " - <B>" + strTipoDocumento + ":</B> " + strDocumento;
					else Descripcion = "<B>Razón Social: </B>" + strRazonSocial + " - <B>Cuit: </B> " + strCuit;
					break;
				case 11: // Informe Propiedad Otras Provincias
					Descripcion = "Informe de Propiedad (otras Provincias) - ";
                    switch (intPropTipo)
                    {
                        case 1: // Matricula
                            Descripcion = Descripcion + "<B>Matricula Nro:</B> " + strMatricula;
                            break;
                        case 2: // Dominio
                            if (strMatricula == "")
                            {
                                Descripcion = Descripcion + "<B>Folio:</B> " + strPropFolio + " - <B>Tomo:</B> " + strPropTomo + " - <B>Año: </B>" + strPropAno;
                            }
                            else
                            {
                                Descripcion = Descripcion + "<B>Dominio:</B> " + strMatricula + " - <B>Folio:</B> " + strPropFolio + " - <B>Tomo: </B>" + strPropTomo + " - <B>Año: </B>" + strPropAno;
                            }
                            break;
                        case 3: // Matricula
                            Descripcion = Descripcion + "<B>Leg.Especial:</B> " + strMatricula + " - <B>Folio:</B> " + strPropFolio + " - <B>Tomo: </B>" + strPropTomo + " - <B>Año: </B>" + strPropAno;
                            break;
                        case 4: // Planilla
                            Descripcion = Descripcion + "<B>Planilla Nro:</B> " + strMatricula;
                            break;
                    }
                    if (intCaracter == 1) Descripcion = Descripcion + " - <B>Carácter: </B> Normal";
                    if (intCaracter == 2) Descripcion = Descripcion + " - <B>Carácter: </B> Urgente";
                    if (intCaracter == 3) Descripcion = Descripcion + " - <B>Carácter: </B> Super Urgente";
					break;
				case 12: // Informe Catastral
					switch (intTipoCatastro) 
                    {
                        case 1: //Según Nomenclatura
						    Descripcion = "<B>Nomenclatura - Número:</B> " + strNumeroCatastro;
                            break;
                        case 2:
                            Descripcion = "<B>Nro. de Cuenta - Número:</B> " + strNumeroCatastro;
                            break;
                        case 3:
						    Descripcion = "<B>Dirección:</B> " + strCatCalle + ", <B>Nro:</B> " + strCatNro + ", <B>Dpto: </B>" + strCatDpto + ", <B>Piso: </B>" + strCatPiso;
                            break;
					}
                    break;
				case 13: // Búsqueda Propiedad
                    if (intIdTipoPersona == 1) Descripcion = "<B>Apellido y Nombre: </B>" + strApellido + ", " + strNombre + " - <B>" + strTipoDocumento + ": </B> " + strDocumento;
					else Descripcion = "<B>Razón Social: </B>" + strRazonSocial + " - <B>Cuit: </B> " + strCuit;
					if (intCaracter == 1) Descripcion = Descripcion + " - <B>Carácter: </B> Normal";
					if (intCaracter == 2) Descripcion = Descripcion + " - <B>Carácter: </B> Urgente";
					if (intCaracter == 3) Descripcion = Descripcion + " - <B>Carácter: </B> Super Urgente";
					break;
				case 14: // Informe Contractual
					if (intIdTipoPersona == 1) Descripcion = "<B>Apellido y Nombre: </B>" + strApellido + ", " + strNombre + " - <B>" + strTipoDocumento + ":</B> " + strDocumento;
					else Descripcion = "<B>Razón Social: </B>" + strRazonSocial + " - <B>Cuit: </B> " + strCuit;
					break;
                case 15: // Relevamiento Ambiental BANCOR
                    Descripcion = "<B>Apellido y Nombre: </B>" + strApellido + ", " + strNombre;
                    break;
                case 16: // Inhibicion
                    if (intIdTipoPersona == 1) Descripcion = "<B>" + strApellido + ", " + strNombre + "</B> - <B>" + strTipoDocumento + ":</B> " + strDocumento;
                    else Descripcion = "<B>Razón Social: </B>" + strRazonSocial + " - <B>Cuit: </B> " + strCuit;
                    Descripcion = "Inhibición - " + Descripcion;
                    if (intCaracter == 1) Descripcion = Descripcion + " - <B>Carácter: </B> Normal";
                    if (intCaracter == 2) Descripcion = Descripcion + " - <B>Carácter: </B> Urgente";
                    if (intCaracter == 3) Descripcion = Descripcion + " - <B>Carácter: </B> Super Urgente";

                    break;
                case 17: // Informe de Morosidad
                    if (intIdTipoPersona == 1) Descripcion = "<B>Apellido y Nombre: </B>" + strApellido + ", " + strNombre + " - <B>" + strTipoDocumento + ":</B> " + strDocumento;
                    else Descripcion = "<B>Razón Social: </B>" + strRazonSocial + " - <B>Cuit: </B> " + strCuit;
                    break;
                case 18: // Gravámenes DIR
                    if (intIdTipoPersona == 1) Descripcion = "<B>" + strApellido + ", " + strNombre + "</B> - <B>" + strTipoDocumento + ":</B> " + strDocumento;
                    else Descripcion = "<B>Razón Social: </B>" + strRazonSocial + " - <B>Cuit: </B> " + strCuit;
                    break;
                case 19: // Verifcación de defunción
                    Descripcion = "<B>Apellido y Nombre: </B>" + strApellido + ", " + strNombre + " - <B> " + strTipoDocumento + ":</B> " + strDocumento;
                    break;
                case 20: // Informe de partida defunción
                    Descripcion = "<B>Apellido y Nombre: </B>" + strApellido + ", " + strNombre + " - <B> " + strTipoDocumento + ":</B> " + strDocumento + ", Fallecido: " + strFechaFallecido;
                    break;
                case 21: // Inspección Socio Ambiental
                    Descripcion = "<B>Apellido y Nombre: </B>" + strApellido + ", " + strNombre + " - <B> " + strTipoDocumento + ":</B> " + strDocumento;
                    break;
			}
						
			return Descripcion;
		}

		// ACTUALIZA la Descripcion del Informe
		public bool ModificarTEMP(int idEncabezado)
		{
			OdbcConnection oConnection = this.OpenConnection();
			String strSQL = "UPDATE BandejaEntrada SET ";
			strSQL = strSQL  + "DescripcionInf = '" + TraerDescripcionInforme() + "' WHERE idEncabezado =  " + idEncabezado.ToString();

			try
			{
				OdbcCommand	myCommand = new OdbcCommand(strSQL, oConnection);
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



		public bool Modificar(int idEncabezado)
		{
            OdbcConnection oConnection = this.OpenConnection();
            OdbcDataAdapter myConsulta;
            DataTable dt = new DataTable();
            int intRef = 0;
            myConsulta = new OdbcDataAdapter("SELECT ISNULL(idReferencia,0) AS idReferencia FROM BandejaEntrada WHERE idEncabezado=" + idEncabezado.ToString(), oConnection);
            myConsulta.Fill(dt);
            if(dt.Rows.Count > 0)
                intRef = int.Parse(dt.Rows[0].ItemArray[0].ToString());


			String strSQL = "UPDATE BandejaEntrada SET ";
			strSQL = strSQL  + "idUsuario = " + intIdUsuario + ", idCliente = " + intIdCliente + ", Estado = " + intEstado.ToString() + ", " ;
			strSQL = strSQL  + "Comentarios = '" + strComentarios + "', ";
            if (intidReferencia != 0)
                strSQL = strSQL + "idReferencia = " + intidReferencia + ", ";

			// Datos Personales y Domicilio
			strSQL = strSQL  + "Nombre = '" + strNombre + "', Apellido = '" + strApellido + "', " ;
			strSQL = strSQL  + "idTipoPersona  = " + intIdTipoPersona.ToString() +", EstadoCivil  = " + intEstadoCivil.ToString() + ", TipoDocumento = " + intTipoDocumento.ToString() + ", Documento = '" + strDocumento + "', ";
            strSQL = strSQL + "Calle = '" + strCalle + "', Nro = '" + strNro + "', Dpto = '" + strDpto + "', Lote = '" + strLote + "', Manzana = '" + strManzana + "', Complejo = '" + strComplejo + "', Torre = '" + strTorre + "', ";
			strSQL = strSQL  + "Piso = '" + strPiso + "', Barrio = '" + strBarrio + "', CP = '" + strCP + "', Localidad = " + intLocalidad + ", Provincia = " + intProvincia + ", ";
			//AUTOMOVILES
			strSQL = strSQL  + "AUTDominio = '" + strDominio + "', AUTRegistro = '" + strRegistro + "', AUTCalleRegistro = '" + strCalleRegistro + "', AUTNroRegistro = '" + strNroRegistro + "', AUTDptoRegistro = '" + strDptoRegistro + "', AUTPisoRegistro = '" + strPisoRegistro + "', AUTBarrioRegistro = '" + strBarrioRegistro + "', AUTCPRegistro = '" + strCPRegistro + "', AUTLocalidadRegistro = " + intLocalidadRegistro + ", AUTProvinciaRegistro = " + intProvinciaRegistro + ", ";
			//GRAVAMENES
			strSQL = strSQL  + "GRAVidTipoGravamen = " + intidTipoGravamen.ToString() + ", GRAVFolio = '" + strFolio + "', GRAVTomo = '" + strTomo + "', GRAVAno = '" + strAno + "', ";
			//PROPIEDADES
			strSQL = strSQL  + "PROPMatricula = '" + strMatricula + "', PropTipo = " + intPropTipo.ToString() + ", PROPFolio = '" + strPropFolio + "', PROPTomo = '" + strPropTomo + "', PROPAno = '" + strPropAno + "', ";
            //PROPIEDADES OTRA PROVINCIA
            strSQL = strSQL + "PROPProvincia = " + intProvinciaOtra.ToString() + ", PROPLocalidad = " + intLocalidadOtra.ToString() + ", ";
            // AMBIENTAL
			strSQL = strSQL  + "AMBNombreCony = '" + strNombreCony + "', AMBApellidoCony = '" + strApellidoCony + "', AMBTipoDoc = " + intAMBTipoDoc.ToString() + ", AMBDocumento = '" + strAMBDocumento + "', AMBTelefono = '" + AMBTelefono + "', AMBEMail = '" + AMBEMail +"', ";
			// CATASTRO
            strSQL = strSQL + "TipoCatastro = " + intTipoCatastro.ToString() + ", CatNumero = '" + strNumeroCatastro + "', CatCalle = '" + strCatCalle.Replace("'", "''") + "', CatNro = '" + strCatNro + "', CatDepto = '" + strCatDpto + "', CatPiso = '" + strCatPiso + "', CatBarrio = '" + strCatBarrio + "', CatCP = '" + strCatCP + "', CatLocalidad = " + intCatLocalidad + ", CatProvincia = " + intCatProvincia + ", ";
			//EMPRESA
            strSQL = strSQL + "RazonSocial = '" + strRazonSocial + "', NombreFantasia = '" + strNombreFantasia + "', CargoEmpresa = '" + strCargo + "', TelefonoEmpresa = '" + strTelefonoEmpresa + "', Rubro = '" + strRubro + "', Cuit = '" + strCuit + "', CalleEmpresa = '" + strCalleEmpresa.Replace("'", "''") + "', NroEmpresa = '" + strNroEmpresa + "', DptoEmpresa = '" + strDptoEmpresa + "', PisoEmpresa = '" + strPisoEmpresa + "', BarrioEmpresa = '" + strBarrioEmpresa + "', CPEmpresa = '" + strCPEmpresa + "', LocalidadEmpresa = " + intLocalidadEmpresa + ", ProvinciaEmpresa = " + intProvinciaEmpresa + ", ";
			strSQL = strSQL  + "RegPubFolio = '" + strRegPubFolio + "', RegPubTomo = '" + strRegPubTomo + "', RegPubAno = '" + strRegPubAno + "', ";

			strSQL = strSQL  + "ConFoto = " + intConFoto.ToString() + ", Caracter = " + intCaracter.ToString();
			strSQL = strSQL  + ", DescripcionInf = '" + TraerDescripcionInforme() + "' ";
            strSQL = strSQL + ", txtLocalidad = '" + strLocalidad + "' ";
            strSQL = strSQL + ", Sexo = " + intSexo + " ";
            strSQL = strSQL + ", FechaFallecido = '" + strFechaFallecido + "' ";
            strSQL = strSQL + ", LugarFallecido = '" + strLugarFallecido + "' ";
            strSQL = strSQL + ", ActaFallecido = '" + strActaFallecido + "' ";
            strSQL = strSQL + ", TomoFallecido = '" + strTomoFallecido + "' ";
            strSQL = strSQL + ", FolioFallecido = '" + strFolioFallecido + "' ";
            
			strSQL = strSQL  + " WHERE idEncabezado =  " + idEncabezado.ToString();

			try
			{
                OdbcCommand myCommand = new OdbcCommand(strSQL, oConnection);
				myCommand.ExecuteNonQuery();

                //Elimino la referencia que no tiene asociado una solicitud
                if (intRef != 0 && intRef != intidReferencia)
                {
                    strSQL = "sp_deleteReferencia " + intRef;
                    myCommand = new OdbcCommand(strSQL, oConnection);
                    myCommand.ExecuteNonQuery();
                }

				int MaxID = idEncabezado; 

				String strAuditoria = "INSERT INTO HistoricoAcciones (idCliente, idUsuario, Instante, Evento, Observaciones, idTipoObjeto, idEstado, idReferencia) VALUES (";
				strAuditoria = strAuditoria  + intIdCliente + "," + intIdUsuario  + ", getdate(), 'Modificación de Informe', 'Modificación de Informe', 1" + ", 5," + MaxID.ToString() + ")";

				myCommand = new OdbcCommand(strAuditoria, oConnection);
				myCommand.ExecuteNonQuery();



                //Transferido
                string strEstadoTransferido = "";
                string strTransferido = "";
                string descrInformeHistorial = "";
                if (IdEncabezadoTransferido != null)
                {
                    strEstadoTransferido = "UPDATE bandejaentrada SET Estado=10 " +
                    " WHERE idEncabezado=" + IdEncabezadoTransferido;

                    myCommand = new OdbcCommand(strEstadoTransferido, oConnection);
                    myCommand.ExecuteNonQuery();

                    strTransferido = "INSERT INTO informepropiedadtransferido " +
                        "(idEncabezadoPadre, idEncabezado, fecha) VALUES " +
                        "(" + IdEncabezadoTransferido + ", " + idEncabezado.ToString() + ", getdate())";

                    myCommand = new OdbcCommand(strTransferido, oConnection);
                    myCommand.ExecuteNonQuery();
                    descrInformeHistorial = TraerDescripcionInforme().Replace("'", "''").Replace("<B>", "").Replace("</B>", "");
                    String strAuditoria2 = "INSERT INTO HistoricoAcciones (idCliente, idUsuario, Instante, Evento, Observaciones, idTipoObjeto, idEstado, idReferencia) VALUES " +
                        "(" + intIdCliente + "," + intIdUsuario + ", getdate(), 'Informe Transferido', 'Informe Transferido a " + descrInformeHistorial + "', 1" + ", 10," + IdEncabezadoTransferido + ")";

                    myCommand = new OdbcCommand(strAuditoria2, oConnection);
                    myCommand.ExecuteNonQuery();
                }


				oConnection.Close();
			} 			
			catch (Exception e)
			{	
				string p = e.Message;
				return false;
			}
			return true;
		}

		public bool Borrar(int idEncabezado)
		{
			OdbcConnection oConnection = this.OpenConnection();

            String strSQLTransferido = "Delete from informepropiedadtransferido where idEncabezado = " + idEncabezado.ToString();
			String strSQL = "Delete from BandejaEntrada where estado=1 AND idEncabezado = " + idEncabezado.ToString();
			
			String strAuditoria = "INSERT INTO HistoricoAcciones (idCliente, idUsuario, Instante, Evento, Observaciones, idTipoObjeto, idReferencia, idEstado) VALUES (";
            strAuditoria = strAuditoria + intIdCliente + "," + intIdUsuario + ", getdate(), 'Eliminación de Informe', 'Eliminación del Informe Nro." + idEncabezado.ToString() + "' ,1," + idEncabezado.ToString() + "," + Estado.ToString() + ")";

			try
			{
                OdbcCommand myCommand = new OdbcCommand(strSQLTransferido, oConnection);
                myCommand.ExecuteNonQuery();
                myCommand = new OdbcCommand(strSQL, oConnection);
				myCommand.ExecuteNonQuery();
				myCommand = new OdbcCommand(strAuditoria, oConnection);
				myCommand.ExecuteNonQuery();
				oConnection.Close();
			} 			
			catch(Exception e)
			{
				return false;
			}
			return true;
		}

		public DataTable TraerEstados(bool Intra)
		{
			
			OdbcConnection oConnection = this.OpenConnection();
			DataSet ds = new DataSet();
			OdbcDataAdapter myConsulta;
            if (Intra) myConsulta = new OdbcDataAdapter("select idEstado, NombreEstado, DescripcionEstado, Activo from EstadoInformes where Activo = 1 ", oConnection);
            else myConsulta = new OdbcDataAdapter("select idEstado, NombreEstadoExtra AS NombreEstado, DescripcionEstado, Activo from EstadoInformes where Activo = 1 ", oConnection);
			
			myConsulta.Fill(ds);
			try
			{
				oConnection.Close();
			} 			
			catch {}

			return ds.Tables[0];

		}

		public void cargarEncabezado(int idEncabezado)
		{
			
			OdbcConnection oConnection = this.OpenConnection();
			DataSet ds = new DataSet();
			/*String strSQL = "SELECT B.*, E.*, C.*, TD.Descripcion as strTipoDocumento, EC.Descripcion as strEstadoCivil, TG.Descripcion as strTipoGravamen, R.Descripcion as NombreReferencia ";
			strSQL = strSQL + " FROM BandejaEntrada B, tiposInformes T, EstadoInformes E, Clientes C, TipoDocumento TD, EstadoCivil EC, TiposGravamenes TG, Referencias R ";
			strSQL = strSQL + " WHERE B.idTipoInforme = T.idTipoInforme ";
			strSQL = strSQL + " AND B.Estado = E.idEstado ";
			strSQL = strSQL + " AND B.idCliente = C.idCliente ";
			strSQL = strSQL + " AND B.TipoDocumento = TD.idTipoDocumento ";
			strSQL = strSQL + " AND B.EstadoCivil = EC.idEstadoCivil ";
			strSQL = strSQL + " AND B.GRAVidTipoGravamen = TG.idTipoGravamen ";
            strSQL = strSQL + " AND B.idReferencia *= R.idReferencia ";*/

            String strSQL = "SELECT B.*, E.*, C.*, TD.Descripcion as strTipoDocumento, EC.Descripcion as strEstadoCivil, TG.Descripcion as strTipoGravamen, R.Descripcion as NombreReferencia ";
            strSQL = strSQL + " FROM bandejaentrada AS B ";
            strSQL = strSQL + " Left Join referencias AS R ON R.idReferencia = B.idReferencia ";
            strSQL = strSQL + " Inner Join estadoinformes AS E ON E.idEstado = B.Estado ";
            strSQL = strSQL + " Inner Join tiposinformes AS T ON T.idTipoInforme = B.idTipoInforme ";
            strSQL = strSQL + " Inner Join clientes AS C ON C.IdCliente = B.idCliente ";
            strSQL = strSQL + " Inner Join tipodocumento AS TD ON TD.idTipoDocumento = B.TipoDocumento ";
            strSQL = strSQL + " Inner Join tiposgravamenes AS TG ON TG.idTipoGravamen = B.GRAVidTipoGravamen ";
            strSQL = strSQL + " Inner Join estadocivil AS EC ON EC.idEstadoCivil = B.EstadoCivil ";
			strSQL = strSQL + " AND B.idEncabezado = " + idEncabezado.ToString();
			OdbcDataAdapter myConsulta = new OdbcDataAdapter(strSQL, oConnection);
			myConsulta.Fill(ds);
			try
			{
				oConnection.Close();
			} 			
			catch {}

			intIdEncabezado = int.Parse(ds.Tables[0].Rows[0]["idEncabezado"].ToString()); 
			intIdTipoInforme = int.Parse(ds.Tables[0].Rows[0]["idTipoInforme"].ToString());
            if (ds.Tables[0].Rows[0]["idReferencia"].ToString() != "" && ds.Tables[0].Rows[0]["idReferencia"].ToString() != null)
            {
                intidReferencia = int.Parse(ds.Tables[0].Rows[0]["idReferencia"].ToString());
                strNombreReferencia = ds.Tables[0].Rows[0]["NombreReferencia"].ToString();
            }
			intIdCliente = int.Parse(ds.Tables[0].Rows[0]["idCliente"].ToString());
			intIdUsuario = int.Parse(ds.Tables[0].Rows[0]["idUsuario"].ToString());
            strUsuarioCliente = ds.Tables[0].Rows[0]["UsuarioCliente"].ToString();
			intEstado = int.Parse(ds.Tables[0].Rows[0]["Estado"].ToString());
			intCaracter= int.Parse(ds.Tables[0].Rows[0]["Caracter"].ToString());
			intConFoto= int.Parse(ds.Tables[0].Rows[0]["ConFoto"].ToString());
			intIdTipoPersona = int.Parse(ds.Tables[0].Rows[0]["IdTipoPersona"].ToString());
			strNombre = ds.Tables[0].Rows[0]["Nombre"].ToString();
			strApellido = ds.Tables[0].Rows[0]["Apellido"].ToString();
			intEstadoCivil = int.Parse(ds.Tables[0].Rows[0]["EstadoCivil"].ToString());
			strEstadoCivil = ds.Tables[0].Rows[0]["strEstadoCivil"].ToString();
			intTipoDocumento = int.Parse(ds.Tables[0].Rows[0]["TipoDocumento"].ToString());
			strTipoDocumento = ds.Tables[0].Rows[0]["strTipoDocumento"].ToString();
			strDocumento = ds.Tables[0].Rows[0]["Documento"].ToString();
			strCalle = ds.Tables[0].Rows[0]["Calle"].ToString();
			strNro = ds.Tables[0].Rows[0]["Nro"].ToString();
			strDpto = ds.Tables[0].Rows[0]["Dpto"].ToString();
			strPiso = ds.Tables[0].Rows[0]["Piso"].ToString();
			strBarrio = ds.Tables[0].Rows[0]["Barrio"].ToString();
            strLote = ds.Tables[0].Rows[0]["Lote"].ToString();
            strManzana = ds.Tables[0].Rows[0]["Manzana"].ToString();
            strComplejo = ds.Tables[0].Rows[0]["Complejo"].ToString();
            strTorre = ds.Tables[0].Rows[0]["Torre"].ToString();
			strCP = ds.Tables[0].Rows[0]["CP"].ToString();
			intLocalidad = int.Parse(ds.Tables[0].Rows[0]["Localidad"].ToString());
			intProvincia = int.Parse(ds.Tables[0].Rows[0]["Provincia"].ToString());
			//AUTOMOTORES
			strDominio = ds.Tables[0].Rows[0]["AUTDominio"].ToString();
			strRegistro = ds.Tables[0].Rows[0]["AUTRegistro"].ToString();
			strCalleRegistro = ds.Tables[0].Rows[0]["AUTCalleRegistro"].ToString();
			strNroRegistro = ds.Tables[0].Rows[0]["AUTNroRegistro"].ToString();
			strDptoRegistro = ds.Tables[0].Rows[0]["AUTDptoRegistro"].ToString();
			strPisoRegistro = ds.Tables[0].Rows[0]["AUTPisoRegistro"].ToString();
			strBarrioRegistro = ds.Tables[0].Rows[0]["AUTBarrioRegistro"].ToString();
			strCPRegistro = ds.Tables[0].Rows[0]["AUTCPRegistro"].ToString();
			intLocalidadRegistro = int.Parse(ds.Tables[0].Rows[0]["AUTLocalidadRegistro"].ToString());
			intProvinciaRegistro = int.Parse(ds.Tables[0].Rows[0]["AUTProvinciaRegistro"].ToString());
			//GRAVAMENES
			if (ds.Tables[0].Rows[0]["GRAVidTipoGravamen"].ToString() != "")
				intidTipoGravamen= int.Parse(ds.Tables[0].Rows[0]["GRAVidTipoGravamen"].ToString());
			strTipoGravamen = ds.Tables[0].Rows[0]["strTipoGravamen"].ToString();
			strFolio= ds.Tables[0].Rows[0]["GRAVFolio"].ToString();
			strTomo= ds.Tables[0].Rows[0]["GRAVTomo"].ToString();
			strAno= ds.Tables[0].Rows[0]["GRAVAno"].ToString();
			//INFO PROPIEDAD
			intPropTipo= int.Parse(ds.Tables[0].Rows[0]["PROPTipo"].ToString());
			strMatricula= ds.Tables[0].Rows[0]["PROPMatricula"].ToString();
			strPropFolio= ds.Tables[0].Rows[0]["PropFolio"].ToString();
			strPropAno= ds.Tables[0].Rows[0]["PropAno"].ToString();
			strPropTomo= ds.Tables[0].Rows[0]["PropTomo"].ToString();
            // INFO PROPIEDAD OTRA PROVINCIA
            if (ds.Tables[0].Rows[0]["PROPLocalidad"].ToString() != "")
                intLocalidadOtra = int.Parse(ds.Tables[0].Rows[0]["PROPLocalidad"].ToString());
            if (ds.Tables[0].Rows[0]["PROPProvincia"].ToString() != "")
                intProvinciaOtra = int.Parse(ds.Tables[0].Rows[0]["PROPProvincia"].ToString());
			// INFO AMBIENTE
			strNombreCony= ds.Tables[0].Rows[0]["AMBNombreCony"].ToString();
			strApellidoCony= ds.Tables[0].Rows[0]["AMBApellidoCony"].ToString();
			if (ds.Tables[0].Rows[0]["AMBTipoDoc"].ToString() != "")
				intAMBTipoDoc= int.Parse(ds.Tables[0].Rows[0]["AMBTipoDoc"].ToString());
            strAMBDocumento= ds.Tables[0].Rows[0]["AMBDocumento"].ToString();
            strAMBTelefono = ds.Tables[0].Rows[0]["AMBTelefono"].ToString();
            strAMBEMail = ds.Tables[0].Rows[0]["AMBEMail"].ToString();
			// INFO CATASTRO
			if (ds.Tables[0].Rows[0]["TipoCatastro"].ToString() != "")
				intTipoCatastro= int.Parse(ds.Tables[0].Rows[0]["TipoCatastro"].ToString());
			strNumeroCatastro= ds.Tables[0].Rows[0]["CatNumero"].ToString();
			intCatLocalidad= int.Parse(ds.Tables[0].Rows[0]["CatLocalidad"].ToString());
			intCatProvincia= int.Parse(ds.Tables[0].Rows[0]["CatProvincia"].ToString());
			strCatCP= ds.Tables[0].Rows[0]["CatCP"].ToString();
			strCatBarrio= ds.Tables[0].Rows[0]["CatBarrio"].ToString();
			strCatCalle= ds.Tables[0].Rows[0]["CatCalle"].ToString();
			strCatDpto= ds.Tables[0].Rows[0]["CatDepto"].ToString();
			strCatNro= ds.Tables[0].Rows[0]["CatNro"].ToString();
			strCatPiso= ds.Tables[0].Rows[0]["CatPiso"].ToString();
			// EMPRESAS
			strRazonSocial= ds.Tables[0].Rows[0]["RazonSocial"].ToString();
			strNombreFantasia= ds.Tables[0].Rows[0]["NombreFantasia"].ToString();
            strCargo = ds.Tables[0].Rows[0]["CargoEmpresa"].ToString();
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
			strComentarios= ds.Tables[0].Rows[0]["Comentarios"].ToString();
			strObservaciones= ds.Tables[0].Rows[0]["Observaciones"].ToString();
			strApreciaciones= ds.Tables[0].Rows[0]["Apreciaciones"].ToString();
            strFechaFin = ds.Tables[0].Rows[0]["FechaFin"].ToString();
		    //Integración FOX
            if( ds.Tables[0].Rows[0]["idFox"].ToString() != "" )
                intIdFOX = int.Parse(ds.Tables[0].Rows[0]["idFox"].ToString());

            // Partidas Defuncion
            if (ds.Tables[0].Rows[0]["Sexo"].ToString() != "")
                intSexo = int.Parse(ds.Tables[0].Rows[0]["Sexo"].ToString());

            strFechaFallecido = ds.Tables[0].Rows[0]["FechaFallecido"].ToString();
            strLugarFallecido = ds.Tables[0].Rows[0]["LugarFallecido"].ToString();
            strActaFallecido = ds.Tables[0].Rows[0]["ActaFallecido"].ToString();
            strTomoFallecido = ds.Tables[0].Rows[0]["TomoFallecido"].ToString();
            strFolioFallecido = ds.Tables[0].Rows[0]["FolioFallecido"].ToString();
            strLogoEmpresa = ds.Tables[0].Rows[0]["logoEmpresa"].ToString();
		}

		public bool CambiarEstado(int idInforme)
		{
			OdbcConnection oConnection = OpenConnection();
			String strSQL = "UPDATE BandejaEntrada SET Estado = " + Estado.ToString();
			strSQL = strSQL  + ", Observaciones = '" + Observaciones + "'";
            strSQL = strSQL + ", Leido = " + Leido;
			//strSQL = strSQL  + "', idUsuario = " + intIdUsuario; //No deberia cambiar el usuario que cargo el informe en el encabezado
            strSQL = strSQL + ", FechaFin = getdate()";
			strSQL = strSQL  + " WHERE idEncabezado = " + idInforme.ToString();

			String strAuditoria = "INSERT INTO HistoricoAcciones (idCliente, idUsuario, Instante, Evento, Observaciones, idTipoObjeto, idReferencia, idEstado) VALUES (";
			strAuditoria = strAuditoria  + intIdCliente + "," + intIdUsuario  + ", getdate(), 'Cambio de Estado de Informe', '" + Observaciones + "' ,1," + idInforme.ToString() + "," + Estado.ToString() + ")";
            
			try
			{
				OdbcCommand	myCommand = new OdbcCommand(strSQL, oConnection);
				myCommand.ExecuteNonQuery();
				myCommand = new OdbcCommand(strAuditoria, oConnection);
				myCommand.ExecuteNonQuery();
                /*
				if (Estado == 3)
				{
					if (intIdTipoInforme == 1)
					{
						if (intCaracter != -1)
							CuentaCorrienteApp.AsentarMovimiento(intIdCliente, idInforme, intIdTipoInforme, (byte)intCaracter);
						else
							CuentaCorrienteApp.AsentarMovimiento(intIdCliente, idInforme, intIdTipoInforme);
					}
					else
					{
						if (intIdTipoInforme == 5 || intIdTipoInforme == 6 || intIdTipoInforme == 7)
							if (intConFoto != 0)
								CuentaCorrienteApp.AsentarMovimiento(intIdCliente, idInforme, intIdTipoInforme, (byte) 1);
							else
								CuentaCorrienteApp.AsentarMovimiento(intIdCliente, idInforme, intIdTipoInforme, (byte) 2);
						else
							CuentaCorrienteApp.AsentarMovimiento(intIdCliente, idInforme, intIdTipoInforme);

					}
				} 
                 */ 
				oConnection.Close();
			} 			
			catch (Exception e) 
			{
				return false;
			}
           
			return true;
		}


        public int crearGrupoCambioEstado(int idUsuarioLocal, int idTipoInforme)
        {
            int MaxID = 0;

            String strSQL = "Insert into informesGrupoCambioEstado (idTipoInforme, idUsuario) values (" + idTipoInforme + ", " + idUsuarioLocal + ")";

            String strMaxID = "SELECT MAX(id) as MaxId FROM informesGrupoCambioEstado";

            try
            {
                OdbcConnection oConnection = this.OpenConnection();
                OdbcCommand myCommand = new OdbcCommand(strSQL, oConnection);
                myCommand.ExecuteNonQuery();

                MaxID = ObtenerMaxID(strMaxID, oConnection);

                oConnection.Close();
            }
            catch (Exception e)
            {
                string p = e.Message;
                return MaxID;
            }
            return MaxID;
        }


        public bool crearCambiosEstadoInformes(int idGrupo, int idInforme, int estado)
        {
            string strDescripcion = DateTime.Today.ToShortDateString() + " " + DateTime.Today.Hour.ToString() + ":" + DateTime.Today.Minute.ToString();

            String strSQL = "Insert into informesCambioEstado (idTipoGrupo, idInforme, estado) values (" + idGrupo + ", " + idInforme + ", " + estado + ")";

            try
            {
                OdbcConnection oConnection = this.OpenConnection();
                OdbcCommand myCommand = new OdbcCommand(strSQL, oConnection);
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


        public bool CambiarLeido(int idInforme)
        {
            OdbcConnection oConnection = OpenConnection();
            String strSQL = "UPDATE BandejaEntrada SET leido = " + Leido.ToString();
            strSQL = strSQL + " WHERE idEncabezado = " + idInforme.ToString();
            try
            {
                OdbcCommand myCommand = new OdbcCommand(strSQL, oConnection);
                myCommand.ExecuteNonQuery();
                oConnection.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool CambiarEntregado(int idInforme)
        {
            OdbcConnection oConnection = OpenConnection();
            String strSQL = "UPDATE BandejaEntrada SET entregado = " + Entregado.ToString();
            strSQL = strSQL + " WHERE idEncabezado = " + idInforme.ToString();
            try
            {
                OdbcCommand myCommand = new OdbcCommand(strSQL, oConnection);
                myCommand.ExecuteNonQuery();
                oConnection.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool AsignarFechaCondicional(int idInforme)
        {
            OdbcConnection oConnection = OpenConnection();
            String strSQL = "UPDATE BandejaEntrada SET FechaCondicional = getdate() " +
                " WHERE idEncabezado = " + idInforme.ToString();
            try
            {
                OdbcCommand myCommand = new OdbcCommand(strSQL, oConnection);
                myCommand.ExecuteNonQuery();
                oConnection.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool CambiarEstadoCondicional(int idInforme, string idEstado)
        {
            OdbcConnection oConnection = OpenConnection();
            String strSQL = "UPDATE BandejaEntrada SET ";
            if (idEstado != "&nbsp;")
                strSQL = strSQL + "EstadoCondicional = " + idEstado.ToString();
            else
                strSQL = strSQL + "EstadoCondicional = NULL";
            strSQL = strSQL + " WHERE idEncabezado = " + idInforme.ToString();
            try
            {
                OdbcCommand myCommand = new OdbcCommand(strSQL, oConnection);
                myCommand.ExecuteNonQuery();
                oConnection.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }


		public bool CargarApreciacion(int idInforme)
		{
			OdbcConnection oConnection = this.OpenConnection();
			String strSQL = "UPDATE BandejaEntrada SET Apreciaciones = '" + Apreciaciones;
			strSQL = strSQL  + "' WHERE idEncabezado = " + idInforme.ToString();

			String strAuditoria = "INSERT INTO HistoricoAcciones (idCliente, idUsuario, Instante, Evento, Observaciones, idTipoObjeto, idReferencia, idEstado) VALUES (";
			strAuditoria = strAuditoria  + intIdCliente + "," + intIdUsuario  + ", getdate(), 'Ingreso de Apreciación del Cliente', '" + Apreciaciones + "' ,2," + idInforme.ToString() + "," + Estado.ToString() + ")";
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

		public bool Cancelar(int idEncabezado, bool Extranet)
		{

			OdbcConnection oConnection = this.OpenConnection();
			String strSQL = "UPDATE BandejaEntrada SET Estado = 4";
			strSQL = strSQL  + ", Observaciones = 'Cancelado por el Cliente' ";
			strSQL = strSQL  + " WHERE idEncabezado = " + idEncabezado.ToString();
            if (Extranet)
                strSQL = strSQL + " AND estado=1 ";

			String strAuditoria = "INSERT INTO HistoricoAcciones (idCliente, idUsuario, Instante, Evento, Observaciones, idTipoObjeto, idReferencia, idEstado) VALUES (";
			strAuditoria = strAuditoria  + intIdCliente + "," + intIdUsuario  + ", getdate(), 'Cancelación de Informe', 'Cancelación del Informe Nro." + idEncabezado.ToString() +"' ,1," + idEncabezado.ToString() + ",4)";

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



        public int ObtenerUltimoInforme()
        {
            String strMaxID = "SELECT MAX(idEncabezado) as MaxId FROM BandejaEntrada";
            OdbcConnection oConnection = this.OpenConnection();
            int MaxID = 0;
            try
            {
                MaxID = ObtenerMaxID(strMaxID, oConnection);
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
