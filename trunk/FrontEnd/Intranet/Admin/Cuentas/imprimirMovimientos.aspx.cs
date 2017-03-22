using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.App;
using ar.com.TiempoyGestion.BackEnd.Clientes.Dal;
using ar.com.TiempoyGestion.BackEnd.Cobranzas.App;
using System.Data;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.App;
using System.Globalization;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.Admin.Cuentas
{
    public partial class Admin_Cuentas_remitos : System.Web.UI.Page
    {
        int idCliente = 0;
        int nroMovimiento = 0;
        int idTipoDocumentacion = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                idTipoDocumentacion = int.Parse(Request.QueryString["idTipo"]);
                setTipoDocumentacion(idTipoDocumentacion);
                pnCliente.Visible = false;
                cargarRemito(idTipoDocumentacion);
                ListarServicios(idTipoDocumentacion);
            }
        }

        private void cargarRemito(int idTipoDocumentacion)
        {
            idCliente = int.Parse(Request.QueryString["idCliente"]);
            nroMovimiento = int.Parse(Request.QueryString["nroMovimiento"]);

            lblResumenes.Text = listarResumenes(idTipoDocumentacion, nroMovimiento);
            ClienteDal oCliente = new ClienteDal();
            oCliente.Cargar(idCliente);
            lblCliente.Text = oCliente.NombreFantasia + ((oCliente.Sucursal != "") ? " (" + oCliente.Sucursal + ")" : "");
            string dirCliente = "";
            dirCliente = oCliente.Calle + " " + oCliente.Numero;
            if (oCliente.Piso != "")
                dirCliente = dirCliente + " Piso: " + oCliente.Piso + " " + oCliente.Departamento;
            if (oCliente.CodigoPostal != "")
                dirCliente = dirCliente + " CP: " + oCliente.CodigoPostal;
            lblDireccion.Text = dirCliente;
            if (oCliente.IdLocalidad != 1)
                lblLocalidad.Text = " - Localidad: " + CargarLocalidades(oCliente.IdProvincia, oCliente.IdLocalidad); ;

            lblTelefono.Text = oCliente.Telefono;
            if (oCliente.Fax != "")

                lblFax.Text = " / Fax: " + oCliente.Fax;

            lblNroMovimiento.Text = nroMovimiento.ToString();

            GestorPreciosApp gp = new GestorPreciosApp();
            DataTable cargar = gp.ListaMovimientosCliente(idTipoDocumentacion, nroMovimiento);
            DateTime fecha = Convert.ToDateTime(cargar.Rows[0][1].ToString());
            lblFecha.Text = fecha.ToShortDateString();


            string fechasTemp = gp.periodoMovimiento(idTipoDocumentacion, nroMovimiento);
            string[] fechas = fechasTemp.Split(new char[] { ',' });
            
            DateTime fechaIni = Convert.ToDateTime(fechas[0]);
            lblFechaDesde.Text = fechaIni.ToShortDateString();

            DateTime fechaFin = Convert.ToDateTime(fechas[1]);
            lblFechaHasta.Text = fechaFin.ToShortDateString();
        }


        private void ListarServicios(int idTipoDocumentacion)
        {
            pnListadoInformes.Visible = true;
            pnCliente.Visible = true;

            GestorPreciosApp gp = new GestorPreciosApp();
            dgridRemitosMovimiento.DataSource = gp.ListaDetallesRemitosMovimiento(idTipoDocumentacion, nroMovimiento, idCliente);
            dgridRemitosMovimiento.DataBind();


            lblTotal.Text = "$ " + System.Math.Round(gp.precioTotalRemitosMovimiento(idTipoDocumentacion, nroMovimiento, idCliente), 2).ToString();
        }


        protected void dgridRemitosMovimiento_PreRender(object sender, EventArgs e)
        {
            float vTotal = 0;
            
            foreach (DataGridItem myItem in dgridRemitosMovimiento.Items)
            {
                try
                {
                    ((Label)myItem.FindControl("lblPrecioUnitario")).Text = "$ " + System.Math.Round(decimal.Parse(myItem.Cells[2].Text), 2).ToString();
                    ((Label)myItem.FindControl("lblPrecioTotal")).Text = "$ " + System.Math.Round(decimal.Parse(myItem.Cells[4].Text), 2).ToString();
                    vTotal = vTotal + float.Parse(myItem.Cells[4].Text);
                }
                catch (Exception exc)
                { }
            }

            lblTotal.Text = "$ " + vTotal;
        }

        protected string listarResumenes(int idTipoDocumentacion, int nroMovimiento)
        {
            string remitos="";
            GestorPreciosApp gp = new GestorPreciosApp();
            DataTable dt = gp.NroRemitosPorMovimiento(idTipoDocumentacion, nroMovimiento);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (i == dt.Rows.Count-1)
                    remitos = remitos + dt.Rows[i]["nroRemito"].ToString();
                else
                    remitos = remitos + dt.Rows[i]["nroRemito"].ToString() + ", ";
            }
            return remitos;
        }

        private void setTipoDocumentacion(int idTipoDocumentacion)
        {
            if (idTipoDocumentacion == 1)
            {
                lblTipo.Text = "RESUMEN DE REMITOS";
                //btnAceptar.Text = "Finalizar remito";
            }
            else
            {
                lblTipo.Text = "RESUMEN DE PARTES DE ENTREGA";
                //btnAceptar.Text = "Finalizar parte de entrega";
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