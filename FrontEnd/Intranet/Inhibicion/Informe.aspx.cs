using System;
using System.Data;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;
using ar.com.TiempoyGestion.BackEnd.Gravamenes.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.Inhibicion
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
		protected Label Label8;
		protected TextBox txtMovParticular;
	
		protected void Page_Load(object sender, EventArgs e)
		{
			idInforme.Value = Request.QueryString["id"];
            //this.GetPostBackEventReference(this);

			if (!Page.IsPostBack)
			{
				if(Request.QueryString["id"] != null)
				{	
					LoadInhibicion(int.Parse(idInforme.Value));
                    ListarResultados(int.Parse(idInforme.Value));
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

        private void LoadInhibicion(int Id)
		{
			InhibicionesDal oInhibicion = new InhibicionesDal();
			bool cargar = oInhibicion.Cargar(Id);
			if (cargar)
			{
				idReferencia.Value = (1).ToString();
				CargarForm(oInhibicion);
			}
			else
			{
				idReferencia.Value = (0).ToString();
				EncabezadoApp oEncabezado = new EncabezadoApp();
				oEncabezado.cargarEncabezado(Id);
				CargarEncabezado(oEncabezado);
                CargarDatosContacto(oEncabezado);
			}
		}


		private void CargarEncabezado(EncabezadoApp oEncabezado)
		{
			cmbTipoPersona.SelectedValue = oEncabezado.IdTipoPersona.ToString();
			SelectTipoPersona(oEncabezado.IdTipoPersona);

			txtNombre.Text = oEncabezado.Nombre;
			txtApellido.Text = oEncabezado.Apellido;
			CargarTipoDocumento(oEncabezado.TipoDocumento);
			txtDocumento.Text = oEncabezado.Documento;

			//EMPRESA
			RazonSocial.Text = oEncabezado.RazonSocial;
			Cuit.Text = oEncabezado.Cuit;
			//txtObservaciones.Text = oEncabezado.Comentarios;
		}


		private void CargarForm(InhibicionesDal oInhibicion)
		{
			CultureInfo myInfo = new CultureInfo("es-AR");

			idInforme.Value= oInhibicion.IdInforme.ToString();

			cmbTipoPersona.SelectedValue = oInhibicion.IdTipoPersona.ToString();
			SelectTipoPersona(oInhibicion.IdTipoPersona);

			txtNombre.Text= oInhibicion.Nombre;
			txtApellido.Text = oInhibicion.Apellido;
			CargarTipoDocumento(oInhibicion.TipoDocumento);
			txtDocumento.Text = oInhibicion.Documento;
			//EMPRESA
			RazonSocial.Text = oInhibicion.RazonSocial;
			Cuit.Text = oInhibicion.Cuit;
			txtObservaciones.Text = oInhibicion.Observaciones;

		}

        private void ListarResultados(int idInforme)
        {
            InhibicionesDal oInhibicion = new InhibicionesDal();
            dgResultados.DataSource = oInhibicion.TraerResultados(idInforme);
            dgResultados.DataBind();
        }

		protected void Cancelar_Click(object sender, EventArgs e)
		{
			Response.Redirect("/BandejaEntrada/Principal.aspx?idTipo=16");
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



		protected void AceptarFinalizar_Click(object sender, System.EventArgs e)
		{
			string strScript;
			strScript = "<script languaje=\"Javascript\">";
            strScript += "window.showModalDialog('/BandejaEntrada/PopUpCambioEstado.aspx?idTipo=16&idInforme=" + idInforme.Value + "&Finalizar=1','','dialogWidth:400px;dialogHeight:250px');";
			strScript += "document.location.href = '/BandejaEntrada/Principal.aspx?idTipo=16'";
			strScript += "</script>";
			ActualizarInforme();

			Page.RegisterStartupScript("CambiarEstado", strScript);
		}


		protected void Aceptar_Click(object sender, System.EventArgs e)
		{
			ActualizarInforme();
			
			Response.Redirect("/BandejaEntrada/Principal.aspx?idTipo=16");
		}

		private void ActualizarInforme()
		{
			InhibicionesDal oInhibicion = new InhibicionesDal();
			bool cargar = oInhibicion.Cargar(int.Parse(idInforme.Value));
			// Usuario Logueado
			UsuarioAutenticado Usuario = (UsuarioAutenticado)Session["UsuarioAutenticado"];
			oInhibicion.IdCliente = Usuario.IdCliente;
			oInhibicion.IdUsuario = Usuario.IdUsuario;
			
			oInhibicion.IdInforme = int.Parse(idInforme.Value);
			
			oInhibicion.IdTipoPersona = int.Parse(cmbTipoPersona.SelectedValue);

			oInhibicion.Nombre = txtNombre.Text;
			oInhibicion.Apellido = txtApellido.Text;
			oInhibicion.TipoDocumento = int.Parse(cmbTipoDocumento.SelectedItem.Value);
			oInhibicion.Documento = txtDocumento.Text;
			//EMPRESA
			oInhibicion.RazonSocial = RazonSocial.Text;
			oInhibicion.Cuit = Cuit.Text;

			oInhibicion.Observaciones = txtObservaciones.Text.ToUpper();

			if(int.Parse(idReferencia.Value) == 0)
				oInhibicion.Crear();
			else
				oInhibicion.Modificar(int.Parse(idInforme.Value));
		
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


		protected void cmbTipoPersona_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			SelectTipoPersona(int.Parse(cmbTipoPersona.SelectedValue)); 
		}

		private void SelectTipoPersona(int idTipo)
		{
			if (idTipo == 1) 
			{
				pnlDomComercial.Visible = false;
				pnlParticulares.Visible = true;
			} 
			else 
			{
				pnlDomComercial.Visible = true;
				pnlParticulares.Visible = false;
			}
		}


        protected void dgResultados_PreRender(object sender, System.EventArgs e)
        {
            foreach (DataGridItem myItem in dgResultados.Items)
            {
                ((ImageButton)myItem.FindControl("Editar")).Attributes.Add("onclick", "window.showModalDialog('abmResultado.aspx?idInforme=" + idInforme.Value + "&idResultado=" + myItem.Cells[0].Text + "' ,'','dialogWidth:510px;dialogHeight:350px');document.forms[0].submit();");
                ((ImageButton)myItem.FindControl("Borrar")).Attributes.Add("onclick", @"javascript: return confirm('¿Está seguro que desea eliminar el resultado?');");
            }
        }


        protected void dgResultados_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            if (e.Item.Cells[0].Text != "")
            {
                switch (((ImageButton)e.CommandSource).CommandName)
                {
                    case "Borrar":
                        InhibicionesDal oInhibicion = new InhibicionesDal();
                        bool borrar = oInhibicion.BorrarResultado(Convert.ToInt32(e.Item.Cells[0].Text));
                        break;
                }
                ListarResultados(int.Parse(idInforme.Value));
            }
        }

	}
}
