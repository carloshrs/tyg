using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Odbc;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;
using System.Diagnostics;

namespace ar.com.TiempoyGestion.BackEnd.ImportadorFox.Dal
{
    public class Importador : GenericDal
    {
        #region Atributos y Contructores

        public static string TIPOINFORME = "T_INF";
        public static string ESTADOINFORME = "E_INF";
        public static string TIPODOCUMENTO = "T_DOC";

        private string strResultado;
        private int intIdSolicitudes;
        private int intCantSolicitudes;
        private int intIdAutomotor;
        private int intCantAutomotor;
        private int intIdPropiedad;
        private int intCantPropiedad;
        private int intIdVParticular;
        private int intCantVParticular;
        private int intIdVComercial;
        private int intCantVComercial;
        private int intIdVLaboral;
        private int intCantVLaboral;
        private int intIdCliente;
        private int intCantCliente;
        private string strLog; 

        #endregion

        public Importador()
        {
        }

        #region Propiedades

        public string Resultado
        {
            get
            {
                return strResultado;
            }
            set
            {
                strResultado = value;
            }
        }

        public int IdSolicitudes
        {
            get
            {
                return intIdSolicitudes;
            }
            set
            {
                intIdSolicitudes = value;
            }
        }

        public int CantSolicitudes
        {
            get
            {
                return intCantSolicitudes;
            }
            set
            {
                intCantSolicitudes = value;
            }
        }

        public int IdAutomotor
        {
            get
            {
                return intIdAutomotor;
            }
            set
            {
                intIdAutomotor = value;
            }
        }

        public int CantAutomotor
        {
            get
            {
                return intCantAutomotor;
            }
            set
            {
                intCantAutomotor = value;
            }
        }

        public int IdPropiedad
        {
            get
            {
                return intIdPropiedad;
            }
            set
            {
                intIdPropiedad = value;
            }
        }

        public int CantPropiedad
        {
            get
            {
                return intCantPropiedad;
            }
            set
            {
                intCantPropiedad = value;
            }
        }

        public int IdVParticular
        {
            get
            {
                return intIdVParticular;
            }
            set
            {
                intIdVParticular = value;
            }
        }

        public int CantVParticular
        {
            get
            {
                return intCantVParticular;
            }
            set
            {
                intCantVParticular = value;
            }
        }

        public int IdVComercial
        {
            get
            {
                return intIdVComercial;
            }
            set
            {
                intIdVComercial = value;
            }
        }

        public int CantVComercial
        {
            get
            {
                return intCantVComercial;
            }
            set
            {
                intCantVComercial = value;
            }
        }

        public int IdVLaboral
        {
            get
            {
                return intIdVLaboral;
            }
            set
            {
                intIdVLaboral = value;
            }
        }

        public int CantVLaboral
        {
            get
            {
                return intCantVLaboral;
            }
            set
            {
                intCantVLaboral = value;
            }
        }

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

        public int CantCliente
        {
            get
            {
                return intCantCliente;
            }
            set
            {
                intCantCliente = value;
            }
        }

        public string Log
        {
            get
            {
                return strLog;
            }
            set
            {
                strLog = value;
            }
        }

        #endregion

        #region Metodos públicos

        public void ImportarBase(string odbcString, bool desdeCero)
        {
            //Leo los datos de la última importación
            cargar();
            this.Resultado = "";
            this.Log = "";
            //Importo solicitudes
            Solicitud solic = new Solicitud(odbcString);
            solic.ImportarRegistros(this, desdeCero);

            //Guardo los datos de la importación.
            crear();
        }

