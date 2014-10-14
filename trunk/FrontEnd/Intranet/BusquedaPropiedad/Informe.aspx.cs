using System;
using System.Data;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.App;
using ar.com.TiempoyGestion.BackEnd.Busquedas.Dal;


namespace ar.com.TiempoyGestion.FrontEnd.Intranet.BusquedaPropiedad
{
	/// <summary>
	/// Summary description for altaInforme.
	/// </summary>
	public partial class Informe : Page
	{
		protected TextBox Provincia;
		protected Image Image1;
		protected Image Image2;
		protected Image Image3;
		protected Image Image4;
		protected Button Cerrar;
		protected Label Label2;
		protected Label Label5;
		protected Label Label8;
		protected TextBox txtMovParticular;
	
		protected void Page_Load(object sender, EventArgs e)
		{
			idInforme.Value = Request.QueryString["id"];

			if (!Page.IsPostBack)
			{
				if(Request.QueryString["id"] != null)
				{	
					LoadVerifBusqueda(int.Parse(idInforme.Value));
					ListarMatriculas(int.Parse(Request.QueryString["id"]));
					
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
			this.dgMatriculas.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgMatriculas_ItemCommand);

		}
		#endregion

		private void LoadVerifBusqueda(int Id)
		{
			BusquedaPropiedadApp oBusqueda = new BusquedaPropiedadApp();
			bool cargar = oBusqueda.Cargar(Id);

            EncabezadoApp oEncabezado = new EncabezadoApp();
            oEncabezado.cargarEncabezado(Id);
            CargarDatosContacto(oEncabezado);

			if (cargar)
			{
				idReferencia.Value = (1).ToString();
				CargarForm(oBusqueda);
			}
			else
			{
				idReferencia.Value = (0).ToString();
				CargarEncabezado(oEncabezado);
			}
		}


		
		private void CargarEncabezado(EncabezadoApp oEncabezado)
		{
			idTipoPersona.Value = oEncabezado.IdTipoPersona.ToString();

			txtNombre.Text = oEncabezado.Nombre;
			txtApellido.Text = oEncabezado.Apellido;
			txtDocumento.Text = oEncabezado.Documento;
			CargarTipoDocumento(oEncabezado.TipoDocumento);
			//EMPRESA
			RazonSocial.Text = oEncabezado.RazonSocial;
			Cuit.Text = oEncabezado.Cuit;
			// Empresas
			CargarComboProvincias(cmbProvinciaEmpresas, oEncabezado.ProvinciaEmpresa);

			if (oEncabezado.IdTipoPersona == 1) 
			{
				pnlDomComercial.Visible = false;
				pnlFisica.Visible = true;
			} else {
				pnlDomComercial.Visible = true;
				pnlFisica.Visible = false;
			}
		}


		private void CargarComboProvincias(DropDownList comboProvincia, int IdProvincia)
		{
			UtilesApp Tipos = new UtilesApp();
			comboProvincia.Items.Clear();
			DataTable myTb;
			myTb = Tipos.TraerProvincias();
			ListItem myItem;
			foreach (DataRow myRow in myTb.Rows)
			{
				myItem = new ListItem(myRow[1].ToString(), myRow[0].ToString());
				if (IdProvincia == int.Parse(myRow[0].ToString()))
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
			foreach (DataRow myRow in myTb.Rows)
			{
				myItem = new ListItem(myRow[1].ToString(), myRow[0].ToString());
				if (IdLocalidad == myRow[0].ToString())
				{
					comboLocalidades.SelectedIndex = -1;
					myItem.Selected = true;
				}
				comboLocalidades.Items.Add(myItem);
			}
		}


		private void CargarForm(BusquedaPropiedadApp oBusqueda)
		{
			CultureInfo myInfo = new CultureInfo("es-AR");

			idInforme.Value= oBusqueda.IdInforme.ToString();
			txtNombre.Text= oBusqueda.Nombre;
			txtApellido.Text = oBusqueda.Apellido;
			CargarTipoDocumento(oBusqueda.IdTipoDoc);
			//CargarEstadoCivil(oBusqueda.EstadoCivil);
			txtDocumento.Text = oBusqueda.NroDoc.ToString();

			idTipoPersona.Value = oBusqueda.IdTipoPersona.ToString();
			//EMPRESA
			RazonSocial.Text = oBusqueda.RazonSocial;
			Cuit.Text = oBusqueda.Cuit;
			// Empresas
			CargarComboProvincias(cmbProvinciaEmpresas, oBusqueda.ProvinciaEmpresa);

			if (oBusqueda.IdTipoPersona == 1) 
			{
				pnlDomComercial.Visible = false;
				pnlFisica.Visible = true;
			} 
			else 
			{
				pnlDomComercial.Visible = true;
				pnlFisica.Visible = false;
			}
			
			txtObservaciones.Text = oBusqueda.Observaciones;
			cmbResultado.SelectedValue = oBusqueda.Resultado;

            EncabezadoApp oEncabezado = new EncabezadoApp();
            oEncabezado.Leido = 1;
            oEncabezado.CambiarLeido(oBusqueda.IdInforme);
		}


		protected void Cancelar_Click(object sender, EventArgs e)
		{
			Response.Redirect("/BandejaEntrada/Principal.aspx?idTipo=13");
		}


		private void CargarTipoDocumento(int idTipo)
		{
			cmbTipoDocumento.Items.Clear();
			TipoDocumentoApp objTipoDocumento = new TipoDocumentoApp();
			DataTable dtTipoDoc = objTipoDocumento.TraerDatos();
			ListItem myItem;

			foreach(DataRow myRow in dtTipoDoc.Rows)
			{
				myItem = new ListItem(myRow[1].ToString(), myRow[0].ToString());
				if(idTipo == int.Parse(myRow[0].ToString()))
				{
					cmbTipoDocumento.SelectedIndex = -1;
					myItem.Selected = true;
				}
				cmbTipoDocumento.Items.Add(myItem);
			}
		}



		private void ListarMatriculas(int idInforme)
		{
			BusquedaPropiedadApp objBusquedaPropiedad = new BusquedaPropiedadApp();
            dgMatriculas.DataSource = objBusquedaPropiedad.TraerMatriculas(idInforme);
			dgMatriculas.DataBind();
		}


		protected void AceptarFinalizar_Click(object sender, EventArgs e)
		{
			string strScript;
			strScript = "<script languaje=\"Javascript\">";
            strScript += "window.showModalDialog('/BandejaEntrada/PopUpCambioEstado.aspx?idTipo=13&idInforme=" + idInforme.Value + "&Finalizar=1','','dialogWidth:400px;dialogHeight:250px');";
			strScript += "document.location.href = '/BandejaEntrada/Principal.aspx?idTipo=13'";
			strScript += "</script>";
			ActualizarInforme();
			Page.RegisterStartupScript("CambiarEstado", strScript);
		}

        protected void dgMatriculas_PreRender(object sender, System.EventArgs e)
		{
			foreach(DataGridItem myItem in dgMatriculas.Items)
			{
				((ImageButton) myItem.FindControl("Editar")).Attributes.Add("onclick","window.showModalDialog('abmMatricula.aspx?idInforme=" + idInforme.Value + "&IdMatricula="+ myItem.Cells[0].Text + "' ,'','dialogWidth:510px;dialogHeight:250px');document.forms[0].submit();");
				((ImageButton) myItem.FindControl("Borrar")).Attributes.Add("onclick", @"javascript: return confirm('¿Está seguro que desea eliminar la Matricula?');");
			}
		}

        protected void dgMatriculas_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.Item.Cells[0].Text != "")
			{
				switch(((ImageButton)e.CommandSource).CommandName)
				{
					case "Borrar":
						BusquedaPropiedadApp objBusquedaPropiedad = new BusquedaPropiedadApp();
						bool borrar = objBusquedaPropiedad.BorrarMatricula(Convert.ToInt32(e.Item.Cells[0].Text));
						break;
				}
				ListarMatriculas(int.Parse(idInforme.Value));
			}
		}

