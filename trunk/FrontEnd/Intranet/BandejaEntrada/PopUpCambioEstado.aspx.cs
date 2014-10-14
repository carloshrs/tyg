using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.BandejaEntrada
{
	/// <summary>
	/// Summary description for PopUpCambioEstado.
	/// </summary>
	public partial class PopUpCambioEstado : Page
	{
		private int intIdInforme;
        private int intTipoGravamen = 0;
	
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.QueryString["Finalizar"] != null && Request.QueryString["Finalizar"] == "1")
				{
					ListaEstados(3);
					cmbEstados.Enabled = false;
				}
                else if (Request.QueryString["Rechazar"] != null && Request.QueryString["Rechazar"] == "1")
                {
                    ListaEstados(8);
                    cmbEstados.Enabled = false;
                }
                else if (Request.QueryString["Problema"] != null && Request.QueryString["Problema"] == "1")
                {
                    ListaEstados(9);
                    cmbEstados.Enabled = false;
                }
                else if (Request.QueryString["Condicional"] != null && Request.QueryString["Condicional"] == "1")
                {
                    ListaEstados(11);
                    cmbEstados.Enabled = false;
                }
                else
					ListaEstados(-1);
				try
				{
					intIdInforme = int.Parse(Request.QueryString["IdInforme"]);
					ViewState["IdInforme"] = intIdInforme.ToString();
				}
				catch
				{
					intIdInforme = -1;
					CerrarForm();
				}
			}
			else
			{
				intIdInforme = int.Parse(ViewState["IdInforme"].ToString());
			}
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
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
			this.btnCambioEstado.Click += new EventHandler(this.btnCambioEstado_Click);
			this.Cerrar.Click += new EventHandler(this.Cerrar_Click);
			this.Load += new EventHandler(this.Page_Load);

		}
		#endregion

		private void ListaEstados(int Estado)
		{
			EncabezadoApp Estados = new EncabezadoApp();
			cmbEstados.Items.Clear();
			DataTable myTable = Estados.TraerEstados(true);
			cmbEstados.Items.Add("Seleccione Estado");
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

		private void btnCambioEstado_Click(object sender, EventArgs e)
		{
			EncabezadoApp Encabezado = new EncabezadoApp();
			Encabezado.cargarEncabezado(intIdInforme);

			// Usuario Logueado
			UsuarioAutenticado Usuario = (UsuarioAutenticado) Session["UsuarioAutenticado"];
			Encabezado.IdUsuario = Usuario.IdUsuario;

            intTipoGravamen = Encabezado.idTipoGravamen;
			Encabezado.Estado = int.Parse(cmbEstados.SelectedValue);
            Encabezado.Leido = 1;
			Encabezado.Observaciones = txtObservaciones.Text;
			Encabezado.CambiarEstado(intIdInforme);

            if (Request.QueryString["Condicional"] != null && Request.QueryString["Condicional"] == "1")
            {
                Encabezado.AsignarFechaCondicional(intIdInforme);
                Encabezado.CambiarEstadoCondicional(intIdInforme, "1");
            }

            ReferenciasApp oReferer = new ReferenciasApp();
            bool existe = oReferer.VerificarInformesReferencia(intIdInforme);

            if (!existe)
            {
                oReferer.Estado = 3;
                oReferer.CambiarEstado(Encabezado.idReferencia);
            }

            string path = "InformePropiedad";
            string strScript;
            string idTipo = Request.QueryString["idTipo"];

            //idTipo=5 verifDomParticular
            switch (idTipo)
            {
                case "1": 
                    path = "InformePropiedad";
                    break;
                case "2": 
                    path = "Automotores";
                    break;
                case "3":
                    switch (intTipoGravamen)
                    {
                    
                        case 1:
                            path = "Hipoteca";
                            break;
                        case 2:
                            path = "Usufructo";
                            break;
                        case 4:
                            path = "Embargo";
                            break;
                        case 5:
                            path = "BienFamilia";
                            break;
                        case 6: //
                            path = "Servidumbre";
                            break;
                        case 7: //Providencia cautelar
                            path = "Gravamenes/ProvidenciaCautelar";
                            break;
                    }
                    break;
                case "4": 
                    path = "socioAmbiental";
                    break;
                case "5": 
                    path = "verifDomParticular";
                    break;
                case "6": 
                    path = "verifDomLaboral";
                    break;
                case "7": 
                    path = "verifDomComercial";
                    break;
                case "10": 
                    path = "BusquedaAutomotor";
                    break;
                case "11":
                    path = "InformePropiedadProvincias";
                    break;
                case "12":
                    path = "Catastral";
                    break;
                case "13": 
                    path = "BusquedaPropiedad";
                    break;
                case "14": 
                    path = "verifContrato";
                    break;
                case "15":
                    path = "ambientalBancor";
                    break;
                case "16":
                    path = "Inhibicion";
                    break;

            }

            if (idTipo != "9" && idTipo != "17")
            {
                if (Request.QueryString["Problema"] != "1" && Request.QueryString["Condicional"] != "1") //Request.QueryString["Problema"] != null && 
                {
                    strScript = "<script languaje=\"Javascript\">";
                    strScript += "window.open('/" + path + "/VerInforme.aspx?id=" + intIdInforme + "&IdTipo=" + idTipo + "','','tools=no,width=720,menus=no,scrollbars=yes');";
                    //strScript += "return false;";
                    strScript += "</script>";
                    Page.RegisterStartupScript("Imprimir", strScript);
                }
            }

            //EnviarMail(intIdInforme, cmbEstados.SelectedItem.ToString());
			CerrarForm();
		}

		private void CerrarForm()
		{
			string strScript;
			strScript = "<script languaje=\"Javascript\">";
			strScript += "window.close();";
			strScript += "</script>";

			Page.RegisterStartupScript("Return", strScript);
		}

		private void Cerrar_Click(object sender, EventArgs e)
		{
			CerrarForm();
		}


        private void EnviarMail(int intInforme, string strEstado)
        {
            EncabezadoApp Encabezado = new EncabezadoApp();
            Encabezado.cargarEncabezado(intIdInforme);

            System.Net.Mail.MailMessage correo = new System.Net.Mail.MailMessage();
            correo.From = new System.Net.Mail.MailAddress("informes@tiempoygestion.com.ar");
            correo.To.Add("carloshrs@gmail.com");
            correo.Subject = "Tiempo & Gestión: Informe Nº " + Encabezado.IdEncabezado + " - " + strEstado;
            //texto = "\n\nFecha: " + DateTime.Now.ToUniversalTime().ToString("dd/MM/yyyy HH:mm:ss");

            string texto = "El informe solicitado el dia " + Encabezado.FechaFin + " se encuentra <b>" + strEstado + "</b>.";
            if (Encabezado.Estado == 8)
                texto = texto + "<br><br><b>Comuníquese con Tiempo & Gestión a la brevedad</b> al los teléfonos: 0351-4229475 / 8466 / 8578.<br><br>Muchas Gracias.<br>Alejandro Sariago ";
            correo.Body = texto;
            correo.IsBodyHtml = true;
            correo.Priority = System.Net.Mail.MailPriority.Normal;
            //
            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
            //
            //---------------------------------------------
            // Estos datos debes rellanarlos correctamente
            //---------------------------------------------
            smtp.Host = "smtp.tiempoygestion.com.ar";
            smtp.Credentials = new System.Net.NetworkCredential("informes@tiempoygestion.com.ar", "12345678");
            //smtp.EnableSsl = false;

            try
            {
                smtp.Send(correo);
                //LabelError.Text = "Mensaje enviado satisfactoriamente";
            }
            catch (Exception ex)
            {
                //LabelError.Text = "ERROR: " + ex.Message;
            }
        }
	}
}
