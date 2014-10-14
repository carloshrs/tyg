using System;
using System.Data;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.Clientes.Dal;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.Admin.Clientes
{
	/// <summary>
	/// Summary description for ListaUsuarios.
	/// </summary>
	public partial class ListaUsuarios : Page
	{
		protected Label lblMessage;

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				bool bolFiltrado = false;
				if (Request.QueryString["IdCliente"] != null && Request.QueryString["IdCliente"] != "")
				{
					dgridUsuarios.Columns[4].Visible = false;
					ddlClientes.Visible = false;
					lblCliente.Visible = true;
					int intIdCliente;
					try
					{
						intIdCliente = Convert.ToInt32(Request.QueryString["IdCliente"]);
					}
					catch
					{
						intIdCliente = 0;
					}
					if (intIdCliente != 0)
					{
						ClienteDal dalCliente = new ClienteDal();
						dalCliente.Cargar(intIdCliente);
						lblCliente.Text = dalCliente.RazonSocial;
					}
					else
						lblCliente.Text = "Intranet";
					ViewState["IdFiltro"] = intIdCliente.ToString();
					bolFiltrado = true;
					BuscarUsuarios(intIdCliente);
				}
				else
				{
					CargarClientes();
					BuscarUsuarios(-1);
				}
				ViewState["Filtrado"] = bolFiltrado.ToString();
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
			this.dgridUsuarios.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgridUsuarios_ItemCommand);

		}

		#endregion

		private void CargarClientes()
		{
			ClienteDal dalCliente = new ClienteDal();
			DataTable dtClientes = dalCliente.Listar("");

			ddlClientes.Items.Add(new ListItem("<Todos>", "-1"));
			ddlClientes.Items.Add(new ListItem("<Intranet>", "0"));

			foreach (DataRow myRow in dtClientes.Rows)
				ddlClientes.Items.Add(new ListItem(Convert.ToString(myRow[1]), Convert.ToString(myRow[0])));

		}

		private void BuscarUsuarios(int lIdFiltro)
		{
			DataTable dtUsuarios;
			Usuario dalUsuario = new Usuario();
			if (lIdFiltro < 0)
				dtUsuarios = dalUsuario.Listar(TxtFiltro.Text, false);
			else if (lIdFiltro == 0)
				dtUsuarios = dalUsuario.Listar(TxtFiltro.Text, true);
			else
				dtUsuarios = dalUsuario.Listar(TxtFiltro.Text, lIdFiltro);
				dgridUsuarios.DataSource = dtUsuarios.DefaultView;
				dgridUsuarios.DataBind();

		}

		protected void btnNewUser_Click(object sender, EventArgs e)
		{
			if (Convert.ToString(ViewState["IdFiltro"]) != "")
				Response.Redirect("/Admin/Clientes/AbmUsuario.aspx?IdCliente=" + Convert.ToString(ViewState["IdFiltro"]));
			else
				Response.Redirect("/Admin/Clientes/AbmUsuario.aspx");
		}

		protected void btnBuscar_Click(object sender, EventArgs e)
		{
			if (Convert.ToBoolean(ViewState["Filtrado"]))
				BuscarUsuarios(Convert.ToInt32(ViewState["IdFiltro"]));
			else
				BuscarUsuarios(Convert.ToInt32(ddlClientes.SelectedValue));

		}

		protected void dgridUsuarios_PreRender(object sender, EventArgs e)
		{
			foreach (DataGridItem myItem in dgridUsuarios.Items)
			{
				((ImageButton) myItem.FindControl("Borrar")).Attributes.Add("onclick", @"javascript: return confirm('Se eliminará toda información del usuario: " + myItem.Cells[2].Text + "\\n¿Está seguro?');");
				if (myItem.Cells[10].Text == "1")
					myItem.ForeColor = Color.Green;
				((Label) myItem.FindControl("lblNomApe")).Text = myItem.Cells[8].Text + " " + myItem.Cells[9].Text;
                if (myItem.Cells[11].Text == "0")
                {
                    myItem.ForeColor = Color.Red;
                    ((Label)myItem.FindControl("lblNomApe")).Text = ((Label)myItem.FindControl("lblNomApe")).Text + " (Inactivo)";
                }

			}
		}

		private void dgridUsuarios_ItemCommand(object source, DataGridCommandEventArgs e)
		{
			if (e.Item.Cells[0].Text != "")
			{
				Usuario dalUsuario;
				switch (((ImageButton) e.CommandSource).CommandName)
				{
					case "Borrar":
						dalUsuario = new Usuario();
						dalUsuario.Eliminar(Convert.ToInt32(e.Item.Cells[0].Text));
						if (Convert.ToBoolean(ViewState["Filtrado"]))
							BuscarUsuarios(Convert.ToInt32(ViewState["IdFiltro"]));
						else
							BuscarUsuarios(Convert.ToInt32(ddlClientes.SelectedValue));
						break;
					case "Editar":
						dalUsuario = new Usuario();
						dalUsuario.Cargar(Convert.ToInt32(e.Item.Cells[0].Text));
						if (Convert.ToString(ViewState["IdFiltro"]) != "")
							Response.Redirect("AbmUsuario.aspx?IdUsuario=" + e.Item.Cells[0].Text + "&IdCliente=" + dalUsuario.IdCliente.ToString());
						else
							Response.Redirect("AbmUsuario.aspx?IdUsuario=" + e.Item.Cells[0].Text);
						break;
					case "Roles":
						if (Convert.ToString(ViewState["IdFiltro"]) != "")
							Response.Redirect("UsuarioAddRol.aspx?IdUsuario=" + e.Item.Cells[0].Text + "&From=list&IdCliente=" + Convert.ToString(ViewState["IdFiltro"]));
						else
							Response.Redirect("UsuarioAddRol.aspx?IdUsuario=" + e.Item.Cells[0].Text + "&From=list");
						break;

				}
			}
		}

	}

}