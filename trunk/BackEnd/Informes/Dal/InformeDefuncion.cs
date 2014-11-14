using System;
using System.Data;
using System.Data.Odbc;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;

namespace ar.com.TiempoyGestion.BackEnd.Informes.Dal
{
    public class InformeDefuncion : GenericDal
    {
        #region Atributos y Contructores

        private int intIdUsuario;
        private int intEstado;
        private int intIdEncabezado;
        private int intIdTipoInforme;
        private int intIdCliente;
        private string strNombre;
        private string strApellido;
        private string strDocumento;
        private int intSexo;
        private int intFallecido;
        private string strFechaFallecido;
        private string strActa;
        private string strTomo;
        private string strFolio;
        private string strLugarFallecimiento;
        private string strObservaciones;
        
        #endregion

        #region Propiedades

        public int IdCliente
        {
            get
            {
                return intIdCliente;
            }
            set
            {
                intIdCliente = value;
            }
        }

        public int IdUsuario
        {
            get
            {
                return intIdUsuario;
            }
            set
            {
                intIdUsuario = value;
            }
        }

        public int Estado
        {
            get
            {
                return intEstado;
            }
            set
            {
                intEstado = value;
            }
        }

        public int IdEncabezado
        {
            get
            {
                return intIdEncabezado;
            }
            set
            {
                intIdEncabezado = value;
            }
        }

        public int IdTipoInforme
        {
            get
            {
                return intIdTipoInforme;
            }
            set
            {
                intIdTipoInforme = value;
            }
        }

        public string Nombre
        {
            get
            {
                return strNombre;
            }
            set
            {
                strNombre = value;
            }
        }

        public string Apellido
        {
            get
            {
                return strApellido;
            }
            set
            {
                strApellido = value;
            }
        }

        public string Documento
        {
            get
            {
                return strDocumento;
            }
            set
            {
                strDocumento = value;
            }
        }

        public int Sexo
        {
            get
            {
                return intSexo;
            }
            set
            {
                intSexo = value;
            }
        }

        public int Fallecido
        {
            get
            {
                return intFallecido;
            }
            set
            {
                intFallecido = value;
            }
        }

        public string FechaFallecido
        {
            get
            {
                return strFechaFallecido;
            }
            set
            {
                strFechaFallecido = value;
            }
        }

        public string Acta
        {
            get
            {
                return strActa;
            }
            set
            {
                strActa = value;
            }
        }

        public string Tomo
        {
            get
            {
                return strTomo;
            }
            set
            {
                strTomo = value;
            }
        }

        public string Folio
        {
            get
            {
                return strFolio;
            }
            set
            {
                strFolio = value;
            }
        }

        public string LugarFallecimiento
        {
            get
            {
                return strLugarFallecimiento;
            }
            set
            {
                strLugarFallecimiento = value;
            }
        }
        

        public string Observaciones
        {
            get
            {
                return strObservaciones;
            }
            set
            {
                strObservaciones = value;
            }
        }

        

        #endregion

        #region Métodos Publicos

        #region Crear()

        public bool Crear()
        {
            string dtFechaFallecido = "";
            if (strFechaFallecido != "")
            {
                //string[] fechai1 = strFecIngEmpresa1.Split("/".ToCharArray());
                //dtFecIngEmpresa1 = "'" + fechai1[2] + "-" + fechai1[1] + "-" + fechai1[0] + "'";
                dtFechaFallecido = strFechaFallecido;
            }
            
            OdbcConnection oConnection = this.OpenConnection();
            String strSQL = "INSERT INTO InformePartidaDefuncion (idInforme, Nombre, Apellido, NroDoc, Sexo, Fallecido, FechaFallecido, Acta, Tomo, Folio, LugarFallecimiento,observaciones) ";
            strSQL = strSQL + " VALUES (" + intIdEncabezado + ", '" + strNombre + "','" + strApellido + "', " + strDocumento + ", " + intSexo + ", " + intFallecido + ", '" + strFechaFallecido + "'";
            strSQL = strSQL + ",'" + strActa + "','" + strTomo + "','" + strFolio + "','" + strLugarFallecimiento + "','" + strObservaciones + "')";

            String strMaxID = "SELECT MAX(idInforme) as MaxId FROM InformePartidaDefuncion";
            //System.Console.Out.WriteLine(strSQL);
            try
            {
                OdbcCommand myCommand = new OdbcCommand(strSQL, oConnection);
                myCommand.ExecuteNonQuery();

                int MaxID = ObtenerMaxID(strMaxID, oConnection);

                String strAuditoria = "INSERT INTO HistoricoAcciones (idCliente, idUsuario, Instante, Evento, Observaciones, idTipoObjeto, idEstado, idReferencia) VALUES (";
                strAuditoria = strAuditoria + intIdCliente + "," + intIdUsuario + ", getdate(), 'Creación de Informe', 'Solicitud de Informe', 1" + ", 1," + MaxID.ToString() + ")";

                myCommand = new OdbcCommand(strAuditoria, oConnection);
                myCommand.ExecuteNonQuery();
                oConnection.Close();
            }
            catch (Exception e)
            {
                string p = e.Message;
                return false;
            }
            return true;
        }

