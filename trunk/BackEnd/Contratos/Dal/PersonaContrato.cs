using System;
using System.Data;
using System.Data.Odbc;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;

namespace ar.com.TiempoyGestion.BackEnd.Contratos.Dal
{
	/// <summary>
	/// Summary description for ClienteDal.
	/// </summary>
	public class PersonaContratoAPP : GenericDal
	{
		#region Atributos y Contructores
			
		private int intIdPersona;
		private int intIdTipo;

		private int intIdTipoPersona;

		private int intidContrato;
		private String strNombre;
		private String strApellido;
		private int intEstadoCivil;
		private int intTipoDocumento;
		private String strDocumento;
		private String strCalle;
		private String strNro;
		private String strDpto;
		private String strPiso;
		private String strBarrio;
		private String strCP;
		private int intLocalidad;
		private int intProvincia;

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
		private int intLocalidadEmpresa = 67;
		private int intProvinciaEmpresa = 23;




		public PersonaContratoAPP() : base()
		{		}

		#endregion

		#region Propiedades
		public int IdPersona
		{
			get
			{
				return intIdPersona;
			}
			set
			{
				intIdPersona = value;
			}
		}
		public int IdTipo
		{
			get
			{
				return intIdTipo;
			}
			set
			{
				intIdTipo = value;
			}
		}

		public int idContrato
		{
			get
			{
				return intidContrato;
			}
			set
			{
				intidContrato = value;
			}
		}

		public int IdTipoPersona
		{
			get
			{
				return intIdTipoPersona;
			}
			set
			{
				intIdTipoPersona = value;
			}
		}

