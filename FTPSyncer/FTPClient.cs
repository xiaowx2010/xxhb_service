using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace FTPSyncer
{
    public class FTPClient
    {
        private readonly string IP;
        private readonly string UserID;
        private readonly string Password;
        public FTPClient(string ip, string userID, string pwd)
        {
            IP = ip;
            UserID = userID;
            Password = pwd;
        }

        public void Download(string filePath, string fileName)
        {
            FtpWebRequest reqFTP = null;
            Stream ftpStream = null;
            try
            {
                FileStream outputStream = new FileStream(filePath + "\\" + fileName, FileMode.Create);
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + IP + "/" + fileName));
                reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(UserID, Password);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                ftpStream = response.GetResponseStream();
                long cl = response.ContentLength;
                int bufferSize = 2048;
                int readCount;
                byte[] buffer = new byte[bufferSize];

                readCount = ftpStream.Read(buffer, 0, bufferSize);
                while (readCount > 0)
                {
                    outputStream.Write(buffer, 0, readCount);
                    readCount = ftpStream.Read(buffer, 0, bufferSize);
                }

                ftpStream.Close();
                outputStream.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                if (ftpStream != null)
                {
                    ftpStream.Close();
                    ftpStream.Dispose();
                }
                throw new Exception(ex.Message.ToString());
            }
        }
    }
}
