using System;
using System.Data;
using System.Text;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;
using System.Data.Odbc;
using System.Globalization;
using System.Data.SqlClient;

namespace ar.com.TiempoyGestion.BackEnd.Clientes.Dal
{
	/// <summary>
	/// Summary description for GestorPrecios.
	/// </summary>
	public class GestorPrecios : GenericDal
	{
        private int intNroRemito;
        private int intTipoPeriodo;

		public GestorPrecios() {}

        #region Propiedades

        public int NroRemito
        {
            get
            {
                return intNroRemito;
            }
            set
            {
                intNroRemito = value;
            }
        }

        public int TipoPeriodo
        {
            get
            {
                return intTipoPeriodo;
            }
            set
            {
                intTipoPeriodo = value;
            }
        }

        #endregion

		public static DataTable TraerPrecios(int lIdTipoInforme)
		{
			StringBuilder strQuery = new StringBuilder(512);
			DataTable dtSalida = null;
			strQuery.Append("Select FecDesde, TipoPrecio, Precio, Actual ");
			strQuery.Append(" From Precios ");
			strQuery.Append(" Where IdTipoInforme = " + lIdTipoInforme.ToString());
			strQuery.Append(" Order by FecDesde Desc");
			
			try
			{

				dtSalida = StaticDal.EjecutarDataSet(strQuery.ToString(),"Precios").Tables[0];
			}
			catch
			{
				throw;
			}

			return dtSalida;
		}

        public static DataTable TraerPreciosPropiedad(int lIdTipoPropiedad)
        {
            StringBuilder strQuery = new StringBuilder(512);
            DataTable dtSalida = null;
            strQuery.Append("Select FecDesde, TipoPrecio, Precio, Actual ");
            strQuery.Append(" From preciosPropiedad ");
            strQuery.Append(" Where IdTipoPropiedad = " + lIdTipoPropiedad.ToString());
            strQuery.Append(" Order by FecDesde Desc");

            try
            {

                dtSalida = StaticDal.EjecutarDataSet(strQuery.ToString(), "PreciosPropiedad").Tables[0];
            }
            catch
            {
                throw;
            }

            return dtSalida;
        }


        public static DataTable TraerPreciosAdicionales()
        {
            StringBuilder strQuery = new StringBuilder(512);
            DataTable dtSalida = null;
            strQuery.Append("Select pa.IdServicioAdicional, pa.FecDesde, sa.id as idServicio, sa.descripcion as servicio, pa.Precio, pa.Actual ");
            strQuery.Append(" From PreciosAdicionales pa INNER JOIN serviciosAdicionales sa ON pa.idServicioAdicional = sa.id ");
            strQuery.Append(" Order by pa.FecDesde Desc");

            try
            {

                dtSalida = StaticDal.EjecutarDataSet(strQuery.ToString(), "PreciosAdicionales").Tables[0];
            }
            catch
            {
                throw;
            }

            return dtSalida;
        }

		public static float TraerPrecioActual(int lIdTipoInforme, byte lTipoPrecio)
		{
			StringBuilder strQuery = new StringBuilder(512);
			IDataReader drPrecio = null;
			float flSalida = 0;
			strQuery.Append("Select Precio ");
			strQuery.Append(" From Precios ");
			strQuery.Append(" Where IdTipoInforme = " + lIdTipoInforme.ToString());
			strQuery.Append(" And TipoPrecio = " + lTipoPrecio.ToString());
			strQuery.Append(" And Actual = 1");
			
			try
			{
				drPrecio = StaticDal.EjecutarDataReader(strQuery.ToString());
				if(drPrecio.Read())
				{
					flSalida = drPrecio.GetFloat(0);
				}
			}
			catch
			{
				flSalida = 0;
			}

			return flSalida;

		}

        public static float TraerPrecioActualPropiedad(int lIdTipoPropiedad, byte lTipoPrecio)
        {
            StringBuilder strQuery = new StringBuilder(512);
            IDataReader drPrecio = null;
            float flSalida = 0;
            strQuery.Append("Select Precio ");
            strQuery.Append(" From PreciosPropiedad ");
            strQuery.Append(" Where IdTipoPropiedad = " + lIdTipoPropiedad.ToString());
            strQuery.Append(" And TipoPrecio = " + lTipoPrecio.ToString());
            strQuery.Append(" And Actual = 1");

            try
            {
                drPrecio = StaticDal.EjecutarDataReader(strQuery.ToString());
                if (drPrecio.Read())
                {
                    flSalida = drPrecio.GetFloat(0);
                }
            }
            catch
            {
                flSalida = 0;
            }

            return flSalida;

        }

		public static void AgregarPrecio(float lPrecio, int lIdTipoInforme, byte lTipoPrecio)
		{
			try
			{
				StringBuilder strQuery = new StringBuilder(512);
				strQuery.Append("Update Precios Set Actual = 0 Where ");
				strQuery.Append(" IdTipoInforme = " + StaticDal.Traduce(lIdTipoInforme));
				strQuery.Append(" And TipoPrecio = " + StaticDal.Traduce(lTipoPrecio));
				StaticDal.EjecutarComando(strQuery.ToString());

				strQuery = new StringBuilder(512);
				strQuery.Append("Insert Into Precios (IdTipoInforme, FecDesde, TipoPrecio, Precio) ");
				strQuery.Append(" Values (" + StaticDal.Traduce(lIdTipoInforme));
				strQuery.Append(", getdate() ");
				strQuery.Append(", " + StaticDal.Traduce(lTipoPrecio));
				strQuery.Append(", " + StaticDal.Traduce(lPrecio) + ")");
			

				StaticDal.EjecutarComando(strQuery.ToString());
			}
			catch(Exception e)
			{
				Console.WriteLine(e.Message + Environment.NewLine + e.StackTrace);
			}

		}

        public static void AgregarPrecioPropiedad(float lPrecio, int lIdTipoPropiedad, byte lTipoPrecio)
        {
            try
            {
                StringBuilder strQuery = new StringBuilder(512);
                strQuery.Append("Update PreciosPropiedad Set Actual = 0 Where ");
                strQuery.Append(" IdTipoPropiedad = " + StaticDal.Traduce(lIdTipoPropiedad));
                strQuery.Append(" And TipoPrecio = " + StaticDal.Traduce(lTipoPrecio));
                StaticDal.EjecutarComando(strQuery.ToString());

                strQuery = new StringBuilder(512);
                strQuery.Append("Insert Into PreciosPropiedad (IdTipoPropiedad, FecDesde, TipoPrecio, Precio) ");
                strQuery.Append(" Values (" + StaticDal.Traduce(lIdTipoPropiedad));
                strQuery.Append(", getdate() ");
                strQuery.Append(", " + StaticDal.Traduce(lTipoPrecio));
                strQuery.Append(", " + StaticDal.Traduce(lPrecio) + ")");


                StaticDal.EjecutarComando(strQuery.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + Environment.NewLine + e.StackTrace);
            }

        }


        public static void AgregarPrecioAdicional(float lPrecio, int lTipoAdicional)
        {
            try
            {
                StringBuilder strQuery = new StringBuilder(512);
                strQuery.Append("Update PreciosAdicionales Set Actual = 0 Where ");
                strQuery.Append(" IdServicioAdicional = " + StaticDal.Traduce(lTipoAdicional));
                StaticDal.EjecutarComando(strQuery.ToString());

                strQuery = new StringBuilder(512);
                strQuery.Append("Insert Into PreciosAdicionales (IdServicioAdicional, FecDesde, Precio) ");
                strQuery.Append(" Values (" + StaticDal.Traduce(lTipoAdicional));
                strQuery.Append(", getdate() ");
                strQuery.Append(", " + StaticDal.Traduce(lPrecio) + ")");

                StaticDal.EjecutarComando(strQuery.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + Environment.NewLine + e.StackTrace);
            }

        }

