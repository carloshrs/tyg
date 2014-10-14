using Microsoft.Win32;
using ar.com.TiempoyGestion.BackEnd.BackServices.Services.Cryptography;

namespace ar.com.TiempoyGestion.BackEnd.BackServices.Services
{
	/// <summary>
	/// Summary description for Reader.
	/// </summary>
	public class RegistryReader
	{
		string mvarPath;
		public RegistryReader()
		{
			//Constructor...
			
		}

		public string getStringValue(string  stringName)
		{
			return getStringValue(stringName, false);
		}

		public string getStringValue(string stringName, bool decrypt)
		{
			string strTemp = internGetStringValue(stringName);
			if (decrypt)
			{
				DataProtector myProtect = new DataProtector(DataProtector.Store.USE_MACHINE_STORE);
				strTemp = myProtect.Decrypt(strTemp);
			}
			return strTemp;
		}

		/// <summary>
		/// Variable que contiene el path dentro de Hkey_Local_Machine\Software donde se encuentrar todas las variables de una determinada applicacion
		/// </summary>
		public string path
		{
			get
			{
				return mvarPath;
			}
			set
			{
				mvarPath = value;
			}
		}

		private string internGetStringValue(string stringName)
		{
			string salida = "";
			try
			{
				RegistryKey theCurrentMachine = Registry.LocalMachine;
				RegistryKey IPP = theCurrentMachine.OpenSubKey (mvarPath);
				salida = (string)IPP.GetValue(stringName);
			}
			catch
			{ 
				//
				// TODO: Asignar manejo de errores
				//
			}

			return salida;
		}
	}
}
