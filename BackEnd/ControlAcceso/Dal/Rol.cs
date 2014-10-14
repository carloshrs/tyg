using System;
using System.Collections;
using System.Data;
using System.Text;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;

namespace ar.com.TiempoyGestion.BackEnd.ControlAcceso.Dal
{
	/// <summary>
	/// Summary description for Rol.
	/// </summary>
	public class Rol : GenericDal
	{
		#region Atributos y Contructores

		private int intIdRol;
		private string strNombre;
		private string strDescripcion;
		private bool bolAutomatico;
		private bool bolExtranet;
		private Hashtable htFunciones;

		public Rol() : base()
		{
			intIdRol = -1;
			strNombre = "";
			strDescripcion = "";
			bolAutomatico = false;
			bolExtranet = false;
		}

		public Rol(int lIdRol, string lNombre, string lDescripcion, bool lAutomatico, bool lExtranet) : base()
		{
			intIdRol = lIdRol;
			strNombre = lNombre;
			strDescripcion = lDescripcion;
			bolAutomatico = lAutomatico;
			bolExtranet = lExtranet;

		}

		#endregion

		#region Propiedades

		public int Id
		{
			get { return intIdRol; }
		}

		public string Nombre
		{
			get { return strNombre; }
			set { strNombre = value; }
		}

		public string Descripcion
		{
			get { return strDescripcion; }
			set { strDescripcion = value; }
		}

		public bool Automatico
		{
			get { return bolAutomatico; }
			set { bolAutomatico = value; }
		}

		public bool Extranet
		{
			get { return bolExtranet; }
			set { bolExtranet = value; }
		}

		public Hashtable Funciones
		{
			get
			{
				if (htFunciones == null)
				{
					if (intIdRol != -1)
						htFunciones = pBuscarFunciones();
					else
						htFunciones = new Hashtable();
				}
				return htFunciones;
			}

		}

		#endregion

		#region Métodos Publicos

		public void Cargar(int lId)
		{
			if (lId != 0)
			{
				StringBuilder strSqlGet = new StringBuilder(512);
				strSqlGet.Append("Select Nombre, Descripcion, Automatico, Extranet ");
				strSqlGet.Append(" From Roles ");
				strSqlGet.Append(" Where IdRol = " + Traduce(lId));
				try
				{
					IDataReader drRol = EjecutarDataReader(strSqlGet.ToString());
					if (drRol.Read())
					{
						intIdRol = lId;
						strNombre = drRol.GetString(0);
						if (!drRol.IsDBNull(1))
							strDescripcion = drRol.GetString(1);
						bolAutomatico = Convert.ToBoolean(drRol.GetByte(2));
						bolExtranet = Convert.ToBoolean(drRol.GetByte(3));
					}
					drRol.Close();
				}
				catch
				{
					throw;
				}

			}
		}

		public int Crear()
		{
			int intSalida = -1;
			if (strNombre != "")
			{
				StringBuilder strSqlInsert = new StringBuilder(512);
				strSqlInsert.Append("Insert Into Roles ");
				strSqlInsert.Append(" (Nombre, Descripcion, Automatico, Extranet) ");
				strSqlInsert.Append(" Values ");
				strSqlInsert.Append(" (" + Traduce(strNombre) + ", ");
				strSqlInsert.Append(" " + Traduce(strDescripcion) + ", ");
				strSqlInsert.Append(" " + Traduce(bolAutomatico) + ",");
				strSqlInsert.Append(" " + Traduce(bolExtranet) + ")");

				try
				{
					if (EjecutarComando(strSqlInsert.ToString()) == 1)
					{
						IDataReader drIdCreado = EjecutarDataReader("Select Max(IdRol) From Roles");
						if (drIdCreado.Read() && !drIdCreado.IsDBNull(0))
						{
							intSalida = (int) drIdCreado.GetInt64(0);
							intIdRol = intSalida;
						}
						drIdCreado.Close();
					}

				}
				catch
				{
					throw;
				}
			}
			else
				intSalida = -1;
			return intSalida;

		}

		public bool Modificar()
		{
			bool bolSalida = true;
			if (intIdRol != -1 && strNombre != "")
			{
				StringBuilder strSqlUpdate = new StringBuilder(512);
				strSqlUpdate.Append("Update Roles ");
				strSqlUpdate.Append(" Set Nombre = " + Traduce(strNombre));
				strSqlUpdate.Append(", Descripcion = " + Traduce(strDescripcion));
				strSqlUpdate.Append(", Automatico = " + Traduce(bolAutomatico));
				strSqlUpdate.Append(", Extranet = " + Traduce(bolExtranet));
				strSqlUpdate.Append(" Where IdRol = " + Traduce(intIdRol));
				try
				{
					if (EjecutarComando(strSqlUpdate.ToString()) != 1)
						bolSalida = false;
					else
					{
						try
						{
							if (this.Funciones.Count > 0)
							{
								EjecutarComando("Delete From FuncionesRoles Where IdRol = " + Traduce(intIdRol));
								foreach (Funcion itemFuncion in htFunciones.Values)
									EjecutarComando("Insert Into FuncionesRoles(IdFuncion, IdRol) Values(" + Traduce(itemFuncion.Id) + ", " + Traduce(intIdRol) + ")");
							}
						}
						catch
						{}

					}
				}
				catch
				{
					bolSalida = false;
					throw;
				}
			}

			return bolSalida;
		}

