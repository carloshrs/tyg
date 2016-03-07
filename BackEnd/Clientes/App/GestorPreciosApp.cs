using ar.com.TiempoyGestion.BackEnd.Clientes.Dal;
using System.Data;
using System;

namespace ar.com.TiempoyGestion.BackEnd.Clientes.App
{
	/// <summary>
	/// Summary description for CuentaCorrienteApp.
	/// </summary>
	public class GestorPreciosApp
	{
        public GestorPreciosApp() { }
        /*
		public static bool AsentarMovimiento(int lIdCliente, int lIdEncabezado, int lIdTipoInforme)
		{
			return AsentarMovimiento(lIdCliente, lIdEncabezado, lIdTipoInforme, 3);

		}

		public static bool AsentarMovimiento(int lIdCliente, int lIdEncabezado, int lIdTipoInforme, byte lTipoPrecio)
		{
			float flPrecio = GestorPrecios.TraerPrecioActual(lIdTipoInforme, lTipoPrecio);
			return CuentaCorrienteDal.AsentarMovimiento(lIdCliente, lIdEncabezado, lIdTipoInforme, lTipoPrecio, flPrecio);

		}
        */

        public DataTable listarTiposInformesRemito(int lIdCliente, string lFechaDesde, string lFechaHasta)
        {
            if (lFechaDesde != "")
                lFechaDesde = "'" + lFechaDesde + " 00:00:00.000'";

            if (lFechaHasta != "")
                lFechaHasta = "'" + lFechaHasta + " 23:59:59.999'";

            string FechaActual = DateTime.Today.ToShortDateString();
            FechaActual = "'" + FechaActual + " 00:00:00.000'";

            string strSQL = "WHERE b.FechaCarga BETWEEN " + lFechaDesde + " AND " + lFechaHasta + 
            " AND b.idCliente = " + lIdCliente +
            " AND b.estado=3 " +
            //"AND p.fecDesde < b.FechaFin " +
            //"AND p.actual = 1 " +
            "AND b.idEncabezado NOT IN ( " +
            "SELECT bb.idEncabezado FROM remitoinforme ri " +
            "INNER JOIN bandejaentrada bb ON ri.idEncabezado=bb.idEncabezado " +
            "WHERE bb.idCliente = " + lIdCliente + " ) " +
            "AND b.idEncabezado NOT IN ( " +
            "SELECT bb.idEncabezado FROM parteEntregaInforme pei " +
            "INNER JOIN bandejaentrada bb ON pei.idEncabezado=bb.idEncabezado " +
            "WHERE bb.idCliente = " + lIdCliente + " ) " +
            "GROUP BY b.idTipoInforme, ti.descripcion, p.precio " + //, c.descripcion
            "ORDER BY b.idTipoInforme ASC ";
            DataTable Datos = GestorPrecios.RemitoListarTiposInformes(strSQL);
            return Datos;
        }


        public DataTable listarTiposInformesRemito(int lIdCliente, string lFechaDesde, string lFechaHasta, int lTipoDocumentacion, int lnroRemito)
        {

            string strSQL = " WHERE b.idCliente = " + lIdCliente +
            " AND b.estado=3 ";
            //" AND p.fecDesde < b.fechaFin " +
            //" AND p.actual = 1 ";

            if (lTipoDocumentacion == 1)
            {
                strSQL = strSQL + "AND (b.FechaCarga BETWEEN " + lFechaDesde + " AND " + lFechaHasta +
                " OR b.idEncabezado IN ( " +
                " SELECT idEncabezado FROM remitoinforme " +
                " WHERE nroRemito = " + lnroRemito + " )) ";
            }

            if (lTipoDocumentacion == 2)
            {
                strSQL = strSQL + "AND (b.FechaCarga BETWEEN " + lFechaDesde + " AND " + lFechaHasta +
                " OR b.idEncabezado IN ( " +
                " SELECT idEncabezado FROM parteEntregaInforme " +
                " WHERE nroParte = " + lnroRemito + " )) ";
            }

            strSQL = strSQL + "GROUP BY b.idTipoInforme, ti.descripcion, p.precio " + //, c.descripcion
            "ORDER BY b.idTipoInforme ASC ";

            DataTable Datos = GestorPrecios.RemitoListarTiposInformes(strSQL);
            return Datos;
        }

