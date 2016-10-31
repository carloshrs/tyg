using System;
using System.Data;
using System.Data.Odbc;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;

namespace ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal
{
	/// <summary>
	/// Summary description for ClienteDal.
	/// </summary>
	public class BandejaEntradaDal : GenericDal
	{
		#region Atributos y Contructores
        private int intTotalRegistros = 0;

		public BandejaEntradaDal() : base()
		{		}

		#endregion

		#region Propiedades

        public int TotalRegistros
        {
            get
            {
                return intTotalRegistros;
            }
        }
		#endregion

		#region Métodos Publicos

		public DataTable TraerDatos()
		{
			
			OdbcConnection oConnection = this.OpenConnection();
			DataSet ds = new DataSet();
            //ver query
            String strSQL = "SELECT * from v_cantidadTiposInformes";
			OdbcDataAdapter myConsulta = new OdbcDataAdapter(strSQL, oConnection);
			myConsulta.Fill(ds);
			try
			{
				
				oConnection.Close();
			} 			
			catch {}
			
			return ds.Tables[0];

		}

		public DataTable TraerDatosMenu()
		{
			
			OdbcConnection oConnection = this.OpenConnection();
			DataSet ds = new DataSet();
            //ver query
			String strSQL = "select Descripcion, idTipoInforme, Cantidad " +
                "FROM v_traerDatosMenu";
			OdbcDataAdapter myConsulta = new OdbcDataAdapter(strSQL, oConnection);
			myConsulta.Fill(ds);
			try
			{
				oConnection.Close();
			} 			
			catch {}
			
			return ds.Tables[0];

		}


		public DataTable ListaEncabezados(String SQLWhere, int pagina, int registros)
		{
            String strSQLCount = "SELECT COUNT(B.idEncabezado) as Total FROM BandejaEntrada B";
            if (SQLWhere != "")
            {
                SQLWhere = SQLWhere.Replace("''", "'");
                string SQLWhereC = " WHERE " + SQLWhere.Substring(SQLWhere.IndexOf("AND")+3);
                strSQLCount = strSQLCount + SQLWhereC;
            }
            IDataReader dr = EjecutarDataReader(strSQLCount);
            if (dr.Read())
            { 
                intTotalRegistros = dr.GetInt32(0);
                int totPaginas = ((int)(intTotalRegistros / registros)) + 1;
                if (pagina > totPaginas) pagina = totPaginas;
            }
			OdbcConnection oConnection = this.OpenConnection();
			DataSet ds = new DataSet();
            String strSQL = "SELECT B.idEncabezado, B.idTipoInforme, B.idCliente, " +
                "B.DescripcionInf, B.FechaCarga, C.RazonSocial as RazonSocial1, B.Comentarios, " +
                "E.idEstado, E.NombreEstado, E.NombreEstadoExtra, B.GRAVidTipoGravamen, B.leido, T.descripcion, B.estado, " +
                "B.PROPTipo, B.PROPMatricula, B.PROPFolio, B.PROPtomo, B.PROPano, E.DescripcionEstado, B.FechaCondicional, " +
                "B.EstadoCondicional, C.NombreFantasia, C.sucursal " +
                "FROM BandejaEntrada B " +
                "INNER JOIN tiposInformes T ON B.idTipoInforme = T.idTipoInforme " +
                "INNER JOIN EstadoInformes E ON B.Estado = E.idEstado " +
                "INNER JOIN Clientes C ON B.idCliente = C.idCliente ";
			strSQL = strSQL + "WHERE 1=1 ";
			if (SQLWhere != "") strSQL = strSQL + SQLWhere.Replace("'","''");
            int iniciopag = (pagina-1) * registros;
            String strSQLSP = "execute_query '" + strSQL + "', 'FechaCarga DESC', " + pagina + ", " + registros + ", 10";

            OdbcDataAdapter myConsulta = new OdbcDataAdapter(strSQLSP, oConnection);
			myConsulta.Fill(ds);
			try
			{
				
				oConnection.Close();
			} 			
			catch {}
			
			return ds.Tables[0];

		}