		public void Eliminar(int lId)
		{
			if (lId != 0)
			{
				StringBuilder strSqlUpdate = new StringBuilder(128);
				strSqlUpdate.Append("Delete From Roles ");
				strSqlUpdate.Append(" Where IdRol = " + Traduce(lId));
				try
				{
					EjecutarComando(strSqlUpdate.ToString());
				}
				catch
				{
					throw;
				}
			}
		}

		public DataTable Listar(string lTexto)
		{
			return pListar(lTexto, false, -1, -1, false);

		}

		public DataTable Listar(bool lAutomatico)
		{
			return pListar("", lAutomatico, -1, -1, false);

		}

		public DataTable Listar (string lTexto, bool lAutomatico, bool lExtranet)
		{
			return pListar(lTexto, lAutomatico, -1, -1, lExtranet);

		}

		public Hashtable ListarRolesUsuario(int lId)
		{
			return pListarRoles(lId, true);

		}

		public Hashtable ListarRolesFuncion(int lId)
		{
			return pListarRoles(lId, false);

		}
		#endregion

		#region Métodos Privados

		private DataTable pListar(string lTexto, bool lAuto, int lIdUsuario, int lIdFuncion, bool lExtranet)
		{
			StringBuilder strQuery = new StringBuilder(512);
			DataTable dtSalida = null;
			if (lIdUsuario != -1 || lIdFuncion != -1)
			{
				strQuery.Append("Select Re.IdRol, Ro.Nombre, Ro.Descripcion, Ro.Automatico, Ro.Extranet");
				if (lIdUsuario != -1)
				{
					strQuery.Append(" From Roles Ro, UsuariosRoles Re");
					strQuery.Append(" Where Re.IdRol = Ro.IdRol And Re.IdUsuario = " + Traduce(lIdUsuario));
				}
				else
				{
					strQuery.Append(" From Roles Ro, FuncionesRoles Re");
					strQuery.Append(" Where Re.IdRol = Ro.IdRol And Re.IdFuncion = " + Traduce(lIdFuncion));
				}
			}
			else
			{
				bool bolFlagWhere = false;
				strQuery.Append("Select IdRol, Nombre, Descripcion, Automatico, Extranet ");
				strQuery.Append(" From Roles ");
				if (lTexto != "")
				{
					if (lTexto[0] != '(')
						strQuery.Append(" Where Nombre Like " + Traduce(lTexto + "%") + " Or Descripcion Like " + Traduce(lTexto + "%"));
					else
						strQuery.Append(" Where IdRol Not In " + lTexto);
					bolFlagWhere = true;

				}
				if (lAuto)
				{
					if (bolFlagWhere)
						strQuery.Append(" And ");
					else
					{
						strQuery.Append(" Where ");
						bolFlagWhere = true;
					}
					strQuery.Append(" Automatico = 1");
				}
				if (lExtranet)
				{
					if (bolFlagWhere)
						strQuery.Append(" And ");
					else
						strQuery.Append(" Where ");
					strQuery.Append(" Automatico = 1");
				}
				strQuery.Append(" Order by Nombre");
			}

			try
			{
				dtSalida = EjecutarDataSet(strQuery.ToString(), "Roles").Tables["Roles"];
			}
			catch
			{
				throw;
			}
			return dtSalida;

		}

		private Hashtable pListarRoles(int lId, bool lUsuario)
		{
			DataTable dtListado;
			Hashtable htSalida = new Hashtable();
			Rol oRolAux = null;
			if (lUsuario)
				dtListado = pListar("", false, lId, -1, false);
			else
				dtListado = pListar("", false, -1, lId, false);

			foreach (DataRow drRol in dtListado.Rows)
			{
				if (!drRol.IsNull("Descripcion"))
					oRolAux = new Rol(Convert.ToInt32(drRol["IdRol"]), Convert.ToString(drRol["Nombre"]), Convert.ToString(drRol["Descripcion"]), Convert.ToBoolean(drRol["Automatico"]), Convert.ToBoolean(drRol["Extranet"]));
				else
					oRolAux = new Rol(Convert.ToInt32(drRol["IdRol"]), Convert.ToString(drRol["Nombre"]), "", Convert.ToBoolean(drRol["Automatico"]), Convert.ToBoolean(drRol["Extranet"]));
				htSalida.Add(oRolAux.Id, oRolAux);
			}

			return htSalida;
		}

		private Hashtable pBuscarFunciones()
		{
			DataTable dtFunciones;
			Hashtable htResFunciones = new Hashtable();
			Funcion auxFuncion = null;

			dtFunciones = EjecutarDataSet("Select F.IdFuncion, F.Nombre, F.UrlKey From Funciones F, FuncionesRoles FR Where F.IdFuncion = FR.IdFuncion And FR.IdRol = " + Traduce(intIdRol), "Funciones").Tables[0];

			foreach (DataRow drFuncion in dtFunciones.Rows)
			{
				auxFuncion = new Funcion(Convert.ToInt32(drFuncion["IdFuncion"]), Convert.ToString(drFuncion["Nombre"]), Convert.ToString(drFuncion["UrlKey"]));
				htResFunciones.Add(auxFuncion.Id, auxFuncion);
			}

			return htResFunciones;

		}

		#endregion
	}
}