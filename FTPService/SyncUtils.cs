using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OralSync;
using FTPSyncer;
using System.Data;
using System.Configuration;

namespace SyncService
{
    class SyncUtils
    {

        internal void SyncOral()
        {
            SyncXXGK();
            SyncSEWAGE();
            SyncWWAIR();
            SyncWWATER();
        }

        private void SyncWWATER()
        {
            throw new NotImplementedException();
        }

        private void SyncWWAIR()
        {
            throw new NotImplementedException();
        }

        private void SyncSEWAGE()
        {
            throw new NotImplementedException();
        }

        private void SyncXXGK()
        {
            string sql = ConfigurationManager.AppSettings["SQL_XXGK"];
            DataTable dt = OracleHelper.ExecuteDataTable(
            throw new NotImplementedException();
        }

        internal void SyncFTP()
        {
            throw new NotImplementedException();
        }
    }
}

