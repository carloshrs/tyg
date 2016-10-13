using System;
using System.Data;
using System.Text;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;

namespace ar.com.TiempoyGestion.BackEnd.InboxSuport.App
{
	/// <summary>
	/// Summary description for ClienteDal.
	/// </summary>
	public class BandejaEntradaApp
	{
		#region Atributos y Contructores
        private int intTotalRegistros = 0;
        private int intPaginas = 1;
        private int intRegPorPagina = 15;
        private int intPagina = 1;
		public BandejaEntradaApp() : base()
		{		}

		#endregion

		#region Propiedades
        public int RegPorPagina
        {
            set
            {
                intRegPorPagina = value;
            }
            get
            {
                return intRegPorPagina;
            }
        }
        public int Pagina
        {
            set
            {
                intPagina = value;
            }
            get
            {
                return intPagina;
            }
        }
        public int TotalRegistros
        {
            get
            {
                return intTotalRegistros;
            }
        }
        public int Paginas
        {
            get
            {
                return intPaginas;
            }
        }
        #endregion

		#region Métodos Publicos

		public int[] CargarDatos()
		{
			int[] MenuArray = new int[] {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
			BandejaEntradaDal bandeja = new BandejaEntradaDal();
			DataTable Datos = bandeja.TraerDatosMenu();
			foreach(DataRow myRow in Datos.Rows)
			{
				MenuArray[(int.Parse(myRow["idTipoInforme"].ToString()) - 1)] = int.Parse(myRow["Cantidad"].ToString());
			}
			
			return MenuArray;
		}


		public StringBuilder InformesEstadisticosHOME()
		{
			StringBuilder Grupos = new StringBuilder(2000);
			BandejaEntradaDal Bandeja = new BandejaEntradaDal();

			Grupos.Append("<table cellSpacing='0' cellPadding='0' width='450' border='1' style='BORDER-COLLAPSE:collapse'>");
			Grupos.Append("<TR><TD colspan='2'>");
			// Titulo
				Grupos.Append("<table cellSpacing='0' cellPadding='0' width='450' border='0'>");
					Grupos.Append("<TR><TD widht='10%'><img src='/img/inbox.jpg' widht='50' height='59'></TD>");
					Grupos.Append("<TD widht='90%' class='title'>Bandeja de Entrada</TD></TR>");
				Grupos.Append("</TABLE>");
			Grupos.Append("</TD></TR>");
			Grupos.Append("<TR><TD colspan='2'>");
			// Informes de Hoy
				DataTable Groups = Bandeja.GroupTiposInformesHoy();
				Grupos.Append("<table cellSpacing='0' cellPadding='0' width='450' border='1' style='BORDER-COLLAPSE:collapse'>");
				foreach(DataRow myRow in Groups.Rows)
				{
					Grupos.Append("<TR><TD class='titlesmall' bgcolor='#E3E2DE'>&nbsp;Informes Cargados Hoy: </TD>");
					Grupos.Append("<TD class='text' align='center'  width='50px'><B>&nbsp;" + myRow["Cantidad"].ToString()+ "</B></TD>");
					Grupos.Append("</TR>");
				}
				Grupos.Append("</TABLE>");
			Grupos.Append("</TD></TR>");
			Grupos.Append("<TR><TD colspan='2'>&nbsp;</TD></TR>");
			Grupos.Append("<TR><TD colspan='2'>");
			// Informes por Tipo Informe
				Groups = Bandeja.TraerDatos();
				Grupos.Append("<table cellSpacing='0' cellPadding='0' width='450' border='1' style='BORDER-COLLAPSE:collapse'>");
				Grupos.Append("<TR><TD class='titlesmall' bgcolor='#E3E2DE'>&nbsp;Tipos de Informes </TD>");
				Grupos.Append("<TD class='titlesmall' align='center' width='50px'  bgcolor='#E3E2DE'><B>&nbsp;Cant.&nbsp;</B></TD>");
				Grupos.Append("</TR>");
				foreach(DataRow myRow in Groups.Rows)
				{
					Grupos.Append("<TR><TD class='text'>&nbsp;<a href='/BandejaEntrada/Principal.aspx?idTipo=" + myRow["idTipoInforme"].ToString() + "' class='text'>" + myRow["Descripcion"].ToString()+ "</a></TD>");
					Grupos.Append("<TD class='text' align='center'><B>&nbsp;" + myRow["Cantidad"].ToString()+ "</B></TD>");
					Grupos.Append("</TR>");
				}
				Grupos.Append("</TABLE>");
			Grupos.Append("</TD></TR>");
			Grupos.Append("<TR><TD colspan='2'>&nbsp;</TD></TR>");
			Grupos.Append("<TR><TD colspan='2'>");
			// Informes por Estados
				Groups = Bandeja.GroupEstados();
				Grupos.Append("<table cellSpacing='0' cellPadding='0' width='450' border='1' style='BORDER-COLLAPSE:collapse'>");
				Grupos.Append("<TD class='titlesmall' bgcolor='#E3E2DE'>&nbsp;Estados</TD>");
				Grupos.Append("<TD class='titlesmall' bgcolor='#E3E2DE'  align='center' >&nbsp;Cant.&nbsp;</TD>");
				Grupos.Append("</TR>");
				foreach(DataRow myRow in Groups.Rows)
				{
					Grupos.Append("<TR><TD class='text' valign='middle'>&nbsp;<img src='/img/Estado" + myRow["idEstado"].ToString() + ".gif' widht='14' height='14' border='0'>&nbsp;&nbsp;&nbsp;" + myRow["Estado"].ToString()+ "</TD>");
					Grupos.Append("<TD class='text' align='center' width='50px'><B>&nbsp;" + myRow["Cantidad"].ToString()+ "</B></TD>");
					Grupos.Append("</TR>");
				}
				Grupos.Append("</TABLE>");
			Grupos.Append("</TD></TR>");
			Grupos.Append("<TR><TD colspan='2'>&nbsp;</TD></TR>");
			Grupos.Append("<TR><TD colspan='2'>");
			// Informes por Tipos de Informes y Estados
				Groups = Bandeja.GroupTiposInformesEstados();
				Grupos.Append("<table cellSpacing='0' cellPadding='0' width='450' border='1' style='BORDER-COLLAPSE:collapse'>");
				Grupos.Append("<TR><TD class='titlesmall' bgcolor='#E3E2DE'>&nbsp;Tipos de Informes </TD>");
				Grupos.Append("<TD class='titlesmall' bgcolor='#E3E2DE'>&nbsp;Estados</TD>");
				Grupos.Append("<TD class='titlesmall' bgcolor='#E3E2DE'  align='center' >&nbsp;Cant.&nbsp;</TD>");
				Grupos.Append("</TR>");
				foreach(DataRow myRow in Groups.Rows)
				{
					Grupos.Append("<TR><TD class='text' width='200px'>&nbsp;" + myRow["TipoInforme"].ToString()+ "</TD>");
					Grupos.Append("<TD class='text'  width='200px'>&nbsp;" + myRow["Estado"].ToString()+ "</TD>");
					Grupos.Append("<TD class='text' align='center'  width='50px'><B>&nbsp;" + myRow["Cantidad"].ToString()+ "</B></TD>");
					Grupos.Append("</TR>");
				}
				Grupos.Append("</TABLE>");
			Grupos.Append("</TD></TR>");
			Grupos.Append("</TABLE>");

			return Grupos;

		}
			
			
		public DataTable ListaEncabezados(int tipo, String Texto, int idCliente, int Usuario, string Estado, int Caracter, String FechaDesde, String FechaHasta, int vRegPorPagina, bool Extranet)
		{
			String SQLWhere = "";
			if (tipo != -1)
                SQLWhere = SQLWhere + "AND B.idTipoInforme = " + tipo.ToString();

			if (Texto != "") {
				SQLWhere = SQLWhere + " AND (B.Nombre like '%" + Texto + "%' ";
				SQLWhere = SQLWhere + " OR B.Apellido like '%" + Texto + "%' ";
                SQLWhere = SQLWhere + " OR B.RazonSocial like '%" + Texto + "%' ";
                SQLWhere = SQLWhere + " OR B.RazonSocial like '%" + Texto + "%' ";
				SQLWhere = SQLWhere + " OR B.DescripcionInf like '%" + Texto + "%' )";
			}
			
			if (Usuario != -1) 
				SQLWhere = SQLWhere + " AND B.idUsuario = " + Usuario.ToString();

			if (idCliente != -1) 
				SQLWhere = SQLWhere + " AND B.idCliente = " + idCliente.ToString();

            if (Estado != "")
            {
                string[] Est = Estado.Split(",".ToCharArray());
                if (Est[0] != "-1")
                {
                    SQLWhere = SQLWhere + " AND ( ";
                    for (int i = 0; i < Est.Length; i++)
                    {
                        if (i < Est.Length && i > 0)
                            SQLWhere = SQLWhere + " OR ";
                        SQLWhere = SQLWhere + " B.Estado = " + Est[i].ToString();
                    }
                    SQLWhere = SQLWhere + ")";
                }
            }

            if (Caracter != -1)
                SQLWhere = SQLWhere + " AND B.Caracter = " + Caracter.ToString();
			/*else {
				if (Extranet) {
					SQLWhere = SQLWhere + " AND B.Estado in (1,5,9) ";
				}
			}*/



            if (FechaDesde != "")
                FechaDesde = "'" + FechaDesde + " 00:00:00.000'";
            else
            {
                FechaDesde = DateTime.Today.AddMonths(-3).ToShortDateString();
                FechaDesde = "'" + FechaDesde + " 00:00:00.000'";
            }
            

			
            if (FechaHasta != "")
                FechaHasta = "'" + FechaHasta + " 23:59:59.999'";
            else
            {
                FechaHasta = DateTime.Today.ToShortDateString();
                FechaHasta = "'" + FechaHasta + " 23:59:59.999'";
            }

            if (vRegPorPagina != 0)
                intRegPorPagina = vRegPorPagina;

            SQLWhere = SQLWhere + " AND B.FechaCarga BETWEEN '" + FechaDesde + "' AND '" + FechaHasta + "'";

			BandejaEntradaDal bandeja = new BandejaEntradaDal();
            DataTable Datos = bandeja.ListaEncabezados(SQLWhere, Pagina, intRegPorPagina);
            intTotalRegistros = bandeja.TotalRegistros;
            intPaginas = ((int)(intTotalRegistros / intRegPorPagina)) + 1;
			return Datos;
		}

        public DataTable ListaEncabezados(int idCliente, int Usuario, string Estado, string FechaDesde, string FechaHasta, int vRegPorPagina, int excepcion)
        {
            String SQLWhere = "";

            if (Usuario != -1)
                SQLWhere = SQLWhere + " AND B.idUsuario = " + Usuario.ToString();

            if (idCliente != -1)
                SQLWhere = SQLWhere + " AND B.idCliente = " + idCliente.ToString();

            if (Estado != "")
            {
                string[] Est = Estado.Split(",".ToCharArray());
                if (Est[0] != "-1")
                {
                    SQLWhere = SQLWhere + " AND ( ";
                    for (int i = 0; i < Est.Length; i++)
                    {
                        if (i < Est.Length && i > 0)
                            SQLWhere = SQLWhere + " OR ";
                        SQLWhere = SQLWhere + " B.Estado = " + Est[i].ToString();
                    }
                    SQLWhere = SQLWhere + ")";
                }
            }

            if (FechaDesde != "")
                FechaDesde = "'" + FechaDesde + " 00:00:00.000'";
            else
            {
                FechaDesde = DateTime.Today.AddMonths(-3).ToShortDateString();
                FechaDesde = "'" + FechaDesde + " 00:00:00.000'";
            }



            if (FechaHasta != "")
                FechaHasta = "'" + FechaHasta + " 23:59:59.999'";
            else
            {
                FechaHasta = DateTime.Today.ToShortDateString();
                FechaHasta = "'" + FechaHasta + " 23:59:59.999'";
            }

            if (vRegPorPagina != 0)
                intRegPorPagina = vRegPorPagina;

            SQLWhere = SQLWhere + " AND B.FechaCarga BETWEEN '" + FechaDesde + "' AND '" + FechaHasta + "'";

            if (excepcion != 0)
            {
                SQLWhere = SQLWhere + " AND B.idEncabezado NOT IN ( ";
                SQLWhere = SQLWhere + "SELECT bb.idEncabezado FROM remitoinforme ri ";
                SQLWhere = SQLWhere + "INNER JOIN bandejaentrada bb ON ri.idEncabezado=bb.idEncabezado ";
                SQLWhere = SQLWhere + "WHERE bb.idCliente = " + idCliente.ToString() + " ) ";

                SQLWhere = SQLWhere + " AND B.idEncabezado NOT IN ( ";
                SQLWhere = SQLWhere + "SELECT bb.idEncabezado FROM parteEntregaInforme ri ";
                SQLWhere = SQLWhere + "INNER JOIN bandejaentrada bb ON ri.idEncabezado=bb.idEncabezado ";
                SQLWhere = SQLWhere + "WHERE bb.idCliente = " + idCliente.ToString() + " ) ";
            }

            BandejaEntradaDal bandeja = new BandejaEntradaDal();
            DataTable Datos = bandeja.ListaEncabezados(SQLWhere, Pagina, RegPorPagina);
            return Datos;
        }

		public DataTable ListaEncabezados(int idReferencia)
		{
			String SQLWhere = "";
			if (idReferencia != -1) 
			{
				SQLWhere = "AND B.idReferencia = " + idReferencia.ToString();
			}

			BandejaEntradaDal bandeja = new BandejaEntradaDal();
			DataTable Datos = bandeja.ListaEncabezados(SQLWhere, Pagina, RegPorPagina);
			return Datos;
		}
		
		public DataTable TraerReferencias(String Texto, int idCliente, int Estado)
		{
			String SQLWhere = "";

			if (Texto != "") 
			{
				SQLWhere = SQLWhere + " AND (R.Descripcion like '%" + Texto + "%' ";
				SQLWhere = SQLWhere + " OR R.Observaciones like '%" + Texto + "%' )";
			}
		
			if (idCliente != -1) 
			{
				SQLWhere = SQLWhere + " AND R.idCliente = " + idCliente.ToString();
			}

			if (Estado != -1) 
			{
				SQLWhere = SQLWhere + " AND R.Estado = " + Estado.ToString();
			}
            else
            {
                SQLWhere = SQLWhere + " AND (R.Estado = 1 OR R.Estado = 2 OR R.Estado = 5) ";
            }

			BandejaEntradaDal bandeja = new BandejaEntradaDal();
            DataTable Datos = bandeja.TraerReferencias(SQLWhere, Pagina, RegPorPagina);
            intTotalRegistros = bandeja.TotalRegistros;
            intPaginas = ((int)(intTotalRegistros / intRegPorPagina)) + 1;

			return Datos;
	    }

        public string GetPaginador(int cantidadNros)
        {
            int mitad = (int)(cantidadNros / 2);
            int i;
            int inicio = 0;
            int comienzoCiclo = 0;
            int paginaActual = this.Pagina;

            String salida = "<div id=\"pagination-digg-bandeja\">";
            if (paginaActual != 1)
            {
                salida = salida + "<div class=\"previous-bandeja\"><a title=\"Primer p&aacute;gina\" href=\"javascript: paginadorIrA(1);\">&laquo;</a></div>";
                salida = salida + "<div class=\"previous-bandeja\"><a title=\"P&aacute;gina anterior\" href=\"javascript: paginadorIrA("+ (paginaActual-1) +");\">&lt;</a></div>";
            }
            if ((paginaActual + mitad) > Paginas)
                inicio = Paginas - paginaActual + cantidadNros;
            else
                inicio = mitad;
            if (paginaActual - inicio < 1)
                comienzoCiclo = 1;
            else
                comienzoCiclo = paginaActual - inicio + 1;
            for (i = comienzoCiclo; i < paginaActual; i++)
            {
                salida = salida + "<div style=\"float:left;\"><a href=\"javascript: paginadorIrA(" + i.ToString() + ");\">" + i.ToString() + "</a></div>";
            }
            i++;
            salida = salida + "<div class=\"active-bandeja\"><b>" + paginaActual.ToString() + "</b></div>";

            if ((paginaActual - mitad) < 1)
                inicio = cantidadNros;
            else
                inicio = paginaActual + mitad;
            
            if (inicio > Paginas)
                inicio = Paginas;
                        
            for(i=paginaActual+1; i < inicio; i++)
            {
                salida = salida + "<div class=\"next-bandeja\"><a href=\"javascript: paginadorIrA(" + i.ToString() + ");\">" + i.ToString() + "</a></div>";
            }

            if (paginaActual != Paginas)
            {
                salida = salida + "<div class=\"next-bandeja\"><a title=\"P&aacute;gina siguiente\" href=\"javascript: paginadorIrA(" + (paginaActual + 1) + ");\">&gt;</a></div>";
                salida = salida + "<div class=\"next-bandeja\"><a title=\"&Uacute;ltima p&aacute;gina\" href=\"javascript: paginadorIrA(" + this.Paginas + ");\">&raquo;</a></div>";
            }

            salida = salida + "</div>";
            return salida;
        }


        public DataTable ListaEncabezadosGrupos(int idCliente, int Usuario, int idTipoInforme, string Estado, int Caracter, String FechaDesde, String FechaHasta, int vRegPorPagina, bool Extranet, int idGrupo, string vVar) //vVar es variable opcional, ejemplo se usa en partidas defunción
        {
            String SQLWhere = "";
            SQLWhere = SQLWhere + " AND G.idTipoGrupo = " + idGrupo;
            SQLWhere = SQLWhere + " AND B.idTipoInforme = " + idTipoInforme;

            if (Usuario != -1)
                SQLWhere = SQLWhere + " AND B.idUsuario = " + Usuario.ToString();

            if (idCliente != -1)
                SQLWhere = SQLWhere + " AND B.idCliente = " + idCliente.ToString();

            if (Estado != "")
            {
                string[] Est = Estado.Split(",".ToCharArray());
                if (Est[0] != "-1")
                {
                    SQLWhere = SQLWhere + " AND ( ";
                    for (int i = 0; i < Est.Length; i++)
                    {
                        if (i < Est.Length && i > 0)
                            SQLWhere = SQLWhere + " OR ";
                        SQLWhere = SQLWhere + " B.Estado = " + Est[i].ToString();
                    }
                    SQLWhere = SQLWhere + ")";
                }
            }

            if (Caracter != -1)
                SQLWhere = SQLWhere + " AND B.Caracter = " + Caracter.ToString();
            else
            {
                if (Extranet)
                {
                    SQLWhere = SQLWhere + " AND B.Estado in (1,5) ";
                }
            }



            if (FechaDesde != "")
                FechaDesde = "'" + FechaDesde + " 00:00:00.000'";
            else
            {
                FechaDesde = DateTime.Today.AddMonths(-3).ToShortDateString();
                FechaDesde = "'" + FechaDesde + " 00:00:00.000'";
            }



            if (FechaHasta != "")
                FechaHasta = "'" + FechaHasta + " 23:59:59.999'";
            else
            {
                FechaHasta = DateTime.Today.ToShortDateString();
                FechaHasta = "'" + FechaHasta + " 23:59:59.999'";
            }

            // Partidas de defunción por sexo
            if (idTipoInforme == 19) 
            {
                if (vVar != "")
                {
                    if(vVar == "M")
                        SQLWhere = SQLWhere + " AND B.Sexo = 1 ";
                    else
                        SQLWhere = SQLWhere + " AND B.Sexo = 2 ";
                }
            }

            if (vRegPorPagina != 0)
                intRegPorPagina = vRegPorPagina;

            SQLWhere = SQLWhere + " AND B.FechaCarga BETWEEN '" + FechaDesde + "' AND '" + FechaHasta + "'";

            BandejaEntradaDal bandeja = new BandejaEntradaDal();
            DataTable Datos = bandeja.ListaEncabezadosGrupos(SQLWhere, Pagina, intRegPorPagina);
            intTotalRegistros = bandeja.TotalRegistros;
            intPaginas = ((int)(intTotalRegistros / intRegPorPagina)) + 1;
            return Datos;
        }



        public DataTable ListarHistorialInformesEnviados(int idTipoInforme)
        {
        
            BandejaEntradaDal bandeja = new BandejaEntradaDal();
            DataTable Datos = bandeja.ListarHistorialInformesEnviados(idTipoInforme);
            return Datos;
        }


        public DataTable ListaEncabezadosCondicionales(int idCliente, int Usuario, int idTipoInforme, string Estado, int Caracter, String FechaDesde, String FechaHasta, int vRegPorPagina, bool Extranet, int idEstadoCondicional)
        {
            String SQLWhere = "";
            SQLWhere = SQLWhere + " AND B.EstadoCondicional = " + idEstadoCondicional;
            SQLWhere = SQLWhere + " AND B.idTipoInforme = " + idTipoInforme;

            if (Usuario != -1)
                SQLWhere = SQLWhere + " AND B.idUsuario = " + Usuario.ToString();

            if (idCliente != -1)
                SQLWhere = SQLWhere + " AND B.idCliente = " + idCliente.ToString();

            if (Estado != "")
            {
                string[] Est = Estado.Split(",".ToCharArray());
                if (Est[0] != "-1")
                {
                    SQLWhere = SQLWhere + " AND ( ";
                    for (int i = 0; i < Est.Length; i++)
                    {
                        if (i < Est.Length && i > 0)
                            SQLWhere = SQLWhere + " OR ";
                        SQLWhere = SQLWhere + " B.Estado = " + Est[i].ToString();
                    }
                    SQLWhere = SQLWhere + ")";
                }
            }

            if (Caracter != -1)
                SQLWhere = SQLWhere + " AND B.Caracter = " + Caracter.ToString();
            else
            {
                if (Extranet)
                {
                    SQLWhere = SQLWhere + " AND B.Estado in (1,5) ";
                }
            }



            if (FechaDesde != "")
                FechaDesde = "'" + FechaDesde + " 00:00:00.000'";
            else
            {
                FechaDesde = DateTime.Today.AddMonths(-3).ToShortDateString();
                FechaDesde = "'" + FechaDesde + " 00:00:00.000'";
            }



            if (FechaHasta != "")
                FechaHasta = "'" + FechaHasta + " 23:59:59.999'";
            else
            {
                FechaHasta = DateTime.Today.ToShortDateString();
                FechaHasta = "'" + FechaHasta + " 23:59:59.999'";
            }

            if (vRegPorPagina != 0)
                intRegPorPagina = vRegPorPagina;

            SQLWhere = SQLWhere + " AND B.FechaCarga BETWEEN '" + FechaDesde + "' AND '" + FechaHasta + "'";

            BandejaEntradaDal bandeja = new BandejaEntradaDal();
            DataTable Datos = bandeja.ListaEncabezadosCondicionales(SQLWhere, Pagina, intRegPorPagina);
            intTotalRegistros = bandeja.TotalRegistros;
            intPaginas = ((int)(intTotalRegistros / intRegPorPagina)) + 1;
            return Datos;
        }


        public DataTable ListaEncabezadosTransferidos(int idCliente, int Usuario, int idTipoInforme, string Estado, int Caracter, String FechaDesde, String FechaHasta, int vRegPorPagina, bool Extranet, int idEncabezado)
        {
            String SQLWhere = "";
            SQLWhere = SQLWhere + " AND T.idEncabezadoPadre = " + idEncabezado;
            SQLWhere = SQLWhere + " AND B.idTipoInforme = " + idTipoInforme;

            if (Usuario != -1)
                SQLWhere = SQLWhere + " AND B.idUsuario = " + Usuario.ToString();

            if (idCliente != -1)
                SQLWhere = SQLWhere + " AND B.idCliente = " + idCliente.ToString();

            if (Estado != "")
            {
                string[] Est = Estado.Split(",".ToCharArray());
                if (Est[0] != "-1")
                {
                    SQLWhere = SQLWhere + " AND ( ";
                    for (int i = 0; i < Est.Length; i++)
                    {
                        if (i < Est.Length && i > 0)
                            SQLWhere = SQLWhere + " OR ";
                        SQLWhere = SQLWhere + " B.Estado = " + Est[i].ToString();
                    }
                    SQLWhere = SQLWhere + ")";
                }
            }

            if (Caracter != -1)
                SQLWhere = SQLWhere + " AND B.Caracter = " + Caracter.ToString();
            else
            {
                if (Extranet)
                {
                    SQLWhere = SQLWhere + " AND B.Estado in (1,5) ";
                }
            }



            if (FechaDesde != "")
                FechaDesde = "'" + FechaDesde + " 00:00:00.000'";
            else
            {
                FechaDesde = DateTime.Today.AddMonths(-3).ToShortDateString();
                FechaDesde = "'" + FechaDesde + " 00:00:00.000'";
            }



            if (FechaHasta != "")
                FechaHasta = "'" + FechaHasta + " 23:59:59.999'";
            else
            {
                FechaHasta = DateTime.Today.ToShortDateString();
                FechaHasta = "'" + FechaHasta + " 23:59:59.999'";
            }

            if (vRegPorPagina != 0)
                intRegPorPagina = vRegPorPagina;

            SQLWhere = SQLWhere + " AND B.FechaCarga BETWEEN '" + FechaDesde + "' AND '" + FechaHasta + "'";

            BandejaEntradaDal bandeja = new BandejaEntradaDal();
            DataTable Datos = bandeja.ListaEncabezadosTransferidos(SQLWhere, Pagina, intRegPorPagina);
            intTotalRegistros = bandeja.TotalRegistros;
            intPaginas = ((int)(intTotalRegistros / intRegPorPagina)) + 1;
            return Datos;
        }


        public DataTable ListaEncabezadosMovimientosCC(int nroMovimiento)
        {
            string SQLWhere = "";
            int vRegPorPagina = 0;

            SQLWhere = SQLWhere + " AND B.idEncabezado NOT IN ( ";
            SQLWhere = SQLWhere + "SELECT bb.idEncabezado FROM remitoinforme ri ";
            SQLWhere = SQLWhere + "INNER JOIN bandejaentrada bb ON ri.idEncabezado=bb.idEncabezado ";
            SQLWhere = SQLWhere + "WHERE bb.idCliente = " + nroMovimiento.ToString() + " ) ";

            BandejaEntradaDal bandeja = new BandejaEntradaDal();
            DataTable Datos = bandeja.ListaEncabezados(SQLWhere, Pagina, RegPorPagina);
            return Datos;
        }


        public DataTable ListaInformesFinalizados(int idCliente, int Usuario, int idTipoInforme, string Estado, int Caracter, String FechaDesde, String FechaHasta, int vRegPorPagina, bool Extranet, int idGrupo)
        {
            String SQLWhere = "";
            SQLWhere = SQLWhere + " AND ice.idTipoGrupo = " + idGrupo;
            SQLWhere = SQLWhere + " AND B.idTipoInforme = " + idTipoInforme;

            if (Usuario != -1)
                SQLWhere = SQLWhere + " AND B.idUsuario = " + Usuario.ToString();

            if (idCliente != -1)
                SQLWhere = SQLWhere + " AND B.idCliente = " + idCliente.ToString();

            if (Estado != "")
            {
                string[] Est = Estado.Split(",".ToCharArray());
                if (Est[0] != "-1")
                {
                    SQLWhere = SQLWhere + " AND ( ";
                    for (int i = 0; i < Est.Length; i++)
                    {
                        if (i < Est.Length && i > 0)
                            SQLWhere = SQLWhere + " OR ";
                        SQLWhere = SQLWhere + " B.Estado = " + Est[i].ToString();
                    }
                    SQLWhere = SQLWhere + ")";
                }
            }

            if (Caracter != -1)
                SQLWhere = SQLWhere + " AND B.Caracter = " + Caracter.ToString();
            else
            {
                if (Extranet)
                {
                    SQLWhere = SQLWhere + " AND B.Estado in (1,5) ";
                }
            }



            if (FechaDesde != "")
                FechaDesde = "'" + FechaDesde + " 00:00:00.000'";
            else
            {
                FechaDesde = DateTime.Today.AddMonths(-3).ToShortDateString();
                FechaDesde = "'" + FechaDesde + " 00:00:00.000'";
            }



            if (FechaHasta != "")
                FechaHasta = "'" + FechaHasta + " 23:59:59.999'";
            else
            {
                FechaHasta = DateTime.Today.ToShortDateString();
                FechaHasta = "'" + FechaHasta + " 23:59:59.999'";
            }

            if (vRegPorPagina != 0)
                intRegPorPagina = vRegPorPagina;

            SQLWhere = SQLWhere + " AND B.FechaCarga BETWEEN '" + FechaDesde + "' AND '" + FechaHasta + "'";

            BandejaEntradaDal bandeja = new BandejaEntradaDal();
            DataTable Datos = bandeja.ListaInformesFinalizados(SQLWhere, Pagina, RegPorPagina);
            return Datos;
        }

        public DataTable ListarHistorialMasivos()
        {

            BandejaEntradaDal bandeja = new BandejaEntradaDal();
            DataTable Datos = bandeja.ListarHistorialMasivos();
            return Datos;
        }


        public DataTable ListarGruposClientesMasivos(int idTipo)
        {

            BandejaEntradaDal bandeja = new BandejaEntradaDal();
            DataTable Datos = bandeja.ListarGruposClientesMasivos(idTipo);
            return Datos;
        }


        public void generarRecibosMasivos(string fechaDesde, string fechaHasta)
        { 
            BandejaEntradaDal grm = new BandejaEntradaDal();
            grm.generarRecibosMasivos(fechaDesde, fechaHasta);
        }

        #endregion

        #region Métodos Privados
        #endregion

    }
}
