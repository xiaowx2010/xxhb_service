using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Diagnostics;


namespace SyncService
{
    [RunInstaller(true)]
    public partial class SyncInstaller : System.Configuration.Install.Installer
    {
        private Process p = new Process();
        public SyncInstaller()
        {
            InitializeComponent();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
        }

        private void FTPInstaller_AfterInstall(object sender, InstallEventArgs e)
        {
            string Cmdstring = "sc start SynchronyService"; //CMD命令
            p.StandardInput.WriteLine(Cmdstring);
            p.StandardInput.WriteLine("exit");
        }

        private void FTPInstaller_BeforeUninstall(object sender, InstallEventArgs e)
        {
            string Cmdstring = "sc stop SynchronyService"; //CMD命令
            p.StandardInput.WriteLine(Cmdstring);
            p.StandardInput.WriteLine("exit");
        }
    }
}
