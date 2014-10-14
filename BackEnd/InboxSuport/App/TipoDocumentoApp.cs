using System.Data;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;

namespace ar.com.TiempoyGestion.BackEnd.InboxSuport.App
{
	/// <summary>
	/// Summary description for TipoDocumentoDal.
	/// </summary>
	public class TipoDocumentoApp
	{
		#region Atributos y Contructores
		
		public TipoDocumentoApp() : base()
		{		}

		#endregion

		#region Propiedades
	

		#endregion

		#region Métodos Publicos

		public DataTable TraerDatos()
		{
			TipoDocumentoDal EC = new TipoDocumentoDal();
			DataTable strDatos = EC.TraerDatos();
			return strDatos;
		}

		public bool Crear(string Descripcion)
		{
			
			TipoDocumentoDal EC = new TipoDocumentoDal();
			EC.Descripcion = Descripcion;
			return EC.Crear();
		}

		public bool Modificar(int id, string Descripcion)
		{
			TipoDocumentoDal EC = new TipoDocumentoDal();
			EC.Descripcion = Descripcion;
			return EC.Modificar(id);
		}

		public bool Eliminar(int id)
		{
			
			TipoDocumentoDal EC = new TipoDocumentoDal();
			EC.Id = id;
			return EC.Borrar();
		}


		#endregion

		#region Métodos Privados
		#endregion

	}
}
