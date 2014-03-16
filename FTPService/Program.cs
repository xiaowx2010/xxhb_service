using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.IO;

namespace SyncService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            string path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "Log";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }


            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
			{ 
				new MainService() 
			};
            ServiceBase.Run(ServicesToRun);
        }
    }
}
