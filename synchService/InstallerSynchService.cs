using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

namespace ar.com.TiempoyGestion.synchService
{
    [RunInstaller(true)]
    public partial class InstallerSynchService : Installer
    {
        private ServiceInstaller srvInstaller = new ServiceInstaller();
        private ServiceProcessInstaller procInstaller = new ServiceProcessInstaller();

        public InstallerSynchService()
        {
            procInstaller.Account = ServiceAccount.LocalSystem;
            srvInstaller.StartType = ServiceStartMode.Manual;
            srvInstaller.DisplayName = "Sincronizador FOX-WEB TyG";
            srvInstaller.ServiceName = "TyG-SynchServiceFox";
            Installers.Add(srvInstaller);
            Installers.Add(procInstaller);
            InitializeComponent();

        }
    }
}