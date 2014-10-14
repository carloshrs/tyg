using System;

namespace ar.com.TiempoyGestion.BackEnd.ControlAcceso.App
{
	/// <summary>
	/// Summary description for TicketAcceso.
	/// </summary>
	public class TicketAcceso
	{
		#region Atributos y Constructores

		private int intIdFuncion;
		private string strNombre;
		private DateTime dtExpiracion;

		public TicketAcceso(int lIdFuncion, string lNombre, int lMins)
		{
			intIdFuncion = lIdFuncion;
			strNombre = lNombre;
			dtExpiracion = DateTime.Now.AddMinutes(lMins);

		}

		#endregion

		#region Propiedades

		public bool Activo
		{
			get
			{
				bool bolSalida = true;
				if (DateTime.Now > dtExpiracion)
					bolSalida = false;
				return bolSalida;
			}
		}

		public bool PorExpirar
		{
			get
			{
				bool bolSalida = false;
				if (DateTime.Now > dtExpiracion)
				{
					TimeSpan tsPorExpirar = DateTime.Now - dtExpiracion;
					if (tsPorExpirar.Minutes <= 1)
						bolSalida = true;
				}
				return bolSalida;
			}
		}

		#endregion

		#region Métodos Públicos

		public void AddTime(int lMinutes)
		{
			dtExpiracion.AddMinutes(lMinutes);

		}

		#endregion
	}
}