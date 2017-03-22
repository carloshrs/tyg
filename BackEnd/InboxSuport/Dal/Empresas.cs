using System;
using System.Data;
using System.Data.Odbc;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;
//using ar.com.TiempoyGestion.BackEnd.Clientes.App;

namespace ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal
{
	/// <summary>
	/// Summary description for ClienteDal.
	/// </summary>
	public class EmpresasAPP : GenericDal
	{
		#region Atributos y Contructores
			
		private int intIdEmpresa;
		//EMPRESAS
		private String strRazonSocial;
		private String strNombreFantasia;
		private String strTelefonoEmpresa;
		private String strRubro;
		private String strCuit;
		private String strCalleEmpresa;
		private String strNroEmpresa;
		private String strDptoEmpresa;
		private String strPisoEmpresa;
		private String strBarrioEmpresa;
		private String strCPEmpresa;
		private int intLocalidadEmpresa;
		private int intProvinciaEmpresa;
        private String strObservaciones;

		public EmpresasAPP() : base()
		{}

		#endregion

		#region Propiedades

		public int IdEmpresa
		{
			get
			{
				return intIdEmpresa;
			}
			set
			{
				intIdEmpresa = value;
			}
		}

		public String RazonSocial
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

		public String NombreFantasia
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

		public String TelefonoEmpresa
		{
			get
			{
				return strTelefonoEmpresa;
			}
			set
			{
				strTelefonoEmpresa = value;
			}
		}

		public String Rubro
		{
			get
			{
				return strRubro;
			}
			set
			{
				strRubro = value;
			}
		}

		public String Cuit
		{
			get
			{
				return strCuit;
			}
			set
			{
				strCuit = value;
			}
		}

		public String CalleEmpresa
		{
			get
			{
				return strCalleEmpresa;
			}
			set
			{
				strCalleEmpresa = value;
			}
		}

		public String NroEmpresa
		{
			get
			{
				return strNroEmpresa;
			}
			set
			{
				strNroEmpresa = value;
			}
		}

		public String DptoEmpresa
		{
			get
			{
				return strDptoEmpresa;
			}
			set
			{
				strDptoEmpresa = value;
			}
		}

		public String PisoEmpresa
		{
			get
			{
				return strPisoEmpresa;
			}
			set
			{
				strPisoEmpresa = value;
			}
		}

		public String BarrioEmpresa
		{
			get
			{
				return strBarrioEmpresa;
			}
			set
			{
				strBarrioEmpresa = value;
			}
		}

		public String CPEmpresa
		{
			get
			{
				return strCPEmpresa;
			}
			set
			{
				strCPEmpresa = value;
			}
		}

		public int LocalidadEmpresa
		{
			get
			{
				return intLocalidadEmpresa;
			}
			set
			{
				intLocalidadEmpresa = value;
			}
		}

		public int ProvinciaEmpresa
		{
			get
			{
				return intProvinciaEmpresa;
			}
			set
			{
				intProvinciaEmpresa = value;
			}
		}

        public String Observaciones
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

		#endregion

		#region Métodos Publicos

		#region bool Crear()

		public bool Crear()
		{
			OdbcConnection oConnection = this.OpenConnection();
			String strSQL="";
			strSQL+="INSERT INTO Empresas (RazonSocial, NombreFantasia, Telefono, Rubro, Cuit, Calle, Nro,";
			strSQL+="Dpto, Piso, Barrio, CP, idLocalidad, idProvincia, Observaciones) VALUES ('";			
			strSQL+=strRazonSocial+"','";
			strSQL+=strNombreFantasia+"','";
			strSQL+=strTelefonoEmpresa+"','";
			strSQL+=strRubro+"','";
			strSQL+=strCuit+"','";
			strSQL+=strCalleEmpresa+"','";
			strSQL+=strNroEmpresa+"','";
			strSQL+=strDptoEmpresa+"','"; 
			strSQL+=strPisoEmpresa+"','";
			strSQL+=strBarrioEmpresa+"','";
			strSQL+=strCPEmpresa+"',";
			strSQL+=intLocalidadEmpresa+",";
			strSQL+=intProvinciaEmpresa+",'";
            strSQL+=strObservaciones + "')"; 
			try
			{
				OdbcCommand	myCommand = new OdbcCommand(strSQL, oConnection);
				myCommand.ExecuteNonQuery();
				oConnection.Close();
			} 			
			catch (Exception e)
			{	
				Console.Out.WriteLine(e.Message);
				return false;
			}
			return true;
		}

