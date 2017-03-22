using System;
using ar.com.TiempoyGestion.BackEnd.Clientes.Dal;
using ar.com.TiempoyGestion.BackEnd.Cobranzas.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.Admin.Cuentas
{
	/// <summary>
	/// Summary description for ABMFuncion.
	/// </summary>
	public partial class ABMAdicionales : System.Web.UI.Page
	{
        private int intId;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				try
				{
					intId = int.Parse(Request.QueryString["id"]);
                    CargarAdicional(intId);
				}
				catch
				{
                    intId = -1;
				}
                ViewState["Id"] = intId.ToString();
			}
			else
                intId = int.Parse(ViewState["Id"].ToString());
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
			Response.Redirect("ListaAdicionales.aspx");

		}

		protected void btnAceptar_Click(object sender, System.EventArgs e)
		{
			if (intId != -1)
			{
                GestorPrecios.ModificarAdicional(intId, txtDescripcion.Text);
			}
			else
            {
                GestorPrecios.CrearAdicional(txtDescripcion.Text);
			}

			Response.Redirect("ListaAdicionales.aspx");
		}

        private void CargarAdicional(int lId)
		{
            string strDescr = "";
            strDescr = GestorPrecios.CargarAdicional(lId);
			txtDescripcion.Text = strDescr;
			
		}


	}
}
