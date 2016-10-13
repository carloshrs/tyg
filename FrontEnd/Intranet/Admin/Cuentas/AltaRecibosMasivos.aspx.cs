using System;
using ar.com.TiempoyGestion.BackEnd.Clientes.Dal;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.Admin.Cuentas
{
	/// <summary>
	/// Summary description for ABMFuncion.
	/// </summary>
	public partial class ABMCaja : System.Web.UI.Page
	{
        private int intId;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				try
				{
					intId = int.Parse(Request.QueryString["id"]);
                    //CargarCaja(intId);
				}
				catch
				{
                    intId = -1;
				}
                
			}
			
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
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

		protected void btnCancelar_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("ListaCaja.aspx");

		}

		protected void btnAceptar_Click(object sender, System.EventArgs e)
		{
            GenerarRecibosMasivos();
		}

        protected void btnCerrar_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("listadoGruposDocumentosMasivo.aspx");
        }

        private void GenerarRecibosMasivos()
		{
            //string strDescr = "";
            BandejaEntradaApp grm = new BandejaEntradaApp();
            grm.generarRecibosMasivos(txtFechaInicio.Text, txtFechaFinal.Text);
            Response.Redirect("listadoGruposDocumentosMasivo.aspx");
		}


	}
}
