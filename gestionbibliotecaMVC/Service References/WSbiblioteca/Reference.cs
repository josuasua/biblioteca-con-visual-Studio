﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GestionBibliotecaMVC.WSbiblioteca {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Autor", Namespace="http://schemas.datacontract.org/2004/07/WcfBiblioteca")]
    [System.SerializableAttribute()]
    public partial class Autor : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ErrorMessageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NombreField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ErrorMessage {
            get {
                return this.ErrorMessageField;
            }
            set {
                if ((object.ReferenceEquals(this.ErrorMessageField, value) != true)) {
                    this.ErrorMessageField = value;
                    this.RaisePropertyChanged("ErrorMessage");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nombre {
            get {
                return this.NombreField;
            }
            set {
                if ((object.ReferenceEquals(this.NombreField, value) != true)) {
                    this.NombreField = value;
                    this.RaisePropertyChanged("Nombre");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="WSbiblioteca.IAutorService")]
    public interface IAutorService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAutorService/GetVersion", ReplyAction="http://tempuri.org/IAutorService/GetVersionResponse")]
        string GetVersion();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAutorService/GetVersion", ReplyAction="http://tempuri.org/IAutorService/GetVersionResponse")]
        System.Threading.Tasks.Task<string> GetVersionAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAutorService/getAutorById", ReplyAction="http://tempuri.org/IAutorService/getAutorByIdResponse")]
        GestionBibliotecaMVC.WSbiblioteca.Autor getAutorById(int codigoAutor);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAutorService/getAutorById", ReplyAction="http://tempuri.org/IAutorService/getAutorByIdResponse")]
        System.Threading.Tasks.Task<GestionBibliotecaMVC.WSbiblioteca.Autor> getAutorByIdAsync(int codigoAutor);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAutorServiceChannel : GestionBibliotecaMVC.WSbiblioteca.IAutorService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AutorServiceClient : System.ServiceModel.ClientBase<GestionBibliotecaMVC.WSbiblioteca.IAutorService>, GestionBibliotecaMVC.WSbiblioteca.IAutorService {
        
        public AutorServiceClient() {
        }
        
        public AutorServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AutorServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AutorServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AutorServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetVersion() {
            return base.Channel.GetVersion();
        }
        
        public System.Threading.Tasks.Task<string> GetVersionAsync() {
            return base.Channel.GetVersionAsync();
        }
        
        public GestionBibliotecaMVC.WSbiblioteca.Autor getAutorById(int codigoAutor) {
            return base.Channel.getAutorById(codigoAutor);
        }
        
        public System.Threading.Tasks.Task<GestionBibliotecaMVC.WSbiblioteca.Autor> getAutorByIdAsync(int codigoAutor) {
            return base.Channel.getAutorByIdAsync(codigoAutor);
        }
    }
}