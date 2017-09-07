using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.App;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.Inc
{
	/// <summary>
	///		Summary description for menu.
	/// </summary>
	public partial class menu : UserControl
	{

		protected void Page_Load(object sender, EventArgs e)
		{
			UsuarioAutenticado Usuario = (UsuarioAutenticado) (Context.User);
			if (Session["UsuarioAutenticado"] == null)
				Session.Add("UsuarioAutenticado", Usuario);
			string Fecha = DateTime.Today.Day + "/" + DateTime.Today.Month + "/" + DateTime.Today.Year;
            string strXmlMenu = "<menu Usuario='" + Usuario.NombreUsuario.Trim().Replace("'", "	&apos;") + "' Fecha='" + Fecha + "'>";
			strXmlMenu = strXmlMenu + "<menuPrincipal text='Clientes' idMenuItem='menu1_item_1' idMenuGroup='menu1_group_2'>";
			strXmlMenu = strXmlMenu + "<itemMenu onClick='/Admin/Clientes/AbmCliente.aspx' imageOut='/img/menu/icon_new.gif' imageOver='/img/menu/icon_new_over.gif' idImagenItem='menu1_icon_1' idMenuItem='menu1_item_8' text='Agregar Cliente' separar='0'/>";
			strXmlMenu = strXmlMenu + "<itemMenu onClick='/Admin/Clientes/ListaClientes.aspx' imageOut='/img/menu/icon_listMembers.gif' imageOver='/img/menu/icon_listMembers_over.gif' idImagenItem='menu1_icon_2' idMenuItem='menu1_item_10' text='Listar Clientes' separar='0'/>";
			strXmlMenu = strXmlMenu + "<itemMenu onClick='/Admin/Clientes/ListaCtaCte.aspx' imageOut='/img/menu/icon_visualizar.gif' imageOver='/img/menu/icon_visualizar_over.gif' idImagenItem='menu1_icon_3' idMenuItem='menu1_item_11' text='Estado de Cuentas' separar='1'/>";
			strXmlMenu = strXmlMenu + "</menuPrincipal>";

			strXmlMenu = strXmlMenu + "<menuPrincipal text='Empresas' idMenuItem='menu2_item_1' idMenuGroup='menu2_group_1'>";
			strXmlMenu = strXmlMenu + "<itemMenu onClick='/Admin/Personas/listaPersonas.aspx' imageOut='/img/menu/icon_acces.gif' imageOver='/img/menu/icon_acces_over.gif' idImagenItem='menu2_icon_1' idMenuItem='menu2_item_2' text='Personas' separar='1'/>";
			strXmlMenu = strXmlMenu + "<itemMenu onClick='/Admin/Empresas/listaEmpresas.aspx' imageOut='/img/menu/icon_acces.gif' imageOver='/img/menu/icon_acces_over.gif' idImagenItem='menu2_icon_1' idMenuItem='menu2_item_15' text='Empresas' separar='1'/>";
			strXmlMenu = strXmlMenu + "</menuPrincipal>";

            strXmlMenu = strXmlMenu + "<menuPrincipal text='Cuentas' idMenuItem='menu3_item_1' idMenuGroup='menu3_group_1'>";
            strXmlMenu = strXmlMenu + "<itemMenu onClick='/Admin/Cuentas/listaAdicionales.aspx' imageOut='/img/menu/ico-adicional.png' imageOver='/img/menu/ico-adicional.png' idImagenItem='menu3_icon_1' idMenuItem='menu3_item_2' text='Servicios adicionales' separar='0'/>";
            strXmlMenu = strXmlMenu + "<itemMenu onClick='/Admin/Cuentas/abmlPreciosAdicionales.aspx' imageOut='/img/menu/ico-adicional-precio.png' imageOver='/img/menu/ico-adicional-precio.png' idImagenItem='menu3_icon_2' idMenuItem='menu3_item_15' text='Precios serv. adicionales' separar='0'/>";
            strXmlMenu = strXmlMenu + "<itemMenu onClick='/Admin/TipoInforme/abmlTipoInforme.aspx' imageOut='/img/menu/Precios.gif' imageOver='/img/menu/Precios.gif' idImagenItem='menu4_icon_4' idMenuItem='menu4_item_18' text='Precios' separar='1'/>";
            strXmlMenu = strXmlMenu + "<itemMenu onClick='/Admin/Cuentas/remitos.aspx' imageOut='/img/menu/ico-parteentrega.png' imageOver='/img/menu/ico-parteentrega.png' idImagenItem='menu3_icon_4' idMenuItem='menu3_item_17' text='Partes de entrega | Remitos' separar='1'/>";
            //strXmlMenu = strXmlMenu + "<itemMenu onClick='/Admin/Cuentas/remitos.aspx?idTipo=1' imageOut='/img/menu/ico-remito.png' imageOver='/img/menu/ico-remito.png' idImagenItem='menu3_icon_3' idMenuItem='menu3_item_16' text='Remitos' separar='0'/>";
            //strXmlMenu = strXmlMenu + "<itemMenu onClick='/Admin/Cuentas/abmClientesCuentaCorriente.aspx' imageOut='/img/menu/ico-remito.png' imageOver='/img/menu/ico-remito.png' idImagenItem='menu3_icon_4' idMenuItem='menu3_item_17' text='CC Clientes' separar='1'/>";
            strXmlMenu = strXmlMenu + "<itemMenu onClick='/Admin/Cuentas/recibosmensuales.aspx' imageOut='/img/menu/ico-resumen.png' imageOver='/img/menu/ico-resumen.png' idImagenItem='menu3_icon_5' idMenuItem='menu3_item_18' text='Resúmenes mensuales' separar='1'/>";

            if (Usuario.IsInRole("Administrador"))
            {
                strXmlMenu = strXmlMenu + "<itemMenu onClick='/Admin/Cuentas/ListaCobranzas.aspx' imageOut='/img/menu/ico-cobranzas.png' imageOver='/img/menu/ico-cobranzas.png' idImagenItem='menu3_icon_6' idMenuItem='menu4_item_19' text='Cobranzas' separar='1'/>";
                strXmlMenu = strXmlMenu + "<itemMenu onClick='/Admin/Cuentas/ListaCaja.aspx' imageOut='/img/menu/ico-caja.png' imageOver='/img/menu/ico-caja.png' idImagenItem='menu3_icon_7' idMenuItem='menu4_item_20' text='Caja' separar='1'/>";
                strXmlMenu = strXmlMenu + "<itemMenu onClick='/Admin/Cuentas/ListaFacturacion.aspx' imageOut='/img/menu/ico-facturacion.png' imageOver='/img/menu/ico-facturacion.png' idImagenItem='menu3_icon_8' idMenuItem='menu4_item_21' text='Facturación' separar='1'/>";
                strXmlMenu = strXmlMenu + "<itemMenu onClick='/Admin/Cuentas/ListaChequesCartera.aspx' imageOut='/img/menu/ico-cheques.png' imageOver='/img/menu/ico-cheques.png' idImagenItem='menu3_icon_9' idMenuItem='menu4_item_22' text='Cheques en cartera' separar='1'/>";
            }
            strXmlMenu = strXmlMenu + "</menuPrincipal>";

			strXmlMenu = strXmlMenu + "<menuPrincipal text='Administración' idMenuItem='menu4_item_2' idMenuGroup='menu4_group_1'>";
			strXmlMenu = strXmlMenu + "<itemMenu onClick='/Admin/Clientes/ListaUsuarios.aspx' imageOut='/img/menu/icon_acces.gif' imageOver='/img/menu/icon_acces_over.gif' idImagenItem='menu4_icon_1' idMenuItem='menu4_item_1' text='Usuarios' separar='0'/>";
			strXmlMenu = strXmlMenu + "<itemMenu onClick='/Admin/Seguridad/ListaRoles.aspx' imageOut='/img/menu/icon_acces.gif' imageOver='/img/menu/icon_acces_over.gif' idImagenItem='menu4_icon_2' idMenuItem='menu4_item_16' text='Roles' separar='1'/>";
			strXmlMenu = strXmlMenu + "<itemMenu onClick='/Admin/Seguridad/ListaFunciones.aspx' imageOut='/img/menu/icon_acces.gif' imageOver='/img/menu/icon_acces_over.gif' idImagenItem='menu4_icon_3' idMenuItem='menu4_item_17' text='Funciones' separar='0'/>";
			strXmlMenu = strXmlMenu + "</menuPrincipal>";

            strXmlMenu = strXmlMenu + "<menuPrincipal text='Reportes' idMenuItem='menu5_item_2' idMenuGroup='menu5_group_1'>";
            strXmlMenu = strXmlMenu + "<itemMenu onClick='/Admin/Reportes/ReporteMovimientosCaja.aspx' imageOut='/img/menu/ico-resumen.png' imageOver='/img/menu/ico-resumen.png' idImagenItem='menu5_icon_1' idMenuItem='menu5_item_1' text='Movimientos caja' separar='0'/>";
            strXmlMenu = strXmlMenu + "<itemMenu onClick='/Admin/Reportes/ReporteCantidadInformes.aspx' imageOut='/img/menu/ico-resumen.png' imageOver='/img/menu/ico-resumen.png' idImagenItem='menu5_icon_2' idMenuItem='menu5_item_16' text='Cantidad de informes' separar='1'/>";
            strXmlMenu = strXmlMenu + "</menuPrincipal>";

			strXmlMenu = strXmlMenu + "</menu>";

			XmlDocument oXmlMenu = new XmlDocument();
			oXmlMenu.LoadXml(strXmlMenu);
			xmlMenu.Document = oXmlMenu;

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
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.Load += new EventHandler(this.Page_Load);

		}

		#endregion
	}
}