using System;
using System.Data;
using System.Data.Odbc;
using System.Text;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;

namespace ar.com.TiempoyGestion.BackEnd.Clientes.Dal
{
	/// <summary>
	/// Summary description for ClienteDal.
	/// </summary>
	public class ClienteDal : GenericDal
	{
		#region Atributos y Contructores

		private int intIdCliente;
		private string strRazonSocial;
        private string strRazonSocialFox;
        private string strNombreFantasia;
        private string strSucursal;
		private string strCUIT;
		private string strIngBru;
		private string strTelefono;
		private string strFax;
		private string strCalle;
		private string strNumero;
		private string strPiso;
		private string strDepto;
		private string strBarrio;
		private string strCodPostal;
		private int intIdLocalidad;
		private int intIdProvincia;
		private string strEmail;
		private string strNombreLocalidad;
		private string strNombreProvincia;
        private string strEncargado;
        private string strCargo;
        private string strObservaciones;
        private int intTipoDocumento;
        private int intTipoPeriodo;
        private int intHabilitarFinalizados;


		public ClienteDal() : base()
		{
			intIdCliente = -1;
			intIdLocalidad = -1;
			intIdProvincia = -1;
			strRazonSocial = "";
			strCUIT = "";
			strIngBru = "";
			strTelefono = "";
			strFax = "";
			strCalle = "";
			strNumero = "";
			strBarrio = "";
			strCodPostal = "";
			strEmail = "";
			strNombreLocalidad = "";
			strNombreProvincia = "";
		}

		#endregion

		#region Propiedades

		public int Id
		{
			get
			{
				return intIdCliente;
			}
            set
            {
                intIdCliente = value;
            }
		}

		public string RazonSocial
		{
			get
			{
				return strRazonSocial;
			}
			set
			{
				strRazonSocial = value;
			}
		}

        public string RazonSocialFox
        {
            get
            {
                return strRazonSocialFox;
            }
        }

        public string NombreFantasia
        {
            get
            {
                return strNombreFantasia;
            }
            set
            {
                strNombreFantasia = value;
            }
        }

        public string Sucursal
        {
            get
            {
                return strSucursal;
            }
            set
            {
                strSucursal = value;
            }
        }

		public string CUIT
		{
			get
			{
				return strCUIT;
			}
			set
			{
				strCUIT = value;
			}
		}

		public string IngresosBrutos
		{
			get
			{
				return strIngBru;
			}
			set
			{
				strIngBru = value;
			}
		}

		public string Telefono
		{
			get
			{
				return strTelefono;
			}
			set
			{
				strTelefono = value;
			}
		}

		public string Fax
		{
			get
			{
				return strFax;
			}
			set
			{
				strFax = value;
			}
		}

		public string Calle
		{
			get
			{
				return strCalle;
			}
			set
			{
				strCalle = value;
			}
		}

		public string Numero
		{
			get
			{
				return strNumero;
			}
			set
			{
				strNumero = value;
			}
		}

		public string Piso
		{
			get
			{
				return strPiso;
			}
			set
			{
				strPiso = value;
			}
		}

		public string Departamento
		{
			get
			{
				return strDepto;
			}
			set
			{
				strDepto = value;
			}
		}

		public string Barrio
		{
			get
			{
				return strBarrio;
			}
			set
			{
				strBarrio = value;
			}
		}

		public string CodigoPostal
		{
			get
			{
				return strCodPostal;
			}
			set
			{
				strCodPostal = value;
			}
		}

		public int IdLocalidad
		{
			get
			{
				return intIdLocalidad;
			}
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
			get
			{
				return intIdProvincia;
			}
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
			get
			{
				return strEmail;
			}
			set
			{
				strEmail = value;
			}
		}

        public string Encargado
        {
            get
            {
                return strEncargado;
            }
            set
            {
                strEncargado = value;
            }
        }

        public string Cargo
        {
            get
            {
                return strCargo;
            }
            set
            {
                strCargo = value;
            }
        }

