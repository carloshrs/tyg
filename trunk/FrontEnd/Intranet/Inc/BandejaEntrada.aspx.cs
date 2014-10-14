using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.App;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.Inc
{
	/// <summary>
	/// Summary description for BandejaEntrada.
	/// </summary>
	public partial class BandejaEntrada : Page
	{

		protected void Page_Load(object sender, EventArgs e)
		{
			// Put user code to initialize the page here
			BandejaEntradaApp bandeja = new BandejaEntradaApp();
			int[] registros = bandeja.CargarDatos();

			Propiedad.NavigateUrl = "/BandejaEntrada/Principal.aspx?idTipo=1";
			if (registros[0] > 0)
				Propiedad.Text = "Propiedad <B>(" + registros[0].ToString() + ")</B>";
			else
				Propiedad.Text = "Propiedad (" + registros[0].ToString() + ")";

			Automotores.NavigateUrl = "/BandejaEntrada/Principal.aspx?idTipo=2";
			if (registros[1] > 0)
				Automotores.Text = "Automotores <B>(" + registros[1].ToString() + ")</B>";
			else
				Automotores.Text = "Automotores (" + registros[1].ToString() + ")";

			Gravamenes.NavigateUrl = "/BandejaEntrada/Principal.aspx?idTipo=3";
			if (registros[2] > 0)
				Gravamenes.Text = "Gravámenes <B>(" + registros[2].ToString() + ")</B>";
			else
				Gravamenes.Text = "Gravámenes (" + registros[2].ToString() + ")";

			Ambientales.NavigateUrl = "/BandejaEntrada/Principal.aspx?idTipo=4";
			if (registros[3] > 0)
				Ambientales.Text = "Ambientales <B>(" + registros[3].ToString() + ")</B>";
			else
				Ambientales.Text = "Ambientales (" + registros[3].ToString() + ")";

			DomicilioParticular.NavigateUrl = "/BandejaEntrada/Principal.aspx?idTipo=5";
			if (registros[4] > 0)
				DomicilioParticular.Text = "Domicilio Particular <B>(" + registros[4].ToString() + ")</B>";
			else
				DomicilioParticular.Text = "Domicilio Particular (" + registros[4].ToString() + ")";

			Laboral.NavigateUrl = "/BandejaEntrada/Principal.aspx?idTipo=6";
			if (registros[5] > 0)
				Laboral.Text = "Domicilio Laboral <B>(" + registros[5].ToString() + ")</B>";
			else
				Laboral.Text = "Domicilio Laboral (" + registros[5].ToString() + ")";

			DomicilioComercial.NavigateUrl = "/BandejaEntrada/Principal.aspx?idTipo=7";
			if (registros[6] > 0)
				DomicilioComercial.Text = "Domicilio Comercial <B>(" + registros[6].ToString() + ")</B>";
			else
				DomicilioComercial.Text = "Domicilio Comercial (" + registros[6].ToString() + ")";

			Especial.NavigateUrl = "/BandejaEntrada/Principal.aspx?idTipo=8";
			if (registros[7] > 0)
				Especial.Text = "Especial <B>(" + registros[7].ToString() + ")</B>";
			else
				Especial.Text = "Especial (" + registros[7].ToString() + ")";

			RegPublicoComercio.NavigateUrl = "/BandejaEntrada/Principal.aspx?idTipo=9";
			if (registros[8] > 0)
				RegPublicoComercio.Text = "Reg. Público de Comercio <B>(" + registros[8].ToString() + ")</B>";
			else
				RegPublicoComercio.Text = "Reg. Público de Comercio (" + registros[8].ToString() + ")";

			BusquedaAuto.NavigateUrl = "/BandejaEntrada/Principal.aspx?idTipo=10";
			if (registros[9] > 0)
				BusquedaAuto.Text = "Búsq. Automotores <B>(" + registros[9].ToString() + ")</B>";
			else
				BusquedaAuto.Text = "Búsq. Automotores (" + registros[9].ToString() + ")";

			PropiedadProvincias.NavigateUrl = "/BandejaEntrada/Principal.aspx?idTipo=11";
			if (registros[10] > 0)
				PropiedadProvincias.Text = "Propiedad otras Prov. <B>(" + registros[10].ToString() + ")</B>";
			else
				PropiedadProvincias.Text = "Propiedad otras Prov.(" + registros[10].ToString() + ")";

			Catastral.NavigateUrl = "/BandejaEntrada/Principal.aspx?idTipo=12";
			if (registros[11] > 0)
				Catastral.Text = "Catastral <B>(" + registros[11].ToString() + ")</B>";
			else
				Catastral.Text = "Catastral (" + registros[11].ToString() + ")";

			BusquedaPropiedad.NavigateUrl = "/BandejaEntrada/Principal.aspx?idTipo=13";
			if (registros[12] > 0)
				BusquedaPropiedad.Text = "Búsq. Propiedad <B>(" + registros[12].ToString() + ")</B>";
			else
				BusquedaPropiedad.Text = "Búsq. Propiedad (" + registros[12].ToString() + ")";


			contractuales.NavigateUrl = "/BandejaEntrada/Principal.aspx?idTipo=14";
			if (registros[13] > 0)
				contractuales.Text = "Contractuales <B>(" + registros[13].ToString() + ")</B>";
			else
				contractuales.Text = "Contractuales (" + registros[13].ToString() + ")";

            AmbientalBancor.NavigateUrl = "/BandejaEntrada/Principal.aspx?idTipo=15";
            if (registros[14] > 0)
                AmbientalBancor.Text = "Entrevista de Relevamiento Habitacional <B>(" + registros[14].ToString() + ")</B>";
            else
                AmbientalBancor.Text = "Entrevista de Relevamiento Habitacional (" + registros[14].ToString() + ")";

            Inhibicion.NavigateUrl = "/BandejaEntrada/Principal.aspx?idTipo=16";
            if (registros[15] > 0)
                Inhibicion.Text = "Inhibición <B>(" + registros[15].ToString() + ")</B>";
            else
                Inhibicion.Text = "Inhibición (" + registros[15].ToString() + ")";

            Morosidad.NavigateUrl = "/BandejaEntrada/Principal.aspx?idTipo=17";
            if (registros[16] > 0)
                Morosidad.Text = "Morosidad <B>(" + registros[16].ToString() + ")</B>";
            else
                Morosidad.Text = "Morosidad (" + registros[16].ToString() + ")";


            ContactenosApp oContactos = new ContactenosApp();
            int totalConsultasNoLeidas = oContactos.TraerDatos();
            Consulta.Text = "Consultas <B>(" + totalConsultasNoLeidas + ")</B>";

        }

		#region Web Form Designer generated code

		protected override void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{

		}

		#endregion
	}
}