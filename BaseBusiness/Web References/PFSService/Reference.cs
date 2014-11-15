﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.34014.
// 
#pragma warning disable 1591

namespace FTS.BaseBusiness.PFSService {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="ServiceSoap", Namespace="http://tempuri.org/")]
    public partial class Service : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private CredentialSoapHeader credentialSoapHeaderValueField;
        
        private System.Threading.SendOrPostCallback ReadyOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetReportsOperationCompleted;
        
        private System.Threading.SendOrPostCallback UpdateManagerBaseOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public Service() {
            this.Url = global::FTS.BaseBusiness.Properties.Settings.Default.FTS_BaseBusiness_PFSService_Service;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public CredentialSoapHeader CredentialSoapHeaderValue {
            get {
                return this.credentialSoapHeaderValueField;
            }
            set {
                this.credentialSoapHeaderValueField = value;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event ReadyCompletedEventHandler ReadyCompleted;
        
        /// <remarks/>
        public event GetReportsCompletedEventHandler GetReportsCompleted;
        
        /// <remarks/>
        public event UpdateManagerBaseCompletedEventHandler UpdateManagerBaseCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("CredentialSoapHeaderValue")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Ready", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool Ready() {
            object[] results = this.Invoke("Ready", new object[0]);
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void ReadyAsync() {
            this.ReadyAsync(null);
        }
        
        /// <remarks/>
        public void ReadyAsync(object userState) {
            if ((this.ReadyOperationCompleted == null)) {
                this.ReadyOperationCompleted = new System.Threading.SendOrPostCallback(this.OnReadyOperationCompleted);
            }
            this.InvokeAsync("Ready", new object[0], this.ReadyOperationCompleted, userState);
        }
        
        private void OnReadyOperationCompleted(object arg) {
            if ((this.ReadyCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ReadyCompleted(this, new ReadyCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("CredentialSoapHeaderValue")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetReports", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute(DataType="base64Binary")]
        public byte[] GetReports([System.Xml.Serialization.XmlElementAttribute(DataType="base64Binary")] byte[] arrFtsMain, [System.Xml.Serialization.XmlElementAttribute(DataType="base64Binary")] byte[] arrFtsReport) {
            object[] results = this.Invoke("GetReports", new object[] {
                        arrFtsMain,
                        arrFtsReport});
            return ((byte[])(results[0]));
        }
        
        /// <remarks/>
        public void GetReportsAsync(byte[] arrFtsMain, byte[] arrFtsReport) {
            this.GetReportsAsync(arrFtsMain, arrFtsReport, null);
        }
        
        /// <remarks/>
        public void GetReportsAsync(byte[] arrFtsMain, byte[] arrFtsReport, object userState) {
            if ((this.GetReportsOperationCompleted == null)) {
                this.GetReportsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetReportsOperationCompleted);
            }
            this.InvokeAsync("GetReports", new object[] {
                        arrFtsMain,
                        arrFtsReport}, this.GetReportsOperationCompleted, userState);
        }
        
        private void OnGetReportsOperationCompleted(object arg) {
            if ((this.GetReportsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetReportsCompleted(this, new GetReportsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("CredentialSoapHeaderValue")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/UpdateManagerBase", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute(DataType="base64Binary")]
        public byte[] UpdateManagerBase([System.Xml.Serialization.XmlElementAttribute(DataType="base64Binary")] byte[] arrFtsMain, [System.Xml.Serialization.XmlElementAttribute(DataType="base64Binary")] byte[] arrManagerBase) {
            object[] results = this.Invoke("UpdateManagerBase", new object[] {
                        arrFtsMain,
                        arrManagerBase});
            return ((byte[])(results[0]));
        }
        
        /// <remarks/>
        public void UpdateManagerBaseAsync(byte[] arrFtsMain, byte[] arrManagerBase) {
            this.UpdateManagerBaseAsync(arrFtsMain, arrManagerBase, null);
        }
        
        /// <remarks/>
        public void UpdateManagerBaseAsync(byte[] arrFtsMain, byte[] arrManagerBase, object userState) {
            if ((this.UpdateManagerBaseOperationCompleted == null)) {
                this.UpdateManagerBaseOperationCompleted = new System.Threading.SendOrPostCallback(this.OnUpdateManagerBaseOperationCompleted);
            }
            this.InvokeAsync("UpdateManagerBase", new object[] {
                        arrFtsMain,
                        arrManagerBase}, this.UpdateManagerBaseOperationCompleted, userState);
        }
        
        private void OnUpdateManagerBaseOperationCompleted(object arg) {
            if ((this.UpdateManagerBaseCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.UpdateManagerBaseCompleted(this, new UpdateManagerBaseCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/", IsNullable=false)]
    public partial class CredentialSoapHeader : System.Web.Services.Protocols.SoapHeader {
        
        private string userNameField;
        
        private string passWordField;
        
        private decimal idField;
        
        private System.Xml.XmlAttribute[] anyAttrField;
        
        /// <remarks/>
        public string UserName {
            get {
                return this.userNameField;
            }
            set {
                this.userNameField = value;
            }
        }
        
        /// <remarks/>
        public string PassWord {
            get {
                return this.passWordField;
            }
            set {
                this.passWordField = value;
            }
        }
        
        /// <remarks/>
        public decimal Id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr {
            get {
                return this.anyAttrField;
            }
            set {
                this.anyAttrField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    public delegate void ReadyCompletedEventHandler(object sender, ReadyCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ReadyCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ReadyCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    public delegate void GetReportsCompletedEventHandler(object sender, GetReportsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetReportsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetReportsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public byte[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((byte[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    public delegate void UpdateManagerBaseCompletedEventHandler(object sender, UpdateManagerBaseCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class UpdateManagerBaseCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal UpdateManagerBaseCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public byte[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((byte[])(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591