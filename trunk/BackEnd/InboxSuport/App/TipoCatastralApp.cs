using System.Data;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;

namespace ar.com.TiempoyGestion.BackEnd.InboxSuport.App
{
	/// <summary>
	/// Summary description for TipoCatastralDal.
	/// </summary>
	public class TipoCatastralApp
	{
		#region Atributos y Contructores
		
		public TipoCatastralApp() : base()
		{		}

		#endregion

		#region Propiedades
	

		#endregion

		#region Métodos Publicos

		public DataTable TraerDatos()
		{
			TipoCatastralDal EC = new TipoCatastralDal();
			DataTable strDatos = EC.TraerDatos();
			return strDatos;
		}

		public bool Crear(string Descripcion)
		{
			
			TipoCatastralDal EC = new TipoCatastralDal();
			EC.Descripcion = Descripcion;
			return EC.Crear();
		}

		public bool Modificar(int id, string Descripcion)
		{
			TipoCatastralDal EC = new TipoCatastralDal();
			EC.Descripcion = Descripcion;
			return EC.Modificar(id);
		}

		public bool Eliminar(int id)
		{
			
			TipoCatastralDal EC = new TipoCatastralDal();
			EC.Id = id;
			return EC.Borrar();
		}


		#endregion

		#region Métodos Privados
		#endregion

	}
}
