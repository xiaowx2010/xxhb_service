using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SyncService
{
    class SyncData
    {
        private readonly int synchronySecond;
        private bool isRun;
        private Thread syncThread;

        public SyncData(int synchronytime)
        {
            this.synchronySecond = synchronytime;
            isRun = true;
        }

        internal void SyncStart()
        {
            syncThread = new Thread(new ThreadStart(Run));
            syncThread.Start();
        }

        internal void SyncStop()
        {
            isRun = false;
        }

        public void Run() 
        {
            int i = 0;
            while (isRun)
            {
                if (i++ == synchronySecond)
                {
                    Log.WriteLog(DateTime.Now.ToString());
                    SyncUtils su = new SyncUtils();
                    su.SyncOral();
                    su.SyncFTP();
                    i = 0;
                }

                Thread.Sleep(1000);
            }
        }
    }
}