        public DataTable listarInformesRemitoParteEntrega(int idTipoDocumento, int lTipoInforme, int lIdCliente, string lFechaDesde, string lFechaHasta)
        {
            if (lFechaDesde != "")
                lFechaDesde = "'" + lFechaDesde + " 00:00:00.000'";

            if (lFechaHasta != "")
                lFechaHasta = "'" + lFechaHasta + " 23:59:59.999'";

            string FechaActual = DateTime.Today.ToShortDateString();
            FechaActual = "'" + FechaActual + " 00:00:00.000'";

            string strSQL = "";

            strSQL = "WHERE b.FechaCarga BETWEEN " + lFechaDesde + " AND " + lFechaHasta +
            " AND b.idCliente = " + lIdCliente +
            " AND b.estado=3 " +
            //" AND p.fecDesde < b.fechaFin " +
            " AND p.actual = 1 " +
            " AND b.idTipoInforme = " + lTipoInforme +
            "AND b.idEncabezado NOT IN ( " +
            "SELECT bb.idEncabezado FROM remitoinforme ri " +
            "INNER JOIN bandejaentrada bb ON ri.idEncabezado=bb.idEncabezado " +
            "WHERE bb.idCliente = " + lIdCliente + " ) " +
            "AND b.idEncabezado NOT IN ( " +
            "SELECT bb.idEncabezado FROM parteEntregaInforme ri " +
            "INNER JOIN bandejaentrada bb ON ri.idEncabezado=bb.idEncabezado " +
            "WHERE bb.idCliente = " + lIdCliente + " ) " +
            "ORDER BY b.idTipoInforme ASC ";

            DataTable Datos = GestorPrecios.RemitoParteEntregaListarInformes(idTipoDocumento, lTipoInforme, 0, strSQL);
            return Datos;
        }

        public DataTable listarInformesRemitoParteEntrega(int idTipoDocumento, int lnroRemito, int lTipoInforme)
        {
            string strSQL = "";

            if (idTipoDocumento == 1)
            {
                if (lnroRemito == 0)
                {
                    strSQL = "WHERE p.actual=1 " +
                    "AND b.idEncabezado IN ( " +
                    "SELECT idEncabezado FROM remitoinforme " +
                    "WHERE nroRemito = " + lnroRemito +
                    " AND idTipoInforme = " + lTipoInforme + ") " +
                    "ORDER BY b.idTipoInforme ASC ";
                }
                else
                {
                    strSQL = "WHERE " +
                    "ri.nroRemito= " + lnroRemito +
                    " ORDER BY b.idTipoInforme ASC";
                }
            }

            if (idTipoDocumento == 2)
            {
                if (lnroRemito == 0)
                {
                    strSQL = "WHERE p.actual=1 " +
                    "AND b.idEncabezado IN ( " +
                    "SELECT idEncabezado FROM parteEntregaInforme " +
                    "WHERE nroParte = " + lnroRemito +
                    " AND idTipoInforme = " + lTipoInforme + ") " +
                    "ORDER BY b.idTipoInforme ASC ";
                }
                else
                {
                    strSQL = "WHERE " +
                    "ri.nroparte= " + lnroRemito +
                    " ORDER BY b.idTipoInforme ASC";
                }
            }

            DataTable Datos = GestorPrecios.RemitoParteEntregaListarInformes(idTipoDocumento, lTipoInforme, lnroRemito, strSQL);
            return Datos;
        }

        public int crearRemitoParte(int idTipoDocumentacion, int idtipoCobranza, int idCliente, int idUsuarioIntra)
        {
            GestorPrecios gp = new GestorPrecios();
            int idRemito = gp.CrearRemitoParte(idTipoDocumentacion, idtipoCobranza, idCliente, idUsuarioIntra);
            return idRemito;
        }

        public void modificarRemitoParte(int idTipoDocumentacion, int idtipoCobranza, int nroRemito)
        {
            GestorPrecios gp = new GestorPrecios();
            int idRemito = gp.ModificarRemitoParte(idTipoDocumentacion, idtipoCobranza, nroRemito);
        }