		public DataTable GroupTiposInformesEstados()
		{
			
			OdbcConnection oConnection = this.OpenConnection();
			DataSet ds = new DataSet();
			String strSQL = "SELECT TI.descripcion as TipoInforme, EI.Nombreestado as Estado, COUNT(*) AS Cantidad " +
                "FROM bandejaentrada B " +
                "INNER JOIN estadoinformes EI ON B.estado = EI.idestado " +
                "INNER JOIN tiposinformes TI ON B.idtipoinforme = TI.idtipoinforme " +
                "WHERE B.FechaCarga BETWEEN DATEADD(MONTH, -1, getdate()) AND getdate() " +
                "GROUP by TI.descripcion, EI.Nombreestado";

			OdbcDataAdapter myConsulta = new OdbcDataAdapter(strSQL, oConnection);
			myConsulta.Fill(ds);
			try
			{
				
				oConnection.Close();
			} 			
			catch {}
			
			return ds.Tables[0];

		}

		public DataTable GroupEstados()
		{
			
			OdbcConnection oConnection = this.OpenConnection();
			DataSet ds = new DataSet();
			String strSQL = "SELECT EI.idEstado, EI.Nombreestado as Estado, COUNT(*) AS Cantidad ";
            strSQL = strSQL + " FROM bandejaentrada B ";
            strSQL = strSQL + " INNER JOIN estadoinformes EI ON B.estado = EI.idestado ";
            strSQL = strSQL + " WHERE B.FechaCarga > DATEADD(MONTH, -1, getdate()) ";
            strSQL = strSQL + " GROUP by EI.idEstado, EI.Nombreestado";

			OdbcDataAdapter myConsulta = new OdbcDataAdapter(strSQL, oConnection);
			myConsulta.Fill(ds);
			try
			{
				
				oConnection.Close();
			} 			
			catch {}
			
			return ds.Tables[0];

		}

		public DataTable GroupTiposInformesHoy()
		{
			
			OdbcConnection oConnection = this.OpenConnection();
			DataSet ds = new DataSet();
            String strSQL = "select COUNT(*) as Cantidad from bandejaentrada B " +
                "WHERE CONVERT(VarChar(50), b.fechacarga, 103) =  CONVERT(VarChar(50), getdate(), 103) ";

			OdbcDataAdapter myConsulta = new OdbcDataAdapter(strSQL, oConnection);
			myConsulta.Fill(ds);
			try
			{
				
				oConnection.Close();
			} 			
			catch {}
			
			return ds.Tables[0];

		}

		
		public DataTable TraerTiposInformes()
		{
			
			OdbcConnection oConnection = this.OpenConnection();
			DataSet ds = new DataSet();
			String strSQL = "SELECT Descripcion, idTipoInforme FROM tiposInformes ORDER BY Orden";
			OdbcDataAdapter myConsulta = new OdbcDataAdapter(strSQL, oConnection);
			myConsulta.Fill(ds);
			try
			{
				
				oConnection.Close();
			} 			
			catch {}
			
			return ds.Tables[0];

		}

        public DataTable TraerReferencias(string strWhere, int pagina, int registros)
		{
            String strSQLCount = "SELECT COUNT(*) FROM Referencias R";
            if (strWhere != "")
            {
                string SQLWhereC = " WHERE " + strWhere.Substring(strWhere.IndexOf("AND") + 3);
                strSQLCount = strSQLCount + SQLWhereC;
            }

            IDataReader dr = EjecutarDataReader(strSQLCount);
            if (dr.Read())
            {
                intTotalRegistros = dr.GetInt32(0);
                int totPaginas = ((int)(intTotalRegistros / registros)) + 1;
                if (pagina > totPaginas) pagina = totPaginas;
            }

            OdbcConnection oConnection = this.OpenConnection();
			DataSet ds = new DataSet();
            String strSQL = "SELECT R.idReferencia, R.Descripcion, R.Observaciones, R.Estado, " +
                "R.FechaCarga, R.isFile, R.path, C.RazonSocial, E.NombreEstado " +
                "FROM Referencias R " +
                "INNER JOIN EstadoInformes E ON R.Estado = E.idEstado " +
                "INNER JOIN Clientes C ON C.idCliente =  R.idCliente";
            strSQL = strSQL + " WHERE 1=1 ";
            if (strWhere != "") strSQL = strSQL + strWhere.Replace("'", "''");
            int iniciopag = (pagina - 1) * registros;

			try
			{
                String strSQLSP = "execute_query '" + strSQL + "', 'FechaCarga DESC', " + pagina + ", " + registros + ", 10";

                OdbcDataAdapter myConsulta = new OdbcDataAdapter(strSQLSP, oConnection);
				myConsulta.Fill(ds);
				oConnection.Close();
			} 			
			catch { 
				return null;
			}
			return ds.Tables[0];
		}


