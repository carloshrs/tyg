using System;
using System.Data;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;
using ar.com.TiempoyGestion.BackEnd.Clientes.Dal;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.Dal;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;
using ar.com.TiempoyGestion.BackEnd.Verificaciones.Dal;
using ar.com.TiempoyGestion.BackEnd.Informes.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.InformeCatastral
{
	/// <summary>
	/// Summary description for altaInforme.
	/// </summary>
	public partial class verInforme : Page
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
				}
				//lblTools.Text = "<input onclick=\"panel.style.visibility='hidden';window.print();panel.style.visibility='visible';\" type=\"image\" src=\"/img/imprimir-2.gif\"> " +
				//	"<input onclick=\"window.close();\" type=\"image\" src=\"/img/log_off.gif\"> " +
				//	"<img src=\"/img/Eterno.gif\"> <input onclick=\"window.showModalDialog('/Admin/Imagenes/VerImagenes.aspx?Informe=" + IdInforme.ToString() + "', '', 'dialogWidth:640px;dialogHeight:480px');\" type=\"image\" src=\"/img/Imagenes.gif\" title=\"Ver más imágenes...\"> ";

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
            InformeCatastralApp oCatastral = new InformeCatastralApp();

			EncabezadoApp oEncabezado = new EncabezadoApp();
			oEncabezado.cargarEncabezado(Id);
			ClienteDal cliente = new ClienteDal();
			cliente.Cargar(oEncabezado.IdCliente);
			Usuario usuario = new Usuario();
			usuario.Cargar(oEncabezado.IdUsuario);

			bool cargar = oCatastral.cargarInformeCatastral(Id);

			if (cargar)
			{
				lblNum.Text = Id.ToString();
				lblFec.Text = DateTime.Today.ToShortDateString();

                string solicitante = "";
                if (cliente.NombreFantasia != null && cliente.NombreFantasia != "")
                    solicitante = cliente.NombreFantasia;
                else
                    solicitante = cliente.RazonSocial;
                if (cliente.Sucursal != null && cliente.Sucursal != "")
                    solicitante = solicitante + " (" + cliente.Sucursal + ")";
                lblSolicitante.Text = solicitante;

                string direccion = "";
                direccion = cliente.Calle + " " + cliente.Numero;
                if (cliente.Piso != "")
                {
                    direccion = direccion + " Piso: " + cliente.Piso;
                    direccion = direccion + " Dpto/Of: " + cliente.Departamento;
                }
                direccion = direccion + ". " + cliente.Barrio;
                lblDireccionSolicitante.Text = direccion;

                if (oEncabezado.idReferencia != 0)
                    lblRef.Text = oEncabezado.NombreReferencia.ToUpper();
                else if (oEncabezado.UsuarioCliente != "")
                    lblRef.Text = oEncabezado.UsuarioCliente.ToUpper();
                else
                    lblRef.Text = usuario.Apellido.ToUpper() + ", " + usuario.Nombre.ToUpper();

				CargarForm(oCatastral);
			}
			else
			{
				CargarEncabezado(oEncabezado);
			}

		}


        private void CargarEncabezado(EncabezadoApp oEncabezado)
		{
            lblProvincia.Text = CargarProvincias(oEncabezado.CatProvincia);
            lblLocalidad.Text = CargarLocalidades(oEncabezado.CatProvincia, oEncabezado.CatLocalidad);
            lblCalle.Text = oEncabezado.Calle;
            lblBarrio.Text = oEncabezado.Barrio;
            lblNro.Text = oEncabezado.Nro;
            lblPiso.Text = oEncabezado.Piso;
            lblDepto.Text = oEncabezado.Dpto;
            lblLote.Text = oEncabezado.Lote;
            lblManzana.Text = oEncabezado.Manzana;
            lblCP.Text = oEncabezado.CP;
            lblComplejo.Text = oEncabezado.Complejo;
            lblTorre.Text = oEncabezado.Torre;
            if (oEncabezado.TipoCatastro == 1)
                lblNomenclatura.Text = oEncabezado.NumeroCatastro;
            else if (oEncabezado.TipoCatastro == 2)
                lblCuenta.Text = oEncabezado.NumeroCatastro;
            lblObservaciones.Text = oEncabezado.Observaciones;
		}


		private void CargarForm(InformeCatastralApp oCatastral)
		{
            lblMatricula.Text = oCatastral.Matricula;
            if (oCatastral.TipoProp == 2 || oCatastral.TipoProp == 3)
            {
                lblFolio.Text = oCatastral.Folio;
                lblTomo.Text = oCatastral.Tomo;
                lblAnio.Text = oCatastral.Ano;
            }
            SelectTipoPropiedad(oCatastral.TipoProp);
            lblCalle.Text = oCatastral.Calle;
            lblBarrio.Text = oCatastral.Barrio;
            lblNro.Text = oCatastral.Nro;
            lblPiso.Text = oCatastral.Piso;
            lblDepto.Text = oCatastral.Depto;
            lblCP.Text = oCatastral.CP;
            lblLote.Text = oCatastral.Lote;
            lblManzana.Text = oCatastral.Manzana;
            lblComplejo.Text = oCatastral.Complejo;
            lblTorre.Text = oCatastral.Torre;
            lblProvincia.Text = CargarProvincias(oCatastral.IdProvincia);
			lblLocalidad.Text = CargarLocalidades(oCatastral.IdProvincia, oCatastral.IdLocalidad);
            lblNomenclatura.Text = oCatastral.Nomenclatura;
            lblCuenta.Text = oCatastral.NroCuenta;
            lblObservaciones.Text = oCatastral.Observaciones;

		}

		private void Cancelar_Click(object sender, EventArgs e)
		{
//			if(idReferencia.Value != null) 
//			{
//				if (int.Parse(idReferencia.Value) > 0) Response.Redirect("/Extranet/Referencias/altaReferencia.aspx?IdReferencia=" + idReferencia.Value);
//				else Response.Redirect("ListaInformes.aspx");
//			} 				
//			else Response.Redirect("ListaInformes.aspx");
			Response.Redirect("/BandejaEntrada/Principal.aspx?idTipo=" + Request.QueryString["idTipo"]);
		}



		private string LoadTipoPropiedad(int idTipoPropiedad)
		{
			UtilesApp Tipos = new UtilesApp();
			string TipoPropiedad= "";
			DataTable myTb;
			myTb = Tipos.TraerTipoPropiedad();
			foreach(DataRow myRow in myTb.Rows)
			{
				if(idTipoPropiedad.ToString() == myRow[0].ToString())
				{
					TipoPropiedad = myRow[1].ToString();
				}
			}
			//SelectTipoPropiedad(idTipoPropiedad);	
			return TipoPropiedad;
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

        private void SelectTipoPropiedad(int idTipo)
        {
            switch (idTipo)
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

	}
}
