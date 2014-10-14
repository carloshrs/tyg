using System;
using System.Security.Cryptography;
using System.Web.Security;

namespace ar.com.TiempoyGestion.BackEnd.BackServices.Services
{
	/// <summary>
	/// Summary description for Encriptador.
	/// </summary>
	public class Encriptador
	{
		private Encriptador() {}

		public static string HashPassword(string lClearPassword)
		{
			string hashedPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(lClearPassword, "SHA1");

			return hashedPwd;

		}

	}
}
