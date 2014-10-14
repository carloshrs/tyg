using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.App;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.Contactenos
{
	/// <summary>
	/// Summary description for ListaInformes.
	/// </summary>
	public partial class ListaContactos : Page
	{
        private int paginaActual = 1;

		protected void Page_Load(object sender, EventArgs e)
		{
			// Put user code to initialize the page here
            this.GetPostBackEventReference(this);
            paginaActual = int.Parse(hPagina.Value);

            if (!Page.IsPostBack) {
                ListaConsultas();
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
			this.btnBuscar.Click += new EventHandler(this.btnBuscar_Click);
			this.dgridContacto.PreRender += new EventHandler(this.dgridContacto_PreRender);
			this.btnVolver.Click += new EventHandler(this.btnVolver_Click);
			this.Load += new EventHandler(this.Page_Load);

		}

		#endregion

		private void btnBuscar_Click(object sender, EventArgs e)
		{
            ListaConsultasFiltro();
		}

        private void ListaConsultas()
        {
            ContactenosApp Contacto = new ContactenosApp();
            Contacto.RegPorPagina = 10;
            Contacto.Pagina = paginaActual;
            dgridContacto.DataSource = Contacto.TraerDatos("", 0);
            dgridContacto.DataBind();
            litPaginador.Text = Contacto.GetPaginador(10);
        }

        private void ListaConsultasFiltro()
        {
            ContactenosApp Contacto = new ContactenosApp();
            Contacto.RegPorPagina = 10;
            Contacto.Pagina = paginaActual;
            dgridContacto.DataSource = Contacto.TraerDatos(TxtContengan.Text, 0);
            dgridContacto.DataBind();
            litPaginador.Text = Contacto.GetPaginador(10);
        }
        

		private void btnVolver_Click(object sender, EventArgs e)
		{
			Response.Redirect("/Default.aspx");
		}

        protected void dgridContacto_PreRender(object sender, EventArgs e)
		{
            foreach (DataGridItem myItem in dgridContacto.Items)
            {
                ((Label)myItem.FindControl("lblFecha")).Text = DateTime.Parse(myItem.Cells[1].Text).ToShortDateString() + " " + DateTime.Parse(myItem.Cells[1].Text).ToShortTimeString();
                if (myItem.Cells[3].Text == "1")  //origen
                    ((Label)myItem.FindControl("lblOrigen")).Text = "Extranet";
                else
                    ((Label)myItem.FindControl("lblOrigen")).Text = "Website";

                if (myItem.Cells[8].Text == "0")  //no leida
                {
                    myItem.Font.Bold = true;
                    myItem.Font.Name = "blue";
                }
            }

		}

        protected void dgridContacto_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.Item.Cells[0].Text != "")
            {
                switch (((ImageButton)e.CommandSource).CommandName)
                {
                    case "Ver":
                        int IdCodigo = int.Parse(e.Item.Cells[0].Text);
                        {
                            Response.Redirect("verConsulta.aspx?id=" + IdCodigo + "&idTipo=" + e.Item.Cells[3].Text);
                        }
                        break;
                }
            }
        }

        protected void hPagina_ValueChanged(object sender, EventArgs e)
        {
            paginaActual = int.Parse(hPagina.Value);
            ListaConsultasFiltro();
            //ListaConsultas();
        }
    }

}