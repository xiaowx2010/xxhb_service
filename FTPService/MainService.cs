using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Configuration;

namespace SyncService
{
    public partial class MainService : ServiceBase
    {
        SyncData sync;
        public MainService()
        {
            InitializeComponent();
            int time = 60;          // 默认60秒
            if (!int.TryParse(ConfigurationManager.AppSettings["synchronyTime"], out time))
                time = 60;

            sync = new SyncData(time);
        }

        protected override void OnStart(string[] args)
        {
            sync.SyncStart();
        }

        protected override void OnStop()
        {
            sync.SyncStop();
        }
    }
}
