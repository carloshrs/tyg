using System;
using ar.com.TiempoyGestion.BackEnd.Clientes.Dal;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.App;

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
                    CargarCaja(intId);
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
			Response.Redirect("ListaCaja.aspx");

		}

		protected void btnAceptar_Click(object sender, System.EventArgs e)
		{
			if (intId != -1)
			{
                GestorPrecios.ModificarCaja(intId, float.Parse(txtEfectivoInicial.Text), float.Parse(txtChequeInicial.Text), float.Parse(txtSaldoEfectivo.Text), float.Parse(txtSaldoCheque.Text), 0);
			}
			else
            {
                UsuarioAutenticado Usuario = (UsuarioAutenticado)Session["UsuarioAutenticado"];
                GestorPrecios.CrearCaja(float.Parse(txtEfectivoInicial.Text), float.Parse(txtChequeInicial.Text), Usuario.IdUsuario);
			}

			Response.Redirect("ListaCaja.aspx");
		}

        protected void btnCerrar_Click(object sender, System.EventArgs e)
        {
            if (intId != -1)
            {
                GestorPrecios.ModificarCaja(intId, float.Parse(txtEfectivoInicial.Text), float.Parse(txtChequeInicial.Text), float.Parse(txtSaldoEfectivo.Text), float.Parse(txtSaldoCheque.Text), 1);
            }

            Response.Redirect("ListaCaja.aspx");
        }

        private void CargarCaja(int lId)
		{
            //string strDescr = "";
            GestorPrecios gCarga = new GestorPrecios();
            gCarga.CargarCaja(lId);

            //strDescr = GestorPrecios.CargarCaja(lId);
			txtEfectivoInicial.Text = gCarga.EfectivoInicial.ToString();
            txtChequeInicial.Text = gCarga.ChequeInicial.ToString();
            txtSaldoEfectivo.Text = gCarga.SaldoEfectivo.ToString();
            txtSaldoCheque.Text = gCarga.SaldoCheque.ToString();
			
		}


	}
}
