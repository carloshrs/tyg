using System;

namespace WebCustomControls.EventArguments
{
	/// <summary>
	/// Summary description for FilterChangedEventArgs.
	/// </summary>
	public class FilterChangedEventArgs : EventArgs
	{
		#region Atributos
		
		private string filter;

		#endregion

		#region Constructores

		public FilterChangedEventArgs()
		{			
			this.filter = "";
		}

		#endregion

		#region Propiedades
		
		public string Filter
		{
			get { return filter; }            
			set { filter=value; }
		}

		#endregion       
	}
}