		#endregion

		#region bool Modificar(int idEmpresa)

		public bool Modificar(int idEmpresa)
		{
			OdbcConnection oConnection = this.OpenConnection();
			String strSQL ="";
			strSQL+="UPDATE Empresas SET ";			
			strSQL+="RazonSocial='" + strRazonSocial + "'";
			strSQL+=", NombreFantasia='" + strNombreFantasia + "'";
			strSQL+=", Telefono='" + strTelefonoEmpresa + "'";
			strSQL+=", Rubro='" + strRubro + "'";
			strSQL+=", Cuit='" + strCuit + "'";
			strSQL+=", Calle='" + strCalleEmpresa + "'";
			strSQL+=", Nro='" + strNroEmpresa + "'";
			strSQL+=", Dpto='" + strDptoEmpresa + "'";
			strSQL+=", Piso='" + strPisoEmpresa + "'";
			strSQL+=", Barrio='" + strBarrioEmpresa + "'";
			strSQL+=", CP='" + strCPEmpresa + "'";
			strSQL+=", idLocalidad = " + intLocalidadEmpresa;
			strSQL+=", idProvincia = " + intProvinciaEmpresa;
            strSQL += ", Observaciones='" + strObservaciones + "'";
			strSQL+=" WHERE idEmpresa=" + idEmpresa.ToString();

			try
			{
				OdbcCommand	myCommand = new OdbcCommand(strSQL, oConnection);
				myCommand.ExecuteNonQuery();
				oConnection.Close();
			} 			
			catch (Exception e)
			{	
				Console.Out.WriteLine(e.Message);
				return false;
			}
			return true;
		}

		#endregion

		#region bool Eliminar(int idEmpresa)

		public bool Eliminar(int idEmpresa)
		{
			OdbcConnection oConnection = this.OpenConnection();
			String strSQL = "DELETE FROM Empresas WHERE idEmpresa = " + idEmpresa.ToString();

			try
			{
				OdbcCommand	myCommand = new OdbcCommand(strSQL, oConnection);
				myCommand.ExecuteNonQuery();
				oConnection.Close();
			} 			
			catch (Exception e)
			{	
				Console.Out.WriteLine(e.Message);
				return false;
			}
			return true;
		}

		#endregion

		#region void Cargar(int idEmpresa)

		public void Cargar(int idEmpresa)
		{
			
			OdbcConnection oConnection = this.OpenConnection();
			DataSet ds = new DataSet();
			String strSQL = "SELECT * FROM Empresas WHERE idEmpresa=" + idEmpresa.ToString();			
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

			intIdEmpresa = idEmpresa; 			
			strRazonSocial= ds.Tables[0].Rows[0]["RazonSocial"].ToString().Trim();
			strNombreFantasia= ds.Tables[0].Rows[0]["NombreFantasia"].ToString().Trim();
			strTelefonoEmpresa= ds.Tables[0].Rows[0]["Telefono"].ToString();
			strRubro= ds.Tables[0].Rows[0]["Rubro"].ToString().Trim();
			strCuit= ds.Tables[0].Rows[0]["Cuit"].ToString();
			strCalleEmpresa= ds.Tables[0].Rows[0]["Calle"].ToString().Trim();
			strNroEmpresa= ds.Tables[0].Rows[0]["Nro"].ToString();
			strDptoEmpresa= ds.Tables[0].Rows[0]["Dpto"].ToString();
			strPisoEmpresa= ds.Tables[0].Rows[0]["Piso"].ToString();
			strBarrioEmpresa= ds.Tables[0].Rows[0]["Barrio"].ToString().Trim();
			strCPEmpresa= ds.Tables[0].Rows[0]["CP"].ToString();
			if (ds.Tables[0].Rows[0]["idLocalidad"].ToString().CompareTo("")==0)
				intLocalidadEmpresa=-1;
			else
				intLocalidadEmpresa= int.Parse(ds.Tables[0].Rows[0]["idLocalidad"].ToString());

			if (ds.Tables[0].Rows[0]["idProvincia"].ToString().CompareTo("")==0)
				intProvinciaEmpresa=-1;
			else
				intProvinciaEmpresa= int.Parse(ds.Tables[0].Rows[0]["idProvincia"].ToString());
            strObservaciones = ds.Tables[0].Rows[0]["Observaciones"].ToString().Trim();
		}

