using System;
using System.Collections;
using System.Security.Principal;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.Dal;

namespace ar.com.TiempoyGestion.BackEnd.ControlAcceso.App
{
	/// <summary>
	/// Summary description for UsuarioAutenticado.
	/// </summary>
	public class UsuarioAutenticado : IPrincipal
	{
		private IIdentity oIdentity;
		private string[] vRoles;
		
		private int intIdUsuario;
		private int intIdCliente;
		private string strNombreUsuario;
		private string strRazonSocial;
		private string strEmailUsuario;
        private DateTime dtUltimoIngreso;
		private Usuario oDatosUsuario;
		private Hashtable htTickets;
		private int intVencimientoTicket;
        private int intTipoPeriodo;

		public UsuarioAutenticado(IIdentity lIdentity, Usuario lUsuario, int lVencTicket)
		{
			oIdentity = lIdentity;
			vRoles = lUsuario.RolesString.Split("|".ToCharArray());
			Array.Sort(vRoles);

			
			intIdUsuario = lUsuario.Id;
			intIdCliente = lUsuario.IdCliente;
			strNombreUsuario = lUsuario.Nombre + " " + lUsuario.Apellido;
			strRazonSocial = lUsuario.Cliente;
			strEmailUsuario = lUsuario.Email;
            dtUltimoIngreso = lUsuario.UltimoIngreso;
			oDatosUsuario = lUsuario;
			htTickets = new Hashtable();
			intVencimientoTicket = lVencTicket;
            intTipoPeriodo = lUsuario.TipoPeriodo;
		}

		public int IdUsuario
		{
			get { return intIdUsuario; }
		}

		public int IdCliente
		{
			get { return intIdCliente; }
		}

		public string NombreUsuario
		{
			get { return strNombreUsuario; }
		}

		public string RazonSocial
		{
			get { return strRazonSocial; }
		}

		public string EmailUsuario
		{
			get { return strEmailUsuario; }
		}

        public DateTime UltimoIngreso
        {
            get { return dtUltimoIngreso; }
        }
        
        public int TipoPeriodo {
            get { return intTipoPeriodo; }
        }

		public Hashtable Roles
		{
			get { return oDatosUsuario.Roles; }
		}
		
		public IIdentity Identity
		{
			get
			{
				return oIdentity;
			}
		}

		public bool CheckAccess(string lUrlKey)
		{
			bool bolSalida = false;
			TicketAcceso tk;
			if (htTickets.Contains(lUrlKey))
			{
				tk = (TicketAcceso) htTickets[lUrlKey];
				if (tk.Activo)
				{
					bolSalida = true;
					if (tk.PorExpirar)
						tk.AddTime(intVencimientoTicket * 2);
				}
				else
				{
					htTickets.Remove(lUrlKey);
					tk = BuscarTicket(lUrlKey);
					if (tk != null)
					{
						bolSalida = true;
						htTickets.Add(lUrlKey, tk);
					}
				}
			}
			else
			{
				tk = BuscarTicket(lUrlKey);
				if (tk != null)
				{
					bolSalida = true;
					htTickets.Add(lUrlKey, tk);
				}
			}

			return bolSalida;
		}

		private TicketAcceso BuscarTicket(string lUrlKey)
		{
			Funcion oFuncion = new Funcion();
			bool bolExists = false;
			oFuncion.Cargar(lUrlKey);

			foreach (Rol itemRol in oDatosUsuario.Roles.Values)
			{
				if (oFuncion.Roles.Contains(itemRol.Id))
				{
					bolExists = true;
					break;
				}
			}

			TicketAcceso tkSalida = null;
			if (bolExists)
				tkSalida = new TicketAcceso(oFuncion.Id, oFuncion.Nombre, intVencimientoTicket);

			return tkSalida;

		}

		public bool IsInRole(string role)
		{
			bool bolFlag = false;
			if (Array.BinarySearch(vRoles, role) >= 0)
				bolFlag = true;

			return bolFlag;

		}

		public bool IsInAllRoles(params string [] roles)
		{
			bool bolFlag = true;
			
			for(int i= 0; i < roles.Length && bolFlag; i++)
			{
				if (Array.BinarySearch(vRoles, roles[i]) < 0)
					bolFlag = false;
			}
		
			return bolFlag;
		}

		public bool IsInAnyRoles(params string [] roles)
		{
			bool bolFlag = false;
			
			for(int i= 0; i < roles.Length && !bolFlag; i++)
			{
				if (Array.BinarySearch(vRoles, roles[i]) >= 0)
					bolFlag = true;
			}
		
			return bolFlag;
		}

	}
}