        public string Observaciones
        {
            get
            {
                return strObservaciones;
            }
            set
            {
                strObservaciones = value;
            }
        }

        public int TipoDocumento
        {
            get 
            {
                return intTipoDocumento;
            }
            set
            {
                intTipoDocumento = value;
            }
        }

        public int TipoPeriodo
        {
            get
            {
                return intTipoPeriodo;
            }
            set
            {
                intTipoPeriodo = value;
            }
        }

        public int HabilitarFinalizados
        {
            get
            {
                return intHabilitarFinalizados;
            }
            set
            {
                intHabilitarFinalizados = value;
            }
        }
        

		#endregion

		#region Métodos Publicos

		#region void Cargar(int lIdCliente)

		public void Cargar(int lIdCliente)
		{
			if (lIdCliente != 0)
			{
				StringBuilder strSqlGet = new StringBuilder(512);
                strSqlGet.Append("Select C.RazonSocial, C.nombrefantasia, C.sucursal, C.CUIT, C.NroIngBrutos, C.Telefono, C.Fax, C.Calle, C.Numero, C.Piso, C.Office, C.Barrio, C.CodPos, C.IdLocalidad, C.IdProvincia, C.Email, C.encargado, C.cargo, C.observaciones, C.RazonSocialFox, C.tipoDocumento, C.tipoPeriodo, C.habilitarInformeFinalizado ");
				strSqlGet.Append(" From Clientes C ");
				strSqlGet.Append(" Where C.IdCliente = " + Traduce(lIdCliente));
				try
				{
					IDataReader drCliente = EjecutarDataReader(strSqlGet.ToString());
					
					if (drCliente.Read())
					{
						intIdCliente = lIdCliente;
						strRazonSocial = drCliente.GetString(0);
                        if (!drCliente.IsDBNull(19))
                            strRazonSocialFox = drCliente.GetString(19);
                        if (!drCliente.IsDBNull(1))
                            strNombreFantasia = drCliente.GetString(1);
                        if (!drCliente.IsDBNull(2))
                            strSucursal = drCliente.GetString(2);
						if (!drCliente.IsDBNull(3))
							strCUIT = drCliente.GetString(3);
						if (!drCliente.IsDBNull(4))
							strIngBru = drCliente.GetString(4);
						if (!drCliente.IsDBNull(5))
							strTelefono = drCliente.GetString(5);
						if (!drCliente.IsDBNull(6))
							strFax = drCliente.GetString(6);
						if (!drCliente.IsDBNull(7))
							strCalle = drCliente.GetString(7);
						if (!drCliente.IsDBNull(8))
							strNumero = drCliente.GetString(8);
						if (!drCliente.IsDBNull(9))
							strPiso = drCliente.GetString(9);
						if (!drCliente.IsDBNull(10))
							strDepto = drCliente.GetString(10);
						if (!drCliente.IsDBNull(11))
							strBarrio = drCliente.GetString(11);
						if (!drCliente.IsDBNull(12))
							strCodPostal = drCliente.GetString(12);
						if (!drCliente.IsDBNull(13))
							IdLocalidad = Convert.ToInt32(drCliente.GetInt32(13));
						if (!drCliente.IsDBNull(14))
							IdProvincia = Convert.ToInt32(drCliente.GetInt32(14));
                        if (!drCliente.IsDBNull(15))
                            strEmail = drCliente.GetString(15);
                        if (!drCliente.IsDBNull(16))
                            strEncargado = drCliente.GetString(16);
                        if (!drCliente.IsDBNull(17))
                            strCargo = drCliente.GetString(17);
                        if (!drCliente.IsDBNull(18))
                            strObservaciones = drCliente.GetString(18);
                        if (!drCliente.IsDBNull(20))
                            intTipoDocumento = Convert.ToInt32(drCliente.GetValue(20));
                        if (!drCliente.IsDBNull(21))
                            intTipoPeriodo = Convert.ToInt32(drCliente.GetValue(21));
                        if (!drCliente.IsDBNull(22))
                            intHabilitarFinalizados = Convert.ToInt32(drCliente.GetValue(22));

					}
					drCliente.Close();
				}
				catch
				{
					throw;
				}

			}				
		}