        public DataTable ListaEncabezadosGrupos(String SQLWhere, int pagina, int registros)
        {
            String strSQLCount = "SELECT COUNT(idEncabezado) AS total FROM BandejaEntrada B" +
            " INNER JOIN informesCambioEstado G ON B.idEncabezado=G.idInforme ";
            if (SQLWhere != "")
            {
                SQLWhere = SQLWhere.Replace("''", "'");
                string SQLWhereC = " WHERE " + SQLWhere.Substring(SQLWhere.IndexOf("AND") + 3);
                strSQLCount = strSQLCount + SQLWhereC;
            }
            IDataReader dr = EjecutarDataReader(strSQLCount);
            if (dr.Read())
            {
                intTotalRegistros = dr.GetInt32(0);
                int totPaginas = ((int)(intTotalRegistros / registros)) + 1;
                if (pagina > totPaginas) pagina = totPaginas;
            }
            OdbcConnection oConnection = this.OpenConnection();
            DataSet ds = new DataSet();
            String strSQL = "SELECT (isnull(b.nombre,'''') + '' '' + isnull(B.apellido,'''')) as nombre, B.documento, B.razonsocial, B.calleempresa + '' '' + B.nroempresa  as direccion, " +
                "B.telefonoempresa as telefono, CASE WHEN (C.sucursal is null) THEN C.nombrefantasia ELSE C.nombrefantasia + '' ('' + C.sucursal + '')'' END AS cliente, + " +
                "B.cuit, B.FechaCarga, B.DescripcionInf, B.comentarios, P.nom_prov AS provincia, L.nom_loc AS localidad, B.UsuarioCliente, B.CargoEmpresa as cargo " +
                "FROM bandejaentrada B " +
                "INNER JOIN clientes C ON B.idCliente=C.idCliente " +
                "INNER JOIN informesCambioEstado G ON B.idEncabezado=G.idInforme " +
                "INNER JOIN provin P ON P.cod_prov=B.provinciaempresa " +
                "INNER JOIN localida L ON L.cod_loc=B.localidadempresa ";

            strSQL = strSQL + "WHERE 1=1 ";
            if (SQLWhere != "") strSQL = strSQL + SQLWhere.Replace("'", "''");
            int iniciopag = (pagina - 1) * registros;
            String strSQLSP = "execute_query '" + strSQL + "', 'FechaCarga ASC', " + pagina + ", " + registros + ", 10";

            OdbcDataAdapter myConsulta = new OdbcDataAdapter(strSQLSP, oConnection);
            myConsulta.Fill(ds);
            try
            {

                oConnection.Close();
            }
            catch { }

            return ds.Tables[0];

        }



        public DataTable ListarHistorialInformesEnviados(int idTipoInforme)
        {

            OdbcConnection oConnection = this.OpenConnection();
            DataSet ds = new DataSet();
            String strSQL = "SELECT TOP 50 GCE.fecha, GCE.id, TI.descripcion,U.nombre, U.apellido, count(GCE.id) AS total " +
                "FROM informesGrupoCambioEstado GCE " +
                "INNER JOIN informesCambioEstado CE ON GCE.id=CE.idTipoGrupo " +
                "INNER JOIN tiposinformes TI ON GCE.idTipoInforme=TI.idTipoInforme " +
                "INNER JOIN Usuarios U ON GCE.idUsuario=U.idUsuario " +
                "GROUP BY GCE.fecha, GCE.id, TI.idTipoInforme, TI.descripcion,U.nombre, U.apellido " +
                "HAVING TI.idTipoInforme= " + idTipoInforme +
                " ORDER BY GCE.fecha DESC";

            OdbcDataAdapter myConsulta = new OdbcDataAdapter(strSQL, oConnection);
            myConsulta.Fill(ds);
            try
            {

                oConnection.Close();
            }
            catch { }

            return ds.Tables[0];

        }


