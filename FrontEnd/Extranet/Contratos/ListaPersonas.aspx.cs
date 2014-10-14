using System;
using System.Data;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;
using ar.com.TiempoyGestion.BackEnd.Contratos.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.Contratos
{
	/// <summary>
	/// Summary description for altaInforme.
	/// </summary>
	public partial class ListaPersonas : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox Provincia;
		private int idContrato;
		private int tipo = 0;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(Request.QueryString["Id"] != null)
			{	
				idContrato = int.Parse(Request.QueryString["Id"]);
				if(Request.QueryString["tipo"] != null)
				{	
					tipo = int.Parse(Request.QueryString["tipo"]);
					if (tipo == 0) 
					{
						btnPersonas.Visible= false;
						Aceptar.Text= "Cerrar";
					} 
					else {
						btnPersonas.Visible= true;
						Aceptar.Text= "Finalizar";
					}
				}

			}
			if (!Page.IsPostBack) 
			{
				ContratosDal contratos = new ContratosDal();
				CargarContrato(idContrato);
				dgridContratos.DataSource = contratos.CargarPersonasContratos(idContrato);
				dgridContratos.DataBind();
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
			this.dgridContratos.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgridContratos_ItemCommand);

		}
		#endregion


		protected void Aceptar_Click(object sender, System.EventArgs e)
		{
			//ContratoAPP contrato = new ContratoAPP();
			// Usuario Logueado
			//UsuarioAutenticado Usuario = (UsuarioAutenticado)Session["UsuarioAutenticado"];
			
			//contrato.Crear();
			Response.Redirect("ListaContratos.aspx");
		}

		private void Cancelar_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("ListaContratos.aspx");
		}

		private void CargarContrato(int idContrato)
		{
			ContratoAPP contrato = new ContratoAPP();
			if (contrato.Cargar(idContrato)) 
			{
				txtNumero.Text = contrato.Numero;
				txtFechaInicio.Text = contrato.FechaInicio;
				txtFechaFin.Text = contrato.FechaFin;
				txtDescripcion.Text = contrato.Descripcion;
				txtTipoContrato.Text = contrato.TipoContrato;
			
			} 
			else {
				Response.Redirect("ListaContratos.aspx");
			}
		}

		protected void btnPersonas_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("AltaPersonas.aspx?tipo=1&Id=" + idContrato.ToString());
		}

		private void dgridContratos_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.Item.Cells[0].Text != "")
			{
				switch(((ImageButton)e.CommandSource).CommandName)
				{
					case "Cancelar":
						int IdCodigo = int.Parse(e.Item.Cells[0].Text);
						EliminarPersona(IdCodigo);
						Response.Redirect("ListaPersonas.aspx?tipo=1&Id=" + idContrato.ToString());
						break;

					case "Editar":
						Response.Redirect("AbmPersonas.aspx?tipo=1&Id=" + idContrato.ToString() + "&idPersona="+ e.Item.Cells[0].Text);
						break;
					case "Ver":
						Response.Redirect("AbmPersonas.aspx?tipo=0&Id=" + idContrato.ToString() + "&idPersona="+ e.Item.Cells[0].Text);
						break;
				}
			}
		}

		protected void dgridContratos_PreRender(object sender, System.EventArgs e)
		{
			foreach (DataGridItem myItem in dgridContratos.Items)
			{
				if (tipo != 0) 
				{
					((ImageButton)myItem.FindControl("Editar")).Visible= true;
					((ImageButton)myItem.FindControl("Cancelar")).Visible= true;
					((ImageButton)myItem.FindControl("Cancelar")).Attributes.Add("onclick",@"javascript: return confirm('¿Está seguro que desea Eliminar la Persona?');");
				} 
				else 
				{
					((ImageButton)myItem.FindControl("Editar")).Visible= false;
					((ImageButton)myItem.FindControl("Cancelar")).Visible= false;
				}
				if (myItem.Cells[10].Text == "1")  // Persona Física
				{
					myItem.Cells[2].Text = "<B>Apellido y Nombre: </B>" + myItem.Cells[4].Text + ", " + myItem.Cells[3].Text;
				} 
				else { // Persona jurídica
					myItem.Cells[2].Text = "<B>Razón Social: </B>" + myItem.Cells[6].Text + " - <B>Cuit: </B> " + myItem.Cells[5].Text;
				}
				 
			}
		}

		private void EliminarPersona(int Persona)
		{
			PersonaContratoAPP persona = new PersonaContratoAPP();
			persona.Eliminar(Persona);
		}

	}
}
