using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.App;
using ar.com.TiempoyGestion.BackEnd.Automotores.Dal;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.App;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.Automotores
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
					idTitularAutomotor.Value = Request.QueryString["idTitular"];
					CargarTitular(int.Parse(Request.QueryString["idTitular"]));
				}
				else
				{
					CargarTipoDocumento(-1);
					CargarEstadoCivil(-1);
					SelectTipoPersona(1);
                    CargarComboProvincias(cmbProvincia, 2);
                    CargarComboLocalidades(cmbProvincia, cmbLocalidad, "1");
                    CargarComboProvincias(cmbProvinciaEmpresas, 2);
                    CargarComboLocalidades(cmbProvinciaEmpresas, cmbLocalidadEmpresas, "1");
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
			
			AutomotoresApp objAutomotores = new AutomotoresApp();
			objAutomotores.cargarTitular(idTitular);
			cmbTipoPersona.SelectedValue = objAutomotores.IdTipoPersona.ToString();
			SelectTipoPersona(objAutomotores.IdTipoPersona);
			txtNombre.Text = objAutomotores.NombreTitular;
			txtApellido.Text = objAutomotores.ApellidoTitular;
			CargarTipoDocumento(objAutomotores.TipoDocTitular);
			txtDocumento.Text = objAutomotores.NroDocTitular;
			CargarEstadoCivil(objAutomotores.EstadoCivilTitular);
            txtCalle.Text = objAutomotores.Calle;
            txtBarrio.Text = objAutomotores.Barrio;
            txtNro.Text = objAutomotores.Nro;
            txtPiso.Text = objAutomotores.Piso;
            txtDepto.Text = objAutomotores.Depto;
            txtCP.Text = objAutomotores.CP;
            CargarComboProvincias(cmbProvincia, objAutomotores.IdProvincia);
            CargarComboLocalidades(cmbProvincia, cmbLocalidad, objAutomotores.IdLocalidad.ToString());

            
            //EMPRESA
			txtNombreFantasia.Text = objAutomotores.NombreFantasiaTitular;
			txtRazonSocial.Text = objAutomotores.RazonSocialTitular;
			txtRubro.Text = objAutomotores.RubroTitular;
			txtCUIT.Text = objAutomotores.CUITTitular;
            CalleEmpresa.Text = objAutomotores.CalleEmpresa;
            NroEmpresa.Text = objAutomotores.NroEmpresa;
            DptoEmpresa.Text = objAutomotores.DptoEmpresa;
            PisoEmpresa.Text = objAutomotores.PisoEmpresa;
            BarrioEmpresa.Text = objAutomotores.BarrioEmpresa;
            CPEmpresa.Text = objAutomotores.CPEmpresa;
            CargarComboProvincias(cmbProvinciaEmpresas, objAutomotores.ProvinciaEmpresa);
            CargarComboLocalidades(cmbProvinciaEmpresas, cmbLocalidadEmpresas, objAutomotores.LocalidadEmpresa.ToString());


            txtPorcentaje.Text = objAutomotores.PorcentajeTitular.ToString();
		}

		protected void Aceptar_Click(object sender, EventArgs e)
		{
			AutomotoresApp oAutomotores = new AutomotoresApp();
			//bool cargar = oInformePropiedad.cargarTitular(int.Parse(idTitularInmueble.Value));

            UsuarioAutenticado Usuario = (UsuarioAutenticado)Session["UsuarioAutenticado"];
            oAutomotores.IdCliente = Usuario.IdCliente;
            oAutomotores.IdUsuario = Usuario.IdUsuario;

			oAutomotores.IdInforme = int.Parse(idInforme.Value);
			oAutomotores.IdTipoPersona = int.Parse(cmbTipoPersona.SelectedValue);
			oAutomotores.NombreTitular = txtNombre.Text;
			oAutomotores.ApellidoTitular = txtApellido.Text;
			oAutomotores.TipoDocTitular = int.Parse(cmbTipoDocumento.SelectedItem.Value);
			oAutomotores.NroDocTitular = txtDocumento.Text;
			oAutomotores.EstadoCivilTitular = int.Parse(cmbEstadoCivil.SelectedItem.Value);
            oAutomotores.Calle = txtCalle.Text;
            oAutomotores.Barrio = txtBarrio.Text;
            oAutomotores.Nro = txtNro.Text;
            oAutomotores.Piso = txtPiso.Text;
            oAutomotores.Depto = txtDepto.Text;
            oAutomotores.CP = txtCP.Text;
            oAutomotores.IdProvincia = int.Parse(cmbProvincia.SelectedItem.Value);
            oAutomotores.IdLocalidad = int.Parse(cmbLocalidad.SelectedItem.Value);

			oAutomotores.CUITTitular = txtCUIT.Text;
			oAutomotores.NombreFantasiaTitular = txtNombreFantasia.Text;
			oAutomotores.RazonSocialTitular = txtRazonSocial.Text;
			oAutomotores.RubroTitular = txtRubro.Text;
            oAutomotores.CalleEmpresa = CalleEmpresa.Text;
            oAutomotores.NroEmpresa = NroEmpresa.Text;
            oAutomotores.DptoEmpresa = DptoEmpresa.Text;
            oAutomotores.PisoEmpresa = PisoEmpresa.Text;
            oAutomotores.BarrioEmpresa = BarrioEmpresa.Text;
            oAutomotores.CPEmpresa = CPEmpresa.Text;
            oAutomotores.LocalidadEmpresa = int.Parse(cmbLocalidadEmpresas.SelectedValue);
            oAutomotores.ProvinciaEmpresa = int.Parse(cmbProvinciaEmpresas.SelectedValue);

			oAutomotores.PorcentajeTitular = txtPorcentaje.Text;
			
			if(Request.QueryString["idTitular"] != null)
				oAutomotores.ModificarTitular(int.Parse(Request.QueryString["idTitular"]));
			else
				oAutomotores.CrearTitular();

			Page.RegisterClientScriptBlock("cerrar", "<script>window.close();</script>");
		}
        
		private void CargarTipoDocumento(int idTipo)
		{
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

		private void CargarEstadoCivil(int idEstado)
		{
			EstadoCivilApp objEstadoCivil = new EstadoCivilApp();
			DataTable dtEstadoCivil = objEstadoCivil.TraerDatos();
			ListItem myItem;

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


		protected void Cancelar_Click(object sender, EventArgs e)
		{
			Page.RegisterClientScriptBlock("cerrar", "<script>window.close();</script>");
		}
        
		protected void cmbTipoPersona_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			SelectTipoPersona(int.Parse(cmbTipoPersona.SelectedValue));
            cmbTipoPersona.Focus();
		}

        protected void cmbProvincia_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            CargarComboLocalidades(cmbProvincia, cmbLocalidad, "");
            cmbProvincia.Focus();
        }

        protected void cmbProvinciaEmpresas_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            CargarComboLocalidades(cmbProvinciaEmpresas, cmbLocalidadEmpresas, "");
            cmbProvinciaEmpresas.Focus();
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

    }
}