		public static void ModificarPrecio(DateTime lFecha, byte lTipoPrecio, int lIdTipoInforme, float lPrecio)
		{
			StringBuilder strQuery = new StringBuilder(512);
			strQuery.Append("Update Precios ");
			strQuery.Append(" Set Precio = " + StaticDal.Traduce(lPrecio));
			strQuery.Append(" Where IdTipoInforme = " + StaticDal.Traduce(lIdTipoInforme));
			strQuery.Append(" And FecDesde = " + StaticDal.Traduce(lFecha));
			strQuery.Append(" And TipoPrecio = " + StaticDal.Traduce(lTipoPrecio));
			
			try
			{

				StaticDal.EjecutarComando(strQuery.ToString());
			}
			catch
			{
				throw;
			}

		}

        public static void ModificarPrecioPropiedad(DateTime lFecha, byte lTipoPrecio, int lIdTipoPropiedad, float lPrecio)
        {
            StringBuilder strQuery = new StringBuilder(512);
            strQuery.Append("Update PreciosPropiedad ");
            strQuery.Append(" Set Precio = " + StaticDal.Traduce(lPrecio));
            strQuery.Append(" Where IdTipoPropiedad = " + StaticDal.Traduce(lIdTipoPropiedad));
            strQuery.Append(" And FecDesde = " + StaticDal.Traduce(lFecha));
            strQuery.Append(" And TipoPrecio = " + StaticDal.Traduce(lTipoPrecio));

            try
            {

                StaticDal.EjecutarComando(strQuery.ToString());
            }
            catch
            {
                throw;
            }

        }

        public static void ModificarPrecioAdicional(int lidPrecioAdicional, int lTipoAdicional, float lPrecio)
        {
            StringBuilder strQuery = new StringBuilder(512);
            strQuery.Append("Update PreciosAdicionales ");
            strQuery.Append(" Set Precio = " + StaticDal.Traduce(lPrecio));
            strQuery.Append(" Where IdServicioAdicional = " + StaticDal.Traduce(lidPrecioAdicional));

            try
            {

                StaticDal.EjecutarComando(strQuery.ToString());
            }
            catch
            {
                throw;
            }

        }

        public static DataTable ListarAdicionales(string lTexto)
        {
            StringBuilder strQuery = new StringBuilder(512);
            DataTable dtSalida = null;
            strQuery.Append("Select id, descripcion ");
            strQuery.Append(" From serviciosAdicionales ");
            if (lTexto != "")
                strQuery.Append(" Where id = " + lTexto + " ");

            strQuery.Append(" Order by descripcion");

            try
            {
                dtSalida = StaticDal.EjecutarDataSet(strQuery.ToString(), "Adicionales").Tables[0];
            }
            catch
            {
                throw;
            }
            return dtSalida;

        }


        public static void EliminarAdicional(int lId)
        {
            StringBuilder strSqlUpdate = new StringBuilder(128);
            strSqlUpdate.Append("Delete From serviciosAdicionales ");
            strSqlUpdate.Append(" Where id = " + lId);
            try
            {
                StaticDal.EjecutarComando(strSqlUpdate.ToString());
            }
            catch
            {
                throw;
            }
        }


        public static void EliminarClienteCC(int lIdCliente)
        {
            StringBuilder strSqlUpdate = new StringBuilder(128);
            strSqlUpdate.Append("DELETE FROM cuentascorrientes ");
            strSqlUpdate.Append(" WHERE idCliente=" + lIdCliente);
            strSqlUpdate.Append(" AND NOT idCliente IN ( ");
            strSqlUpdate.Append(" SELECT DISTINCT idCliente ");
            strSqlUpdate.Append(" FROM CtaCteMovimientos ");
            strSqlUpdate.Append(" Where idCliente=" + lIdCliente + ")");
            try
            {
                StaticDal.EjecutarComando(strSqlUpdate.ToString());
            }
            catch
            {
                throw;
            }
        }


        public static void CrearAdicional(string lDescripcion)
        {
            try
            {
                StringBuilder strQuery = new StringBuilder(512);
                strQuery = new StringBuilder(512);
                strQuery.Append("Insert Into serviciosAdicionales (descripcion) ");
                strQuery.Append(" Values (" + StaticDal.Traduce(lDescripcion) + ")");


                StaticDal.EjecutarComando(strQuery.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + Environment.NewLine + e.StackTrace);
            }

        }

        public static void ModificarAdicional(int lId, string lDescripcion)
        {
            try
            {
                StringBuilder strQuery = new StringBuilder(512);
                strQuery = new StringBuilder(512);
                strQuery.Append("UPDATE serviciosAdicionales ");
                strQuery.Append(" SET descripcion=" + StaticDal.Traduce(lDescripcion));
                strQuery.Append(" WHERE id = " + lId);

                StaticDal.EjecutarComando(strQuery.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + Environment.NewLine + e.StackTrace);
            }

        }


        public static string CargarAdicional(int lId)
        {
            StringBuilder strQuery = new StringBuilder(512);
            IDataReader drDescripcion = null;
            string flSalida = "";
            strQuery.Append("Select descripcion ");
            strQuery.Append(" From serviciosAdicionales ");
            strQuery.Append(" Where id = " + lId);

            try
            {
                drDescripcion = StaticDal.EjecutarDataReader(strQuery.ToString());
                if (drDescripcion.Read())
                {
                    flSalida = drDescripcion.GetString(0);
                }
            }
            catch
            {
                flSalida = "";
            }

            return flSalida;

        }


        public static float CargarPrecioAdicional(int lId)
        {
            StringBuilder strQuery = new StringBuilder(512);
            IDataReader drDescripcion = null;
            float flSalida = 0;
            strQuery.Append("Select Precio ");
            strQuery.Append(" From preciosAdicionales ");
            strQuery.Append(" Where idServicioAdicional = " + lId);
            strQuery.Append(" AND Actual = 1 ");

            try
            {
                drDescripcion = StaticDal.EjecutarDataReader(strQuery.ToString());
                if (drDescripcion.Read())
                {
                    flSalida = drDescripcion.GetFloat(0);
                }
            }
            catch
            {
                flSalida = 0;
            }

            return flSalida;

        }


        public static DataTable RemitoListarTiposInformes(string strSQL)
        {

            StringBuilder strQuery = new StringBuilder(512);
            DataTable dtSalida = null;
            strQuery.Append("SELECT count(b.idTipoInforme) as cantidad, b.idTipoInforme,  ");
            strQuery.Append("ti.descripcion as tipoinforme, (count(b.idTipoInforme) * p.precio) as precioTotal "); //c.descripcion as caracter, 
            strQuery.Append("Into #Temp ");
            strQuery.Append("FROM bandejaentrada b ");
            strQuery.Append("INNER JOIN tiposinformes ti ON b.idTipoInforme=ti.idTipoInforme ");
            strQuery.Append("LEFT OUTER JOIN precios p ON ti.idTipoInforme=p.idTipoInforme AND p.tipoprecio=b.caracter AND p.actual = 1 ");
            //strQuery.Append("INNER JOIN caracter c ON b.caracter = c.idCaracter ");
            strQuery.Append(strSQL);
            //strQuery.Append("GO ");
            strQuery.Append("SELECT sum(cantidad) as Cantidad, idTipoInforme, tipoinforme, sum(precioTotal) as PrecioTotal ");
            strQuery.Append("FROM #Temp ");
            strQuery.Append("GROUP BY idTipoInforme, tipoinforme ");
            strQuery.Append("ORDER BY idTipoInforme ");
            strQuery.Append("DROP table #temp ");
            //strQuery.Append("GO");
            
            /*
            strQuery.Append("WHERE b.FechaCarga BETWEEN " + FechaDesde + " AND " + FechaHasta + " ");
            strQuery.Append("AND b.idCliente = " + lCliente + " ");
            strQuery.Append("AND b.estado=3 ");
            strQuery.Append("AND p.fecDesde < b.fechaCarga ");
            strQuery.Append("AND p.actual = 1 ");
            strQuery.Append("AND b.idEncabezado NOT IN ( ");
            strQuery.Append("SELECT bb.idEncabezado FROM remitoinforme ri ");
            strQuery.Append("INNER JOIN bandejaentrada bb ON ri.idEncabezado=bb.idEncabezado ");
            strQuery.Append("WHERE bb.idCliente = " + lCliente + " ) ");
            strQuery.Append("GROUP BY b.idTipoInforme, ti.descripcion, p.precio, c.descripcion ");
            strQuery.Append("ORDER BY b.idTipoInforme ASC ");
             */

            try
            {
                dtSalida = StaticDal.EjecutarDataSet(strQuery.ToString(), "RemitoTiposInformes").Tables[0];
            }
            catch
            {
                throw;
            }
            return dtSalida;

        }



