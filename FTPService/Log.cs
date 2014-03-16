using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace SyncService
{
    class Log
    {
        #region 静态写日志函数

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="logMessage">日志信息</param>
        public static void WriteLog(string logMessage)
        {
            try
            {
                string logFullPath = string.Format(@"{0}{1}{2}.dat", AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "Log" + "\\", "SynchronySiteViewService", // Log日志路径
                    DateTime.Today.Year.ToString()
                    + (DateTime.Today.Month.ToString()).PadLeft(2, '0')
                    + (DateTime.Today.Day.ToString()).PadLeft(2, '0')
                    );
                logMessage = DateTime.Now.ToString() + "\t" + logMessage;
                using (StreamWriter streamWriter = new StreamWriter(logFullPath, true, System.Text.Encoding.Default))
                {
                    streamWriter.WriteLine(logMessage);
                }
            }
            catch
            {
            }
        }
        #endregion
    }
}
