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
using ar.com.TiempoyGestion.BackEnd.Gravamenes.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Extranet.Inhibicion
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
		protected System.Web.UI.WebControls.Label lblFecha;
		private int IdInforme;
	
		protected void Page_Load(object sender, EventArgs e)
		{

            dlResultados.ItemDataBound +=
             new DataListItemEventHandler(this.Item_Bound);



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
			
			InhibicionesDal oInhibicion = new InhibicionesDal();
			oInhibicion.Cargar(Id);
			CargarForm(oInhibicion);
		}


		private void CargarForm(InhibicionesDal oVerif)
		{
			lblNombre.Text= oVerif.Nombre;
			lblApellido.Text = oVerif.Apellido;
			lblTipoDocumento.Text = LoadTipoDNI(oVerif.TipoDocumento);
			lblDocumento.Text = oVerif.Documento;

			//EMPRESA
			lblRazonSocial.Text= oVerif.RazonSocial;
			lblCUIT.Text= oVerif.Cuit;

			if (oVerif.IdTipoPersona == 1) 
			{
				pnlJuridica.Visible = false;
				pnlFisica.Visible = true;
			} 
			else 
			{
				pnlFisica.Visible = false;
				pnlJuridica.Visible = true;
			}

			lblObservaciones.Text = oVerif.Observaciones;


            dlResultados.DataSource = oVerif.TraerResultados(oVerif.IdInforme);
            dlResultados.DataBind();
            int cantReg = dlResultados.Items.Count;

		}


		private void Cancelar_Click(object sender, EventArgs e)
		{
			Response.Redirect("/BandejaEntrada/Principal.aspx?idTipo=" + Request.QueryString["idTipo"]);
		}



		private string LoadTipoDNI(int DNI)
		{
			UtilesApp Tipos = new UtilesApp();
			string TipoDNI="";
			DataTable myTb;
			myTb = Tipos.TraerTipoDocumento();
			foreach(DataRow myRow in myTb.Rows)
			{
				if(DNI.ToString() == myRow[0].ToString())
				{
					TipoDNI= myRow[1].ToString();			
				}
			}
			return TipoDNI;
		}

        protected void Item_Bound(Object sender, DataListItemEventArgs e)
        {

            if (e.Item.ItemType == ListItemType.Item ||
                e.Item.ItemType == ListItemType.AlternatingItem)
            {
                int nroResto = int.Parse(((DataRowView)e.Item.DataItem).Row.ItemArray[12].ToString()) % 4;

                if (nroResto == 0)
                    //pnSaltoPagina.Visible = true;
                    e.Item.FindControl("pnSaltoPagina").Visible = true;

                /*
            else
                idSaltoPagina.visible = false;
             */
                // Retrieve the Label control in the current DataListItem.
                //Label PriceLabel = (Label)e.Item.FindControl("PriceLabel");

                // Retrieve the text of the CurrencyColumn from the DataListItem
                // and convert the value to a Double.
                //Double Price = Convert.ToDouble(((DataRowView)e.Item.DataItem).Row.ItemArray[2].ToString());

                // Format the value as currency and redisplay it in the DataList.
                //PriceLabel.Text = Price.ToString("c");

            }

        }


	}
}