        public static DataTable RemitoParteEntregaListarInformes(int idTipoDocumento, int TipoInforme, int nroRemito, string strSQL)
        {
            

            StringBuilder strQuery = new StringBuilder(512);
            DataTable dtSalida = null;
            
            if (nroRemito == 0)
            {
                strQuery.Append("SELECT b.idEncabezado, b.fechaCarga, b.descripcioninf, p.precio ");
                strQuery.Append("FROM bandejaentrada b ");
                strQuery.Append("INNER JOIN tiposinformes ti on b.idTipoInforme=ti.idTipoInforme ");
                if (TipoInforme == 1) //Informes de propiedad
                {
                    strQuery.Append("INNER JOIN tipoPropiedad tp on b.PROPTipo=tp.idTipoPropiedad ");
                    strQuery.Append("INNER JOIN preciosPropiedad p on ti.idTipoInforme=1 AND p.idTipoPropiedad=b.PROPTipo AND p.tipoprecio=b.caracter ");
                }
                else
                    strQuery.Append("INNER JOIN precios p on ti.idTipoInforme=p.idTipoInforme AND p.tipoprecio=b.caracter ");
            }
            else
            {
                if (idTipoDocumento == 1)
                {
                    strQuery.Append("SELECT b.idEncabezado, b.fechaCarga, b.descripcioninf, ri.precio ");
                    strQuery.Append("FROM bandejaentrada b ");
                    strQuery.Append("INNER JOIN remitoinforme ri on b.idEncabezado=ri.idEncabezado ");
                }
                if (idTipoDocumento == 2)
                { 
                    strQuery.Append("SELECT b.idEncabezado, b.fechaCarga, b.descripcioninf, ri.precio ");
                    strQuery.Append("FROM bandejaentrada b ");
                    strQuery.Append("INNER JOIN parteEntregaInforme ri on b.idEncabezado=ri.idEncabezado ");
                }

            }


            strQuery.Append(strSQL);

            try
            {
                dtSalida = StaticDal.EjecutarDataSet(strQuery.ToString(), "RemitoTiposInformes").Tables[0];
            }
            catch
            {
                throw;
            }
            return dtSalida;

        }

        public int CrearRemitoParte(int idTipoDocumentacion, int idtipoCobranza, int idCliente, int idUsuarioIntra)
        {
            int MaxID = 0;
            string strSQL = "";
            string strMaxID = "";

            OdbcConnection oConnection = this.OpenConnection();
            if (idTipoDocumentacion == 1)
            {
                strSQL = "Insert into remitos (idCliente, idUsuarioIntra, periodoCobranza, fecha) ";
                strSQL = strSQL + " values (" + idCliente + ", " + idUsuarioIntra + ", " + idtipoCobranza + ", getdate())";

                strMaxID = "SELECT MAX(nroRemito) as MaxId FROM remitos";
            }
            if (idTipoDocumentacion == 2)
            {
                strSQL = "Insert into partesEntrega (idCliente, idUsuarioIntra, periodoCobranza, fecha) ";
                strSQL = strSQL + " values (" + idCliente + ", " + idUsuarioIntra + ", " + idtipoCobranza + ", getdate())";

                strMaxID = "SELECT MAX(nroParte) as MaxId FROM partesEntrega";
            }

            try
            {
                OdbcCommand myCommand = new OdbcCommand(strSQL, oConnection);
                myCommand.ExecuteNonQuery();

                MaxID = ObtenerMaxID(strMaxID, oConnection);
            }
            catch (Exception e)
            {
                string p = e.Message;
                return MaxID;
            }

            return MaxID;
        }


        public int ModificarRemitoParte(int idTipoDocumentacion, int idtipoCobranza, int nroRemito)
        {
            int MaxID = 0;
            string strSQL = "";

            OdbcConnection oConnection = this.OpenConnection();
            if (idTipoDocumentacion == 1)
            {
                strSQL = "UPDATE remitos SET periodoCobranza = " + idtipoCobranza +
                " WHERE nroRemito = "+ nroRemito;

            }
            if (idTipoDocumentacion == 2)
            {
                strSQL = "UPDATE partesEntrega SET periodoCobranza = " + idtipoCobranza +
                " WHERE nroParte = " + nroRemito;
            }

            try
            {
                OdbcCommand myCommand = new OdbcCommand(strSQL, oConnection);
                myCommand.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                string p = e.Message;
                return MaxID;
            }

            return MaxID;
        }


        public void cargarRemitoParte(int lidTipoDocumento, int lnroRemito)
        {

            OdbcConnection oConnection = OpenConnection();
            string strSql = "";
            if(lidTipoDocumento == 1)
                strSql = "select * from remitos where nroRemito=" + lnroRemito.ToString();
            
            if (lidTipoDocumento == 2)
                strSql = "select nroParte as nroRemito, periodoCobranza from partesEntrega where nroParte=" + lnroRemito.ToString();
            //try
            {
                OdbcDataAdapter myConsulta = new OdbcDataAdapter(strSql, oConnection);
                DataSet myDataSet = new DataSet();
                myConsulta.Fill(myDataSet);
                intNroRemito = int.Parse(myDataSet.Tables[0].Rows[0]["nroRemito"].ToString());
                intTipoPeriodo = int.Parse(myDataSet.Tables[0].Rows[0]["periodoCobranza"].ToString());

                oConnection.Close();
            }
            //	catch {}
        }


        public void agregarInformesRemitoParte(int idTipoDocumentacion, int idRemito, int idTipoInforme, int idEncabezado, decimal precio)
        {
            //int MaxID = 0;
            OdbcConnection oConnection = this.OpenConnection();
            string strSQL = "";
            if (idTipoDocumentacion == 1)
            {
                strSQL = strSQL + "Insert into remitoinforme (nroRemito, idEncabezado, idTipoInforme, precio, fecha, facturado) ";
                strSQL = strSQL + " values (" + idRemito + ", " + idEncabezado + ", " + idTipoInforme + ", " + precio.ToString().Replace(',', '.') + ", getdate(), 0)";
            }

            if (idTipoDocumentacion == 2)
            {
                strSQL = strSQL + "Insert into parteEntregaInforme (nroParte, idEncabezado, idTipoInforme, precio, fecha, facturado) ";
                strSQL = strSQL + " values (" + idRemito + ", " + idEncabezado + ", " + idTipoInforme + ", " + precio.ToString().Replace(',', '.') + ", getdate(), 0)";
            }

            try
            {
                OdbcCommand myCommand = new OdbcCommand(strSQL, oConnection);
                myCommand.ExecuteNonQuery();

                //MaxID = ObtenerMaxID(strMaxID, oConnection);
            }
            catch (Exception e)
            {
                string p = e.Message;
                //return MaxID;
            }

            //return MaxID;
        }

