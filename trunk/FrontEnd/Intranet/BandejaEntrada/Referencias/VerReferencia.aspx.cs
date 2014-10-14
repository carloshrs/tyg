using System;
using System.Configuration;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.BandejaEntrada.Referencia
{
	/// <summary>
	/// Summary description for altaInforme.
	/// </summary>
	public partial class VerReferencia : Page
	{
		private int IdReferencia;

		protected void Page_Load(object sender, EventArgs e)
		{
			lblFile.Visible = false;
			if (Request.QueryString["IdReferencia"] != null)
			{
				IdReferencia = int.Parse(Request.QueryString["IdReferencia"]);
				ReferenciasApp Referencia = new ReferenciasApp();
				Referencia.Cargar(IdReferencia);
				lblDescripcion.Text = Referencia.Descripcion;
				lblObservaciones.Text = Referencia.Observaciones;
				if (Request.QueryString["isFile"] == "1")
				{
					lblFile.Visible = true;
					pnlInformes.Visible = false;
					lblFile.Text = "<a class='text' href='" + ConfigurationSettings.AppSettings["PATH"] + Referencia.Path + "' target='_blank'>" + Referencia.Path + "</a>";
				}
				else
				{
					pnlInformes.Visible = true;
					if (!Page.IsPostBack) ListaEncabezados(IdReferencia);
				}
				if (! Page.IsPostBack) ListaEstados(Referencia.Estado);
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
			this.dgridEncabezados.ItemCommand += new DataGridCommandEventHandler(this.dgridEncabezados_ItemCommand);
			this.dgridEncabezados.PreRender += new EventHandler(this.dgridEncabezados_PreRender);
			this.btnCambioEstado.Click += new EventHandler(this.btnCambioEstado_Click);
			this.Load += new EventHandler(this.Page_Load);

		}

		#endregion

		private void ListaEncabezados(int IdRef)
		{
			BandejaEntradaApp bandeja = new BandejaEntradaApp();
			dgridEncabezados.DataSource = bandeja.ListaEncabezados(IdRef);
			dgridEncabezados.DataBind();
		}

		private void dgridEncabezados_PreRender(object sender, EventArgs e)
		{
			foreach (DataGridItem myItem in dgridEncabezados.Items)
				myItem.Cells[6].Text = "<IMG SRC='/img/Estado" + myItem.Cells[9].Text + ".gif' widht='14' height='14' border='0'>&nbsp;&nbsp;&nbsp;" + myItem.Cells[5].Text;
		}

		private void dgridEncabezados_ItemCommand(object source, DataGridCommandEventArgs e)
		{
			if (e.Item.Cells[0].Text != "")
			{
				switch (((ImageButton) e.CommandSource).CommandName)
				{
					case "VerInforme":
						Response.Redirect("/BandejaEntrada/VerInforme.aspx?id=" + e.Item.Cells[0].Text + "&Ref=" + IdReferencia.ToString() + "&IdTipo=" + e.Item.Cells[11].Text);
						break;

					case "VerHistorial":
						Response.Redirect("/BandejaEntrada/VerHistorial.aspx?id=" + e.Item.Cells[0].Text + "&Ref=" + IdReferencia.ToString() + "&IdTipo=" + e.Item.Cells[11].Text);
						break;
				}
			}
		}

		private void btnCambioEstado_Click(object sender, EventArgs e)
		{
			ReferenciasApp Referencia = new ReferenciasApp();
			Referencia.Cargar(IdReferencia);

			// Usuario Logueado
			UsuarioAutenticado Usuario = (UsuarioAutenticado) Session["UsuarioAutenticado"];
			Referencia.IdUsuario = Usuario.IdUsuario;

			Referencia.Estado = int.Parse(cmbEstados.SelectedValue);
			Referencia.Comentarios = txtObservaciones.Text;
			Referencia.CambiarEstado(IdReferencia);
		}

		private void ListaEstados(int Estado)
		{
			EncabezadoApp Estados = new EncabezadoApp();
			cmbEstados.Items.Clear();
			DataTable myTable = Estados.TraerEstados(true);
			cmbEstados.Items.Add("Todos los Estados");
			ListItem myItem;
			foreach (DataRow myRow in myTable.Rows)
			{
				myItem = new ListItem(myRow[1].ToString(), myRow[0].ToString());
				if (Estado.ToString() == myRow[0].ToString())
				{
					cmbEstados.SelectedIndex = -1;
					myItem.Selected = true;
				}
				cmbEstados.Items.Add(myItem);
			}

		}

	}
}