using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;
using ar.com.TiempoyGestion.BackEnd.Contratos.Dal;
using ar.com.TiempoyGestion.BackEnd.Contratos.App;

namespace ar.com.TiempoyGestion.FrontEnd.Extranet.Contratos
{
	/// <summary>
	/// Summary description for ListaInformes.
	/// </summary>
	public partial class ListaContratos : Page
	{
		private UsuarioAutenticado Usuario;

		protected void Page_Load(object sender, EventArgs e)
		{
			// Put user code to initialize the page here
			// Usuario Logueado
			Usuario = (UsuarioAutenticado)Session["UsuarioAutenticado"];

			if (!Page.IsPostBack) 
			{

				ContratosApp contratos = new ContratosApp();
				dgridEncabezados.DataSource = contratos.ListaContratos(-1,"", Usuario.IdCliente, "","",true);
				dgridEncabezados.DataBind();
				ContratosDal Tipos = new ContratosDal();
				cmbTipo.Items.Clear();
				DataTable myTable = Tipos.TraerTipoContrato();
				cmbTipo.Items.Add("Todos los Tipos de Contratos");
				ListItem myItem;
				foreach(DataRow myRow in myTable.Rows)
				{
					myItem = new ListItem(myRow[0].ToString(), myRow[1].ToString());
					cmbTipo.Items.Add(myItem);
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
			this.dgridEncabezados.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgridEncabezados_ItemCommand);

		}
		#endregion

		protected void btnInforme_Click(object sender, EventArgs e)
		{
			Response.Redirect("altaContrato.aspx");
		}

		protected void btnBuscar_Click(object sender, EventArgs e)
		{
			Usuario = (UsuarioAutenticado)(Session["UsuarioAutenticado"]);
			//int idCliente = Usuario.IdCliente;
			int idCliente = Usuario.IdCliente;
			int idTipo;
			ContratosApp contratos = new ContratosApp();
			if (cmbTipo.SelectedValue == "Todos los Tipos de Contratos") idTipo = -1;
			else idTipo = int.Parse(cmbTipo.SelectedValue); 

			dgridEncabezados.DataSource = contratos.ListaContratos(idTipo,TxtContengan.Text, idCliente, "","", true);
			dgridEncabezados.DataBind();
		}

		protected void dgridEncabezados_PreRender(object sender, EventArgs e)
		{
			foreach (DataGridItem myItem in dgridEncabezados.Items)
			{
				((ImageButton)myItem.FindControl("Editar")).Visible= true;
				((ImageButton)myItem.FindControl("Cancelar")).Visible= true;
				((ImageButton)myItem.FindControl("Cancelar")).Attributes.Add("onclick",@"javascript: return confirm('¿Está seguro que desea Eliminar el Contrato?');");

				string[] fecha = myItem.Cells[5].Text.Remove(9,myItem.Cells[5].Text.Length -9).Split("/".ToCharArray());
				myItem.Cells[4].Text = fecha[1] + "/" + fecha[0] + "/" + fecha[2];

				fecha = myItem.Cells[7].Text.Remove(9,myItem.Cells[7].Text.Length -9).Split("/".ToCharArray());
				myItem.Cells[6].Text = fecha[1] + "/" + fecha[0] + "/" + fecha[2];

			}
		}

		private void dgridEncabezados_ItemCommand(object source, DataGridCommandEventArgs e)
		{
			if (e.Item.Cells[0].Text != "")
			{
				switch(((ImageButton)e.CommandSource).CommandName)
				{
					case "Cancelar":
						int IdCodigo = int.Parse(e.Item.Cells[0].Text);
						EliminarContrato(IdCodigo);
						Response.Redirect("ListaContratos.aspx");
						break;

					case "Editar":
						Response.Redirect("ListaPersonas.aspx?tipo=1&Id="+ e.Item.Cells[0].Text);
						break;
					case "Ver":
						Response.Redirect("ListaPersonas.aspx?tipo=0&Id="+ e.Item.Cells[0].Text);
						break;
					case "Historico":
						Response.Redirect("Historial.aspx?Id="+ e.Item.Cells[0].Text);
						break;
				}
			}
		}

		private void EliminarContrato(int idContrato)
		{
			ContratoAPP contrato = new ContratoAPP();
			contrato.Eliminar(idContrato);
		}

	}
}