        public void Cargar(string nomCliente)
        {
            if (nomCliente != "")
            {
                StringBuilder strSqlGet = new StringBuilder(512);
                strSqlGet.Append("Select C.RazonSocial, C.nombrefantasia, C.sucursal, C.CUIT, C.NroIngBrutos, C.Telefono, C.Fax, C.Calle, C.Numero, C.Piso, C.Office, C.Barrio, C.CodPos, C.IdLocalidad, C.IdProvincia, C.Email, C.IdCliente, C.encargado, C.cargo, C.observaciones, C.RazonSocialFox, C.tipoDocumento, C.tipoPeriodo ");
                strSqlGet.Append(" From Clientes C ");
                strSqlGet.Append(" Where C.RazonSocial LIKE '" + nomCliente + "%'");
                try
                {
                    IDataReader drCliente = EjecutarDataReader(strSqlGet.ToString());

                    if (drCliente.Read())
                    {
                        intIdCliente = int.Parse(drCliente.GetString(14));
                        strRazonSocial = drCliente.GetString(0);
                        strRazonSocialFox = drCliente.GetString(19);
                        if (!drCliente.IsDBNull(1))
                            strNombreFantasia = drCliente.GetString(1);
                        if (!drCliente.IsDBNull(2))
                            strSucursal = drCliente.GetString(2);
                        if (!drCliente.IsDBNull(3))
                            strCUIT = drCliente.GetString(3);
                        if (!drCliente.IsDBNull(4))
                            strIngBru = drCliente.GetString(4);
                        if (!drCliente.IsDBNull(5))
                            strTelefono = drCliente.GetString(5);
                        if (!drCliente.IsDBNull(6))
                            strFax = drCliente.GetString(6);
                        if (!drCliente.IsDBNull(7))
                            strCalle = drCliente.GetString(7);
                        if (!drCliente.IsDBNull(8))
                            strNumero = drCliente.GetString(8);
                        if (!drCliente.IsDBNull(9))
                            strPiso = drCliente.GetString(9);
                        if (!drCliente.IsDBNull(10))
                            strDepto = drCliente.GetString(10);
                        if (!drCliente.IsDBNull(11))
                            strBarrio = drCliente.GetString(11);
                        if (!drCliente.IsDBNull(12))
                            strCodPostal = drCliente.GetString(12);
                        if (!drCliente.IsDBNull(13))
                            IdLocalidad = Convert.ToInt32(drCliente.GetInt32(13));
                        if (!drCliente.IsDBNull(14))
                            IdProvincia = Convert.ToInt32(drCliente.GetInt32(14));
                        if (!drCliente.IsDBNull(15))
                            strEmail = drCliente.GetString(15);
                        if (!drCliente.IsDBNull(16))
                            strEncargado = drCliente.GetString(16);
                        if (!drCliente.IsDBNull(17))
                            strCargo = drCliente.GetString(17);
                        if (!drCliente.IsDBNull(18))
                            strObservaciones = drCliente.GetString(18);
                        if (!drCliente.IsDBNull(20))
                            intTipoDocumento = drCliente.GetInt16(20);
                        if (!drCliente.IsDBNull(21))
                            intTipoPeriodo = drCliente.GetInt16(21);
                    }
                    drCliente.Close();
                }
                catch
                {
                    throw;
                }

            }
        }
		#endregion

		#region bool Crear()

