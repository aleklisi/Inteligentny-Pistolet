﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PolicemanSymulationConsole.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Message", Namespace="http://schemas.datacontract.org/2004/07/MessagesLibrary")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(PolicemanSymulationConsole.ServiceReference1.UpdateMessage))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(PolicemanSymulationConsole.ServiceReference1.WarningMessage))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(PolicemanSymulationConsole.ServiceReference1.ShotMessage))]
    public partial class Message : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private PolicemanSymulationConsole.ServiceReference1.MessageType MessageTypeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UsernameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double XField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double YField;
        
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
        public PolicemanSymulationConsole.ServiceReference1.MessageType MessageType {
            get {
                return this.MessageTypeField;
            }
            set {
                if ((this.MessageTypeField.Equals(value) != true)) {
                    this.MessageTypeField = value;
                    this.RaisePropertyChanged("MessageType");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Username {
            get {
                return this.UsernameField;
            }
            set {
                if ((object.ReferenceEquals(this.UsernameField, value) != true)) {
                    this.UsernameField = value;
                    this.RaisePropertyChanged("Username");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double X {
            get {
                return this.XField;
            }
            set {
                if ((this.XField.Equals(value) != true)) {
                    this.XField = value;
                    this.RaisePropertyChanged("X");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Y {
            get {
                return this.YField;
            }
            set {
                if ((this.YField.Equals(value) != true)) {
                    this.YField = value;
                    this.RaisePropertyChanged("Y");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="UpdateMessage", Namespace="http://schemas.datacontract.org/2004/07/MessagesLibrary")]
    [System.SerializableAttribute()]
    public partial class UpdateMessage : PolicemanSymulationConsole.ServiceReference1.Message {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="WarningMessage", Namespace="http://schemas.datacontract.org/2004/07/MessagesLibrary")]
    [System.SerializableAttribute()]
    public partial class WarningMessage : PolicemanSymulationConsole.ServiceReference1.Message {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ShotMessage", Namespace="http://schemas.datacontract.org/2004/07/MessagesLibrary")]
    [System.SerializableAttribute()]
    public partial class ShotMessage : PolicemanSymulationConsole.ServiceReference1.Message {
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="MessageType", Namespace="http://schemas.datacontract.org/2004/07/MessagesLibrary")]
    public enum MessageType : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Update = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Warning = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Shot = 2,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IMessagesFilter")]
    public interface IMessagesFilter {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMessagesFilter/LogIn", ReplyAction="http://tempuri.org/IMessagesFilter/LogInResponse")]
        bool LogIn(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMessagesFilter/LogIn", ReplyAction="http://tempuri.org/IMessagesFilter/LogInResponse")]
        System.Threading.Tasks.Task<bool> LogInAsync(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMessagesFilter/ReceiveData", ReplyAction="http://tempuri.org/IMessagesFilter/ReceiveDataResponse")]
        void ReceiveData(PolicemanSymulationConsole.ServiceReference1.Message message);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMessagesFilter/ReceiveData", ReplyAction="http://tempuri.org/IMessagesFilter/ReceiveDataResponse")]
        System.Threading.Tasks.Task ReceiveDataAsync(PolicemanSymulationConsole.ServiceReference1.Message message);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IMessagesFilterChannel : PolicemanSymulationConsole.ServiceReference1.IMessagesFilter, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MessagesFilterClient : System.ServiceModel.ClientBase<PolicemanSymulationConsole.ServiceReference1.IMessagesFilter>, PolicemanSymulationConsole.ServiceReference1.IMessagesFilter {
        
        public MessagesFilterClient() {
        }
        
        public MessagesFilterClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MessagesFilterClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MessagesFilterClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MessagesFilterClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool LogIn(string username) {
            return base.Channel.LogIn(username);
        }
        
        public System.Threading.Tasks.Task<bool> LogInAsync(string username) {
            return base.Channel.LogInAsync(username);
        }
        
        public void ReceiveData(PolicemanSymulationConsole.ServiceReference1.Message message) {
            base.Channel.ReceiveData(message);
        }
        
        public System.Threading.Tasks.Task ReceiveDataAsync(PolicemanSymulationConsole.ServiceReference1.Message message) {
            return base.Channel.ReceiveDataAsync(message);
        }
    }
}
