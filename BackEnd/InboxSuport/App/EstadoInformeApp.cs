using System.Data;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;

namespace ar.com.TiempoyGestion.BackEnd.InboxSuport.App
{
	/// <summary>
	/// Summary description for EstadoInformeDal.
	/// </summary>
	public class EstadoInformeApp
	{
		#region Atributos y Contructores
		
		public EstadoInformeApp() : base()
		{		}

		#endregion

		#region Propiedades
	

		#endregion

		#region Métodos Publicos

		public DataTable TraerDatos()
		{
			EstadoInformeDal EC = new EstadoInformeDal();
			DataTable strDatos = EC.TraerDatos();
			return strDatos;
		}

		public bool Crear(string Nombre, string Descricpion)
		{
			
			EstadoInformeDal EC = new EstadoInformeDal();
			EC.Nombre = Nombre;
			EC.Descripcion = Descricpion;
			return EC.Crear();
		}

		public bool Modificar(int id, string Nombre, string Descripcion)
		{
			EstadoInformeDal EC = new EstadoInformeDal();
			EC.Nombre = Nombre;
			EC.Descripcion = Descripcion;
			return EC.Modificar(id);
		}

		public bool Eliminar(int id)
		{
			
			EstadoInformeDal EC = new EstadoInformeDal();
			EC.Id = id;
			return EC.Borrar();
		}


		#endregion

		#region Métodos Privados
		#endregion

	}
}
