namespace SyncService
{
    partial class SyncInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.serviceProcessInstaller1 = new System.ServiceProcess.ServiceProcessInstaller();
            this.serviceInstaller1 = new System.ServiceProcess.ServiceInstaller();
            // 
            // serviceProcessInstaller1
            // 
            this.serviceProcessInstaller1.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.serviceProcessInstaller1.Password = null;
            this.serviceProcessInstaller1.Username = null;
            this.serviceProcessInstaller1.AfterInstall += new System.Configuration.Install.InstallEventHandler(this.FTPInstaller_AfterInstall);
            this.serviceProcessInstaller1.BeforeUninstall += new System.Configuration.Install.InstallEventHandler(this.FTPInstaller_BeforeUninstall);
            // 
            // serviceInstaller1
            // 
            this.serviceInstaller1.Description = "用于同步环保市局前置库的服务";
            this.serviceInstaller1.DisplayName = "SynchronyService";
            this.serviceInstaller1.ServiceName = "SynchronyService";
            this.serviceInstaller1.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            this.serviceInstaller1.AfterInstall += new System.Configuration.Install.InstallEventHandler(this.FTPInstaller_AfterInstall);
            this.serviceInstaller1.BeforeUninstall += new System.Configuration.Install.InstallEventHandler(this.FTPInstaller_BeforeUninstall);
            // 
            // FTPInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.serviceProcessInstaller1,
            this.serviceInstaller1});
            this.AfterInstall += new System.Configuration.Install.InstallEventHandler(this.FTPInstaller_AfterInstall);
            this.BeforeUninstall += new System.Configuration.Install.InstallEventHandler(this.FTPInstaller_BeforeUninstall);

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller serviceProcessInstaller1;
        private System.ServiceProcess.ServiceInstaller serviceInstaller1;
    }
}