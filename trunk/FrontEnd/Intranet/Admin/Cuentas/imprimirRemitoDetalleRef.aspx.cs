using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.App;
using ar.com.TiempoyGestion.BackEnd.Clientes.Dal;
using ar.com.TiempoyGestion.BackEnd.Clientes.App;
using System.Data;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.App;
using System.Globalization;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.Admin.Cuentas
{
    public partial class Admin_Cuentas_remitos : System.Web.UI.Page
    {
        int idCliente = 0;
        int nroRemito = 0;
        int idTipoDocumentacion = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                idTipoDocumentacion = int.Parse(Request.QueryString["idTipo"]);
                setTipoCobranza(idTipoDocumentacion);
                pnCliente.Visible = false;
                cargarRemito(idTipoDocumentacion);
                ListarServicios(idTipoDocumentacion);
            }
        }

        private void cargarRemito(int idTipoDocumentacion)
        {
            

            idCliente = int.Parse(Request.QueryString["idCliente"]);
            nroRemito = int.Parse(Request.QueryString["nroRemito"]);

            ClienteDal oCliente = new ClienteDal();
            oCliente.Cargar(idCliente);
            lblCliente.Text = oCliente.NombreFantasia + ((oCliente.Sucursal != "") ? " (" + oCliente.Sucursal + ")" : "");
            lblCliente2.Text = oCliente.NombreFantasia + ((oCliente.Sucursal != "") ? " (" + oCliente.Sucursal + ")" : "");
            string dirCliente = "";
            dirCliente = oCliente.Calle + " " + oCliente.Numero;
            if (oCliente.Piso != "")
                dirCliente = dirCliente + " Piso: " + oCliente.Piso + " " + oCliente.Departamento;
            if (oCliente.CodigoPostal != "")
                dirCliente = dirCliente + " CP: " + oCliente.CodigoPostal;
            lblDireccion.Text = dirCliente;
            lblDireccion2.Text = dirCliente;

            if (oCliente.IdLocalidad != 1)
            {
                lblLocalidad.Text = " - Localidad: " + CargarLocalidades(oCliente.IdProvincia, oCliente.IdLocalidad);
                lblLocalidad2.Text = " - Localidad: " + CargarLocalidades(oCliente.IdProvincia, oCliente.IdLocalidad);
            }

            lblTelefono.Text = oCliente.Telefono;
            lblTelefono2.Text = oCliente.Telefono;

            if (oCliente.Fax != "")
            {
                lblFax.Text = " / Fax: " + oCliente.Fax;
                lblFax2.Text = " / Fax: " + oCliente.Fax;
            }

            lblNroRemito.Text = nroRemito.ToString();
            lblNroRemito2.Text = nroRemito.ToString();

            GestorPreciosApp gp = new GestorPreciosApp();
            DataTable cargar = gp.ListaRemitosPartesEntrega(idTipoDocumentacion, nroRemito);
            DateTime fecha = Convert.ToDateTime(cargar.Rows[0][1].ToString());
            lblFecha.Text = fecha.ToShortDateString();
            lblFecha2.Text = fecha.ToShortDateString();
        }


        private void ListarServicios(int idTipoDocumentacion)
        {
            pnListadoInformes.Visible = true;
            pnCliente.Visible = true;
            bool referencia = true;

            GestorPreciosApp gp = new GestorPreciosApp();
            dgridRemitoServicios.DataSource = gp.ListaDetallesRemitoParteEntrega(idTipoDocumentacion, nroRemito, referencia);
            dgridRemitoServicios.DataBind();


            dgridRemitoServicios2.DataSource = gp.ListaDetallesRemitoParteEntrega(idTipoDocumentacion, nroRemito, referencia);
            dgridRemitoServicios2.DataBind();

            lblTotal.Text = "$ " + System.Math.Round(gp.precioTotalRemitoParteEntrega(idTipoDocumentacion, nroRemito), 2).ToString();
            lblTotal2.Text = "$ " + System.Math.Round(gp.precioTotalRemitoParteEntrega(idTipoDocumentacion, nroRemito), 2).ToString();
        }

        
        protected void dgridRemitoServicios_PreRender(object sender, EventArgs e)
        {
            foreach (DataGridItem myItem in dgridRemitoServicios.Items)
            {
                try
                {
                    ((Label)myItem.FindControl("lblPrecioUnitario")).Text = "$ " + System.Math.Round(decimal.Parse(myItem.Cells[2].Text), 2).ToString();
                    ((Label)myItem.FindControl("lblPrecioTotal")).Text = "$ " + System.Math.Round(decimal.Parse(myItem.Cells[4].Text), 2).ToString();
                }
                catch (Exception exc)
                { }
            }
        }
        

        protected void dgridRemitoServicios2_PreRender(object sender, EventArgs e)
        {
            foreach (DataGridItem myItem in dgridRemitoServicios2.Items)
            {
                try
                {
                    ((Label)myItem.FindControl("lblPrecioUnitario")).Text = "$ " + System.Math.Round(decimal.Parse(myItem.Cells[2].Text), 2).ToString();
                    ((Label)myItem.FindControl("lblPrecioTotal")).Text = "$ " + System.Math.Round(decimal.Parse(myItem.Cells[4].Text), 2).ToString();
                }
                catch (Exception exc)
                { }
            }
        }


        

        protected void InformeDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListViewDataItem di = (ListViewDataItem)e.Item;
                DataRow row = ((DataRowView)di.DataItem).Row;
                int idTipoInfo = int.Parse(row.ItemArray[1].ToString());
                ListView lvInformes = (ListView)e.Item.FindControl("lvInformes");

                GestorPreciosApp gp = new GestorPreciosApp();
                int idTipoDocumento = int.Parse(Request.QueryString["idTipo"]);
                lvInformes.DataSource = gp.listarInformesRemitoParteEntrega(idTipoDocumento, nroRemito, idTipoInfo);
                lvInformes.DataBind();
            }
        }

        private void setTipoCobranza(int idTipoDocumentacion)
        {
            if (idTipoDocumentacion == 1)
            {
                lblDocumento.Text = "REMITO";
                lblDocumento2.Text = "REMITO";
            }
            else
            {
                lblDocumento.Text = "PARTE DE ENTREGA";
                lblDocumento2.Text = "PARTE DE ENTREGA";
            }
        }

        private String CargarLocalidades(int idProvincia, int IdLocalidad)
        {
            UtilesApp Tipos = new UtilesApp();
            DataTable myTb;
            string Localidad = "";
            myTb = Tipos.TraerLocalidades(idProvincia);
            foreach (DataRow myRow in myTb.Rows)
            {
                if (IdLocalidad.ToString() == myRow[0].ToString())
                {
                    Localidad = myRow[1].ToString();
                }
            }
            return Localidad;
        }

    }
}