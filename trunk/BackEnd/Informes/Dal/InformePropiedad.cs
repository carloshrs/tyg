using System;
using System.Data;
using System.Data.Odbc;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;


namespace ar.com.TiempoyGestion.BackEnd.Informes.Dal
{
	/// <summary>
	/// Summary description for ClienteDal.
	/// </summary>
	public class InformePropiedadApp : GenericDal
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
		private string strBarrio;
		private string strPedania;
		private int intIdLocalidad;
		private int intIdProvincia;
		private string strDepartamento;
		private string strPH;
		private string strLote;
		private string strManzana;
		private string strSuperficie;
		private string strProporcion;
		private string strGravamenes;
        private string strInformesAnteriores;
		private string strObservaciones;
		private string strMorosidad;
		private string strResultado;
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
        private string strPropiedadDe;
        private string strUbicadaEn;
        private string strDominioAntecedente;



		public InformePropiedadApp() : base()
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

		public string Pedania
		{
			get
			{
				return strPedania;
			}
			set
			{
				strPedania = value;
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

		public string Departamento
		{
			get
			{
				return strDepartamento;
			}
			set
			{
				strDepartamento = value;
			}
		}

		public string PH
		{
			get
			{
				return strPH;
			}
			set
			{
				strPH = value;
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

		public string Superficie
		{
			get
			{
				return strSuperficie;
			}
			set
			{
				strSuperficie = value;
			}
		}

		public string Proporcion
		{
			get
			{
				return strProporcion;
			}
			set
			{
				strProporcion = value;
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

		public string Morosidad
		{
			get
			{
				return strMorosidad;
			}
			set
			{
				strMorosidad = value;
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

        public string PropiedadDe
        {
            get
            {
                return strPropiedadDe;
            }
            set
            {
                strPropiedadDe = value;
            }
        }

        public string UbicadaEn
        {
            get
            {
                return strUbicadaEn;
            }
            set
            {
                strUbicadaEn = value;
            }
        }

        public string DominioAntecedente
        {
            get
            {
                return strDominioAntecedente;
            }
            set
            {
                strDominioAntecedente = value;
            }
        }

		#endregion

		#region Métodos Publicos

		#region Crear()

		public bool Crear()
		{
			OdbcConnection oConnection = this.OpenConnection();
			String strSQL = "Insert into InformePropiedad (idInforme, idTipo, Matricula, Folio, Tomo, Anio, Barrio, Pedania, Provincia, Localidad, Departamento, PH, ";
			strSQL = strSQL  + "Lote, Manzana, Superficie, Proporcion, Gravamenes, Observaciones, Morosidad, Resultado, InformesAnteriores, PropiedadDe, UbicadaEn, DominioAntecedente) ";
			strSQL = strSQL  + " values (" + intIdInforme + ", " + intTipoProp + ",'" + strMatricula + "', '" + strFolio + "', '" + strTomo + "', '" + strAno + "','" + strBarrio + "','" + strPedania + "'," + intIdProvincia + "," + intIdLocalidad + ",'" + strDepartamento + "','" + strPH + "',";
            strSQL = strSQL + " '" + strLote + "','" + strManzana + "','" + strSuperficie + "','" + strProporcion + "','" + strGravamenes.Replace("'", "''") + "','" + strObservaciones.Replace("'", "''") + "','" + strMorosidad + "','" + strResultado + "','" + strInformesAnteriores.Replace("'", "''") + "',";
            strSQL = strSQL + " '" + strPropiedadDe.Replace("'", "''") + "','" + strUbicadaEn + "','" + strDominioAntecedente + "')";

			String strMaxID = "SELECT MAX(idInforme) as MaxId FROM InformePropiedad";

			try
			{
				OdbcCommand	myCommand = new OdbcCommand(strSQL, oConnection);
				myCommand.ExecuteNonQuery();

				int MaxID = ObtenerMaxID(strMaxID, oConnection); 

				String strAuditoria = "INSERT INTO HistoricoAcciones (idCliente, idUsuario, Instante, Evento, Observaciones, idTipoObjeto, idEstado, idReferencia) VALUES (";
				strAuditoria = strAuditoria  + intIdCliente + "," + intIdUsuario  + ", getdate(), 'Creación de Informe', 'Solicitud de Informe', 1" + ", 1," + MaxID.ToString() + ")";

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
			String strSQL = "UPDATE InformePropiedad SET ";
			strSQL = strSQL  + "IdTipo = " + intTipoProp + ", Matricula = '" + strMatricula + "', Folio = '" + strFolio + "', Tomo = '" + strTomo + "', Anio = '" + strAno + "', Barrio = '" + strBarrio + "', Pedania = '" + strPedania + "', " ;
			strSQL = strSQL  + "Provincia = " + intIdProvincia + ", Localidad = " + intIdLocalidad + ", Departamento = '" + strDepartamento + "', PH = '" + strPH + "', " ;
			strSQL = strSQL  + "Lote = '" + strLote + "', Manzana = '" + strManzana + "', Superficie = '" + strSuperficie + "', " ;
            strSQL = strSQL + "Proporcion = '" + strProporcion + "', Gravamenes = '" + strGravamenes.Replace("'", "''") + "', InformesAnteriores = '" + strInformesAnteriores.Replace("'", "''") + "', Observaciones = '" + strObservaciones.Replace("'", "''") + "', ";
			strSQL = strSQL  + "Morosidad = '" + strMorosidad + "', Resultado = '" + strResultado + "', " ;
            strSQL = strSQL + "PropiedadDe = '" + strPropiedadDe.Replace("'", "''") + "', UbicadaEn = '" + strUbicadaEn + "', DominioAntecedente = '" + strDominioAntecedente + "' ";
			strSQL = strSQL  + " WHERE idInforme =  " + idInforme.ToString();
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
		
		#region Borrar(int idInforme)

		public bool Borrar(int idInforme)
		{
			OdbcConnection oConnection = this.OpenConnection();
			String strSQL = "Delete from InformePropiedad where idInforme = " + intIdInforme.ToString();
			
			String strAuditoria = "INSERT INTO HistoricoAcciones (idCliente, idUsuario, Instante, Evento, Observaciones, idTipoObjeto, idReferencia, idEstado) VALUES (";
			strAuditoria = strAuditoria  + intIdCliente + "," + intIdUsuario  + ", getdate(), 'Eliminación de Informe', 'Eliminación del Informe Nro." + idInforme.ToString() + "' ,1," + idInforme.ToString() + "," + Estado.ToString() + ")";

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

		#region cargarInformePropiedad(int idInforme)

		public bool cargarInformePropiedad(int idInforme)
		{			
			OdbcConnection oConnection = this.OpenConnection();
			DataSet ds = new DataSet();
			String strSQL = "SELECT * FROM InformePropiedad ";
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
			strBarrio = ds.Tables[0].Rows[0]["Barrio"].ToString();
			strPedania = ds.Tables[0].Rows[0]["Pedania"].ToString();
			intIdLocalidad = int.Parse(ds.Tables[0].Rows[0]["Localidad"].ToString());
			intIdProvincia = int.Parse(ds.Tables[0].Rows[0]["Provincia"].ToString());
			strDepartamento = ds.Tables[0].Rows[0]["Departamento"].ToString();
			strPH = ds.Tables[0].Rows[0]["PH"].ToString();
			strLote = ds.Tables[0].Rows[0]["Lote"].ToString();
			strManzana = ds.Tables[0].Rows[0]["Manzana"].ToString();
			strSuperficie = ds.Tables[0].Rows[0]["Superficie"].ToString();
			strProporcion = ds.Tables[0].Rows[0]["Proporcion"].ToString();
			strGravamenes = ds.Tables[0].Rows[0]["Gravamenes"].ToString();
            strInformesAnteriores = ds.Tables[0].Rows[0]["InformesAnteriores"].ToString();
			strObservaciones = ds.Tables[0].Rows[0]["Observaciones"].ToString();
			strMorosidad = ds.Tables[0].Rows[0]["Morosidad"].ToString();
			strResultado = ds.Tables[0].Rows[0]["Resultado"].ToString();
            strPropiedadDe = ds.Tables[0].Rows[0]["PropiedadDe"].ToString();
            strUbicadaEn = ds.Tables[0].Rows[0]["UbicadaEn"].ToString();
            strDominioAntecedente = ds.Tables[0].Rows[0]["DominioAntecedente"].ToString();

			return true;
		}

		#endregion

		#region CrearTitular()

		public bool CrearTitular()
		{
			OdbcConnection oConnection = this.OpenConnection();
			String strSQL = "Insert into informepropiedadtitulares (idInforme, idTipoPersona, Nombre, Apellido, IdTipoDocumento, NroDoc, IdEstadoCivil, Cuit, NombreFantasia, RazonSocial, Rubro, Porcentaje) ";
            strSQL = strSQL + " values (" + intIdInforme + ", " + intTipoPersona + ",'" + strNombreTitular.Replace("'", "''") + "','" + strApellidoTitular.Replace("'", "''") + "',";
            if (intTipoDocTitular == 0)
                strSQL = strSQL + "NULL";
            else
                strSQL = strSQL + intTipoDocTitular;
            if (strNroDocTitular == "0")
                strSQL = strSQL + ",NULL,";
            else
                strSQL = strSQL + ",'" + strNroDocTitular + "',";
            if(intEstadoCivilTitular == 0)
                strSQL = strSQL + "NULL";
            else
                strSQL = strSQL + intEstadoCivilTitular;
            strSQL = strSQL + ", '" + strCUITTitular + "', '" + strNombreFantasiaTitular.Replace("'", "''") + "', '" + strRazonSocialTitular.Replace("'", "''") + "', '" + strRubroTitular + "', '" + strPorcentajeTitular + "')"; 

			String strMaxID = "SELECT MAX(idInforme) as MaxId FROM informepropiedadtitulares";

			try
			{
				OdbcCommand	myCommand = new OdbcCommand(strSQL, oConnection);
				myCommand.ExecuteNonQuery();

				int MaxID = ObtenerMaxID(strMaxID, oConnection); 

				String strAuditoria = "INSERT INTO HistoricoAcciones (idCliente, idUsuario, Instante, Evento, Observaciones, idTipoObjeto, idEstado, idReferencia) VALUES (";
				strAuditoria = strAuditoria  + intIdCliente + "," + intIdUsuario  + ", getdate(), 'Creación de titular en Informe de Propiedad', 'Solicitud de Titular de Informe Propiedad', 1" + ", 1," + MaxID.ToString() + ")";

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

		#region ModificarTitular(int idTitular)

		public bool ModificarTitular(int idTitular)
		{
			OdbcConnection oConnection = this.OpenConnection();
			String strSQL = "UPDATE informepropiedadtitulares SET ";
			strSQL = strSQL  + "IdTipoPersona = " + intTipoPersona + ", Nombre = '" + strNombreTitular + "', Apellido = '" + strApellidoTitular + "', IdTipoDocumento = " + intTipoDocTitular + ", NroDoc = '" + strNroDocTitular + "', IdEstadoCivil = " + intEstadoCivilTitular + ", Cuit = '" + strCUITTitular + "', NombreFantasia = '" + strNombreFantasiaTitular + "', RazonSocial = '" + strRazonSocialTitular + "', Rubro = '" + strRubroTitular + "', Porcentaje = '" + strPorcentajeTitular + "' " ;
			strSQL = strSQL  + " WHERE idTitular =  " + idTitular.ToString();
			try
			{
				OdbcCommand	myCommand = new OdbcCommand(strSQL, oConnection);
				myCommand.ExecuteNonQuery();

				int MaxID = IdTitular;

				String strAuditoria = "INSERT INTO HistoricoAcciones (idCliente, idUsuario, Instante, Evento, Observaciones, idTipoObjeto, idEstado, idReferencia) VALUES (";
				strAuditoria = strAuditoria  + intIdCliente + "," + intIdUsuario  + ", getdate(), 'Modificación de titular de Informe de Propiedad', 'Modificación de titular de Informe de Propiedad', 1" + ", 5," + MaxID.ToString() + ")";

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

		#region BorrarTitular(int idTitular)

		public bool BorrarTitular(int idTitular)
		{
			OdbcConnection oConnection = this.OpenConnection();
			String strSQL = "Delete from informepropiedadtitulares where idTitular = " + idTitular.ToString();
			
			String strAuditoria = "INSERT INTO HistoricoAcciones (idCliente, idUsuario, Instante, Evento, Observaciones, idTipoObjeto, idReferencia, idEstado) VALUES (";
			strAuditoria = strAuditoria  + intIdCliente + "," + intIdUsuario  + ", getdate(), 'Eliminación de Titular de Informe de Propiedad', 'Eliminación de Titular de Informe de Propiedad" + idTitular.ToString() + "' ,1," + idTitular.ToString() + "," + Estado.ToString() + ")";

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

		#region BorrarTitulares(int lIdEncabezado)

		public static void BorrarTitulares(int lIdEncabezado)
		{
			String strSQL = "Delete from informepropiedadtitulares where idInforme = " + lIdEncabezado.ToString();
			
			try
			{
				StaticDal.EjecutarComando(strSQL);
			} 			
			catch 
			{}
		}
		
		#endregion

		#region TraerTitulares(int idInforme)

		public DataTable TraerTitulares(int idInforme)
		{
			
			OdbcConnection oConnection = this.OpenConnection();
			DataSet ds = new DataSet();
            string strSQL = "select it.idTitular, it.idTipoPersona, (it.Apellido+' '+it.Nombre) AS Nombre, " +
                "(td.descripcion +' '+ it.NroDoc) as NroDoc, ec.descripcion as EstadoCivil, it.Cuit, it.NombreFantasia, it.RazonSocial, it.Rubro, it.Porcentaje " + 
				"from informepropiedadtitulares it "+
                "left outer join tipodocumento td on td.idTipoDocumento = it.idTipoDocumento "+
                "left outer join estadocivil ec on ec.idEstadoCivil = it.idEstadoCivil "+
				"where it.idInforme = " + idInforme.ToString();
			OdbcDataAdapter myConsulta = new OdbcDataAdapter(strSQL, oConnection);
			myConsulta.Fill(ds);
			try
			{
				oConnection.Close();
			} 			
			catch {}

			return ds.Tables[0];
		}

		#endregion

		#region cargarTitular(int idTitular)

		public bool cargarTitular(int idTitular)
		{
			
			OdbcConnection oConnection = this.OpenConnection();
			DataSet ds = new DataSet();
			String strSQL = "SELECT * FROM informepropiedadtitulares ";
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
			intTipoPersona = int.Parse(ds.Tables[0].Rows[0]["idTipoPersona"].ToString()); 
			strNombreTitular = ds.Tables[0].Rows[0]["Nombre"].ToString();
			strApellidoTitular = ds.Tables[0].Rows[0]["Apellido"].ToString();
            if(ds.Tables[0].Rows[0]["IdTipoDocumento"].ToString() != "")
			    intTipoDocTitular = int.Parse(ds.Tables[0].Rows[0]["IdTipoDocumento"].ToString());
			strNroDocTitular = ds.Tables[0].Rows[0]["NroDoc"].ToString();
            if(ds.Tables[0].Rows[0]["IdEstadoCivil"].ToString() != "")
			    intEstadoCivilTitular = int.Parse(ds.Tables[0].Rows[0]["IdEstadoCivil"].ToString());
			strCUITTitular = ds.Tables[0].Rows[0]["Cuit"].ToString();
			strNombreFantasiaTitular = ds.Tables[0].Rows[0]["NombreFantasia"].ToString();
			strRazonSocialTitular = ds.Tables[0].Rows[0]["RazonSocial"].ToString();
			strRubroTitular = ds.Tables[0].Rows[0]["Rubro"].ToString();
			strPorcentajeTitular = ds.Tables[0].Rows[0]["Porcentaje"].ToString();
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