        public DataTable ListaEncabezadosCondicionales(String SQLWhere, int pagina, int registros)
        {
            String strSQLCount = "SELECT COUNT(idEncabezado) AS total FROM BandejaEntrada B";

            if (SQLWhere != "")
            {
                SQLWhere = SQLWhere.Replace("''", "'");
                string SQLWhereC = " WHERE " + SQLWhere.Substring(SQLWhere.IndexOf("AND") + 3);
                strSQLCount = strSQLCount + SQLWhereC;
            }
            IDataReader dr = EjecutarDataReader(strSQLCount);
            if (dr.Read())
            {
                intTotalRegistros = dr.GetInt32(0);
                int totPaginas = ((int)(intTotalRegistros / registros)) + 1;
                if (pagina > totPaginas) pagina = totPaginas;
            }
            OdbcConnection oConnection = this.OpenConnection();
            DataSet ds = new DataSet();
            String strSQL = "SELECT (isnull(b.nombre,'''') + '' '' + isnull(B.apellido,'''')) as nombre, B.documento, B.razonsocial, B.calleempresa + '' '' + B.nroempresa  as direccion, " +
                "B.telefonoempresa as telefono, C.razonsocial AS Cliente, B.cuit, B.FechaCarga, B.DescripcionInf, B.comentarios, P.nom_prov AS provincia, L.nom_loc AS localidad, B.UsuarioCliente, B.FechaCondicional " +
                "FROM bandejaentrada B " +
                "INNER JOIN clientes C ON B.idCliente=C.idCliente " +
                "INNER JOIN provin P ON P.cod_prov=B.provinciaempresa " +
                "INNER JOIN localida L ON L.cod_loc=B.localidadempresa ";

            strSQL = strSQL + "WHERE 1=1 ";
            if (SQLWhere != "") strSQL = strSQL + SQLWhere.Replace("'", "''");
            int iniciopag = (pagina - 1) * registros;
            String strSQLSP = "execute_query '" + strSQL + "', 'FechaCarga DESC', " + pagina + ", " + registros + ", 10";

            OdbcDataAdapter myConsulta = new OdbcDataAdapter(strSQLSP, oConnection);
            myConsulta.Fill(ds);
            try
            {

                oConnection.Close();
            }
            catch { }

            return ds.Tables[0];

        }


        public DataTable ListaEncabezadosTransferidos(String SQLWhere, int pagina, int registros)
        {
            String strSQLCount = "SELECT COUNT(B.idEncabezado) AS total FROM BandejaEntrada B " +
                "INNER JOIN informepropiedadtransferido T ON B.idEncabezado=T.idEncabezado ";

            if (SQLWhere != "")
            {
                SQLWhere = SQLWhere.Replace("''", "'");
                string SQLWhereC = " WHERE " + SQLWhere.Substring(SQLWhere.IndexOf("AND") + 3);
                strSQLCount = strSQLCount + SQLWhereC;
            }
            IDataReader dr = EjecutarDataReader(strSQLCount);
            if (dr.Read())
            {
                intTotalRegistros = dr.GetInt32(0);
                int totPaginas = ((int)(intTotalRegistros / registros)) + 1;
                if (pagina > totPaginas) pagina = totPaginas;
            }
            OdbcConnection oConnection = this.OpenConnection();
            DataSet ds = new DataSet();
            String strSQL = "SELECT B.idEncabezado, (isnull(b.nombre,'''') + '' '' + isnull(B.apellido,'''')) as nombre, B.documento, B.razonsocial, " +
                "B.calleempresa + '' '' + B.nroempresa  as direccion, " +
                "B.PROPTipo, B.PROPMatricula, B.PROPFolio, B.PROPtomo, B.PROPano, E.NombreEstado, E.DescripcionEstado, " +
                "B.telefonoempresa as telefono, B.cuit, B.FechaCarga, B.DescripcionInf, B.comentarios, B.UsuarioCliente, B.FechaCondicional " +
                "FROM bandejaentrada B " +
                "INNER JOIN informepropiedadtransferido T ON B.idEncabezado=T.idEncabezado " +
                "INNER JOIN EstadoInformes E ON B.Estado = E.idEstado ";

            strSQL = strSQL + "WHERE 1=1 ";
            if (SQLWhere != "") strSQL = strSQL + SQLWhere.Replace("'", "''");
            int iniciopag = (pagina - 1) * registros;
            String strSQLSP = "execute_query '" + strSQL + "', 'FechaCarga DESC', " + pagina + ", " + registros + ", 10";

            OdbcDataAdapter myConsulta = new OdbcDataAdapter(strSQLSP, oConnection);
            myConsulta.Fill(ds);
            try
            {

                oConnection.Close();
            }
            catch { }

            return ds.Tables[0];

        }


