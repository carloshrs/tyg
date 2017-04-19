using System;
using System.Data;
using System.Text;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;
using System.Data.Odbc;
using System.Globalization;
using System.Data.SqlClient;

namespace ar.com.TiempoyGestion.BackEnd.Cobranzas.Dal
{
    /// <summary>
    /// Summary description for GestorPrecios.
    /// </summary>
    public class GestorPrecios : GenericDal
    {
        private int intNroRemito;
        private int intTipoPeriodo;
        private int intIdCaja;
        private string strApertura;
        private string strCierre;
        private float floEfectivoInicial;
        private float floChequeInicial;
        private float floSaldoEfectivo;
        private float floSaldoCheque;
        private int intIdCajaDetalle;
        private string strConcepto;
        private string strFormaPago1;
        private float floMonto1;
        private string strFormaPago2;
        private float floMonto2;
        private string strFormaPago3;
        private float floMonto3;
        private int intEntradasalida;
        private string strFecha;
        private string strObservaciones;
        private int intIdChequeCartera;
        private float floCHMonto;
        private string strCHBanco;
        private string strCHNumero;
        private string strCHFechaCobro;
        private string strCHFechaEmision;

        public GestorPrecios() { }

        #region Propiedades

        public int NroRemito
        {
            get
            {
                return intNroRemito;
            }
            set
            {
                intNroRemito = value;
            }
        }

        public int TipoPeriodo
        {
            get
            {
                return intTipoPeriodo;
            }
            set
            {
                intTipoPeriodo = value;
            }
        }

        public int IdCaja
        {
            get
            {
                return intIdCaja;
            }
            set
            {
                intIdCaja = value;
            }
        }

        public string Apertura
        {
            get
            {
                return strApertura;
            }
            set
            {
                strApertura = value;
            }
        }

        public string Cierre
        {
            get
            {
                return strCierre;
            }
            set
            {
                strCierre = value;
            }
        }

        public float EfectivoInicial
        {
            get
            {
                return floEfectivoInicial;
            }
            set
            {
                floEfectivoInicial = value;
            }
        }

        public float ChequeInicial
        {
            get
            {
                return floChequeInicial;
            }
            set
            {
                floChequeInicial = value;
            }
        }

        public float SaldoEfectivo
        {
            get
            {
                return floSaldoEfectivo;
            }
            set
            {
                floSaldoEfectivo = value;
            }
        }

        public float SaldoCheque
        {
            get
            {
                return floSaldoCheque;
            }
            set
            {
                floSaldoCheque = value;
            }
        }

        public string Concepto
        {
            get
            {
                return strConcepto;
            }
            set
            {
                strConcepto = value;
            }
        }

        public string FormaPago1
        {
            get
            {
                return strFormaPago1;
            }
            set
            {
                strFormaPago1 = value;
            }
        }

        public float Monto1
        {
            get
            {
                return floMonto1;
            }
            set
            {
                floMonto1 = value;
            }
        }

        public string FormaPago2
        {
            get
            {
                return strFormaPago2;
            }
            set
            {
                strFormaPago2 = value;
            }
        }

        public float Monto2
        {
            get
            {
                return floMonto2;
            }
            set
            {
                floMonto2 = value;
            }
        }

        public string FormaPago3
        {
            get
            {
                return strFormaPago3;
            }
            set
            {
                strFormaPago3 = value;
            }
        }

        public float Monto3
        {
            get
            {
                return floMonto3;
            }
            set
            {
                floMonto3 = value;
            }
        }

