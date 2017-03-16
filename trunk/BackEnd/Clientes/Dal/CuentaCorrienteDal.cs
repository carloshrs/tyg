using System;
using System.Data;
using System.Text;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;
using System.Data.Odbc;

namespace ar.com.TiempoyGestion.BackEnd.Clientes.Dal
{
	/// <summary>
	/// Summary description for CuentaCorrienteDal.
	/// </summary>
	public class CuentaCorrienteDal  : GenericDal
	{
		public CuentaCorrienteDal()  { }

		public static bool AsentarMovimiento(int lIdCliente, int lIdEncabezado, int lIdTipoInforme, byte lTipoPrecio, float lPrecio)
		{
			StringBuilder strQuery;
			bool bolFlag = true;
			try
			{
				strQuery = new StringBuilder(512);
				strQuery.Append("Insert Into CuentaCorriente (FecMovimiento, IdCliente, IdEncabezado, IdTipoInforme, TipoPrecio, Precio) ");
				strQuery.Append(" Values (getdate(), " + StaticDal.Traduce(lIdCliente));
				strQuery.Append(", " + StaticDal.Traduce(lIdEncabezado));
				strQuery.Append(", " + StaticDal.Traduce(lIdTipoInforme));
				strQuery.Append(", " + StaticDal.Traduce(lTipoPrecio));
				strQuery.Append(", " + StaticDal.Traduce(lPrecio) + ")");

				StaticDal.EjecutarComando(strQuery.ToString());
			}
			catch
			{
				bolFlag = false;
				throw;
			}
			
			return bolFlag;
		}

		public static DataTable Listar(int lIdCliente, int lIdTipoInforme, bool lNoFacturado)
		{
			return Listar(lIdCliente, lIdTipoInforme, 0, DateTime.MinValue, DateTime.MaxValue, lNoFacturado);
			
		}

		public static DataTable Listar(int lIdCliente, int lIdTipoInforme, byte lTipoPrecio, bool lNoFacturado)
		{
			return Listar(lIdCliente, lIdTipoInforme, lTipoPrecio, DateTime.MinValue, DateTime.MaxValue, lNoFacturado);

		}

		public static DataTable Listar(DateTime lFecDesde, DateTime lFecHasta, bool lNoFacturado)
		{
			return Listar(-1, -1, 0, lFecDesde, lFecHasta, lNoFacturado);

		}

		public static DataTable Listar(int lIdCliente, int lIdTipoInforme, byte lTipoPrecio, DateTime lFecDesde, DateTime lFecHasta, bool lNoFacturado)
		{
			StringBuilder strQuery = new StringBuilder(512);
			DataTable dtSalida = null;
			strQuery.Append("Select CC.NroMovimiento, CC.FecMovimiento, CC.IdCliente, C.RazonSocial As Cliente, CC.IdTipoInforme, T.Descripcion, CC.TipoPrecio, CC.Precio, CC.Facturado, CC.IdEncabezado");
			strQuery.Append(" From CuentaCorriente CC, Clientes C, TiposInformes T ");
			strQuery.Append(" Where CC.IdCliente = C.IdCliente And CC.IdTipoInforme = T.IdTipoInforme ");
			
			if (lIdCliente != -1)
				strQuery.Append(" And CC.IdCliente = " + StaticDal.Traduce(lIdCliente));
			if (lIdTipoInforme != -1)
				strQuery.Append(" And CC.IdTipoInforme = " + StaticDal.Traduce(lIdTipoInforme));
			if (lTipoPrecio != 0)
				strQuery.Append(" And CC.TipoPrecio = " + StaticDal.Traduce(lTipoPrecio));
			if (lFecDesde != DateTime.MinValue)
				strQuery.Append(" And CC.FecMovimiento > " + StaticDal.Traduce(lFecDesde));
			if (lFecHasta != DateTime.MaxValue)
				strQuery.Append(" And CC.FecMovimiento <= " + StaticDal.Traduce(lFecHasta));
			if (lNoFacturado)
				strQuery.Append(" And CC.Facturado = 0");

			strQuery.Append(" Order By CC.FecMovimiento Desc ");

			try
			{
				dtSalida = StaticDal.EjecutarDataSet(strQuery.ToString(), "CtaCte").Tables["CtaCte"];
			}
			catch
			{
				throw;
			}
			return dtSalida;

		}

		public static float CalcularSaldo(int lIdCliente, int lIdTipoInforme)
		{
			return CalcularSaldo(lIdCliente, lIdTipoInforme, 0, DateTime.MinValue, DateTime.MaxValue);
			
		}

