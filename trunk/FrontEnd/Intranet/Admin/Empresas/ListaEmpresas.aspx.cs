using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;
using WebCustomControls.Controls;
using WebCustomControls.EventArguments;

namespace ar.com.TiempoyGestion.FrontEnd.Extranet.Contratos
{
	/// <summary>
	/// Summary description for altaInforme.
	/// </summary>
	public partial class ListaEmpresas : Page
	{
		#region Elementos Web

		protected TextBox Provincia;
		private string filtroActual="";
        private int tipofiltro = 1;

		#endregion
	
		#region Page_Load(object sender, System.EventArgs e)

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack) 
			{
			
				// Mantener Pagina Seleccionada
				if (Session["PaginaEmpresaActual"]!=null)
				{					
					dgridEmpresas.CurrentPageIndex=int.Parse(Session["PaginaEmpresaActual"].ToString());
					Session.Remove("PaginaEmpresaActual");
				}
				
				// Mantener Filtro Seleccionado
				if (Session["FiltroEmpresaActual"]!=null)
				{
					filtroActual=Session["FiltroEmpresaActual"].ToString().Trim();
                    tipofiltro = int.Parse(Session["TipoFiltroActual"].ToString());
				}
					
				BuscarEmpresas(tipofiltro, filtroActual);	
			}
		}

		#endregion

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
			this.FiltroEmpresas.FilterChange += new FilterHandler(this.FiltroEmpresas_FilterChange);
			this.btnBuscar.Click += new EventHandler(this.btnBuscar_Click);
			this.dgridEmpresas.ItemCommand += new DataGridCommandEventHandler(this.dgridEmpresas_ItemCommand);
			this.dgridEmpresas.PageIndexChanged += new DataGridPageChangedEventHandler(this.dgridEmpresas_PageIndexChanged);
			this.dgridEmpresas.PreRender += new EventHandler(this.dgridEmpresas_PreRender);
			this.btnEmpresas.Click += new EventHandler(this.btnEmpresas_Click);
			this.Load += new EventHandler(this.Page_Load);
		}
		#endregion

		#region Métodos Privados

		#region BuscarEmpresas(string filtro)

		private void BuscarEmpresas(int tipofiltro, string filtro)
		{
			EmpresasAPP empresa = new EmpresasAPP();
			dgridEmpresas.DataSource=empresa.ListaEmpresas(tipofiltro, filtro);
			dgridEmpresas.DataBind();
		}

		#endregion
		
		#region dgridEmpresas_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		
		private void dgridEmpresas_ItemCommand(object source, DataGridCommandEventArgs e)
		{
			if (e.Item.Cells[0].Text != "")
			{
				switch(((ImageButton)e.CommandSource).CommandName)
				{
					case "Eliminar":
					{
						Session.Add("PaginaEmpresaActual",dgridEmpresas.CurrentPageIndex);
						int IdCodigo = int.Parse(e.Item.Cells[0].Text);
						EliminarEmpresa(IdCodigo);						
						break;
					}

					case "Editar":
					{
						Session.Add("PaginaEmpresaActual",dgridEmpresas.CurrentPageIndex);
						Response.Redirect("AbmEmpresa.aspx?Id="+ e.Item.Cells[0].Text);
						break;
					}
				}
			}
		}

		#endregion

		#region dgridEmpresas_PreRender(object sender, System.EventArgs e)

		private void dgridEmpresas_PreRender(object sender, EventArgs e)
		{
			foreach (DataGridItem myItem in dgridEmpresas.Items)
			{
				((ImageButton)myItem.FindControl("Editar")).Visible= true;
				((ImageButton)myItem.FindControl("Eliminar")).Visible= true;
				((ImageButton)myItem.FindControl("Eliminar")).Attributes.Add("onclick",@"javascript: return confirm('¿Está seguro que desea Eliminar la Empresa?');");
			}
		}

		#endregion

		#region EliminarEmpresa(int idEmpresa)

		private void EliminarEmpresa(int idEmpresa)
		{
			EmpresasAPP empresa = new EmpresasAPP();
			bool resultado=empresa.Eliminar(idEmpresa);
			// Si hubo un error...
			if (resultado==false)
			{
				Response.Redirect("/PaginaError.aspx");	
			}
			else
				Response.Redirect("ListaEmpresas.aspx");
		}

		#endregion

		#endregion

		#region Eventos

		#region btnBuscar_Click(object sender, System.EventArgs e)

		private void btnBuscar_Click(object sender, EventArgs e)
		{
            if (raTipoFiltro1.Checked)
                tipofiltro = 1;
            else
                tipofiltro = 2;
            filtroActual=TxtFiltro.Text.Trim();
			Session.Add("FiltroEmpresaActual",filtroActual);
            Session.Add("TipoFiltroActual", tipofiltro);
			dgridEmpresas.CurrentPageIndex=0;
			BuscarEmpresas(tipofiltro, filtroActual);
		}

		#endregion

		#region btnEmpresas_Click(object sender, System.EventArgs e)
		
		private void btnEmpresas_Click(object sender, EventArgs e)
		{
			Session.Add("PaginaEmpresaActual",dgridEmpresas.CurrentPageIndex);
			Response.Redirect("AltaEmpresa.aspx");
		}

		#endregion

		#region dgridEmpresas_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)

		private void dgridEmpresas_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
		{
			if (Session["FiltroEmpresaActual"]!=null)
			{
				filtroActual=Session["FiltroEmpresaActual"].ToString().Trim();
                tipofiltro = int.Parse(Session["TipoFiltroActual"].ToString());				
			}

			dgridEmpresas.CurrentPageIndex=e.NewPageIndex;			
			BuscarEmpresas(tipofiltro, filtroActual);
		}

		#endregion
						
		#region FiltroEmpresas_FilterChange(object sender, WebCustomControls.EventArguments.FilterChangedEventArgs e)

		private void FiltroEmpresas_FilterChange(object sender, FilterChangedEventArgs e)
		{
			filtroActual=e.Filter;
			Session.Add("FiltroEmpresaActual",filtroActual);
            Session.Add("TipoFiltroActual", 1);
			dgridEmpresas.CurrentPageIndex=0;
			BuscarEmpresas(1, filtroActual);
		}

		#endregion

		#endregion
	}
}
