using System;
using System.Data;
using System.Text;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;

namespace ar.com.TiempoyGestion.BackEnd.InboxSuport.App
{
	/// <summary>
	/// Summary description for ClienteDal.
	/// </summary>
	public class ContactenosApp
	{
		#region Atributos y Contructores
        private int intTotalRegistros = 0;
        private int intPaginas = 1;
        private int intRegPorPagina = 15;
        private int intPagina = 1;
        public ContactenosApp()
            : base()
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




        public DataTable TraerDatos(string Texto, int vRegPorPagina)
		{
			string SQLWhere = "";

            if (Texto != "")
                SQLWhere = SQLWhere + " LIKE '%" + Texto + "%' ";

			
            if (vRegPorPagina != 0)
                intRegPorPagina = vRegPorPagina;


            ContactenosDal listado = new ContactenosDal();
            DataTable Datos = listado.TraerDatos(SQLWhere, Pagina, intRegPorPagina);
            intTotalRegistros = listado.TotalRegistros;
            intPaginas = ((int)(intTotalRegistros / intRegPorPagina)) + 1;
			return Datos;
		}

        public int TraerDatos()
        {
            ContactenosDal listado = new ContactenosDal();
            int TotalNoLeidos = listado.TraerDatos();
            return TotalNoLeidos;
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


        

        #endregion

        #region Métodos Privados
        #endregion

    }
}