		#endregion

		#region DataTable ListaEmpresas(int tipofiltro, string filtro)

		public DataTable ListaEmpresas(int tipofiltro, string filtro)
		{			
			OdbcConnection oConnection = this.OpenConnection();
			DataSet ds = new DataSet();
            String strSQL = "SELECT *, (calle + ' ' + nro) as direccion from Empresas ";
			if (filtro.CompareTo("")!=0)
			{
                if (tipofiltro == 1)
                {
                    // Si busco una razones sociales que empiecen con Ñ
                    if (filtro.Substring(0).ToUpper().CompareTo("Ñ") == 0)
                        strSQL += "WHERE ASCII(razonSocial)='209' OR ASCII(razonSocial)='241'";
                    else
                        strSQL += "WHERE razonSocial like '%" + filtro + "%' ";
                }
                else
                {
                    {
                        // Si busco una calle que empiecen con Ñ
                        if (filtro.Substring(0).ToUpper().CompareTo("Ñ") == 0)
                            strSQL += "WHERE ASCII(calle)='209' OR ASCII(calle)='241'";
                        else
                            strSQL += "WHERE calle like '%" + filtro + "%' ";
                    }                
                }
			}
			else
			{
				// Traigo todos las empresas cuyas razones sociales no empiecen con una letra
				strSQL+="WHERE (ASCII(razonSocial) <'65' OR ASCII(razonSocial)>'90') ";
				strSQL+="AND (ASCII(razonSocial)<'97' OR ASCII(razonSocial)>'122') ";								
				strSQL+="AND ASCII(razonSocial)!='209' AND ASCII(razonSocial)!='241' ";
			}
			strSQL = strSQL + " ORDER BY razonSocial";
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

        #region DataTable ListaEmpresasFantasia(string filtro)

        public DataTable ListaEmpresasFantasia(string filtro)
        {
            OdbcConnection oConnection = this.OpenConnection();
            DataSet ds = new DataSet();
            String strSQL = "SELECT * from Empresas ";
            if (filtro.CompareTo("") != 0)
            {
                // Si busco un nombre de fantasia que empiecen con Ñ
                if (filtro.Substring(0).ToUpper().CompareTo("Ñ") == 0)
                    strSQL += "WHERE ASCII(nombreFantasia)='209' OR ASCII(nombreFantasia)='241'";
                else
                    strSQL += "WHERE nombreFantasia like '" + filtro + "%' ";
            }
            else
            {
                // Traigo todos las empresas cuyos nombres de fantasia no empiecen con una letra
                strSQL += "WHERE (ASCII(nombreFantasia) <'65' OR ASCII(nombreFantasia)>'90') ";
                strSQL += "AND (ASCII(nombreFantasia)<'97' OR ASCII(nombreFantasia)>'122') ";
                strSQL += "AND ASCII(nombreFantasia)!='209' AND ASCII(nombreFantasia)!='241' ";
            }
            strSQL = strSQL + " ORDER BY nombreFantasia";
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

		#region DataTable listarEmpresasPorNombre()

		public DataTable listarEmpresasPorNombre()
		{
			OdbcConnection oConnection = this.OpenConnection();
			DataSet ds = new DataSet();
			String strSQL ="";
			strSQL+="SELECT RazonSocial, idEmpresa";
			strSQL+=" FROM Empresas";
			strSQL+=" ORDER BY RazonSocial";
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

		#endregion		
	}
}
