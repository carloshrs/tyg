using System;
using System.Data;
using System.Data.Odbc;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;
using ar.com.TiempoyGestion.BackEnd.Clientes.App;

namespace ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal
{
	/// <summary>
	/// Summary description for ClienteDal.
	/// </summary>
	public class PersonasAPP : GenericDal
	{
		#region Atributos y Contructores
			
		private int intIdPersona;
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


		public PersonasAPP() : base()
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

		

		#endregion

		#region Métodos Publicos

		#region bool Crear()

		public bool Crear()
		{

            OdbcConnection oConnection = this.OpenConnection();
            OdbcDataAdapter myConsulta;
            DataTable dt = new DataTable();
            myConsulta = new OdbcDataAdapter("SELECT Nombre, Apellido FROM Personas WHERE dni = " + int.Parse(strDocumento), oConnection);
            myConsulta.Fill(dt);
            if (dt.Rows.Count > 0) { return false; }

			String strSQL = "Insert into Personas (Nombre, Apellido, ";
			strSQL = strSQL  + "EstadoCivil, Tipodni, DNI, Calle, Nro, Dpto, Piso, Barrio, CP, idLocalidad, idProvincia) ";
            strSQL = strSQL + " values ('" + Nombre + "','" + Apellido.Replace("'", "''") + "',";
			
			strSQL = strSQL  + intEstadoCivil + "," + intTipoDocumento + ",'" + strDocumento;
            strSQL = strSQL + "','" + strCalle + "','" + strNro + "','" + strDpto + "','" + strPiso + "','" + strBarrio + "','" + strCP + "'," + intLocalidad.ToString() + "," + intProvincia.ToString() + ")";

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

		#endregion

		#region ListaPersonas (string filtro)

		public DataTable ListaPersonas(string filtro)
		{
			
			OdbcConnection oConnection = this.OpenConnection();
			DataSet ds = new DataSet();						                     
			String strSQL ="SELECT idPersona, Apellido, Nombre, Tipodni, DNI, descripcion ";			
			strSQL+="FROM   Personas ";
			strSQL+="INNER JOIN TipoDocumento ";
			strSQL+="ON Tipodni=idTipoDocumento ";
			if (filtro.CompareTo("")!=0)
			{
				// Si busco apellido que empiecen con Ñ
				if (filtro.Substring(0).ToUpper().CompareTo("Ñ")==0)
					strSQL+="WHERE ASCII(apellido)='209' OR ASCII(apellido)='241'";					
				else
					strSQL+="WHERE Apellido like '"+filtro+"%' ";	
			}
			else
			{
				// Traigo todos las personas cuyos apellidos no empiecen con una letra
				strSQL+="WHERE (ASCII(apellido)<'65' OR ASCII(apellido)>'90') ";
				strSQL+="AND (ASCII(apellido)<'97' OR ASCII(apellido)>'122') ";								
				strSQL+="AND ASCII(apellido)!='209' AND ASCII(apellido)!='241' ";
			}
			strSQL+=" ORDER BY Apellido, Nombre";
			OdbcDataAdapter myConsulta = new OdbcDataAdapter(strSQL, oConnection);
			myConsulta.Fill(ds);
			try
			{
				
				oConnection.Close();
			} 			
			catch {}
			
			return ds.Tables[0];

		}

		#endregion

		#region bool Modificar(int idPersona)

		public bool Modificar(int idPersona)
		{
			OdbcConnection oConnection = this.OpenConnection();
			String strSQL = "UPDATE Personas SET ";
			// Datos Personales y Domicilio
			strSQL = strSQL  + "Nombre = '" + strNombre + "', Apellido = '" + strApellido + "', " ;
			strSQL = strSQL  + "EstadoCivil  = " + intEstadoCivil.ToString() + ", Tipodni = " + intTipoDocumento.ToString() + ", DNI = '" + strDocumento + "', ";  
			strSQL = strSQL  + "Calle = '" + strCalle + "', Nro = '" + strNro + "', Dpto = '" + strDpto + "', ";
			strSQL = strSQL  + "Piso = '" + strPiso + "', Barrio = '" + strBarrio + "', CP = '" + strCP + "', idLocalidad = " + intLocalidad + ", idProvincia = " + intProvincia;
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

		#endregion

		#region void Cargar(int idPersona)

		public void Cargar(int idPersona)
		{
			
			OdbcConnection oConnection = this.OpenConnection();
			DataSet ds = new DataSet();
			String strSQL = "SELECT * ";
			strSQL = strSQL + " FROM Personas ";
			strSQL = strSQL + " WHERE idPersona = " + idPersona.ToString();
			OdbcDataAdapter myConsulta = new OdbcDataAdapter(strSQL, oConnection);
			myConsulta.Fill(ds);
			try
			{
				oConnection.Close();
			} 			
			catch {}

			intIdPersona = int.Parse(ds.Tables[0].Rows[0]["IdPersona"].ToString()); 

			strNombre = ds.Tables[0].Rows[0]["Nombre"].ToString();
			strApellido = ds.Tables[0].Rows[0]["Apellido"].ToString();
			intEstadoCivil = int.Parse(ds.Tables[0].Rows[0]["EstadoCivil"].ToString());
			intTipoDocumento = int.Parse(ds.Tables[0].Rows[0]["TipoDni"].ToString());
			strDocumento = ds.Tables[0].Rows[0]["DNI"].ToString();
			strCalle = ds.Tables[0].Rows[0]["Calle"].ToString();
			strNro = ds.Tables[0].Rows[0]["Nro"].ToString();
			strDpto = ds.Tables[0].Rows[0]["Dpto"].ToString();
			strPiso = ds.Tables[0].Rows[0]["Piso"].ToString();
			strBarrio = ds.Tables[0].Rows[0]["Barrio"].ToString();
			strCP = ds.Tables[0].Rows[0]["CP"].ToString();
			intLocalidad = int.Parse(ds.Tables[0].Rows[0]["idLocalidad"].ToString());
			intProvincia = int.Parse(ds.Tables[0].Rows[0]["idProvincia"].ToString());
		
		}

		#endregion

		#region bool Eliminar(int idPersona)

		public bool Eliminar(int idPersona)
		{
			OdbcConnection oConnection = this.OpenConnection();
			String strSQLPersonas = "Delete from Personas WHERE idPersona = " + idPersona.ToString();
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

		#endregion	
	}
}
