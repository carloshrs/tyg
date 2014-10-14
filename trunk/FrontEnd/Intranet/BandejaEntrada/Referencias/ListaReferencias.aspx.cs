using System;
using System.Data;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.BandejaEntrada.Referencias
{
	/// <summary>
	/// Summary description for ListaInformes.
	/// </summary>
	public partial class ListaReferencias : Page
	{
        private int IdTipo;
        private int paginaActual = 1;
        protected bool bsqRapida = false;
        //protected int tipoBusqueda = 0;


		protected void Page_Load(object sender, EventArgs e)
		{
			// Put user code to initialize the page here
            this.GetPostBackEventReference(this);
            paginaActual = int.Parse(hPagina.Value);
            if (!Page.IsPostBack)
            {
                ListadoReferencias();
            }
		}

		#region Web Form Designer generated code

		protected override void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
            if (Request.QueryString["bsqrapida"] != null) bsqRapida = true;

			// Usuario Logueado
			UsuarioAutenticado Usuario = (UsuarioAutenticado) Session["UsuarioAutenticado"];

            //if (Request.QueryString["IdTipo"] != null) IdTipo = int.Parse(Request.QueryString["IdTipo"]);
            //else IdTipo = -1;

            ListaEstados();
			base.OnInit(e);
		}

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnBuscar.Click += new EventHandler(this.btnBuscar_Click);
			this.dgridReferencias.ItemCommand += new DataGridCommandEventHandler(this.dgridEncabezados_ItemCommand);
			this.dgridReferencias.PreRender += new EventHandler(this.dgridEncabezados_PreRender);
			this.btnReferencia.Click += new EventHandler(this.btnInforme_Click);
			this.Load += new EventHandler(this.Page_Load);

		}

		#endregion

        private void ListadoReferencias()
        {
            //hTipoBusqueda.Value = "0";
            //int idUser = -1;
            string pFiltro = TxtContengan.Text;
            //if (chkSoloMias.Checked) idUser = IdUsuario;

            BandejaEntradaApp bandeja = new BandejaEntradaApp();
            bandeja.RegPorPagina = 10;
            bandeja.Pagina = paginaActual;
            if (!bsqRapida)
            {
                dgridReferencias.DataSource = bandeja.TraerReferencias(pFiltro, -1, -1);
                dgridReferencias.DataBind();

                litPaginador.Text = bandeja.GetPaginador(10);
            }
            else
                litPaginador.Text = "<b><i>Ingrese criterio de búsqueda</i></b>";

        }

		private void btnInforme_Click(object sender, EventArgs e)
		{
			Response.Redirect("altaReferencia.aspx");
		}

		private void btnBuscar_Click(object sender, EventArgs e)
		{
			UsuarioAutenticado Usuario = (UsuarioAutenticado) Session["UsuarioAutenticado"];
			BandejaEntradaApp bandeja = new BandejaEntradaApp();
			dgridReferencias.DataSource = bandeja.TraerReferencias(TxtContengan.Text, -1, int.Parse(cmbEstados.SelectedValue));
			dgridReferencias.DataBind();
		}

		private void dgridEncabezados_PreRender(object sender, EventArgs e)
		{
			foreach (DataGridItem myItem in dgridReferencias.Items)
			{
				myItem.Cells[6].Text = "<IMG SRC='/img/Estado" + myItem.Cells[9].Text + ".gif' widht='14' height='14' border='0'>&nbsp;&nbsp;&nbsp;" + myItem.Cells[5].Text;
				if (int.Parse(myItem.Cells[11].Text) == 0)
					((ImageButton) myItem.FindControl("Down")).Visible = false;
				else
					((ImageButton) myItem.FindControl("Down")).Visible = true;

			}
		}

		private void dgridEncabezados_ItemCommand(object source, DataGridCommandEventArgs e)
		{
			if (e.Item.Cells[0].Text != "")
			{
				switch (((ImageButton) e.CommandSource).CommandName)
				{
					case "VerHistorial":
						Response.Redirect("VerHistorial.aspx?id=" + e.Item.Cells[0].Text);
						break;

					case "Editar":
						Response.Redirect("altaReferencia.aspx?IdReferencia=" + e.Item.Cells[0].Text + "&isFile=" + e.Item.Cells[11].Text);
						break;
					case "Down":
						string strPath = ConfigurationSettings.AppSettings["PATH"];
						Response.Redirect(strPath + e.Item.Cells[12].Text);
						break;
				}
			}
		}


		public void EliminarReferencia(int idReferencia)
		{
			ReferenciasApp Referencia = new ReferenciasApp();
			Referencia.Cargar(idReferencia);

			// Usuario Logueado
			UsuarioAutenticado Usuario = (UsuarioAutenticado) Session["UsuarioAutenticado"];
			Referencia.IdUsuario = Usuario.IdUsuario;
			Referencia.Borrar(idReferencia);
		}


        private void ListaEstados()
        {
            EncabezadoApp Estados = new EncabezadoApp();
            cmbEstados.Items.Clear();
            DataTable myTable = Estados.TraerEstados(true);
            ListItem myItemTodos = new ListItem("Todos los Estados", "-1");
            cmbEstados.Items.Add(myItemTodos);
            ListItem myItem;
            foreach (DataRow myRow in myTable.Rows)
            {
                myItem = new ListItem(myRow[1].ToString(), myRow[0].ToString());
                cmbEstados.Items.Add(myItem);
            }
        }

        protected void hPagina_ValueChanged(object sender, EventArgs e)
        {
                paginaActual = int.Parse(hPagina.Value);
            /*
                if (hTipoBusqueda.Value == "1")
                    ListaBandejaFiltro();
                else
             */
                ListadoReferencias();

        }
}

}