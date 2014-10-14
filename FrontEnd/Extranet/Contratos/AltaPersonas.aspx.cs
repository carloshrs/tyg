using System;
using System.Data;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;
using ar.com.TiempoyGestion.BackEnd.Contratos.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.Contratos
{
	/// <summary>
	/// Summary description for altaInforme.
	/// </summary>
	public partial class AltaPersonas : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox Provincia;
		private int idContrato;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
				if(Request.QueryString["Id"] != null)
				{	
					idContrato = int.Parse(Request.QueryString["Id"]);
				} 
				else {
					Response.Redirect("ListaContratos.aspx");
				}
				if (!Page.IsPostBack)
				{
					SelectTipoPersona(1); 
					LoadTipoDNI(-1, cmbTipoDocumento);
					CargarTipoPersona(1);
					LoadEstadoCivil(-1);
					CargarComboProvincias(cmbProvincia, 23);
					CargarComboLocalidades(cmbProvincia, cmbLocalidad, "67");
					CargarComboProvincias(cmbProvinciaEmpresas, 23);
					CargarComboLocalidades(cmbProvinciaEmpresas, cmbLocalidadEmpresas, "67");
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

		private void CargarTipoPersona(int idTipo)
		{
			ContratosDal Tipos = new ContratosDal();
			cmbTipoPersona.Items.Clear();
			DataTable myTb;
			myTb = Tipos.TraerTipoPersona();
			ListItem myItem;
			foreach(DataRow myRow in myTb.Rows)
			{
				myItem = new ListItem(myRow[0].ToString(), myRow[1].ToString());
				if(idTipo.ToString() == myRow[1].ToString())
				{
					cmbTipoPersona.SelectedIndex = -1;
					myItem.Selected = true;
				}
				cmbTipoPersona.Items.Add(myItem);
			}
		}

		protected void Aceptar_Click(object sender, System.EventArgs e)
		{
			PersonaContratoAPP persona = new PersonaContratoAPP();
			persona.IdTipo = int.Parse(cmbTipoPersona.SelectedValue);

			persona.idContrato = idContrato;

			persona.Nombre = Nombre.Text.ToString();
			persona.Apellido = Apellido.Text.ToString();
			persona.EstadoCivil = int.Parse(cmbEstadoCivil.SelectedValue);
			persona.TipoDocumento = int.Parse(cmbTipoDocumento.SelectedValue);
			persona.Documento = Documento.Text;
			// Direccion
			persona.Calle = Calle.Text.ToString();
			persona.Nro = Nro.Text;
			persona.Dpto = Dpto.Text.ToString();
			persona.Piso = Piso.Text.ToString();
			persona.Barrio = barrio.Text.ToString();
			persona.CP = CP.Text.ToString();
			persona.Localidad = int.Parse(cmbLocalidad.SelectedValue);
			persona.Provincia = int.Parse(cmbProvincia.SelectedValue);

			persona.IdTipoPersona= int.Parse(cmbTipo.SelectedValue);
			//EMPRESA
			persona.RazonSocial = RazonSocial.Text;
			persona.NombreFantasia = NombreFantasia.Text;
			persona.TelefonoEmpresa = Telefono.Text;
			persona.Rubro = Rubro.Text;
			persona.Cuit = Cuit.Text;
			persona.CalleEmpresa = CalleEmpresa.Text;
			persona.NroEmpresa = NroEmpresa.Text;
			persona.DptoEmpresa = DptoEmpresa.Text;
			persona.PisoEmpresa = PisoEmpresa.Text;
			persona.BarrioEmpresa = BarrioEmpresa.Text;
			persona.CPEmpresa = CPEmpresa.Text;
			persona.LocalidadEmpresa = int.Parse(cmbLocalidadEmpresas.SelectedValue);
			persona.ProvinciaEmpresa = int.Parse(cmbProvinciaEmpresas.SelectedValue);

			persona.Crear();

			Response.Redirect("ListaPersonas.aspx?tipo=1&Id=" + idContrato);
		
		}


		private void LoadTipoDNI(int DNI, DropDownList cmbTipoDNI)
		{
			UtilesApp Tipos = new UtilesApp();

			cmbTipoDNI.Items.Clear();
			DataTable myTb;
			myTb = Tipos.TraerTipoDocumento();
			ListItem myItem;
			foreach(DataRow myRow in myTb.Rows)
			{
				myItem = new ListItem(myRow[1].ToString(), myRow[0].ToString());
				if(DNI.ToString() == myRow[0].ToString())
				{
					cmbTipoDNI.SelectedIndex = -1;
					myItem.Selected = true;
				}
				cmbTipoDNI.Items.Add(myItem);
			}
		}

		private void LoadEstadoCivil(int EstadoCivil)
		{
			UtilesApp Tipos = new UtilesApp();

			cmbEstadoCivil.Items.Clear();
			DataTable myTb;
			myTb = Tipos.TraerEstadoCivil();
			ListItem myItem;
			foreach(DataRow myRow in myTb.Rows)
			{
				myItem = new ListItem(myRow[1].ToString(), myRow[0].ToString());
				if(EstadoCivil.ToString() == myRow[0].ToString())
				{
					cmbEstadoCivil.SelectedIndex = -1;
					myItem.Selected = true;
				}
				cmbEstadoCivil.Items.Add(myItem);
			}
		}

		protected void Dropdownlist1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			SelectTipoPersona(int.Parse(cmbTipo.SelectedValue)); 
		}

		private void SelectTipoPersona(int idTipo)
		{
			if (idTipo == 1) 
			{
				pnlJuridico.Visible = false;
				pnlPersona.Visible = true;
			} 
			else 
			{
				pnlJuridico.Visible = true;
				pnlPersona.Visible = false;
			}
		}

		protected void cmbProvinciaEmpresas_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			CargarComboLocalidades(cmbProvinciaEmpresas, cmbLocalidadEmpresas, "");
		
		}
	}
}
