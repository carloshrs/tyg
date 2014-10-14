using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using ar.com.TiempoyGestion.BackEnd.ImportadorFox.Dal;


namespace ar.com.TiempoyGestion.synchService.Sincronizador
{
    public delegate void CallBackEventHandler(object sender);

    class Sincronizador
    {
        #region Atributos y constructores

        private string DBF_ConnectionString;
        public event CallBackEventHandler CallBack;

        public Sincronizador(String dbfcs)
        {
            DBF_ConnectionString = dbfcs;
        }

        #endregion

        #region Metodos publicos
        
        public void SincronizarRegistros()
        {
            Importador imp = new Importador();
            try
            {
                imp.ImportarBase(DBF_ConnectionString, false);
            }
            catch (Exception exc)
            {
                EventLog.WriteEntry("TyG-SynchService", "Error al ejecutar sincronización " + exc.StackTrace, EventLogEntryType.Error);
            }
            OnCallBack();
        }

        #endregion

        #region Metodos protegidos
        protected virtual void OnCallBack()
        {
            if (CallBack != null)
                CallBack(this);
        }
        #endregion
    }
}
