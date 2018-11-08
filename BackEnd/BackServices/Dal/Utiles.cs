using System;
using System.Data;
using System.Data.Odbc;

namespace ar.com.TiempoyGestion.BackEnd.BackServices.Dal
{
	/// <summary>
	/// Summary description for Utiles.
	/// </summary>
	public class UtilesApp: GenericDal
	{
		#region Constructor

		public UtilesApp() 
		{
			//
			// TODO: Add constructor logic here
			//
		}

		#endregion
		
		#region TraerTipoDocumento()

		public DataTable TraerTipoDocumento()
		{
			OdbcConnection oConnection = this.OpenConnection();
			DataSet ds = new DataSet();
			OdbcDataAdapter myConsulta = new OdbcDataAdapter("select * from TipoDocumento", oConnection);
			myConsulta.Fill(ds);
			try
			{
				oConnection.Close();
			} 			
			catch {}

			return ds.Tables[0];
		}

		#endregion

		#region DataTable TraerTipoGravamen()

		public DataTable TraerTipoGravamen()
		{
			OdbcConnection oConnection = this.OpenConnection();
			DataSet ds = new DataSet();
			OdbcDataAdapter myConsulta = new OdbcDataAdapter("select * from TiposGravamenes where activo=1", oConnection);
			myConsulta.Fill(ds);
			try
			{
				oConnection.Close();
			} 			
			catch {}

			return ds.Tables[0];
		}

		#endregion

		#region DataTable TraerEstadoCivil()

		public DataTable TraerEstadoCivil()
		{
			OdbcConnection oConnection = this.OpenConnection();
			DataSet ds = new DataSet();
			OdbcDataAdapter myConsulta = new OdbcDataAdapter("select idEstadoCivil, descripcion from EstadoCivil", oConnection);
			myConsulta.Fill(ds);
			try
			{
				oConnection.Close();
			} 			
			catch {}

			return ds.Tables[0];
		}

		#endregion

		#region DataTable TraerTipoPropiedad()

		public DataTable TraerTipoPropiedad()
		{
			OdbcConnection oConnection = this.OpenConnection();
			DataSet ds = new DataSet();
			OdbcDataAdapter myConsulta = new OdbcDataAdapter("select * from TipoPropiedad", oConnection);
			myConsulta.Fill(ds);
			try
			{
				oConnection.Close();
			} 			
			catch {}

			return ds.Tables[0];
		}

		#endregion
		
		#region DataTable TraerTipoCatastro()

		public DataTable TraerTipoCatastro()
		{
			OdbcConnection oConnection = this.OpenConnection();
			DataSet ds = new DataSet();
			OdbcDataAdapter myConsulta = new OdbcDataAdapter("select * from TipoCatastral", oConnection);
			myConsulta.Fill(ds);
			try
			{
				oConnection.Close();
			} 			
			catch {}

			return ds.Tables[0];
		}

		#endregion
		
		#region DataTable TraerCaracter()

		public DataTable TraerCaracter()
		{
			OdbcConnection oConnection = this.OpenConnection();
			DataSet ds = new DataSet();
			OdbcDataAdapter myConsulta = new OdbcDataAdapter("select * from Caracter", oConnection);
			myConsulta.Fill(ds);
			try
			{
				oConnection.Close();
			} 			
			catch {}

			return ds.Tables[0];
		}

		#endregion

		#region DataTable TraerHistorial(int idEncabezado, int TipoObjeto)

		public DataTable TraerHistorial(int idEncabezado, int TipoObjeto)
		{
			OdbcConnection oConnection = this.OpenConnection();
			DataSet ds = new DataSet();
            String strSQL = "SELECT H.Instante, U.Nombre, U.Apellido, H.idCliente, H.idEstado, H.idUsuario, H.Evento, " +
                "H.Observaciones, H.idReferencia, EI.NombreEstado, EI.NombreEstadoExtra, TObj.Descripcion, C.RazonSocial  " +
                "FROM HistoricoAcciones H " +
                "LEFT OUTER JOIN Usuarios U ON H.idUsuario = U.idUsuario " +
                "INNER JOIN estadoinformes EI ON H.idEstado = EI.idEstado " +
                "INNER JOIN tipoobjetos TObj ON H.idTipoObjeto = TObj.idTipoObjeto " +
                "INNER JOIN Clientes C ON H.idCliente = C.idCliente ";
			strSQL = strSQL + " WHERE H.idReferencia = " + idEncabezado.ToString();
			if (TipoObjeto == 1)
				strSQL = strSQL + " AND H.idTipoObjeto in (1,2)";
			else
				strSQL = strSQL + " AND H.idTipoObjeto = " + TipoObjeto.ToString();
			strSQL = strSQL  + " ORDER BY H.instante";
			
 
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
		
		#region string BuscarLocalidad(int lIdLoc)

		public string BuscarLocalidad(int lIdLoc)
		{
			
			return "Córdoba";
		}
		
		#endregion

		#region string BuscarProvincia(int lIdProv)

		public string BuscarProvincia(int lIdProv)
		{

			return "Córdoba";
		}

		#endregion

		#region DataTable TraerProvincias()
			
		public DataTable TraerProvincias()
		{
			OdbcConnection oConnection = this.OpenConnection();
			DataSet ds = new DataSet();
            OdbcDataAdapter myConsulta = new OdbcDataAdapter("select COD_PROV as id, NOM_PROV as Nombre from provin order by Nombre", oConnection);
			myConsulta.Fill(ds);
			try
			{
				oConnection.Close();
			} 			
			catch {}

			return ds.Tables[0];
		}

		#endregion

		#region DataTable TraerLocalidades(int IdProvincia)

		public DataTable TraerLocalidades(int IdProvincia)
		{
			OdbcConnection oConnection = this.OpenConnection();
			DataSet ds = new DataSet();
            OdbcDataAdapter myConsulta = new OdbcDataAdapter("select COD_LOC as Id, NOM_LOC as Nombre from localida Where COD_PROV=" + IdProvincia + " Order by Nombre", oConnection);
			myConsulta.Fill(ds);
			try
			{
				oConnection.Close();
			} 			
			catch {}

			return ds.Tables[0];
		}

        #endregion



        #region DataTable TraerLocalidadesMensajeria(int IdProvincia)
        public DataTable TraerLocalidadesMensajeria(int IdProvincia)
        {
            OdbcConnection oConnection = this.OpenConnection();
            DataSet ds = new DataSet();
            OdbcDataAdapter myConsulta = new OdbcDataAdapter("select COD_LOC as Id, NOM_LOC as Nombre from localida Where MENSAJERIA=1 AND COD_PROV=" + IdProvincia + " Order by Nombre", oConnection);
            myConsulta.Fill(ds);
            try
            {
                oConnection.Close();
            }
            catch { }

            return ds.Tables[0];
        }

		#endregion

        #region DataTable TraerBarrios(int IdLocalidad, string Criterio)

        public DataTable TraerBarrios(int IdLocalidad, string Criterio)
        {
            OdbcConnection oConnection = this.OpenConnection();
            DataSet ds = new DataSet();
            OdbcDataAdapter myConsulta = new OdbcDataAdapter("select NOM_BAR from Barrios Where COD_LOC=" + IdLocalidad + " and NOM_BAR LIKE '" + Criterio + "%' Order by NOM_BAR", oConnection);
            myConsulta.Fill(ds);
            try
            {
                oConnection.Close();
            }
            catch { }

            return ds.Tables[0];
        }

        #endregion
	}
}
