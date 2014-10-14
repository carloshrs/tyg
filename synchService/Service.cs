using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Timers;
using Timer = System.Timers.Timer;
using System.Configuration;
using ar.com.TiempoyGestion.synchService.Sincronizador;

namespace ar.com.TiempoyGestion.synchService
{
    public partial class Service : ServiceBase
    {
        //Reloj que controla el periodo de verificacion
        private Timer timUpdater;

        //periodo inicial del reloj
        private static int _INICIAL_INTERVAL = 50000;//cada 5 segundos y luego segun configuracion

        public Service()
        {
            InitializeComponent();

            timUpdater = new Timer();
            timUpdater.Interval = _INICIAL_INTERVAL;
            timUpdater.Elapsed += new ElapsedEventHandler(timUpdater_Elapsed);
        }

        protected override void OnStart(string[] args)
        {

            timUpdater.Start();
            EventLog.WriteEntry("TyG-SynchService", "Servicio iniciado", EventLogEntryType.Information);
        }

        protected override void OnStop()
        {
            timUpdater.Stop();

            EventLog.WriteEntry("TyG-SynchService", "Servicio detenido", EventLogEntryType.Information);
        }

        private void timUpdater_Elapsed(object sender, ElapsedEventArgs e)
        {
            EventLog.WriteEntry("TyG-SynchService", "Iniciando sincronizacion de registros", EventLogEntryType.Information);
            timUpdater.Stop();
            if (timUpdater.Interval == _INICIAL_INTERVAL)
            {
                int wAux;
                try
                {
                    wAux = int.Parse(System.Configuration.ConfigurationSettings.AppSettings["DelayInterval"]);
                    timUpdater.Interval = wAux;
                }
                catch
                {
                    EventLog.WriteEntry("TyG-SynchService", "Error al interntar obtener el intervalo de activación", EventLogEntryType.Error);
                    timUpdater.Interval = 30000;
                }

            }
            //Corro el sincronizador
            try
            {
                Thread proceso;
                Sincronizador.Sincronizador sinc = new Sincronizador.Sincronizador(System.Configuration.ConfigurationSettings.AppSettings["OLEDBFoxPro"]);
                sinc.CallBack += new CallBackEventHandler(sincronizado_CallBack);
                proceso = new Thread(new ThreadStart(sinc.SincronizarRegistros));
                proceso.Start();
            }
            catch (Exception exc)
            {
                EventLog.WriteEntry("TyG-SynchService", "Error al ejecutar sincronización " + exc.StackTrace, EventLogEntryType.Error);
            }
        }

        private void sincronizado_CallBack(object sender)
        {
            EventLog.WriteEntry("TyG-SynchService", "Sincronización finalizada", EventLogEntryType.Information);
            timUpdater.Start();
        }
    }
}
