using System;
using System.Data;
using System.Data.Odbc;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;

namespace ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal
{
	/// <summary>
	/// Summary description for Contactenos.
	/// </summary>
	public class ContactenosDal : GenericDal
	{
		#region Atributos y Contructores
		
		private int intIdConsulta;
		private string strNombre;
        private string strEmpresa;
        private string strTelefono;
        private string strMailUsuario;
        private string strServicio;
        private string strFecha;
		private int intLeido;
        private int intIdCliente;
        private int intIdUsuario;
		private string strComentarios;
        private int intIdUsuarioIntra;
		
        private int intTotalRegistros = 0;

        public ContactenosDal()
		{		}
		#endregion

		#region Propiedades
        public int idConsulta
		{
			get
			{
                return intIdConsulta;
			}
			set
			{
                intIdConsulta = value;
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

        public string Empresa
        {
            get
            {
                return strEmpresa;
            }
            set
            {
                strEmpresa = value;
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


        public string MailUsuario
        {
            get
            {
                return strMailUsuario;
            }
            set
            {
                strMailUsuario = value;
            }
        }

        public string Servicio
        {
            get
            {
                return strServicio;
            }
            set
            {
                strServicio = value;
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
		public string Comentarios
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

        public int IdUsuarioIntra
        {
            get
            {
                return intIdUsuarioIntra;
            }
            set
            {
                intIdUsuarioIntra = value;
            }
        }

        public int TotalRegistros
        {
            get
            {
                return intTotalRegistros;
            }
        }
        
		#endregion

		public void Cargar(int idContactenos, int origen)
		{
			string strSQL = "";
			OdbcConnection oConnection = this.OpenConnection();
			DataSet ds = new DataSet();
            if(origen ==1) {
			strSQL = "SELECT idContacto as idConsulta, isnull(u.nombre,'')+' '+ isnull(u.apellido,'') as nombre, " +
                "c.nombrefantasia as empresa, c.telefono, c.email, co.tipocontacto as servicio, co.fechaCarga, co.leido, co.comentarios, co.idUsuarioIntra " +
                "FROM contactenos co " +
                "INNER JOIN clientes c on c.idCliente=co.idCliente " +
                "left outer join usuarios u on co.idUsuario=u.idUsuario " +
                "WHERE co.idContacto=" + idContactenos;
            }
            else {
                strSQL = "SELECT idContacto as idConsulta, nombre, empresa, telefono, email, servicio, fecha as fechaCarga, leido, mensaje as comentarios, idUsuarioIntra " +
                "FROM tiempoygestion_web.dbo.contacto " +
                "WHERE idContacto=" + idContactenos;
            }

			try
			{
				OdbcDataAdapter myConsulta = new OdbcDataAdapter(strSQL, oConnection);
				myConsulta.Fill(ds);
				oConnection.Close();
			} 			
			catch {}

			idConsulta = int.Parse(ds.Tables[0].Rows[0]["idConsulta"].ToString()); 
            strNombre = ds.Tables[0].Rows[0]["nombre"].ToString();
            strEmpresa = ds.Tables[0].Rows[0]["empresa"].ToString();
            strTelefono = ds.Tables[0].Rows[0]["telefono"].ToString();
            strMailUsuario = ds.Tables[0].Rows[0]["email"].ToString();
            strServicio = ds.Tables[0].Rows[0]["servicio"].ToString();
            strFecha = ds.Tables[0].Rows[0]["fechaCarga"].ToString();
			intLeido = int.Parse(ds.Tables[0].Rows[0]["leido"].ToString());
			strComentarios = ds.Tables[0].Rows[0]["comentarios"].ToString();
            if (ds.Tables[0].Rows[0]["idUsuarioIntra"].ToString() != "")
                intIdUsuarioIntra = int.Parse(ds.Tables[0].Rows[0]["idUsuarioIntra"].ToString());
            else
                intIdUsuarioIntra = 0;
		}

		public bool Crear()
		{
			OdbcConnection oConnection = this.OpenConnection();

			String strSQL = "Insert into Contactenos (idCliente, idUsuario, Comentarios, TipoContacto, Mail, FechaCarga ";
            strSQL = strSQL + ") values (" + intIdCliente + ", " + intIdUsuario + ",'" + Comentarios + "','" + Servicio + "','" + MailUsuario;
			strSQL = strSQL  + "', getdate())"; 

			try
			{
				OdbcCommand	myCommand = new OdbcCommand(strSQL, oConnection);
				myCommand.ExecuteNonQuery();

				oConnection.Close();
			} 			
			catch 
			{	
				return false;
			}
			return true;
		}


        public DataTable TraerDatos(string SQLWhere, int pagina, int registros)
        {
            string strSQLCount = "SELECT count (*) as Total " +
                "FROM " +
                "(select idContacto, 1 as origen " +
                "FROM contactenos co " +
                "inner join clientes c on c.idCliente=co.idCliente " +
                "left outer join usuarios u on co.idUsuario=u.idUsuario ";
            if (SQLWhere != "")
                strSQLCount = strSQLCount + "WHERE Comentarios  " + SQLWhere;
            strSQLCount = strSQLCount + "UNION " +
            "select idContacto, 2 as origen " +
            "from tiempoygestion_web.dbo.contacto ";
            if (SQLWhere != "")
                strSQLCount = strSQLCount + "WHERE mensaje  " + SQLWhere;

            strSQLCount = strSQLCount + ") C";
            
            IDataReader dr = EjecutarDataReader(strSQLCount);
            if (dr.Read())
            {
                intTotalRegistros = dr.GetInt32(0);
                int totPaginas = ((int)(intTotalRegistros / registros)) + 1;
                if (pagina > totPaginas) pagina = totPaginas;
            }

            

            OdbcConnection oConnection = this.OpenConnection();
            DataSet ds = new DataSet();
            String strSQL = "select idContacto as idConsulta, 1 as origen, isnull(u.nombre,'')+' '+ isnull(u.apellido,'') as nombre, " +
            "c.nombrefantasia as empresa, c.telefono, c.email, co.tipocontacto as servicio, co.fechaCarga, co.leido " +
            "FROM contactenos co " +
            "INNER JOIN clientes c on c.idCliente=co.idCliente " +
            "LEFT OUTER JOIN usuarios u on co.idUsuario=u.idUsuario ";
            
            if (SQLWhere != "")
                strSQL = strSQL + "WHERE Comentarios  " + SQLWhere;
            
            strSQL = strSQL + "UNION " +
            "SELECT idContacto, 2 as origen, nombre, empresa, telefono, email, servicio, fecha, leido " +
            "FROM tiempoygestion_web.dbo.contacto ";
            
            if (SQLWhere != "")
                strSQL = strSQL + "WHERE mensaje  " + SQLWhere;


            strSQL = strSQL.Replace("'", "''");
            int iniciopag = (pagina - 1) * registros;
            String strSQLSP = "execute_query '" + strSQL + "', 'FechaCarga DESC', " + pagina + ", " + registros + ", 10";

            OdbcDataAdapter myConsulta = new OdbcDataAdapter(strSQLSP, oConnection);
            myConsulta.Fill(ds);
            try
            {
                oConnection.Close();
            }
            catch
            {
                return null;
            }
            return ds.Tables[0];
        }


        public bool UsuarioIntraLeido(int lIdConsulta, int lidTpo, int lIdUsuario)
        {
            string strSQL = "";
            OdbcConnection oConnection = OpenConnection();

            if (lidTpo == 1)
            {
                strSQL = "UPDATE contactenos SET leido = " + Leido.ToString() +
                    ", idUsuarioIntra = " + lIdUsuario.ToString() + 
                    " WHERE idContacto = " + lIdConsulta.ToString();
            }
            else
            {
                strSQL = "UPDATE tiempoygestion_web.dbo.contacto SET leido = " + Leido.ToString() +
                    ", idUsuarioIntra = " + lIdUsuario.ToString() + 
                    " WHERE idContacto = " + lIdConsulta.ToString();
            }
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


        public int TraerDatos()
        {
            int intTotalNoLeidos = 0;
            string strSQLCount = "SELECT count (*) as Total " +
                "FROM " +
                "(select idContacto, 1 as origen " +
                "FROM contactenos co " +
                "inner join clientes c on c.idCliente=co.idCliente " +
                "left outer join usuarios u on co.idUsuario=u.idUsuario " +
                "WHERE co.leido=0";
            strSQLCount = strSQLCount + "UNION " +
            "select idContacto, 2 as origen " +
            "from tiempoygestion_web.dbo.contacto " +
            "WHERE leido=0";

            strSQLCount = strSQLCount + ") C";

            IDataReader dr = EjecutarDataReader(strSQLCount);
            if (dr.Read())
            {
                intTotalNoLeidos = dr.GetInt32(0);
            }
            return intTotalNoLeidos;
        }
    }
}
