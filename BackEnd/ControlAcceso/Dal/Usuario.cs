using System;
using System.Collections;
using System.Data;
using System.Text;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;
using ar.com.TiempoyGestion.BackEnd.BackServices.Services;

namespace ar.com.TiempoyGestion.BackEnd.ControlAcceso.Dal
{
	/// <summary>
	/// Summary description for Usuario.
	/// </summary>
	public class Usuario : GenericDal
	{
		#region Atributos y Contructores

		private int intIdUsuario;
		private string strLoginName;
		private string strNombre;
		private string strApellido;
		private string strTelefono;
		private string strCelular;
		private string strCalle;
		private string strNumero;
		private string strPiso;
		private string strDpto;
		private string strBarrio;
		private string strCodPostal;
		private int intIdLocalidad;
		private int intIdProvincia;
		private string strEmail;
		private string strPassword;
		private int intIdCliente;
		private DateTime dtFecCreacion;
		private DateTime dtUltimoIngreso;
		private bool bolIntranet;
		private string strNombreLocalidad;
		private string strNombreProvincia;
        private bool bolActivo;
		private string strCliente;
		private Hashtable htRoles;
		private string strStringRoles;


		public Usuario() : base()
		{
			intIdUsuario = -1;
			intIdCliente = -1;
			intIdLocalidad = -1;
			intIdProvincia = -1;
			bolIntranet = false;
			dtFecCreacion = DateTime.MinValue;
			dtUltimoIngreso = DateTime.MinValue;
			strLoginName = "";
			strNombre = "";
			strApellido = "";
			strTelefono = "";
			strCelular = "";
			strCalle = "";
			strNumero = "";
			strPiso = "";
			strDpto = "";
			strBarrio = "";
			strCodPostal = "";
			strEmail = "";
			strPassword = "";
			strNombreLocalidad = "";
			strNombreProvincia = "";
			strCliente = "";
			htRoles = null;
			strStringRoles = "";
            bolActivo = false;
		}

		#endregion

		#region Propiedades

		public int Id
		{
			get { return intIdUsuario; }
		}

		public string LogginName
		{
			get { return strLoginName; }
		}

		public string Nombre
		{
			get { return strNombre; }
			set { strNombre = value; }
		}

		public string Apellido
		{
			get { return strApellido; }
			set { strApellido = value; }
		}

		public string Telefono
		{
			get { return strTelefono; }
			set { strTelefono = value; }
		}

		public string Celular
		{
			get { return strCelular; }
			set { strCelular = value; }
		}

		public string Calle
		{
			get { return strCalle; }
			set { strCalle = value; }
		}

		public string Numero
		{
			get { return strNumero; }
			set { strNumero = value; }
		}

		public string Piso
		{
			get { return strPiso; }
			set { strPiso = value; }
		}

		public string Departamento
		{
			get { return strDpto; }
			set { strDpto = value; }
		}

		public string Barrio
		{
			get { return strBarrio; }
			set { strBarrio = value; }
		}

		public string CodigoPostal
		{
			get { return strCodPostal; }
			set { strCodPostal = value; }
		}

		public int IdLocalidad
		{
			get { return intIdLocalidad; }
			set
			{
				UtilesApp oUtil = new UtilesApp();
				strNombreLocalidad = oUtil.BuscarLocalidad(value);
				if (strNombreLocalidad != "")
					intIdLocalidad = value;
				else
					throw new ArgumentException("El Id de Localidad es Inexistente... ");
			}
		}

		public int IdProvincia
		{
			get { return intIdProvincia; }
			set
			{
				UtilesApp oUtil = new UtilesApp();
				strNombreProvincia = oUtil.BuscarLocalidad(value);
				if (strNombreProvincia != "")
					intIdProvincia = value;
				else
					throw new ArgumentException("El Id de Localidad es Inexistente... ");
			}
		}

		public string Email
		{
			get { return strEmail; }
			set { strEmail = value; }
		}

		public int IdCliente
		{
			get { return intIdCliente; }
		}

		public string Cliente
		{
			get { return strCliente; }
		}

		public DateTime FechaCreacion
		{
			get { return dtFecCreacion; }
		}

