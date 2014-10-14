using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.App;
using ar.com.TiempoyGestion.BackEnd.Busquedas.Dal;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.App;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.BusquedaPropiedad
{
	/// <summary>
	/// Summary description for abmTitular.
	/// </summary>
    public partial class abmMatricula : Page
	{
	
		protected void Page_Load(object sender, EventArgs e)
		{
			// Put user code to initialize the page here
			if(!Page.IsPostBack)
			{
				idInforme.Value = Request.QueryString["idInforme"];
                pnlDominioLegEspecial.Visible = false;
                ValtxtFolio.Visible = false;
                if (Request.QueryString["idMatricula"] != null)
				{
                    idMatricula.Value = Request.QueryString["idMatricula"];
                    CargarMatricula(int.Parse(Request.QueryString["idMatricula"]));
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

		private void CargarMatricula(int idMatricula)
		{
            BusquedaPropiedadApp objBusquedaPropiedad = new BusquedaPropiedadApp();
            objBusquedaPropiedad.cargarMatricula(idMatricula);
            LoadTipoPropiedad(objBusquedaPropiedad.PropTipo);
            SelectTipoPropiedad(objBusquedaPropiedad.PropTipo);
            txtLegajo.Text = objBusquedaPropiedad.Matricula;
            txtFolio.Text = objBusquedaPropiedad.PropFolio;
            txtTomo.Text = objBusquedaPropiedad.PropTomo;
            txtAno.Text = objBusquedaPropiedad.PropAno;

		}

		protected void Aceptar_Click(object sender, EventArgs e)
		{
            BusquedaPropiedadApp objBusquedaPropiedad = new BusquedaPropiedadApp();
			//bool cargar = oInformePropiedad.cargarTitular(int.Parse(idTitularInmueble.Value));

            UsuarioAutenticado Usuario = (UsuarioAutenticado)Session["UsuarioAutenticado"];
            objBusquedaPropiedad.IdCliente = Usuario.IdCliente;
            objBusquedaPropiedad.IdUsuario = Usuario.IdUsuario;
            objBusquedaPropiedad.IdInforme = int.Parse(idInforme.Value);
            objBusquedaPropiedad.PropTipo = int.Parse(cmbTipoPropiedad.SelectedValue);
            objBusquedaPropiedad.Matricula = txtLegajo.Text;
            objBusquedaPropiedad.PropFolio = txtFolio.Text;
            objBusquedaPropiedad.PropTomo = txtTomo.Text;
            objBusquedaPropiedad.PropAno = txtAno.Text;

			if(Request.QueryString["idMatricula"] != null)
                objBusquedaPropiedad.ModificarMatricula(int.Parse(Request.QueryString["idMatricula"]));
			else
                objBusquedaPropiedad.CrearMatricula();

			Page.RegisterClientScriptBlock("cerrar", "<script>window.close();</script>");
		}


		protected void Cancelar_Click(object sender, EventArgs e)
		{
			Page.RegisterClientScriptBlock("cerrar", "<script>window.close();</script>");
		}



        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectTipoPropiedad(int.Parse(cmbTipoPropiedad.SelectedValue));
            cmbTipoPropiedad.Focus();
        }


        #region SelectTipoPropiedad(int idTipo)

        private void SelectTipoPropiedad(int idTipo)
        {
            switch (idTipo)
            {
                case 1:
                    pnlDominioLegEspecial.Visible = false;
                    ValtxtFolio.Visible = false;
                    ValMatricula.Visible = true;
                    RequiredFieldValidator6.Enabled = true;
                    lblTipoPropiedad.Text = "Nro. de Matricula";
                    break;
                case 2:
                    lblTipoPropiedad.Text = "Dominio";
                    ValtxtFolio.Visible = true;
                    ValMatricula.Visible = false;
                    pnlDominioLegEspecial.Visible = true;
                    RequiredFieldValidator6.Enabled = true;
                    break;
                case 3:
                    lblTipoPropiedad.Text = "Nro. de Legajo Especial";
                    ValtxtFolio.Visible = true;
                    RequiredFieldValidator6.Enabled = false;
                    ValMatricula.Visible = true;
                    pnlDominioLegEspecial.Visible = true;
                    break;
            }
        }

        #endregion


        #region LoadTipoPropiedad(int idTipoPropiedad)

        private void LoadTipoPropiedad(int idTipoPropiedad)
        {
            UtilesApp Tipos = new UtilesApp();
            cmbTipoPropiedad.Items.Clear();
            DataTable myTb;
            myTb = Tipos.TraerTipoPropiedad();
            ListItem myItem;
            foreach (DataRow myRow in myTb.Rows)
            {
                myItem = new ListItem(myRow[1].ToString(), myRow[0].ToString());
                if (idTipoPropiedad.ToString() == myRow[0].ToString())
                {
                    cmbTipoPropiedad.SelectedIndex = -1;
                    myItem.Selected = true;
                }
                cmbTipoPropiedad.Items.Add(myItem);
            }
            SelectTipoPropiedad(idTipoPropiedad);
        }

        #endregion
}
}
