﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.9148
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.CompactFramework.Design.Data, Version 2.0.50727.9148.
// 
namespace PackageControl.PackageService {
    using System.Diagnostics;
    using System.Web.Services;
    using System.ComponentModel;
    using System.Web.Services.Protocols;
    using System;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="Service1Soap", Namespace="http://tempuri.org/")]
    public partial class Service1 : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        /// <remarks/>
        public Service1() {
            this.Url = "http://10.11.1.28/packageservice/service1.asmx";
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/HelloWorld", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string HelloWorld() {
            object[] results = this.Invoke("HelloWorld", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginHelloWorld(System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("HelloWorld", new object[0], callback, asyncState);
        }
        
        /// <remarks/>
        public string EndHelloWorld(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetRequiredClientVersion", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GetRequiredClientVersion() {
            object[] results = this.Invoke("GetRequiredClientVersion", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetRequiredClientVersion(System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetRequiredClientVersion", new object[0], callback, asyncState);
        }
        
        /// <remarks/>
        public string EndGetRequiredClientVersion(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/UploadScannedData", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public UploadScannedResult UploadScannedData(UploadScannedTableRow[] scannedBarcodes) {
            object[] results = this.Invoke("UploadScannedData", new object[] {
                        scannedBarcodes});
            return ((UploadScannedResult)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginUploadScannedData(UploadScannedTableRow[] scannedBarcodes, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("UploadScannedData", new object[] {
                        scannedBarcodes}, callback, asyncState);
        }
        
        /// <remarks/>
        public UploadScannedResult EndUploadScannedData(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((UploadScannedResult)(results[0]));
        }
    }
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class UploadScannedTableRow {
        
        private string constructionCodeField;
        
        private string requestField;
        
        private string houseCodeField;
        
        private string panelNoField;
        
        private int scannedFlgField;
        
        private int statusFlgField;
        
        private int designationField;
        
        private string updatedByField;
        
        private string palletGroupField;
        
        private string errMsgField;
        
        /// <remarks/>
        public string ConstructionCode {
            get {
                return this.constructionCodeField;
            }
            set {
                this.constructionCodeField = value;
            }
        }
        
        /// <remarks/>
        public string Request {
            get {
                return this.requestField;
            }
            set {
                this.requestField = value;
            }
        }
        
        /// <remarks/>
        public string HouseCode {
            get {
                return this.houseCodeField;
            }
            set {
                this.houseCodeField = value;
            }
        }
        
        /// <remarks/>
        public string PanelNo {
            get {
                return this.panelNoField;
            }
            set {
                this.panelNoField = value;
            }
        }
        
        /// <remarks/>
        public int ScannedFlg {
            get {
                return this.scannedFlgField;
            }
            set {
                this.scannedFlgField = value;
            }
        }
        
        /// <remarks/>
        public int StatusFlg {
            get {
                return this.statusFlgField;
            }
            set {
                this.statusFlgField = value;
            }
        }
        
        /// <remarks/>
        public int Designation {
            get {
                return this.designationField;
            }
            set {
                this.designationField = value;
            }
        }
        
        /// <remarks/>
        public string UpdatedBy {
            get {
                return this.updatedByField;
            }
            set {
                this.updatedByField = value;
            }
        }
        
        /// <remarks/>
        public string PalletGroup {
            get {
                return this.palletGroupField;
            }
            set {
                this.palletGroupField = value;
            }
        }
        
        /// <remarks/>
        public string ErrMsg {
            get {
                return this.errMsgField;
            }
            set {
                this.errMsgField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class UploadScannedResult {
        
        private int serverStatusField;
        
        private string serverMessageField;
        
        private UploadScannedTableRow[] uploadedDataField;
        
        /// <remarks/>
        public int ServerStatus {
            get {
                return this.serverStatusField;
            }
            set {
                this.serverStatusField = value;
            }
        }
        
        /// <remarks/>
        public string ServerMessage {
            get {
                return this.serverMessageField;
            }
            set {
                this.serverMessageField = value;
            }
        }
        
        /// <remarks/>
        public UploadScannedTableRow[] UploadedData {
            get {
                return this.uploadedDataField;
            }
            set {
                this.uploadedDataField = value;
            }
        }
    }
}