		public DateTime UltimoIngreso
		{
			get { return dtUltimoIngreso; }
		}

		public bool UsuarioIntranet
		{
			get { return bolIntranet; }
			set { bolIntranet = value; }
		}

        public bool Activo
        {
            get { return bolActivo; }
            set { bolActivo = value; }
        }

		public Hashtable Roles
		{
			get
			{
				if (htRoles == null)
				{
					if (intIdUsuario != -1)
						htRoles = pBuscarRoles();
					else
						htRoles = new Hashtable();
				}
				return htRoles;
			}
		}

		public string RolesString
		{
			get
			{
				if (strStringRoles == "" && this.Roles.Count > 0)
				{
					StringBuilder sbAuxRoles = new StringBuilder();
					foreach(Rol itemRol in htRoles.Values)
						sbAuxRoles.Append(itemRol.Nombre + "|");
					if (sbAuxRoles.Length > 0)
						sbAuxRoles.Remove(sbAuxRoles.Length - 1, 1);
					strStringRoles = sbAuxRoles.ToString();
				}

				return strStringRoles;
			}

		}

		#endregion

		#region Métodos Publicos

		public void Cargar(int lIdUsuario)
		{
			pCargar(lIdUsuario, "");
		}

		public void Cargar(string lLoginName)
		{
			pCargar(-1, lLoginName);
		}

		public int Crear(string lLoginName, string lPassword)
		{
			return pCrear(lLoginName, lPassword, -1);

		}

		public int Crear(string lLoginName, string lPassword, int lIdCliente)
		{
			return pCrear(lLoginName, lPassword, lIdCliente);

		}

