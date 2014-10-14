using System;
using System.Data;
using System.Text;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;

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

	}
}
