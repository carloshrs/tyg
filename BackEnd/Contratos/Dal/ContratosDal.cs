using System;
using System.Data;
using System.Data.Odbc;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;

namespace ar.com.TiempoyGestion.BackEnd.Contratos.Dal
{
	/// <summary>
	/// Summary description for ClienteDal.
	/// </summary>
	public class ContratosDal : GenericDal
	{
		#region Atributos y Contructores
		
		public ContratosDal() : base()
		{		}

		#endregion

		#region Propiedades
		#endregion

		#region Métodos Publicos


		public DataTable ListaContratos(String SQLWhere)
		{
			
			OdbcConnection oConnection = this.OpenConnection();
			DataSet ds = new DataSet();
			String strSQL = "SELECT C.idContrato, C.Numero, C.Descripcion, C.idCliente, C.idTipo, C.idUsuario, ";
			strSQL = strSQL + " fechainicio, fechafin, L.RazonSocial, ";
			strSQL = strSQL + " T.Descripcion as TIDescripcion FROM Contratos C, tipocontrato T, Clientes L";
			strSQL = strSQL + " WHERE T.idTipoContrato = C.idTipo ";
			strSQL = strSQL + " AND L.idcliente = C.idcliente ";
			if (SQLWhere != "") strSQL = strSQL + SQLWhere;
			strSQL = strSQL + " ORDER BY idContrato ";
			OdbcDataAdapter myConsulta = new OdbcDataAdapter(strSQL, oConnection);
			myConsulta.Fill(ds);
			try
			{
				
				oConnection.Close();
			} 			
			catch {}
			
			return ds.Tables[0];

		}

		public DataTable ListaContratosInforme(String Numero, int Tipo)
		{
			
			OdbcConnection oConnection = this.OpenConnection();
			DataSet ds = new DataSet();

			String strSQL = "SELECT C.idContrato, Numero, C.Descripcion, C.idCliente, C.idTipo, idUsuario,";
			strSQL = strSQL + " fechainicio, fechafin,  T.Descripcion as TIDescripcion, TP.Descripcion as TipoPersona";
			strSQL = strSQL + " FROM Contratos C, tipocontrato T, personascontrato P, tipopersona TP";
			strSQL = strSQL + " WHERE T.idTipoContrato = C.idTipo";
			strSQL = strSQL + " AND C.idContrato = P.idContrato";
			strSQL = strSQL + " AND TP.idTipo = P.idTipo";
			if (Tipo == -1) // Empresa
			{
				strSQL = strSQL + " AND Cuit = '" + Numero + "'" ;
			} 
			else 
			{ // Persona
				strSQL = strSQL + " AND NumeroDNI = '" + Numero + "'" ;
				strSQL = strSQL + " AND tipoDNI = " + Tipo.ToString() ;
			}
			strSQL = strSQL + " ORDER BY idContrato";
			OdbcDataAdapter myConsulta = new OdbcDataAdapter(strSQL, oConnection);
			myConsulta.Fill(ds);
			try
			{
				
				oConnection.Close();
			} 			
			catch {}
			
			return ds.Tables[0];

		}

		
		public DataTable TraerTipoContrato()
		{
			
			OdbcConnection oConnection = this.OpenConnection();
			DataSet ds = new DataSet();
			String strSQL = "SELECT Descripcion, idTipoContrato FROM tipoContrato";
			OdbcDataAdapter myConsulta = new OdbcDataAdapter(strSQL, oConnection);
			myConsulta.Fill(ds);
			try
			{
				
				oConnection.Close();
			} 			
			catch {}
			
			return ds.Tables[0];

		}

		public DataTable TraerTipoPersona()
		{
			
			OdbcConnection oConnection = this.OpenConnection();
			DataSet ds = new DataSet();
			String strSQL = "SELECT Descripcion, idTipo FROM tipoPersona";
			OdbcDataAdapter myConsulta = new OdbcDataAdapter(strSQL, oConnection);
			myConsulta.Fill(ds);
			try
			{
				
				oConnection.Close();
			} 			
			catch {}
			
			return ds.Tables[0];

		}
		
		public DataTable CargarPersonasContratos(int idContrato)
		{
			
			OdbcConnection oConnection = this.OpenConnection();
			DataSet ds = new DataSet();
			String strSQL = "SELECT P.*, T.descripcion as Tipo, TD.descripcion as txttipodni from PersonasContrato P, tipopersona T, TipoDocumento TD";
			strSQL = strSQL + " WHERE  P.idtipo = T.idTipo ";
			strSQL = strSQL + " AND  TD.idtipodocumento = P.TipoDNI ";
			strSQL = strSQL + " AND P.idContrato = " + idContrato;
			strSQL = strSQL + " order by idPersona";
			OdbcDataAdapter myConsulta = new OdbcDataAdapter(strSQL, oConnection);
			myConsulta.Fill(ds);
			try
			{
				
				oConnection.Close();
			} 			
			catch {}
			
			return ds.Tables[0];

		}
		
		public DataTable ListaHistorico(int idContrato)
		{
			
			OdbcConnection oConnection = this.OpenConnection();
			DataSet ds = new DataSet();
			String strSQL = "SELECT id, descripcion, idContrato, fecha FROM historialcontratos ";
			strSQL = strSQL + " WHERE idContrato = " + idContrato;
			strSQL = strSQL + " ORDER BY fecha ";
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

		#region Métodos Privados
		#endregion

	}
}
