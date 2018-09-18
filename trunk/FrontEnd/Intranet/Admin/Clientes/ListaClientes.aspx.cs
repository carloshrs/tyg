using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.Clientes.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.Admin.Clientes
{
	/// <summary>
	/// Summary description for ListaClientes.
	/// </summary>
	public partial class ListaClientes : Page
	{
		#region Elementos Web
		
		protected Label lblMessage;
		private string filtroActual="";

		#endregion

		#region Page_Load(object sender, EventArgs e)

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack) 
			{		
				// Mantener Pagina Seleccionada
				if (Session["PaginaClienteActual"]!=null)
				{					
					dgridClientes.CurrentPageIndex=int.Parse(Session["PaginaClienteActual"].ToString());
					Session.Remove("PaginaClienteActual");
				}
			
				// Mantener Filtro Seleccionado
				if (Session["FiltroClienteActual"]!=null)
				{
					filtroActual=Session["FiltroClienteActual"].ToString().Trim();					
				}
				
				BuscarClientes(filtroActual);
			}
		}

		#endregion

		#region Web Form Designer generated code

		protected override void OnInit(EventArgs e)
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
			this.FiltroClientes.FilterChange += new WebCustomControls.Controls.FilterHandler(this.FiltroClientes_FilterChange);
			this.dgridClientes.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgridClientes_ItemCommand);
			this.dgridClientes.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgridClientes_PageIndexChanged);

		}

		#endregion

		#region Métodos Privados

		#region BuscarClientes(string filtro)

		private void BuscarClientes(string filtro)
		{
			ClienteDal dalCliente = new ClienteDal();
            dgridClientes.DataSource = dalCliente.Listar(filtro.Replace("'", "''"));
			dgridClientes.DataBind();
		}

		#endregion
		
		#region dgridClientes_ItemCommand(object source, DataGridCommandEventArgs e)

		private void dgridClientes_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.Item.Cells[0].Text != "")
			{
				ImageButton aux = new ImageButton();
				if(e.CommandSource.GetType().IsInstanceOfType(aux))
				{
					switch (((ImageButton) e.CommandSource).CommandName)
					{
						case "Eliminar":
						{
							Session.Add("PaginaClienteActual",dgridClientes.CurrentPageIndex);
							int IdCodigo = int.Parse(e.Item.Cells[0].Text);
							EliminarCliente(IdCodigo);	
							break;
						}
						case "Editar":
						{
							Session.Add("PaginaClienteActual",dgridClientes.CurrentPageIndex);
							Response.Redirect("AbmCliente.aspx?IdCliente=" + e.Item.Cells[0].Text);
							break;
						}
						case "VerUsuarios":
						{
							Session.Add("PaginaClienteActual",dgridClientes.CurrentPageIndex);
							Response.Redirect("ListaUsuarios.aspx?IdCliente=" + e.Item.Cells[0].Text);
							break;
						}
                        case "verCCCliente":
                        {
                            Session.Add("PaginaClienteActual", dgridClientes.CurrentPageIndex);
                            Response.Redirect("../Cuentas/ListaCuentaCorrienteCliente.aspx?IdCliente=" + e.Item.Cells[0].Text);
                            break;
                        }
					}
				}
			}	
		}
		
		#endregion

		#region dgridClientes_PreRender(object sender, EventArgs e)

		protected void dgridClientes_PreRender(object sender, EventArgs e)
		{
            foreach (DataGridItem myItem in dgridClientes.Items)
            {
                ((ImageButton)myItem.FindControl("Eliminar")).Attributes.Add("onclick", "javascript: return confirm(\"Se eliminará toda información del cliente: " + myItem.Cells[1].Text + " ¿Está seguro? \");");
                if (myItem.Cells[12].Text != "" && myItem.Cells[12].Text != "&nbsp;")
                    myItem.Cells[1].ToolTip = "En el sistema Fox puede visualizarse como " + myItem.Cells[12].Text;
            }

		}

		#endregion

		#region EliminarCliente(int idCliente)
		
		private void EliminarCliente(int idCliente)
		{
			ClienteDal cliente = new ClienteDal();						
			bool resultado=cliente.Eliminar(idCliente);

			// Si hubo un error...
			if (resultado==false)
			{
				Response.Redirect("/PaginaError.aspx");	
			}
			else
				Response.Redirect("ListaClientes.aspx");			
		}

		#endregion
		
		#endregion
		
		#region Eventos

		#region btnBuscar_Click(object sender, EventArgs e)
		
		protected void btnBuscar_Click(object sender, EventArgs e)
		{
			filtroActual=TxtFiltro.Text.Trim();
			Session.Add("FiltroClienteActual",filtroActual);
			dgridClientes.CurrentPageIndex=0;
			BuscarClientes(filtroActual);			
		}

		#endregion

		#region btnNewCliente_Click(object sender, EventArgs e)
		
		protected void btnNewCliente_Click(object sender, EventArgs e)
		{
			Session.Add("PaginaClienteActual",dgridClientes.CurrentPageIndex);
			Response.Redirect("/Admin/Clientes/AbmCliente.aspx");
		}

		#endregion

		#region dgridClientes_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)

		private void dgridClientes_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{						
			if (Session["FiltroClienteActual"]!=null)
			{
				filtroActual=Session["FiltroClienteActual"].ToString().Trim();				
			}

			dgridClientes.CurrentPageIndex=e.NewPageIndex;			
			BuscarClientes(filtroActual);						
		}

		#endregion

		#region FiltroClientes_FilterChange(object sender, WebCustomControls.EventArguments.FilterChangedEventArgs e)

		private void FiltroClientes_FilterChange(object sender, WebCustomControls.EventArguments.FilterChangedEventArgs e)
		{
			filtroActual=e.Filter;
			Session.Add("FiltroClienteActual",filtroActual);
			dgridClientes.CurrentPageIndex=0;
			BuscarClientes(filtroActual);
		}

		#endregion
		
		#endregion										
	}
}