        public DataTable ListaInformesFinalizados(String SQLWhere, int pagina, int registros)
        {
            String strSQLCount = "SELECT COUNT(B.idEncabezado) as Total FROM BandejaEntrada B";
            if (SQLWhere != "")
            {
                SQLWhere = SQLWhere.Replace("''", "'");
                string SQLWhereC = " WHERE " + SQLWhere.Substring(SQLWhere.IndexOf("AND") + 3);
                strSQLCount = strSQLCount + SQLWhereC;
            }
            /*IDataReader dr = EjecutarDataReader(strSQLCount);
            if (dr.Read())
            {
                intTotalRegistros = dr.GetInt32(0);
                int totPaginas = ((int)(intTotalRegistros / registros)) + 1;
                if (pagina > totPaginas) pagina = totPaginas;
            }
             */

            OdbcConnection oConnection = this.OpenConnection();
            DataSet ds = new DataSet();
            String strSQL = "select b.idencabezado, b.apellido, b.nombre, b.documento, b.sexo, ipd.Fallecido, ipd.FechaFallecido, " +
            "ipd.acta, ipd.tomo, ipd.folio, ipd.lugarfallecimiento, ipd.observaciones, B.FechaCarga " +
            "from bandejaentrada b " +
            "inner join informesCambioEstado ice on b.idEncabezado = ice.idinforme " +
            "left join informepartidadefuncion ipd on b.idEncabezado = ipd.idinforme ";
            strSQL = strSQL + "WHERE 1=1 ";
            if (SQLWhere != "") strSQL = strSQL + SQLWhere.Replace("'", "''");
            int iniciopag = (pagina - 1) * registros;
            string strSQLSP = "execute_query '" + strSQL + "', 'FechaCarga DESC', " + pagina + ", " + registros + ", 10";

            OdbcDataAdapter myConsulta = new OdbcDataAdapter(strSQLSP, oConnection);
            myConsulta.Fill(ds);
            try
            {

                oConnection.Close();
            }
            catch { }

            return ds.Tables[0];

        }

        public DataTable ListarHistorialMasivos()
        {

            OdbcConnection oConnection = this.OpenConnection();
            DataSet ds = new DataSet();
            String strSQL = "SELECT TOP 50 GCE.fecha, GCE.id, " +
                "CAST(CASE " +
                "WHEN GCE.tipoDocumento = 1 " +
                "THEN 'Remito' " +
                "ELSE 'Parte de entrega' " +
                "END AS varchar) as documento, " +
                "U.nombre, U.apellido, count(GCE.id) AS total " +
                "FROM documentosGrupoCambioEstado GCE "+ 
                "INNER JOIN documentosCambioEstado CE ON GCE.id=CE.idTipoGrupo " +
                "INNER JOIN Usuarios U ON GCE.idUsuario=U.idUsuario " +
                "GROUP BY GCE.fecha, GCE.id, GCE.tipoDocumento , U.nombre, U.apellido "+
                 "ORDER BY GCE.fecha DESC";

            OdbcDataAdapter myConsulta = new OdbcDataAdapter(strSQL, oConnection);
            myConsulta.Fill(ds);
            try
            {

                oConnection.Close();
            }
            catch { }

            return ds.Tables[0];

        }

        public DataTable ListarGruposClientesMasivos(int idGrupo)
        {

            OdbcConnection oConnection = this.OpenConnection();
            DataSet ds = new DataSet();
            String strSQL = "";
            
            if(idGrupo ==1)
            strSQL = "select 1 as idTipo, ccr.nroMovimiento, c.idCliente, "+
                "CAST( CASE WHEN c.sucursal = '' THEN c.nombrefantasia  ElSE  c.nombrefantasia + ' (' + c.sucursal +')' END AS varchar (80)) as cliente, count(ccmr.nroRemito) as total "+
                "from clientes c "+
                "inner join CtaCteRemitos ccr on ccr.idCliente=c.IdCliente "+
                "inner join CtaCteMovimientosRemitos ccmr on ccr.nroMovimiento=ccmr.nroMovimiento "+
                "inner join CtaCteResumenCambioEstado ccrce on ccrce.nroMovimiento=ccr.nroMovimiento "+
                "inner join CtaCteResumenGrupoCambioEstado ccrgce on ccrgce.id=ccrce.idTipoGrupo "+
                "where ccrgce.tipoDocumento= " + idGrupo +
                "group by ccr.nroMovimiento, c.idCliente, c.nombrefantasia, c.sucursal " +
                "order by c.nombrefantasia";
            else

            strSQL = "select 2 as idTipo, ccr.nroMovimiento, c.idCliente, "+
                "CAST( CASE WHEN c.sucursal = '' THEN c.nombrefantasia  ElSE  c.nombrefantasia + ' (' + c.sucursal +')' END AS varchar (80)) as cliente, count(ccmr.nroParte) as total "+
                "from clientes c "+
                "inner join CtaCtePartesEntrega ccr on ccr.idCliente=c.IdCliente "+
                "inner join CtaCteMovimientosPartesEntrega ccmr on ccr.nroMovimiento=ccmr.nroMovimiento "+
                "inner join CtaCteResumenCambioEstado ccrce on ccrce.nroMovimiento=ccr.nroMovimiento "+
                "inner join CtaCteResumenGrupoCambioEstado ccrgce on ccrgce.id=ccrce.idTipoGrupo "+
                "where ccrgce.tipoDocumento=" + idGrupo +
                "group by ccr.nroMovimiento, c.idCliente, c.nombrefantasia, c.sucursal "+
                "order by c.nombrefantasia ";


            OdbcDataAdapter myConsulta = new OdbcDataAdapter(strSQL, oConnection);
            myConsulta.Fill(ds);
            try
            {

                oConnection.Close();
            }
            catch { }

            return ds.Tables[0];

        }

