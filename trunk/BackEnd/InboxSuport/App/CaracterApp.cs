using System.Data;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;

namespace ar.com.TiempoyGestion.BackEnd.InboxSuport.App
{
	/// <summary>
	/// Summary description for CaracterDal.
	/// </summary>
	public class CaracterApp
	{
		#region Atributos y Contructores
		
		public CaracterApp() : base()
		{		}

		#endregion

		#region Propiedades
	

		#endregion

		#region Métodos Publicos

		public DataTable TraerDatos()
		{
			CaracterDal EC = new CaracterDal();
			DataTable strDatos = EC.TraerDatos();
			return strDatos;
		}

		public bool Crear(string Descripcion)
		{
			
			CaracterDal EC = new CaracterDal();
			EC.Descripcion = Descripcion;
			return EC.Crear();
		}

		public bool Modificar(int id, string Descripcion)
		{
			CaracterDal EC = new CaracterDal();
			EC.Descripcion = Descripcion;
			return EC.Modificar(id);
		}

		public bool Eliminar(int id)
		{
			
			CaracterDal EC = new CaracterDal();
			EC.Id = id;
			return EC.Borrar();
		}


		#endregion

		#region Métodos Privados
		#endregion

	}
}
