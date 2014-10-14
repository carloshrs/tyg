using System;
using System.Data;
using System.Text;
using ar.com.TiempoyGestion.BackEnd.Contratos.Dal;

namespace ar.com.TiempoyGestion.BackEnd.Contratos.App
{
	/// <summary>
	/// Summary description for ClienteDal.
	/// </summary>
	public class ContratosApp
	{
		#region Atributos y Contructores
		
		public ContratosApp() : base()
		{		}

		#endregion

		#region Propiedades
	

		#endregion

		#region Métodos Publicos


		public DataTable ListaContratos(int tipo, String Texto, int idCliente, String FechaDesde, String FechaHasta, bool Extranet)
		{
			String SQLWhere = "";
			if (tipo != -1) {
				SQLWhere = "AND idTipo = " + tipo.ToString();
			}

			if (Texto != "") {
				SQLWhere = SQLWhere + " AND (C.Descripcion like '%" + Texto + "%' ";
				SQLWhere = SQLWhere + " OR C.Numero like '%" + Texto + "%' )";
			}
			
			if (idCliente != -1) 
			{
				SQLWhere = SQLWhere + " AND C.idCliente = " + idCliente.ToString();
			}


			if (FechaDesde != "") 
			{
				SQLWhere = SQLWhere + " AND FechaInicio >= '" + FechaDesde + "'";
			} 

			if (FechaHasta != "") 
			{
				SQLWhere = SQLWhere + " AND FechaFin <= '" + FechaHasta + "'";
			} 

			ContratosDal contratos = new ContratosDal();
			DataTable Datos = contratos.ListaContratos(SQLWhere);
			return Datos;
		}

		
		public StringBuilder ImprimirInforme(String DNI, int TipoDNI)
		{
			StringBuilder Grupos = new StringBuilder(2000);
			ContratosDal contratos = new ContratosDal();
			string[] fecha;
			string txtfecha;

			Grupos.Append("<table cellSpacing='0' cellPadding='0' width='100%' border='1' style='BORDER-COLLAPSE:collapse'>");
			Grupos.Append("<TR><TD>");
			// Contratos
				DataTable Groups = contratos.ListaContratosInforme(DNI, TipoDNI);
				Grupos.Append("<table cellSpacing='0' cellPadding='0' width='100%' border='1' style='BORDER-COLLAPSE:collapse'>");
				if (Groups.Rows.Count != 0) 
				{
					Grupos.Append("<TR>");
					Grupos.Append("	<TD class='titlesmall' height='20px' align='center' bgcolor='#E3E2DE'>&nbsp;Código&nbsp;</TD>");
					Grupos.Append("	<TD class='titlesmall' bgcolor='#E3E2DE'>&nbsp;Tipo Contrato</TD>");
					Grupos.Append("	<TD class='titlesmall' bgcolor='#E3E2DE'>&nbsp;Número Contrato</TD>");
					Grupos.Append("	<TD class='titlesmall' bgcolor='#E3E2DE'>&nbsp;En caracter de...</TD>");
					Grupos.Append("	<TD class='titlesmall' bgcolor='#E3E2DE'>&nbsp;Fecha Inicio</TD>");
					Grupos.Append("	<TD class='titlesmall' bgcolor='#E3E2DE'>&nbsp;Fecha Fin</TD>");
					Grupos.Append("</TR>");
					foreach(DataRow myRow in Groups.Rows)
					{
						Grupos.Append("<TR>");
						Grupos.Append("<TD class='text' align='center' width='15px' height='25px'>" + myRow["idContrato"].ToString()+ "</TD>");
						Grupos.Append("<TD class='text' width='100px'>&nbsp;" + myRow["TIDescripcion"].ToString()+ "</TD>");
						Grupos.Append("<TD class='text' width='60px'>&nbsp;" + myRow["Numero"].ToString()+ "</TD>");
						Grupos.Append("<TD class='text' width='80px'>&nbsp;<B>" + myRow["TipoPersona"].ToString()+ "</B></TD>");

						fecha = myRow["Fechainicio"].ToString().Remove(9,myRow["Fechainicio"].ToString().Length -9).Split("/".ToCharArray());
						txtfecha = fecha[1] + "/" + fecha[0] + "/" + fecha[2];
								
						Grupos.Append("<TD class='text' align='center' width='50px'>" + txtfecha + "</TD>");
								
						fecha = myRow["Fechafin"].ToString().Remove(9,myRow["Fechafin"].ToString().Length -9).Split("/".ToCharArray());
						txtfecha = fecha[1] + "/" + fecha[0] + "/" + fecha[2];

						Grupos.Append("<TD class='text' align='center' width='50px'>" + txtfecha + "</TD>");
						Grupos.Append("</TR>");

						// Contratos
						DataTable Mora = contratos.ListaHistorico(int.Parse(myRow["idContrato"].ToString()));
						if (Mora.Rows.Count != 0) 
						{
							Grupos.Append("<TR>");
							Grupos.Append("<TD class='text' width='15px'><img src='/img/shim.gif' widht='5'></TD>");
							Grupos.Append("<TD class='text' colspan='5'>");
							Grupos.Append("<table cellSpacing='0' cellPadding='0' width='100%' border='1' style='BORDER-COLLAPSE:collapse'>");
							Grupos.Append("<TR>");
							Grupos.Append("	<TD class='titlesmall' align='center' bgcolor='#E3E2DE' height='20px'>&nbsp;Código&nbsp;</TD>");
							Grupos.Append("	<TD class='titlesmall' bgcolor='#E3E2DE'>&nbsp;Fecha&nbsp;</TD>");
							Grupos.Append("	<TD class='titlesmall' bgcolor='#E3E2DE'>&nbsp;Descripción</TD>");
							Grupos.Append("</TR>");
							foreach(DataRow myRowMora in Mora.Rows)
							{
								Grupos.Append("<TR>");
								Grupos.Append("<TD class='text' align='center'  width='25px' height='15px'>&nbsp;" + myRowMora["id"].ToString()+ "</TD>");

								fecha = myRowMora["fecha"].ToString().Remove(9,myRowMora["fecha"].ToString().Length -9).Split("/".ToCharArray());
								txtfecha = fecha[1] + "/" + fecha[0] + "/" + fecha[2];
								Grupos.Append("<TD class='text' align='center'  width='40px'>&nbsp;" + txtfecha + "&nbsp;</TD>");

								Grupos.Append("<TD class='text'>&nbsp;" + myRowMora["Descripcion"].ToString()+ "</TD>");
											
								Grupos.Append("</TR>");
							}
							Grupos.Append("</TABLE>");
							Grupos.Append("</TD>");
							Grupos.Append("</TR>");
							Grupos.Append("<TR>");
							Grupos.Append("<TD colspan='6' class='text'><img src='/img/shim.gif' widht='5' height='20'></TD>");
							Grupos.Append("</TR>");

						}
					}
				} else {
					Grupos.Append("<TR>");
					Grupos.Append("	<TD class='titlesmall'>&nbsp;&nbsp;No hay información Contractual disponible.</TD>");
					Grupos.Append("</TR>");
				}

				Grupos.Append("</TABLE>");
			Grupos.Append("</TD></TR>");
			Grupos.Append("<TR><TD colspan='2'>&nbsp;</TD></TR>");
			Grupos.Append("</TABLE>");

			return Grupos;

		}

		#endregion

		#region Métodos Privados
		#endregion

	}
}
