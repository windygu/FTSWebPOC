using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Web.Services;
using System.Web;
using System.Web.Services.Protocols;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using FTS.BaseBusiness.PFSService;
using FTS.Global.Classes;
using FTS.Global.Utilities;
using FTS.Global.Interface;
using System.Data;
using System.Net;
using System.Management;
using System.Data.Common;

namespace FTS.BaseBusiness.Systems
{
    public class Pfs
    {
        private Service mService;
        private FTSMain mFtsMain;
        private bool mReady = false;

        public Pfs(FTSMain ftsmain)
        {
            this.mFtsMain = ftsmain;
            this.mService = new Service();            
            this.mService.Url = this.mFtsMain.PfsUrl;
            this.mService.Timeout = -1;
            CredentialSoapHeader header = new CredentialSoapHeader();
            header.UserName = "NT";
            header.PassWord = "cntt";
            this.mService.CredentialSoapHeaderValue = header;
            this.Ping();
        }
        private void Ping()
        {
            try
            {
                this.mReady = this.mService.Ready();
            }
            catch
            {
                this.mReady = false;
            }
        }
        public byte[] GetReports(byte[] arrFtsMain, byte[] arrFtsReport)
        {
            this.mService.Timeout = 1800000;
            return this.mService.GetReports(arrFtsMain, arrFtsReport);
        }
        public byte[] UpdateManagerBase(byte[] arrFtsMain, byte[] arrManagerBase) {
            this.mService.Timeout = 1800000;
            return this.mService.UpdateManagerBase(arrFtsMain, arrManagerBase);
        }
        public bool Ready
        {
            get { return this.mReady; }
        }
    }
}
