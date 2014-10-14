using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;
using ar.com.TiempoyGestion.BackEnd.Clientes.Dal;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.Dal;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;
using ar.com.TiempoyGestion.BackEnd.Informes.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.InformePropiedad
{
	/// <summary>
	/// Summary description for altaInforme.
	/// </summary>
	public partial class verInformeCalle : Page
	{
		protected RequiredFieldValidator reqNombre;
		protected RequiredFieldValidator reqApellido;
		protected DropDownList cmbEstadoCivil;
		protected DropDownList cmbTipoDocumento;
		protected RequiredFieldValidator RequiredFieldValidator2;
		protected RequiredFieldValidator RequiredFieldValidator3;
		protected RequiredFieldValidator RequiredFieldValidator6;
		protected RequiredFieldValidator RequiredFieldValidator7;
		protected DropDownList cmbProvincia;
		protected DropDownList cmbLocalidad;
		private int IdInforme;
	
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if(Request.QueryString["id"] != null)
				{	
					IdInforme = int.Parse(Request.QueryString["id"]);
					LoadInforme(IdInforme);
					ListarTitulares(int.Parse(Request.QueryString["id"]));
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

		private void LoadInforme(int Id)
		{
			EncabezadoApp oEncabezado = new EncabezadoApp();
			oEncabezado.cargarEncabezado(Id);
			ClienteDal cliente = new ClienteDal();
			cliente.Cargar(oEncabezado.IdCliente);
			Usuario usuario = new Usuario();
			usuario.Cargar(oEncabezado.IdUsuario);
			idReferencia.Value = (1).ToString();
			lblNum.Text = Id.ToString();
			lblFec.Text = DateTime.Today.ToShortDateString();
			lblSolicitante.Text = cliente.RazonSocial;

            if (oEncabezado.idReferencia != 0)
                lblRef.Text = oEncabezado.NombreReferencia.ToUpper();
            else if (oEncabezado.UsuarioCliente != "")
                lblRef.Text = oEncabezado.UsuarioCliente.ToUpper();
            else
                lblRef.Text = usuario.Apellido.ToUpper() + ", " + usuario.Nombre.ToUpper();

			CargarEncabezado(oEncabezado);

		}

		private void CargarEncabezado(EncabezadoApp oEncabezado)
		{
			//Visualiza el icono de traer mas datos
			
			lblMatricula.Text= oEncabezado.Matricula;
			lblFolio.Text = oEncabezado.PropFolio;
			lblTomo.Text = oEncabezado.PropTomo;
			lblAnio.Text = oEncabezado.PropAno;

			lblProvincia.Text = CargarProvincias(oEncabezado.Provincia);
			lblLocalidad.Text = CargarLocalidades(oEncabezado.Provincia, oEncabezado.Localidad);
			SelectTipoPropiedad(oEncabezado.PropTipo);
		}


		private void SelectTipoPropiedad(int idTipo)
		{
			switch(idTipo)
			{
				case 1: 
					lblTipoPropiedad.Text = "Nro. de Matricula";
					trMatricula.Visible = false;
					break;
				case 2: 
					lblTipoPropiedad.Text = "Dominio";
					trMatricula.Visible = true;
					break;
				case 3: 
					lblTipoPropiedad.Text = "Nro. de Legajo Especial";
					trMatricula.Visible = true;
					break;
			}
		}

		private string CargarProvincias(int IdProvincia)
		{
			UtilesApp Tipos = new UtilesApp();
			string Provincia= "";
			DataTable myTb;
			myTb = Tipos.TraerProvincias();
			foreach(DataRow myRow in myTb.Rows)
			{
				if(IdProvincia == int.Parse(myRow[0].ToString()))
				{
					Provincia = myRow[1].ToString();
				}
			}
			return Provincia;
		}

		private String CargarLocalidades(int idProvincia, int IdLocalidad)
		{
			UtilesApp Tipos = new UtilesApp();
			DataTable myTb;
			string Localidad = "";
			myTb = Tipos.TraerLocalidades(idProvincia);
			foreach(DataRow myRow in myTb.Rows)
			{
				if(IdLocalidad.ToString() == myRow[0].ToString())
				{
					Localidad = myRow[1].ToString();
				}
			}
			return Localidad;
		}


		private void ListarTitulares(int idInforme)
		{
			InformePropiedadApp objInformePropiedad = new InformePropiedadApp();
			dgTitulares.DataSource = objInformePropiedad.TraerTitulares(idInforme);
			dgTitulares.DataBind();
		}

	}
}
