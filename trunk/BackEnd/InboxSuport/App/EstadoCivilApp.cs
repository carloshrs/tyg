using System.Data;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;

namespace ar.com.TiempoyGestion.BackEnd.InboxSuport.App
{
	/// <summary>
	/// Summary description for EstadoCivilDal.
	/// </summary>
	public class EstadoCivilApp
	{
		#region Atributos y Contructores
		
		public EstadoCivilApp() : base()
		{		}

		#endregion

		#region Propiedades
	

		#endregion

		#region Métodos Publicos

		public DataTable TraerDatos()
		{
			EstadoCivilDal EC = new EstadoCivilDal();
			DataTable strDatos = EC.TraerDatos();
			return strDatos;
		}

		public bool Crear(string Descripcion)
		{
			
			EstadoCivilDal EC = new EstadoCivilDal();
			EC.Descripcion = Descripcion;
			return EC.Crear();
		}

		public bool Modificar(int id, string Descripcion)
		{
			EstadoCivilDal EC = new EstadoCivilDal();
			EC.Descripcion = Descripcion;
			return EC.Modificar(id);
		}

		public bool Eliminar(int id)
		{
			
			EstadoCivilDal EC = new EstadoCivilDal();
			EC.Id = id;
			return EC.Borrar();
		}


		#endregion

		#region Métodos Privados
		#endregion

	}
}
