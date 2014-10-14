using System;
using System.Data;
using System.Data.Odbc;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;

namespace ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal
{
	/// <summary>
	/// Summary description for Referencias.
	/// </summary>
	public class ReferenciasApp : GenericDal
	{
		private int intIdReferencia;
		private string strDescripcion;
		private string strObservaciones;
		private string strComentarios;
		private string strPath;
		private int intisFile;
		private int intIdUsuario;
		private int intEstado;
		private int intIdCliente;
        private String strUsuarioCliente;

		public ReferenciasApp() : base()
		{		}

		#region Propiedades
		public int IdReferencia
		{
			get
			{
				return intIdReferencia;
			}
			set
			{
				intIdReferencia = value;
			}
		}
		public String Descripcion
		{
			get
			{
				return strDescripcion;
			}
			set
			{
				strDescripcion = value;
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
		public String Path
		{
			get
			{
				return strPath;
			}
			set
			{
				strPath = value;
			}
		}
		public int isFile
		{
			get
			{
				return intisFile;
			}
			set
			{
				intisFile = value;
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
		#endregion

		public void Cargar(int idReferencia)
		{
			
			OdbcConnection oConnection = this.OpenConnection();
			DataSet ds = new DataSet();
			String strSQL = "SELECT R.*, E.*, C.* " +
            "FROM Referencias R " +
            "INNER JOIN EstadoInformes E ON R.Estado = E.idEstado " +
            "INNER JOIN Clientes C ON R.idCliente = C.idCliente  " +
            "WHERE  idReferencia =" + idReferencia.ToString();
			try
			{
				OdbcDataAdapter myConsulta = new OdbcDataAdapter(strSQL, oConnection);
				myConsulta.Fill(ds);
				oConnection.Close();
			} 			
			catch {}

			intIdReferencia = int.Parse(ds.Tables[0].Rows[0]["IdReferencia"].ToString()); 
			strDescripcion = ds.Tables[0].Rows[0]["Descripcion"].ToString();
			strObservaciones = ds.Tables[0].Rows[0]["Observaciones"].ToString();
			strComentarios = ds.Tables[0].Rows[0]["Comentarios"].ToString();
			strPath = ds.Tables[0].Rows[0]["Path"].ToString();
            strUsuarioCliente = ds.Tables[0].Rows[0]["UsuarioCliente"].ToString();
			intisFile = int.Parse(ds.Tables[0].Rows[0]["isFile"].ToString());
			intIdCliente = int.Parse(ds.Tables[0].Rows[0]["idCliente"].ToString());
			if (ds.Tables[0].Rows[0]["IdUsuario"].ToString() != null && ds.Tables[0].Rows[0]["IdUsuario"].ToString() != "")
				intIdUsuario = int.Parse(ds.Tables[0].Rows[0]["idUsuario"].ToString());
			intEstado = int.Parse(ds.Tables[0].Rows[0]["Estado"].ToString());
		
		}

		public bool Borrar(int idReferencia)
		{
        	OdbcConnection oConn = this.OpenConnection();
            DataSet ds = new DataSet();

            String strSQLRef = "SELECT count(*) AS total " +
                "FROM bandejaentrada " +
                "WHERE idReferencia = " + idReferencia;

            OdbcDataAdapter myConsulta = new OdbcDataAdapter(strSQLRef, oConn);
            myConsulta.Fill(ds);
            oConn.Close();

            if (int.Parse(ds.Tables[0].Rows[0]["total"].ToString()) == 0)
            {
                OdbcConnection oConnection = this.OpenConnection();
                String strSQL = "Delete from Referencias where idReferencia = " + idReferencia.ToString();

                String strAuditoria = "INSERT INTO HistoricoAcciones (idCliente, idUsuario, Instante, Evento, Observaciones, idTipoObjeto, idReferencia, idEstado) VALUES (";
                strAuditoria = strAuditoria + intIdCliente + "," + intIdUsuario + ", getdate(), 'Eliminación de Referencia', 'Eliminación de la Referencia Nro." + idReferencia.ToString() + "' ,3," + idReferencia.ToString() + "," + Estado.ToString() + ")";

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
            }
            else
                return false;
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

		public int Crear()
		{
			OdbcConnection oConnection = this.OpenConnection();

			String strSQL = "Insert into Referencias (idCliente, Estado, Descripcion, Observaciones, Path, isFile, FechaCarga, idUsuario, UsuarioCliente ";
			strSQL = strSQL  + ") values (" + intIdCliente + "," + intEstado ;
            strSQL = strSQL + ",'" + Descripcion.Replace("'", "''").ToUpper() + "','" + Observaciones.Replace("'", "''").ToUpper() + "','" + Path + "'," + isFile;
			strSQL = strSQL  + ", getdate(),"+intIdUsuario+",'"+UsuarioCliente+"')"; 

			String strMaxID = "SELECT MAX(idReferencia) as MaxId FROM Referencias";
			int MaxID = 0;
			try
			{
				OdbcCommand	myCommand = new OdbcCommand(strSQL, oConnection);
				myCommand.ExecuteNonQuery();

				MaxID = ObtenerMaxID(strMaxID, oConnection); 

				String strAuditoria = "INSERT INTO HistoricoAcciones (idCliente, idUsuario, Instante, Evento, Observaciones, idTipoObjeto, idEstado, idReferencia) VALUES (";
				strAuditoria = strAuditoria  + intIdCliente + "," + intIdUsuario  + ", getdate(), 'Solicitud de Referencia', 'Solicitud de Referencia', 3, 1," + MaxID.ToString() + ")";

				myCommand = new OdbcCommand(strAuditoria, oConnection);
				myCommand.ExecuteNonQuery();
				oConnection.Close();
			} 			
			catch (Exception e)
			{	
				string p = e.Message;
			}
			return MaxID;
		}

		public bool Modificar(int IdReferencia)
		{
			OdbcConnection oConnection = this.OpenConnection();

			String strSQL = "UPDATE Referencias SET ";
			strSQL = strSQL  + "idCliente = " + IdCliente.ToString() + "," ;
			strSQL = strSQL  + "Estado = " + Estado.ToString() + "," ;
            strSQL = strSQL + "Descripcion  = '" + Descripcion.Replace("'", "''").ToUpper() + "',";
            strSQL = strSQL  + "UsuarioCliente  = '" + UsuarioCliente + "',";
            strSQL = strSQL + "Observaciones = '" + Observaciones.Replace("'", "''").ToUpper() + "'";
			strSQL = strSQL  + " WHERE IdReferencia=" +  IdReferencia.ToString();

			try
			{
				OdbcCommand	myCommand = new OdbcCommand(strSQL, oConnection);
				myCommand.ExecuteNonQuery();

				String strAuditoria = "INSERT INTO HistoricoAcciones (idCliente, idUsuario, Instante, Evento, Observaciones, idTipoObjeto, idEstado, idReferencia) VALUES (";
				strAuditoria = strAuditoria  + intIdCliente + "," + intIdUsuario  + ", getdate(), 'Modificación de Referencia', 'Modificación de la Referencia Nro. " + IdReferencia.ToString() + "', 3, 1," + IdReferencia.ToString() + ")";

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


		public bool Cancelar(int idReferencia)
		{
			OdbcConnection oConnection = this.OpenConnection();
			String strSQL = "UPDATE Referencias SET Estado = 4";
			strSQL = strSQL  + " WHERE idReferencia = " + idReferencia.ToString();

			String strAuditoria = "INSERT INTO HistoricoAcciones (idCliente, idUsuario, Instante, Evento, Observaciones, idTipoObjeto, idReferencia, idEstado) VALUES (";
			strAuditoria = strAuditoria  + intIdCliente + "," + intIdUsuario  + ", getdate(), 'Cancelación de Referencia', 'Cancelación de Referencia del Informe Nro." + idReferencia.ToString() +"' ,3," + idReferencia.ToString() + ",4)";

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

        public bool VerificarInformesReferencia(int idInforme)
        {
            OdbcConnection oConnection = this.OpenConnection();
            String strSQL = "SELECT b.estado, b.idTipoInforme, t.descripcion " +
                "FROM bandejaentrada b " +
                "INNER JOIN tiposinformes t on b.idTipoInforme = t.idTipoInforme " +
                "WHERE b.idReferencia " +
                "IN (select idReferencia from bandejaentrada where idEncabezado = " + idInforme + ") " +
                "AND b.estado = 1 ";

            DataSet ds = new DataSet();
            OdbcDataAdapter myConsulta = new OdbcDataAdapter(strSQL, oConnection);
            myConsulta.Fill(ds);

            bool existe = false;
            if (ds.Tables[0].Rows.Count > 0)
                existe = true;
				//MaxID = int.Parse(ds.Tables[0].Rows[0]["Descripcion"].ToString());

            return existe;
        }


		public bool CambiarEstado(int idRef)
		{
			OdbcConnection oConnection = this.OpenConnection();
			String strSQL = "UPDATE Referencias SET Estado = " + Estado.ToString();
			strSQL = strSQL  + ", Comentarios = '" + Comentarios;
			strSQL = strSQL  + "' WHERE idReferencia = " + idRef.ToString();

			String strAuditoria = "INSERT INTO HistoricoAcciones (idCliente, idUsuario, Instante, Evento, Observaciones, idTipoObjeto, idReferencia, idEstado) VALUES (";
			strAuditoria = strAuditoria  + intIdCliente + "," + intIdUsuario  + ", getdate(), 'Cambio de Estado de Referencia', '" + Comentarios + "' ,3," + idRef.ToString() + "," + Estado.ToString() + ")";
			try
			{
				OdbcCommand	myCommand = new OdbcCommand(strSQL, oConnection);
				myCommand.ExecuteNonQuery();
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



        public DataTable ListarReferencias(int idCliente)
        {

            OdbcConnection oConnection = this.OpenConnection();
            DataSet ds = new DataSet();

            String strSQL = "SELECT r.idReferencia, r.descripcion, r.fechaCarga, u.nombre, u.apellido " + 
            "FROM referencias r " +
            "LEFT OUTER JOIN usuarios u ON r.idUsuario = u.idUsuario " +
            "WHERE r.idCliente=" + idCliente.ToString() +
            " AND r.estado NOT IN (3,4) " +
            "ORDER BY r.fechaCarga DESC";

            try
            {
                OdbcDataAdapter myConsulta = new OdbcDataAdapter(strSQL, oConnection);
                myConsulta.Fill(ds);
                oConnection.Close();
            }

			catch (Exception e)
			{	
				Console.Out.WriteLine(e.Message);				
			}

            return ds.Tables[0];
        }


        #region DataTable CargarDatosReferencias(int filtro)

        public DataTable CargarDatosReferencias(int filtro)
        {
            return ListarReferencias(filtro);

        }

        #endregion

	}
}