		public static float CalcularSaldo(int lIdCliente, int lIdTipoInforme, byte lTipoPrecio)
		{
			return CalcularSaldo(lIdCliente, lIdTipoInforme, lTipoPrecio, DateTime.MinValue, DateTime.MaxValue);

		}

		public static float CalcularSaldo(DateTime lFecDesde, DateTime lFecHasta)
		{
			return CalcularSaldo(-1, -1, 0, lFecDesde, lFecHasta);

		}

		public static float CalcularSaldo(int lIdCliente, int lIdTipoInforme, byte lTipoPrecio, DateTime lFecDesde, DateTime lFecHasta)
		{
			StringBuilder strQuery = new StringBuilder(512);
			IDataReader drSaldo = null;
			float flSalida = 0;
			strQuery.Append("Select Sum(CC.Precio * ((CC.Facturado - 1) * -1)) ");
			strQuery.Append(" From CuentaCorriente CC, Clientes C, TiposInformes T ");
			strQuery.Append(" Where CC.IdCliente = C.IdCliente And CC.IdTipoInforme = T.IdTipoInforme ");

			if (lIdCliente != -1)
				strQuery.Append(" And CC.IdCliente = " + StaticDal.Traduce(lIdCliente));
			if (lIdTipoInforme != -1)
				strQuery.Append(" And CC.IdTipoInforme = " + StaticDal.Traduce(lIdTipoInforme));
			if (lTipoPrecio != 0)
				strQuery.Append(" And CC.TipoPrecio = " + StaticDal.Traduce(lTipoPrecio));
			if (lFecDesde != DateTime.MinValue)
				strQuery.Append(" And CC.FecMovimiento > " + StaticDal.Traduce(lFecDesde));
			if (lFecHasta != DateTime.MaxValue)
				strQuery.Append(" And CC.FecMovimiento <= " + StaticDal.Traduce(lFecHasta));

			try
			{
				drSaldo = StaticDal.EjecutarDataReader(strQuery.ToString());
				if (drSaldo.Read() && !drSaldo.IsDBNull(0))
					flSalida = (float) drSaldo.GetDouble(0);
				else
					flSalida = 0;
			}
			catch
			{
				throw;
			}
			return flSalida;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        

		}


        public int ObtenerNroClienteCC(int lIdCliente)
        {
            //int MaxID = 0;
            string strSQL = "";
            int idCuentaCliente = 0;

            OdbcConnection oConnection = this.OpenConnection();

            strSQL = "SELECT idCuentaCliente FROM CPCuentaCliente " +
            " WHERE idCliente = " + lIdCliente;

            try
            {
                //OdbcCommand myCommand = new OdbcCommand(strSQL, oConnection);
                //myCommand.ExecuteNonQuery();

                OdbcDataAdapter myConsulta = new OdbcDataAdapter(strSQL, oConnection);
                DataSet myDataSet = new DataSet();
                myConsulta.Fill(myDataSet);


                idCuentaCliente = int.Parse(myDataSet.Tables[0].Rows[0]["idCuentaCliente"].ToString());

            }
            catch (Exception e)
            {
                string p = e.Message;
                return 0;
            }
            return idCuentaCliente;
        }


        public void ValClienteCC(int lIdCliente)
        {
            //int MaxID = 0;
            string strSQL = "";
            float fSaldo = 0; 

            OdbcConnection oConnection = this.OpenConnection();

            strSQL = "CCsetCrearCuentaCliente " + lIdCliente;
            

            try
            {
                OdbcCommand myCommand = new OdbcCommand(strSQL, oConnection);
                myCommand.ExecuteNonQuery();

                //OdbcDataAdapter myConsulta = new OdbcDataAdapter(strSQL, oConnection);
                //DataSet myDataSet = new DataSet();
                //myConsulta.Fill(myDataSet);
                //fSaldo = float.Parse(myDataSet.Tables[0].Rows[0]["saldoActual"].ToString());

            }
            catch (Exception e)
            {
                string p = e.Message;
                //return false;
            }
            //return true;
        }


