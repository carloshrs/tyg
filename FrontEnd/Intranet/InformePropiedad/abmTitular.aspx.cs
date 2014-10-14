using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.App;
using ar.com.TiempoyGestion.BackEnd.Informes.Dal;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.App;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.InformePropiedad
{
	/// <summary>
	/// Summary description for abmTitular.
	/// </summary>
	public partial class abmTitular : Page
	{
	
		protected void Page_Load(object sender, EventArgs e)
		{
			// Put user code to initialize the page here
			if(!Page.IsPostBack)
			{
				idInforme.Value = Request.QueryString["idInforme"];
				totalPorcentaje.Value = Request.QueryString["porcTotal"];
				itemPorcentaje.Value = Request.QueryString["porc"];
				if(Request.QueryString["idTitular"] != null)
				{
					idTitularInmueble.Value = Request.QueryString["idTitular"];
					CargarTitular(int.Parse(Request.QueryString["idTitular"]));
				}
				else
				{
					CargarTipoDocumento(-1);
					CargarEstadoCivil(-1);
					SelectTipoPersona(1);
				}
			}
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
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

		private void CargarTitular(int idTitular)
		{
			InformePropiedadApp objInformePropiedad = new InformePropiedadApp();
			objInformePropiedad.cargarTitular(idTitular);
			cmbTipoPersona.SelectedValue = objInformePropiedad.TipoPersona.ToString();
			SelectTipoPersona(objInformePropiedad.TipoPersona);
			txtNombre.Text = objInformePropiedad.NombreTitular;
			txtApellido.Text = objInformePropiedad.ApellidoTitular;
			CargarTipoDocumento(objInformePropiedad.TipoDocTitular);
            if(objInformePropiedad.NroDocTitular != "0" )
			    txtDocumento.Text = objInformePropiedad.NroDocTitular;
			CargarEstadoCivil(objInformePropiedad.EstadoCivilTitular);
			txtNombreFantasia.Text = objInformePropiedad.NombreFantasiaTitular;
			txtRazonSocial.Text = objInformePropiedad.RazonSocialTitular;
			txtRubro.Text = objInformePropiedad.RubroTitular;
			txtCUIT.Text = objInformePropiedad.CUITTitular;
			txtPorcentaje.Text = objInformePropiedad.PorcentajeTitular.ToString();
		}

		protected void Aceptar_Click(object sender, EventArgs e)
		{
			InformePropiedadApp oInformePropiedad = new InformePropiedadApp();
			//bool cargar = oInformePropiedad.cargarTitular(int.Parse(idTitularInmueble.Value));
            // Usuario Logueado
            UsuarioAutenticado Usuario = (UsuarioAutenticado)Session["UsuarioAutenticado"];
            oInformePropiedad.IdCliente = Usuario.IdCliente;
            oInformePropiedad.IdUsuario = Usuario.IdUsuario;

			oInformePropiedad.IdInforme = int.Parse(idInforme.Value);
			oInformePropiedad.TipoPersona = int.Parse(cmbTipoPersona.SelectedValue);
			oInformePropiedad.NombreTitular = txtNombre.Text.ToUpper();
            oInformePropiedad.ApellidoTitular = txtApellido.Text.ToUpper();
			if(cmbTipoDocumento.SelectedItem.Value != "")
                oInformePropiedad.TipoDocTitular = int.Parse(cmbTipoDocumento.SelectedItem.Value);
            oInformePropiedad.NroDocTitular = txtDocumento.Text.ToUpper();
			if(cmbEstadoCivil.SelectedItem.Value != "")
                oInformePropiedad.EstadoCivilTitular = int.Parse(cmbEstadoCivil.SelectedItem.Value);
            oInformePropiedad.CUITTitular = txtCUIT.Text.ToUpper();
            oInformePropiedad.NombreFantasiaTitular = txtNombreFantasia.Text.ToUpper();
            oInformePropiedad.RazonSocialTitular = txtRazonSocial.Text.ToUpper();
            oInformePropiedad.RubroTitular = txtRubro.Text.ToUpper();
            oInformePropiedad.PorcentajeTitular = txtPorcentaje.Text.ToUpper();
			
			if(Request.QueryString["idTitular"] != null)
				oInformePropiedad.ModificarTitular(int.Parse(Request.QueryString["idTitular"]));
			else
				oInformePropiedad.CrearTitular();

            if (oInformePropiedad.NombreTitular != "")
            {
                PersonasAPP persona = new PersonasAPP();
                persona.Nombre = txtNombre.Text;
                persona.Apellido = txtApellido.Text;
                if (cmbEstadoCivil.SelectedValue != "") { persona.EstadoCivil = int.Parse(cmbEstadoCivil.SelectedValue); }
                persona.TipoDocumento = int.Parse(cmbTipoDocumento.SelectedItem.Value);
                persona.Documento = txtDocumento.Text;
                bool resultado = persona.Crear();
            }


			Page.RegisterClientScriptBlock("cerrar", "<script>window.close();</script>");
		}


		private void CargarTipoDocumento(int idTipo)
		{
            cmbTipoDocumento.Items.Clear();
            TipoDocumentoApp objTipoDocumento = new TipoDocumentoApp();
			DataTable dtTipoDoc = objTipoDocumento.TraerDatos();
			ListItem myItem;
            myItem = new ListItem("", "");
            cmbTipoDocumento.Items.Add(myItem);
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

		private void CargarEstadoCivil(int idEstado)
		{
            cmbEstadoCivil.Items.Clear();
            EstadoCivilApp objEstadoCivil = new EstadoCivilApp();
			DataTable dtEstadoCivil = objEstadoCivil.TraerDatos();
			ListItem myItem;
            myItem = new ListItem("", "");
            cmbEstadoCivil.Items.Add(myItem);
			foreach(DataRow myRow in dtEstadoCivil.Rows)
			{
				myItem = new ListItem(myRow[1].ToString(), myRow[0].ToString());
				if(idEstado == int.Parse(myRow[0].ToString()))
				{
					cmbEstadoCivil.SelectedIndex = -1;
					myItem.Selected = true;
				}
				cmbEstadoCivil.Items.Add(myItem);
			}
		}

		protected void Cancelar_Click(object sender, EventArgs e)
		{
			Page.RegisterClientScriptBlock("cerrar", "<script>window.close();</script>");
		}


		protected void cmbTipoPersona_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			SelectTipoPersona(int.Parse(cmbTipoPersona.SelectedValue)); 
		}

		private void SelectTipoPersona(int idTipo)
		{
			if (idTipo == 1) 
			{
				pnlJuridico.Visible = false;
				pnlFisica.Visible = true;
			} 
			else 
			{
				pnlJuridico.Visible = true;
				pnlFisica.Visible = false;
			}
		}



        protected void txtDocumento_TextChanged(object sender, EventArgs e)
        {
            if (txtDocumento.Text != "")
            {
                DataTable dt = null;
                if (cmbTipoDocumento.SelectedValue == "")
                    dt = ControlPersonasDal.ControlarDocumento(txtDocumento.Text);
                else
                    dt = ControlPersonasDal.ControlarDocumento(int.Parse(cmbTipoDocumento.SelectedValue), txtDocumento.Text);
                if (dt.Rows.Count != 0)
                {
                    DataRow dr = dt.Rows[0];
                    txtApellido.Text = dr["Apellido"].ToString();
                    txtNombre.Text = dr["Nombre"].ToString();
                    CargarEstadoCivil(int.Parse(dr["EstadoCivil"].ToString()));
                    CargarTipoDocumento(int.Parse(dr["Tipodni"].ToString()));
                    txtPorcentaje.Focus();
                    lblResultado.Text = "";
                }
                else
                {
                    txtApellido.Focus();
                    lblResultado.Text = "*No hay resultados";
                }
            }
                /*
            else
            {
                txtApellido.Focus();
                lblResultado.Text = "";
            }
                 */
            
        }


        protected void btnObtener_PreRender(object sender, EventArgs e)
        {
            btnObtener.Attributes.Add("onClick", "if(document.getElementById('txtDocumento').value != ''){GetServerTime(document.getElementById('txtDocumento').value);}else{alert('Ingrese el número de documento'); return false;}");
        }
}
}