        public void modificarInformesRemitoParte(int idTipoDocumentacion, int idRemito, int idTipoInforme, int idEncabezado, decimal precio)
        {
            //int MaxID = 0;
            OdbcConnection oConnection = this.OpenConnection();
            string strSQL = "";
            if (idTipoDocumentacion == 1)
            {
                strSQL = strSQL + "UPDATE remitoinforme SET " +
                    "precio = " + precio.ToString().Replace(',', '.') +
                    " WHERE nroRemito=" + idRemito + " AND idEncabezado=" + idEncabezado;
            }

            if (idTipoDocumentacion == 2)
            {
                strSQL = strSQL + "UPDATE parteEntregaInforme SET " +
                    "precio = " + precio.ToString().Replace(',', '.') +
                    " WHERE nroParte=" + idRemito + " AND idEncabezado=" + idEncabezado;
            }

            try
            {
                OdbcCommand myCommand = new OdbcCommand(strSQL, oConnection);
                myCommand.ExecuteNonQuery();

                //MaxID = ObtenerMaxID(strMaxID, oConnection);
            }
            catch (Exception e)
            {
                string p = e.Message;
                //return MaxID;
            }

            //return MaxID;
        }


        public bool eliminarInformeRemito(int tipoDocumentacion, int nroRemito, int idEncabezado)
        {
            OdbcConnection oConnection = this.OpenConnection();
            string strSQL = "";
            if(tipoDocumentacion == 1) 
            {
            strSQL = "DELETE remitoinforme " +
                 " WHERE idEncabezado = " + idEncabezado +
                 " AND nroRemito=" + nroRemito +
                 " AND facturado=0";
            }

            if (tipoDocumentacion == 2)
            {
                strSQL = "DELETE parteentregainforme " +
                     " WHERE idEncabezado = " + idEncabezado +
                     " AND nroParte=" + nroRemito +
                     " AND facturado=0";
            }

            //String strMaxID = "SELECT MAX(nroRemito) as MaxId FROM remitos";

            try
            {
                OdbcCommand myCommand = new OdbcCommand(strSQL, oConnection);
                myCommand.ExecuteNonQuery();

                //MaxID = ObtenerMaxID(strMaxID, oConnection);
            }
            catch (Exception e)
            {
                string p = e.Message;
                return false;
            }

            return true;
        }


        public bool eliminarRemitoMovimiento(int idTipoDocumentacion, int nroMovimiento, int nroRemito)
        {
            OdbcConnection oConnection = this.OpenConnection();
            string strSQL = "";
            if (idTipoDocumentacion == 1)
            {
                strSQL = "DELETE CtaCteMovimientosRemitos " +
                " WHERE nroMovimiento = " + nroMovimiento +
                " AND nroRemito=" + nroRemito;
            }

            if (idTipoDocumentacion == 2)
            {
                strSQL = "DELETE CtaCteMovimientosPartesEntrega " +
                " WHERE nroMovimiento = " + nroMovimiento +
                " AND nroParte=" + nroRemito;
            }

            //String strMaxID = "SELECT MAX(nroRemito) as MaxId FROM remitos";

            try
            {
                OdbcCommand myCommand = new OdbcCommand(strSQL, oConnection);
                myCommand.ExecuteNonQuery();

                //MaxID = ObtenerMaxID(strMaxID, oConnection);
            }
            catch (Exception e)
            {
                string p = e.Message;
                return false;
            }

            return true;
        }
        

        public bool eliminarAdicionalRemito(int tipoDocumentacion, int nroRemito, int idAdicional)
        {
            OdbcConnection oConnection = this.OpenConnection();
            string strSQL = "";

            if (tipoDocumentacion == 1)
            {
                strSQL = "DELETE remitoadicionales " +
                     " WHERE idAdicional = " + idAdicional +
                     " AND nroRemito=" + nroRemito +
                     " AND facturado=0";
            }

            if (tipoDocumentacion == 2)
            {
                strSQL = "DELETE parteEntregaAdicionales " +
                     " WHERE idAdicional = " + idAdicional +
                     " AND nroParte=" + nroRemito +
                     " AND facturado=0";
            }

            try
            {
                OdbcCommand myCommand = new OdbcCommand(strSQL, oConnection);
                myCommand.ExecuteNonQuery();

                //MaxID = ObtenerMaxID(strMaxID, oConnection);
            }
            catch (Exception e)
            {
                string p = e.Message;
                return false;
            }

            return true;
        }


        public bool eliminarTodosAdicionalesRemitosParteEntrega(int tipoDocumentacion, int nroRemito)
        {
            OdbcConnection oConnection = this.OpenConnection();
            string strSQL = "";

            if (tipoDocumentacion == 1)
            {
                strSQL = "DELETE remitoadicionales " +
                     " WHERE nroRemito=" + nroRemito +
                     " AND facturado=0";
            }

            if (tipoDocumentacion == 2)
            {
                strSQL = "DELETE parteEntregaAdicionales " +
                     " WHERE nroParte=" + nroRemito +
                     " AND facturado=0";
            }

            try
            {
                OdbcCommand myCommand = new OdbcCommand(strSQL, oConnection);
                myCommand.ExecuteNonQuery();

                //MaxID = ObtenerMaxID(strMaxID, oConnection);
            }
            catch (Exception e)
            {
                string p = e.Message;
                return false;
            }

            return true;
        }

        public void agregarAdicionalRemito(int idTipoDocumentacion, int idRemito, int idAdicional, int Cantidad, decimal precio)
        {
            //int MaxID = 0;
            OdbcConnection oConnection = this.OpenConnection();
            string strSQL = "";
            if (idTipoDocumentacion == 1)
            {
                strSQL = strSQL + "Insert into remitoadicionales(nroRemito, idAdicional, cantidad, precio, fecha, facturado) ";
                strSQL = strSQL + " values (" + idRemito + ", " + idAdicional + ", " + Cantidad + ", " + precio.ToString().Replace(',', '.') + ", getdate(), 0)";
            }

            if (idTipoDocumentacion == 2)
            {
                strSQL = strSQL + "Insert into parteEntregaAdicionales(nroParte, idAdicional, cantidad, precio, fecha, facturado) ";
                strSQL = strSQL + " values (" + idRemito + ", " + idAdicional + ", " + Cantidad + ", " + precio.ToString().Replace(',', '.') + ", getdate(), 0)";
            }

            try
            {
                OdbcCommand myCommand = new OdbcCommand(strSQL, oConnection);
                myCommand.ExecuteNonQuery();
                //cmd.ExecuteNonQuery();

                //MaxID = ObtenerMaxID(strMaxID, oConnection);
            }
            catch (Exception e)
            {
                string p = e.Message;
                //return MaxID;
            }

            //return MaxID;
        }

        private static int ObtenerMaxID(string strMaxID, OdbcConnection oConnection)
        {
            DataSet ds = new DataSet();
            OdbcDataAdapter myConsulta = new OdbcDataAdapter(strMaxID, oConnection);
            myConsulta.Fill(ds);
            int MaxID = 0;
            try
            {
                MaxID = int.Parse(ds.Tables[0].Rows[0]["Maxid"].ToString());
            }
            catch
            {
                return 0;
            }
            return MaxID;
        }

