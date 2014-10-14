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
	public partial class AbmEmpresa : System.Web.UI.Page
	{
		#region Elementos Web

		protected System.Web.UI.WebControls.TextBox Provincia;
		protected System.Web.UI.WebControls.TextBox Documento;
		protected System.Web.UI.WebControls.DropDownList cmbTipoDocumento;
		protected System.Web.UI.WebControls.DropDownList cmbEstadoCivil;
		protected System.Web.UI.WebControls.TextBox Nombre;
		protected System.Web.UI.WebControls.RequiredFieldValidator reqNombre;
		protected System.Web.UI.WebControls.TextBox Apellido;
		protected System.Web.UI.WebControls.RequiredFieldValidator reqApellido;
		protected System.Web.UI.WebControls.TextBox CP;
		protected System.Web.UI.WebControls.TextBox barrio;
		protected System.Web.UI.WebControls.TextBox Piso;
		protected System.Web.UI.WebControls.TextBox Dpto;
		protected System.Web.UI.WebControls.TextBox Nro;
		protected System.Web.UI.WebControls.TextBox Calle;
		protected System.Web.UI.WebControls.Panel pnlPersona;
		protected System.Web.UI.WebControls.RequiredFieldValidator reqDNI;
		private int idEmpresa;

		#endregion
	
		#region Page_Load(object sender, System.EventArgs e)

		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(Request.QueryString["Id"] != null)
			{	
				idEmpresa = int.Parse(Request.QueryString["Id"]);
				if (!Page.IsPostBack) 
				{
					CargarEmpresa(idEmpresa);
				}
			}
			
		}

		#endregion

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			// Put user code to initialize the page here
			// Domicilio Particular
			CargarComboProvincias(cmbProvincia, "2");
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

		#region Métodos Privados

		#region CargarEmpresa(int id) 
			
		private void CargarEmpresa(int id) 
		{
			EmpresasAPP empresa = new EmpresasAPP();
			empresa.Cargar(id);

			//EMPRESA
			RazonSocial.Text = empresa.RazonSocial;
			NombreFantasia.Text = empresa.NombreFantasia;
			Telefono.Text = empresa.TelefonoEmpresa;
			Rubro.Text = empresa.Rubro;
			Cuit.Text = empresa.Cuit;
			CalleEmpresa.Text = empresa.CalleEmpresa;
			NroEmpresa.Text = empresa.NroEmpresa;
			DptoEmpresa.Text = empresa.DptoEmpresa;
			PisoEmpresa.Text = empresa.PisoEmpresa;
			BarrioEmpresa.Text = empresa.BarrioEmpresa;
			CPEmpresa.Text = empresa.CPEmpresa;
			// Empresas
			CargarComboProvincias(cmbProvincia, empresa.ProvinciaEmpresa.ToString());
			CargarComboLocalidades(cmbProvincia, cmbLocalidad, empresa.LocalidadEmpresa.ToString());
            txtObservaciones.Text = empresa.Observaciones;
		}

		#endregion

		#region CargarComboLocalidades(DropDownList comboProvincias, DropDownList comboLocalidades, string IdLocalidad)

		private void CargarComboLocalidades(DropDownList comboProvincias, DropDownList comboLocalidades, string IdLocalidad)
		{
			UtilesApp Tipos = new UtilesApp();
			comboLocalidades.Items.Clear();
			DataTable myTb;
			myTb = Tipos.TraerLocalidades(int.Parse(comboProvincias.SelectedItem.Value));
			ListItem myItem;

			if (comboProvincias.SelectedItem.Value.CompareTo("-1")==0)
				myItem = new ListItem("Seleccione Provincia","-1");
			else
				myItem = new ListItem("Seleccione Localidad","-1");

			comboLocalidades.Items.Add(myItem);

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

		#endregion

		#region CargarComboProvincias(DropDownList comboProvincia, string IdProvincia)

		private void CargarComboProvincias(DropDownList comboProvincia, string IdProvincia)
		{
			UtilesApp Tipos = new UtilesApp();
			comboProvincia.Items.Clear();
			DataTable myTb;
			myTb = Tipos.TraerProvincias();
			ListItem myItem;

			myItem = new ListItem("Seleccione Provincia","-1");
			comboProvincia.Items.Add(myItem);

			foreach(DataRow myRow in myTb.Rows)
			{
				myItem = new ListItem(myRow[1].ToString(), myRow[0].ToString());
				
				if(IdProvincia == myRow[0].ToString())
				{
					comboProvincia.SelectedIndex = -1;
					myItem.Selected = true;
				}				
				comboProvincia.Items.Add(myItem);
			}
		}

		#endregion
		
		#endregion

		#region Eventos

		#region Aceptar_Click(object sender, System.EventArgs e)
		
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
			bool resultado=empresa.Modificar(idEmpresa);
			
			if (resultado==false)
			{
				Response.Redirect("/PaginaError.aspx");	
			}
			else
				Response.Redirect("ListaEmpresas.aspx");			
		}

		#endregion

		#region cmbProvincia_SelectedIndexChanged_1(object sender, System.EventArgs e)

		protected void cmbProvincia_SelectedIndexChanged_1(object sender, System.EventArgs e)
		{
			CargarComboLocalidades(cmbProvincia, cmbLocalidad, "");
		}

		#endregion

		#endregion								
	}
}
