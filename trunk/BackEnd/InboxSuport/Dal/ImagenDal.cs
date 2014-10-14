using System;
using System.Data;
using System.Text;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;

namespace ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal
{
	/// <summary>
	/// Summary description for ImagenDal.
	/// </summary>
	public class ImagenDal: GenericDal
	{
		
		#region Atributos y Contructores
		private int intNroImagen;
		private int intIdInforme;
		private string strDescripcion;
		private string strPath;
		private int intWidth;
		private int intHeight;
		private bool bolPredeterminada;

		public ImagenDal()
		{
            intNroImagen = 0;
            intIdInforme = -1;
            strDescripcion = "";
            strPath = "";
            intWidth = 0;
            intHeight = 0;
            bolPredeterminada = false;
		}
		#endregion

		#region Propiedades
		public int NumeroImagen
		{
			get
			{
				return intNroImagen;
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

		public string Path
		{
			get
			{
				return strPath;
			}
		}

		public int Width
		{
			get
			{
				return intWidth;
			}
			set
			{
				intWidth = value;
			}
		}

		public int Height
		{
			get
			{
				return intHeight;
			}
			set
			{
				intHeight = value;
			}
		}


		public bool Predeterminada
		{
			get
			{
				return bolPredeterminada;
			}
			set
			{
				bolPredeterminada = value;
			}
		}

		#endregion

		#region Métodos Publicos

		public void Cargar(int lIdInforme, int lNroImagen)
		{
			if (lIdInforme != 0 && lNroImagen != 0)
			{
				StringBuilder strSqlGet = new StringBuilder(512);
				strSqlGet.Append("Select Descripcion, Path, Width, Height, Predeterminada ");
				strSqlGet.Append(" From Imagenes ");
				strSqlGet.Append(" Where IdInforme = " + Traduce(lIdInforme) + " And NroImagen = " + Traduce(lNroImagen));
				try
				{
					IDataReader drImagen = EjecutarDataReader(strSqlGet.ToString());
					
					if (drImagen.Read())
					{
						intNroImagen = lNroImagen;
						intIdInforme = lIdInforme;
						strPath = drImagen.GetString(1);
						bolPredeterminada = Convert.ToBoolean(drImagen.GetInt32(4));
						if (!drImagen.IsDBNull(0))
							strDescripcion = drImagen.GetString(0);
						if (!drImagen.IsDBNull(2))
							intWidth = drImagen.GetInt32(2);
						if (!drImagen.IsDBNull(2))
							intHeight = drImagen.GetInt32(3);

					}
					drImagen.Close();
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
				strSqlGet.Append("Select Descripcion, Path, Width, Height, Predeterminada, NroImagen ");
				strSqlGet.Append(" From Imagenes ");
				strSqlGet.Append(" Where IdInforme = " + Traduce(lIdInforme) + " And Predeterminada = 1");
				try
				{
					IDataReader drImagen = EjecutarDataReader(strSqlGet.ToString());
					
					if (drImagen.Read())
					{
						intIdInforme = lIdInforme;
						strPath = drImagen.GetString(1);
						bolPredeterminada = Convert.ToBoolean(drImagen.GetInt32(4));
						intNroImagen = (int) drImagen.GetInt64(5);
						if (!drImagen.IsDBNull(0))
							strDescripcion = drImagen.GetString(0);
						if (!drImagen.IsDBNull(2))
							intWidth = drImagen.GetInt32(2);
						if (!drImagen.IsDBNull(2))
							intHeight = drImagen.GetInt32(3);

					}
					else
						bolResult = false;
					drImagen.Close();
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

		public int Crear(int lIdInforme, string lPath)
		{
			int intSalida = -1;
			intNroImagen = 1;
			if (lIdInforme != 0 && lPath != "")
			{

				try
				{
					intNroImagen = ImagenDal.NextImage(lIdInforme);
					if (intNroImagen == 1)
						bolPredeterminada = true;

					StringBuilder strSqlInsert = new StringBuilder(512);
					strSqlInsert.Append("Insert Into Imagenes ");
					strSqlInsert.Append(" (NroImagen, IdInforme, Descripcion, Path, Width, Height, Predeterminada) ");
					strSqlInsert.Append(" Values ");
					strSqlInsert.Append(" (" + Traduce(intNroImagen) + ", ");
					strSqlInsert.Append(" " + Traduce(lIdInforme) + ", ");
					strSqlInsert.Append(" " + Traduce(strDescripcion) + ", ");
					strSqlInsert.Append(" " + Traduce(lPath) + ", ");
					strSqlInsert.Append(" " + Traduce(intWidth) + ", ");
					strSqlInsert.Append(" " + Traduce(intHeight) + ", ");
					if (intNroImagen == 1)
						strSqlInsert.Append(" 1)");
					else
						strSqlInsert.Append(" " + Traduce(bolPredeterminada) + ")");

					if (EjecutarComando(strSqlInsert.ToString()) == 1)
					{
						intSalida = intNroImagen;
						intIdInforme = lIdInforme;
						strPath = lPath;
						if (intNroImagen != 1 && bolPredeterminada)
							EjecutarComando("Update Imagenes Set Predeterminada = 0 Where IdInforme = " + Traduce(intIdInforme) + " And NroImagen <> " + Traduce(intNroImagen));
						
					}

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
			if 	(intIdInforme != -1 && intNroImagen != 0 && strPath != "")
			{	
				StringBuilder strSqlUpdate = new StringBuilder(512);
				strSqlUpdate.Append("Update Imagenes ");
				strSqlUpdate.Append(" Set Descripcion = " + Traduce(strDescripcion));
				strSqlUpdate.Append(", Width = " + Traduce(intWidth));
				strSqlUpdate.Append(", Height = " + Traduce(intHeight));
				strSqlUpdate.Append(", Predeterminada = " + Traduce(bolPredeterminada));
				strSqlUpdate.Append(" Where IdInforme = " + Traduce(intIdInforme) + " And NroImagen = " + Traduce(intNroImagen));
				try
				{
					if (EjecutarComando(strSqlUpdate.ToString()) == 1)
					{
						if (bolPredeterminada)
							EjecutarComando("Update Imagenes Set Predeterminada = 0 Where IdInforme = " + Traduce(intIdInforme) + " And NroImagen <> " + Traduce(intNroImagen));
						else
						{
							IDataReader drPred = EjecutarDataReader("Select Count(*) From Imagenes Where Predeterminada = 1 And IdInforme = " + Traduce(intIdInforme));
							bool bolFlag = false;
							if (drPred.Read() && drPred.GetInt32(0) == 0)
								bolFlag = true;
							drPred.Close();
							if (bolFlag)
								EjecutarComando("Update Imagenes Set Predeterminada = 1 Where IdInforme = " + Traduce(intIdInforme) + " And NroImagen = 1");
						}
					}
					else
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

		public void Eliminar(int lIdInforme, int lNroImagen)
		{
			StringBuilder strSqlUpdate = new StringBuilder(128);
			strSqlUpdate.Append("Delete From Imagenes ");
			strSqlUpdate.Append(" Where IdInforme = " + Traduce(lIdInforme) + " And NroImagen = " + Traduce(lNroImagen));
			try
			{
				EjecutarComando(strSqlUpdate.ToString());
			}
			catch
			{
				throw;
			}		

		}

		public DataTable Listar(int lIdInforme)
		{
			StringBuilder strQuery = new StringBuilder(512);
			DataTable dtSalida = null;
			strQuery.Append("Select NroImagen, Descripcion, Path, Width, Height, Predeterminada ");
			strQuery.Append(" From Imagenes ");
			strQuery.Append(" Where IdInforme = " + Traduce(lIdInforme));
			strQuery.Append(" Order by NroImagen");
			
			try
			{
				dtSalida = EjecutarDataSet(strQuery.ToString(),"Imagenes").Tables["Imagenes"];
			}
			catch
			{
				throw;
			}
			return dtSalida;


		}

		public static int NextImage(int lIdInforme)
		{
			StringBuilder strQuery = new StringBuilder(512);
			int intResult = 1;
			strQuery.Append("Select Max(NroImagen) ");
			strQuery.Append(" From Imagenes ");
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

		
		public static void BorrarImagenes(int lIdInforme)
		{
			StringBuilder strQuery = new StringBuilder(512);
			strQuery.Append("Delete ");
			strQuery.Append(" From Imagenes ");
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
