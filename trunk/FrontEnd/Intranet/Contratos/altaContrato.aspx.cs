using System;
using System.Data;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;
using ar.com.TiempoyGestion.BackEnd.Clientes.Dal;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.Dal;
using ar.com.TiempoyGestion.BackEnd.Contratos.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.Contratos
{
	/// <summary>
	/// Summary description for altaInforme.
	/// </summary>
	public partial class altaContrato : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox Provincia;
		
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				ListaClientes();
			}

		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			// Put user code to initialize the page here
            Aceptar.Attributes.Add("onclick", "javascript: deshabilitarBotones(" + Aceptar.ClientID + ");");
			CargarTipoContrato();
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


		protected void Aceptar_Click(object sender, System.EventArgs e)
		{
			ContratoAPP contrato = new ContratoAPP();
			contrato.IdTipo = int.Parse(cmbTipoContrato.SelectedValue);
			// Usuario Logueado
			UsuarioAutenticado Usuario = (UsuarioAutenticado)Session["UsuarioAutenticado"];
			contrato.IdCliente = int.Parse(cmbClientes.SelectedValue);
            if (cmbUsuarios.SelectedValue.ToString() != "") contrato.UsuarioCliente = cmbUsuarios.SelectedValue.ToString();
			else contrato.UsuarioCliente = txtPersona.Text;
			contrato.IdUsuario = Usuario.IdUsuario;
			contrato.Descripcion = Observaciones.Text.ToString();

			contrato.Numero = txtNumero.Text.ToString();
			contrato.FechaInicio = txtFechaInicio.Text.ToString();
			contrato.FechaFin = txtFechaFin.Text.ToString();
			
			
			int idNewContrato = contrato.Crear();
			Response.Redirect("ListaPersonas.aspx?Id=" + idNewContrato);
		}

		private void CargarTipoContrato()
		{
			ContratosDal Tipos = new ContratosDal();
			cmbTipoContrato.DataSource = Tipos.TraerTipoContrato();
			cmbTipoContrato.DataTextField = "Descripcion";
			cmbTipoContrato.DataValueField = "idTipoContrato";
			cmbTipoContrato.DataBind();
		}

		private void ListaClientes()
		{
            ClienteDal Clientes = new ClienteDal();
            cmbClientes.Items.Clear();
            DataTable myTable = Clientes.CargarDatos();
            ListItem vSeleccione = new ListItem("Seleccione un Cliente", "");
            cmbClientes.Items.Add(vSeleccione);
            ListItem myItem;
            string nombreEmpresa = "";
            foreach (DataRow myRow in myTable.Rows)
            {
                if (myRow[2].ToString() != "")
                {
                    nombreEmpresa = myRow[2].ToString();
                    if (myRow[3].ToString() != "")
                        nombreEmpresa = nombreEmpresa + " (" + myRow[3].ToString() + ")";
                }
                else
                    nombreEmpresa = myRow[1].ToString();

                myItem = new ListItem(nombreEmpresa.Trim(), myRow[0].ToString());
                cmbClientes.Items.Add(myItem);
            }
		}

		private void ListaUsuarios(int idCliente)
		{
			Usuario Usuarios = new Usuario();
			cmbUsuarios.Items.Clear();
			DataTable myTable = Usuarios.Listar("", idCliente);
            ListItem vSeleccione = new ListItem("Seleccione un Usuario", "");
            cmbUsuarios.Items.Add(vSeleccione);
			ListItem myItem;
			foreach (DataRow myRow in myTable.Rows)
			{
				myItem = new ListItem(myRow[3].ToString() + ", " + myRow[2].ToString(), myRow[0].ToString());
				cmbUsuarios.Items.Add(myItem);
			}
		}

		protected void cmbClientes_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (cmbClientes.SelectedValue != "")
				ListaUsuarios(int.Parse(cmbClientes.SelectedValue));
		}

		protected void cmbUsuarios_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (cmbUsuarios.SelectedValue != "")
			{
				valPersona.Visible = false;
				txtPersona.Enabled = false;
				txtPersona.Text = "";
			}
			else
			{
				valPersona.Visible = true;
				txtPersona.Enabled = true;
			}
		}

	}
}