		public bool Crear()
		{	
            OdbcConnection oConnection = this.OpenConnection();
            String strMaxID = "SELECT MAX(idCliente) + 1 as MaxId FROM Clientes";
            //System.Console.Out.WriteLine(strSQL);
            int MaxID = ObtenerMaxID(strMaxID, oConnection);

			String strSQL = "INSERT INTO Clientes ";
			strSQL+="(idCliente, RazonSocial, NombreFantasia, Sucursal, CUIT, NroIngBrutos, Telefono, Fax, Calle, ";
			strSQL+="Numero, Piso, Office, Barrio, CodPos, IdLocalidad, ";
            strSQL += "IdProvincia, Email, Encargado, Cargo, Observaciones, tipoDocumento, tipoPeriodo, habilitarInformeFinalizado) ";
			strSQL+="VALUES ";
            strSQL += "('" + MaxID + "'";
            strSQL += ",'" + strRazonSocial.Trim().Replace("'", "''") + "'";
            strSQL += ",'" + strNombreFantasia.Trim().Replace("'", "''") + "'";
            strSQL += ",'" + strSucursal.Trim().Replace("'", "''") + "'";
			strSQL+=",'"+strCUIT.Trim()+"'";
			strSQL+=",'"+strIngBru.Trim()+"'";
			strSQL+=",'"+strTelefono.Trim()+"'";
			strSQL+=",'"+strFax.Trim()+"'";
            strSQL += ",'" + strCalle.Trim().Replace("'", "''") + "'";
			strSQL+=",'"+strNumero.Trim()+"'";
			strSQL+=",'"+strPiso.Trim()+"'";
			strSQL+=",'"+strDepto.Trim()+"'";
			strSQL+=",'"+strBarrio.Trim()+"'";
			strSQL+=",'"+strCodPostal.Trim()+"'";
			strSQL+=","+intIdLocalidad;
			strSQL+=","+intIdProvincia;
			strSQL+=",'"+strEmail.Trim()+"'";
            strSQL+=",'" + strEncargado.Trim() + "'";
            strSQL+=",'" + strCargo.Trim() + "'";
            strSQL+=",'" + strObservaciones.Trim() + "'";
            strSQL+="," + intTipoDocumento + "";
            strSQL+="," + intTipoPeriodo + "";
            strSQL+="," + intHabilitarFinalizados + ")";
			
			try
			{
				OdbcCommand	myCommand = new OdbcCommand(strSQL, oConnection);
				myCommand.ExecuteNonQuery();

				oConnection.Close();
			} 			
			catch (Exception e)
			{	
				System.Console.WriteLine(e.Message);
				return false;
			}
			return true;			
		}

		#endregion

		#region bool Modificar()

		public bool Modificar()
		{			
			if 	(intIdCliente != -1)
			{	
				OdbcConnection oConnection = this.OpenConnection();
				String strSQL = "Update Clientes ";
                strSQL += " Set RazonSocial='" + strRazonSocial.Trim().Replace("'", "''") + "'";
                if (strNombreFantasia != null)
                    strSQL += " ,nombrefantasia='" + strNombreFantasia.Trim().Replace("'", "''") + "'";
                if (strSucursal != null)
                    strSQL += " ,sucursal='" + strSucursal.Trim().Replace("'", "''") + "'";
				strSQL+=",CUIT='"+strCUIT.Trim()+"'";
				strSQL+=",NroIngBrutos='"+strIngBru.Trim()+"'";
				strSQL+=",Telefono='"+strTelefono.Trim()+"'";
				strSQL+=",Fax='"+strFax.Trim()+"'";
                strSQL += ",Calle='" + strCalle.Trim().Replace("'", "''") + "'";
				strSQL+=",Numero='"+strNumero.Trim()+"'";
				strSQL+=",Piso='"+strPiso.Trim()+"'";
				strSQL+=",Office='"+strDepto.Trim()+"'";
                strSQL += ",Barrio='" + strBarrio.Trim().Replace("'", "''") + "'";
				strSQL+=",CodPos='"+strCodPostal.Trim()+"'";
				strSQL+=",IdLocalidad="+intIdLocalidad;
				strSQL+=",IdProvincia="+intIdProvincia;
				strSQL+=",Email='"+strEmail.Trim()+"'";
                if (strEncargado != null)
                    strSQL+=",Encargado='" + strEncargado.Trim() + "'";
                if (strCargo != null)
                    strSQL+=",Cargo='" + strCargo.Trim() + "'";
                if (strObservaciones != null)
                    strSQL+=",Observaciones='" + strObservaciones.Trim() + "'";
                strSQL += ",tipoDocumento=" + intTipoDocumento + "";
                strSQL += ",tipoPeriodo=" + intTipoPeriodo + "";
                strSQL += ",habilitarInformeFinalizado=" + intHabilitarFinalizados + "";
				strSQL+=" WHERE IdCliente="+intIdCliente;
			
				try
				{
					OdbcCommand	myCommand = new OdbcCommand(strSQL, oConnection);
					myCommand.ExecuteNonQuery();

					oConnection.Close();
				} 			
				catch (Exception e)
				{	
					System.Console.WriteLine(e.Message);
					return false;
				}
				return true;						
			}
			return false;
		}

