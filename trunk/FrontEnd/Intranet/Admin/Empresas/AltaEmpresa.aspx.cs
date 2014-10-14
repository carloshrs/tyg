using System;
using System.Data;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Extranet.Contratos
{
	/// <summary>
	/// Summary description for altaInforme.
	/// </summary>
	public partial class AltaEmpresa : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox Provincia;

		private string direccionRetorno="";
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (Request.QueryString["retornarA"] != null)
			{
				direccionRetorno = Request.QueryString["retornarA"].ToString();				
			}
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			// Put user code to initialize the page here
			// Domicilio Particular
			CargarComboProvincias(cmbProvincia, 2);
			CargarComboLocalidades(cmbProvincia, cmbLocalidad, "1");

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


		private void CargarComboProvincias(DropDownList comboProvincia, int IdProvincia)
		{
			UtilesApp Tipos = new UtilesApp();
			comboProvincia.Items.Clear();
			DataTable myTb;
			myTb = Tipos.TraerProvincias();
			ListItem myItem;
			foreach(DataRow myRow in myTb.Rows)
			{
				myItem = new ListItem(myRow[1].ToString(), myRow[0].ToString());
				if(IdProvincia == int.Parse(myRow[0].ToString()))
				{
					comboProvincia.SelectedIndex = -1;
					myItem.Selected = true;
				}
				comboProvincia.Items.Add(myItem);
			}
		}

		private void CargarComboLocalidades(DropDownList comboProvincias, DropDownList comboLocalidades, string IdLocalidad)
		{
			UtilesApp Tipos = new UtilesApp();
			comboLocalidades.Items.Clear();
			DataTable myTb;
			myTb = Tipos.TraerLocalidades(int.Parse(comboProvincias.SelectedItem.Value));
			ListItem myItem;
			foreach(DataRow myRow in myTb.Rows)
			{
				myItem = new ListItem(myRow[1].ToString(), myRow[0].ToString());
				if(IdLocalidad == myRow[0].ToString())
				{
					comboLocalidades.SelectedIndex = -1;
					myItem.Selected = true;
				}
				comboLocalidades.Items.Add(myItem);
			}
		}

		protected void cmbProvincia_SelectedIndexChanged_1(object sender, System.EventArgs e)
		{
			CargarComboLocalidades(cmbProvincia, cmbLocalidad, "");
		}


		protected void Aceptar_Click(object sender, System.EventArgs e)
		{
			EmpresasAPP empresa = new EmpresasAPP();

			empresa.RazonSocial = RazonSocial.Text;
			empresa.NombreFantasia = NombreFantasia.Text;
			empresa.TelefonoEmpresa = Telefono.Text;
			empresa.Rubro = Rubro.Text;
			empresa.Cuit = Cuit.Text;
			empresa.CalleEmpresa = CalleEmpresa.Text;
			empresa.NroEmpresa = NroEmpresa.Text;
			empresa.DptoEmpresa = DptoEmpresa.Text;
			empresa.PisoEmpresa = PisoEmpresa.Text;
			empresa.BarrioEmpresa = BarrioEmpresa.Text;
			empresa.CPEmpresa = CPEmpresa.Text;
			empresa.LocalidadEmpresa = int.Parse(cmbLocalidad.SelectedValue);
			empresa.ProvinciaEmpresa = int.Parse(cmbProvincia.SelectedValue);
            empresa.Observaciones = txtObservaciones.Text;
			bool resultado=empresa.Crear();

			if (resultado==false)
			{
				Response.Redirect("/PaginaError.aspx");	
			}
			else
			{
				if (direccionRetorno=="")
					Response.Redirect("ListaEmpresas.aspx");
				else
					Response.Redirect(direccionRetorno);		
			}
		}

		protected void Cancelar_Click(object sender, System.EventArgs e)
		{
			if (direccionRetorno=="")
				Response.Redirect("ListaEmpresas.aspx");
			else
				Response.Redirect(direccionRetorno);
		}



	}
}
