using System.Collections;
using System.Data;
using System.Text;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;
using System;

namespace ar.com.TiempoyGestion.BackEnd.ControlAcceso.Dal
{
	/// <summary>
	/// Summary description for Funcion.
	/// </summary>
	public class Funcion : GenericDal
	{
		#region Atributos y Contructores

		private int intIdFuncion;
		private string strNombre;
		private string strUrlKey;
		private Hashtable htRoles;

		public Funcion() : base()
		{
			intIdFuncion = -1;
			strNombre = "";
			strUrlKey = "";
		}

		public Funcion(int lId, string lNombre, string lUrlKey) : base()
		{
			intIdFuncion = lId;
			strNombre = lNombre;
			strUrlKey = lUrlKey;

		}

		#endregion

		#region Propiedades

		public int Id
		{
			get { return intIdFuncion; }
		}

		public string Nombre
		{
			get { return strNombre; }
			set { strNombre = value; }
		}

		public string UrlKey
		{
			get { return strUrlKey; }
			set { strUrlKey = value; }
		}

		public Hashtable Roles
		{
			get
			{
				if (htRoles == null)
				{
					if (intIdFuncion != -1)
						htRoles = pBuscarRoles();
					else
						htRoles = new Hashtable();
				}
				return htRoles;
			}
		}

		#endregion

		#region Métodos Publicos

		public void Cargar(int lId)
		{
			pCargar(lId, "");

		}

		public void Cargar(string lUrl)
		{
			pCargar(-1, lUrl);

		}

		public int Crear()
		{
			int intSalida = -1;
			if (strNombre != "" && strUrlKey != "")
			{
				StringBuilder strSqlInsert = new StringBuilder(512);
				strSqlInsert.Append("Insert Into Funciones ");
				strSqlInsert.Append(" (Nombre, UrlKey) ");
				strSqlInsert.Append(" Values ");
				strSqlInsert.Append(" (" + Traduce(strNombre) + ", ");
				strSqlInsert.Append(" " + Traduce(strUrlKey) + ") ");

				try
				{
					if (EjecutarComando(strSqlInsert.ToString()) == 1)
					{
						IDataReader drIdCreado = EjecutarDataReader("Select Max(IdFuncion) From Funciones");
						if (drIdCreado.Read() && !drIdCreado.IsDBNull(0))
						{
							intSalida = (int) drIdCreado.GetInt64(0);
							intIdFuncion = intSalida;
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
			if (intIdFuncion != -1 && strNombre != "" && strUrlKey != "")
			{
				StringBuilder strSqlUpdate = new StringBuilder(512);
				strSqlUpdate.Append("Update Funciones ");
				strSqlUpdate.Append(" Set Nombre = " + Traduce(strNombre));
				strSqlUpdate.Append(", UrlKey = " + Traduce(strUrlKey));
				strSqlUpdate.Append(" Where IdFuncion = " + Traduce(intIdFuncion));
				try
				{
					if (EjecutarComando(strSqlUpdate.ToString()) != 1)
						bolSalida = false;
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
			StringBuilder strSqlUpdate = new StringBuilder(128);
			strSqlUpdate.Append("Delete From Funciones ");
			strSqlUpdate.Append(" Where IdFuncion = " + Traduce(lId));
			try
			{
				EjecutarComando(strSqlUpdate.ToString());
			}
			catch
			{
				throw;
			}
		}

		public DataTable Listar(string lTexto)
		{
			StringBuilder strQuery = new StringBuilder(512);
			DataTable dtSalida = null;
			strQuery.Append("Select IdFuncion, Nombre, UrlKey ");
			strQuery.Append(" From Funciones ");
			if (lTexto != "")
			{
				if (lTexto[0] != '(')
					strQuery.Append(" Where Nombre Like " + Traduce(lTexto + "%") + " Or UrlKey Like " + Traduce(lTexto + "%"));
				else
					strQuery.Append(" Where IdFuncion Not In " + lTexto + " ");
			}
			strQuery.Append(" Order by Nombre");

			try
			{
				dtSalida = EjecutarDataSet(strQuery.ToString(), "Funciones").Tables["Funciones"];
			}
			catch
			{
				throw;
			}
			return dtSalida;

		}

		public bool PermiteRol(int lIdRol)
		{
			bool bolSalida = false;
			if (htRoles.Contains(lIdRol))
				bolSalida = true;
			return bolSalida;
		}

		#endregion

		#region Métodos Privados

		private void pCargar(int lId, string lUrl)
		{
			if (lId != 0 || lUrl != "")
			{
				StringBuilder strSqlGet = new StringBuilder(512);
				strSqlGet.Append("Select IdFuncion, Nombre, UrlKey ");
				strSqlGet.Append(" From Funciones ");
				if (lId != -1)
					strSqlGet.Append(" Where IdFuncion = " + Traduce(lId));
				else
                    strSqlGet.Append(" Where UrlKey LIKE '%" + Convert.ToString(lUrl) + "%'");
				try
				{
                    if (lId != -1)
                    {
                        IDataReader drFuncion = EjecutarDataReader(strSqlGet.ToString());
					    if (drFuncion.Read())
					    {
						    intIdFuncion = drFuncion.GetInt32(0);
						    strNombre = drFuncion.GetString(1);
						    strUrlKey = drFuncion.GetString(2);
					    }
                        drFuncion.Close();
                    }
                    else
                    {
                        DataSet dsFuncion = EjecutarDataSet(strSqlGet.ToString(), "Funciones");
                        for (int i = 0; i < dsFuncion.Tables["Funciones"].Rows.Count; i++)
                        {
                            string lkey = dsFuncion.Tables["Funciones"].Rows[i]["UrlKey"].ToString();
                            string[] keys = lkey.Split(';');
                            bool existe = false;
                            for (int j = 0; j < keys.Length; j++)
                            {
                                if (keys[j].Equals(lUrl))
                                {
                                    existe = true;
                                    break;
                                }
                            }
                            if (existe)
                            {
                                intIdFuncion = Int32.Parse(dsFuncion.Tables["Funciones"].Rows[i]["IdFuncion"].ToString());
                                strNombre = dsFuncion.Tables["Funciones"].Rows[i]["Nombre"].ToString();
                                strUrlKey = lUrl;
                                break;
                            }
                        }
                    }
                }
				catch
				{
					throw;
				}

			}
		}

		private Hashtable pBuscarRoles()
		{
			Hashtable htSalida = new Rol().ListarRolesFuncion(intIdFuncion);
			return htSalida;

		}

		#endregion
	}
}