using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.Dal;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.App;
using System.Text;
using ar.com.TiempoyGestion.BackEnd.BackServices.Services;

namespace ar.com.TiempoyGestion.FrontEnd.Extranet.Admin.Clientes
{
	/// <summary>
	/// Summary description for AbmUsuario.
	/// </summary>
	public partial class AbmUsuario : Page
	{

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
                if (((UsuarioAutenticado)Context.User).IdCliente != null)
				{
					int intIdUsuario;
					try
					{
                        DateTime fechaUltimoIngreso = new DateTime();
                        //UsuarioAutenticado Usuario = (UsuarioAutenticado) Context.User;
                        if (((UsuarioAutenticado)Context.User).UltimoIngreso != null)
                            fechaUltimoIngreso = ((UsuarioAutenticado)Context.User).UltimoIngreso;

                            if (fechaUltimoIngreso.ToShortDateString() == ("01/01/1900").ToString()) //Al ser la primera vez que ingresa al sistema, se activa el saludo de bienvenida y carga de datos de usuario/empresa
                            Page.RegisterClientScriptBlock("Bienvenida", "<script>setTimeout('Bienvenida()', 1000);</script>");

                            intIdUsuario = ((UsuarioAutenticado)Context.User).IdUsuario;
						CargarUsuario(intIdUsuario);
					}
					catch
					{
					}
				}
				
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

		}

		#endregion

		private void CargarUsuario(int lIdUsuario)
		{
			Usuario dalUsuario = new Usuario();
			dalUsuario.Cargar(lIdUsuario);

			txtLoginName.Text = dalUsuario.LogginName;
			txtNombre.Text = dalUsuario.Nombre;
			txtApellido.Text = dalUsuario.Apellido;
			txtEmail.Text = dalUsuario.Email;
			txtTelefono.Text = dalUsuario.Telefono;
			txtCelular.Text = dalUsuario.Celular;
            /*
			txtCalle.Text = dalUsuario.Calle;
			txtNro.Text = dalUsuario.Numero;
			txtPiso.Text = dalUsuario.Piso;
			txtDpto.Text = dalUsuario.Departamento;
			txtBarrio.Text = dalUsuario.Barrio;
			txtCodPos.Text = dalUsuario.CodigoPostal;
			CargarComboProvincias(ddlProvincia, dalUsuario.IdProvincia);
			CargarComboLocalidades(ddlProvincia, ddlLocalidad, dalUsuario.IdLocalidad.ToString());
             */

			lblPassword.Visible = false;
			txtPassword.Visible = false;
			lblRePassword.Visible = false;
			txtRePassword.Visible = false;
			reqPassword.Visible = false;
			reqPassword.Enabled = false;
			reqRePassword.Visible = false;
			reqRePassword.Enabled = false;
			compPassword.Visible = false;
			compPassword.Enabled = false;
			panPassword.Visible = false;

			Session["UsuarioUpdate"] = dalUsuario;

		}

		protected void btnCancelar_Click(object sender, EventArgs e)
		{
			Salir();

		}

		private void Salir()
		{
			Session.Remove("UsuarioUpdate");
			Response.Redirect("/Admin/Clientes/AbmCliente.aspx");
		}

		protected void btnAceptar_Click(object sender, EventArgs e)
		{
			Usuario dalUsuario;
			dalUsuario = (Usuario) Session["UsuarioUpdate"];
			dalUsuario.Nombre = txtNombre.Text;
			dalUsuario.Apellido = txtApellido.Text;
			dalUsuario.Telefono = txtTelefono.Text;
			dalUsuario.Celular = txtCelular.Text;
			dalUsuario.Email = txtEmail.Text;
            /*
			dalUsuario.Calle = txtCalle.Text;
			dalUsuario.Numero = txtNro.Text;
			dalUsuario.Piso = txtPiso.Text;
			dalUsuario.Departamento = txtDpto.Text;
			dalUsuario.Barrio = txtBarrio.Text;
			dalUsuario.CodigoPostal = txtCodPos.Text;
			dalUsuario.IdLocalidad = Convert.ToInt32(ddlLocalidad.SelectedValue);
			dalUsuario.IdProvincia = Convert.ToInt32(ddlProvincia.SelectedValue);
             */
			dalUsuario.Modificar();
            dalUsuario.RegistrarIngreso();
            if (pwdAnterior.Text != "" && pwdNuevo.Text == pwdNuevo2.Text && Usuario.AutenticarUsuario(txtLoginName.Text, pwdAnterior.Text) )
            {
                StringBuilder strSqlUpdate = new StringBuilder(128);
                strSqlUpdate.Append("Update Usuarios ");
                strSqlUpdate.Append(" Set Password = " + StaticDal.Traduce(Encriptador.HashPassword(pwdNuevo.Text)));
                strSqlUpdate.Append(" Where LoginName = " + StaticDal.Traduce(txtLoginName.Text));
                try
                {
                    StaticDal.EjecutarComando(strSqlUpdate.ToString());
                }
                catch
                { }
            }
			Salir();
		}

		private void CargarComboProvincias(DropDownList comboProvincia, int IdProvincia)
		{
			UtilesApp Tipos = new UtilesApp();
			comboProvincia.Items.Clear();
			DataTable myTb;
			myTb = Tipos.TraerProvincias();
			ListItem myItem;
			foreach (DataRow myRow in myTb.Rows)
			{
				myItem = new ListItem(myRow[1].ToString(), myRow[0].ToString());
				if (IdProvincia == int.Parse(myRow[0].ToString()))
				{
					comboProvincia.SelectedIndex = -1;
					myItem.Selected = true;
				}
				comboProvincia.Items.Add(myItem);
			}
		}

		private void CargarComboLocalidades(DropDownList comboProvincias, DropDownList comboLocalidades, string IdLocalidad)
		{
			UtilesApp Tipos = new UtilesApp();
			comboLocalidades.Items.Clear();
			DataTable myTb;
			myTb = Tipos.TraerLocalidades(int.Parse(comboProvincias.SelectedItem.Value));
			ListItem myItem;
			foreach (DataRow myRow in myTb.Rows)
			{
				myItem = new ListItem(myRow[1].ToString(), myRow[0].ToString());
				if (IdLocalidad == myRow[0].ToString())
				{
					comboLocalidades.SelectedIndex = -1;
					myItem.Selected = true;
				}
				comboLocalidades.Items.Add(myItem);
			}
		}
        /*
		protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
		{
			CargarComboLocalidades(ddlProvincia, ddlLocalidad, "");
		}
         */

	}
}