        public float ObtenerSaldoClienteCC(int lIdCuentaCliente)
        {
            //int MaxID = 0;
            string strSQL = "";
            float fSaldo = 0;

            OdbcConnection oConnection = this.OpenConnection();

            strSQL = "SELECT top 1 isnull(saldo,0) as saldo FROM CPCuentaClienteDetalle " +
            " WHERE idCuentaCliente = " + lIdCuentaCliente +
            " ORDER BY idCuentaClienteDetalle DESC";


            try
            {
                //OdbcCommand myCommand = new OdbcCommand(strSQL, oConnection);
                //myCommand.ExecuteNonQuery();

                OdbcDataAdapter myConsulta = new OdbcDataAdapter(strSQL, oConnection);
                DataSet myDataSet = new DataSet();
                myConsulta.Fill(myDataSet);
                fSaldo = float.Parse(myDataSet.Tables[0].Rows[0]["saldo"].ToString());

            }
            catch (Exception e)
            {
                string p = e.Message;
                return -1;
            }

            return fSaldo;
        }


        public float ObtenerSaldoInformesCliente(int lIdCliente)
        {
            //int MaxID = 0;
            string strSQL = "";
            float fSaldo = 0;

            OdbcConnection oConnection = this.OpenConnection();

            strSQL = "WITH CTE " +
                "AS " +
                "( " +
                "SELECT isnull(monto,0) as saldo  " +
                "FROM remitos  " +
                "WHERE idCliente=" + lIdCliente + 
                " and estado=1 and periodoCobranza=1 " +
                "union  " +
                "SELECT isnull(monto,0) as saldo  " +
                "FROM partesEntrega  " +
                "WHERE idCliente=" + lIdCliente + 
                " and estado=1 and periodoCobranza=1 " +
                "union " +
                "SELECT sum(monto) as saldo  " +
                "FROM CtaCteRemitos  " +
                " WHERE idCliente=" + lIdCliente + 
                " and estado=1 " +
                "union " +
                "SELECT isnull(monto,0) as saldo  " +
                "FROM CtaCtePartesEntrega  " +
                "WHERE idCliente=" + lIdCliente + 
                " and estado=1 " +
                ") " +
                "SELECT SUM(saldo) as saldo " +
                "FROM CTE";
            try
            {
                //OdbcCommand myCommand = new OdbcCommand(strSQL, oConnection);
                //myCommand.ExecuteNonQuery();

                OdbcDataAdapter myConsulta = new OdbcDataAdapter(strSQL, oConnection);
                DataSet myDataSet = new DataSet();
                myConsulta.Fill(myDataSet);
                fSaldo = float.Parse(myDataSet.Tables[0].Rows[0]["saldo"].ToString());

            }
            catch (Exception e)
            {
                string p = e.Message;
                return -1;
            }

            return fSaldo;
        }

        public int ObtenerNroCajaDiaria()
        {
            //int MaxID = 0;
            string strSQL = "";
            int idcaja = 0;

            OdbcConnection oConnection = this.OpenConnection();

            strSQL = "SELECT TOP 1 idcaja FROM CPCaja " +
             "WHERE cierre IS NULL "+
			 //"AND apertura BETWEEN CONVERT(VARCHAR(10), GETDATE(), 103) + ' 00:00:00' AND CONVERT(VARCHAR(10), GETDATE(), 103) + ' 23:59:59' " +
             "ORDER BY idCaja DESC";
 

            try
            {
                //OdbcCommand myCommand = new OdbcCommand(strSQL, oConnection);
                //myCommand.ExecuteNonQuery();

                OdbcDataAdapter myConsulta = new OdbcDataAdapter(strSQL, oConnection);
                DataSet myDataSet = new DataSet();
                myConsulta.Fill(myDataSet);


                idcaja = int.Parse(myDataSet.Tables[0].Rows[0]["idcaja"].ToString());

            }
            catch (Exception e)
            {
                string p = e.Message;
                return 0;
            }
            return idcaja;
        }


        public int AgregarMovimientoCC(int idCuentaCliente, int entrada, string concepto, float montoDebe, float montoPagar)
        {
            //int MaxID = 0;
            string strSQL = "";
            int idCuentaClienteDetalle = 0;
            

            OdbcConnection oConnection = this.OpenConnection();

            strSQL = "CCAddMovimientoCC " + idCuentaCliente + ", '" + concepto + "', " + montoDebe + ", " + montoPagar + ", " + entrada + ", 0";

            try
            {
                //OdbcCommand myCommand = new OdbcCommand(strSQL, oConnection);
                //myCommand.ExecuteNonQuery();

                OdbcDataAdapter myConsulta = new OdbcDataAdapter(strSQL, oConnection);
                DataSet myDataSet = new DataSet();
                myConsulta.Fill(myDataSet);
                idCuentaClienteDetalle = int.Parse(myDataSet.Tables[0].Rows[0]["idCuentaClienteDetalle"].ToString());

            }
            catch (Exception e)
               {
                string p = e.Message;
                return idCuentaClienteDetalle;
            }

            return idCuentaClienteDetalle;
        }


