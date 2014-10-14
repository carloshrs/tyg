using System.Data;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;

namespace ar.com.TiempoyGestion.BackEnd.InboxSuport.App
{
	/// <summary>
	/// Summary description for TipoObjetosDal.
	/// </summary>
	public class TipoObjetosApp
	{
		#region Atributos y Contructores
		
		public TipoObjetosApp() : base()
		{		}

		#endregion

		#region Propiedades
	

		#endregion

		#region Métodos Publicos

		public DataTable TraerDatos()
		{
			TipoObjetosDal EC = new TipoObjetosDal();
			DataTable strDatos = EC.TraerDatos();
			return strDatos;
		}

		public bool Crear(string Descripcion)
		{
			
			TipoObjetosDal EC = new TipoObjetosDal();
			EC.Descripcion = Descripcion;
			return EC.Crear();
		}

		public bool Modificar(int id, string Descripcion)
		{
			TipoObjetosDal EC = new TipoObjetosDal();
			EC.Descripcion = Descripcion;
			return EC.Modificar(id);
		}

		public bool Eliminar(int id)
		{
			
			TipoObjetosDal EC = new TipoObjetosDal();
			EC.Id = id;
			return EC.Borrar();
		}


		#endregion

		#region Métodos Privados
		#endregion

	}
}