        public static DataTable ListaRemitosPartesEntrega(int idTipoDocumentacion, int idCliente, string FechaDesde, string FechaHasta, bool SinMovimiento, string nroMovimiento)
        {
            //SinMovimiento: "false" lista los remitos/partes desde abmRemitos. "true" lista los remitos/partes desde abmMovimientos.

            if (FechaDesde != "")
                FechaDesde = "'" + FechaDesde + " 00:00:00.000'";

            if (FechaHasta != "")
                FechaHasta = "'" + FechaHasta + " 23:59:59.999'";

            string FechaActual = DateTime.Today.ToShortDateString();
            FechaActual = "'" + FechaActual + " 00:00:00.000'";

            StringBuilder strQuery = new StringBuilder(512);
            DataTable dtSalida = null;

            if (idTipoDocumentacion == 1)
            {
                strQuery.Append("select r.nroRemito, r.fecha, count(distinct(ri.idEncabezado)) as cantInformes, isnull(sum(distinct(ra.cantidad)),0) as cantAdicionales ");
                strQuery.Append("from remitos r ");
                strQuery.Append("left outer join remitoinforme ri on r.nroRemito=ri.nroRemito ");
                strQuery.Append("left outer join remitoadicionales ra on r.nroRemito=ra.nroRemito ");
                strQuery.Append("where r.idCliente= " + idCliente + " ");
                if (nroMovimiento != "")
                {
                    strQuery.Append("AND r.nroRemito IN (SELECT nroRemito from CtaCteMovimientosRemitos ");
                    strQuery.Append("WHERE nroMovimiento= " + int.Parse(nroMovimiento) + ")  ");
                }
                if (FechaDesde != "" && FechaDesde != "")
                    strQuery.Append("AND r.fecha BETWEEN " + FechaDesde + " AND " + FechaHasta + " ");
                if (SinMovimiento)
                {
                    strQuery.Append("AND r.periodoCobranza=2 AND r.nroRemito NOT IN ( ");
                    strQuery.Append("select ccmr.nroRemito ");
                    strQuery.Append("from CtaCteRemitos ccm ");
                    strQuery.Append("inner join CtaCteMovimientosRemitos ccmr on ccmr.nroMovimiento=ccm.nroMovimiento ");
                    strQuery.Append("where ccm.idCliente= " + idCliente + " ");
                    strQuery.Append("AND ccm.fecha BETWEEN " + FechaDesde + " AND " + FechaHasta + " )");
                }

                strQuery.Append("group by r.nroRemito, r.fecha ");
                strQuery.Append("order by r.nroRemito Desc");
            }

            if (idTipoDocumentacion == 2)
            {
                strQuery.Append("select r.nroParte as nroRemito, r.fecha, count(distinct(ri.idEncabezado)) as cantInformes, isnull(sum(distinct(ra.cantidad)),0) as cantAdicionales ");
                strQuery.Append("from partesEntrega r ");
                strQuery.Append("left outer join parteEntregaInforme ri on r.nroParte=ri.nroParte ");
                strQuery.Append("left outer join parteEntregaAdicionales ra on r.nroParte=ra.nroParte ");
                strQuery.Append("where r.idCliente= " + idCliente + " ");
                if (nroMovimiento != "")
                {
                    strQuery.Append(" AND r.nroParte IN (SELECT nroParte from CtaCteMovimientosPartesEntrega ");
                    strQuery.Append("WHERE nroMovimiento= " + int.Parse(nroMovimiento) + ")  ");
                }
                if (FechaDesde != "" && FechaDesde != "")
                    strQuery.Append("AND r.fecha BETWEEN " + FechaDesde + " AND " + FechaHasta + " ");
                if (SinMovimiento)
                {
                    strQuery.Append("AND r.periodoCobranza=2 AND r.nroParte NOT IN ( ");
                    strQuery.Append("select ccmr.nroParte ");
                    strQuery.Append("from CtaCtePartesEntrega ccm ");
                    strQuery.Append("inner join CtaCteMovimientosPartesEntrega ccmr on ccmr.nroMovimiento=ccm.nroMovimiento ");
                    strQuery.Append("where ccm.idCliente= " + idCliente + " ");
                    strQuery.Append("AND ccm.fecha BETWEEN " + FechaDesde + " AND " + FechaHasta + " )");
                }

                strQuery.Append("group by r.nroParte, r.fecha ");
                strQuery.Append("order by r.nroParte Desc");
            }

            try
            {
                dtSalida = StaticDal.EjecutarDataSet(strQuery.ToString(), "RemitoxCliente").Tables[0];
            }
            catch
            {
                throw;
            }
            return dtSalida;
        }


        public static DataTable ListaRemitosPartesEntrega(int tipoDocumento, int nroRemito)
        {

            StringBuilder strQuery = new StringBuilder(512);
            DataTable dtSalida = null;
            if (tipoDocumento == 1)
            {
                strQuery.Append("select r.nroRemito, r.fecha ");
                strQuery.Append("from remitos r ");
                strQuery.Append("where r.nroRemito= " + nroRemito + " ");
            }

            if (tipoDocumento == 2)
            {
                strQuery.Append("select r.nroParte as nroRemito, r.fecha ");
                strQuery.Append("from partesEntrega r ");
                strQuery.Append("where r.nroParte= " + nroRemito + " ");
            }


            try
            {
                dtSalida = StaticDal.EjecutarDataSet(strQuery.ToString(), "RemitoxCliente").Tables[0];
            }
            catch
            {
                throw;
            }
            return dtSalida;
        }


        public static DataTable ListarAdicionalesRemito(int tipoDocumentacion, int nroRemito)
        {

            StringBuilder strQuery = new StringBuilder(512);
            DataTable dtSalida = null;

            if (tipoDocumentacion == 1)
            {
                strQuery.Append("SELECT ra.nroRemito, ra.idAdicional, ra.cantidad, ra.precio as PrecioUnitario, ");
                strQuery.Append("(ra.cantidad* ra.precio) as Precio , sa.descripcion as Adicional ");
                strQuery.Append("FROM remitoadicionales ra ");
                strQuery.Append("INNER JOIN serviciosadicionales sa ON ra.idAdicional=sa.id ");
                strQuery.Append("WHERE ra.nroRemito= " + nroRemito + " ");
            }

            if (tipoDocumentacion == 2)
            {
                strQuery.Append("SELECT ra.nroParte as nroRemito, ra.idAdicional, ra.cantidad, ra.precio as PrecioUnitario, ");
                strQuery.Append("(ra.cantidad* ra.precio) as Precio , sa.descripcion as Adicional ");
                strQuery.Append("FROM parteEntregaAdicionales ra ");
                strQuery.Append("INNER JOIN serviciosadicionales sa ON ra.idAdicional=sa.id ");
                strQuery.Append("WHERE ra.nroParte= " + nroRemito + " ");
            }

            try
            {
                dtSalida = StaticDal.EjecutarDataSet(strQuery.ToString(), "RemitoxCliente").Tables[0];
            }
            catch
            {
                throw;
            }
            return dtSalida;
        }