		public String Nombre
		{
			get
			{
				return strNombre;
			}
			set
			{
				strNombre = value;
			}
		}
		public String Apellido
		{
			get
			{
				return strApellido;
			}
			set
			{
				strApellido = value;
			}
		}
		public int EstadoCivil
		{
			get
			{
				return intEstadoCivil;
			}
			set
			{
				intEstadoCivil = value;
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

		public String Documento
		{
			get
			{
				return strDocumento;
			}
			set
			{
				strDocumento = value;
			}
		}
		public String Calle
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
		public String Nro
		{
			get
			{
				return strNro;
			}
			set
			{
				strNro = value;
			}
		}
		public String Dpto
		{
			get
			{
				return strDpto;
			}
			set
			{
				strDpto = value;
			}
		}
		public String Piso
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
		public String Barrio
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
		public String CP
		{
			get
			{
				return strCP;
			}
			set
			{
				strCP = value;
			}
		}
		public int Localidad
		{
			get
			{
				return intLocalidad;
			}
			set
			{
				intLocalidad = value;
			}
		}
		public int Provincia
		{
			get
			{
				return intProvincia;
			}
			set
			{
				intProvincia = value;
			}
		}

		// EMPRESA
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
		

		#endregion

		#region Métodos Publicos

		

		public bool Crear()
		{
			OdbcConnection oConnection = this.OpenConnection();
			String strSQL = "Insert into PersonasContrato (idTipo, idContrato, IdTipoPersona, Nombre, Apellido, ";
			strSQL = strSQL  + "EstadoCivil, Tipodni, NumeroDNI, Calle, Nro, Dpto, Piso, Barrio, CP, idLocalidad, idProvincia, ";
			strSQL = strSQL  + "RazonSocial, NombreFantasia, TelefonoEmpresa, Rubro, Cuit, CalleEmpresa, NroEmpresa, DptoEmpresa, PisoEmpresa, BarrioEmpresa, CPEmpresa, LocalidadEmpresa, ProvinciaEmpresa)";
			strSQL = strSQL  + " values (" + intIdTipo.ToString() + "," + intidContrato.ToString() + "," + intIdTipoPersona.ToString() + ",'" + Nombre + "','" + Apellido + "',";
			
			strSQL = strSQL  + intEstadoCivil + "," + intTipoDocumento + ",'" + strDocumento;
			strSQL = strSQL  + "','" + strCalle + "','" + strNro + "','" + strDpto  + "','" + strPiso  + "','" + strBarrio  + "','" + strCP  + "'," + intLocalidad.ToString()  + "," + intProvincia.ToString(); 
			strSQL = strSQL  + ",'" + strRazonSocial + "','" + strNombreFantasia + "','" + strTelefonoEmpresa + "','" + strRubro + "','" +	strCuit + "','" + strCalleEmpresa + "','" + strNroEmpresa + "','" + strDptoEmpresa + "','" + strPisoEmpresa + "','" + strBarrioEmpresa + "','" + strCPEmpresa + "'," + intLocalidadEmpresa + "," + intProvinciaEmpresa + ")"; 	

			try
			{
				OdbcCommand	myCommand = new OdbcCommand(strSQL, oConnection);
				myCommand.ExecuteNonQuery();

				oConnection.Close();
			} 			
			catch (Exception e)
			{	
				string p = e.Message;
				return false;
			}
			return true;
		}

		public bool Modificar(int idPersona)
		{
			OdbcConnection oConnection = this.OpenConnection();
			String strSQL = "UPDATE PersonasContrato SET ";
			// Datos Personales y Domicilio
			strSQL = strSQL  + "idTipo = " + intIdTipo + ",idTipoPersona = " + intIdTipoPersona + ", Nombre = '" + strNombre + "', Apellido = '" + strApellido + "', " ;
			strSQL = strSQL  + "EstadoCivil  = " + intEstadoCivil.ToString() + ", Tipodni = " + intTipoDocumento.ToString() + ", NumeroDNI = '" + strDocumento + "', ";  
			strSQL = strSQL  + "Calle = '" + strCalle + "', Nro = '" + strNro + "', Dpto = '" + strDpto + "', ";
			strSQL = strSQL  + "Piso = '" + strPiso + "', Barrio = '" + strBarrio + "', CP = '" + strCP + "', idLocalidad = " + intLocalidad + ", idProvincia = " + intProvincia;
			strSQL = strSQL  + ",RazonSocial = '" + strRazonSocial + "', NombreFantasia = '" + strNombreFantasia + "', TelefonoEmpresa = '" + strTelefonoEmpresa + "', Rubro = '" + strRubro + "', Cuit = '" + strCuit + "', CalleEmpresa = '" + strCalleEmpresa + "', NroEmpresa = '" + strNroEmpresa + "', DptoEmpresa = '" + strDptoEmpresa + "', PisoEmpresa = '" + strPisoEmpresa + "', BarrioEmpresa = '" + strBarrioEmpresa + "', CPEmpresa = '" + strCPEmpresa + "', LocalidadEmpresa = " + intLocalidadEmpresa + ", ProvinciaEmpresa = " + intProvinciaEmpresa;
			strSQL = strSQL  + " WHERE idPersona =  " + idPersona.ToString();

			try
			{
				OdbcCommand	myCommand = new OdbcCommand(strSQL, oConnection);
				myCommand.ExecuteNonQuery();

				oConnection.Close();
			} 			
			catch (Exception e)
			{	
				string p = e.Message;
				return false;
			}
			return true;
		}

		public void Cargar(int idPersona)
		{
			
			OdbcConnection oConnection = this.OpenConnection();
			DataSet ds = new DataSet();
			String strSQL = "SELECT * ";
			strSQL = strSQL + " FROM PersonasContrato ";
			strSQL = strSQL + " WHERE idPersona = " + idPersona.ToString();
			OdbcDataAdapter myConsulta = new OdbcDataAdapter(strSQL, oConnection);
			myConsulta.Fill(ds);
			try
			{
				oConnection.Close();
			} 			
			catch {}

			intIdPersona = int.Parse(ds.Tables[0].Rows[0]["IdPersona"].ToString()); 
			intIdTipo = int.Parse(ds.Tables[0].Rows[0]["idTipo"].ToString());
			intidContrato = int.Parse(ds.Tables[0].Rows[0]["idContrato"].ToString());
			intIdTipoPersona = int.Parse(ds.Tables[0].Rows[0]["IdTipoPersona"].ToString()); 

			strNombre = ds.Tables[0].Rows[0]["Nombre"].ToString();
			strApellido = ds.Tables[0].Rows[0]["Apellido"].ToString();
			intEstadoCivil = int.Parse(ds.Tables[0].Rows[0]["EstadoCivil"].ToString());
			intTipoDocumento = int.Parse(ds.Tables[0].Rows[0]["TipoDni"].ToString());
			strDocumento = ds.Tables[0].Rows[0]["NumeroDNI"].ToString();
			strCalle = ds.Tables[0].Rows[0]["Calle"].ToString();
			strNro = ds.Tables[0].Rows[0]["Nro"].ToString();
			strDpto = ds.Tables[0].Rows[0]["Dpto"].ToString();
			strPiso = ds.Tables[0].Rows[0]["Piso"].ToString();
			strBarrio = ds.Tables[0].Rows[0]["Barrio"].ToString();
			strCP = ds.Tables[0].Rows[0]["CP"].ToString();
			intLocalidad = int.Parse(ds.Tables[0].Rows[0]["idLocalidad"].ToString());
			intProvincia = int.Parse(ds.Tables[0].Rows[0]["idProvincia"].ToString());

			//EMPRESAS
			strRazonSocial= ds.Tables[0].Rows[0]["RazonSocial"].ToString();
			strNombreFantasia= ds.Tables[0].Rows[0]["NombreFantasia"].ToString();
			strTelefonoEmpresa= ds.Tables[0].Rows[0]["TelefonoEmpresa"].ToString();
			strRubro= ds.Tables[0].Rows[0]["Rubro"].ToString();
			strCuit= ds.Tables[0].Rows[0]["Cuit"].ToString();
			strCalleEmpresa= ds.Tables[0].Rows[0]["CalleEmpresa"].ToString();
			strNroEmpresa= ds.Tables[0].Rows[0]["NroEmpresa"].ToString();
			strDptoEmpresa= ds.Tables[0].Rows[0]["DptoEmpresa"].ToString();
			strPisoEmpresa= ds.Tables[0].Rows[0]["PisoEmpresa"].ToString();
			strBarrioEmpresa= ds.Tables[0].Rows[0]["BarrioEmpresa"].ToString();
			strCPEmpresa= ds.Tables[0].Rows[0]["CPEmpresa"].ToString();
			intLocalidadEmpresa= int.Parse(ds.Tables[0].Rows[0]["LocalidadEmpresa"].ToString());
			intProvinciaEmpresa= int.Parse(ds.Tables[0].Rows[0]["ProvinciaEmpresa"].ToString());

		}

		public bool Eliminar(int idPersona)
		{
			OdbcConnection oConnection = this.OpenConnection();
			String strSQLPersonas = "Delete from PersonasContrato WHERE idPersona = " + idPersona.ToString();
			try
			{
				OdbcCommand	myCommand = new OdbcCommand(strSQLPersonas, oConnection);
				myCommand.ExecuteNonQuery();
				
				oConnection.Close();
			} 			
			catch 
			{
				return false;
			}
			return true;
		}


		#endregion

		#region Métodos Privados
		#endregion

	}
}