		protected void Aceptar_Click(object sender, System.EventArgs e)
		{
			ActualizarInforme();
			
			Response.Redirect("/BandejaEntrada/Principal.aspx?idTipo=13");

		}

		private void ActualizarInforme()
		{
			BusquedaPropiedadApp objBusquedaAutomotor = new BusquedaPropiedadApp();
			bool cargar = objBusquedaAutomotor.Cargar(int.Parse(idInforme.Value));
			// Usuario Logueado
			UsuarioAutenticado Usuario = (UsuarioAutenticado)Session["UsuarioAutenticado"];
			objBusquedaAutomotor.IdCliente = Usuario.IdCliente;
			objBusquedaAutomotor.IdUsuario = Usuario.IdUsuario;
			
			objBusquedaAutomotor.IdInforme = int.Parse(idInforme.Value);
			objBusquedaAutomotor.Nombre = txtNombre.Text;
			objBusquedaAutomotor.Apellido = txtApellido.Text;
			objBusquedaAutomotor.IdTipoDoc = int.Parse(cmbTipoDocumento.SelectedValue);
			objBusquedaAutomotor.NroDoc = txtDocumento.Text;
			objBusquedaAutomotor.Resultado = cmbResultado.SelectedValue;
			objBusquedaAutomotor.Observaciones = txtObservaciones.Text;
			//EMPRESA
			objBusquedaAutomotor.RazonSocial = RazonSocial.Text;
			objBusquedaAutomotor.Cuit = Cuit.Text;
			objBusquedaAutomotor.ProvinciaEmpresa = int.Parse(cmbProvinciaEmpresas.SelectedValue);
			objBusquedaAutomotor.IdTipoPersona = int.Parse(idTipoPersona.Value);

			if(int.Parse(idReferencia.Value) == 0)
				objBusquedaAutomotor.Crear();
			else
				objBusquedaAutomotor.Modificar(int.Parse(idInforme.Value));

		}

        protected void btnObtener_PreRender(object sender, EventArgs e)
        {
            btnObtener.Attributes.Add("onClick", "GetServerTime(document.getElementById('txtDocumento').value)");
        }


        #region void CargarDatosContacto(EncabezadoApp enc)

        private void CargarDatosContacto(EncabezadoApp enc)
        {
            lblEncTelefono.Text = enc.AMBTelefono;
            lblEncMail.Text = enc.AMBEMail;
            lblEncApeCon.Text = enc.ApellidoCony;
            lblEncNomCon.Text = enc.NombreCony;
            lblEncNroDocCon.Text = enc.AMBDocumento;
            TipoDocumentoApp objTipoDocumento = new TipoDocumentoApp();
            DataTable dtTipoDoc = objTipoDocumento.TraerDatos();
            foreach (DataRow myRow in dtTipoDoc.Rows)
            {
                if (enc.AMBTipoDoc == int.Parse(myRow[0].ToString()))
                {
                    lblEncTipoDocCon.Text = myRow[1].ToString();
                    break;
                }
            }
            lblEncObservaciones.Text = enc.Comentarios;
        }

        #endregion
	}
}
