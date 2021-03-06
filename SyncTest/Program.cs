﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FTPSyncer;
using OralSync;
using System.Configuration;

namespace SyncService
{
    class Program
    {
        static void Main(string[] args)
        {
            //FTPClient c = new FTPClient();
            //string path = @"F:\Download";
            //string file = "40288392430DABFF01432DD48E101F18_正文_3.doc";
            //c.Download(path, file);
            //String mySelectQuery = ConfigurationManager.AppSettings["SQL_SEWAGE"];
            //OracleHelper oh = new OracleHelper(ConfigurationManager.AppSettings["ORAL_CONN"]);
            //oh.ExecuteDataTable(mySelectQuery);
            int time = 60;          // 默认60秒
            if (!int.TryParse(ConfigurationManager.AppSettings["synchronyTime"], out time))
                time = 60;
            SyncData sync;
            sync = new SyncData(time);

            sync.Run();
            //var deadline = DateTime.Now.AddMonths(-5);
            //Console.WriteLine(DateTime.Compare(deadline, DateTime.Now));
        }
    }
}