        public static DataTable ListaDetallesRemitoParteEntrega(int idTipoDocumentacion, int NroRemito, bool refer)
        {

            StringBuilder strQuery = new StringBuilder(512);
            DataTable dtSalida = null;
            /*
            strQuery.Append("select count(ri.idTipoInforme) as cantidad, ti.descripcion, ri.precio as precioUnitario, (count(ri.idTipoInforme) * ri.precio) as precioTotal ");
            strQuery.Append("from remitos r ");
            strQuery.Append("inner join remitoinforme ri on r.nroRemito=ri.nroRemito ");
            strQuery.Append("inner join tiposinformes ti on ri.idTipoInforme=ti.idTipoInforme ");
            strQuery.Append("where r.nroRemito=" + NroRemito + " ");
            strQuery.Append("group by ri.idTipoInforme, ti.descripcion, ri.precio ");
            strQuery.Append("union ");
            strQuery.Append("select ra.cantidad, sa.descripcion, ra.precio as precioUnitario, (ra.cantidad*ra.precio) as precioTotal ");
            strQuery.Append("from remitos r ");
            strQuery.Append("inner join remitoadicionales ra on r.nroRemito=ra.nroRemito ");
            strQuery.Append("inner join serviciosadicionales sa on sa.id=ra.idAdicional ");
            strQuery.Append("where r.nroRemito=" + NroRemito + " ");
            */
            /* AGRUPADOS POR TIPO
            strQuery.Append("SELECT count(ri.idTipoInforme) as cantidad, ");
            strQuery.Append("(ti.descripcion + ");
            strQuery.Append("isnull(CASE WHEN b.idTipoInforme=1 THEN ' - ' + tp.descripcion ELSE NULL END, '') + ");
            strQuery.Append("isnull(CASE WHEN b.idTipoInforme=1 AND b.PROPTipo <> 1 THEN ' (' + c.descripcion + ')' ELSE NULL END, '') ");
            strQuery.Append(") as descripcion, ");
            strQuery.Append("ri.precio as precioUnitario, ");
            strQuery.Append("(count(ri.idTipoInforme) * ri.precio) as precioTotal, 1 as orden, ri.idTipoInforme ");
            strQuery.Append("from remitos r ");
            strQuery.Append("inner join remitoinforme ri on r.nroRemito=ri.nroRemito ");
            strQuery.Append("inner join bandejaentrada b on b.idEncabezado=ri.idEncabezado ");
            strQuery.Append("inner join tiposinformes ti on ri.idTipoInforme=ti.idTipoInforme ");
            strQuery.Append("inner join tipopropiedad tp on b.PROPTipo=tp.idTipoPropiedad ");
            strQuery.Append("inner join caracter c on b.caracter=c.idCaracter ");
            strQuery.Append("where r.nroRemito=" + NroRemito + " ");
            strQuery.Append("group by ri.idTipoInforme, ti.descripcion, ri.precio, b.idTipoInforme, b.PROPTipo, tp.descripcion, c.descripcion ");
            strQuery.Append("union ");
            strQuery.Append("select ra.cantidad, sa.descripcion, ra.precio as precioUnitario, (ra.cantidad*ra.precio) as precioTotal, 2 as orden, 1000 as idTipoInforme ");
            strQuery.Append("from remitos r ");
            strQuery.Append("inner join remitoadicionales ra on r.nroRemito=ra.nroRemito ");
            strQuery.Append("inner join serviciosadicionales sa on sa.id=ra.idAdicional ");
            strQuery.Append("where r.nroRemito=" + NroRemito + " ");
            strQuery.Append("order by orden, ri.idTipoInforme");
            */

            if (idTipoDocumentacion == 1)
            {
                strQuery.Append("SELECT count(ri.idTipoInforme) as cantidad, ");
                strQuery.Append("(ti.descripcion + ': ' + ");
                strQuery.Append("replace(replace(b.descripcioninf, '<B>', ''),'</B>','') ");
                if (refer)
                    strQuery.Append("+ '  (Ref. ' + rf.descripcion + ')'");
                strQuery.Append(") as descripcion, ");
                strQuery.Append("ri.precio as precioUnitario, (count(ri.idTipoInforme) * ri.precio) as precioTotal, 1 as orden, ");
                strQuery.Append("ri.idTipoInforme ");
                strQuery.Append("from remitos r ");
                strQuery.Append("inner join remitoinforme ri on r.nroRemito=ri.nroRemito ");
                strQuery.Append("inner join bandejaentrada b on b.idEncabezado=ri.idEncabezado ");
                strQuery.Append("inner join referencias rf on b.idReferencia=rf.idReferencia ");
                strQuery.Append("inner join tiposinformes ti on ri.idTipoInforme=ti.idTipoInforme ");
                strQuery.Append("inner join tipopropiedad tp on b.PROPTipo=tp.idTipoPropiedad ");

                strQuery.Append("where r.nroRemito=" + NroRemito + " ");
                strQuery.Append("group by ri.idTipoInforme, ti.descripcion, ri.precio, b.idTipoInforme, b.PROPTipo, ");
                strQuery.Append("tp.descripcion, b.descripcioninf, rf.descripcion ");

                strQuery.Append("union ");
                strQuery.Append("select ra.cantidad, sa.descripcion, ra.precio as precioUnitario, (ra.cantidad*ra.precio) as precioTotal, ");
                strQuery.Append("2 as orden, 1000 as idTipoInforme ");
                strQuery.Append("from remitos r ");
                strQuery.Append("inner join remitoadicionales ra on r.nroRemito=ra.nroRemito ");
                strQuery.Append("inner join serviciosadicionales sa on sa.id=ra.idAdicional ");
                strQuery.Append("where r.nroRemito=" + NroRemito + " ");
                strQuery.Append("order by orden, ri.idTipoInforme");
            }
            if (idTipoDocumentacion == 2)
            {
                strQuery.Append("SELECT count(ri.idTipoInforme) as cantidad, ");
                strQuery.Append("(ti.descripcion + ': ' + ");
                strQuery.Append("replace(replace(b.descripcioninf, '<B>', ''),'</B>','') ");
                if (refer)
                    strQuery.Append("+ '  (Ref. ' + rf.descripcion + ')'");
                strQuery.Append(") as descripcion, ");
                strQuery.Append("ri.precio as precioUnitario, (count(ri.idTipoInforme) * ri.precio) as precioTotal, 1 as orden, ");
                strQuery.Append("ri.idTipoInforme ");
                strQuery.Append("from partesEntrega r ");
                strQuery.Append("inner join parteEntregaInforme ri on r.nroParte=ri.nroParte ");
                strQuery.Append("inner join bandejaentrada b on b.idEncabezado=ri.idEncabezado ");
                strQuery.Append("inner join referencias rf on b.idReferencia=rf.idReferencia ");
                strQuery.Append("inner join tiposinformes ti on ri.idTipoInforme=ti.idTipoInforme ");
                strQuery.Append("inner join tipopropiedad tp on b.PROPTipo=tp.idTipoPropiedad ");

                strQuery.Append("where r.nroParte=" + NroRemito + " ");
                strQuery.Append("group by ri.idTipoInforme, ti.descripcion, ri.precio, b.idTipoInforme, b.PROPTipo, ");
                strQuery.Append("tp.descripcion, b.descripcioninf, rf.descripcion ");

                strQuery.Append("union ");
                strQuery.Append("select ra.cantidad, sa.descripcion, ra.precio as precioUnitario, (ra.cantidad*ra.precio) as precioTotal, ");
                strQuery.Append("2 as orden, 1000 as idTipoInforme ");
                strQuery.Append("from partesEntrega r ");
                strQuery.Append("inner join parteEntregaAdicionales ra on r.nroParte=ra.nroParte ");
                strQuery.Append("inner join serviciosadicionales sa on sa.id=ra.idAdicional ");
                strQuery.Append("where r.nroParte=" + NroRemito + " ");
                strQuery.Append("order by orden, ri.idTipoInforme");
            }

            try
            {
                dtSalida = StaticDal.EjecutarDataSet(strQuery.ToString(), "RemitoxCliente").Tables[0];
            }
            catch
            {
                throw;
            }
            return dtSalida;
        }


        public static decimal precioTotalRemitoParteEntrega(int idTipoDocumento, int NroRemito)
        {
            DataTable Datos = GestorPrecios.ListaDetallesRemitoParteEntrega(idTipoDocumento, NroRemito, false);
            decimal precioTotal = 0;
            for (int i = 0; i < Datos.Rows.Count; i++)
            {
                precioTotal = precioTotal + decimal.Parse(Datos.Rows[i]["precioTotal"].ToString());
            }

            return precioTotal;
        }

        public static void AgregarClienteCuentaCorriente(int lIdCliente)
        {
            try
            {
                StringBuilder strQuery = new StringBuilder(512);
                strQuery.Append("insert into cuentascorrientes (idCliente, fechaIngreso, activo) ");
                strQuery.Append(" Values (" + StaticDal.Traduce(lIdCliente));
                strQuery.Append(", getdate() ");
                strQuery.Append(", 1)");

                StaticDal.EjecutarComando(strQuery.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + Environment.NewLine + e.StackTrace);
            }

        }


        public static DataTable TraerCuentasClientes()
        {
            StringBuilder strQuery = new StringBuilder(512);
            DataTable dtSalida = null;
            strQuery.Append("Select c.idCliente, c.razonsocial, c.nombrefantasia, c.sucursal, c.telefono,  ");
            strQuery.Append(" (c.calle +' '+ c.numero) as direccion, c.fax, c.cuit, c.email ");
            strQuery.Append(" From clientes c INNER JOIN cuentascorrientes cc ON c.idCliente=cc.idCliente ");
            strQuery.Append(" Order by c.nombrefantasia");

            try
            {

                dtSalida = StaticDal.EjecutarDataSet(strQuery.ToString(), "Precios").Tables[0];
            }
            catch
            {
                throw;
            }

            return dtSalida;
        }


