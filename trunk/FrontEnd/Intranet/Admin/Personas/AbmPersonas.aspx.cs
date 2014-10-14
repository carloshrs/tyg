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
	public partial class AbmPersonas : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox Provincia;
		private int idPersona;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(Request.QueryString["Id"] != null)
			{	
				idPersona = int.Parse(Request.QueryString["Id"]);
				if (!Page.IsPostBack) 
				{
					CargarPersona(idPersona);
				}
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
			PersonasAPP persona = new PersonasAPP();

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
			bool resultado=persona.Modificar(idPersona);

			if (resultado==false)
			{
				Response.Redirect("/PaginaError.aspx");	
			}
			else
				Response.Redirect("ListaPersonas.aspx");				
		}

		private void CargarPersona(int id) 
		{
			PersonasAPP persona = new PersonasAPP();
			persona.Cargar(id);

			Nombre.Text = persona.Nombre;
			Apellido.Text= persona.Apellido;
			//Cargo Estado Civil
			LoadEstadoCivil(persona.EstadoCivil);
			//Cargo Tipo DNI
			LoadTipoDNI(persona.TipoDocumento, cmbTipoDocumento);
			Documento.Text= persona.Documento;
			Calle.Text= persona.Calle;
			Nro.Text= persona.Nro;
			Dpto.Text= persona.Dpto;
			Piso.Text= persona.Piso;
			barrio.Text= persona.Barrio;
			CP.Text= persona.CP;
			// Domicilio Particular
			CargarComboProvincias(cmbProvincia, persona.Provincia);
			CargarComboLocalidades(cmbProvincia, cmbLocalidad, persona.Localidad.ToString());

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
	}
}
