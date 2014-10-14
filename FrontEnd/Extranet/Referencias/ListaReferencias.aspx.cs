using System;
using System.Web.UI.WebControls;
using System.Configuration;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Extranet.Referencias
{
	/// <summary>
	/// Summary description for ListaInformes.
	/// </summary>
	public partial class ListaReferencias : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here

		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();

			// Usuario Logueado
			UsuarioAutenticado Usuario = (UsuarioAutenticado)Session["UsuarioAutenticado"];

			BandejaEntradaApp bandeja = new BandejaEntradaApp();
			dgridReferencias.DataSource = bandeja.TraerReferencias("", Usuario.IdCliente, -1);
			dgridReferencias.DataBind();
		
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.dgridReferencias.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgridEncabezados_ItemCommand);

		}
		#endregion

		protected void btnInforme_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("altaReferencia.aspx");
		}

		protected void btnBuscar_Click(object sender, System.EventArgs e)
		{
			UsuarioAutenticado Usuario = (UsuarioAutenticado)Session["UsuarioAutenticado"];
			BandejaEntradaApp bandeja = new BandejaEntradaApp();
			dgridReferencias.DataSource = bandeja.TraerReferencias(TxtContengan.Text, Usuario.IdCliente, -1);
			dgridReferencias.DataBind();
		}

		protected void dgridEncabezados_PreRender(object sender, System.EventArgs e)
		{
			foreach (DataGridItem myItem in dgridReferencias.Items)
			{
				myItem.Cells[5].Text= "<IMG SRC='/img/Estado" + myItem.Cells[8].Text + ".gif' widht='14' height='14' border='0'>&nbsp;&nbsp;&nbsp;" + myItem.Cells[4].Text;
				if (int.Parse(myItem.Cells[8].Text) == 1)
				{
					((ImageButton)myItem.FindControl("Editar")).Attributes.Add("src",@"/img/modificar_general.gif");
					((ImageButton)myItem.FindControl("Editar")).ToolTip = "Modificar Referencia";
					((ImageButton)myItem.FindControl("Cancelar")).Attributes.Add("onclick",@"javascript: return confirm('¿Está seguro que desea Cancelar la Referencia?');");
				}
				else
				{
					((ImageButton)myItem.FindControl("Editar")).Attributes.Add("src",@"/img/lupita.gif");
					((ImageButton)myItem.FindControl("Editar")).ToolTip = "Visualizar Referencia";
					((ImageButton)myItem.FindControl("Cancelar")).Attributes.Add("src",@"/img/reloj.jpg");
					((ImageButton)myItem.FindControl("Cancelar")).ToolTip = "Ver Historial";
				}
				if (int.Parse(myItem.Cells[10].Text) == 0)
				{
					((ImageButton)myItem.FindControl("Down")).Visible = false;
				}
				else
				{
					((ImageButton)myItem.FindControl("Down")).Visible = true;
				}

			}
		}

		private void dgridEncabezados_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.Item.Cells[0].Text != "")
			{
				switch(((ImageButton)e.CommandSource).CommandName)
				{
					case "Cancelar":
						int IdReferencia = int.Parse(e.Item.Cells[0].Text);
						if (int.Parse(e.Item.Cells[8].Text) == 1)
						{
							CancelarReferencia(IdReferencia);
							Response.Redirect("ListaReferencias.aspx");
						}
						else
						{
							Response.Redirect("VerHistorial.aspx?id="+ e.Item.Cells[0].Text);
						}
						break;

					case "Editar":
						if (int.Parse(e.Item.Cells[8].Text) == 1)
						{
							Response.Redirect("altaReferencia.aspx?IdReferencia="+ e.Item.Cells[0].Text + "&isFile=" + e.Item.Cells[10].Text);
						}
						else
						{
							Response.Redirect("VerReferencia.aspx?IdReferencia="+ e.Item.Cells[0].Text + "&isFile=" + e.Item.Cells[10].Text);
						}
						break;

					case "Down":
							string strPath = ConfigurationSettings.AppSettings["PATH"];
							Response.Redirect(strPath + e.Item.Cells[11].Text);
						break;
				}
			}
		}


		public void CancelarReferencia(int idReferencia)
		{
			ReferenciasApp Referencia = new ReferenciasApp();
			Referencia.Cargar(idReferencia);

			// Usuario Logueado
			UsuarioAutenticado Usuario = (UsuarioAutenticado)Session["UsuarioAutenticado"];
			Referencia.IdCliente = Usuario.IdCliente;

			Referencia.Cancelar(idReferencia);
		}

	}
	
}	