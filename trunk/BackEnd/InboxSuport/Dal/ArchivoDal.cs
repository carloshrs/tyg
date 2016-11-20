using System;
using System.Data;
using System.Text;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;

namespace ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal
{
	/// <summary>
	/// Summary description for ImagenDal.
	/// </summary>
	public class ArchivoDal: GenericDal
	{
		
		#region Atributos y Contructores
		private int intIdArchivo;
		private int intIdInforme;
		private string strDescripcion;
		private string strPath;
        private string strExtension;
		

        public ArchivoDal()
		{
            intIdArchivo = 0;
            intIdInforme = -1;
            strDescripcion = "";
            strPath = "";
            
		}
		#endregion

		#region Propiedades
        public int IdArchivo
		{
			get
			{
                return intIdArchivo;
			}
		}

		public int IdInforme
		{
			get
			{
				return intIdInforme;
			}
		}

		public string Descripcion
		{
			get
			{
				return strDescripcion;
			}
			set
			{
				strDescripcion = value;
			}
		}

        public string Extension
        {
            get
            {
                return strExtension;
            }
            set
            {
                strExtension = value;
            }
        }

		public string Path
		{
			get
			{
				return strPath;
			}
		}



		#endregion

		#region Métodos Publicos

		public void Cargar(int lIdInforme, int lIdArchivo)
		{
            if (lIdInforme != 0 && lIdArchivo != 0)
			{
				StringBuilder strSqlGet = new StringBuilder(512);
				strSqlGet.Append("Select Descripcion, Path, extension ");
                strSqlGet.Append(" From archivos ");
                strSqlGet.Append(" Where IdInforme = " + Traduce(lIdInforme) + " And idarchivo = " + Traduce(lIdArchivo));
				try
				{
					IDataReader drArchivo = EjecutarDataReader(strSqlGet.ToString());

                    if (drArchivo.Read())
					{
                        intIdArchivo = lIdArchivo;
						intIdInforme = lIdInforme;
                        strPath = drArchivo.GetString(1);
                        if (!drArchivo.IsDBNull(0))
                            strDescripcion = drArchivo.GetString(0);
                        if (!drArchivo.IsDBNull(2))
                            strExtension = drArchivo.GetString(2);
						

					}
                    drArchivo.Close();
				}
				catch
				{
					throw;
				}

			}				
		}

		public bool Cargar(int lIdInforme)
		{
			bool bolResult = true;
			if (lIdInforme != 0)
			{
				StringBuilder strSqlGet = new StringBuilder(512);
                strSqlGet.Append("Select Descripcion, Path, extension, idInforme ");
                strSqlGet.Append(" From archivos ");
				strSqlGet.Append(" Where IdInforme = " + Traduce(lIdInforme));
				try
				{
					IDataReader drArchivo = EjecutarDataReader(strSqlGet.ToString());

                    if (drArchivo.Read())
					{
						intIdInforme = lIdInforme;
                        strPath = drArchivo.GetString(1);
                        strExtension = drArchivo.GetString(2);
                        intIdArchivo = (int)drArchivo.GetInt64(3);
                        if (!drArchivo.IsDBNull(0))
                            strDescripcion = drArchivo.GetString(0);
						

					}
					else
						bolResult = false;
                    drArchivo.Close();
				}
				catch
				{
					bolResult = false;
				}

			}	
			else
				bolResult = false;

			return bolResult;

		}

        public int Crear(int lIdInforme, string lPath, string strExtension)
		{
			int intSalida = -1;
			intIdArchivo = 1;
			if (lIdInforme != 0 && lPath != "")
			{

				try
				{
					intIdArchivo = ArchivoDal.NextArchivo(lIdInforme);

                    StringBuilder strSqlDelete = new StringBuilder(512);
                    strSqlDelete.Append("DELETE FROM archivos ");
                    strSqlDelete.Append(" WHERE idInforme = " + Traduce(lIdInforme));

                    EjecutarComando(strSqlDelete.ToString());

					StringBuilder strSqlInsert = new StringBuilder(512);
                    strSqlInsert.Append("Insert Into archivos ");
					strSqlInsert.Append(" (IdArchivo, IdInforme, Descripcion, Path, extension) ");
					strSqlInsert.Append(" Values ");
					strSqlInsert.Append(" (" + Traduce(intIdArchivo) + ", ");
					strSqlInsert.Append(" " + Traduce(lIdInforme) + ", ");
					strSqlInsert.Append(" " + Traduce(strDescripcion) + ", ");
					strSqlInsert.Append(" " + Traduce(lPath) + ", ");
					strSqlInsert.Append(" " + Traduce(strExtension) + ") ");

                    EjecutarComando(strSqlInsert.ToString());

				}
				catch
				{
					throw;
				}
			}	
			else
				intSalida = -1;
			return intSalida;

		}

		public bool Modificar()
		{
			bool bolSalida = true;
			if 	(intIdInforme != -1 && intIdArchivo != 0 && strPath != "")
			{	
				StringBuilder strSqlUpdate = new StringBuilder(512);
				strSqlUpdate.Append("Update archivos ");
				strSqlUpdate.Append(" Set Descripcion = " + Traduce(strDescripcion));
				strSqlUpdate.Append(", extension = " + Traduce(strExtension));

				strSqlUpdate.Append(" Where IdInforme = " + Traduce(intIdInforme) + " And idArchivo = " + Traduce(intIdArchivo));
				try
				{
					if (EjecutarComando(strSqlUpdate.ToString()) != 1)
						bolSalida = false;
				}
				catch
				{
					bolSalida = false;
					throw;
				}		
			}

			return bolSalida;
		}

		public void Eliminar(int lIdInforme, int lIdArchivo)
		{
			StringBuilder strSqlUpdate = new StringBuilder(128);
			strSqlUpdate.Append("Delete From archivos ");
            strSqlUpdate.Append(" Where IdInforme = " + Traduce(lIdInforme) + " And idArchivo = " + Traduce(lIdArchivo));
			try
			{
				EjecutarComando(strSqlUpdate.ToString());
			}
			catch
			{
				throw;
			}		

		}


		public static int NextArchivo(int lIdInforme)
		{
			StringBuilder strQuery = new StringBuilder(512);
			int intResult = 1;
			strQuery.Append("Select Max(idArchivo) ");
			strQuery.Append(" From archivos ");
			strQuery.Append(" Where IdInforme = " + StaticDal.Traduce(lIdInforme));
			
			try
			{
				IDataReader drNext = StaticDal.EjecutarDataReader(strQuery.ToString());
				if (drNext.Read() && !drNext.IsDBNull(0))
					intResult = (int) drNext.GetInt32(0) + 1;
				drNext.Close();
			}
			catch(Exception EX) {Console.WriteLine(EX.Message)	;}

			return intResult;

		}

		
		public static void BorrarArchivo(int lIdInforme)
		{
			StringBuilder strQuery = new StringBuilder(512);
			strQuery.Append("Delete ");
			strQuery.Append(" From archivos ");
			strQuery.Append(" Where IdInforme = " + StaticDal.Traduce(lIdInforme));
			
			try
			{
				StaticDal.EjecutarComando(strQuery.ToString());
			}
			catch(Exception EX) {Console.WriteLine(EX.Message)	;}

		}
		#endregion

		#region Métodos Privados

		#endregion


	}
}