        public int Entradasalida
        {
            get
            {
                return intEntradasalida;
            }
            set
            {
                intEntradasalida = value;
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

        public int IdChequeCartera
        {
            get
            {
                return intIdChequeCartera;
            }
            set
            {
                intIdChequeCartera = value;
            }
        }

        public float CHMonto
        {
            get
            {
                return floCHMonto;
            }
            set
            {
                floCHMonto = value;
            }
        }

        public string CHBanco
        {
            get
            {
                return strCHBanco;
            }
            set
            {
                strCHBanco = value;
            }
        }

        public string CHNumero
        {
            get
            {
                return strCHNumero;
            }
            set
            {
                strCHNumero = value;
            }
        }

        public string CHFechaCobro
        {
            get
            {
                return strCHFechaCobro;
            }
            set
            {
                strCHFechaCobro = value;
            }
        }

        public string CHFechaEmision
        {
            get
            {
                return strCHFechaEmision;
            }
            set
            {
                strCHFechaEmision = value;
            }
        }

        #endregion

        public static DataTable TraerPrecios(int lIdTipoInforme)
        {
            StringBuilder strQuery = new StringBuilder(512);
            DataTable dtSalida = null;
            strQuery.Append("Select FecDesde, TipoPrecio, Precio, Actual ");
            strQuery.Append(" From Precios ");
            strQuery.Append(" Where IdTipoInforme = " + lIdTipoInforme.ToString());
            strQuery.Append(" Order by FecDesde Desc");

            try
            {

                dtSalida = StaticDal.EjecutarDataSet(strQuery.ToString(), "Precios").Tables[0];
            }
            catch
            {
                throw;
            }

            return dtSalida;
        }

        public static DataTable TraerPreciosPropiedad(int lIdTipoPropiedad)
        {
            StringBuilder strQuery = new StringBuilder(512);
            DataTable dtSalida = null;
            strQuery.Append("Select FecDesde, TipoPrecio, Precio, Actual ");
            strQuery.Append(" From preciosPropiedad ");
            strQuery.Append(" Where IdTipoPropiedad = " + lIdTipoPropiedad.ToString());
            strQuery.Append(" Order by FecDesde Desc");

            try
            {

                dtSalida = StaticDal.EjecutarDataSet(strQuery.ToString(), "PreciosPropiedad").Tables[0];
            }
            catch
            {
                throw;
            }

            return dtSalida;
        }


        public static DataTable TraerPreciosAdicionales()
        {
            StringBuilder strQuery = new StringBuilder(512);
            DataTable dtSalida = null;
            strQuery.Append("Select pa.IdServicioAdicional, pa.FecDesde, sa.id as idServicio, sa.descripcion as servicio, pa.Precio, pa.Actual ");
            strQuery.Append(" From PreciosAdicionales pa INNER JOIN serviciosAdicionales sa ON pa.idServicioAdicional = sa.id ");
            strQuery.Append(" Order by pa.FecDesde Desc");

            try
            {

                dtSalida = StaticDal.EjecutarDataSet(strQuery.ToString(), "PreciosAdicionales").Tables[0];
            }
            catch
            {
                throw;
            }

            return dtSalida;
        }

        public static float TraerPrecioActual(int lIdTipoInforme, byte lTipoPrecio)
        {
            StringBuilder strQuery = new StringBuilder(512);
            IDataReader drPrecio = null;
            float flSalida = 0;
            strQuery.Append("Select Precio ");
            strQuery.Append(" From Precios ");
            strQuery.Append(" Where IdTipoInforme = " + lIdTipoInforme.ToString());
            strQuery.Append(" And TipoPrecio = " + lTipoPrecio.ToString());
            strQuery.Append(" And Actual = 1");

            try
            {
                drPrecio = StaticDal.EjecutarDataReader(strQuery.ToString());
                if (drPrecio.Read())
                {
                    flSalida = drPrecio.GetFloat(0);
                }
            }
            catch
            {
                flSalida = 0;
            }

            return flSalida;

        }

        public static float TraerPrecioActualPropiedad(int lIdTipoPropiedad, byte lTipoPrecio)
        {
            StringBuilder strQuery = new StringBuilder(512);
            IDataReader drPrecio = null;
            float flSalida = 0;
            strQuery.Append("Select Precio ");
            strQuery.Append(" From PreciosPropiedad ");
            strQuery.Append(" Where IdTipoPropiedad = " + lIdTipoPropiedad.ToString());
            strQuery.Append(" And TipoPrecio = " + lTipoPrecio.ToString());
            strQuery.Append(" And Actual = 1");

            try
            {
                drPrecio = StaticDal.EjecutarDataReader(strQuery.ToString());
                if (drPrecio.Read())
                {
                    flSalida = drPrecio.GetFloat(0);
                }
            }
            catch
            {
                flSalida = 0;
            }

            return flSalida;

        }

        public static void AgregarPrecio(float lPrecio, int lIdTipoInforme, byte lTipoPrecio)
        {
            try
            {
                StringBuilder strQuery = new StringBuilder(512);
                strQuery.Append("Update Precios Set Actual = 0 Where ");
                strQuery.Append(" IdTipoInforme = " + StaticDal.Traduce(lIdTipoInforme));
                strQuery.Append(" And TipoPrecio = " + StaticDal.Traduce(lTipoPrecio));
                StaticDal.EjecutarComando(strQuery.ToString());

                strQuery = new StringBuilder(512);
                strQuery.Append("Insert Into Precios (IdTipoInforme, FecDesde, TipoPrecio, Precio) ");
                strQuery.Append(" Values (" + StaticDal.Traduce(lIdTipoInforme));
                strQuery.Append(", getdate() ");
                strQuery.Append(", " + StaticDal.Traduce(lTipoPrecio));
                strQuery.Append(", " + StaticDal.Traduce(lPrecio) + ")");


                StaticDal.EjecutarComando(strQuery.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + Environment.NewLine + e.StackTrace);
            }

        }

        public static void AgregarPrecioPropiedad(float lPrecio, int lIdTipoPropiedad, byte lTipoPrecio)
        {
            try
            {
                StringBuilder strQuery = new StringBuilder(512);
                strQuery.Append("Update PreciosPropiedad Set Actual = 0 Where ");
                strQuery.Append(" IdTipoPropiedad = " + StaticDal.Traduce(lIdTipoPropiedad));
                strQuery.Append(" And TipoPrecio = " + StaticDal.Traduce(lTipoPrecio));
                StaticDal.EjecutarComando(strQuery.ToString());

                strQuery = new StringBuilder(512);
                strQuery.Append("Insert Into PreciosPropiedad (IdTipoPropiedad, FecDesde, TipoPrecio, Precio) ");
                strQuery.Append(" Values (" + StaticDal.Traduce(lIdTipoPropiedad));
                strQuery.Append(", getdate() ");
                strQuery.Append(", " + StaticDal.Traduce(lTipoPrecio));
                strQuery.Append(", " + StaticDal.Traduce(lPrecio) + ")");


                StaticDal.EjecutarComando(strQuery.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + Environment.NewLine + e.StackTrace);
            }

        }


        public static void AgregarPrecioAdicional(float lPrecio, int lTipoAdicional)
        {
            try
            {
                StringBuilder strQuery = new StringBuilder(512);
                strQuery.Append("Update PreciosAdicionales Set Actual = 0 Where ");
                strQuery.Append(" IdServicioAdicional = " + StaticDal.Traduce(lTipoAdicional));
                StaticDal.EjecutarComando(strQuery.ToString());

                strQuery = new StringBuilder(512);
                strQuery.Append("Insert Into PreciosAdicionales (IdServicioAdicional, FecDesde, Precio) ");
                strQuery.Append(" Values (" + StaticDal.Traduce(lTipoAdicional));
                strQuery.Append(", getdate() ");
                strQuery.Append(", " + StaticDal.Traduce(lPrecio) + ")");

                StaticDal.EjecutarComando(strQuery.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + Environment.NewLine + e.StackTrace);
            }

        }

        public static void ModificarPrecio(DateTime lFecha, byte lTipoPrecio, int lIdTipoInforme, float lPrecio)
        {
            StringBuilder strQuery = new StringBuilder(512);
            strQuery.Append("Update Precios ");
            strQuery.Append(" Set Precio = " + StaticDal.Traduce(lPrecio));
            strQuery.Append(" Where IdTipoInforme = " + StaticDal.Traduce(lIdTipoInforme));
            strQuery.Append(" And FecDesde = " + StaticDal.Traduce(lFecha));
            strQuery.Append(" And TipoPrecio = " + StaticDal.Traduce(lTipoPrecio));

            try
            {

                StaticDal.EjecutarComando(strQuery.ToString());
            }
            catch
            {
                throw;
            }

        }

        public static void ModificarPrecioPropiedad(DateTime lFecha, byte lTipoPrecio, int lIdTipoPropiedad, float lPrecio)
        {
            StringBuilder strQuery = new StringBuilder(512);
            strQuery.Append("Update PreciosPropiedad ");
            strQuery.Append(" Set Precio = " + StaticDal.Traduce(lPrecio));
            strQuery.Append(" Where IdTipoPropiedad = " + StaticDal.Traduce(lIdTipoPropiedad));
            strQuery.Append(" And FecDesde = " + StaticDal.Traduce(lFecha));
            strQuery.Append(" And TipoPrecio = " + StaticDal.Traduce(lTipoPrecio));

            try
            {

                StaticDal.EjecutarComando(strQuery.ToString());
            }
            catch
            {
                throw;
            }

        }

        public static void ModificarPrecioAdicional(int lidPrecioAdicional, int lTipoAdicional, float lPrecio)
        {
            StringBuilder strQuery = new StringBuilder(512);
            strQuery.Append("Update PreciosAdicionales ");
            strQuery.Append(" Set Precio = " + StaticDal.Traduce(lPrecio));
            strQuery.Append(" Where IdServicioAdicional = " + StaticDal.Traduce(lidPrecioAdicional));

            try
            {

                StaticDal.EjecutarComando(strQuery.ToString());
            }
            catch
            {
                throw;
            }

        }

        public static DataTable ListarAdicionales(string lTexto)
        {
            StringBuilder strQuery = new StringBuilder(512);
            DataTable dtSalida = null;
            strQuery.Append("Select id, descripcion ");
            strQuery.Append(" From serviciosAdicionales ");
            if (lTexto != "")
                strQuery.Append(" Where id = " + lTexto + " ");

            strQuery.Append(" Order by descripcion");

            try
            {
                dtSalida = StaticDal.EjecutarDataSet(strQuery.ToString(), "Adicionales").Tables[0];
            }
            catch
            {
                throw;
            }
            return dtSalida;

        }


        public static void EliminarAdicional(int lId)
        {
            StringBuilder strSqlUpdate = new StringBuilder(128);
            strSqlUpdate.Append("Delete From serviciosAdicionales ");
            strSqlUpdate.Append(" Where id = " + lId);
            try
            {
                StaticDal.EjecutarComando(strSqlUpdate.ToString());
            }
            catch
            {
                throw;
            }
        }


        public static void CrearCaja(float lEfectivoInicial, float lChequeInicial, int lUsuario)
        {
            try
            {
                StringBuilder strQuery = new StringBuilder(512);
                strQuery = new StringBuilder(512);
                strQuery.Append("Insert Into CPCaja (efectivoInicial, chequeInicial, saldoEfectivo, saldoCheque, apertura, fechaUltimoMovimiento, idUsuario) ");
                strQuery.Append(" Values (" + StaticDal.Traduce(lEfectivoInicial) + ", " + StaticDal.Traduce(lChequeInicial) + ", " + StaticDal.Traduce(lEfectivoInicial) + ", " + StaticDal.Traduce(lChequeInicial) + ", getdate(), getdate(), " + StaticDal.Traduce(lUsuario) + ")");


                StaticDal.EjecutarComando(strQuery.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + Environment.NewLine + e.StackTrace);
            }

        }

        public static void ModificarCaja(int lId, float lEfectivoInicial, float lChequeInicial, float lSaldoEfectivo, float lSaldoCheque, int estado)
        {
            try
            {
                StringBuilder strQuery = new StringBuilder(512);
                strQuery = new StringBuilder(512);
                strQuery.Append("UPDATE CPCaja ");
                strQuery.Append(" SET efectivoInicial=" + StaticDal.Traduce(lEfectivoInicial));
                strQuery.Append(" , chequeInicial=" + StaticDal.Traduce(lChequeInicial));
                if (estado == 1)
                {
                    strQuery.Append(" , saldoEfectivo=" + StaticDal.Traduce(lSaldoEfectivo));
                    strQuery.Append(" , saldoCheque=" + StaticDal.Traduce(lSaldoCheque));
                    strQuery.Append(" , cierre= getdate()");
                }

                strQuery.Append(" WHERE idCaja = " + lId);

                StaticDal.EjecutarComando(strQuery.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + Environment.NewLine + e.StackTrace);
            }

        }


        public void CargarCaja(int idCaja)
        {

            OdbcConnection oConnection = this.OpenConnection();
            DataSet ds = new DataSet();

            String strSQL = "Select idCaja, apertura, cierre, efectivoInicial, chequeInicial, saldoEfectivo, saldoCheque ";
            strSQL = strSQL + " From CPCaja ";
            strSQL = strSQL + " Where idCaja = " + idCaja.ToString();
            OdbcDataAdapter myConsulta = new OdbcDataAdapter(strSQL, oConnection);
            myConsulta.Fill(ds);
            try
            {
                oConnection.Close();
            }
            catch { }

            intIdCaja = int.Parse(ds.Tables[0].Rows[0]["idCaja"].ToString());
            strApertura = ds.Tables[0].Rows[0]["apertura"].ToString();
            strCierre = ds.Tables[0].Rows[0]["cierre"].ToString();
            floEfectivoInicial = float.Parse(ds.Tables[0].Rows[0]["efectivoInicial"].ToString());
            floChequeInicial = float.Parse(ds.Tables[0].Rows[0]["chequeInicial"].ToString());
            floSaldoEfectivo = float.Parse(ds.Tables[0].Rows[0]["saldoEfectivo"].ToString());
            floSaldoCheque = float.Parse(ds.Tables[0].Rows[0]["saldoCheque"].ToString());
        }


        public void CargarChequeCartera(int idChequeCartera)
        {

            OdbcConnection oConnection = this.OpenConnection();
            DataSet ds = new DataSet();

            String strSQL = "Select  idChequeCartera, monto, ch_banco, ch_numero, ch_fechaCobro, ch_fechaEmision ";
            strSQL = strSQL + " From CPChequesCartera ";
            strSQL = strSQL + " Where idChequeCartera = " + idChequeCartera.ToString();
            OdbcDataAdapter myConsulta = new OdbcDataAdapter(strSQL, oConnection);
            myConsulta.Fill(ds);
            try
            {
                oConnection.Close();
            }
            catch { }

            intIdChequeCartera = int.Parse(ds.Tables[0].Rows[0]["idChequeCartera"].ToString());
            floCHMonto = float.Parse(ds.Tables[0].Rows[0]["monto"].ToString());
            strCHBanco = ds.Tables[0].Rows[0]["ch_banco"].ToString();
            strCHNumero = ds.Tables[0].Rows[0]["ch_numero"].ToString();
            strCHFechaCobro = ds.Tables[0].Rows[0]["ch_fechaCobro"].ToString();
            strCHFechaEmision = ds.Tables[0].Rows[0]["ch_fechaEmision"].ToString();
        }


        public void CargarMontosCajaAnterior()
        {

            OdbcConnection oConnection = this.OpenConnection();
            DataSet ds = new DataSet();

            String strSQL = "Select top 1 saldoEfectivo, saldoCheque ";
            strSQL = strSQL + " From CPCaja ";
            strSQL = strSQL + " Order By idCaja Desc ";
            OdbcDataAdapter myConsulta = new OdbcDataAdapter(strSQL, oConnection);
            myConsulta.Fill(ds);
            try
            {
                oConnection.Close();
            }
            catch { }

            floEfectivoInicial = float.Parse(ds.Tables[0].Rows[0]["saldoEfectivo"].ToString());
            floChequeInicial = float.Parse(ds.Tables[0].Rows[0]["saldoCheque"].ToString());
        }


        public static DataTable ListarCajas(string lTexto)
        {
            StringBuilder strQuery = new StringBuilder(512);
            DataTable dtSalida = null;
            strQuery.Append("Select idCaja, apertura, cierre, efectivoInicial, chequeInicial, saldoEfectivo, saldoCheque ");
            strQuery.Append(" From CPCaja ");
            if (lTexto != "")
                strQuery.Append(" Where idCaja = " + lTexto + " ");

            strQuery.Append(" Order by apertura DESC");

            try
            {
                dtSalida = StaticDal.EjecutarDataSet(strQuery.ToString(), "Cajas").Tables[0];
            }
            catch
            {
                throw;
            }
            return dtSalida;

        }


        public static void EliminarCaja(int lId)
        {
            StringBuilder strSqlUpdate = new StringBuilder(128);
            strSqlUpdate.Append(" DELETE FROM CPCaja ");
            strSqlUpdate.Append(" WHERE idCaja=" + lId);
            strSqlUpdate.Append(" AND NOT idCaja IN ( ");
            strSqlUpdate.Append(" SELECT DISTINCT idCaja ");
            strSqlUpdate.Append(" FROM CPCajaDetalle ");
            strSqlUpdate.Append(" Where idCaja=" + lId + ")");
            try
            {
                StaticDal.EjecutarComando(strSqlUpdate.ToString());
            }
            catch
            {
                throw;
            }
        }


        public static DataTable ListarCajasDetalle(string lTexto)
        {
            StringBuilder strQuery = new StringBuilder(512);
            DataTable dtSalida = null;
            strQuery.Append("Select idCajaDetalle, concepto, montoTotal, entradasalida, fecha, observaciones ");
            strQuery.Append(" From CPCajaDetalle ");
            if (lTexto != "")
                strQuery.Append(" Where idCaja = " + lTexto + " ");

            strQuery.Append(" Order by fecha DESC");

            try
            {
                dtSalida = StaticDal.EjecutarDataSet(strQuery.ToString(), "CajaDetalle").Tables[0];
            }
            catch
            {
                throw;
            }
            return dtSalida;

        }

        public static DataTable ListarChequesCartera()
        {
            StringBuilder strQuery = new StringBuilder(512);
            DataTable dtSalida = null;
            strQuery.Append("select idChequeCartera, ch_fechaCobro, monto, ch_banco, ch_numero from CPChequesCartera where idestadocheque=1 order by ch_fechaCobro ASC");

            try
            {
                dtSalida = StaticDal.EjecutarDataSet(strQuery.ToString(), "ChequesCartera").Tables[0];
            }
            catch
            {
                throw;
            }
            return dtSalida;

        }


        public static DataTable ListaPendientesCobrosClientes(int tipoPeriodo, string fechaDesde, string fechaHasta)
        {
            StringBuilder strQuery = new StringBuilder(512);
            DataTable dtSalida = null;

            if (fechaDesde != "")
                fechaDesde = "'" + fechaDesde + " 00:00:00.000'";
            else
            {
                fechaDesde = DateTime.Today.AddMonths(-2).ToShortDateString();
                fechaDesde = "'" + fechaDesde + " 00:00:00.000'";
            }



            if (fechaHasta != "")
                fechaHasta = "'" + fechaHasta + " 23:59:59.999'";
            else
            {
                fechaHasta = DateTime.Today.ToShortDateString();
                fechaHasta = "'" + fechaHasta + " 23:59:59.999'";
            }


            if (tipoPeriodo == 2)
            {
                strQuery.Append("select tipoperiodo, sum(cantidad) as cantidad, IdCliente, cliente, sum(monto) as monto from ( ");
                strQuery.Append("select 1 as idTipo, 2 as tipoperiodo, COUNT(monto) as cantidad, c.idCliente, ");
                strQuery.Append("CAST( CASE WHEN isnull(c.sucursal,'') = '' THEN c.nombrefantasia  ElSE  c.nombrefantasia + ' (' + c.sucursal +')' END AS varchar (80)) as cliente, sum(ccr.monto) as monto  ");
                strQuery.Append("from clientes c  ");
                strQuery.Append("inner join CtaCteRemitos ccr on ccr.idCliente=c.IdCliente  ");
                strQuery.Append("where ccr.estado=1 ");
                strQuery.Append("and ccr.fecha between "+fechaDesde+" and "+fechaHasta+" ");
                strQuery.Append("group by c.idCliente, c.nombrefantasia, c.sucursal ");
                strQuery.Append("UNION ");
                strQuery.Append("select 2 as idTipo, 2 as tipoperiodo, COUNT(monto) as cantidad, c.idCliente,  ");
                strQuery.Append("CAST( CASE WHEN isnull(c.sucursal,'') = '' THEN c.nombrefantasia  ElSE  c.nombrefantasia + ' (' + c.sucursal +')' END AS varchar (80)) as cliente, sum(ccpe.monto) as monto  ");
                strQuery.Append("from clientes c  ");
                strQuery.Append("inner join CtaCtePartesEntrega ccpe on ccpe.idCliente=c.IdCliente  ");
                strQuery.Append("where ccpe.estado=1 ");
                strQuery.Append("and ccpe.fecha between " + fechaDesde + " and " + fechaHasta + " ");
                strQuery.Append("group by c.idCliente, c.nombrefantasia, c.sucursal ");
                strQuery.Append("UNION ");
                strQuery.Append("select c.tipoDocumento, c.tipoPeriodo, 1, c.IdCliente, CAST( CASE WHEN isnull(c.sucursal,'') = '' THEN c.nombrefantasia  ElSE  c.nombrefantasia + ' (' + c.sucursal +')' END AS varchar (80)) as cliente, cpc.saldo ");
                strQuery.Append("from CPCuentaCliente cpc ");
                strQuery.Append("inner join clientes c on cpc.idCliente=c.IdCliente ");
                strQuery.Append("where cpc.saldo < 0 and c.tipoPeriodo=2 ");
                strQuery.Append(") T ");
                strQuery.Append("group by tipoperiodo, IdCliente, cliente ");
                strQuery.Append("order by cliente ");
            }

            if (tipoPeriodo == 1)
            {
                strQuery.Append("select tipoperiodo, sum(cantidad) as cantidad, IdCliente, cliente, sum(monto) as monto from ( ");
                strQuery.Append("select 1 as idTipo, 1 as tipoperiodo, COUNT(monto) as cantidad, c.idCliente,  ");
                strQuery.Append("CAST( CASE WHEN isnull(c.sucursal,'') = '' THEN c.nombrefantasia  ElSE  c.nombrefantasia + ' (' + c.sucursal +')' END AS varchar (80)) as cliente, sum(ccr.monto) as monto ");
                strQuery.Append("from clientes c  ");
                strQuery.Append("inner join remitos ccr on ccr.idCliente=c.IdCliente  ");
                strQuery.Append("where ccr.estado=1 ");
                strQuery.Append("and ccr.periodoCobranza=1 ");
                strQuery.Append("and ccr.fecha between " + fechaDesde + " and " + fechaHasta + " ");
                strQuery.Append("group by c.idCliente, c.nombrefantasia, c.sucursal ");
                strQuery.Append("UNION ");
                strQuery.Append("select 2 as idTipo, 1 as tipoperiodo, COUNT(monto) as cantidad, c.idCliente,  ");
                strQuery.Append("CAST( CASE WHEN isnull(c.sucursal,'') = '' THEN c.nombrefantasia  ElSE  c.nombrefantasia + ' (' + c.sucursal +')' END AS varchar (80)) as cliente, sum(ccpe.monto) as monto ");
                strQuery.Append("from clientes c  ");
                strQuery.Append("inner join PartesEntrega ccpe on ccpe.idCliente=c.IdCliente  ");
                strQuery.Append("where ccpe.estado=1 ");
                strQuery.Append("and ccpe.periodoCobranza=1 ");
                strQuery.Append("and ccpe.fecha between " + fechaDesde + " and " + fechaHasta + " ");
                strQuery.Append("group by c.idCliente, c.nombrefantasia, c.sucursal ");
                strQuery.Append("UNION ");
                strQuery.Append("select c.tipoDocumento, c.tipoPeriodo, 1, c.IdCliente, CAST( CASE WHEN isnull(c.sucursal,'') = '' THEN c.nombrefantasia  ElSE  c.nombrefantasia + ' (' + c.sucursal +')' END AS varchar (80)) as cliente, cpc.saldo ");
                strQuery.Append("from CPCuentaCliente cpc ");
                strQuery.Append("inner join clientes c on cpc.idCliente=c.IdCliente ");
                strQuery.Append("where cpc.saldo < 0 and c.tipoPeriodo=1 ");
                strQuery.Append(") T ");
                strQuery.Append("group by tipoperiodo, IdCliente, cliente ");
                strQuery.Append("order by cliente ");
            }

            try
            {
                dtSalida = StaticDal.EjecutarDataSet(strQuery.ToString(), "PendientesCobrosClientes").Tables[0];
            }
            catch
            {
                throw;
            }
            return dtSalida;

        }


        public static DataTable ListaPendientesCobrosClientesDocumentos(int tipoPeriodo, int idCliente, string fechaDesde, string fechaHasta)
        {
            StringBuilder strQuery = new StringBuilder(512);
            DataTable dtSalida = null;

            if (fechaDesde != "")
                fechaDesde = "'" + fechaDesde + " 00:00:00.000'";
            else
            {
                fechaDesde = DateTime.Today.AddMonths(-2).ToShortDateString();
                fechaDesde = "'" + fechaDesde + " 00:00:00.000'";
            }



            if (fechaHasta != "")
                fechaHasta = "'" + fechaHasta + " 23:59:59.999'";
            else
            {
                fechaHasta = DateTime.Today.ToShortDateString();
                fechaHasta = "'" + fechaHasta + " 23:59:59.999'";
            }


            if (tipoPeriodo == 2)
            {

                strQuery.Append("select tipoperiodo, nroMovimiento, fecha, concepto, monto from ( ");
                strQuery.Append("select  2 as tipoperiodo, ccr.nroMovimiento, ccr.fecha, ('Remito mensual N° ' + CAST(ccr.nroMovimiento AS varchar(80))) as concepto, ccr.monto ");
                strQuery.Append("from CtaCteRemitos ccr  ");
                strQuery.Append("where ccr.estado=1  ");
                strQuery.Append("and ccr.fecha between " + fechaDesde + " and " + fechaHasta + " ");
                strQuery.Append("and ccr.idCliente=" + idCliente);
                strQuery.Append(" UNION  ");
                strQuery.Append("select  2 as tipoperiodo, ccpe.nroMovimiento, ccpe.fecha, ('Parte de entrega mensual N° ' + CAST(ccpe.nroMovimiento AS varchar(80))) as concepto, ccpe.monto ");
                strQuery.Append("from CtaCtePartesEntrega ccpe  ");
                strQuery.Append("where ccpe.estado=1  ");
                strQuery.Append("and ccpe.fecha between " + fechaDesde + " and " + fechaHasta + " ");
                strQuery.Append("and ccpe.idCliente=" + idCliente);
                strQuery.Append(" UNION  ");
                strQuery.Append(" select c.tipoPeriodo, 0, getdate(), 'SALDO PENDIENTE', (cpc.saldo * -1) as saldo ");
                strQuery.Append(" from CPCuentaCliente cpc ");
                strQuery.Append(" inner join clientes c on cpc.idCliente=c.IdCliente ");
                strQuery.Append(" where c.idCliente=" + idCliente + " and cpc.saldo < 0 and c.tipoPeriodo=2 ");
                strQuery.Append(" ) T ");
                strQuery.Append("order by fecha ");
            }

            if (tipoPeriodo == 1)
            {

                strQuery.Append("select tipoperiodo, nroMovimiento, fecha, concepto, monto from ( ");
                strQuery.Append("select  1 as tipoperiodo, r.nroRemito as nroMovimiento, r.fecha, ('Remito diario N° ' + CAST(r.nroRemito AS varchar(80))) as concepto, r.monto ");
                strQuery.Append("from Remitos r  ");
                strQuery.Append("where r.estado=1 and periodoCobranza=1 ");
                strQuery.Append("and r.fecha between " + fechaDesde + " and " + fechaHasta + " ");
                strQuery.Append("and r.idCliente=" + idCliente);
                strQuery.Append(" UNION  ");
                strQuery.Append("select  1 as tipoperiodo, pe.nroParte as nroMovimiento, pe.fecha, ('Parte de entrega diario N° ' + CAST(pe.nroParte AS varchar(80))) as concepto, pe.monto ");
                strQuery.Append("from PartesEntrega pe  ");
                strQuery.Append("where pe.estado=1  and periodoCobranza=1 ");
                strQuery.Append("and pe.fecha between " + fechaDesde + " and " + fechaHasta + " ");
                strQuery.Append("and pe.idCliente=" + idCliente);
                strQuery.Append(" UNION  ");
                strQuery.Append(" select c.tipoPeriodo, 0, getdate(), 'SALDO PENDIENTE', (cpc.saldo * -1) as saldo ");
                strQuery.Append(" from CPCuentaCliente cpc ");
                strQuery.Append(" inner join clientes c on cpc.idCliente=c.IdCliente ");
                strQuery.Append(" where c.idCliente=" + idCliente + " and cpc.saldo < 0 and c.tipoPeriodo=2 ");
                strQuery.Append(" ) T ");
                strQuery.Append("order by fecha ");
            }

            try
            {
                dtSalida = StaticDal.EjecutarDataSet(strQuery.ToString(), "PendientesCobrosClientes").Tables[0];
            }
            catch
            {
                throw;
            }
            return dtSalida;

        }

        public void CargarCajaDetalle(int idCajaDetalle)
        {

            OdbcConnection oConnection = this.OpenConnection();
            DataSet ds = new DataSet();

            String strSQL = "Select  CPCD.idCajaDetalle, CPCD.idCaja, CPCD.concepto, CPCD.entradasalida, CPCD.fecha, CPCD.observaciones, isnull(CPCDFP1.monto, 0) AS monto1, CPFP1.descripcion AS FormaPago1, isnull(CPCDFP2.monto, 0) AS monto2, CPFP2.descripcion AS FormaPago2, isnull(CPCDFP3.monto, 0) AS monto3, CPFP3.descripcion AS FormaPago3 " +
                " From CPCajaDetalle CPCD " +
                " LEFT OUTER JOIN CPCajaDetalleFormaPago CPCDFP1 ON CPCD.idCajaDetalle = CPCDFP1.idCajaDetalle and CPCDFP1.idFormaPago=1 " +
                " LEFT OUTER JOIN CPFormasPago CPFP1 ON CPCDFP1.idFormaPago= CPFP1.idFormaPago  " +
                " LEFT OUTER JOIN CPCajaDetalleFormaPago CPCDFP2 ON CPCD.idCajaDetalle = CPCDFP2.idCajaDetalle and CPCDFP2.idFormaPago=2 " +
                " LEFT OUTER JOIN CPFormasPago CPFP2 ON CPCDFP2.idFormaPago= CPFP2.idFormaPago  " +
                " LEFT OUTER JOIN CPCajaDetalleFormaPago CPCDFP3 ON CPCD.idCajaDetalle = CPCDFP3.idCajaDetalle and CPCDFP3.idFormaPago=3 " +
                " LEFT OUTER JOIN CPFormasPago CPFP3 ON CPCDFP3.idFormaPago= CPFP3.idFormaPago " +
                " Where CPCD.idCajaDetalle = " + idCajaDetalle.ToString();
            OdbcDataAdapter myConsulta = new OdbcDataAdapter(strSQL, oConnection);
            myConsulta.Fill(ds);
            try
            {
                oConnection.Close();
            }
            catch { }

            intIdCajaDetalle = int.Parse(ds.Tables[0].Rows[0]["idCajaDetalle"].ToString());
            intIdCaja = int.Parse(ds.Tables[0].Rows[0]["idCaja"].ToString());
            strConcepto = ds.Tables[0].Rows[0]["concepto"].ToString();
            strFormaPago1 = ds.Tables[0].Rows[0]["FormaPago1"].ToString();
            floMonto1 = float.Parse(ds.Tables[0].Rows[0]["monto1"].ToString());
            strFormaPago2 = ds.Tables[0].Rows[0]["FormaPago2"].ToString();
            floMonto2 = float.Parse(ds.Tables[0].Rows[0]["monto2"].ToString());
            strFormaPago3 = ds.Tables[0].Rows[0]["FormaPago3"].ToString();
            floMonto3 = float.Parse(ds.Tables[0].Rows[0]["monto3"].ToString());
            intEntradasalida = int.Parse(ds.Tables[0].Rows[0]["entradasalida"].ToString());
            strFecha = ds.Tables[0].Rows[0]["fecha"].ToString();
            strObservaciones = ds.Tables[0].Rows[0]["observaciones"].ToString();
        }

        public static DataTable ListarConceptos(string lTexto, int idTipo, int ES)
        {
            StringBuilder strQuery = new StringBuilder(512);
            DataTable dtSalida = null;
            strQuery.Append("Select idConcepto, descripcion ");
            strQuery.Append(" From CPConcepto ");
            strQuery.Append(" WHERE idTipo=" + idTipo);
            strQuery.Append(" AND entrada=" + ES);
            strQuery.Append(" AND estado=1");
            if (lTexto != "")
                strQuery.Append(" AND id = " + lTexto + " ");
            strQuery.Append(" Order by descripcion");

            try
            {
                dtSalida = StaticDal.EjecutarDataSet(strQuery.ToString(), "Conceptos").Tables[0];
            }
            catch
            {
                throw;
            }
            return dtSalida;

        }

        public static DataTable ListarEstadosCheques(string lTexto)
        {
            StringBuilder strQuery = new StringBuilder(512);
            DataTable dtSalida = null;
            strQuery.Append("Select idEstadoCheque, descripcion ");
            strQuery.Append("From CPEstadosCheque ");
            strQuery.Append("WHERE idEstadoCheque<>1 ");
            strQuery.Append("AND activo=1");
           

            try
            {
                dtSalida = StaticDal.EjecutarDataSet(strQuery.ToString(), "EstadosCheques").Tables[0];
            }
            catch
            {
                throw;
            }
            return dtSalida;

        }

        public static void CrearCajaDetalle(int IdCaja, int TipoIngreso, string concepto, float monto, string observaciones)
        {
            try
            {
                StringBuilder strQuery = new StringBuilder(512);
                strQuery = new StringBuilder(512);
                strQuery.Append("Insert Into CPCajaDetalle (idCaja, concepto, montoTotal, entradasalida, fecha, observaciones) ");
                strQuery.Append(" Values (" + StaticDal.Traduce(IdCaja) + ", " + StaticDal.Traduce(concepto) + ", " + StaticDal.Traduce(monto) + ", " + StaticDal.Traduce(TipoIngreso) + ", getdate(), " + StaticDal.Traduce(observaciones) + ")");
                StaticDal.EjecutarComando(strQuery.ToString());

                StringBuilder strQuery2 = new StringBuilder(512);
                strQuery2 = new StringBuilder(512);
                if (TipoIngreso == 1)
                    strQuery2.Append("UPDATE CPCaja SET saldoEfectivo = saldoEfectivo + " + StaticDal.Traduce(monto) + " ");
                else
                    strQuery2.Append("UPDATE CPCaja SET saldoEfectivo = saldoEfectivo - " + StaticDal.Traduce(monto) + " ");
                strQuery2.Append(" WHERE idCaja = " + StaticDal.Traduce(IdCaja));
                StaticDal.EjecutarComando(strQuery2.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + Environment.NewLine + e.StackTrace);
            }

        }

        public static void CambiarEstadoCheque(int IdChequeCartera, float Monto, int Estado)
        {
            try
            {
                // Se selecciona ultima caja abierta para actualizar saldo
                StringBuilder strQuery1 = new StringBuilder(512);
                DataTable dtSalida = null;
                strQuery1.Append("Select top 1 idCaja FROM CPCaja ");
                strQuery1.Append("WHERE cierre is null");


                try
                {
                    dtSalida = StaticDal.EjecutarDataSet(strQuery1.ToString(), "idCaja").Tables[0];
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + Environment.NewLine + e.StackTrace);
                }

                if (dtSalida.Rows.Count != 0)
                {
                    StringBuilder strQuery = new StringBuilder(512);
                    strQuery = new StringBuilder(512);
                    strQuery.Append("UPDATE CPChequesCartera ");
                    strQuery.Append(" SET idEstadoCheque = " + StaticDal.Traduce(Estado) + "");
                    strQuery.Append(" WHERE idChequeCartera = " + StaticDal.Traduce(IdChequeCartera) + "");
                    StaticDal.EjecutarComando(strQuery.ToString());

                    if (Estado == 2 || Estado == 4)
                    {

                        StringBuilder strQuery2 = new StringBuilder(512);
                        strQuery2 = new StringBuilder(512);
                        strQuery2.Append("UPDATE CPCaja SET saldoEfectivo = saldoEfectivo + " + StaticDal.Traduce(Monto) + ", saldoCheque = saldoCheque - " + StaticDal.Traduce(Monto) + " ");
                        strQuery2.Append(" WHERE idCaja = " + StaticDal.Traduce(dtSalida.Rows[0]["idCaja"].ToString()));
                        StaticDal.EjecutarComando(strQuery2.ToString());


                        StringBuilder strQuery3  = new StringBuilder(512);
                        strQuery3 = new StringBuilder(512);
                        strQuery3.Append("INSERT CPCajaDetalle (idCaja, Concepto, montoTotal, entradasalida, fecha) VALUES ");
                        strQuery3.Append("(" + StaticDal.Traduce(dtSalida.Rows[0]["idCaja"].ToString()) + ", 'INGRESO DE CHEQUE EN CARTERA', " + StaticDal.Traduce(Monto) + ", 1, getdate())");
                        StaticDal.EjecutarComando(strQuery3.ToString());
                        
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + Environment.NewLine + e.StackTrace);
            }

        }

        public static void CrearCuentaClienteDetalle(int IdCuentaCliente, int TipoIngreso, string concepto, int FormaPago, float monto)
        {
            try
            {

                StringBuilder strQuerySel = new StringBuilder(512);
                IDataReader drSaldo = null;
                DataTable dtSaldo = null;
                double saldo = 0;
                strQuerySel.Append("select top 1 saldo from CPCuentaClienteDetalle ");
                strQuerySel.Append(" where idCuentaCliente=" + IdCuentaCliente);
                strQuerySel.Append(" order by idCuentaClienteDetalle DESC");

                drSaldo = StaticDal.EjecutarDataReader(strQuerySel.ToString());
                if (drSaldo.Read())
                {
                    saldo = drSaldo.GetFloat(0);
                }

                if (TipoIngreso == 1)
                    saldo = saldo + monto;
                else
                    saldo = saldo - monto;



                StringBuilder strQuery = new StringBuilder(512);
                strQuery = new StringBuilder(512);
                strQuery.Append("Insert Into CPCuentaClienteDetalle (idCuentaCliente, concepto, monto, saldo, entradasalida, fechaIngreso, fecha) ");
                strQuery.Append(" Values (" + StaticDal.Traduce(IdCuentaCliente) + ", " + StaticDal.Traduce(concepto) + ", " + StaticDal.Traduce(monto) + ", " + StaticDal.Traduce(saldo) + ", " + StaticDal.Traduce(TipoIngreso) + ", getdate(), getdate())");
                StaticDal.EjecutarComando(strQuery.ToString());


                StringBuilder strQuery2 = new StringBuilder(512);
                strQuery2 = new StringBuilder(512);
                strQuery2.Append("UPDATE CPCuentaCliente ");
                strQuery2.Append("SET saldo = " + StaticDal.Traduce(saldo) + ", fechaUltimoMovimiento=getdate() ");
                strQuery2.Append("WHERE idCuentaCliente=" + StaticDal.Traduce(IdCuentaCliente));
                StaticDal.EjecutarComando(strQuery2.ToString());

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + Environment.NewLine + e.StackTrace);
            }

        }

        public static void EliminarClienteCC(int lIdCliente)
        {
            StringBuilder strSqlUpdate = new StringBuilder(128);
            strSqlUpdate.Append("DELETE FROM cuentascorrientes ");
            strSqlUpdate.Append(" WHERE idCliente=" + lIdCliente);
            strSqlUpdate.Append(" AND NOT idCliente IN ( ");
            strSqlUpdate.Append(" SELECT DISTINCT idCliente ");
            strSqlUpdate.Append(" FROM CtaCteMovimientos ");
            strSqlUpdate.Append(" Where idCliente=" + lIdCliente + ")");
            try
            {
                StaticDal.EjecutarComando(strSqlUpdate.ToString());
            }
            catch
            {
                throw;
            }
        }


        public static void CrearAdicional(string lDescripcion)
        {
            try
            {
                StringBuilder strQuery = new StringBuilder(512);
                strQuery = new StringBuilder(512);
                strQuery.Append("Insert Into serviciosAdicionales (descripcion) ");
                strQuery.Append(" Values (" + StaticDal.Traduce(lDescripcion) + ")");


                StaticDal.EjecutarComando(strQuery.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + Environment.NewLine + e.StackTrace);
            }

        }

        public static void ModificarAdicional(int lId, string lDescripcion)
        {
            try
            {
                StringBuilder strQuery = new StringBuilder(512);
                strQuery = new StringBuilder(512);
                strQuery.Append("UPDATE serviciosAdicionales ");
                strQuery.Append(" SET descripcion=" + StaticDal.Traduce(lDescripcion));
                strQuery.Append(" WHERE id = " + lId);

                StaticDal.EjecutarComando(strQuery.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + Environment.NewLine + e.StackTrace);
            }

        }


        public static string CargarAdicional(int lId)
        {
            StringBuilder strQuery = new StringBuilder(512);
            IDataReader drDescripcion = null;
            string flSalida = "";
            strQuery.Append("Select descripcion ");
            strQuery.Append(" From serviciosAdicionales ");
            strQuery.Append(" Where id = " + lId);

            try
            {
                drDescripcion = StaticDal.EjecutarDataReader(strQuery.ToString());
                if (drDescripcion.Read())
                {
                    flSalida = drDescripcion.GetString(0);
                }
            }
            catch
            {
                flSalida = "";
            }

            return flSalida;

        }


        public static float CargarPrecioAdicional(int lId)
        {
            StringBuilder strQuery = new StringBuilder(512);
            IDataReader drDescripcion = null;
            float flSalida = 0;
            strQuery.Append("Select Precio ");
            strQuery.Append(" From preciosAdicionales ");
            strQuery.Append(" Where idServicioAdicional = " + lId);
            strQuery.Append(" AND Actual = 1 ");

            try
            {
                drDescripcion = StaticDal.EjecutarDataReader(strQuery.ToString());
                if (drDescripcion.Read())
                {
                    flSalida = drDescripcion.GetFloat(0);
                }
            }
            catch
            {
                flSalida = 0;
            }

            return flSalida;

        }


        public static DataTable RemitoListarTiposInformes(string strSQL)
        {

            StringBuilder strQuery = new StringBuilder(512);
            DataTable dtSalida = null;
            strQuery.Append("SELECT count(b.idTipoInforme) as cantidad, b.idTipoInforme,  ");
            strQuery.Append("ti.descripcion as tipoinforme, (count(b.idTipoInforme) * p.precio) as precioTotal "); //c.descripcion as caracter, 
            strQuery.Append("Into #Temp ");
            strQuery.Append("FROM bandejaentrada b ");
            strQuery.Append("INNER JOIN tiposinformes ti ON b.idTipoInforme=ti.idTipoInforme ");
            strQuery.Append("LEFT OUTER JOIN precios p ON ti.idTipoInforme=p.idTipoInforme AND p.tipoprecio=b.caracter AND p.actual = 1 ");
            //strQuery.Append("INNER JOIN caracter c ON b.caracter = c.idCaracter ");
            strQuery.Append(strSQL);
            //strQuery.Append("GO ");
            strQuery.Append("SELECT sum(cantidad) as Cantidad, idTipoInforme, tipoinforme, sum(precioTotal) as PrecioTotal ");
            strQuery.Append("FROM #Temp ");
            strQuery.Append("GROUP BY idTipoInforme, tipoinforme ");
            strQuery.Append("ORDER BY idTipoInforme ");
            strQuery.Append("DROP table #temp ");
            //strQuery.Append("GO");

            /*
            strQuery.Append("WHERE b.FechaCarga BETWEEN " + FechaDesde + " AND " + FechaHasta + " ");
            strQuery.Append("AND b.idCliente = " + lCliente + " ");
            strQuery.Append("AND b.estado=3 ");
            strQuery.Append("AND p.fecDesde < b.fechaCarga ");
            strQuery.Append("AND p.actual = 1 ");
            strQuery.Append("AND b.idEncabezado NOT IN ( ");
            strQuery.Append("SELECT bb.idEncabezado FROM remitoinforme ri ");
            strQuery.Append("INNER JOIN bandejaentrada bb ON ri.idEncabezado=bb.idEncabezado ");
            strQuery.Append("WHERE bb.idCliente = " + lCliente + " ) ");
            strQuery.Append("GROUP BY b.idTipoInforme, ti.descripcion, p.precio, c.descripcion ");
            strQuery.Append("ORDER BY b.idTipoInforme ASC ");
             */

            try
            {
                dtSalida = StaticDal.EjecutarDataSet(strQuery.ToString(), "RemitoTiposInformes").Tables[0];
            }
            catch
            {
                throw;
            }
            return dtSalida;

        }



        public static DataTable RemitoParteEntregaListarInformes(int idTipoDocumento, int TipoInforme, int nroRemito, string strSQL)
        {


            StringBuilder strQuery = new StringBuilder(512);
            DataTable dtSalida = null;

            if (nroRemito == 0)
            {
                strQuery.Append("SELECT b.idEncabezado, b.fechaCarga, (b.descripcioninf + ', REF: '+  r.Descripcion) as descripcioninf, p.precio ");
                strQuery.Append("FROM bandejaentrada b ");
                strQuery.Append("INNER JOIN referencias r on b.idReferencia=r.idReferencia ");
                strQuery.Append("INNER JOIN tiposinformes ti on b.idTipoInforme=ti.idTipoInforme ");
                if (TipoInforme == 1) //Informes de propiedad
                {
                    strQuery.Append("INNER JOIN tipoPropiedad tp on b.PROPTipo=tp.idTipoPropiedad ");
                    strQuery.Append("INNER JOIN preciosPropiedad p on ti.idTipoInforme=1 AND p.idTipoPropiedad=b.PROPTipo AND p.tipoprecio=b.caracter ");
                }
                else
                    strQuery.Append("INNER JOIN precios p on ti.idTipoInforme=p.idTipoInforme AND p.tipoprecio=b.caracter ");
            }
            else
            {
                if (idTipoDocumento == 1)
                {
                    strQuery.Append("SELECT b.idEncabezado, b.fechaCarga, b.descripcioninf, ri.precio ");
                    strQuery.Append("FROM bandejaentrada b ");
                    strQuery.Append("INNER JOIN remitoinforme ri on b.idEncabezado=ri.idEncabezado ");
                }
                if (idTipoDocumento == 2)
                {
                    strQuery.Append("SELECT b.idEncabezado, b.fechaCarga, b.descripcioninf, ri.precio ");
                    strQuery.Append("FROM bandejaentrada b ");
                    strQuery.Append("INNER JOIN parteEntregaInforme ri on b.idEncabezado=ri.idEncabezado ");
                }

            }


            strQuery.Append(strSQL);

            try
            {
                dtSalida = StaticDal.EjecutarDataSet(strQuery.ToString(), "RemitoTiposInformes").Tables[0];
            }
            catch
            {
                throw;
            }
            return dtSalida;

        }

        public int CrearRemitoParte(int idTipoDocumentacion, int idtipoCobranza, int idCliente, int idUsuarioIntra)
        {
            int MaxID = 0;
            string strSQL = "";
            string strMaxID = "";

            OdbcConnection oConnection = this.OpenConnection();
            if (idTipoDocumentacion == 1)
            {
                strSQL = "Insert into remitos (idCliente, idUsuarioIntra, periodoCobranza, fecha) ";
                strSQL = strSQL + " values (" + idCliente + ", " + idUsuarioIntra + ", " + idtipoCobranza + ", getdate())";

                strMaxID = "SELECT MAX(nroRemito) as MaxId FROM remitos";
            }
            if (idTipoDocumentacion == 2)
            {
                strSQL = "Insert into partesEntrega (idCliente, idUsuarioIntra, periodoCobranza, fecha) ";
                strSQL = strSQL + " values (" + idCliente + ", " + idUsuarioIntra + ", " + idtipoCobranza + ", getdate())";

                strMaxID = "SELECT MAX(nroParte) as MaxId FROM partesEntrega";
            }

            try
            {
                OdbcCommand myCommand = new OdbcCommand(strSQL, oConnection);
                myCommand.ExecuteNonQuery();

                MaxID = ObtenerMaxID(strMaxID, oConnection);
            }
            catch (Exception e)
            {
                string p = e.Message;
                return MaxID;
            }

            return MaxID;
        }


        public int ModificarRemitoParte(int idTipoDocumentacion, int idtipoCobranza, int nroRemito)
        {
            int MaxID = 0;
            string strSQL = "";

            OdbcConnection oConnection = this.OpenConnection();
            if (idTipoDocumentacion == 1)
            {
                strSQL = "UPDATE remitos SET periodoCobranza = " + idtipoCobranza +
                " WHERE nroRemito = " + nroRemito;

            }
            if (idTipoDocumentacion == 2)
            {
                strSQL = "UPDATE partesEntrega SET periodoCobranza = " + idtipoCobranza +
                " WHERE nroParte = " + nroRemito;
            }

            try
            {
                OdbcCommand myCommand = new OdbcCommand(strSQL, oConnection);
                myCommand.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                string p = e.Message;
                return MaxID;
            }

            return MaxID;
        }


        public void cargarRemitoParte(int lidTipoDocumento, int lnroRemito)
        {

            OdbcConnection oConnection = OpenConnection();
            string strSql = "";
            if (lidTipoDocumento == 1)
                strSql = "select * from remitos where nroRemito=" + lnroRemito.ToString();

            if (lidTipoDocumento == 2)
                strSql = "select nroParte as nroRemito, periodoCobranza from partesEntrega where nroParte=" + lnroRemito.ToString();
            //try
            {
                OdbcDataAdapter myConsulta = new OdbcDataAdapter(strSql, oConnection);
                DataSet myDataSet = new DataSet();
                myConsulta.Fill(myDataSet);
                intNroRemito = int.Parse(myDataSet.Tables[0].Rows[0]["nroRemito"].ToString());
                intTipoPeriodo = int.Parse(myDataSet.Tables[0].Rows[0]["periodoCobranza"].ToString());

                oConnection.Close();
            }
            //	catch {}
        }


        public void agregarInformesRemitoParte(int idTipoDocumentacion, int idRemito, int idTipoInforme, int idEncabezado, decimal precio)
        {
            //int MaxID = 0;
            OdbcConnection oConnection = this.OpenConnection();
            string strSQL = "";
            if (idTipoDocumentacion == 1)
            {
                strSQL = strSQL + "Insert into remitoinforme (nroRemito, idEncabezado, idTipoInforme, precio, fecha, facturado) ";
                strSQL = strSQL + " values (" + idRemito + ", " + idEncabezado + ", " + idTipoInforme + ", " + precio.ToString().Replace(',', '.') + ", getdate(), 0)";
            }

            if (idTipoDocumentacion == 2)
            {
                strSQL = strSQL + "Insert into parteEntregaInforme (nroParte, idEncabezado, idTipoInforme, precio, fecha, facturado) ";
                strSQL = strSQL + " values (" + idRemito + ", " + idEncabezado + ", " + idTipoInforme + ", " + precio.ToString().Replace(',', '.') + ", getdate(), 0)";
            }

            try
            {
                OdbcCommand myCommand = new OdbcCommand(strSQL, oConnection);
                myCommand.ExecuteNonQuery();

                //MaxID = ObtenerMaxID(strMaxID, oConnection);
            }
            catch (Exception e)
            {
                string p = e.Message;
                //return MaxID;
            }

            //return MaxID;
        }

        public void modificarInformesRemitoParte(int idTipoDocumentacion, int idRemito, int idTipoInforme, int idEncabezado, decimal precio)
        {
            //int MaxID = 0;
            OdbcConnection oConnection = this.OpenConnection();
            string strSQL = "";
            if (idTipoDocumentacion == 1)
            {
                strSQL = strSQL + "UPDATE remitoinforme SET " +
                    "precio = " + precio.ToString().Replace(',', '.') +
                    " WHERE nroRemito=" + idRemito + " AND idEncabezado=" + idEncabezado;
            }

            if (idTipoDocumentacion == 2)
            {
                strSQL = strSQL + "UPDATE parteEntregaInforme SET " +
                    "precio = " + precio.ToString().Replace(',', '.') +
                    " WHERE nroParte=" + idRemito + " AND idEncabezado=" + idEncabezado;
            }

            try
            {
                OdbcCommand myCommand = new OdbcCommand(strSQL, oConnection);
                myCommand.ExecuteNonQuery();

                //MaxID = ObtenerMaxID(strMaxID, oConnection);
            }
            catch (Exception e)
            {
                string p = e.Message;
                //return MaxID;
            }

            //return MaxID;
        }


        public bool eliminarInformeRemito(int tipoDocumentacion, int nroRemito, int idEncabezado)
        {
            OdbcConnection oConnection = this.OpenConnection();
            string strSQL = "";
            if (tipoDocumentacion == 1)
            {
                strSQL = "DELETE remitoinforme " +
                     " WHERE idEncabezado = " + idEncabezado +
                     " AND nroRemito=" + nroRemito +
                     " AND facturado=0";
            }

            if (tipoDocumentacion == 2)
            {
                strSQL = "DELETE parteentregainforme " +
                     " WHERE idEncabezado = " + idEncabezado +
                     " AND nroParte=" + nroRemito +
                     " AND facturado=0";
            }

            //String strMaxID = "SELECT MAX(nroRemito) as MaxId FROM remitos";

            try
            {
                OdbcCommand myCommand = new OdbcCommand(strSQL, oConnection);
                myCommand.ExecuteNonQuery();

                //MaxID = ObtenerMaxID(strMaxID, oConnection);
            }
            catch (Exception e)
            {
                string p = e.Message;
                return false;
            }

            return true;
        }


        public bool eliminarRemitoMovimiento(int idTipoDocumentacion, int nroMovimiento, int nroRemito)
        {
            OdbcConnection oConnection = this.OpenConnection();
            string strSQL = "";
            string strSQLMonto = "";
            if (idTipoDocumentacion == 1)
            {
                strSQL = "DELETE CtaCteMovimientosRemitos " +
                " WHERE nroMovimiento = " + nroMovimiento +
                " AND nroRemito=" + nroRemito;
            }

            if (idTipoDocumentacion == 2)
            {
                strSQL = "DELETE CtaCteMovimientosPartesEntrega " +
                " WHERE nroMovimiento = " + nroMovimiento +
                " AND nroParte=" + nroRemito;
            }

            strSQLMonto = "setMontoDocumentoMensual " + nroMovimiento + ", " + idTipoDocumentacion;

            //String strMaxID = "SELECT MAX(nroRemito) as MaxId FROM remitos";

            try
            {
                OdbcCommand myCommand = new OdbcCommand(strSQL, oConnection);
                myCommand.ExecuteNonQuery();

                OdbcCommand myCommand2 = new OdbcCommand(strSQLMonto, oConnection);
                myCommand2.ExecuteNonQuery();

                //MaxID = ObtenerMaxID(strMaxID, oConnection);
            }
            catch (Exception e)
            {
                string p = e.Message;
                return false;
            }

            return true;
        }


        public bool eliminarAdicionalRemito(int tipoDocumentacion, int nroRemito, int idAdicional)
        {
            OdbcConnection oConnection = this.OpenConnection();
            string strSQL = "";

            if (tipoDocumentacion == 1)
            {
                strSQL = "DELETE remitoadicionales " +
                     " WHERE idAdicional = " + idAdicional +
                     " AND nroRemito=" + nroRemito +
                     " AND facturado=0";
            }

            if (tipoDocumentacion == 2)
            {
                strSQL = "DELETE parteEntregaAdicionales " +
                     " WHERE idAdicional = " + idAdicional +
                     " AND nroParte=" + nroRemito +
                     " AND facturado=0";
            }

            try
            {
                OdbcCommand myCommand = new OdbcCommand(strSQL, oConnection);
                myCommand.ExecuteNonQuery();

                //MaxID = ObtenerMaxID(strMaxID, oConnection);
            }
            catch (Exception e)
            {
                string p = e.Message;
                return false;
            }

            return true;
        }


        public bool eliminarTodosAdicionalesRemitosParteEntrega(int tipoDocumentacion, int nroRemito)
        {
            OdbcConnection oConnection = this.OpenConnection();
            string strSQL = "";

            if (tipoDocumentacion == 1)
            {
                strSQL = "DELETE remitoadicionales " +
                     " WHERE nroRemito=" + nroRemito +
                     " AND facturado=0";
            }

            if (tipoDocumentacion == 2)
            {
                strSQL = "DELETE parteEntregaAdicionales " +
                     " WHERE nroParte=" + nroRemito +
                     " AND facturado=0";
            }

            try
            {
                OdbcCommand myCommand = new OdbcCommand(strSQL, oConnection);
                myCommand.ExecuteNonQuery();

                //MaxID = ObtenerMaxID(strMaxID, oConnection);
            }
            catch (Exception e)
            {
                string p = e.Message;
                return false;
            }

            return true;
        }

        public void agregarAdicionalRemito(int idTipoDocumentacion, int idRemito, int idAdicional, int Cantidad, decimal precio)
        {
            //int MaxID = 0;
            OdbcConnection oConnection = this.OpenConnection();
            string strSQL = "";
            if (idTipoDocumentacion == 1)
            {
                strSQL = strSQL + "Insert into remitoadicionales(nroRemito, idAdicional, cantidad, precio, fecha, facturado) ";
                strSQL = strSQL + " values (" + idRemito + ", " + idAdicional + ", " + Cantidad + ", " + precio.ToString().Replace(',', '.') + ", getdate(), 0)";
            }

            if (idTipoDocumentacion == 2)
            {
                strSQL = strSQL + "Insert into parteEntregaAdicionales(nroParte, idAdicional, cantidad, precio, fecha, facturado) ";
                strSQL = strSQL + " values (" + idRemito + ", " + idAdicional + ", " + Cantidad + ", " + precio.ToString().Replace(',', '.') + ", getdate(), 0)";
            }

            try
            {
                OdbcCommand myCommand = new OdbcCommand(strSQL, oConnection);
                myCommand.ExecuteNonQuery();
                //cmd.ExecuteNonQuery();

                //MaxID = ObtenerMaxID(strMaxID, oConnection);
            }
            catch (Exception e)
            {
                string p = e.Message;
                //return MaxID;
            }

            //return MaxID;
        }

        private static int ObtenerMaxID(string strMaxID, OdbcConnection oConnection)
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

        public static DataTable ListaRemitosPartesEntrega(int idTipoDocumentacion, int idCliente, string FechaDesde, string FechaHasta, bool SinMovimiento, string nroMovimiento)
        {
            //SinMovimiento: "false" lista los remitos/partes desde abmRemitos. "true" lista los remitos/partes desde abmMovimientos.

            if (FechaDesde != "")
                FechaDesde = "'" + FechaDesde + " 00:00:00.000'";

            if (FechaHasta != "")
                FechaHasta = "'" + FechaHasta + " 23:59:59.999'";

            string FechaActual = DateTime.Today.ToShortDateString();
            FechaActual = "'" + FechaActual + " 00:00:00.000'";

            StringBuilder strQuery = new StringBuilder(512);
            DataTable dtSalida = null;

            if (idTipoDocumentacion == 1)
            {
                strQuery.Append("select r.nroRemito, r.fecha, r.estado, count(distinct(ri.idEncabezado)) as cantInformes, isnull(sum(distinct(ra.cantidad)),0) as cantAdicionales ");
                strQuery.Append("from remitos r ");
                strQuery.Append("left outer join remitoinforme ri on r.nroRemito=ri.nroRemito ");
                strQuery.Append("left outer join remitoadicionales ra on r.nroRemito=ra.nroRemito ");
                strQuery.Append("where r.idCliente= " + idCliente + " ");
                if (nroMovimiento != "")
                {
                    strQuery.Append("AND r.nroRemito IN (SELECT nroRemito from CtaCteMovimientosRemitos ");
                    strQuery.Append("WHERE nroMovimiento= " + int.Parse(nroMovimiento) + ")  ");
                }
                if (FechaDesde != "" && FechaDesde != "")
                    strQuery.Append("AND r.fecha BETWEEN " + FechaDesde + " AND " + FechaHasta + " ");
                if (SinMovimiento)
                {
                    strQuery.Append("AND r.periodoCobranza=2 AND r.nroRemito NOT IN ( ");
                    strQuery.Append("select ccmr.nroRemito ");
                    strQuery.Append("from CtaCteRemitos ccm ");
                    strQuery.Append("inner join CtaCteMovimientosRemitos ccmr on ccmr.nroMovimiento=ccm.nroMovimiento ");
                    strQuery.Append("where ccm.idCliente= " + idCliente + " ");
                    strQuery.Append("AND ccm.fecha BETWEEN " + FechaDesde + " AND " + FechaHasta + " )");
                }

                strQuery.Append("group by r.nroRemito, r.fecha, r.estado ");
                strQuery.Append("order by r.nroRemito Desc");
            }

            if (idTipoDocumentacion == 2)
            {
                strQuery.Append("select r.nroParte as nroRemito, r.fecha, r.estado, count(distinct(ri.idEncabezado)) as cantInformes, isnull(sum(distinct(ra.cantidad)),0) as cantAdicionales ");
                strQuery.Append("from partesEntrega r ");
                strQuery.Append("left outer join parteEntregaInforme ri on r.nroParte=ri.nroParte ");
                strQuery.Append("left outer join parteEntregaAdicionales ra on r.nroParte=ra.nroParte ");
                strQuery.Append("where r.idCliente= " + idCliente + " ");
                if (nroMovimiento != "")
                {
                    strQuery.Append(" AND r.nroParte IN (SELECT nroParte from CtaCteMovimientosPartesEntrega ");
                    strQuery.Append("WHERE nroMovimiento= " + int.Parse(nroMovimiento) + ")  ");
                }
                if (FechaDesde != "" && FechaDesde != "")
                    strQuery.Append("AND r.fecha BETWEEN " + FechaDesde + " AND " + FechaHasta + " ");
                if (SinMovimiento)
                {
                    strQuery.Append("AND r.periodoCobranza=2 AND r.nroParte NOT IN ( ");
                    strQuery.Append("select ccmr.nroParte ");
                    strQuery.Append("from CtaCtePartesEntrega ccm ");
                    strQuery.Append("inner join CtaCteMovimientosPartesEntrega ccmr on ccmr.nroMovimiento=ccm.nroMovimiento ");
                    strQuery.Append("where ccm.idCliente= " + idCliente + " ");
                    strQuery.Append("AND ccm.fecha BETWEEN " + FechaDesde + " AND " + FechaHasta + " )");
                }

                strQuery.Append("group by r.nroParte, r.fecha, r.estado ");
                strQuery.Append("order by r.nroParte Desc");
            }

            try
            {
                dtSalida = StaticDal.EjecutarDataSet(strQuery.ToString(), "RemitoxCliente").Tables[0];
            }
            catch
            {
                throw;
            }
            return dtSalida;
        }


        public static DataTable ListaRemitosPartesEntrega(int tipoDocumento, int nroRemito)
        {

            StringBuilder strQuery = new StringBuilder(512);
            DataTable dtSalida = null;
            if (tipoDocumento == 1)
            {
                strQuery.Append("select r.nroRemito, r.fecha ");
                strQuery.Append("from remitos r ");
                strQuery.Append("where r.nroRemito= " + nroRemito + " ");
            }

            if (tipoDocumento == 2)
            {
                strQuery.Append("select r.nroParte as nroRemito, r.fecha ");
                strQuery.Append("from partesEntrega r ");
                strQuery.Append("where r.nroParte= " + nroRemito + " ");
            }


            try
            {
                dtSalida = StaticDal.EjecutarDataSet(strQuery.ToString(), "RemitoxCliente").Tables[0];
            }
            catch
            {
                throw;
            }
            return dtSalida;
        }


        public static DataTable ListarAdicionalesRemito(int tipoDocumentacion, int nroRemito)
        {

            StringBuilder strQuery = new StringBuilder(512);
            DataTable dtSalida = null;

            if (tipoDocumentacion == 1)
            {
                strQuery.Append("SELECT ra.nroRemito, ra.idAdicional, ra.cantidad, ra.precio as PrecioUnitario, ");
                strQuery.Append("(ra.cantidad* ra.precio) as Precio , sa.descripcion as Adicional ");
                strQuery.Append("FROM remitoadicionales ra ");
                strQuery.Append("INNER JOIN serviciosadicionales sa ON ra.idAdicional=sa.id ");
                strQuery.Append("WHERE ra.nroRemito= " + nroRemito + " ");
            }

            if (tipoDocumentacion == 2)
            {
                strQuery.Append("SELECT ra.nroParte as nroRemito, ra.idAdicional, ra.cantidad, ra.precio as PrecioUnitario, ");
                strQuery.Append("(ra.cantidad* ra.precio) as Precio , sa.descripcion as Adicional ");
                strQuery.Append("FROM parteEntregaAdicionales ra ");
                strQuery.Append("INNER JOIN serviciosadicionales sa ON ra.idAdicional=sa.id ");
                strQuery.Append("WHERE ra.nroParte= " + nroRemito + " ");
            }

            try
            {
                dtSalida = StaticDal.EjecutarDataSet(strQuery.ToString(), "RemitoxCliente").Tables[0];
            }
            catch
            {
                throw;
            }
            return dtSalida;
        }


        public static DataTable ListaDetallesRemitoParteEntrega(int idTipoDocumentacion, int NroRemito, bool refer)
        {

            StringBuilder strQuery = new StringBuilder(512);
            DataTable dtSalida = null;
            /*
            strQuery.Append("select count(ri.idTipoInforme) as cantidad, ti.descripcion, ri.precio as precioUnitario, (count(ri.idTipoInforme) * ri.precio) as precioTotal ");
            strQuery.Append("from remitos r ");
            strQuery.Append("inner join remitoinforme ri on r.nroRemito=ri.nroRemito ");
            strQuery.Append("inner join tiposinformes ti on ri.idTipoInforme=ti.idTipoInforme ");
            strQuery.Append("where r.nroRemito=" + NroRemito + " ");
            strQuery.Append("group by ri.idTipoInforme, ti.descripcion, ri.precio ");
            strQuery.Append("union ");
            strQuery.Append("select ra.cantidad, sa.descripcion, ra.precio as precioUnitario, (ra.cantidad*ra.precio) as precioTotal ");
            strQuery.Append("from remitos r ");
            strQuery.Append("inner join remitoadicionales ra on r.nroRemito=ra.nroRemito ");
            strQuery.Append("inner join serviciosadicionales sa on sa.id=ra.idAdicional ");
            strQuery.Append("where r.nroRemito=" + NroRemito + " ");
            */
            /* AGRUPADOS POR TIPO
            strQuery.Append("SELECT count(ri.idTipoInforme) as cantidad, ");
            strQuery.Append("(ti.descripcion + ");
            strQuery.Append("isnull(CASE WHEN b.idTipoInforme=1 THEN ' - ' + tp.descripcion ELSE NULL END, '') + ");
            strQuery.Append("isnull(CASE WHEN b.idTipoInforme=1 AND b.PROPTipo <> 1 THEN ' (' + c.descripcion + ')' ELSE NULL END, '') ");
            strQuery.Append(") as descripcion, ");
            strQuery.Append("ri.precio as precioUnitario, ");
            strQuery.Append("(count(ri.idTipoInforme) * ri.precio) as precioTotal, 1 as orden, ri.idTipoInforme ");
            strQuery.Append("from remitos r ");
            strQuery.Append("inner join remitoinforme ri on r.nroRemito=ri.nroRemito ");
            strQuery.Append("inner join bandejaentrada b on b.idEncabezado=ri.idEncabezado ");
            strQuery.Append("inner join tiposinformes ti on ri.idTipoInforme=ti.idTipoInforme ");
            strQuery.Append("inner join tipopropiedad tp on b.PROPTipo=tp.idTipoPropiedad ");
            strQuery.Append("inner join caracter c on b.caracter=c.idCaracter ");
            strQuery.Append("where r.nroRemito=" + NroRemito + " ");
            strQuery.Append("group by ri.idTipoInforme, ti.descripcion, ri.precio, b.idTipoInforme, b.PROPTipo, tp.descripcion, c.descripcion ");
            strQuery.Append("union ");
            strQuery.Append("select ra.cantidad, sa.descripcion, ra.precio as precioUnitario, (ra.cantidad*ra.precio) as precioTotal, 2 as orden, 1000 as idTipoInforme ");
            strQuery.Append("from remitos r ");
            strQuery.Append("inner join remitoadicionales ra on r.nroRemito=ra.nroRemito ");
            strQuery.Append("inner join serviciosadicionales sa on sa.id=ra.idAdicional ");
            strQuery.Append("where r.nroRemito=" + NroRemito + " ");
            strQuery.Append("order by orden, ri.idTipoInforme");
            */

            if (idTipoDocumentacion == 1)
            {
                strQuery.Append("SELECT count(ri.idTipoInforme) as cantidad, ");
                strQuery.Append("(ti.descripcion + ': ' + ");
                strQuery.Append("replace(replace(b.descripcioninf, '<B>', ''),'</B>','') ");
                if (refer)
                    strQuery.Append("+ '  (Ref. ' + rf.descripcion + ')'");
                strQuery.Append(") as descripcion, ");
                strQuery.Append("ri.precio as precioUnitario, (count(ri.idTipoInforme) * ri.precio) as precioTotal, 1 as orden, ");
                strQuery.Append("ri.idTipoInforme ");
                strQuery.Append("from remitos r ");
                strQuery.Append("inner join remitoinforme ri on r.nroRemito=ri.nroRemito ");
                strQuery.Append("inner join bandejaentrada b on b.idEncabezado=ri.idEncabezado ");
                strQuery.Append("inner join referencias rf on b.idReferencia=rf.idReferencia ");
                strQuery.Append("inner join tiposinformes ti on ri.idTipoInforme=ti.idTipoInforme ");
                strQuery.Append("inner join tipopropiedad tp on b.PROPTipo=tp.idTipoPropiedad ");

                strQuery.Append("where r.nroRemito=" + NroRemito + " ");
                strQuery.Append("group by ri.idTipoInforme, ti.descripcion, ri.precio, b.idTipoInforme, b.PROPTipo, ");
                strQuery.Append("tp.descripcion, b.descripcioninf, rf.descripcion ");

                strQuery.Append("union ");
                strQuery.Append("select ra.cantidad, sa.descripcion, ra.precio as precioUnitario, (ra.cantidad*ra.precio) as precioTotal, ");
                strQuery.Append("2 as orden, 1000 as idTipoInforme ");
                strQuery.Append("from remitos r ");
                strQuery.Append("inner join remitoadicionales ra on r.nroRemito=ra.nroRemito ");
                strQuery.Append("inner join serviciosadicionales sa on sa.id=ra.idAdicional ");
                strQuery.Append("where r.nroRemito=" + NroRemito + " ");
                strQuery.Append("order by orden, ri.idTipoInforme");
            }
            if (idTipoDocumentacion == 2)
            {
                strQuery.Append("SELECT count(ri.idTipoInforme) as cantidad, ");
                strQuery.Append("(ti.descripcion + ': ' + ");
                strQuery.Append("replace(replace(b.descripcioninf, '<B>', ''),'</B>','') ");
                if (refer)
                    strQuery.Append("+ '  (Ref. ' + rf.descripcion + ')'");
                strQuery.Append(") as descripcion, ");
                strQuery.Append("ri.precio as precioUnitario, (count(ri.idTipoInforme) * ri.precio) as precioTotal, 1 as orden, ");
                strQuery.Append("ri.idTipoInforme ");
                strQuery.Append("from partesEntrega r ");
                strQuery.Append("inner join parteEntregaInforme ri on r.nroParte=ri.nroParte ");
                strQuery.Append("inner join bandejaentrada b on b.idEncabezado=ri.idEncabezado ");
                strQuery.Append("inner join referencias rf on b.idReferencia=rf.idReferencia ");
                strQuery.Append("inner join tiposinformes ti on ri.idTipoInforme=ti.idTipoInforme ");
                strQuery.Append("inner join tipopropiedad tp on b.PROPTipo=tp.idTipoPropiedad ");

                strQuery.Append("where r.nroParte=" + NroRemito + " ");
                strQuery.Append("group by ri.idTipoInforme, ti.descripcion, ri.precio, b.idTipoInforme, b.PROPTipo, ");
                strQuery.Append("tp.descripcion, b.descripcioninf, rf.descripcion ");

                strQuery.Append("union ");
                strQuery.Append("select ra.cantidad, sa.descripcion, ra.precio as precioUnitario, (ra.cantidad*ra.precio) as precioTotal, ");
                strQuery.Append("2 as orden, 1000 as idTipoInforme ");
                strQuery.Append("from partesEntrega r ");
                strQuery.Append("inner join parteEntregaAdicionales ra on r.nroParte=ra.nroParte ");
                strQuery.Append("inner join serviciosadicionales sa on sa.id=ra.idAdicional ");
                strQuery.Append("where r.nroParte=" + NroRemito + " ");
                strQuery.Append("order by orden, ri.idTipoInforme");
            }

            try
            {
                dtSalida = StaticDal.EjecutarDataSet(strQuery.ToString(), "RemitoxCliente").Tables[0];
            }
            catch
            {
                throw;
            }
            return dtSalida;
        }


        public static decimal precioTotalRemitoParteEntrega(int idTipoDocumento, int NroRemito)
        {
            DataTable Datos = GestorPrecios.ListaDetallesRemitoParteEntrega(idTipoDocumento, NroRemito, false);
            decimal precioTotal = 0;
            for (int i = 0; i < Datos.Rows.Count; i++)
            {
                precioTotal = precioTotal + decimal.Parse(Datos.Rows[i]["precioTotal"].ToString());
            }

            return precioTotal;
        }


        //public static decimal guardarPrecioRemitoParte(decimal )

        public static void AgregarClienteCuentaCorriente(int lIdCliente)
        {
            try
            {
                StringBuilder strQuery = new StringBuilder(512);
                strQuery.Append("insert into cuentascorrientes (idCliente, fechaIngreso, activo) ");
                strQuery.Append(" Values (" + StaticDal.Traduce(lIdCliente));
                strQuery.Append(", getdate() ");
                strQuery.Append(", 1)");

                StaticDal.EjecutarComando(strQuery.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + Environment.NewLine + e.StackTrace);
            }

        }


        public static DataTable TraerCuentasClientes()
        {
            StringBuilder strQuery = new StringBuilder(512);
            DataTable dtSalida = null;
            strQuery.Append("Select c.idCliente, c.razonsocial, c.nombrefantasia, c.sucursal, c.telefono,  ");
            strQuery.Append(" (c.calle +' '+ c.numero) as direccion, c.fax, c.cuit, c.email ");
            strQuery.Append(" From clientes c INNER JOIN cuentascorrientes cc ON c.idCliente=cc.idCliente ");
            strQuery.Append(" Order by c.nombrefantasia");

            try
            {

                dtSalida = StaticDal.EjecutarDataSet(strQuery.ToString(), "Precios").Tables[0];
            }
            catch
            {
                throw;
            }

            return dtSalida;
        }


        public static DataTable ListaMovimientosCliente(int idTipoDocumento, int idCliente, string FechaDesde, string FechaHasta)
        {
            if (FechaDesde != "")
                FechaDesde = "'" + FechaDesde + " 00:00:00.000'";

            if (FechaHasta != "")
                FechaHasta = "'" + FechaHasta + " 23:59:59.999'";

            string FechaActual = DateTime.Today.ToShortDateString();
            FechaActual = "'" + FechaActual + " 00:00:00.000'";

            StringBuilder strQuery = new StringBuilder(512);
            DataTable dtSalida = null;
            if (idTipoDocumento == 1)
            {
                strQuery.Append("select ccr.nroMovimiento, ccr.fecha, count(ccr.nroMovimiento) as cantRemitos ");
                strQuery.Append("from  CtaCteRemitos ccr  ");
                strQuery.Append("inner join CtaCteMovimientosRemitos ccmr on ccmr.nroMovimiento=ccr.nroMovimiento  ");
                strQuery.Append("where ccr.idCliente= " + idCliente + " ");
                strQuery.Append("AND ccr.fecha BETWEEN " + FechaDesde + " AND " + FechaHasta + " ");
                strQuery.Append("group by ccr.nroMovimiento, ccr.fecha ");
                strQuery.Append("order by ccr.nroMovimiento Desc");
            }

            if (idTipoDocumento == 2)
            {
                strQuery.Append("select ccr.nroMovimiento, ccr.fecha, count(ccr.nroMovimiento) as cantRemitos ");
                strQuery.Append("from  CtaCtePartesEntrega ccr  ");
                strQuery.Append("inner join CtaCteMovimientosPartesEntrega ccmr on ccmr.nroMovimiento=ccr.nroMovimiento  ");
                strQuery.Append("where ccr.idCliente= " + idCliente + " ");
                strQuery.Append("AND ccr.fecha BETWEEN " + FechaDesde + " AND " + FechaHasta + " ");
                strQuery.Append("group by ccr.nroMovimiento, ccr.fecha ");
                strQuery.Append("order by ccr.nroMovimiento Desc");
            }

            try
            {
                dtSalida = StaticDal.EjecutarDataSet(strQuery.ToString(), "MovimientosxCliente").Tables[0];
            }
            catch
            {
                throw;
            }
            return dtSalida;
        }


        public static DataTable ListaMovimientosCliente(int idTipoDocumentacion, int nroMovimiento)
        {

            StringBuilder strQuery = new StringBuilder(512);
            DataTable dtSalida = null;

            if (idTipoDocumentacion == 1)
            {
                strQuery.Append("select ccm.nroMovimiento, ccm.fecha ");
                strQuery.Append("from CtaCteRemitos ccm ");
                strQuery.Append("where ccm.nroMovimiento= " + nroMovimiento + " ");
            }

            if (idTipoDocumentacion == 2)
            {
                strQuery.Append("select ccm.nroMovimiento, ccm.fecha ");
                strQuery.Append("from CtaCtePartesEntrega ccm ");
                strQuery.Append("where ccm.nroMovimiento= " + nroMovimiento + " ");
            }

            try
            {
                dtSalida = StaticDal.EjecutarDataSet(strQuery.ToString(), "MovimientoxCliente").Tables[0];
            }
            catch
            {
                throw;
            }
            return dtSalida;
        }

        public static DataTable ListaDetallesRemitosMovimiento(int idTipoDocumento, int NroMovimiento, int idCliente)
        {

            StringBuilder strQuery = new StringBuilder(512);
            DataTable dtSalida = null;

            if (idTipoDocumento == 1)
            {
                strQuery.Append("select count(ri.idTipoInforme) as cantidad, ");
                strQuery.Append("(ti.descripcion + ");
                strQuery.Append("isnull(CASE WHEN b.idTipoInforme=1 THEN ' - ' + tp.descripcion ELSE NULL END, '') + ");
                strQuery.Append("isnull(CASE WHEN b.idTipoInforme=1 AND b.PROPTipo <> 1 THEN ' (' + c.descripcion + ')' ELSE NULL END, '') + ");
                strQuery.Append("isnull(CASE WHEN (b.idTipoInforme=13 OR b.idTipoInforme=3 OR b.idTipoInforme=16 ) THEN ' (' + c.descripcion + ')' ELSE NULL END, '') ");
                strQuery.Append(") as descripcion, ");
                strQuery.Append("ri.precio as precioUnitario, (count(ri.idTipoInforme) * ri.precio) as precioTotal, 1 as orden, ri.idTipoInforme, b.caracter  ");
                strQuery.Append("from CtaCteRemitos ccr  ");
                strQuery.Append("inner join CtaCteMovimientosRemitos ccmr on ccr.nroMovimiento=ccmr.nroMovimiento ");
                strQuery.Append("inner join remitos r on ccmr.nroRemito=r.nroRemito ");
                strQuery.Append("inner join remitoinforme ri on r.nroRemito=ri.nroRemito ");
                strQuery.Append("inner join bandejaentrada b on b.idEncabezado=ri.idEncabezado ");
                strQuery.Append("inner join tiposinformes ti on ri.idTipoInforme=ti.idTipoInforme ");
                strQuery.Append("inner join tipopropiedad tp on b.PROPTipo=tp.idTipoPropiedad ");
                strQuery.Append("inner join caracter c on b.caracter=c.idCaracter ");
                strQuery.Append("where ccmr.nroMovimiento=" + NroMovimiento + " ");
                strQuery.Append("and ccr.idCliente=" + idCliente + " ");
                strQuery.Append("group by ri.idTipoInforme, ti.descripcion, ri.precio, b.idTipoInforme, b.PROPTipo, tp.descripcion, c.descripcion, b.caracter ");
                strQuery.Append("union ");
                strQuery.Append("select sum(ra.cantidad), sa.descripcion, ra.precio as precioUnitario, (sum(ra.cantidad)*ra.precio) as precio, 2 as orden, 1000 as idTipoInforme, 0  ");
                strQuery.Append("from CtaCteRemitos ccr  ");
                strQuery.Append("inner join ctaCteMovimientosRemitos ccmr on ccr.nroMovimiento=ccmr.nroMovimiento ");
                strQuery.Append("inner join remitos r on ccmr.nroRemito=r.nroRemito ");
                strQuery.Append("inner join remitoadicionales ra on r.nroRemito=ra.nroRemito ");
                strQuery.Append("inner join serviciosadicionales sa on sa.id=ra.idAdicional ");
                strQuery.Append("where ccmr.nroMovimiento=" + NroMovimiento + " ");
                strQuery.Append("and ccr.idCliente=" + idCliente + " ");
                strQuery.Append("group by sa.descripcion, ra.precio ");
                strQuery.Append("order by orden, ri.idTipoInforme");
            }

            if (idTipoDocumento == 2)
            {
                strQuery.Append("select count(ri.idTipoInforme) as cantidad, ");
                strQuery.Append("(ti.descripcion + ");
                strQuery.Append("isnull(CASE WHEN b.idTipoInforme=1 THEN ' - ' + tp.descripcion ELSE NULL END, '') + ");
                strQuery.Append("isnull(CASE WHEN b.idTipoInforme=1 AND b.PROPTipo <> 1 THEN ' (' + c.descripcion + ')' ELSE NULL END, '') + ");
                strQuery.Append("isnull(CASE WHEN (b.idTipoInforme=13 OR b.idTipoInforme=3 OR b.idTipoInforme=16 ) THEN ' (' + c.descripcion + ')' ELSE NULL END, '') ");
                strQuery.Append(") as descripcion, ");
                strQuery.Append("ri.precio as precioUnitario, (count(ri.idTipoInforme) * ri.precio) as precioTotal, 1 as orden, ri.idTipoInforme, b.caracter  ");
                strQuery.Append("from CtaCtePartesEntrega ccr  ");
                strQuery.Append("inner join CtaCteMovimientosPartesEntrega ccmr on ccr.nroMovimiento=ccmr.nroMovimiento ");
                strQuery.Append("inner join partesEntrega r on ccmr.nroParte=r.nroParte ");
                strQuery.Append("inner join parteEntregaInforme ri on r.nroParte=ri.nroParte ");
                strQuery.Append("inner join bandejaentrada b on b.idEncabezado=ri.idEncabezado ");
                strQuery.Append("inner join tiposinformes ti on ri.idTipoInforme=ti.idTipoInforme ");
                strQuery.Append("inner join tipopropiedad tp on b.PROPTipo=tp.idTipoPropiedad ");
                strQuery.Append("inner join caracter c on b.caracter=c.idCaracter ");
                strQuery.Append("where ccmr.nroMovimiento=" + NroMovimiento + " ");
                strQuery.Append("and ccr.idCliente=" + idCliente + " ");
                strQuery.Append("group by ri.idTipoInforme, ti.descripcion, ri.precio, b.idTipoInforme, b.PROPTipo, tp.descripcion, c.descripcion, b.caracter ");
                strQuery.Append("union ");
                strQuery.Append("select sum(ra.cantidad), sa.descripcion, ra.precio as precioUnitario, (sum(ra.cantidad)*ra.precio) as precio, 2 as orden, 1000 as idTipoInforme, 0  ");
                strQuery.Append("from CtaCtePartesEntrega ccr  ");
                strQuery.Append("inner join CtaCteMovimientosPartesEntrega ccmr on ccr.nroMovimiento=ccmr.nroMovimiento ");
                strQuery.Append("inner join partesEntrega r on ccmr.nroParte=r.nroParte ");
                strQuery.Append("inner join parteEntregaAdicionales ra on r.nroParte=ra.nroParte ");
                strQuery.Append("inner join serviciosadicionales sa on sa.id=ra.idAdicional ");
                strQuery.Append("where ccmr.nroMovimiento=" + NroMovimiento + " ");
                strQuery.Append("and ccr.idCliente=" + idCliente + " ");
                strQuery.Append("group by sa.descripcion, ra.precio ");
                strQuery.Append("order by orden, ri.idTipoInforme");
            }

            try
            {
                dtSalida = StaticDal.EjecutarDataSet(strQuery.ToString(), "RemitosMovimientoxCliente").Tables[0];
            }
            catch
            {
                throw;
            }
            return dtSalida;
        }


        public static decimal precioTotalRemitosMovimiento(int idTipoDocumento, int NroMovimiento, int idCliente)
        {
            DataTable Datos = GestorPrecios.ListaDetallesRemitosMovimiento(idTipoDocumento, NroMovimiento, idCliente);
            decimal precioTotal = 0;
            for (int i = 0; i < Datos.Rows.Count; i++)
            {
                precioTotal = precioTotal + decimal.Parse(Datos.Rows[i]["precioTotal"].ToString());
            }

            return precioTotal;
        }


        public static DataTable NroRemitosPorMovimiento(int idTipoDocumentacion, int nroMovimiento)
        {

            StringBuilder strQuery = new StringBuilder(512);
            DataTable dtSalida = null;

            if (idTipoDocumentacion == 1)
            {
                strQuery.Append("select nromovimiento, nroRemito from CtaCteMovimientosRemitos ");
                strQuery.Append("where nroMovimiento= " + nroMovimiento + " ");
                strQuery.Append("order by nroRemito");
            }

            if (idTipoDocumentacion == 2)
            {
                strQuery.Append("select nromovimiento, nroParte as nroRemito from CtaCteMovimientosPartesEntrega ");
                strQuery.Append("where nroMovimiento= " + nroMovimiento + " ");
                strQuery.Append("order by nroParte");
            }


            try
            {
                dtSalida = StaticDal.EjecutarDataSet(strQuery.ToString(), "RemitosxMovimiento").Tables[0];
            }
            catch
            {
                throw;
            }
            return dtSalida;
        }


        public static string periodoMovimiento(int idTipoDocumentacion, int nroMovimiento)
        {

            StringBuilder strQuery = new StringBuilder(512);
            DataTable dtSalida = null;
            string resultado = "";
            if (idTipoDocumentacion == 1)
            {
                strQuery.Append("select min(r.fecha) as fechaMin, max(rr.fecha) as fechaMax ");
                strQuery.Append("from CtaCteMovimientosRemitos ccmr ");
                strQuery.Append("inner join remitos r on r.nroRemito=ccmr.nroRemito ");
                strQuery.Append("inner join remitos rr on rr.nroRemito=ccmr.nroRemito ");
                strQuery.Append("where ccmr.nroMovimiento= " + nroMovimiento + " ");
            }

            if (idTipoDocumentacion == 2)
            {
                strQuery.Append("select min(r.fecha) as fechaMin, max(rr.fecha) as fechaMax ");
                strQuery.Append("from CtaCteMovimientosPartesEntrega ccmr ");
                strQuery.Append("inner join partesEntrega r on r.nroParte=ccmr.nroParte ");
                strQuery.Append("inner join partesEntrega rr on rr.nroParte=ccmr.nroParte ");
                strQuery.Append("where ccmr.nroMovimiento= " + nroMovimiento + " ");
            }

            try
            {
                dtSalida = StaticDal.EjecutarDataSet(strQuery.ToString(), "RemitosxMovimiento").Tables[0];

                resultado = dtSalida.Rows[0]["fechaMin"].ToString() + "," + dtSalida.Rows[0]["fechaMax"].ToString();
            }
            catch
            {
                throw;
            }
            return resultado;
        }


        public int CrearMovimiento(int idTipoDocumentacion, int idCliente, int idUsuarioIntra)
        {
            int MaxID = 0;
            OdbcConnection oConnection = this.OpenConnection();
            string strSQL = "";
            string strMaxID = "";

            if (idTipoDocumentacion == 1)
            {
                strSQL = strSQL + "Insert into CtaCteRemitos (idCliente, idUsuarioIntra, fecha) ";
                strSQL = strSQL + " values (" + idCliente + ", " + idUsuarioIntra + ", getdate())";

                strMaxID = "SELECT MAX(nroMovimiento) as MaxId FROM CtaCteRemitos";
            }

            if (idTipoDocumentacion == 2)
            {
                strSQL = strSQL + "Insert into CtaCtePartesEntrega (idCliente, idUsuarioIntra, fecha) ";
                strSQL = strSQL + " values (" + idCliente + ", " + idUsuarioIntra + ", getdate())";

                strMaxID = "SELECT MAX(nroMovimiento) as MaxId FROM CtaCtePartesEntrega";
            }

            try
            {
                OdbcCommand myCommand = new OdbcCommand(strSQL, oConnection);
                myCommand.ExecuteNonQuery();

                MaxID = ObtenerMaxID(strMaxID, oConnection);
            }
            catch (Exception e)
            {
                string p = e.Message;
                return MaxID;
            }

            return MaxID;
        }



        public int ActualizarMontoMovimiento(int idTipoDocumentacion, int nroMovimiento, decimal monto)
        {
            int MaxID = 0;
            OdbcConnection oConnection = this.OpenConnection();
            string strSQL = "";
            string strMaxID = "";

            if (idTipoDocumentacion == 1)
            {
                strSQL = strSQL + "UPDATE CtaCteRemitos SET estado=1, monto= " + monto;
                strSQL = strSQL + " WHERE nroMovimiento=" + nroMovimiento;

            }

            if (idTipoDocumentacion == 2)
            {
                strSQL = strSQL + "UPDATE CtaCtePartesEntrega SET estado=1, monto= " + monto;
                strSQL = strSQL + " WHERE nroMovimiento=" + nroMovimiento;
            }

            try
            {
                OdbcCommand myCommand = new OdbcCommand(strSQL, oConnection);
                myCommand.ExecuteNonQuery();

                MaxID = ObtenerMaxID(strMaxID, oConnection);
            }
            catch (Exception e)
            {
                string p = e.Message;
                return MaxID;
            }

            return MaxID;
        }

        public void agregarRemitoParteEntregaMovimiento(int idTipoDocumentacion, int nroMovimiento, int idRemito)
        {
            //int MaxID = 0;
            OdbcConnection oConnection = this.OpenConnection();
            String strSQL = "";

            if (idTipoDocumentacion == 1)
            {
                strSQL = strSQL + "Insert into CtaCteMovimientosRemitos (nroMovimiento, nroRemito) ";
                strSQL = strSQL + " values (" + nroMovimiento + ", " + idRemito + ")";
            }

            if (idTipoDocumentacion == 2)
            {
                strSQL = strSQL + "Insert into CtaCteMovimientosPartesEntrega (nroMovimiento, nroParte) ";
                strSQL = strSQL + " values (" + nroMovimiento + ", " + idRemito + ")";
            }

            //String strMaxID = "SELECT MAX(nroRemito) as MaxId FROM remitos";

            try
            {
                OdbcCommand myCommand = new OdbcCommand(strSQL, oConnection);
                myCommand.ExecuteNonQuery();

                //MaxID = ObtenerMaxID(strMaxID, oConnection);
            }
            catch (Exception e)
            {
                string p = e.Message;
                //return MaxID;
            }

            //return MaxID;
        }

        public void setearMontoRemito(int idDocumento, int idTipoDocumentacion, int tipoPeriodo)
        {
            //int MaxID = 0;
            OdbcConnection oConnection = this.OpenConnection();
            String strSQL = "";

            strSQL = "setMontoDocumento " + idDocumento + ", " + idTipoDocumentacion;

            //String strMaxID = "SELECT MAX(nroRemito) as MaxId FROM remitos";

            try
            {
                OdbcCommand myCommand = new OdbcCommand(strSQL, oConnection);
                myCommand.ExecuteNonQuery();

                //MaxID = ObtenerMaxID(strMaxID, oConnection);
            }
            catch (Exception e)
            {
                string p = e.Message;
                //return MaxID;
            }

            //return MaxID;

        }


        public void ActualizarMontosDocumentos(int idCliente, string FechaDesde, string FechaHasta)
        {
            //int MaxID = 0;
            OdbcConnection oConnection = this.OpenConnection();
            String strSQL = "";

            strSQL = "setMontoDocumentosCliente " + idCliente + ", '" + FechaDesde + "', '" + FechaHasta + "'";

            //String strMaxID = "SELECT MAX(nroRemito) as MaxId FROM remitos";

            try
            {
                OdbcCommand myCommand = new OdbcCommand(strSQL, oConnection);
                myCommand.ExecuteNonQuery();

                //MaxID = ObtenerMaxID(strMaxID, oConnection);
            }
            catch (Exception e)
            {
                string p = e.Message;
                //return MaxID;
            }

            //return MaxID;

        }




        public static DataTable ListaDocumentosPendientesCobrar(int idCliente, string FechaDesde, string FechaHasta, int Estado)
        {

            StringBuilder strQuery = new StringBuilder(512);
            DataTable dtSalida = null;

            //remitos diarios    
            strQuery.Append("select '1_1_' + ltrim(str(nroRemito)) as ID, nroRemito as 'nroDocumento', 1 as 'tipoDocumento', 1 as 'tipoPeriodo', fecha, 'Remito - diario Nº: ' + ltrim(str(nroRemito))  as 'Documento', isnull(monto,0) as monto ");
            strQuery.Append("from remitos ");
            strQuery.Append("where ");
            strQuery.Append("periodoCobranza=1 ");
            strQuery.Append("AND estado=" + Estado);
            strQuery.Append(" AND idCliente=" + idCliente);
            strQuery.Append(" AND fecha between '" + FechaDesde + " 00:00:00' AND '" + FechaHasta + " 23:59:59' ");

            strQuery.Append("union ");

            // partes diarios
            strQuery.Append("select '2_1_' + ltrim(str(nroParte)) as ID, nroParte as 'nroDocumento', 2 as 'tipoDocumento', 1 as 'tipoPeriodo', fecha, 'Parte de entrega - diario Nº: ' + ltrim(str(nroParte))  as 'Documento', isnull(monto,0) as monto ");
            strQuery.Append("from partesEntrega ");
            strQuery.Append("where ");
            strQuery.Append("periodoCobranza=1 ");
            strQuery.Append("AND estado=" + Estado);
            strQuery.Append(" AND idCliente=" + idCliente);
            strQuery.Append(" AND fecha between '" + FechaDesde + " 00:00:00' AND '" + FechaHasta + " 23:59:59' ");

            strQuery.Append("union ");

            //remitos mensuales
            strQuery.Append("select '1_2_' + ltrim(str(nroMovimiento)) as ID, nroMovimiento as 'nroDocumento', 1 as 'tipoDocumento', 2 as 'tipoPeriodo' , fecha, 'Remito - mensual Nº: ' + ltrim(str(nroMovimiento))  as 'Documento', isnull(monto,0) as monto ");
            strQuery.Append("from CtaCteRemitos ");
            strQuery.Append("where ");
            strQuery.Append("estado=" + Estado);
            strQuery.Append(" AND idCliente=" + idCliente);
            strQuery.Append(" AND fecha between '" + FechaDesde + " 00:00:00' AND '" + FechaHasta + " 23:59:59' ");

            strQuery.Append("union ");

            // partesEntrega mensuales
            strQuery.Append("select '2_2_' + ltrim(str(nroMovimiento)) as ID, nroMovimiento as 'nroDocumento', 2 as 'tipoDocumento', 2 as 'tipoPeriodo' , fecha, 'Partes de entrega - mensual Nº: ' + ltrim(str(nroMovimiento))  as 'Documento', isnull(monto,0) as monto  ");
            strQuery.Append("from CtaCtePartesEntrega ");
            strQuery.Append("where ");
            strQuery.Append("estado=" + Estado);
            strQuery.Append(" AND idCliente=" + idCliente);
            strQuery.Append(" AND fecha between '" + FechaDesde + " 00:00:00' AND '" + FechaHasta + " 23:59:59' ");


            try
            {
                dtSalida = StaticDal.EjecutarDataSet(strQuery.ToString(), "ListadoDocumentosPendientes").Tables[0];
            }
            catch
            {
                throw;
            }
            return dtSalida;
        }

    }
}