        public int AgregarMovimientoCaja(int idCajaDiaria, int entrada, string concepto, float montoDebe, float montoPagar, string observaciones)
        {
            //int MaxID = 0;
            string strSQL = "";
            int idCajaDetalle = 0;


            OdbcConnection oConnection = this.OpenConnection();

            strSQL = "CCAddMovimientoCaja " + idCajaDiaria + ", '" + concepto + "', " + montoDebe + ", " + montoPagar + ", " + entrada + ", '" + observaciones + "', 0";

            try
            {
                //OdbcCommand myCommand = new OdbcCommand(strSQL, oConnection);
                //myCommand.ExecuteNonQuery();

                OdbcDataAdapter myConsulta = new OdbcDataAdapter(strSQL, oConnection);
                DataSet myDataSet = new DataSet();
                myConsulta.Fill(myDataSet);
                idCajaDetalle = int.Parse(myDataSet.Tables[0].Rows[0]["idCajaDetalle"].ToString());

            }
            catch (Exception e)
            {
                string p = e.Message;
                return idCajaDetalle;
            }

            return idCajaDetalle;
        }


        public bool AgregarDocumentosMovimientoCC(int idCuentaCliente, int tipoDoc, int tipoPeriodo, float NroDoc, int entrada, string concepto, float montoDebe, float montoPagar)
        {
            //int MaxID = 0;
            string strSQL = "";
            


            OdbcConnection oConnection = this.OpenConnection();

            strSQL = "CCAddDocumentosMovimientoCC " + idCuentaCliente + ", " + tipoDoc + ", " + tipoPeriodo + ", " + NroDoc + ", '" + concepto + "', " + montoDebe + ", " + montoPagar + ", " + entrada;

            try
            {
                //OdbcCommand myCommand = new OdbcCommand(strSQL, oConnection);
                //myCommand.ExecuteNonQuery();

                OdbcDataAdapter myConsulta = new OdbcDataAdapter(strSQL, oConnection);
                DataSet myDataSet = new DataSet();
                myConsulta.Fill(myDataSet);
                //fSaldo = float.Parse(myDataSet.Tables[0].Rows[0]["saldo"].ToString());

            }
            catch (Exception e)
            {
                string p = e.Message;
                return false;
            }

            return true;
        }


        public bool AgregarDocumentosMovimientoCaja(int idCuentaCliente, int tipoDoc, int tipoPeriodo, float NroDoc, int entrada, string concepto, float montoDebe, float montoPagar)
        {
            //int MaxID = 0;
            string strSQL = "";
            float fSaldo = 0;


            OdbcConnection oConnection = this.OpenConnection();

            strSQL = "CCAddDocumentosMovimientoCaja " + idCuentaCliente + ", " + tipoDoc + ", " + tipoPeriodo + ", " + NroDoc + ", '" + concepto + "', " + montoDebe + ", " + montoPagar + ", " + entrada;

            try
            {
                //OdbcCommand myCommand = new OdbcCommand(strSQL, oConnection);
                //myCommand.ExecuteNonQuery();

                OdbcDataAdapter myConsulta = new OdbcDataAdapter(strSQL, oConnection);
                DataSet myDataSet = new DataSet();
                myConsulta.Fill(myDataSet);
                //fSaldo = float.Parse(myDataSet.Tables[0].Rows[0]["saldo"].ToString());

            }
            catch (Exception e)
            {
                string p = e.Message;
                return false;
            }

            return true;
        }

        public void AgregarFormaPago(int idCajaDetalle, int idFormaPago, float MontoaPagar, int entradasalida)
        {
            //int MaxID = 0;
            string strSQL = "";
            float fSaldo = 0;


            OdbcConnection oConnection = this.OpenConnection();

            strSQL = "CCAddFormaPago " + idCajaDetalle + ", " + idFormaPago + ", " + MontoaPagar + ", " + entradasalida;

            try
            {
                //OdbcCommand myCommand = new OdbcCommand(strSQL, oConnection);
                //myCommand.ExecuteNonQuery();

                OdbcDataAdapter myConsulta = new OdbcDataAdapter(strSQL, oConnection);
                DataSet myDataSet = new DataSet();
                myConsulta.Fill(myDataSet);
                //fSaldo = float.Parse(myDataSet.Tables[0].Rows[0]["saldo"].ToString());

            }
            catch (Exception e)
            {
                string p = e.Message;
                //return false;
            }

            //return true;
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
	}
}