        public void generarRecibosMasivos(string fechaDesde, string fechaHasta)
        {
            //int MaxID = 0;
            OdbcConnection oConnection = this.OpenConnection();
            String strSQL1 = "";
            String strSQL2 = "";

            fechaDesde = "'" + fechaDesde + " 00:00:00.000'";

            fechaHasta = "'" + fechaHasta + " 23:59:59.999'";
            

            strSQL1 = "setRemitoMensualMasivo 13, " + fechaDesde + ", " + fechaHasta;

            strSQL2 = "setParteEntregaMensualMasivo 13, " + fechaDesde + ", " + fechaHasta;

            //String strMaxID = "SELECT MAX(nroRemito) as MaxId FROM remitos";

            try
            {
                OdbcCommand myCommand1 = new OdbcCommand(strSQL1, oConnection);
                myCommand1.ExecuteNonQuery();

                OdbcCommand myCommand2 = new OdbcCommand(strSQL2, oConnection);
                myCommand2.ExecuteNonQuery();
                //MaxID = ObtenerMaxID(strMaxID, oConnection);
            }
            catch (Exception e)
            {
                string p = e.Message;
                //return MaxID;
            }
        }


        public DataTable ListaCuentaCorrienteCliente(String SQLWhere, int pagina, int registros)
        {
            String strSQLCount = "SELECT COUNT(CCD.idCuentaClienteDetalle) AS total FROM CPCuentaClienteDetalle CCD INNER JOIN CPCuentaCliente CC ON CCD.idCuentaCliente=CC.idCuentaCliente";
            if (SQLWhere != "")
            {
                SQLWhere = SQLWhere.Replace("''", "'");
                string SQLWhereC = " WHERE " + SQLWhere.Substring(SQLWhere.IndexOf("AND") + 3);
                strSQLCount = strSQLCount + SQLWhereC;
            }
            IDataReader dr = EjecutarDataReader(strSQLCount);
            if (dr.Read())
            {
                intTotalRegistros = dr.GetInt32(0);
                int totPaginas = ((int)(intTotalRegistros / registros)) + 1;
                if (pagina > totPaginas) pagina = totPaginas;
            }
            OdbcConnection oConnection = this.OpenConnection();
            DataSet ds = new DataSet();
            String strSQL = "SELECT CCD.idCuentaClienteDetalle, CCD.idCuentaCliente, CCD.concepto, CCD.monto, CCD.saldo, CCD.entradasalida, CCD.fechaIngreso " +
                "FROM CPCuentaClienteDetalle CCD " +
                "INNER JOIN CPCuentaCliente CC ON CCD.idCuentaCliente=CC.idCuentaCliente ";
            strSQL = strSQL + "WHERE 1=1 ";
            if (SQLWhere != "") strSQL = strSQL + SQLWhere.Replace("'", "''");
            int iniciopag = (pagina - 1) * registros;
            String strSQLSP = "execute_query '" + strSQL + "', 'FechaIngreso ASC', " + pagina + ", " + registros + ", 10";

            OdbcDataAdapter myConsulta = new OdbcDataAdapter(strSQLSP, oConnection);
            myConsulta.Fill(ds);
            try
            {

                oConnection.Close();
            }
            catch { }

            return ds.Tables[0];

        }

		#endregion

		#region Métodos Privados
		#endregion

	}
}