		#endregion

		#region bool Eliminar(int lId)

		public bool Eliminar(int lId)
		{
			StringBuilder strSqlUpdate = new StringBuilder(128);
			strSqlUpdate.Append("Delete From Clientes ");
			strSqlUpdate.Append(" Where IdCliente = " + Traduce(lId));
			try
			{
				EjecutarComando(strSqlUpdate.ToString());
			}
			catch
			{
				return false;
			}
			return true;
		}

		#endregion

		#region DataTable Listar(string lTexto)

		public DataTable Listar(string filtro)
		{
			OdbcConnection oConnection = this.OpenConnection();
			DataSet ds = new DataSet();
            String strSQL = "SELECT C.IdCliente, C.RazonSocial, C.nombrefantasia, C.sucursal, C.Telefono, C.Fax, C.CUIT, C.Email, " +
                " (C.Calle + ' ' + isnull(C.Numero,'-') + ' piso:' + isnull(C.Piso,'-') + ' oficina:' " +
                " + isnull(C.Office,'-') + ' barrio:' + C.Barrio) AS Direccion, C.RazonSocialFox " +
			    " FROM Clientes C " +
                " WHERE activo=1 ";
			
			if (filtro.CompareTo("")!=0)
			{
                if (filtro.Substring(0).ToUpper().CompareTo("Ñ") == 0)
                    strSQL += " AND ASCII(C.RazonSocial)='209' OR ASCII(C.RazonSocial)='241'";
                else
                {
                    strSQL += " AND (C.RazonSocial like '%" + filtro + "%' ";
                    strSQL += " OR C.RazonSocialFox like '%" + filtro + "%' ";
                    strSQL += " OR C.nombrefantasia like '%" + filtro + "%' ";
                    strSQL += " OR C.calle like '%" + filtro + "%') ";
                }
			}

            strSQL += " ORDER BY C.nombrefantasia ";

			OdbcDataAdapter myConsulta = new OdbcDataAdapter(strSQL, oConnection);
			myConsulta.Fill(ds);
			try
			{				
				oConnection.Close();
			} 
			catch (Exception e)
			{	
				Console.Out.WriteLine(e.Message);				
			}	
		
			return ds.Tables[0];												
		}

		#endregion

		#region DataTable CargarDatos()

		public DataTable CargarDatos()
		{
			return Listar("");

		}

        
		#endregion

        
        #region ObtenerMaxID(string strMaxID, OdbcConnection oConnection)
        private int ObtenerMaxID(string strMaxID, OdbcConnection oConnection)
        {
            DataSet ds = new DataSet();
            OdbcDataAdapter myConsulta = new OdbcDataAdapter(strMaxID, oConnection);
            myConsulta.Fill(ds);
            int MaxID = 0;
            try
            {
                MaxID = int.Parse(ds.Tables[0].Rows[0]["Maxid"].ToString());
            }
            catch
            {
                return 0;
            }
            return MaxID;
        }
        #endregion
        

        #endregion
    }
}

