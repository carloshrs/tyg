using ar.com.TiempoyGestion.BackEnd.Facturacion.Dal;

namespace ar.com.TiempoyGestion.BackEnd.Facturacion.App
{
    /// <summary>
    /// Summary description for CuentaCorrienteApp.
    /// </summary>
    public class FacturacionApp
    {
        public FacturacionApp() { }

        public static bool AsentarMovimiento(int lIdCliente, int lIdEncabezado, int lIdTipoInforme)
        {
            return AsentarMovimiento(lIdCliente, lIdEncabezado, lIdTipoInforme, 3);

        }

        public static bool AsentarMovimiento(int lIdCliente, int lIdEncabezado, int lIdTipoInforme, byte lTipoPrecio)
        {
            //float flPrecio = GestorPrecios.TraerPrecioActual(lIdTipoInforme, lTipoPrecio);
            return true;// CuentaCorrienteDal.AsentarMovimiento(lIdCliente, lIdEncabezado, lIdTipoInforme, lTipoPrecio, flPrecio);

        }

        public bool ValClienteCC(int lIdCliente)
        {
            //CuentaCorrienteDal gp = new CuentaCorrienteDal();
            return true; // gp.ValClienteCC(lIdCliente); ;
        }


        public float ObtenerSaldoClienteCC(int lIdCliente)
        {
            //CuentaCorrienteDal gp = new CuentaCorrienteDal();
            return 0; // gp.ObtenerSaldoClienteCC(lIdCliente); ;
        }
    }
}
