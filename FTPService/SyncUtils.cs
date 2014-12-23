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
        OracleHelper oh;
        internal SyncUtils(string oracleconn)
        {
            oh = new OracleHelper(oracleconn);
        }
        internal void SyncOral()
        {
            SyncXXGK();
            SyncSEWAGE();
            SyncWWAIR();
            SyncWWATER();
        }

        private void SyncWWATER()
        {
            Log.WriteLog("SyncWWATER start.");
            try
            {
                string sql = ConfigurationManager.AppSettings["SQL_WWATER"];
                DataTable wwater_dt = oh.ExecuteDataTable(sql);
                if (wwater_dt.Rows.Count > 0)
                {
                    using (SyncObjectsDataContext db = new SyncObjectsDataContext())
                    {
                        var water_ids = (from water in db.sync_wwater select water.id).ToList<int?>();

                        var results = from myRow in wwater_dt.AsEnumerable().SkipWhile(row => water_ids.Contains((int?)row.Field<decimal>("id"))) select myRow;
                        List<sync_wwater> waterlist = new List<sync_wwater>();
                        results.ToList().ForEach(row =>
                        {
                            sync_wwater water = new sync_wwater();
                            water.id = (int?)row.Field<decimal>("id");
                            water.entName = row.Field<string>("entName");
                            water.portName = row.Field<string>("portName");
                            water.monitorTime = row.Field<DateTime>("monitorTime");
                            water.flow = row.Field<decimal>("flow");
                            water.factorName = row.Field<string>("factorName");
                            water.factorValue = row.Field<decimal>("factorValue");
                            water.standard = row.Field<string>("standard");
                            water.district = row.Field<string>("district");
                            water.enterName = row.Field<string>("enterName");
                            water.entType = row.Field<string>("entType");
                            water.manageType = row.Field<string>("manageType");
                            water.syncDate = DateTime.Now;
                            waterlist.Add(water);
                        });

                        if (waterlist.Count > 0)
                        {
                            db.sync_wwater.InsertAllOnSubmit<sync_wwater>(waterlist);
                            db.SubmitChanges();
                            Log.WriteLog("SyncWWATER success, count:" + waterlist.Count + ".");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog("SyncWWater Error \n" + ex.Message);
            }
        }

        private void SyncWWAIR()
        {
            Log.WriteLog("SyncWWAIR start.");
            try
            {
                string sql = ConfigurationManager.AppSettings["SQL_Wair"];
                DataTable wair_dt = oh.ExecuteDataTable(sql);
                if (wair_dt.Rows.Count > 0)
                {
                    using (SyncObjectsDataContext db = new SyncObjectsDataContext())
                    {
                        var air_ids = (from air in db.sync_wair select air.id).ToList<int?>();

                        var results = from myRow in wair_dt.AsEnumerable().SkipWhile(row => air_ids.Contains((int?)row.Field<decimal>("id"))) select myRow;
                        List<sync_wair> airlist = new List<sync_wair>();
                        results.ToList().ForEach(row =>
                        {
                            sync_wair air = new sync_wair();
                            air.id = (int?)row.Field<decimal>("id");
                            air.entName = row.Field<string>("entName");
                            air.portName = row.Field<string>("portName");
                            air.monitorTime = row.Field<DateTime>("monitorTime");
                            air.flow = row.Field<decimal>("flow");
                            air.factorName = row.Field<string>("factorName");
                            air.factorValue = row.Field<decimal>("factorValue");
                            air.standard = row.Field<string>("standard");
                            air.district = row.Field<string>("district");
                            air.enterName = row.Field<string>("enterName");
                            air.entType = row.Field<string>("entType");
                            air.manageType = row.Field<string>("manageType");
                            air.syncDate = DateTime.Now;
                            airlist.Add(air);
                        });

                        if (airlist.Count > 0)
                        {
                            db.sync_wair.InsertAllOnSubmit<sync_wair>(airlist);
                            db.SubmitChanges();
                            Log.WriteLog("SyncWair success, count:" + airlist.Count + ".");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog("SyncWair Error \n" + ex.Message);
            }
        }

        private void SyncSEWAGE()
        {
            Log.WriteLog("SyncSEWAGE start.");
            try
            {
                string sql = ConfigurationManager.AppSettings["SQL_SEWAGE"];
                DataTable sewage_dt = oh.ExecuteDataTable(sql);
                if (sewage_dt.Rows.Count > 0)
                {
                    using (SyncObjectsDataContext db = new SyncObjectsDataContext())
                    {
                        var sewage_ids = (from sewage in db.sync_sewage select sewage.id).ToList<int?>();

                        var results = from myRow in sewage_dt.AsEnumerable().SkipWhile(row => sewage_ids.Contains((int?)row.Field<decimal>("id"))) select myRow;
                        List<sync_sewage> sewagelist = new List<sync_sewage>();
                        results.ToList().ForEach(row =>
                        {
                            sync_sewage sewage = new sync_sewage();
                            sewage.id = (int?)row.Field<decimal>("id");
                            sewage.entName = row.Field<string>("entName");
                            sewage.portName = row.Field<string>("portName");
                            sewage.monitorTime = row.Field<DateTime>("monitorTime");
                            sewage.flow = row.Field<decimal>("flow");
                            sewage.factorName = row.Field<string>("factorName");
                            sewage.factorValue = row.Field<decimal>("factorValue");
                            sewage.standard = row.Field<string>("standard");
                            sewage.district = row.Field<string>("district");
                            sewage.enterName = row.Field<string>("enterName");
                            sewage.entType = row.Field<string>("entType");
                            sewage.manageType = row.Field<string>("manageType");
                            sewage.syncDate = DateTime.Now;
                            sewagelist.Add(sewage);
                        });

                        if (sewagelist.Count > 0)
                        {
                            db.sync_sewage.InsertAllOnSubmit<sync_sewage>(sewagelist);
                            db.SubmitChanges();
                            Log.WriteLog("Syncsewage success, count:" + sewagelist.Count + ".");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog("SyncSEWAGE Error\n"+ex.Message);
            }
        }
        private void SetValue(sync_xxgk xxgk, DataRow row)
        {
            xxgk.WF_SYSID = row.Field<string>("WF_SYSID");
            xxgk.WF_CASEID = row.Field<string>("WF_CASEID");
            xxgk.APPLYITEM = row.Field<string>("APPLYITEM");
            xxgk.GONGSHITYPE = row.Field<string>("GONGSHITYPE");
            xxgk.GONGSHIBEGINDATE = row.Field<DateTime?>("GONGSHIBEGINDATE");
            xxgk.GONGSHIENDDATE = row.Field<DateTime?>("GONGSHIENDDATE");
            xxgk.ITEMNO = row.Field<string>("ITEMNO");
            xxgk.SUBJECT = row.Field<string>("SUBJECT");
            xxgk.ADDRESS = row.Field<string>("ADDRESS");
            xxgk.BUILDERUNIT = row.Field<string>("BUILDERUNIT");
            xxgk.HPUNIT = row.Field<string>("HPUNIT");
            xxgk.HPCHECKACCEPTUNIT = row.Field<string>("HPCHECKACCEPTUNIT");
            xxgk.COMPOSEDATE = row.Field<DateTime?>("COMPOSEDATE");
            xxgk.PIWENNAME = row.Field<string>("PIWENNAME");
            xxgk.PIWNENO = row.Field<string>("PIWNENO");
            xxgk.PIWENDATE = row.Field<DateTime?>("PIWENDATE");
            xxgk.SHENPIJD = row.Field<string>("SHENPIJD");
            xxgk.APPROVTYPE = row.Field<string>("APPROVTYPE");
            xxgk.YUANYIN = row.Field<string>("YUANYIN");
            xxgk.CANYUQINGKUANG = row.Field<string>("CANYUQINGKUANG");
            xxgk.ATTACH_1 = row.Field<string>("ATTACH_1");
            xxgk.ATTACH_2 = row.Field<string>("ATTACH_2");
            xxgk.ATTACH_3 = row.Field<string>("ATTACH_3");
            xxgk.ATTACH_4 = row.Field<string>("ATTACH_4");
            xxgk.PRJPROFILE = row.Field<string>("PRJPROFILE");
            xxgk.PRJCS = row.Field<string>("PRJCS");
            xxgk.ATTACH_5 = row.Field<string>("ATTACH_5");
            xxgk.APPROVEUNIT = row.Field<string>("APPROVEUNIT");
            xxgk.PRJCN = row.Field<string>("PRJCN");
            xxgk.OPETIME = row.Field<DateTime?>("OPETIME");
            xxgk.ISDOWNLOAD = false;
            xxgk.syncDate = DateTime.Now;
        }
        private void SyncXXGK()
        {
            Log.WriteLog("SyncXXGK start.");
            try
            {
                string sql = ConfigurationManager.AppSettings["SQL_XXGK"];
                DataTable xxgk_dt = oh.ExecuteDataTable(sql);
                if (xxgk_dt.Rows.Count > 0)
                {
                    using (SyncObjectsDataContext db = new SyncObjectsDataContext())
                    {
                        var c = xxgk_dt.AsEnumerable().ToList<DataRow>();
                        List<sync_xxgk> newitems = new List<sync_xxgk>();
                        var localdata = (from l in db.sync_xxgk where DateTime.Compare(l.syncDate.AddMonths(+5), DateTime.Now) > 0 select l).ToList<sync_xxgk>();
                        int i = 0;
                        c.ForEach(row =>
                        { 
                            try
                            {

                                var xxgk = localdata.FirstOrDefault<sync_xxgk>(sync_xxgk => sync_xxgk.WF_SYSID == row.Field<string>("WF_SYSID"));
                                if (xxgk == null)
                                {
                                    sync_xxgk new_xxgk = new sync_xxgk();
                                    SetValue(new_xxgk, row);
                                    newitems.Add(new_xxgk);
                                    db.sync_xxgk.InsertOnSubmit(new_xxgk);
                                }
                                else if (xxgk.OPETIME != row.Field<DateTime?>("OPETIME"))
                                {
                                    SetValue(xxgk, row);
                                    i++;
                                }
                                db.SubmitChanges();
                            }
                            catch (Exception ex)
                            {
                                db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues);
                                Log.WriteLog(string.Format("SyncXXGK row Error:{1}\n{0}", ex.Message, row.Field<string>("WF_SYSID")));
                            }
                        });
                        if (newitems.Count > 0)
                        {
                            db.sync_xxgk.InsertAllOnSubmit<sync_xxgk>(newitems);
                            Log.WriteLog("SyncXXGK success, new count:" + newitems.Count + ".");
                        }
                        if(i>0)
                            Log.WriteLog("SyncXXGK success, edit count:" + i + ".");
                       
                    }
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(string.Format("SyncXXGK Error\n{0}" , ex.Message));
            }
            
        }
        private bool DownLoad(string filename, string path, FTPClient fc)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(filename))
                    fc.Download(path, filename);
                return true;
            }
            catch (Exception ex)
            {

                Log.WriteLog(string.Format("DownLoad Error.filename:{0},path:{1}\n{2}", filename, path, ex.Message));
                return false;
            }

        }
        internal void SyncFTP()
        {
            Log.WriteLog("SyncFTP start.");
            try
            {
                using (SyncObjectsDataContext db = new SyncObjectsDataContext())
                {
                    var not_download = (from l in db.sync_xxgk where !l.ISDOWNLOAD select l).ToList<sync_xxgk>();
                    if (not_download.Count > 0)
                    {

                        string IP = ConfigurationManager.AppSettings["FTP_IP"];
                        string UserID = ConfigurationManager.AppSettings["FTP_USERID"];
                        string Password = ConfigurationManager.AppSettings["FTP_PWD"];
                        string DownLoadTo = ConfigurationManager.AppSettings["FTP_ADDR"];
                        FTPClient fc = new FTPClient(IP, UserID, Password);
                        not_download.ForEach(xxgk =>
                        {
                            //DownLoad(xxgk.ATTACH_1, DownLoadTo, fc);
                            //DownLoad(xxgk.ATTACH_2, DownLoadTo, fc);
                            //DownLoad(xxgk.ATTACH_3, DownLoadTo, fc);
                            //DownLoad(xxgk.ATTACH_4, DownLoadTo, fc);
                            //DownLoad(xxgk.ATTACH_5, DownLoadTo, fc);
                            bool download_success = (DownLoad(xxgk.ATTACH_1, DownLoadTo, fc) & DownLoad(xxgk.ATTACH_2, DownLoadTo, fc) & DownLoad(xxgk.ATTACH_3, DownLoadTo, fc) & DownLoad(xxgk.ATTACH_4, DownLoadTo, fc) & DownLoad(xxgk.ATTACH_5, DownLoadTo, fc));
                            if (!download_success)
                            {
                                download_success = (DownLoad(xxgk.ATTACH_1, DownLoadTo, fc) & DownLoad(xxgk.ATTACH_2, DownLoadTo, fc) & DownLoad(xxgk.ATTACH_3, DownLoadTo, fc) & DownLoad(xxgk.ATTACH_4, DownLoadTo, fc) & DownLoad(xxgk.ATTACH_5, DownLoadTo, fc));
                            }
                            xxgk.ISDOWNLOAD = download_success;
                        });

                        db.SubmitChanges();
                        Log.WriteLog("SyncFTP success, count:" + not_download.Count + ".");
                    }
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog("SyncFTP Error\n" + ex.Message);
            }
        }
    }
}

