using ar.com.TiempoyGestion.BackEnd.Clientes.Dal;

namespace ar.com.TiempoyGestion.BackEnd.Clientes.App
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

        public int ObtenerNroCajaDiaria()
        {
            CuentaCorrienteDal gp = new CuentaCorrienteDal();
            return gp.ObtenerNroCajaDiaria();
        }

        public bool AgregarMovimientoCC(int idCuentaCliente, int tipoDoc, int tipoPeriodo, float NroDoc, int entrada, string concepto, float montoDebe, float montoPagar) 
        {
            CuentaCorrienteDal gp = new CuentaCorrienteDal();
            return gp.AgregarMovimientoCC(idCuentaCliente, tipoDoc, tipoPeriodo, NroDoc, entrada, concepto, montoDebe, montoPagar);
        }

        public bool AgregarMovimientoCaja(int idCuentaCliente, int tipoDoc, int tipoPeriodo, float NroDoc, int entrada, string concepto, float montoDebe, float montoPagar)
        {
            CuentaCorrienteDal gp = new CuentaCorrienteDal();
            return gp.AgregarMovimientoCaja(idCuentaCliente, tipoDoc, tipoPeriodo, NroDoc, entrada, concepto, montoDebe, montoPagar);
        }
	}
}
