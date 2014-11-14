using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;
using ar.com.TiempoyGestion.BackEnd.Clientes.Dal;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.Dal;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.App;
using ar.com.TiempoyGestion.BackEnd.Informes.Dal;
using System.Globalization;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.defuncion
{
	/// <summary>
	/// Summary description for altaInforme.
	/// </summary>
	public partial class verInforme : Page
	{
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

            InformeDefuncion oDef = new InformeDefuncion();
            oDef.Cargar(Id);
            CargarEncabezado(oDef);
		}


        private void CargarEncabezado(InformeDefuncion oInfDefuncion)
		{
            lblFolio.Text = oInfDefuncion.Folio;
            lblNombre.Text = oInfDefuncion.Nombre;
            lblApellido.Text = oInfDefuncion.Apellido;
            lblDNI.Text = oInfDefuncion.Documento.ToString();
            if(oInfDefuncion.Sexo == 1)
                lblSexo.Text = "Masculino";
            else
                lblSexo.Text = "Femenino";

            if (oInfDefuncion.Fallecido == 1)
            {
                lblFallecido.Text = "SI";
                pnlDetalle.Visible = true;
            }
            else
            {
                lblFallecido.Text = "NO";
                pnlDetalle.Visible = false;
            }


            if (!oInfDefuncion.FechaFallecido.Equals(""))
                lblFechaFallecido.Text = DateTime.Parse(oInfDefuncion.FechaFallecido).ToString("dd/MM/yyyy", DateTimeFormatInfo.InvariantInfo);
            lblActa.Text = oInfDefuncion.Acta;
            lblTomo.Text = oInfDefuncion.Tomo;
            lblFolio.Text = oInfDefuncion.Folio;
            lblLugar.Text = oInfDefuncion.LugarFallecimiento;

            lblObservaciones.Text = oInfDefuncion.Observaciones;

		}


		private void Cancelar_Click(object sender, EventArgs e)
		{
			Response.Redirect("/BandejaEntrada/Principal.aspx?idTipo=19");
		}

	}
}