        #endregion

        #region Modificar(int idInforme)

        public bool Modificar(int idInforme)
        {
            string dtFechaFallecido = "";
            if (strFechaFallecido != "")
            {
                //string[] fechai1 = strFecIngEmpresa1.Split("/".ToCharArray());
                //dtFecIngEmpresa1 = "'" + fechai1[2] + "-" + fechai1[1] + "-" + fechai1[0] + "'";
                dtFechaFallecido = strFechaFallecido;
            }
            
            OdbcConnection oConnection = this.OpenConnection();
            String strSQL = "UPDATE InformePartidaDefuncion SET ";
            strSQL = strSQL + "Nombre = '" + strNombre + "',";
            strSQL = strSQL + "Apellido = '" + strApellido +"',";
            strSQL = strSQL + "NroDoc = " + strDocumento + ",";
            strSQL = strSQL + "Sexo = " + intSexo +",";
            strSQL = strSQL + "Fallecido = " + intFallecido +",";
            if(dtFechaFallecido != "")
                strSQL = strSQL + "FechaFallecido = '" + dtFechaFallecido +"',";
            else
                strSQL = strSQL + "FechaFallecido = NULL,";

            strSQL = strSQL + "Acta = '" + strActa +"',";
            strSQL = strSQL + "Tomo = '" + strTomo +"',";
            strSQL = strSQL + "Folio = '" + strFolio +"',";
            strSQL = strSQL + "LugarFallecimiento = '" + strLugarFallecimiento +"',";
            strSQL = strSQL + "observaciones = '" + strObservaciones +"'";
            strSQL = strSQL + " WHERE idInforme =  " + idInforme.ToString();
            try
            {
                OdbcCommand myCommand = new OdbcCommand(strSQL, oConnection);
                myCommand.ExecuteNonQuery();

                int MaxID = idInforme;

                String strAuditoria = "INSERT INTO HistoricoAcciones (idCliente, idUsuario, Instante, Evento, Observaciones, idTipoObjeto, idEstado, idReferencia) VALUES (";
                strAuditoria = strAuditoria + intIdCliente + "," + intIdUsuario + ", getdate(), 'Modificación de Informe', 'Modificación de Informe', 1" + ", 5," + MaxID.ToString() + ")";

                myCommand = new OdbcCommand(strAuditoria, oConnection);
                myCommand.ExecuteNonQuery();
                oConnection.Close();
            }
            catch (Exception e)
            {
                string p = e.Message;
                return false;
            }
            return true;
        }

        #endregion

        #region Cargar(int idInforme)

        public bool Cargar(int idInforme)
        {

            OdbcConnection oConnection = this.OpenConnection();
            DataSet ds = new DataSet();
            String strSQL = "SELECT * FROM InformePartidaDefuncion ";
            strSQL = strSQL + "WHERE idInforme = " + idInforme.ToString();
            OdbcDataAdapter myConsulta = new OdbcDataAdapter(strSQL, oConnection);
            myConsulta.Fill(ds);
            try
            {
                oConnection.Close();
            }
            catch
            {
                return false;
            }

            if (ds.Tables[0].Rows.Count == 0)
                return false;

            intIdEncabezado = int.Parse(ds.Tables[0].Rows[0]["IdInforme"].ToString());
            strNombre = ds.Tables[0].Rows[0]["Nombre"].ToString();
            strApellido = ds.Tables[0].Rows[0]["Apellido"].ToString();
            strDocumento = ds.Tables[0].Rows[0]["NroDoc"].ToString();
            intSexo = int.Parse(ds.Tables[0].Rows[0]["Sexo"].ToString());
            intFallecido = int.Parse(ds.Tables[0].Rows[0]["Fallecido"].ToString());
            strFechaFallecido = ds.Tables[0].Rows[0]["FechaFallecido"].ToString();
            strActa = ds.Tables[0].Rows[0]["Acta"].ToString();
            strTomo = ds.Tables[0].Rows[0]["Tomo"].ToString();
            strFolio = ds.Tables[0].Rows[0]["Folio"].ToString();
            strLugarFallecimiento = ds.Tables[0].Rows[0]["LugarFallecimiento"].ToString();
            strObservaciones = ds.Tables[0].Rows[0]["observaciones"].ToString();

            return true;
        }

        #endregion

        #region TraerCampo(int tipo)

        public DataTable TraerCampo(int tipo)
        {
            OdbcConnection oConnection = this.OpenConnection();
            DataSet ds = new DataSet();
            OdbcDataAdapter myConsulta = new OdbcDataAdapter("select id, descripcion from Campo Where idGrupo = " + tipo + "", oConnection);
            myConsulta.Fill(ds);
            try
            {
                oConnection.Close();
            }
            catch { }

            return ds.Tables[0];
        }

        #endregion

        #endregion

        #region Métodos Privados

        #region ObtenerMaxID(string strMaxID, OdbcConnection oConnection)

        private int ObtenerMaxID(string strMaxID, OdbcConnection oConnection)
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

        #endregion

        #endregion
    }

}

