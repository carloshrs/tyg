using System;
using System.Data;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;
using ar.com.TiempoyGestion.BackEnd.Clientes.Dal;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.Admin.Clientes
{
	/// <summary>
	/// Summary description for Principal.
	/// </summary>
	public partial class ListaCtaCte : Page
	{

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				ListaClientes();
				PopulateListaCtaCte();
			}
		}

		#region Web Form Designer generated code
		protected override void OnInit(EventArgs e)
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

		private void PopulateListaCtaCte()
		{
			ListaInformes();
			ListaCaracteres();
			dgridEncabezados.DataSource = CuentaCorrienteDal.Listar(Convert.ToInt32(cmbClientes.SelectedValue), -1, chkSoloMias.Checked);
			dgridEncabezados.DataBind();
			lblSaldo.Text = CuentaCorrienteDal.CalcularSaldo(Convert.ToInt32(cmbClientes.SelectedValue),-1).ToString("c");
		}

		private void ListaCaracteres()
		{
			UtilesApp Tipos = new UtilesApp();
			cmbCaracter.Items.Clear();
			DataTable myTb;
			myTb = Tipos.TraerCaracter();
			cmbCaracter.Items.Add(new ListItem("Todos","0"));
			ListItem myItem;
			foreach (DataRow myRow in myTb.Rows)
			{
				myItem = new ListItem(myRow[1].ToString(), myRow[0].ToString());
				cmbCaracter.Items.Add(myItem);
			}
		}

		private void ListaClientes()
		{
			ClienteDal Clientes = new ClienteDal();
			cmbClientes.Items.Clear();
			DataTable myTable = Clientes.CargarDatos();
			cmbClientes.Items.Add(new ListItem("Todos los Clientes","-1"));
			ListItem myItem;
			foreach (DataRow myRow in myTable.Rows)
			{
				myItem = new ListItem(myRow[1].ToString(), myRow[0].ToString());
				cmbClientes.Items.Add(myItem);
			}
		}

		private void ListaInformes()
		{
			BandejaEntradaDal Tipos = new BandejaEntradaDal();
			cmbTipoInforme.Items.Clear();
			DataTable myTable = Tipos.TraerTiposInformes();
			cmbTipoInforme.Items.Add(new ListItem("Todos los Tipos de Informes","-1"));
			ListItem myItem;
			foreach (DataRow myRow in myTable.Rows)
			{
				myItem = new ListItem(myRow[0].ToString(), myRow[1].ToString());
				cmbTipoInforme.Items.Add(myItem);
			}
		}

		protected void btnFiltro_Click(object sender, EventArgs e)
		{
			DateTime dtAuxInicio = DateTime.MinValue;
			DateTime dtAuxFinal = DateTime.MaxValue;

			if (txtFechaInicio.Text != "")
				DateTime.ParseExact(txtFechaInicio.Text, "d/M/yyyy", DateTimeFormatInfo.InvariantInfo);
			if (txtFechaFinal.Text != "")
				DateTime.ParseExact(txtFechaFinal.Text, "d/M/yyyy", DateTimeFormatInfo.InvariantInfo);

			dgridEncabezados.DataSource = CuentaCorrienteDal.Listar(Convert.ToInt32(cmbClientes.SelectedValue),
																	Convert.ToInt32(cmbTipoInforme.SelectedValue),
																	Convert.ToByte(cmbCaracter.SelectedValue),
																	dtAuxInicio,
																	dtAuxFinal,
																	chkSoloMias.Checked);
			dgridEncabezados.DataBind();
			lblSaldo.Text = CuentaCorrienteDal.CalcularSaldo(Convert.ToInt32(cmbClientes.SelectedValue),
				Convert.ToInt32(cmbTipoInforme.SelectedValue),
				Convert.ToByte(cmbCaracter.SelectedValue),
				dtAuxInicio,
				dtAuxFinal).ToString("c");
		}

		protected void dgridEncabezados_PreRender(object sender, EventArgs e)
		{
			string strRedir = "";
			foreach (DataGridItem myItem in dgridEncabezados.Items)
			{
				switch(myItem.Cells[4].Text)
				{
					case "1": //Realizar Informe de Propiedad
						//Response.Redirect("/InformePropiedad/VerInforme.aspx?id="+ e.Item.Cells[0].Text + "&IdTipo=1");
						strRedir = "/InformePropiedad/VerInforme.aspx?id="+ myItem.Cells[9].Text + "&IdTipo=1";
						break;
					case "5": //Realizar Verificacion de domicilio particular
						//Response.Redirect("/verifDomParticular/VerInforme.aspx?id="+ e.Item.Cells[0].Text + "&IdTipo=5");
						strRedir = "/verifDomParticular/VerInforme.aspx?id="+ myItem.Cells[9].Text + "&IdTipo=5";
						break;
					case "6": //Realizar Verificacion de domicilio laboral
						//Response.Redirect("/verifDomLaboral/VerInforme.aspx?id="+ e.Item.Cells[0].Text + "&IdTipo=6");
						strRedir = "/verifDomLaboral/VerInforme.aspx?id="+ myItem.Cells[9].Text + "&IdTipo=6";
						break;
					case "7": //Realizar Verificacion de domicilio comercial
						//Response.Redirect("/verifDomComercial/VerInforme.aspx?id="+ e.Item.Cells[0].Text + "&IdTipo=7");
						strRedir = "/verifDomComercial/VerInforme.aspx?id="+ myItem.Cells[9].Text + "&IdTipo=7";
						break;
				}

				((ImageButton) myItem.FindControl("ibutVer")).Attributes.Add("onclick", "javascript: window.open('" + strRedir + "','','tools=no,width=720,menus=no'); return false;");


			}
		}

		protected void btnBuscar_Click(object sender, EventArgs e)
		{
			PopulateListaCtaCte();
		}

		protected void btnCerrar_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("/default.aspx");
		}

	}
}