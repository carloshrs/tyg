using ar.com.TiempoyGestion.BackEnd.Cobranzas.Dal;

namespace ar.com.TiempoyGestion.BackEnd.Cobranzas.App
{
	/// <summary>
	/// Summary description for CuentaCorrienteApp.
	/// </summary>
	public class CuentaCorrienteApp
	{
		public CuentaCorrienteApp()  {  }

		public static bool AsentarMovimiento(int lIdCliente, int lIdEncabezado, int lIdTipoInforme)
		{
			return AsentarMovimiento(lIdCliente, lIdEncabezado, lIdTipoInforme, 3);

		}

		public static bool AsentarMovimiento(int lIdCliente, int lIdEncabezado, int lIdTipoInforme, byte lTipoPrecio)
		{
			float flPrecio = GestorPrecios.TraerPrecioActual(lIdTipoInforme, lTipoPrecio);
			return CuentaCorrienteDal.AsentarMovimiento(lIdCliente, lIdEncabezado, lIdTipoInforme, lTipoPrecio, flPrecio);

		}

        public void ValClienteCC(int lIdCliente)
        {
            CuentaCorrienteDal gp = new CuentaCorrienteDal();
            gp.ValClienteCC(lIdCliente);
        }

        public int ObtenerNroClienteCC(int lIdCliente)
        {
            CuentaCorrienteDal gp = new CuentaCorrienteDal();
            return gp.ObtenerNroClienteCC(lIdCliente);
        }

        public float ObtenerSaldoClienteCC(int lIdCuentaCliente)
        {
            CuentaCorrienteDal gp = new CuentaCorrienteDal();
            return gp.ObtenerSaldoClienteCC(lIdCuentaCliente);
        }

        public float ObtenerSaldoInformesCliente(int lIdCliente)
        {
            CuentaCorrienteDal gp = new CuentaCorrienteDal();
            return gp.ObtenerSaldoInformesCliente(lIdCliente);
        }

        public int ObtenerNroCajaDiaria()
        {
            CuentaCorrienteDal gp = new CuentaCorrienteDal();
            return gp.ObtenerNroCajaDiaria();
        }

        public int AgregarMovimientoCC(int idCuentaCliente, int entrada, string concepto, float montoDebe, float montoPagar) 
        {
            CuentaCorrienteDal gp = new CuentaCorrienteDal();
            return gp.AgregarMovimientoCC(idCuentaCliente, entrada, concepto, montoDebe, montoPagar);
        }

        public int AgregarMovimientoCaja(int idCajaDiaria, int entrada, string concepto, float montoDebe, float montoPagar, string observaciones)
        {
            CuentaCorrienteDal gp = new CuentaCorrienteDal();
            return gp.AgregarMovimientoCaja(idCajaDiaria, entrada, concepto, montoDebe, montoPagar, observaciones);
        }

        public bool AgregarDocumentosMovimientoCC(int idCuentaCliente, int tipoDoc, int tipoPeriodo, float NroDoc, int entrada, string concepto, float montoDebe, float montoPagar)
        {
            CuentaCorrienteDal gp = new CuentaCorrienteDal();
            return gp.AgregarDocumentosMovimientoCC(idCuentaCliente, tipoDoc, tipoPeriodo, NroDoc, entrada, concepto, montoDebe, montoPagar);
        }

        public bool AgregarDocumentosMovimientoCaja(int idCuentaCliente, int tipoDoc, int tipoPeriodo, float NroDoc, int entrada, string concepto, float montoDebe, float montoPagar)
        {
            CuentaCorrienteDal gp = new CuentaCorrienteDal();
            return gp.AgregarDocumentosMovimientoCaja(idCuentaCliente, tipoDoc, tipoPeriodo, NroDoc, entrada, concepto, montoDebe, montoPagar);
        }

        public int AgregarFormaPago(int idCajaDetalle, int idFormaPago, float MontoaPagar, int entradasalida)
        {
            CuentaCorrienteDal gp = new CuentaCorrienteDal();
            return gp.AgregarFormaPago(idCajaDetalle, idFormaPago, MontoaPagar, entradasalida);
        }

        public void AgregarChequeCartera(int idCajaDetalleFormaPago, float MontoaPagar, string vBanco, string vNroCheque, string vFechaEmision, string vFechaCobro)
        {
            CuentaCorrienteDal gp = new CuentaCorrienteDal();
            gp.AgregarChequeCartera(idCajaDetalleFormaPago, MontoaPagar, vBanco, vNroCheque, vFechaEmision, vFechaCobro);
        }
        
        
	}
}