        /*
        public void cargarRemitoParte(int idTipoDocumentacion, int nroRemito)
        {
            GestorPrecios gp = new GestorPrecios();
            gp.cargarRemitoParte(idTipoDocumentacion, nroRemito);
        }
         */

        public bool eliminarInformeRemito(int tipoDocumentacion, int nroRemito, int id)
        {
            bool estado = false;
            GestorPrecios gp = new GestorPrecios();
            estado = gp.eliminarInformeRemito(tipoDocumentacion, nroRemito, id);
            return estado;
        }

        public bool eliminarAdicionalRemito(int tipoDocumentacion, int nroRemito, int id)
        {
            bool estado = false;
            GestorPrecios gp = new GestorPrecios();
            estado = gp.eliminarAdicionalRemito(tipoDocumentacion, nroRemito, id);
            return true;
        }

        public bool eliminarTodosAdicionalesRemitosParteEntrega(int tipoDocumentacion, int nroRemito)
        {
            bool estado = false;
            GestorPrecios gp = new GestorPrecios();
            estado = gp.eliminarTodosAdicionalesRemitosParteEntrega(tipoDocumentacion, nroRemito);
            return true;
        }


        public bool eliminarRemitoMovimiento(int idTipoDocumentacion, int nroMovimiento, int nroRemito)
        {
            bool estado = false;
            GestorPrecios gp = new GestorPrecios();
            estado = gp.eliminarRemitoMovimiento(idTipoDocumentacion, nroMovimiento, nroRemito);
            return estado;
        }

        public void agregarInformesRemitoParte(int idTipoDocumentacion, int idRemito, int idTipoInforme, int idEncabezado, decimal precio)
        {
            GestorPrecios gp = new GestorPrecios();
            gp.agregarInformesRemitoParte(idTipoDocumentacion, idRemito, idTipoInforme, idEncabezado, precio);
            //return idRemito;
        }

        public void agregarAdicionalRemito(int idTipoDocumentacion, int idRemito, int idAdicional, int Cantidad, decimal precio)
        {
            GestorPrecios gp = new GestorPrecios();
            gp.agregarAdicionalRemito(idTipoDocumentacion, idRemito, idAdicional, Cantidad, precio);
            //return idRemito;
        }

        public void modificarInformesRemitoParte(int idTipoDocumentacion, int idRemito, int idTipoInforme, int idEncabezado, decimal precio)
        {
            GestorPrecios gp = new GestorPrecios();
            gp.modificarInformesRemitoParte(idTipoDocumentacion, idRemito, idTipoInforme, idEncabezado, precio);
            //return idRemito;
        }

        public void modificarAdicionalRemito(int idTipoDocumentacion, int idRemito, int idAdicional, int Cantidad, decimal precio)
        {
            GestorPrecios gp = new GestorPrecios();
            gp.agregarAdicionalRemito(idTipoDocumentacion, idRemito, idAdicional, Cantidad, precio);
            //return idRemito;
        }

        public string obtenerAdicional(int idAdicional)
        {
            string strDescr = GestorPrecios.CargarAdicional(idAdicional);
            return strDescr;
        }

        public float obtenerPrecioAdicional(int idAdicional)
        {
            float strDescr = GestorPrecios.CargarPrecioAdicional(idAdicional);
            return strDescr;
        }

        public DataTable ListaRemitosPartesEntrega(int idTipoDocumentacion, int idCliente, string FechaDesde, string FechaHasta, bool sinMovimiento, string NroMovimiento)
        {
            DataTable Datos = GestorPrecios.ListaRemitosPartesEntrega(idTipoDocumentacion, idCliente, FechaDesde, FechaHasta, sinMovimiento, NroMovimiento);
            return Datos;
        }

        public DataTable ListaRemitosPartesEntrega(int tipoDocumento, int nroRemito)
        {
            DataTable Datos = GestorPrecios.ListaRemitosPartesEntrega(tipoDocumento, nroRemito);
            return Datos;
        }

