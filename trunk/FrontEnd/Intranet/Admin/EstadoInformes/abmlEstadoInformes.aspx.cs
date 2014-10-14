using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.Extranet.EstadoInforme
{
	/// <summary>
	/// Summary description for ListaEstadoInforme.
	/// </summary>
	public partial class ListaEstadoInforme : Page
	{

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.QueryString["id"] != null) cargarEstadoInforme(int.Parse(Request.QueryString["id"]));
				EstadoInformeApp objEstadoInforme = new EstadoInformeApp();
				dgEstadoInforme.DataSource = objEstadoInforme.TraerDatos();
				dgEstadoInforme.DataBind();
			}
		}

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
			this.dgEstadoInforme.ItemCommand += new DataGridCommandEventHandler(this.dgEstadoInforme_ItemCommand);
			this.dgEstadoInforme.PreRender += new EventHandler(this.dgEstadoInforme_PreRender);
			this.btnAceptar.Click += new EventHandler(this.btnAceptar_Click);
			this.btnCancelar.Click += new EventHandler(this.btnCancelar_Click);
			this.Load += new EventHandler(this.Page_Load);

		}

		#endregion

		private void dgEstadoInforme_PreRender(object sender, EventArgs e)
		{
			foreach (DataGridItem myItem in dgEstadoInforme.Items)
			{
				((ImageButton) myItem.FindControl("Editar")).Attributes.Add("src", @"/img/modificar_general.gif");
				((ImageButton) myItem.FindControl("Editar")).ToolTip = "Modificar estado informe";
				((ImageButton) myItem.FindControl("Cancelar")).Attributes.Add("onclick", @"javascript: return confirm('¿Está seguro que desea eliminar el estado informe?');");
			}
		}

		private void dgEstadoInforme_ItemCommand(object source, DataGridCommandEventArgs e)
		{
			if (e.Item.Cells[0].Text != "")
			{
				switch (((ImageButton) e.CommandSource).CommandName)
				{
					case "Cancelar":
						int IdCodigo = int.Parse(e.Item.Cells[0].Text);
						EstadoInformeApp objEstadoInforme = new EstadoInformeApp();
						objEstadoInforme.Eliminar(IdCodigo);
						Response.Redirect("abmlEstadoInformes.aspx");
						break;

					case "Editar":
						Response.Redirect("abmlEstadoInformes.aspx?id=" + e.Item.Cells[0].Text);
						break;
				}
			}
		}

		private void btnAceptar_Click(object sender, EventArgs e)
		{
			if (TxtNombre.Text != "")
			{
				if (hidEstadoInforme.Value != "")
				{
					EstadoInformeApp objEstadoInforme = new EstadoInformeApp();
					objEstadoInforme.Modificar(int.Parse(hidEstadoInforme.Value), TxtNombre.Text, txtDescripcion.Text);
				}
				else
				{
					EstadoInformeApp objEstadoInforme = new EstadoInformeApp();
					objEstadoInforme.Crear(TxtNombre.Text, txtDescripcion.Text);
				}
			}
			Response.Redirect("abmlEstadoInformes.aspx");
		}

		private void cargarEstadoInforme(int id)
		{
			EstadoInformeDal objEstadoInforme = new EstadoInformeDal();
			objEstadoInforme.Cargar(id);
			TxtNombre.Text = objEstadoInforme.Nombre;
			txtDescripcion.Text = objEstadoInforme.Descripcion;
			lblEstado.Text = "Edición de estado informe";
			hidEstadoInforme.Value = objEstadoInforme.Id.ToString();
		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			Response.Redirect("abmlEstadoInformes.aspx");
		}
	}
}