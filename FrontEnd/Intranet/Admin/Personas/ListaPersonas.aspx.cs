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
	public partial class ListaPersonas : Page
	{
		#region Elementos Web
		
		protected TextBox Provincia;
		private string filtroActual="";
		
		#endregion
					
		#region Page_Load(object sender, EventArgs e)

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack) 
			{		
				// Mantener Pagina Seleccionada
				if (Session["PaginaPersonaActual"]!=null)
				{					
					dgridPersonas.CurrentPageIndex=int.Parse(Session["PaginaPersonaActual"].ToString());
					Session.Remove("PaginaPersonaActual");
				}
			
				// Mantener Filtro Seleccionado
				if (Session["FiltroPersonaActual"]!=null)
				{
					filtroActual=Session["FiltroPersonaActual"].ToString().Trim();					
				}
				
				BuscarPersonas(filtroActual);	
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
			this.FiltroPersonas.FilterChange += new WebCustomControls.Controls.FilterHandler(this.FiltroPersonas_FilterChanged);
			this.dgridPersonas.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgridContratos_ItemCommand);
			this.dgridPersonas.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgridContratos_PageIndexChanged);

		}
		#endregion

		#region Métodos Privados

		#region BuscarPersonas(string filtro)

		private void BuscarPersonas(string filtro)
		{
			PersonasAPP personas = new PersonasAPP();
			dgridPersonas.DataSource=personas.ListaPersonas(filtro);
			dgridPersonas.DataBind();
		}

		#endregion

		#region dgridContratos_ItemCommand(object source, DataGridCommandEventArgs e)
		
		private void dgridContratos_ItemCommand(object source, DataGridCommandEventArgs e)
		{
			if (e.Item.Cells[0].Text != "")
			{
				switch(((ImageButton)e.CommandSource).CommandName)
				{
					case "Eliminar":
					{
						Session.Add("PaginaPersonaActual",dgridPersonas.CurrentPageIndex);
						int IdCodigo = int.Parse(e.Item.Cells[0].Text);
						EliminarPersona(IdCodigo);						
						break;
					}

					case "Editar":
					{
						Session.Add("PaginaPersonaActual",dgridPersonas.CurrentPageIndex);
						Response.Redirect("AbmPersonas.aspx?Id="+ e.Item.Cells[0].Text);
						break;
					}
				}
			}
		}

		#endregion

		#region dgridContratos_PreRender(object sender, EventArgs e)
		
		protected void dgridContratos_PreRender(object sender, EventArgs e)
		{
			foreach (DataGridItem myItem in dgridPersonas.Items)
			{
				((ImageButton)myItem.FindControl("Editar")).Visible= true;
				((ImageButton)myItem.FindControl("Eliminar")).Visible= true;
				((ImageButton)myItem.FindControl("Eliminar")).Attributes.Add("onclick",@"javascript: return confirm('¿Está seguro que desea Eliminar la Persona?');");
			}
		}

		#endregion

		#region EliminarPersona(int idPersona)
		
		private void EliminarPersona(int idPersona)
		{
			PersonasAPP persona = new PersonasAPP();
			bool resultado=persona.Eliminar(idPersona);
			// Si hubo un error...
			if (resultado==false)
			{
				Response.Redirect("/PaginaError.aspx");	
			}
			else
				Response.Redirect("ListaPersonas.aspx");			
		}

		#endregion
		
		#endregion

		#region Eventos

		#region btnBuscar_Click(object sender, System.EventArgs e)

		protected void btnBuscar_Click(object sender, System.EventArgs e)
		{
			filtroActual=TxtFiltro.Text.Trim();
			Session.Add("FiltroPersonaActual",filtroActual);
			dgridPersonas.CurrentPageIndex=0;
			BuscarPersonas(filtroActual);
		}

		#endregion

		#region btnPersonas_Click(object sender, EventArgs e)
		
		protected void btnPersonas_Click(object sender, EventArgs e)
		{
			Session.Add("PaginaPersonaActual",dgridPersonas.CurrentPageIndex);
			Response.Redirect("AltaPersonas.aspx");
		}

		#endregion

		#region dgridContratos_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
		
		private void dgridContratos_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
		{
			
			if (Session["FiltroPersonaActual"]!=null)
			{
				filtroActual=Session["FiltroPersonaActual"].ToString().Trim();				
			}

			dgridPersonas.CurrentPageIndex=e.NewPageIndex;			
			BuscarPersonas(filtroActual);
		}

		#endregion

		#region FiltroPersonas_FilterChanged(object sender, FilterChangedEventArgs e)
		
		void FiltroPersonas_FilterChanged(object sender, FilterChangedEventArgs e)
		{
			filtroActual=e.Filter;
			Session.Add("FiltroPersonaActual",filtroActual);
			dgridPersonas.CurrentPageIndex=0;
			BuscarPersonas(filtroActual);
		}

		#endregion

		#endregion
	}
}