		public bool Modificar()
		{
			bool bolSalida = true;
			if (intIdUsuario != -1 && strNombre != "" && strApellido != "")
			{
				StringBuilder strSqlUpdate = new StringBuilder(512);
				strSqlUpdate.Append("Update Usuarios ");
				strSqlUpdate.Append(" Set Nombre = " + Traduce(strNombre));
                strSqlUpdate.Append(", Apellido = " + Traduce(strApellido.Trim().Replace("'", "''")));
				strSqlUpdate.Append(", Telefono = " + Traduce(strTelefono));
				strSqlUpdate.Append(", Celular = " + Traduce(strCelular));
                strSqlUpdate.Append(", Calle = " + Traduce(strCalle.Trim().Replace("'", "''")));
				strSqlUpdate.Append(", Numero =  " + Traduce(strNumero));
				strSqlUpdate.Append(", Piso = " + Traduce(strPiso));
				strSqlUpdate.Append(", Office =  " + Traduce(strDpto));
                strSqlUpdate.Append(", Barrio = " + Traduce(strBarrio.Trim().Replace("'", "''")));
				strSqlUpdate.Append(", CodPos = " + Traduce(strCodPostal));
				strSqlUpdate.Append(", IdLocalidad = " + Traduce(intIdLocalidad));
				strSqlUpdate.Append(", IdProvincia = " + Traduce(intIdProvincia));
				strSqlUpdate.Append(", Email = " + Traduce(strEmail) + " ");
                strSqlUpdate.Append(", estado = " + Traduce(bolActivo) + " ");
				strSqlUpdate.Append(" Where IdUsuario = " + Traduce(intIdUsuario));
				try
				{
					if (EjecutarComando(strSqlUpdate.ToString()) != 1)
						bolSalida = false;
					else
					{
						try
						{
							if (Roles.Count > 0)
							{
								EjecutarComando("Delete From UsuariosRoles Where IdUsuario = " + Traduce(intIdUsuario));
								foreach (Rol itemRol in htRoles.Values)
								{
										EjecutarComando("Insert Into UsuariosRoles(IdUsuario, IdRol) Values(" + Traduce(intIdUsuario) + ", " + Traduce(itemRol.Id) + ") ");
								}
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
			StringBuilder strSqlUpdate = new StringBuilder(128);
			strSqlUpdate.Append("Delete From Usuarios ");
			strSqlUpdate.Append(" Where IdUsuario = " + Traduce(lId));
			try
			{
				EjecutarComando(strSqlUpdate.ToString());
			}
			catch
			{
				throw;
			}

		}

		public static bool CambiarPassword(string lUserName, string lOldPass, string lNewPass)
		{
			bool bolSalida = true;
			if (AutenticarUsuario(lUserName, lOldPass))
			{
				StringBuilder strSqlUpdate = new StringBuilder(128);
				strSqlUpdate.Append("Update Usuarios ");
				strSqlUpdate.Append(" Set Password = " + StaticDal.Traduce(Encriptador.HashPassword(lNewPass)));
				strSqlUpdate.Append(" Where LoginName = " + StaticDal.Traduce(lUserName));
				try
				{
					StaticDal.EjecutarComando(strSqlUpdate.ToString());
				}
				catch
				{
					bolSalida = false;
				}
			}
			return bolSalida;
		}


        public string ResetPassword(int lIdCliente, int lIdUsuario, string lUserName, string lIp)
        {
            string lNewPass = "";
            lNewPass = CreateRandomPassword(10);
            StringBuilder strSqlUpdate = new StringBuilder(128);
            strSqlUpdate.Append("Update Usuarios ");
            strSqlUpdate.Append(" Set Password = " + StaticDal.Traduce(Encriptador.HashPassword(lNewPass)));
            strSqlUpdate.Append(" Where LoginName = " + StaticDal.Traduce(lUserName));

            StringBuilder strSqlUpdate2 = new StringBuilder(128);
            strSqlUpdate2.Append("INSERT INTO log ");
            strSqlUpdate2.Append("(idTipo, idCliente, idUsuario, evento, ip) VALUES ");
            strSqlUpdate2.Append("(1, " + lIdCliente + ", " + lIdUsuario + ", 'Solicitó cambio de clave', '" + lIp + "') ");
            try
            {
                StaticDal.EjecutarComando(strSqlUpdate.ToString());
                StaticDal.EjecutarComando(strSqlUpdate2.ToString());
            }
            catch
            {
                lNewPass = "";
            }
            return lNewPass;
        }

        public static string CreateRandomPassword(int PasswordLength)
        {
            string _allowedChars = "abcdefghijkmnpqrstuvwxyzABCDEFGHJKLMNPQRSTUVWXYZ0123456789";
            Byte[] randomBytes = new Byte[PasswordLength];
            char[] chars = new char[PasswordLength];
            int allowedCharCount = _allowedChars.Length;

            for (int i = 0; i < PasswordLength; i++)
            {
                Random randomObj = new Random();
                randomObj.NextBytes(randomBytes);
                chars[i] = _allowedChars[(int)randomBytes[i] % allowedCharCount];
            }

            return new string(chars);
        } 

		public static bool AutenticarUsuario(string lUserName, string lPassword)
		{
			bool bolSalida = false;
			StringBuilder strSqlGet = new StringBuilder(512);
			strSqlGet.Append("Select U.Password");
			strSqlGet.Append(" From Usuarios U");
			strSqlGet.Append(" Where U.LoginName = " + StaticDal.Traduce(lUserName));
            strSqlGet.Append(" AND U.estado = 1");
			IDataReader drUsuario = null;
			try
			{
				drUsuario= StaticDal.EjecutarDataReader(strSqlGet.ToString());

				if (drUsuario.Read())
				{
					if (Encriptador.HashPassword(lPassword) == drUsuario.GetString(0))
						bolSalida = true;
				}
			}
			catch (Exception e)
			{
				bolSalida = false;
			}
			finally
			{
				if (drUsuario != null)
					drUsuario.Close();
			}

			return bolSalida;
		}

		public bool RegistrarIngreso()
		{
			bool bolSalida = true;
			if (intIdUsuario != -1)
			{
				StringBuilder strSqlUpdate = new StringBuilder(512);
				strSqlUpdate.Append("Update Usuarios ");
				strSqlUpdate.Append(" Set UltimoIngreso = getdate() ");
				strSqlUpdate.Append(" Where IdUsuario = " + Traduce(intIdUsuario));
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

		public DataTable Listar(string lTexto, bool lIntranet)
		{
			return pListar(lTexto, -1, lIntranet);

		}

		public DataTable Listar(string lTexto, int lIdCliente)
		{
			return pListar(lTexto, lIdCliente, false);

		}

		#endregion

		#region Métodos Privados

		private void pCargar(int lId, string lLogin)
		{
			if (lId != 0 || lLogin != "")
			{
				StringBuilder strSqlGet = new StringBuilder(512);
                strSqlGet.Append("Select U.IdUsuario, U.LoginName, U.Nombre, U.Apellido, U.Telefono, U.Celular, U.Calle, U.Numero, U.Piso, U.Office, U.Barrio, U.CodPos, U.IdLocalidad, U.IdProvincia, U.Email, U.Password, U.FecCreacion, U.UltimoIngreso, U.Intranet, C.RazonSocial, U.IdCliente, U.estado");
                strSqlGet.Append(" From Usuarios U LEFT OUTER JOIN Clientes C ON U.IdCliente=C.IdCliente ");
				if (lId != -1)
					strSqlGet.Append(" Where U.IdUsuario = " + Traduce(lId));
				else
					strSqlGet.Append(" Where U.LoginName = " + Traduce(lLogin));
				try
				{
					IDataReader drUsuario = EjecutarDataReader(strSqlGet.ToString());

					if (drUsuario.Read())
					{
						intIdUsuario = drUsuario.GetInt32(0);
						strLoginName = drUsuario.GetString(1);
						strNombre = drUsuario.GetString(2);
						strApellido = drUsuario.GetString(3);
						if (!drUsuario.IsDBNull(4))
							strTelefono = drUsuario.GetString(4);
						if (!drUsuario.IsDBNull(5))
							strCelular = drUsuario.GetString(5);
						if (!drUsuario.IsDBNull(6))
							strCalle = drUsuario.GetString(6);
						if (!drUsuario.IsDBNull(7))
							strNumero = drUsuario.GetString(7);
						if (!drUsuario.IsDBNull(8))
							strPiso = drUsuario.GetString(8);
						if (!drUsuario.IsDBNull(9))
							strDpto = drUsuario.GetString(9);
						if (!drUsuario.IsDBNull(10))
							strBarrio = drUsuario.GetString(10);
						if (!drUsuario.IsDBNull(11))
							strCodPostal = drUsuario.GetString(11);
						if (!drUsuario.IsDBNull(12))
							IdLocalidad = drUsuario.GetInt32(12);
						if (!drUsuario.IsDBNull(13))
							IdProvincia = drUsuario.GetInt32(13);
						strEmail = drUsuario.GetString(14);
						strPassword = drUsuario.GetString(15);
						dtFecCreacion = drUsuario.GetDateTime(16);
						if (!drUsuario.IsDBNull(17))
							dtUltimoIngreso = drUsuario.GetDateTime(17);
						bolIntranet = Convert.ToBoolean(drUsuario.GetByte(18));
						if (!drUsuario.IsDBNull(19))
							strCliente = drUsuario.GetString(19);
						if (!drUsuario.IsDBNull(20))
                            intIdCliente = drUsuario.GetInt32(20);
                        bolActivo = Convert.ToBoolean(drUsuario.GetByte(21));
					}
					drUsuario.Close();
				}
				catch
				{
					throw;
				}

			}
		}

		private int pCrear(string lLogin, string lPass, int lIdCliente)
		{
			int intSalida = -1;
			if (lLogin != "" && strNombre != "" && strApellido != "")
			{
				if (lIdCliente == -1)
				{
					bolIntranet = true;
					lIdCliente = 0;
				}
				StringBuilder strSqlInsert = new StringBuilder(512);
				strSqlInsert.Append("Insert Into Usuarios ");
				strSqlInsert.Append(" (LoginName, Password, Nombre, Apellido, Telefono, Celular, Calle, Numero, Piso, Office, Barrio, CodPos, IdLocalidad, IdProvincia, Email, FecCreacion, UltimoIngreso, IdCliente, Intranet) ");
				strSqlInsert.Append(" Values ");
				strSqlInsert.Append(" (" + Traduce(lLogin) + ", ");
				strSqlInsert.Append(" " + Traduce(Encriptador.HashPassword(lPass)) + ", ");
				strSqlInsert.Append(" " + Traduce(strNombre) + ", ");
                strSqlInsert.Append(" " + Traduce(strApellido.Trim().Replace("'", "''")) + ", ");
				strSqlInsert.Append(" " + Traduce(strTelefono) + ", ");
				strSqlInsert.Append(" " + Traduce(strCelular) + ", ");
                strSqlInsert.Append(" " + Traduce(strCalle.Trim().Replace("'", "''")) + ", ");
				strSqlInsert.Append(" " + Traduce(strNumero) + ", ");
				strSqlInsert.Append(" " + Traduce(strPiso) + ", ");
				strSqlInsert.Append(" " + Traduce(strDpto) + ", ");
                strSqlInsert.Append(" " + Traduce(strBarrio.Trim().Replace("'", "''")) + ", ");
				strSqlInsert.Append(" " + Traduce(strCodPostal) + ", ");
				strSqlInsert.Append(" " + Traduce(intIdLocalidad) + ", ");
				strSqlInsert.Append(" " + Traduce(intIdProvincia) + ", ");
				strSqlInsert.Append(" " + Traduce(strEmail) + ", ");
				strSqlInsert.Append(" getdate(), ");
                strSqlInsert.Append(" '01/01/1900 00:00:00.000', ");
				strSqlInsert.Append(" " + Traduce(lIdCliente) + ", ");
				strSqlInsert.Append(" " + Traduce(bolIntranet) + ") ");

				try
				{
					if (EjecutarComando(strSqlInsert.ToString()) == 1)
					{
						IDataReader drIdCreado = EjecutarDataReader("Select Max(IdUsuario) From Usuarios");
						if (drIdCreado.Read() && !drIdCreado.IsDBNull(0))
						{
                            intSalida = Convert.ToInt32(drIdCreado.GetInt32(0));
							intIdUsuario = intSalida;
							if (htRoles != null)
							{
								foreach (Rol itemRol in htRoles)
								{
									try
									{
										EjecutarComando("Insert Into UsuariosRoles(IdUsuario, IdRol) Values(" + Traduce(intSalida) + ", " + Traduce(itemRol.Id) + ") ");
									}
									catch
									{}
								}
							}
						}
						else
							intSalida = -1;
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

		private DataTable pListar(string lTexto, int lIdCliente, bool lIntranet)
		{
			StringBuilder strQuery = new StringBuilder(512);
			DataTable dtSalida = null;
            strQuery.Append("SELECT U.IdUsuario, U.LoginName, U.Nombre, U.Apellido, U.Email, U.UltimoIngreso, U.Intranet, C.RazonSocial, U.estado ");
            strQuery.Append(" FROM Usuarios U LEFT OUTER JOIN Clientes C ON U.IdCliente = C.IdCliente ");
            strQuery.Append(" WHERE 1 = 1 "); //U.estado
			if (lTexto != "")
				strQuery.Append(" AND (U.Nombre Like " + Traduce(lTexto + "%") + " Or U.Apellido Like " + Traduce(lTexto + "%") + " Or U.LoginName Like " + Traduce(lTexto + "%") + " Or U.Email Like " + Traduce(lTexto + "%") + ") ");
			if (lIdCliente != -1)
			{
				if (lTexto != "")
					strQuery.Append(" AND U.IdCliente = " + Traduce(lIdCliente));
				else
                    strQuery.Append(" AND U.IdCliente = " + Traduce(lIdCliente));
			}
			if (lIntranet)
			{
				if (lTexto != "" || lIdCliente != -1)
					strQuery.Append(" AND U.Intranet = 1 ");
				else
                    strQuery.Append(" AND U.Intranet = 1 ");
			}

			strQuery.Append(" ORDER BY U.Nombre, U.Apellido ");

			try
			{
				dtSalida = EjecutarDataSet(strQuery.ToString(), "Usuarios").Tables["Usuarios"];
			}
			catch
			{
				throw;
			}
			return dtSalida;

		}

		private Hashtable pBuscarRoles()
		{
			Hashtable htSalida = new Rol().ListarRolesUsuario(intIdUsuario);

			return htSalida;

		}

		#endregion
	}
}