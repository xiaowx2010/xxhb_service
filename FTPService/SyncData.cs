using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Configuration;

namespace SyncService
{
    public class SyncData
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
#if DEBUG
            Run();
#else
            syncThread = new Thread(new ThreadStart(Run));
            syncThread.Start();
#endif
        }

        internal void SyncStop()
        {
            isRun = false;
        }

        public void Run() 
        {
            int i = 0;
            string conn = ConfigurationManager.AppSettings["ORAL_CONN"];
            Sync(conn);
            while (isRun)
            {
                if (i++ == synchronySecond)
                {
                    Sync(conn);
                    i = 0;
                }

                Thread.Sleep(1000);
            }
        }
        private void Sync(string conn)
        {
            try
            {
                Log.WriteLog("Sync Start.");
                SyncUtils su = new SyncUtils(conn);
                su.SyncOral();
                su.SyncFTP();
                Log.WriteLog("Sync End.");
            }
            catch (Exception ex)
            {

                Log.WriteLog("Sync Error. \n"+ex.Message);
            }
        }
    }
}