        public static DataTable ListaMovimientosCliente(int idTipoDocumento, int idCliente, string FechaDesde, string FechaHasta)
        {
            if (FechaDesde != "")
                FechaDesde = "'" + FechaDesde + " 00:00:00.000'";

            if (FechaHasta != "")
                FechaHasta = "'" + FechaHasta + " 23:59:59.999'";

            string FechaActual = DateTime.Today.ToShortDateString();
            FechaActual = "'" + FechaActual + " 00:00:00.000'";

            StringBuilder strQuery = new StringBuilder(512);
            DataTable dtSalida = null;
            if (idTipoDocumento == 1)
            {
                strQuery.Append("select ccr.nroMovimiento, ccr.fecha, count(ccr.nroMovimiento) as cantRemitos ");
                strQuery.Append("from  CtaCteRemitos ccr  ");
                strQuery.Append("inner join CtaCteMovimientosRemitos ccmr on ccmr.nroMovimiento=ccr.nroMovimiento  ");
                strQuery.Append("where ccr.idCliente= " + idCliente + " ");
                strQuery.Append("AND ccr.fecha BETWEEN " + FechaDesde + " AND " + FechaHasta + " ");
                strQuery.Append("group by ccr.nroMovimiento, ccr.fecha ");
                strQuery.Append("order by ccr.nroMovimiento Desc");
            }

            if (idTipoDocumento == 2)
            {
                strQuery.Append("select ccr.nroMovimiento, ccr.fecha, count(ccr.nroMovimiento) as cantRemitos ");
                strQuery.Append("from  CtaCtePartesEntrega ccr  ");
                strQuery.Append("inner join CtaCteMovimientosPartesEntrega ccmr on ccmr.nroMovimiento=ccr.nroMovimiento  ");
                strQuery.Append("where ccr.idCliente= " + idCliente + " ");
                strQuery.Append("AND ccr.fecha BETWEEN " + FechaDesde + " AND " + FechaHasta + " ");
                strQuery.Append("group by ccr.nroMovimiento, ccr.fecha ");
                strQuery.Append("order by ccr.nroMovimiento Desc");
            }

            try
            {
                dtSalida = StaticDal.EjecutarDataSet(strQuery.ToString(), "MovimientosxCliente").Tables[0];
            }
            catch
            {
                throw;
            }
            return dtSalida;
        }


        public static DataTable ListaMovimientosCliente(int idTipoDocumentacion, int nroMovimiento)
        {

            StringBuilder strQuery = new StringBuilder(512);
            DataTable dtSalida = null;

            if (idTipoDocumentacion == 1)
            {
                strQuery.Append("select ccm.nroMovimiento, ccm.fecha ");
                strQuery.Append("from CtaCteRemitos ccm ");
                strQuery.Append("where ccm.nroMovimiento= " + nroMovimiento + " ");
            }

            if (idTipoDocumentacion == 2)
            {
                strQuery.Append("select ccm.nroMovimiento, ccm.fecha ");
                strQuery.Append("from CtaCtePartesEntrega ccm ");
                strQuery.Append("where ccm.nroMovimiento= " + nroMovimiento + " ");
            }

            try
            {
                dtSalida = StaticDal.EjecutarDataSet(strQuery.ToString(), "MovimientoxCliente").Tables[0];
            }
            catch
            {
                throw;
            }
            return dtSalida;
        }

        public static DataTable ListaDetallesRemitosMovimiento(int idTipoDocumento, int NroMovimiento, int idCliente)
        {

            StringBuilder strQuery = new StringBuilder(512);
            DataTable dtSalida = null;

            if (idTipoDocumento == 1)
            {
                strQuery.Append("select count(ri.idTipoInforme) as cantidad, ");
                strQuery.Append("(ti.descripcion + ");
                strQuery.Append("isnull(CASE WHEN b.idTipoInforme=1 THEN ' - ' + tp.descripcion ELSE NULL END, '') + ");
                strQuery.Append("isnull(CASE WHEN b.idTipoInforme=1 AND b.PROPTipo <> 1 THEN ' (' + c.descripcion + ')' ELSE NULL END, '') + ");
                strQuery.Append("isnull(CASE WHEN (b.idTipoInforme=13 OR b.idTipoInforme=3 OR b.idTipoInforme=16 ) THEN ' (' + c.descripcion + ')' ELSE NULL END, '') ");
                strQuery.Append(") as descripcion, ");
                strQuery.Append("ri.precio as precioUnitario, (count(ri.idTipoInforme) * ri.precio) as precioTotal, 1 as orden, ri.idTipoInforme  ");
                strQuery.Append("from CtaCteRemitos ccr  ");
                strQuery.Append("inner join CtaCteMovimientosRemitos ccmr on ccr.nroMovimiento=ccmr.nroMovimiento ");
                strQuery.Append("inner join remitos r on ccmr.nroRemito=r.nroRemito ");
                strQuery.Append("inner join remitoinforme ri on r.nroRemito=ri.nroRemito ");
                strQuery.Append("inner join bandejaentrada b on b.idEncabezado=ri.idEncabezado ");
                strQuery.Append("inner join tiposinformes ti on ri.idTipoInforme=ti.idTipoInforme ");
                strQuery.Append("inner join tipopropiedad tp on b.PROPTipo=tp.idTipoPropiedad ");
                strQuery.Append("inner join caracter c on b.caracter=c.idCaracter ");
                strQuery.Append("where ccmr.nroMovimiento=" + NroMovimiento + " ");
                strQuery.Append("and ccr.idCliente=" + idCliente + " ");
                strQuery.Append("group by ri.idTipoInforme, ti.descripcion, ri.precio, b.idTipoInforme, b.PROPTipo, tp.descripcion, c.descripcion ");
                strQuery.Append("union ");
                strQuery.Append("select sum(ra.cantidad), sa.descripcion, ra.precio as precioUnitario, (sum(ra.cantidad)*ra.precio) as precio, 2 as orden, 1000 as idTipoInforme  ");
                strQuery.Append("from CtaCteRemitos ccr  ");
                strQuery.Append("inner join ctaCteMovimientosRemitos ccmr on ccr.nroMovimiento=ccmr.nroMovimiento ");
                strQuery.Append("inner join remitos r on ccmr.nroRemito=r.nroRemito ");
                strQuery.Append("inner join remitoadicionales ra on r.nroRemito=ra.nroRemito ");
                strQuery.Append("inner join serviciosadicionales sa on sa.id=ra.idAdicional ");
                strQuery.Append("where ccmr.nroMovimiento=" + NroMovimiento + " ");
                strQuery.Append("and ccr.idCliente=" + idCliente + " ");
                strQuery.Append("group by sa.descripcion, ra.precio ");
                strQuery.Append("order by orden, ri.idTipoInforme");
            }

            if (idTipoDocumento == 2)
            {
                strQuery.Append("select count(ri.idTipoInforme) as cantidad, ");
                strQuery.Append("(ti.descripcion + ");
                strQuery.Append("isnull(CASE WHEN b.idTipoInforme=1 THEN ' - ' + tp.descripcion ELSE NULL END, '') + ");
                strQuery.Append("isnull(CASE WHEN b.idTipoInforme=1 AND b.PROPTipo <> 1 THEN ' (' + c.descripcion + ')' ELSE NULL END, '') + ");
                strQuery.Append("isnull(CASE WHEN (b.idTipoInforme=13 OR b.idTipoInforme=3 OR b.idTipoInforme=16 ) THEN ' (' + c.descripcion + ')' ELSE NULL END, '') ");
                strQuery.Append(") as descripcion, ");
                strQuery.Append("ri.precio as precioUnitario, (count(ri.idTipoInforme) * ri.precio) as precioTotal, 1 as orden, ri.idTipoInforme  ");
                strQuery.Append("from CtaCtePartesEntrega ccr  ");
                strQuery.Append("inner join CtaCteMovimientosPartesEntrega ccmr on ccr.nroMovimiento=ccmr.nroMovimiento ");
                strQuery.Append("inner join partesEntrega r on ccmr.nroParte=r.nroParte ");
                strQuery.Append("inner join parteEntregaInforme ri on r.nroParte=ri.nroParte ");
                strQuery.Append("inner join bandejaentrada b on b.idEncabezado=ri.idEncabezado ");
                strQuery.Append("inner join tiposinformes ti on ri.idTipoInforme=ti.idTipoInforme ");
                strQuery.Append("inner join tipopropiedad tp on b.PROPTipo=tp.idTipoPropiedad ");
                strQuery.Append("inner join caracter c on b.caracter=c.idCaracter ");
                strQuery.Append("where ccmr.nroMovimiento=" + NroMovimiento + " ");
                strQuery.Append("and ccr.idCliente=" + idCliente + " ");
                strQuery.Append("group by ri.idTipoInforme, ti.descripcion, ri.precio, b.idTipoInforme, b.PROPTipo, tp.descripcion, c.descripcion ");
                strQuery.Append("union ");
                strQuery.Append("select sum(ra.cantidad), sa.descripcion, ra.precio as precioUnitario, (sum(ra.cantidad)*ra.precio) as precio, 2 as orden, 1000 as idTipoInforme  ");
                strQuery.Append("from CtaCtePartesEntrega ccr  ");
                strQuery.Append("inner join CtaCteMovimientosPartesEntrega ccmr on ccr.nroMovimiento=ccmr.nroMovimiento ");
                strQuery.Append("inner join partesEntrega r on ccmr.nroParte=r.nroParte ");
                strQuery.Append("inner join parteEntregaAdicionales ra on r.nroParte=ra.nroParte ");
                strQuery.Append("inner join serviciosadicionales sa on sa.id=ra.idAdicional ");
                strQuery.Append("where ccmr.nroMovimiento=" + NroMovimiento + " ");
                strQuery.Append("and ccr.idCliente=" + idCliente + " ");
                strQuery.Append("group by sa.descripcion, ra.precio ");
                strQuery.Append("order by orden, ri.idTipoInforme");
            }

            try
            {
                dtSalida = StaticDal.EjecutarDataSet(strQuery.ToString(), "RemitosMovimientoxCliente").Tables[0];
            }
            catch
            {
                throw;
            }
            return dtSalida;
        }