        public bool crear()
        {
            String strSQL = "INSERT INTO imp_registro (fecha,resultado,id_solicitudes,cant_solicitudes,id_automotor,cant_automotor,id_propiedad,cant_propiedad,id_vParticular,cant_vParticular,id_vComercial,cant_vComercial,id_vLaboral,cant_vLaboral,log,id_cliente, cant_cliente) VALUES(";
            strSQL = strSQL + "getdate(),'" + Resultado + "','" + IdSolicitudes + "','" + CantSolicitudes + "','" + IdAutomotor + "','" + CantAutomotor + "','" + IdPropiedad + "','" + CantPropiedad + "','" + IdVParticular + "','" + CantVParticular + "','" + IdVComercial + "','" + CantVComercial + "','" + IdVLaboral + "','" + CantVLaboral + "','" + Log.Replace("'", "´") + "', '" + IdCliente + "','" + CantCliente + "')";
            try
            {
                OdbcConnection oConnection = this.OpenConnection();
                OdbcCommand myCommand = new OdbcCommand(strSQL, oConnection);
                myCommand.ExecuteNonQuery();
                oConnection.Close();
            } 			
            catch (Exception e)
            {
                EventLog.WriteEntry("TyG-SynchService", "Ocurrió un error al guardar datos de la importación: " + e.Message + "\n-----------------------\n" + e.StackTrace + "\n-----------------------\n" + strSQL, EventLogEntryType.Error);
                return false;
            }
            return true;
        }

        public bool cargar()
        {
            OdbcConnection oConnection = this.OpenConnection();
            DataSet ds = new DataSet();
            string strSQL = "SELECT TOP 1 * FROM imp_registro ORDER BY fecha DESC"; //LIMIT 1
            OdbcDataAdapter myConsulta = new OdbcDataAdapter(strSQL, oConnection);
            myConsulta.Fill(ds);
            try
            {
                oConnection.Close();
            }
            catch( Exception e )
            {
                EventLog.WriteEntry("TyG-SynchService", "Ocurrió un error al cargar datos de la importación: " + e.Message + "\n-----------------------\n" + e.StackTrace, EventLogEntryType.Error);
                return false;
            }

            if (ds.Tables[0].Rows.Count == 0)
                return false;

            strResultado = ds.Tables[0].Rows[0]["resultado"].ToString();
            strLog = ds.Tables[0].Rows[0]["log"].ToString();
            if (ds.Tables[0].Rows[0]["id_solicitudes"].ToString() != "")
            {
                intIdSolicitudes = int.Parse(ds.Tables[0].Rows[0]["id_solicitudes"].ToString());
                intCantSolicitudes = int.Parse(ds.Tables[0].Rows[0]["cant_solicitudes"].ToString());
                intIdAutomotor = int.Parse(ds.Tables[0].Rows[0]["id_automotor"].ToString());
                intCantAutomotor = int.Parse(ds.Tables[0].Rows[0]["cant_automotor"].ToString());
                intIdPropiedad = int.Parse(ds.Tables[0].Rows[0]["id_propiedad"].ToString());
                intCantPropiedad = int.Parse(ds.Tables[0].Rows[0]["cant_propiedad"].ToString());
                intIdVParticular = int.Parse(ds.Tables[0].Rows[0]["id_vParticular"].ToString());
                intCantVParticular = int.Parse(ds.Tables[0].Rows[0]["cant_vParticular"].ToString());
                intIdVComercial = int.Parse(ds.Tables[0].Rows[0]["id_vComercial"].ToString());
                intCantVComercial = int.Parse(ds.Tables[0].Rows[0]["cant_vComercial"].ToString());
                intIdVLaboral = int.Parse(ds.Tables[0].Rows[0]["id_vLaboral"].ToString());
                intCantVLaboral = int.Parse(ds.Tables[0].Rows[0]["cant_vLaboral"].ToString());
                intIdCliente = int.Parse(ds.Tables[0].Rows[0]["id_cliente"].ToString());
                intCantCliente = int.Parse(ds.Tables[0].Rows[0]["cant_cliente"].ToString());
            }
            return true;
        }

        public string GetIdHomologado(string idFOX, string tipo)
        {
            string sql = "SELECT id_web FROM imp_homologacion WHERE tipo LIKE '" + tipo + "' AND id_fox LIKE '" + idFOX + "'";
            IDataReader dr = EjecutarDataReader(sql);
            string resultado = "";
            if (dr.Read() && !dr.IsDBNull(0))
                resultado = dr.GetString(0);
            dr.Close();
            return resultado;
        }
        #endregion
    }
}
