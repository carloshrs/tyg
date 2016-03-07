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

        public bool ValClienteCC(int lIdCliente)
        {
            CuentaCorrienteDal gp = new CuentaCorrienteDal();
            return gp.ValClienteCC(lIdCliente); ;
        }


        public float ObtenerSaldoClienteCC(int lIdCliente)
        {
            CuentaCorrienteDal gp = new CuentaCorrienteDal();
            return gp.ObtenerSaldoClienteCC(lIdCliente); ;
        }
	}
}
