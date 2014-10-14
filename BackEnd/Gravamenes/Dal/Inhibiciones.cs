using System;
using System.Data;
using System.Data.Odbc;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;

namespace ar.com.TiempoyGestion.BackEnd.Gravamenes.Dal
{
	/// <summary>
	/// Summary description for ClienteDal.
	/// </summary>
	public class InhibicionesDal : GenericDal
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

        private string strMedida;
        private string strDiario;
        private string strAno;
        private string strFecha;
        private string strTipoMedida;
        private string strOrdenadoPor;
        private string strSecretaria;
        private string strEnAutos;
        private string strTipoBusqueda;
        private string strInmueblesGravados;
        private string strAnotacionesDefinitivas;


		public InhibicionesDal() : base()
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


        public string Medida
        {
            get
            {
                return strMedida;
            }
            set
            {
                strMedida = value;
            }
        }


        public string Diario
        {
            get
            {
                return strDiario;
            }
            set
            {
                strDiario = value;
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

        public string TipoMedida
        {
            get
            {
                return strTipoMedida;
            }
            set
            {
                strTipoMedida = value;
            }
        }

        public string OrdenadoPor
        {
            get
            {
                return strOrdenadoPor;
            }
            set
            {
                strOrdenadoPor = value;
            }
        }

        public string Secretaria
        {
            get
            {
                return strSecretaria;
            }
            set
            {
                strSecretaria = value;
            }
        }

        public string EnAutos
        {
            get
            {
                return strEnAutos;
            }
            set
            {
                strEnAutos = value;
            }
        }


        public string TipoBusqueda
        {
            get
            {
                return strTipoBusqueda;
            }
            set
            {
                strTipoBusqueda = value;
            }
        }

        public string InmueblesGravados
        {
            get
            {
                return strInmueblesGravados;
            }
            set
            {
                strInmueblesGravados = value;
            }
        }

        public string AnotacionesDefinitivas
        {
            get
            {
                return strAnotacionesDefinitivas;
            }
            set
            {
                strAnotacionesDefinitivas = value;
            }
        }

		#endregion

		#region Métodos Publicos

		public bool Crear()
		{
			OdbcConnection oConnection = this.OpenConnection();
			String strSQL = "Insert into Inhibiciones (IdInforme, IdTipoPersona, Nombre, Apellido, idTipoDoc, NroDoc, Observaciones, "+
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
			String strSQL = "UPDATE Inhibiciones SET ";
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
			String strSQL = "SELECT * FROM Inhibiciones ";
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



        public bool cargarResultado(int idResultado)
        {

            OdbcConnection oConnection = this.OpenConnection();
            DataSet ds = new DataSet();
            String strSQL = "SELECT * FROM inhibicionesResultados ";
            strSQL = strSQL + "WHERE idResultado = " + idResultado.ToString();
            OdbcDataAdapter myConsulta = new OdbcDataAdapter(strSQL, oConnection);
            myConsulta.Fill(ds);
            try
            {
                oConnection.Close();
                intIdResultado = int.Parse(ds.Tables[0].Rows[0]["idResultado"].ToString());
            }
            catch
            {
                return false;
            }

            intIdInforme = int.Parse(ds.Tables[0].Rows[0]["idInforme"].ToString());
            strMedida = ds.Tables[0].Rows[0]["medida"].ToString();
            strDiario = ds.Tables[0].Rows[0]["diario"].ToString();
            strAno = ds.Tables[0].Rows[0]["ano"].ToString();
            strFecha = ds.Tables[0].Rows[0]["fecha"].ToString();
            strTipoMedida = ds.Tables[0].Rows[0]["tipoMedida"].ToString();
            strOrdenadoPor = ds.Tables[0].Rows[0]["ordenadopor"].ToString();
            strSecretaria = ds.Tables[0].Rows[0]["secretaria"].ToString();
            strEnAutos = ds.Tables[0].Rows[0]["enautos"].ToString();
            strTipoBusqueda = ds.Tables[0].Rows[0]["tipobusqueda"].ToString();
            strInmueblesGravados = ds.Tables[0].Rows[0]["inmueblesgravados"].ToString();
            strAnotacionesDefinitivas = ds.Tables[0].Rows[0]["anotacionesdefinitivas"].ToString();
            return true;
        }



        public bool CrearResultado()
        {
            OdbcConnection oConnection = this.OpenConnection();
            String strSQL = "Insert into inhibicionesResultados (idInforme, medida, diario, ano, fecha, tipoMedida, ordenadopor, " +
                            "secretaria, enautos, tipobusqueda, inmueblesgravados, anotacionesdefinitivas) " +
                            " VALUES (" + intIdInforme + ",'" + strMedida + "', '" + strDiario + "', '" + strAno + "', '" + strFecha + "', '" + strTipoMedida + "', '" + strOrdenadoPor + "', " +
                            "'" + strSecretaria + "', '" + strEnAutos + "', '" + strTipoBusqueda + "', '" + strInmueblesGravados + "', '" + strAnotacionesDefinitivas + "')";

            String strMaxID = "SELECT MAX(idResultado) as MaxId FROM inhibicionesResultados";

            try
            {
                OdbcCommand myCommand = new OdbcCommand(strSQL, oConnection);
                myCommand.ExecuteNonQuery();

                int MaxID = ObtenerMaxID(strMaxID, oConnection);

                String strAuditoria = "INSERT INTO HistoricoAcciones (idCliente, idUsuario, Instante, Evento, Observaciones, idTipoObjeto, idEstado, idReferencia) VALUES (";
                strAuditoria = strAuditoria + intIdCliente + "," + intIdUsuario + ", getdate(), 'Creación de resultado en Informe de Inhibición', 'Creación de Resultado en Informe de Inhibición', 1" + ", 1," + MaxID.ToString() + ")";

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


        public bool ModificarResultado(int idResult)
        {
            OdbcConnection oConnection = this.OpenConnection();
            String strSQL = "UPDATE inhibicionesResultados SET " +
                "idInforme=" + intIdInforme + " , medida='" + strMedida + "', diario='" + strDiario + "', " +
                "ano='" + strAno + "', fecha='" + strFecha + "', tipoMedida='" + strTipoMedida + "', ordenadopor='" + strOrdenadoPor + "', " +
                "secretaria='" + strSecretaria + "', enautos='" + strEnAutos + "', tipobusqueda='" + strTipoBusqueda + "', " +
                "inmueblesgravados='" + strInmueblesGravados + "', anotacionesdefinitivas='" + strAnotacionesDefinitivas + "' " +
                "WHERE idResultado =  " + idResult.ToString();
            try
            {
                OdbcCommand myCommand = new OdbcCommand(strSQL, oConnection);
                myCommand.ExecuteNonQuery();

                int MaxID = idResult;

                String strAuditoria = "INSERT INTO HistoricoAcciones (idCliente, idUsuario, Instante, Evento, Observaciones, idTipoObjeto, idEstado, idReferencia) VALUES (";
                strAuditoria = strAuditoria + intIdCliente + "," + intIdUsuario + ", getdate(), 'Modificación de Resultado en Informe de Inhibición', 'Modificación de Resultado en Informe de Inhibición', 1" + ", 5," + MaxID.ToString() + ")";

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

        public DataTable TraerResultados(int idInforme)
        {

            OdbcConnection oConnection = this.OpenConnection();
            DataSet ds = new DataSet();
            string strSQL = "SELECT idResultado, medida, diario, ano, fecha, tipoMedida, ordenadopor, " +
                            "secretaria, enautos, tipobusqueda, inmueblesgravados, anotacionesdefinitivas, ROW_NUMBER() OVER (order by idResultado) as row_no " +
                            "FROM inhibicionesResultados " +
                            "WHERE idInforme=" + idInforme.ToString() +
                            " Order By idResultado ";
            OdbcDataAdapter myConsulta = new OdbcDataAdapter(strSQL, oConnection);
            myConsulta.Fill(ds);
            try
            {
                oConnection.Close();
            }
            catch { }

            return ds.Tables[0];

        }


        public bool BorrarResultado(int idResultado)
        {
            OdbcConnection oConnection = this.OpenConnection();
            String strSQL = "Delete from inhibicionesResultados where idResultado = " + idResultado.ToString();

            String strAuditoria = "INSERT INTO HistoricoAcciones (idCliente, idUsuario, Instante, Evento, Observaciones, idTipoObjeto, idReferencia, idEstado) VALUES (";
            strAuditoria = strAuditoria + intIdCliente + "," + intIdUsuario + ", getdate(), 'Eliminación de Resultado en Informe de Inhibición', 'Eliminación de Resultado en Informe de Inhibición" + idResultado.ToString() + "' ,1," + idResultado.ToString() + "," + Estado.ToString() + ")";

            try
            {
                OdbcCommand myCommand = new OdbcCommand(strSQL, oConnection);
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

		#region Métodos Privados
		#endregion


	}
}