        public DataTable ListaDetallesRemitoParteEntrega(int idTipoDocumentacion, int NroRemito, bool Referencia)
        {
            DataTable Datos = GestorPrecios.ListaDetallesRemitoParteEntrega(idTipoDocumentacion, NroRemito, Referencia);
            return Datos;
        }

        public DataTable ListarAdicionalesRemito(int tipoDocumentacion, int nroRemito)
        {
            DataTable Datos = GestorPrecios.ListarAdicionalesRemito(tipoDocumentacion, nroRemito);
            return Datos;
        }

        public decimal precioTotalRemitoParteEntrega(int idTipoDocumento, int NroRemito)
        {
            decimal Precio = GestorPrecios.precioTotalRemitoParteEntrega(idTipoDocumento, NroRemito);
            return Precio;
        }

        public DataTable ListaMovimientosCliente(int idTipoDocumento, int idCliente, string FechaDesde, string FechaHasta)
        {
            DataTable Datos = GestorPrecios.ListaMovimientosCliente(idTipoDocumento, idCliente, FechaDesde, FechaHasta);
            return Datos;
        }

        public DataTable ListaMovimientosCliente(int idTipoDocumentacion, int nroMovimiento)
        {
            DataTable Datos = GestorPrecios.ListaMovimientosCliente(idTipoDocumentacion, nroMovimiento);
            return Datos;
        }

        public DataTable ListaDetallesRemitosMovimiento(int idTipoDocumento, int NroMovimiento, int idCliente)
        {
            DataTable Datos = GestorPrecios.ListaDetallesRemitosMovimiento(idTipoDocumento, NroMovimiento, idCliente);
            return Datos;
        }

        public decimal precioTotalRemitosMovimiento(int idTipoDocumento, int NroMovimiento, int idCliente)
        {
            decimal Precio = GestorPrecios.precioTotalRemitosMovimiento(idTipoDocumento, NroMovimiento, idCliente);
            return Precio;
        }

        public DataTable NroRemitosPorMovimiento(int idTipoDocumentacion, int nroMovimiento)
        {
            DataTable Datos = GestorPrecios.NroRemitosPorMovimiento(idTipoDocumentacion, nroMovimiento);
            return Datos;
        }


        public string periodoMovimiento(int idTipoDocumentacion, int nroMovimiento)
        {
            string strDescr = GestorPrecios.periodoMovimiento(idTipoDocumentacion, nroMovimiento);
            return strDescr;
        }

        public int crearMovimiento(int idTipoDocumentacion, int idCliente, int idUsuarioIntra)
        {
            GestorPrecios gp = new GestorPrecios();
            int idMovimiento = gp.CrearMovimiento(idTipoDocumentacion, idCliente, idUsuarioIntra);
            return idMovimiento;
        }

        public void agregarRemitoParteEntregaMovimiento(int idTipoDocumentacion, int nroMovimiento, int idRemito)
        {
            GestorPrecios gp = new GestorPrecios();
            gp.agregarRemitoParteEntregaMovimiento(idTipoDocumentacion, nroMovimiento, idRemito);
            //return idRemito;
        }

        //Setea el monto al confeccionar el remito o parte de entrega (AbmRemitos)
        public void setearMontoRemito(int idRemito, int idTipoDocumentacion, int tipoPeriodo)
        {
            GestorPrecios gp = new GestorPrecios();
            gp.setearMontoRemito(idRemito, idTipoDocumentacion, tipoPeriodo);
        }

        public DataTable ListaDocumentosPendientesCobrar(int idCliente, string FechaDesde, string FechaHasta, int Estado)
        {
            DataTable Datos = GestorPrecios.ListaDocumentosPendientesCobrar(idCliente, FechaDesde, FechaHasta, Estado);
            return Datos;
        }

        //Setea el valor del monto al realizar la cobranza si el monto es null
        public void ActualizarMontosDocumentos(int idCliente, string FechaDesde, string FechaHasta)
        {
            GestorPrecios pre = new GestorPrecios();
            pre.ActualizarMontosDocumentos(idCliente, FechaDesde, FechaHasta);
        }
        //public float obtenerTotalRemito
	}
}