        public static decimal precioTotalRemitosMovimiento(int idTipoDocumento, int NroMovimiento, int idCliente)
        {
            DataTable Datos = GestorPrecios.ListaDetallesRemitosMovimiento(idTipoDocumento, NroMovimiento, idCliente);
            decimal precioTotal = 0;
            for (int i = 0; i < Datos.Rows.Count; i++)
            {
                precioTotal = precioTotal + decimal.Parse(Datos.Rows[i]["precioTotal"].ToString());
            }

            return precioTotal;
        }


        public static DataTable NroRemitosPorMovimiento(int idTipoDocumentacion, int nroMovimiento)
        {

            StringBuilder strQuery = new StringBuilder(512);
            DataTable dtSalida = null;

            if (idTipoDocumentacion == 1)
            {
                strQuery.Append("select nromovimiento, nroRemito from CtaCteMovimientosRemitos ");
                strQuery.Append("where nroMovimiento= " + nroMovimiento + " ");
                strQuery.Append("order by nroRemito");
            }

            if (idTipoDocumentacion == 2)
            {
                strQuery.Append("select nromovimiento, nroParte as nroRemito from CtaCteMovimientosPartesEntrega ");
                strQuery.Append("where nroMovimiento= " + nroMovimiento + " ");
                strQuery.Append("order by nroParte");
            }
            

            try
            {
                dtSalida = StaticDal.EjecutarDataSet(strQuery.ToString(), "RemitosxMovimiento").Tables[0];
            }
            catch
            {
                throw;
            }
            return dtSalida;
        }


        public static string periodoMovimiento(int idTipoDocumentacion, int nroMovimiento)
        {

            StringBuilder strQuery = new StringBuilder(512);
            DataTable dtSalida = null;
            string resultado = "";
            if (idTipoDocumentacion == 1)
            {
                strQuery.Append("select min(r.fecha) as fechaMin, max(rr.fecha) as fechaMax ");
                strQuery.Append("from CtaCteMovimientosRemitos ccmr ");
                strQuery.Append("inner join remitos r on r.nroRemito=ccmr.nroRemito ");
                strQuery.Append("inner join remitos rr on rr.nroRemito=ccmr.nroRemito ");
                strQuery.Append("where ccmr.nroMovimiento= " + nroMovimiento + " ");
            }

            if (idTipoDocumentacion == 2)
            {
                strQuery.Append("select min(r.fecha) as fechaMin, max(rr.fecha) as fechaMax ");
                strQuery.Append("from CtaCteMovimientosPartesEntrega ccmr ");
                strQuery.Append("inner join partesEntrega r on r.nroParte=ccmr.nroParte ");
                strQuery.Append("inner join partesEntrega rr on rr.nroParte=ccmr.nroParte ");
                strQuery.Append("where ccmr.nroMovimiento= " + nroMovimiento + " ");
            }

            try
            {
                dtSalida = StaticDal.EjecutarDataSet(strQuery.ToString(), "RemitosxMovimiento").Tables[0];

                resultado = dtSalida.Rows[0]["fechaMin"].ToString() + "," + dtSalida.Rows[0]["fechaMax"].ToString();
            }
            catch
            {
                throw;
            }
            return resultado;
        }


        public int CrearMovimiento(int idTipoDocumentacion, int idCliente, int idUsuarioIntra)
        {
            int MaxID = 0;
            OdbcConnection oConnection = this.OpenConnection();
            string strSQL = "";
            string strMaxID = "";

            if (idTipoDocumentacion == 1)
            {
                strSQL = strSQL + "Insert into CtaCteRemitos (idCliente, idUsuarioIntra, fecha) ";
                strSQL = strSQL + " values (" + idCliente + ", " + idUsuarioIntra + ", getdate())";

                strMaxID = "SELECT MAX(nroMovimiento) as MaxId FROM CtaCteRemitos";
            }

            if (idTipoDocumentacion == 2)
            {
                strSQL = strSQL + "Insert into CtaCtePartesEntrega (idCliente, idUsuarioIntra, fecha) ";
                strSQL = strSQL + " values (" + idCliente + ", " + idUsuarioIntra + ", getdate())";

                strMaxID = "SELECT MAX(nroMovimiento) as MaxId FROM CtaCtePartesEntrega";
            }

            try
            {
                OdbcCommand myCommand = new OdbcCommand(strSQL, oConnection);
                myCommand.ExecuteNonQuery();

                MaxID = ObtenerMaxID(strMaxID, oConnection);
            }
            catch (Exception e)
            {
                string p = e.Message;
                return MaxID;
            }

            return MaxID;
        }


        public void agregarRemitoParteEntregaMovimiento(int idTipoDocumentacion, int nroMovimiento, int idRemito)
        {
            //int MaxID = 0;
            OdbcConnection oConnection = this.OpenConnection();
            String strSQL = "";

            if (idTipoDocumentacion == 1)
            {
                strSQL = strSQL + "Insert into CtaCteMovimientosRemitos (nroMovimiento, nroRemito) ";
                strSQL = strSQL + " values (" + nroMovimiento + ", " + idRemito + ")";
            }

            if (idTipoDocumentacion == 2)
            {
                strSQL = strSQL + "Insert into CtaCteMovimientosPartesEntrega (nroMovimiento, nroParte) ";
                strSQL = strSQL + " values (" + nroMovimiento + ", " + idRemito + ")";
            }

            //String strMaxID = "SELECT MAX(nroRemito) as MaxId FROM remitos";

            try
            {
                OdbcCommand myCommand = new OdbcCommand(strSQL, oConnection);
                myCommand.ExecuteNonQuery();

                //MaxID = ObtenerMaxID(strMaxID, oConnection);
            }
            catch (Exception e)
            {
                string p = e.Message;
                //return MaxID;
            }

            //return MaxID;
        }

	}
}
